Public Class Ability_Info
  Implements iAbility_Info







  Private mIDItem As dvID
  Private mName As eAbilityName
  Private mDisplayName As String
  Private mAbilityPosition As Integer
  Private mIsUltimate As Boolean
  Private mIsAghsUpgradable As Boolean
  ' Private mHasAghs As Boolean
  Private mAbilityImage As String

  Private mColor As Color

  'privides overall life for ability and also timespans for individual levels of the spell
  Public mLifetime As Lifetime

  'state info. These will have to be filled by receiver of Ability_Info
  Private mStates As List(Of String)
  Private mStateImageUrls As List(Of String)
  Private mCurStateIndex As Integer = 0

  Private mCurrentLevel As Integer = 0

  Private dbAbilities As ability_Database
  Public Sub New(abilitiesdb As ability_Database, _
                 Name As eAbilityName, _
                  theParent As iDisplayUnit, _
     thefriendlyname As String, _
 AbilityPosition As Integer, _
 IsUltimate As Boolean, _
 IsAghsUpgradable As Boolean, _
     AbilityImage As String, _
 WebpageLink As String, _
 Description As String, _
 Notes As String, _
 ManaCost As ValueWrapper, _
 Cooldown As ValueWrapper, _
 AbilityTypes As List(Of eAbilityType), _
 Affects As List(Of eUnit), _
 DamageType As eDamageType, _
 Damage As ValueWrapper, _
 Duration As ValueWrapper, _
 Radius As ValueWrapper, _
 Range As ValueWrapper, _
 BlockedByMagicImmune As Boolean, _
 RemovedByMagicImmune As Boolean, _
 CanBePurged As Boolean, _
 CanBeUsedByIllusions As Boolean, _
 CanSelfDeny As Boolean, _
 BlockedByLinkens As Boolean, _
 BreaksStun As Boolean, _
 IsUniqueAttackModifier As Boolean, _
 piercesspellimmunity As Boolean, _
 AbilityLevelCount As Integer, _
 AbilityLevel As Integer, _
 AbilityLifetime As Lifetime)

    dbAbilities = abilitiesdb

    mName = Name
    If theParent IsNot Nothing Then
      mIDItem = New dvID(Guid.NewGuid, "Ability_Info Instance: " & mName.ToString, eEntity.Ability_Info)
    Else
      mIDItem = New dvID(Guid.Empty, "Ability_Info Non Instance: " & mName.ToString, eEntity.Ability_Info)
    End If


    Me.ParentGameEntity = theParent
    'mFriendlyName = = thefriendlyname
    Me.ParentGameEntity = ParentGameEntity

    mAbilityPosition = AbilityPosition
    mIsUltimate = IsUltimate
    mIsAghsUpgradable = IsAghsUpgradable
    '  mHasAghs = HasAghs
    mAbilityImage = AbilityImage

    Me.Notes = Notes
    mDisplayName = thefriendlyname
    Me.Description = Description
    Me.ManaCost = ManaCost
    Me.Cooldown = Cooldown
    Me.AbilityTypes = AbilityTypes
    Me.Affects = Affects
    Me.DamageType = DamageType
    Me.Damage = Damage
    Me.Duration = Duration
    Me.Radius = Radius
    Me.Range = Range

    Me.BlockedByMagicImmune = BlockedByMagicImmune
    Me.RemovedByMagicImmune = RemovedByMagicImmune
    Me.CanBePurged = CanBePurged
    Me.CanBeUsedByIllusions = CanBeUsedByIllusions
    Me.CanSelfDeny = CanSelfDeny
    Me.BlockedByLinkens = BlockedByLinkens
    Me.BreaksStun = BreaksStun

    Me.PiercesSpellImmunity = piercesspellimmunity

    Me.IsUniqueAttackModifier = IsUniqueAttackModifier
    Me.AbilityLevelCount = AbilityLevelCount
    Me.CurrentLevel = AbilityLevel
    mLifetime = AbilityLifetime

  End Sub

