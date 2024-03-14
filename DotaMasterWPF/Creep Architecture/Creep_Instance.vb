Public Class Creep_Instance
  Implements iCreepUnit





#Region "Vars"
  Private mID As dvID
  Private mCInfo As Creep_Info
  Public mGame As dGame
  Private mDisplayName As String
  Private mLog As Logging


  Private mParent As iGameEntity

  Private mActiveItemsByLevel As New Item_List

  Private mItemInv As Hero_Item_Inventory
  Private mAbility_Inventory As iCreep_Ability_Inventory

  'Team Stuff
  Private mTeam As dTeam
  Private mTeamPosition As Integer

  'targetting
  Private mEnemyTarget As iDisplayUnit
  Private mFriendTarget As iDisplayUnit
  Private mTargetBias As Boolean
  'special cases
  Private mIsMeepo As Boolean = False
  Private mIsSpirit_Bear As Boolean = False


#End Region

  Public Sub New(thecreep As Creep_Info, thecreepdisplayname As String, theparent As iDisplayUnit, _
                  teamposition As Integer, myteam As dTeam, thegame As dGame, _
                  thelog As Logging)
    mCInfo = thecreep
    mGame = thegame
    DisplayName = thecreepdisplayname
    Me.ParentGameEntity = theparent
    mTeamPosition = teamposition
    mTeam = myteam
    mLog = thelog

    mID = New dvID(Guid.NewGuid, "Creep_Instance New", eEntity.Creep_Instance)

    Me.ParentGameEntityType = theparent.MyType


    SetTargets(mTeam.EnemyTarget, mTeam.FriendlyTarget, mTeam.TargetFriendlyBias)

    Me.ImageUrl = New Uri(mCInfo.mUnitImage)
    Me.calcmods()
  End Sub

#Region "Info"
  Public Property CreepName As eCreepName Implements iCreepUnit.CreepName
    Get
      Return mCInfo.mName
    End Get
    Set(value As eCreepName)

    End Set
  End Property

  Public Property Lifetime As Lifetime Implements iDisplayUnit.Lifetime
    Get
      Throw New NotImplementedException
    End Get
    Set(value As Lifetime)

    End Set
  End Property

  Public Property TeamPosition As Integer Implements iCreepUnit.TeamPosition
    Get
      Return mTeamPosition
    End Get
    Set(value As Integer)

    End Set
  End Property


  Public Property ImageUrl As Uri Implements iDisplayUnit.ImageUrl
    Get
      Return New Uri(mCInfo.mUnitImage)
    End Get
    Set(value As Uri)

    End Set
  End Property


  Public Property MyColor As Color Implements iDisplayUnit.MyColor
    Get
      Return mCInfo.MyColor
    End Get
    Set(value As Color)

    End Set
  End Property

  Public Property Team As dTeam Implements iDisplayUnit.Team
    Get
      Return mTeam
    End Get
    Set(value As dTeam)

    End Set
  End Property

  Public Property WebPageUrl As Uri Implements iDisplayUnit.WebPageUrl
    Get
      Throw New NotImplementedException
    End Get
    Set(value As Uri)

    End Set
  End Property

  Public Function GetLevelForTime(thetime As ddFrame) As Integer Implements iDisplayUnit.GetLevelForTime
    Return mCInfo.GetLevelForTime(thetime)
  End Function

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType


#End Region

