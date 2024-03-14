Public Class dTeam
  Implements iControlIO, iGameEntity


  Private mID As dvID

  Private heroroster As New List(Of iHeroUnit)
  '  Private HeroPetRoster As New Dictionary(Of Integer, List(Of ctrlCreep_Badge)) 'integer = index of heroroster heroowner


  Private petroster As New List(Of Creep_Instance) 'index = npc position after herobadges
  'Private petroster As New List(Of HeroPet_Info)
  ' Public Event BadgeDirty( thebadge As ctrlHero_Badge)
  Private mTeamName As eTeamName

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged

  Public Event TargetsChanged(gameentity As iGameEntity)

  Private isLoading As Boolean = True

  Private mIsSelected As Boolean = False

  Private mFriendlyTarget As iDisplayUnit
  Private mFriendlyTargetIndex As Integer '0 to n for heroes, n + npcrosterindex for npc creeps

  Private mEnemyTarget As iDisplayUnit
  Private mEnemyTargetIndex As Integer

  Private mTargetFriendlyBias As Boolean

  Private mMyMods As List(Of Modifier)

  Private dbNames As FriendlyName_Database
  Private mGame As dGame
  Private mLog As Logging
  Private dbMods As Modifier_Database

  Private mMyStats As List(Of Stat)
  Public Sub New(teamname As eTeamName, game As dGame, thelog As Logging, moddb As Modifier_Database)

    mID = New dvID(Guid.NewGuid, "", eEntity.Team)
    mLog = thelog
    mTeamName = teamname

    mGame = game
    dbNames = game.dbNames


    dbMods = moddb
  End Sub

  Public Sub CalcMods() Implements iGameEntity.calcmods
    mMyStats = New List(Of Stat)
    'TeamAvgInt
    'TeamAvgAgi
    'TeamAvgStr
    Dim teamname = dbNames.GetFriendlyUnitName(mTeamName)
    'TeamTtlKills
    Dim kills As New Stat(eStattype.TeamKills, Me, mGame) ', "Kills")
    mMyStats.Add(kills)

    'TeamTtlEffectiveHP
    Dim effhp As New Stat(eStattype.TeamTtlEffectiveHP, Me, mGame) ', "Effective Hitpoints")
    mMyStats.Add(effhp)

    'TeamTtlDamageHi
    Dim ttllo As New Stat(eStattype.TeamTtlDamageLo, Me, mGame) ', "Damage Hi")
    mMyStats.Add(ttllo)

    'TeamTtlDamageLo
    Dim ttlhi As New Stat(eStattype.TeamTtlDamageHi, Me, mGame) ', "Damage Lo")
    mMyStats.Add(ttlhi)

    'TeamTtlDamageAvg
    Dim ttlavg As New Stat(eStattype.TeamTtlDamageAvg, Me, mGame) ', "Damage Avg")
    mMyStats.Add(ttlavg)


    ' TeamTtlHP()
    Dim ttlhp As New Stat(eStattype.TeamTtlHP, Me, mGame) ', "Hitpoints")
    mMyStats.Add(ttlhp)

    'TeamTtlHPRegen()
    Dim ttlhpr As New Stat(eStattype.TeamTtlHPRegen, Me, mGame) ', "HP Regen")
    mMyStats.Add(ttlhpr)

    'TeamTtlMana()
    Dim ttlmana As New Stat(eStattype.TeamTtlMana, Me, mGame) ', "Mana")
    mMyStats.Add(ttlmana)

    'TeamTtlManaRegen()
    Dim ttlmanar As New Stat(eStattype.TeamTtlManaRegen, Me, mGame) ', "Mana Regen")
    mMyStats.Add(ttlmanar)

    'TeamTtlVisionDay()
    Dim vday As New Stat(eStattype.TeamTtlVisionDay, Me, mGame) ', "Vision Day")
    mMyStats.Add(vday)

    'TeamTtlVisionNight()
    Dim vnight As New Stat(eStattype.TeamTtlVisionNight, Me, mGame) ', "Vision Night")
    mMyStats.Add(vnight)

    'TeamTtlDPSPeak()

    'TeamTtlPhysDamageBurst()
    Dim ttlpdam As New Stat(eStattype.TeamTtlPhysDamageBurst, Me, mGame) ', "Physical Damage Burst")
    mMyStats.Add(ttlpdam)

    'TeamTtlMagDamageBurst()
    Dim ttmag As New Stat(eStattype.TeamTtlMagDamageBurst, Me, mGame) ', "Magic Damage Burst")
    mMyStats.Add(ttmag)

    'TeamTtlPureDamageBurst()
    Dim ttlpoure As New Stat(eStattype.TeamTtlPureDamageBurst, Me, mGame) ', "Pure Damage Burst")
    mMyStats.Add(ttlpoure)

    'TeamTtlStunDuratoin()
    Dim ttlstun As New Stat(eStattype.TeamTtlStunDuratoin, Me, mGame) ', "Stun Duration")
    mMyStats.Add(ttlstun)

    'TeamTtlHexDuration()
    Dim ttlhex As New Stat(eStattype.TeamTtlHexDuration, Me, mGame) ', "Hex Duration")
    mMyStats.Add(ttlhex)

    'TeamTtlSpellImmunityTime()
    Dim imm As New Stat(eStattype.TeamTtlSpellImmunityCount, Me, mGame) ', "Spell Immunity Time")
    mMyStats.Add(imm)

    'TeamPhysical Armor
    Dim physarm As New Stat(eStattype.TeamPhysicalArmor, Me, mGame) ', "Physical Armor")
    mMyStats.Add(physarm)

    'team magic resistance
    Dim mresist As New Stat(eStattype.TeamMagicResistance, Me, mGame) ', "Magic Resistance")
    mMyStats.Add(mresist)


    dbMods.ReplaceStats(mMyStats, Nothing)
  End Sub




  'Public Sub AddCreepBadge(thecreep As Creep_Info, theowner As DDObject)

  '  thebadge.SetTargets(mEnemyTarget, mFriendlyTarget, mTargetFriendlyBias)

  '  Select Case theowner.type
  '    Case eEntity.Hero_Build
  '      'Dim hparent As HeroBuild = theowner.obj
  '      'Dim parentindex = Me.GetIndexOfHero(hparent.ID)

  '      'If HeroPetRoster.ContainsKey(parentindex) Then
  '      '  Dim outlist = HeroPetRoster.Item(parentindex)
  '      '  outlist.Add(thebadge)
  '      'Else
  '      'Dim outlist As New List(Of ctrlCreep_Badge)
  '      'outlist.Add(thebadge)
  '      'End If

  '    Case eEntity.Team
  '      creeproster.Add(thecreep)
  '  End Select


  'End Sub

  'Public Function GetDDObjectForID(theid As dvID) As DDObject
  '  Dim outobj As Object

  '  'hero roster
  '  For i As Integer = 0 To heroroster.Count - 1
  '    Dim curhero = heroroster.Item(i)
  '    'hero
  '    If curhero.Id.GuidID = theid.GuidID Then Return New DDObject(curhero, eEntity.Hero_Instance, theid, dbNames)
  '    'item
  '    outobj = curhero.GetItemByID(theid)
  '    If Not outobj Is Nothing Then Return New DDObject(outobj, eEntity.Item_Info, theid, dbNames)

  '    'ability
  '    outobj = curhero.GetAbilityById(theid)
  '    If Not outobj Is Nothing Then Return New DDObject(outobj, eEntity.Ability_Info, theid, dbNames)

  '  Next

  '  'creep roster
  '  For i As Integer = 0 To creeproster.Count - 1
  '    Dim curcreep = creeproster.Item(i)
  '    If curcreep.Id.GuidID = theid.GuidID Then Return New DDObject(curcreep, eEntity.Creep_Info, theid, dbNames)
  '  Next

  '  Dim errstr As String = ""
  '  For i As Integer = 0 To theid.MetaInfo.Count - 1
  '    errstr = errstr & theid.MetaInfo.Item(i) & " "
  '  Next
  '  mLog.WriteLog("dTeam.GetDDObjectForID missing DDObject for ID: " & theid.FriendlyGuid & " " & errstr)
  '  Return Nothing
  'End Function

  Public Sub SetTargets(theenemytarget As iHeroUnit, _
                         thefriendlytarget As iHeroUnit, isfriendbias As Boolean)

    If theenemytarget Is thefriendlytarget Then
      Dim x = 2
    End If
    mEnemyTarget = theenemytarget
    mEnemyTargetIndex = theenemytarget.TeamPosition

    mFriendlyTarget = thefriendlytarget
    mFriendlyTargetIndex = thefriendlytarget.TeamPosition

    mTargetFriendlyBias = isfriendbias

    For i As Integer = 0 To heroroster.Count - 1
      heroroster.Item(i).SetTargets(theenemytarget, thefriendlytarget, TargetFriendlyBias)
    Next

    'RaiseEvent TargetsChanged(New DDObject(Me, eEntity.Team))
  End Sub


  Public ReadOnly Property FriendlyTarget As iHeroUnit
    Get
      Return mFriendlyTarget
    End Get

  End Property

  Public ReadOnly Property FriendlyTargetIndex As Integer
    Get
      Return mFriendlyTargetIndex
    End Get
  End Property

  Public ReadOnly Property EnemyTargetIndex As Integer
    Get
      Return mEnemyTargetIndex
    End Get
  End Property
  Public ReadOnly Property EnemyTarget As iHeroUnit
    Get
      Return mEnemyTarget
    End Get
    'Set(value As dvID)
    '  mEnemyTarget = value
    'End Set
  End Property

  Public ReadOnly Property TargetFriendlyBias As Boolean
    Get
      Return mTargetFriendlyBias
    End Get
    'Set(value As Boolean)
    '  mTargetFriendlyBias = value
    'End Set
  End Property


  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property
  Public ReadOnly Property TeamName As eTeamName
    Get
      Return mTeamName
    End Get
  End Property
  Public ReadOnly Property Count As Integer
    Get
      Return heroroster.Count
    End Get
  End Property

  Public Function Item(theindex As Integer) As iHeroUnit

    Return heroroster.Item(theindex)

  End Function

  Public Function GetUnitWithLowestHealth(thetime As ddFrame) As iUnit
    Dim lowesthealthunit As iUnit

    For i = 0 To petroster.Count - 1
      If i = 0 Then lowesthealthunit = petroster.Item(0)
      Dim curlowesthitpoints = dbMods.GetStatByParentandType(lowesthealthunit, eStattype.HitPoints)

      Dim newhitpoints = dbMods.GetStatByParentandType(petroster.Item(i), eStattype.HitPoints)
      If newhitpoints.Value(thetime) < curlowesthitpoints.Value(thetime) Then
        lowesthealthunit = petroster.Item(i)
      End If

    Next


    For i = 0 To heroroster.Count - 1
      If lowesthealthunit Is Nothing Then lowesthealthunit = heroroster.Item(0)

      Dim curlowesthitpoints = dbMods.GetStatByParentandType(lowesthealthunit, eStattype.HitPoints)

      Dim newhitpoints = dbMods.GetStatByParentandType(heroroster.Item(i), eStattype.HitPoints)
      If newhitpoints.Value(thetime) < curlowesthitpoints.Value(thetime) Then
        lowesthealthunit = heroroster.Item(i)
      End If
    Next


    Return lowesthealthunit

    '    Return New DDObject(heroroster.Item(heroroster.Count - 1), eEntity.Hero_Instance)

  End Function
  Public Function GetColorForID(theheroid As dvID) As Color
    For i As Integer = 0 To heroroster.Count - 1
      If heroroster.Item(i).Id.GuidID = theheroid.GuidID Then
        Dim outcolor = heroroster.Item(i).MyColor
        Return outcolor
      End If
    Next

    Return PageHandler.dbColors.ErrorColor

  End Function
  Public Function ContainsUnit(unit As iDisplayUnit)
    Return ContainsID(unit.Id)
    Return False
  End Function

  Public Function ContainsID(id As dvID)
    If Me.mID.GuidID = id.GuidID Then Return True
    For i As Integer = 0 To heroroster.Count - 1
      If heroroster.Item(i).Id.GuidID = id.GuidID Then Return True
    Next

    For i As Integer = 0 To petroster.Count - 1
      If petroster.Item(i).Id.GuidID = id.GuidID Then Return True
    Next
    Return False
  End Function
  Public Sub RemoveHeroBadge(heroposition As Integer)

    If heroposition <= heroroster.Count Then
      isLoading = True
      heroroster.RemoveAt(heroposition)
      isLoading = False
    End If
  End Sub
  ''' <summary>
  ''' Heroposition is zero based
  ''' </summary>
  Private Sub AddHeroInstance(thehero As HeroInstance, heroindex As Integer)

    If heroindex >= heroroster.Count Then
      isLoading = True
      heroroster.Add(thehero)
      AddHandler thehero.isDirty, AddressOf Object_isDirty
      AddHandler thehero.TargetsChanged, AddressOf HeroBadge_TargetsChanged

    Else
      heroroster.Insert(heroindex, thehero)

    End If
    isLoading = False
  End Sub
  Public Sub AddorReplaceHeroInstance(thehero As HeroInstance, heroposition As Integer)
    isLoading = True
    If heroposition <= heroroster.Count - 1 Then
      Dim oldhero = heroroster.Item(heroposition)
      If oldhero IsNot Nothing Then
        mGame.dbModifiers.RemoveAllHeroModsAndStatsByHero(oldhero)
        thehero.SetTargets(oldhero.GetEnemyTarget, oldhero.GetFriendlyTarget, oldhero.GetTargetFriendBias)
      End If
      heroroster.RemoveAt(heroposition)
      AddHeroInstance(thehero, heroposition)
    Else
      thehero.mTeamPosition = heroroster.Count
      heroroster.Add(thehero)
    End If
    Dim newtargets As Boolean = False
    If heroposition = mEnemyTargetIndex Then
      mEnemyTarget = thehero
      newtargets = True
    End If
    If heroposition = mFriendlyTargetIndex Then
      mFriendlyTarget = thehero
      newtargets = True
    End If

    If newtargets Then
      RaiseEvent TargetsChanged(Me)
    End If
    CalcMods()
    isLoading = False
  End Sub


  Public Function GetAllHeroes() As List(Of iDisplayUnit)
    Dim outlist As New List(Of iDisplayUnit)

    For i As Integer = 0 To Me.Count - 1
      outlist.Add(Me.Item(i))
    Next

    Return outlist
  End Function

  Public Function GetAllStructures() As List(Of iDisplayUnit)
    Return New List(Of iDisplayUnit)
  End Function

  Public Sub ReplaceTarget(oldtarger As dvID, newtarget As dvID)
    If mEnemyTarget.Id.GuidID = oldtarger.GuidID Then mEnemyTarget = newtarget
    If mFriendlyTarget.Id.GuidID = oldtarger.GuidID Then mFriendlyTarget = newtarget
  End Sub
  Public Function GetHeroInstance(theid As dvID) As HeroInstance
    For i As Integer = 0 To heroroster.Count - 1
      If heroroster.Item(i).Id.GuidID = theid.GuidID Then
        Return heroroster.Item(i)
      End If
    Next
    Return Nothing
  End Function

  Public Function GetHeroInstances() As List(Of iHeroUnit)
    Return heroroster
  End Function
  Public Function GetCreepInstance(theid As dvID) As Creep_Instance
    For i As Integer = 0 To petroster.Count - 1
      If petroster.Item(i).Id.GuidID = theid.GuidID Then
        Return petroster.Item(i)
      End If
    Next
    Return Nothing
  End Function
  'Public Function GetHeroInstanceByPositionIndex(theindex As Integer) As HeroInstance
  '  If theindex <= heroroster.Count Then
  '    Return heroroster.Item(theindex)
  '  End If
  '  Return Nothing
  'End Function

  Public Function GetHeroInstance(heroesindex As Integer) As HeroInstance
    If Not heroroster.Count > heroesindex Then
      Return Nothing
    End If
    Return heroroster.Item(heroesindex)
  End Function
  Public Function GetAllHeroInstances() As List(Of HeroInstance)
    Dim outlist As New List(Of HeroInstance)
    For i As Integer = 0 To heroroster.Count - 1
      outlist.Add(heroroster.Item(i))
    Next
    Return outlist
  End Function
  Public Function GetIndexOfHero(theid As dvID) As Integer
    For i As Integer = 0 To heroroster.Count - 1
      If heroroster.Item(i).Id.GuidID = theid.GuidID Then Return i
    Next
    Return -1
  End Function

  Public ReadOnly Property HeroCount As Integer
    Get
      Return heroroster.Count
    End Get
  End Property
  'Public Function GetAllNonHeroeUnits() As List(Of iDisplayUnit)
  '  Dim outlist As New List(Of iDisplayUnit)
  '  For i As Integer = 0 To creeproster.Count - 1
  '    outlist.Add(creeproster.Item(i))
  '  Next
  '  Return outlist
  'End Function


  Public Function GetAllPetUnits() As List(Of iDisplayUnit)
    'this needs a modfilter to get rid of nonpets
    Dim outlist As New List(Of iDisplayUnit)
    For Each pet In petroster
      outlist.Add(DirectCast(pet, iDisplayUnit))
    Next
    Return outlist

  End Function

  Public Function GetAllCreepUnits() As List(Of iDisplayUnit)
    'creeps as pseudo members of a team not yet implemented
    Return New List(Of iDisplayUnit)
  End Function
  Public Function GetAllHeroAndPetUnits() As List(Of iDisplayUnit)
    Dim outlist As New List(Of iDisplayUnit)

    For Each Hero In heroroster
      outlist.Add(DirectCast(Hero, iDisplayUnit))
    Next

    For Each pet In petroster
      outlist.Add(DirectCast(pet, iDisplayUnit))
    Next

    Return outlist
  End Function

  Public Function GetAllGameEntitiesIncludingTeamGameEntity() As List(Of iGameEntity)
    Dim outlist As New List(Of iGameEntity)
    outlist.Add(DirectCast(Me, iGameEntity))
    For Each gameentity In GetAllHeroAndPetUnits()
      outlist.Add(DirectCast(gameentity, iGameEntity))
    Next
    Return outlist
  End Function
  Private Sub Object_isDirty(gameentity As iGameEntity)
    If Not isLoading Then
      RaiseEvent isDirty(gameentity)
    End If

  End Sub



  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    mIsSelected = isselected
  End Sub

  Private Sub HeroBadge_TargetsChanged(gameentity As iGameEntity)
    Dim x = 2
  End Sub



  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mTeamName.ToString
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Team
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mGame
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return eSourceType.Game
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Select Case mTeamName
        Case eTeamName.Dire
          Return PageHandler.dbColors.DireColor
        Case eTeamName.Radiant
          Return PageHandler.dbColors.RadiantColor
        Case Else
          Throw New NotImplementedException
      End Select
    End Get
    Set(value As Color)

    End Set
  End Property
End Class