#Region "Info"
  Public Property EntityName As eEntity Implements iGameEntity.EntityName

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mIDItem
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property AbilityLevelCount As Integer Implements IUnitUpgrade.mAbilityLevelCount

  Public Property AbilityTypes As List(Of eAbilityType) Implements IUnitUpgrade.mAbilityTypes

  Public Property Affects As List(Of eUnit) Implements IUnitUpgrade.mAffects

  Public Property BlockedByLinkens As Boolean Implements IUnitUpgrade.mBlockedByLinkens

  Public Property BlockedByMagicImmune As Boolean Implements IUnitUpgrade.mBlockedByMagicImmune

  Public Property CanBePurged As Boolean Implements IUnitUpgrade.mCanBePurged

  Public Property CanBeUsedByIllusions As Boolean Implements IUnitUpgrade.mCanBeUsedByIllusions

  Public Property CanSelfDeny As Boolean Implements IUnitUpgrade.mCanSelfDeny

  Public Property Charges As ValueWrapper Implements IUnitUpgrade.mCharges

  Public Property ColorText As String Implements IUnitUpgrade.mColorText

  Public Property Cooldown As ValueWrapper Implements IUnitUpgrade.mCooldown

  Public Property Damage As ValueWrapper Implements IUnitUpgrade.mDamage

  Public Property DamageType As eDamageType Implements IUnitUpgrade.mDamageType

  Public Property Description As String Implements IUnitUpgrade.mDescription
  Public Property Duration As ValueWrapper Implements IUnitUpgrade.mDuration

  Public Property ImageURL As String Implements IUnitUpgrade.mImageURL
    Get
      If mStates Is Nothing Then Return mAbilityImage
      If mStateImageUrls Is Nothing Then Return mAbilityImage

      If mStateImageUrls.Count > mCurStateIndex And mCurStateIndex >= 0 Then Return mStateImageUrls.Item(mCurStateIndex)

      Return mAbilityImage
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property IsUniqueAttackModifier As Boolean Implements IUnitUpgrade.mIsUniqueAttackModifier

  Public Property ManaCost As ValueWrapper Implements IUnitUpgrade.mManaCost

  Public Property Notes As String Implements IUnitUpgrade.mNotes

  Public Property PiercesSpellImmunity As Boolean Implements IUnitUpgrade.mPiercesSpellImmunity

  Public Property Radius As ValueWrapper Implements IUnitUpgrade.mRadius

  Public Property Range As ValueWrapper Implements IUnitUpgrade.mRange

  Public Property RemovedByMagicImmune As Boolean Implements IUnitUpgrade.mRemovedByMagicImmune

  Public Property WebpageLink As String Implements IUnitUpgrade.mWebpageLink

  Public Property BreaksStun As Boolean Implements IUnitUpgrade.mBreaksStun

  Public Property AbilityName As eAbilityName Implements iAbility_Info.AbilityName
    Get
      Return mName
    End Get
    Set(value As eAbilityName)

    End Set
  End Property

  Public Property Lifetime As Lifetime Implements IUnitUpgrade.Lifetime
    Get
      Return mLifetime
    End Get
    Set(value As Lifetime)
      mLifetime = value
    End Set
  End Property

  Public Property AbilitysUIPosition As Integer Implements iAbility_Info.AbilitysUIPosition
    Get
      Return mAbilityPosition
    End Get
    Set(value As Integer)

    End Set
  End Property
  Public Property IsAghsUpgradable As Boolean Implements iAbility_Info.IsAghsUpgradable
    Get
      Return mIsAghsUpgradable
    End Get
    Set(value As Boolean)

    End Set
  End Property
  Public Property IsUltimate As Boolean Implements iAbility_Info.IsUltimate
    Get
      Return mIsUltimate
    End Get
    Set(value As Boolean)

    End Set
  End Property
  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Ability_Info
    End Get
    Set(value As eSourceType)

    End Set
  End Property
  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType

  Public Property CurrentLevel As Integer Implements IUnitUpgrade.CurrentLevel
    Get
      Return mCurrentLevel
    End Get
    Set(value As Integer)
      mCurrentLevel = value
    End Set
  End Property
  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mDisplayName
    End Get
    Set(value As String)

    End Set
  End Property