#Region "Targetting"
  Public Function GetEnemyTarget() As iDisplayUnit Implements iDisplayUnit.GetEnemyTarget
    Return mEnemyTarget
  End Function

  Public Function GetFriendlyTarget() As iDisplayUnit Implements iDisplayUnit.GetFriendlyTarget
    Return mFriendTarget
  End Function

  Public Function GetTargetFriendBias() As Boolean Implements iDisplayUnit.GetTargetFriendBias
    Return mTargetBias

  End Function

  Public Sub SetTargets(newenemytarget As iDisplayUnit, newfriendlytarget As iDisplayUnit, newfriendbias As Boolean) Implements iDisplayUnit.SetTargets
    Dim myenemytargetguid As Guid
    If Not mEnemyTarget Is Nothing Then
      myenemytargetguid = mEnemyTarget.Id.GuidID
    End If

    Dim myfriendlytargetguid As Guid
    If Not mFriendTarget Is Nothing Then
      myfriendlytargetguid = mFriendTarget.Id.GuidID
    End If

    Dim newenemytargetguid = newenemytarget.Id.GuidID
    Dim newfriendlytargetguid = newfriendlytarget.Id.GuidID
    Dim newtargetbias = newfriendbias

    If myenemytargetguid = newenemytargetguid And myfriendlytargetguid = newfriendlytargetguid And mTargetBias = newtargetbias Then Exit Sub

    mCInfo.SetTargets(newenemytarget, newfriendlytarget, newfriendbias)

  End Sub

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Creep_Instance
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mParent
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property UnitName As eUnit Implements iUnit.UnitName
    Get
      Throw New NotImplementedException
    End Get
    Set(value As eUnit)

    End Set
  End Property

  Public Property UnitType As eUnittype Implements iUnit.UnitType
    Get
      Throw New NotImplementedException
    End Get
    Set(value As eUnittype)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Creep_Instance
    End Get
    Set(value As eSourceType)

    End Set
  End Property
#End Region

  Public Property Armor As Stat Implements iDisplayUnit.Armor
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.PhysicalArmor)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property HitPoints As Stat Implements iDisplayUnit.HitPoints
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.HitPoints)
    End Get
    Set(value As Stat)

    End Set
  End Property


  Public Property MovementSpeed As Stat Implements iDisplayUnit.MovementSpeed
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.MovementSpeed)
    End Get
    Set(value As Stat)

    End Set
  End Property
