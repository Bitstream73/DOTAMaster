
Public Class Hero
  Inherits UnitBase
  Implements iGameEntity



  Private mID As dvID
  Private mBundle As HeroBundle

#Region "Base Stats (Immutable)"
  'Private mBuildName As String

  Private mName As eHeroName
  Private mParent As iGameEntity

  'Fixed, immutable stats
  Private mDevName As String
  Private mFriendlyName As String



  Private mRoles As New List(Of eRole)
  Private mPrimaryStatName As ePrimaryStat


  Private mBio As String

  Private mAbilityNames As New List(Of eAbilityName)
  Private mAbilities As New Ability_Info_List
  ' Private mAbilityInfos As New Ability_Info_List
  Private mBaseStr As Double
  Private mStrIncrement As Double

  Private mBaseInt As Double
  Private mIntIncrement As Double

  Private mBaseAgi As Double
  Private mAgiIncrement As Double

  Private mBaseArmor As Double
  'Private mBaseArmorPositive As Double
  'Private mBaseArmorNegative As Double


  ''' <summary>
  '''  http://dota2.gamepedia.com/Armor
  ''' </summary>
  ''' <remarks></remarks>
  Private mBaseMagicResistance As Double

  Private mDaySightRange As Integer
  Private mNightSightRange As Integer

  'http://dota2.gamepedia.com/Gold

  'Private mStartginGoldRandom As Integer = 825
  'Private mStartingGoldRepick As Integer = 525

  ''' <summary>
  ''' The gold received automatically per minute http://dota2.gamepedia.com/Gold
  ''' </summary>
  ''' <remarks></remarks>
  Private mBasePeriodicUnreliableGoldperMinute As Integer = 100

  ''' <summary>
  ''' May use this to simulate average gpm since we can't know exaclty when and what the hero kills
  ''' </summary>
  ''' <remarks></remarks>
  Private mUnreliableGoldperMinute As Integer

  ''' <summary>
  ''' May use this to simulate average gpm since we can't know exaclty when and what the hero kills
  ''' </summary>
  ''' <remarks></remarks>
  Private mReliableGoldperMinute As Integer

  Private mTeamEnemyTarget As dvID = Nothing
  Private mTeamFriendlyTarget As dvID = Nothing
  Private mTargetFriendlyBias As Boolean


  Private mMyMods As List(Of Modifier)
#End Region





#Region "News"
  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
              ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName)
    MyBase.New()

    mID = New dvID(Guid.NewGuid, "Hero Added", eEntity.Hero)


    mBaseHitpoints = 150

    mAbilityNames.Add(eAbilityName.abStat_Gain)
    mAbilityNames.Add(ab1)
    mAbilityNames.Add(ab2)
    mAbilityNames.Add(ab3)
    mAbilityNames.Add(ab4)

    'FROM UNITBASE
    mName = hbundle.mName
    mFriendlyName = hbundle.Displayname

    mArmorType = hbundle.mArmorType
    mUnitImage = hbundle.mUnitImage
    mWebpageLink = hbundle.mWebpageLink

    mAttackType = hbundle.mAttackType

    mBaseAttackSpeed = New ValueWrapper(hbundle.mBaseAttackSpeed) ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed


    mBaseAttackDamage = hbundle.mBaseAttackDamage

    mDaySightRange = hbundle.mDaySightRange
    mNightSightRange = hbundle.mNightSightRange

    mAttackRange = New ValueWrapper(hbundle.mAttackRange)
    mMissileSpeed = hbundle.mMissileSpeed

    mBaseArmor = hbundle.mBaseArmor
    'mBaseArmorNegative = hbundle.mBaseArmorNegative


    'FROM HEROBASE
    'Fixed, immutable stats
    mDevName = hbundle.mDevName


    mPrimaryStatName = hbundle.mPrimaryStat


    mBio = hbundle.mBio

    mBaseStr = hbundle.mBaseStr '= 17
    mStrIncrement = hbundle.mStrIncrement '= 2

    mBaseInt = hbundle.mBaseInt '= 22
    mIntIncrement = hbundle.mIntIncrement '= 2.9

    mBaseAgi = hbundle.mBaseAgi '= 14
    mAgiIncrement = hbundle.mAgiIncrement '= 1.3

    mBaseMoveSpeed = hbundle.mBaseMoveSpeed '= 270

    mBaseMagicResistance = hbundle.mBaseMagicResistance  'Check This http://dota2.gamepedia.com/Magic_resistance



    'If Not hbuild.mAbilityBuildSequence = "" Then

    '  Dim abstrings = hbuild.mabilitylist.Split("|")


    '  mBuild.mAbilityBuildSequence.Clear()

    '  For i As Integer = 0 To abstrings.Count - 1
    '    mBuild.mAbilityBuildSequence.Add(abstrings(i))
    '  Next
    'End If

    mBundle = hbundle
    'CalcAbilitiesByLevel()

    'Select Case mCurrentPriority
    '  Case ePriorityGoldXP.Priority1
    '    mCurrentPriorityList = PriorityCurves.Item(0)
    '  Case ePriorityGoldXP.Priority2
    '    mCurrentPriorityList = PriorityCurves.Item(1)
    '  Case ePriorityGoldXP.Priority3
    '    mCurrentPriorityList = PriorityCurves.Item(2)
    '  Case ePriorityGoldXP.Priority4
    '    mCurrentPriorityList = PriorityCurves.Item(3)
    '  Case ePriorityGoldXP.Priority5
    '    mCurrentPriorityList = PriorityCurves.Item(4)
    'End Select


  End Sub
