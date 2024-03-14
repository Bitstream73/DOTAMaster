Imports System.Windows.Media.Imaging
Imports DotaMasterWPF.PageHandler
Public Class Creep_Info

#Region "Vars"
  Private mIDItem As dvID
  Public mParent As iDisplayUnit
  Public mGame As dGame
  Public mName As eCreepName
  Public mFriendlyName As String
  Public mUnitType As eUnittype
  Public mUnitImage As String
  Public mWebpageLink As String
  Public mDuration As ValueWrapper
  Public mLevel As ValueWrapper
  Public mHealth As ValueWrapper
  Public mHealthIncrement As ValueWrapper
  Public mHealthRegen As ValueWrapper
  Public mMana As ValueWrapper
  Public mManaRegen As ValueWrapper
  Public mDamage As List(Of ValueWrapper)
  Public mDamageIncrement As ValueWrapper
  Public mMagicResistance As ValueWrapper
  Public mArmor As ValueWrapper
  Public mArmorType As eArmorType
  Public mMoveSpeed As ValueWrapper
  Public mCOllisionSize As ValueWrapper
  Public mSightrange As List(Of ValueWrapper)
  Public mAttackType As eAttackType
  Public mAttackSubType As eAttackSubType
  Public mAttackRange As ValueWrapper
  Public mAttackDuration As List(Of ValueWrapper)
  Public mCastDuration As List(Of ValueWrapper)
  Public mMissileSpeed As ValueWrapper
  Public mBaseAttacktime As ValueWrapper
  Public mBounty As New List(Of ValueWrapper)
  Public mXp As ValueWrapper

  Public mAbilityNames As List(Of eAbilityName)
  Private mAbilityInfos As Ability_Info_List

  Public mLifetime As Lifetime
  Private mExistsAtLevel As ValueWrapper
  Private mScepterExistsAtLevel As ValueWrapper

  Private mColor As Color


  Public mTeam As eTeamName = eTeamName.None
  Public mTeamPosition As Integer = -1


  'for spirit bear
  Private mItemList As Item_List
  Private ItemInv As Hero_Item_Inventory
  Private mGoldcurve As EconomyCurve
  Private mXPCurve As EconomyCurve

  'Public mTeamEnemyTarget As dvID = Nothing
  'Public mTeamFriendlyTarget As dvID = Nothing
  'Public mTargetFriendbias As Boolean


  'target stuff
  Public mTeamEnemyTarget As iDisplayUnit
  Public mTeamFriendlyTarget As iDisplayUnit
  Public mTargetFriendBias As Boolean

  'pets, illusions creeps, spiderites
  Private mPetsOwned As List(Of CreepStack)

  Private mMyMods As List(Of Modifier)

#End Region


#Region "Creep Over Time stuff"


  Private mActiveAbilitiesByLevel As New List(Of List(Of Integer)) 'integer represents the level of the ability, 0 means unpicked

  Private mActiveItemsByLevel As New Item_List