#Region "Stats"
  Public Sub calcmods() Implements iGameEntity.calcmods
    Dim mmymodinfo = New modInfo(eAbilityType.Passive, _
                         Me, _
                         Me, _
                         Me, eUnit.untSelf, "", eModifierCategory.Passive)

    Dim mymods As New ModifierList
    Dim mystats As New List(Of Stat)

    Dim dbmods = mGame.dbModifiers

    Dim armormodval As New modValue(mCInfo.mArmor, eModifierType.ArmorAdded, Me.Lifetime, Nothing)
    Dim armormod As New Modifier(armormodval, mmymodinfo)
    mymods.Add(armormod)


    Dim hpval As New modValue(mCInfo.mHealth, eModifierType.HPAdded, Me.Lifetime, Nothing)
    Dim hpmod As New Modifier(hpval, mmymodinfo)
    mymods.Add(hpmod)


    Dim moveval As New modValue(mCInfo.mMoveSpeed, eModifierType.MoveSpeedAdded, Me.Lifetime, Nothing)
    Dim movemod As New Modifier(moveval, mmymodinfo)
    mymods.Add(movemod)


    'TODO incorporate damage increment for things such as melee creeps whose 
    'damage increase by damage increment every 7:30 minutes

    Dim damhival As New modValue(mCInfo.mDamage.Item(1).Value(0), eModifierType.BaseAttackDamageHigh, Me.Lifetime)
    Dim damhimod As New Modifier(damhival, mmymodinfo)
    mymods.Add(damhimod)

    Dim damloval As New modValue(mCInfo.mDamage.Item(0).Value(0), eModifierType.BaseAttackDamageLow, Me.Lifetime)
    Dim damlomod As New Modifier(damloval, mmymodinfo)
    mymods.Add(damlomod)


    Dim damavgval As New modValue(mCInfo.mDamage.Item(1).Value(0) - mCInfo.mDamage.Item(0).Value(0), eModifierType.BaseAttackDamageAvg, Me.Lifetime)
    Dim damavgmod As New Modifier(damavgval, mmymodinfo)
    mymods.Add(damavgmod)

    Dim manaval As New modValue(mCInfo.mMana, eModifierType.ManaAdded, Me.Lifetime, Nothing)
    Dim manamod As New Modifier(manaval, mmymodinfo)
    mymods.Add(manamod)

    Dim manaregenval As New modValue(mCInfo.mManaRegen, eModifierType.ManaRegenAdded, Me.Lifetime, Nothing)
    Dim manaregenmod As New Modifier(manaregenval, mmymodinfo)
    mymods.Add(manaregenmod)

    Dim magicresistval As New modValue(mCInfo.mMagicResistance, eModifierType.MagicResistanceAdded, Me.Lifetime, Nothing)
    Dim magicresistmod As New Modifier(magicresistval, mmymodinfo)
    mymods.Add(magicresistmod)

    Dim visiondayval As New modValue(mCInfo.mSightrange.Item(0), eModifierType.VisionDay, Me.Lifetime, Nothing)
    Dim visiondaymod As New Modifier(visiondayval, mmymodinfo)
    mymods.Add(visiondaymod)

    Dim visionnightval As New modValue(mCInfo.mSightrange.Item(1), eModifierType.VisionNight, Me.Lifetime, Nothing)
    Dim visionnightmod As New Modifier(visionnightval, mmymodinfo)
    mymods.Add(visionnightmod)

    Dim atttimeval As New modValue(mCInfo.mBaseAttacktime, eModifierType.BaseAttackTime, Me.Lifetime, Nothing)
    Dim atttimemod As New Modifier(atttimeval, mmymodinfo)
    mymods.Add(atttimemod)



    'add stats and mods we have so far so they are available for next calcs
    dbmods.RemoveAllHeroModsAndStatsByHero(Me)
    dbmods.ReplaceStats(mystats, Nothing)
    dbmods.ReplaceModifiers(mymods, Nothing)

    Dim armorstat As New Stat(eStattype.PhysicalArmor, Me, mGame) ', "Armor")
    mystats.Add(armorstat)

    Dim hpstat As New Stat(eStattype.HitPoints, Me, mGame) ', "Hit Points")
    mystats.Add(armorstat)

    Dim movestat As New Stat(eStattype.MovementSpeed, Me, mGame) ', "Movement Speed")
    mystats.Add(movestat)

    Dim damhistat As New Stat(eStattype.AttackDamageHigh, Me, mGame) ', "Attack Damage High")
    mystats.Add(damhistat)

    Dim damlostat As New Stat(eStattype.AttackDamageLow, Me, mGame) ', "Attack Damage Low")
    mystats.Add(damlostat)

    Dim damavgstat As New Stat(eStattype.AttackDamageAverage, Me, mGame) ', "Attack Damage Average")
    mystats.Add(damavgstat)

    Dim manastat As New Stat(eStattype.Mana, Me, mGame) ', "Mana")
    mystats.Add(manastat)

    Dim manaregenstat As New Stat(eStattype.ManaRegen, Me, mGame) ', "Mana Regen")
    mystats.Add(manaregenstat)

    Dim magicresiststat As New Stat(eStattype.MagicalDamageResistance, Me, mGame) ', "Magic Resistance")
    mystats.Add(magicresiststat)


    Dim visiondaystat As New Stat(eStattype.VisionDay, Me, mGame) ', "Vision Day")
    mystats.Add(visiondaystat)

    Dim visionnightstat As New Stat(eStattype.VisionNight, Me, mGame) ', "Vision Night")
    mystats.Add(visionnightstat)

    Dim atttimestat As New Stat(eStattype.AttackSpeed, Me, mGame) ', "Attack Speed")
    mystats.Add(atttimestat)

    dbmods.ReplaceStats(mystats, Nothing)
  End Sub
#End Region

#Region "Aghs"
  Public Function NonScepterExistsAtLevel(lvl As Integer) Implements iCreepUnit.NonScepterExistsAtLevel
    Return mCInfo.NonScepterExistsAtLevel(lvl)
  End Function