#End Region


#Region "Targetting"
  Public Property TargetFriendBias As Boolean Implements IUnitUpgrade.mTargetFriendBias

  Public Property TeamEnemyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamEnemyTarget

  Public Property TeamFriendlyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamFriendlyTarget

#End Region

#Region "States"
  ''' <summary>
  ''' pass in nothing for thestateimgurls if all states use default image url
  ''' </summary>
  ''' <param name="thestates"></param>
  ''' <param name="thestateimgurls"></param>
  ''' <remarks></remarks>
  ''' 
  Public Sub LoadStates(thestates As List(Of String), thestateimgurls As List(Of String))

    mStates = thestates
    mStateImageUrls = thestateimgurls

  End Sub

  Public Sub LoadStates(statesandurls As List(Of List(Of String)))
    If Not statesandurls Is Nothing Then
      mStates = statesandurls.Item(0)
      mStateImageUrls = statesandurls.Item(1)
    End If

  End Sub
  Public Sub SetTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendlybias As Boolean)
    Me.TeamEnemyTarget = theenemytarget
    Me.TeamFriendlyTarget = thefriendlytarget
    Me.TargetFriendBias = isfriendlybias

  End Sub

  Public Property CurrentStateIndex As Integer Implements IUnitUpgrade.CurrentStateIndex
    Get

      Return mCurStateIndex
    End Get
    Set(value As Integer)
      If mStates Is Nothing Then
        mCurStateIndex = -1

      ElseIf value >= mStates.Count Then
        mCurStateIndex = 0

      ElseIf value < 0 And mStates.Count > 1 Then
        mCurStateIndex = mStates.Count - 1

      ElseIf mStates.Count = 1 Then
        mCurStateIndex = -1
      Else
        mCurStateIndex = value
      End If




    End Set
  End Property

  Public Property StateImageUrls As List(Of String) Implements IUnitUpgrade.StateImageUrls
    Get
      Return mStateImageUrls
    End Get
    Set(value As List(Of String))
      Throw New NotImplementedException
    End Set
  End Property

  Public Property States As List(Of String) Implements IUnitUpgrade.States
    Get
      Return mStates
    End Get
    Set(value As List(Of String))
      Throw New NotImplementedException
    End Set
  End Property

  Public Property StatesAndStateUrls As List(Of List(Of String)) Implements IUnitUpgrade.StatesAndStateUrls
    Get
      Dim outlist As New List(Of List(Of String))
      outlist.Add(Me.States)
      outlist.Add(Me.StateImageUrls)
      Return outlist

    End Get
    Set(value As List(Of List(Of String)))

    End Set
  End Property
#End Region

#Region "Stats"
  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub
#End Region




  Public Function GetActiveModifiers(stateindex As Integer, game As dGame, ability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetActiveModifiers
    Return dbAbilities.GetActiveAbilityModifiers(stateindex, game, ability_InfoID, caster, target, ftarget, isfriendbias, occurencetime, aghstime)
  End Function

  Public Function GetPassiveModifiers(stateindex As Integer, game As dGame, ability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetPassiveModifiers
    Return dbAbilities.GetPassiveAbilityModifiers(stateindex, game, ability_InfoID, caster, target, ftarget, isfriendbias, occurencetime, aghstime)
  End Function




  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      If Not mColor = Nothing Then
        Return mColor
      Else
        mColor = PageHandler.dbColors.GetColor(Me.AbilityName)
        Return mColor
      End If

    End Get
    Set(value As Color)

    End Set
  End Property
End Class