#End Region
  Public Sub New(theIDItem As dvID, _
                   theName As eCreepName, _
                   theparent As iGameEntity, _
                   theUnitType As eUnittype, _
                   theUnitImage As String, _
                   theWebpageLink As String, _
                   theDuration As ValueWrapper, _
                   theLevel As ValueWrapper, _
                   theHealth As ValueWrapper, _
                   theHealthIncrement As ValueWrapper, _
                   theHealthRegen As ValueWrapper, _
                   theMana As ValueWrapper, _
                   theManaRegen As ValueWrapper, _
                   theDamage As List(Of ValueWrapper), _
                   theDamageIncrement As ValueWrapper, _
                     theMagicResistance As ValueWrapper, _
                     theArmor As ValueWrapper, _
                     theArmorType As eArmorType, _
                     theMoveSpeed As ValueWrapper, _
                     theCOllisionSize As ValueWrapper, _
                     theSightrange As List(Of ValueWrapper), _
                     theAttackType As eAttackType, _
                     theAttackSubType As eAttackSubType, _
                     theAttackRange As ValueWrapper, _
                     theAttackDuration As List(Of ValueWrapper), _
                     theCastDuration As List(Of ValueWrapper), _
                     theMissileSpeed As ValueWrapper, _
                     theBaseAttacktime As ValueWrapper, _
                     theBounty As List(Of ValueWrapper), _
                     theXp As ValueWrapper, _
                     theAbilityNames As List(Of eAbilityName), _
                     thecreeplevel As Integer, _
                     thelifetime As Lifetime, _
                     theexistsatlevel As ValueWrapper, _
                     thescepterexistsatlvl As ValueWrapper, _
                     thegame As dGame)


    mIDItem = theIDItem
    mName = theName
    mParent = theparent
    mUnitType = theUnitType
    mUnitImage = theUnitImage
    mWebpageLink = theWebpageLink
    mDuration = theDuration
    mLevel = theLevel
    mHealth = theHealth
    mHealthIncrement = theHealthIncrement
    mHealthRegen = theHealthRegen
    mMana = theMana
    mManaRegen = theManaRegen
    mDamage = theDamage
    mDamageIncrement = theDamageIncrement
    mMagicResistance = theMagicResistance
    mArmor = theArmor
    mArmorType = theArmorType
    mMoveSpeed = theMoveSpeed
    mCOllisionSize = theCOllisionSize
    mSightrange = theSightrange
    mAttackType = theAttackType
    mAttackSubType = theAttackSubType
    mAttackRange = theAttackRange
    mAttackDuration = theAttackDuration
    mCastDuration = theCastDuration
    mMissileSpeed = theMissileSpeed
    mBaseAttacktime = theBaseAttacktime
    mBounty = theBounty
    mXp = theXp
    mAbilityNames = theAbilityNames
    mLifetime = thelifetime

    mExistsAtLevel = theexistsatlevel
    mScepterExistsAtLevel = thescepterexistsatlvl

    mGame = thegame
    CalcColor()
  End Sub


  Public Function NonScepterExistsAtLevel(thelevel As Integer) As Boolean
    If mExistsAtLevel Is Nothing Then Return True

    If mExistsAtLevel.Value(thelevel - 1) = 1 Then Return True
    Return False
  End Function

  Public Function ScepterExistsAtLevel(thelevel As Integer) As Boolean
    If mScepterExistsAtLevel Is Nothing Then Return False

    If mScepterExistsAtLevel.Value(thelevel - 1) = 1 Then Return True
    Return False
  End Function

  Private Sub CalcColor()
    If mColor = Nothing Then
      'we haven't been assigned a color in New so we will generate one
      mColor = dbColors.GetColor(Me.mName)
    End If
  End Sub
  Public Function GetActiveAbilitiesByLevel(herolevel As Integer) As List(Of Integer)
    If mAbilityInfos Is Nothing Then Return New List(Of Integer)
    Dim levelslist As New List(Of Integer)

    ' this is a clue

    For i As Integer = 0 To mAbilityInfos.Count - 1

      levelslist.Add(GetAbilityLevel(mAbilityInfos.Item(i), herolevel))
    Next

    Return levelslist


  End Function

  Public Function GetAbility(abilityid As dvID) As Ability_Info
    If Not mAbilityInfos Is Nothing Then
      For i As Integer = 0 To mAbilityInfos.Count - 1
        If mAbilityInfos.Item(i).Id.GuidID = abilityid.GuidID Then
          Return mAbilityInfos.Item(i)
        End If
      Next
    End If

    Return Nothing
  End Function
  Public Function ExistsAtLevel(thelevel As Integer) As Boolean
    If NonScepterExistsAtLevel(thelevel) Then Return True
    If ScepterExistsAtLevel(thelevel) Then Return True
    Return False
  End Function




  Public ReadOnly Property PetsOwned As List(Of CreepStack)
    Get
      Return mPetsOwned
    End Get
  End Property

  Public ReadOnly Property SwatchColor As Color
    Get
      Return mColor
    End Get
  End Property

  Public Function GetLevelForTime(thetime As ddFrame) As Integer
    'TODO this needs fixin... obviously
    Return 0
  End Function
 

  Public Sub CalcItemtimings()
    ItemInv.UpdateItemSequence(mIDItem, mGoldcurve, mXPCurve, mItemList, mGame)
  End Sub

  Public Sub DeletItemAtIndex(theindex As Integer)
    ItemInv.DeleteItemAtIndex(theindex)
  End Sub

  Public Sub InsertItemAtIndex(theindex As Integer, theitem As Item_Info)
    ItemInv.InsertItemAtIndex(theindex, theitem)
  End Sub
  Public Function GetItemsAtTime(thetime As ddFrame) As Item_List
    If ItemInv Is Nothing Then Return New Item_List()

    Return ItemInv.GetItemsAtTime(thetime)
  End Function

  Public Sub DeleteItemAtIndex(theindex As Integer)
    ItemInv.DeleteItemAtIndex(theindex)
  End Sub
  Public Sub ReplaceItemAtIndex(theitem As Item_Info, theindex As Integer)
    ItemInv.ReplaceItemAtIndex(theitem, theindex)
  End Sub


  'Public ReadOnly Property AbilityInfos As Ability_Info_List
  '  Get
  '    If mAbilityInfos Is Nothing Then
  '      If Not mAbilityNames Is Nothing Then
  '        mAbilityInfos = New Ability_Info_List
  '        For i As Integer = 0 To mAbilityNames.Count - 1
  '          Dim ab = mGame.dbAbilities.CreateAbilityInfoInstance(mAbilityNames.Item(i), 1, Me.mIDItem, mLifetime)
  '          ab.ParentGameEntity.Id = Me.mIDItem
  '          mAbilityInfos.Add(ab)
  '        Next

  '      End If

  '    End If
  '    Return mAbilityInfos
  '  End Get
  'End Property

  Public Function GetAbilityLevel(theab As Ability_Info, herolevel As Integer) As Integer
    If herolevel = 0 Then Return 0
    If mActiveAbilitiesByLevel.Count < 1 Then Return 0


    If herolevel > mActiveAbilitiesByLevel.Count Then
      Return mActiveAbilitiesByLevel.Item(mActiveAbilitiesByLevel.Count - 1).Item(theab.AbilitysUIPosition)
    End If
    Return mActiveAbilitiesByLevel.Item(herolevel - 1).Item(theab.AbilitysUIPosition)

  End Function
  Public ReadOnly Property MyColor As Color
    Get

      Return mColor


    End Get
  End Property
  Public Sub SetTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendbias As Boolean)



    mTeamEnemyTarget = theenemytarget
    mTeamFriendlyTarget = thefriendlytarget
    mTargetFriendBias = isfriendbias



  End Sub
  Public Property ID As dvID
    Get
      Return mIDItem
    End Get
    Set(value As dvID)

    End Set
  End Property

End Class
