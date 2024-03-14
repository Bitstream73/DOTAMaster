Public MustInherit Class AbilityBase
  Implements iAbility






  Protected mName As eAbilityName

  Protected mIDItem As dvID

  Protected mAbilityPosition As Integer = -1
  Protected mIsUltimate As Boolean = False
  Protected mIsAghsUpgradable As Boolean = False

  Protected mAbilityImage As String '= ""

  Public mUniqueStats As List(Of ValueWrapper) 'for all vars that aren't in abilitybase by default but may need to be displayed

  Protected mAbilityCount As Integer = 4 'changed by inheriting classes if needed

  Protected mStates As List(Of String)
  Protected mStateImageURLs As List(Of String)

  Protected mCurrentLevel As Integer = 0

  Protected mDisplayName As String
  Public Sub New()
    Me.AbilityTypes = New List(Of eAbilityType)
    Me.Affects = New List(Of eUnit)
  End Sub

#Region "Info"
  Public ReadOnly Property StatesAndStateUrls As List(Of List(Of String))
    Get
      Dim outlist As New List(Of List(Of String))
      outlist.Add(Me.States)
      outlist.Add(Me.StateImageUrls)
      Return outlist

    End Get
  End Property

  Public ReadOnly Property States As List(Of String)
    Get
      Return mStates
    End Get
  End Property

  Public ReadOnly Property StateImageUrls As List(Of String)
    Get
      'if nothing then we will have to know to use imgurl instead
      Return mStateImageURLs
    End Get
  End Property

  Public ReadOnly Property Name As eAbilityName
    Get
      Return mName
    End Get
  End Property

  Public ReadOnly Property IDItem As dvID
    Get
      Return mIDItem
    End Get
  End Property

  Public Property AbilityPosition As Integer Implements iAbility.AbilitysUIPosition
    Get
      Return mAbilityPosition
    End Get
    Set(value As Integer)
      mAbilityPosition = value
    End Set
  End Property



  Public Property IsAghsUpgradable As Boolean Implements iAbility.IsAghsUpgradable
    Get
      Return mIsAghsUpgradable
    End Get
    Set(value As Boolean)

    End Set
  End Property

  Public Property AbilityLevelCount As Integer Implements IUnitUpgrade.mAbilityLevelCount
    Get
      If mIsUltimate Then
        Return 3
      Else
        Return mAbilityCount
      End If
    End Get
    Set(value As Integer)

    End Set
  End Property

  Public Property AbilityTypes As List(Of eAbilityType) Implements IUnitUpgrade.mAbilityTypes

  Public Property Affects As List(Of eUnit) Implements IUnitUpgrade.mAffects

  Public Property BlockedByLinkens As Boolean Implements IUnitUpgrade.mBlockedByLinkens

  Public Property BlockedByMagicImmune As Boolean Implements IUnitUpgrade.mBlockedByMagicImmune

  Public Property BreaksStun As Boolean Implements IUnitUpgrade.mBreaksStun

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

  Public Property Image As String Implements IUnitUpgrade.mImageURL
    Get
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

  Public Property TargetFriendBias As Boolean Implements IUnitUpgrade.mTargetFriendBias

  Public Property WebpageLink As String Implements IUnitUpgrade.mWebpageLink

  Public Property mTeamEnemyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamEnemyTarget

  Public Property mTeamFriendlyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamFriendlyTarget

  Public Property EntityName As eEntity Implements iGameEntity.EntityName

  Public Property Id As dvID Implements iGameEntity.Id

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType

  Public Property CurrentStateIndex As Integer Implements IUnitUpgrade.CurrentStateIndex

  Public Property Lifetime As Lifetime Implements IUnitUpgrade.Lifetime

  Public Property StateImageUrls1 As List(Of String) Implements IUnitUpgrade.StateImageUrls

  Public Property States1 As List(Of String) Implements IUnitUpgrade.States

  Public Property StatesAndStateUrls1 As List(Of List(Of String)) Implements IUnitUpgrade.StatesAndStateUrls

  Public Property AbilityName As eAbilityName Implements iAbility.AbilityName
    Get
      Return mName
    End Get
    Set(value As eAbilityName)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Ability_Info
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property IsUltimate As Boolean Implements iAbility.IsUltimate
    Get
      Return mIsUltimate
    End Get
    Set(value As Boolean)

    End Set
  End Property

  Public Property CurrentLevel As Integer Implements IUnitUpgrade.CurrentLevel
    Get
      Return CurrentLevel
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


  Public Overridable Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                thecaster As iDisplayUnit, _
                                               thetarget As iDisplayUnit, _
                                                ftarget As iDisplayUnit, _
                                                isfriendbias As Boolean, _
                                                occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetActiveModifiers
    Return New ModifierList
  End Function

  Public Overridable Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  caster As iDisplayUnit, _
                                                  target As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetPassiveModifiers
    Return New ModifierList
  End Function

  ''' <summary>
  ''' The Hero Levels at which each of the ability levels become available. 
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function AbilityLevelsAt() As List(Of Integer)
    Dim outlist As New List(Of Integer)
    If mIsUltimate Then
      outlist.Add(6)
      outlist.Add(11)
      outlist.Add(16)
    Else
      outlist.Add(1)
      outlist.Add(3)
      outlist.Add(5)
      outlist.Add(7)
    End If

    If ParentGameEntity.EntityName = eEntity.untInvoker Then
      If mIsUltimate Then
        outlist.Clear()
        outlist.Add(2)
        outlist.Add(7)
        outlist.Add(12)
        outlist.Add(17)
      End If
    End If

    If ParentGameEntity.EntityName = eEntity.untMeepo Then
      If mIsUltimate Then
        outlist.Clear()
        outlist.Add(3)
        outlist.Add(10)
        outlist.Add(17)
      End If
    End If
    Return outlist
  End Function

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub





  Public Property MyColor As Color Implements IUnitUpgrade.MyColor
End Class