#Region "New Overloads"
  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
              ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
              ab5 As eAbilityName)
    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4)

    mAbilityNames.Add(ab5)
    '  mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab5, 0, Me, Nothing))
    'mAbilityNames.Add(ab5)

  End Sub

  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
              ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
              ab5 As eAbilityName, ab6 As eAbilityName)
    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4, ab5)

    mAbilityNames.Add(ab6)
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab6, 0, Me, Nothing))
    'mAbilityNames.Add(ab6)

  End Sub

  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
            ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
            ab5 As eAbilityName, ab6 As eAbilityName, ab7 As eAbilityName)
    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4, ab5, ab6)

    mAbilityNames.Add(ab7)
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab7, 0, Me, Nothing))
    'mAbilityNames.Add(ab7)

  End Sub

  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
          ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
          ab5 As eAbilityName, ab6 As eAbilityName, ab7 As eAbilityName, _
          ab8 As eAbilityName)
    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4, ab5, ab6, ab7)

    mAbilityNames.Add(ab8)
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab8, 0, Me, Nothing))
    'mAbilityNames.Add(ab8)

  End Sub

  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
          ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
          ab5 As eAbilityName, ab6 As eAbilityName, ab7 As eAbilityName, _
          ab8 As eAbilityName, ab9 As eAbilityName)
    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4, ab5, ab6, ab7, ab8)

    mAbilityNames.Add(ab9)
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab9, 0, Me, Nothing))
    'mAbilityNames.Add(ab9)

  End Sub

  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
        ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
        ab5 As eAbilityName, ab6 As eAbilityName, ab7 As eAbilityName, _
        ab8 As eAbilityName, ab9 As eAbilityName, ab10 As eAbilityName)
    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4, ab5, ab6, ab7, ab8, ab9)

    mAbilityNames.Add(ab10)
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab10, 0, Me, Nothing))
    'mAbilityNames.Add(ab10)

  End Sub

  Public Sub New(uniquename As String, hbundle As HeroBundle, ab1 As eAbilityName, _
      ab2 As eAbilityName, ab3 As eAbilityName, ab4 As eAbilityName, _
      ab5 As eAbilityName, ab6 As eAbilityName, ab7 As eAbilityName, _
      ab8 As eAbilityName, ab9 As eAbilityName, ab10 As eAbilityName, _
      ab11 As eAbilityName, ab12 As eAbilityName, ab13 As eAbilityName)

    Me.New(uniquename, hbundle, ab1, ab2, ab3, ab4, ab5, ab6, ab7, ab8, ab9)

    mAbilityNames.Add(ab10)
    mAbilityNames.Add(ab11)
    mAbilityNames.Add(ab12)
    mAbilityNames.Add(ab13)

    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab10, 0, Me, Nothing))
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab11, 0, Me, Nothing))
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab12, 0, Me, Nothing))
    'mAbilityInfos.Add(PageHandler.dbAbilities.GetAbilityInfo(ab13, 0, Me, Nothing))

    'mAbilityNames.Add(ab10)

  End Sub