#End Region

  '#Region "Items"
  '  Public Sub DeleteItemAtIndex(theindex As Integer) Implements iDisplayUnit.DeleteItemAtIndex
  '    mItemInv.DeleteItemAtIndex(theindex)
  '  End Sub

  '  Public Function GetItemByID(id As dvID) As Item_Info Implements iDisplayUnit.GetItemByID
  '    Return mItemInv.mItemBuildAndAutoGeneratedItems.GetItemByIdItem(id)
  '  End Function

  '  Public Function GetItemLifetime(item As Item_Info) As Lifetime Implements iDisplayUnit.GetItemLifetime
  '    If Not ItemBuildSequence.ContainsIDItem(item.Id) Then Return Nothing

  '    Return ItemBuildSequence.GetItemByIdItem(item.Id).Lifetime
  '  End Function

  '  Public Function GetItemsAtTime(time As ddFrame) As Item_List Implements iDisplayUnit.GetItemsAtTime
  '    Return mCInfo.GetItemsAtTime(time)
  '  End Function

  '  Public Sub InsertItemAtIndex(theindex As Integer, theitem As Item_Info) Implements iDisplayUnit.InsertItemAtIndex
  '    mItemInv.InsertItemAtIndex(theindex, theitem)
  '  End Sub

  '  Public Property ItemBuildSequence As Item_List Implements iDisplayUnit.ItemBuildSequence
  '    Get
  '      Return mItemInv.mItemBuildSequence
  '    End Get
  '    Set(value As Item_List)

  '    End Set
  '  End Property

  '  Public Property ItemBuildAndAutoGeneratedItems As Item_List Implements iDisplayUnit.ItemBuildAndAutoGeneratedItems
  '    Get
  '      Return mItemInv.mItemBuildAndAutoGeneratedItems
  '    End Get
  '    Set(value As Item_List)

  '    End Set
  '  End Property

  '  Public Sub ReplaceItemAtIndex(item As Item_Info, index As Integer) Implements iDisplayUnit.ReplaceItemAtIndex
  '    mItemInv.ReplaceItemAtIndex(item, index)
  '  End Sub

  '#End Region

#Region "Abilitites"


  'Public Property AbilitiesListedByUIPosition As List(Of Ability_Info) Implements iDisplayUnit.AbilitiesListedByUIPosition
  '  Get
  '    Return mAbility_Inventory.AbilitiesListedByUIPosition
  '  End Get
  '  Set(value As List(Of Ability_Info))

  '  End Set
  'End Property

  'Public Function GetAbilityById(id As dvID) As Ability_Info Implements iDisplayUnit.GetAbilityById

  '  Return mAbility_Inventory.GetAbilityById(id)

  'End Function

  'Public Function GetAbilityByPosition(position As Integer) As Ability_Info Implements iDisplayUnit.GetAbilityByPosition
  '  Return mAbility_Inventory.AbilitiesListedByUIPosition.Item(position)
  'End Function

  'Public Function GetAbilityInfos(game As dGame) As List(Of Ability_Info) Implements iDisplayUnit.GetAbilityInfos
  '  Return mCInfo.AbilityInfos()
  'End Function

  'Public Function GetAbilityLevel(theab As Ability_Info, herolevel As Integer) As Integer Implements iDisplayUnit.GetAbilityLevel
  '  Return AbilitiesListedByUIPosition.IndexOf(theab)
  'End Function

  'Public Function GetActiveAbilitiesByLevel(herolevel As Integer) As List(Of Integer) Implements iDisplayUnit.GetActiveAbilitiesByLevel
  '  Return mCInfo.GetActiveAbilitiesByLevel(herolevel)
  'End Function



#End Region




  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mDisplayName
    End Get
    Set(value As String)

    End Set
  End Property

  'Public Function GetAbilityNames() As List(Of eAbilityName) Implements iDisplayUnit.GetAbilityNames
  '  Dim outlist As New List(Of eAbilityName)
  '  For abilityindex = 0 To mAbility_Inventory.AbilitiesListedByUIPosition.Count - 1
  '    outlist.Add(mAbility_Inventory.AbilitiesListedByUIPosition.Item(abilityindex).AbilityName)
  '  Next
  '  Return outlist
  'End Function




  Public Property CreepsOwned As List(Of CreepStack) Implements iCreepUnit.CreepsOwned
    Get
      Throw New NotImplementedException
    End Get
    Set(value As List(Of CreepStack))

    End Set
  End Property
End Class