#End Region

#End Region

#Region "Properties"

  Public ReadOnly Property AbilityNames As List(Of eAbilityName)
    Get
      Return mAbilityNames
    End Get
  End Property
  Public ReadOnly Property FriendlyName As String
    Get
      Return mFriendlyName
    End Get
  End Property


  Public ReadOnly Property Name() As eHeroName
    Get
      Return mName
    End Get
  End Property

  Public Overrides ReadOnly Property BaseSpellResistance As Double
    Get
      Throw New NotImplementedException
    End Get
  End Property

  Public ReadOnly Property DevName As String
    Get
      Return mDevName
    End Get
  End Property

  Public ReadOnly Property Roles As List(Of eRole)
    Get
      Return mRoles
    End Get
  End Property

  Public ReadOnly Property PrimaryStat As ePrimaryStat
    Get
      Return mPrimaryStatName
    End Get
  End Property

  Public ReadOnly Property Bio As String
    Get
      Return mBio
    End Get
  End Property

  Public ReadOnly Property BaseStrength As Double
    Get
      Return mBaseStr
    End Get
  End Property

  Public ReadOnly Property StrengthIncrement As Double
    Get
      Return mStrIncrement
    End Get
  End Property

  Public ReadOnly Property BaseIntelligence As Double
    Get
      Return mBaseInt
    End Get
  End Property

  Public ReadOnly Property IntelligenceIncrement As Double
    Get
      Return mIntIncrement
    End Get
  End Property

  Public ReadOnly Property BaseAgility As Double
    Get
      Return mBaseAgi
    End Get
  End Property

  Public ReadOnly Property AgilityIncrement As Double
    Get
      Return mAgiIncrement
    End Get
  End Property

  Public ReadOnly Property BaseMovementSpeed As Double
    Get
      Return mBaseMoveSpeed
    End Get
  End Property

  Public ReadOnly Property BaseAttackDamageLow As Double
    Get
      Return mBaseAttackDamage.Value(0)
    End Get
  End Property
  Public ReadOnly Property BaseAttackDamageHigh As Double
    Get
      Return mBaseAttackDamage.Value(1)
    End Get
  End Property

  Public ReadOnly Property BaseArmor As Double
    Get
      Return mBaseArmor
    End Get
  End Property

  Public ReadOnly Property BaseDayVision As Double
    Get
      Return mBundle.mDaySightRange
    End Get
  End Property

  Public ReadOnly Property BaseNightVision As Double
    Get
      Return mBundle.mNightSightRange
    End Get
  End Property
  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Hero
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
  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Hero
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mParent
    End Get
    Set(value As iGameEntity)
      mParent = value
    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return mParent.MyType
    End Get
    Set(value As eSourceType)

    End Set
  End Property
  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mFriendlyName
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.NeutralTeamColor
    End Get
    Set(value As Color)

    End Set
  End Property

#End Region


  Public Sub SetTargets(theenemytarget As dvID, thefriendlytarget As dvID, isfriendbias As Boolean)


    If mTeamEnemyTarget Is Nothing Or mTeamFriendlyTarget Is Nothing Then
      mTeamEnemyTarget = theenemytarget
      mTeamFriendlyTarget = thefriendlytarget
      mTargetFriendlyBias = isfriendbias

      calcmods()
    Else
      If mTeamEnemyTarget.GuidID = theenemytarget.GuidID And mTeamFriendlyTarget.GuidID = thefriendlytarget.GuidID And mTargetFriendlyBias = isfriendbias Then Exit Sub

      mTeamEnemyTarget = theenemytarget
      mTeamFriendlyTarget = thefriendlytarget
      mTargetFriendlyBias = isfriendbias

      calcmods()
    End If


  End Sub


  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub


End Class
