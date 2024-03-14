Public MustInherit Class ItemBase
  Implements iItem



  Protected mName As eItemname
  Protected mDisplayName As String
  Protected mGoldCost As ValueWrapper
  Protected mMadeFromItems As New List(Of eItemname)
  Protected mBuildsToNames As New List(Of eItemname)
  Protected mCategory As eItemCategory
  Protected mSoldFrom As New List(Of eShopTypes)
  Protected mTier As Integer
  Protected mIsRecipe As Boolean '= False
  Protected mCanDisassemble As Boolean '= False
  Protected mIsConsumable As Boolean '= False
  Protected mIsCourier As Boolean '= False
  Protected mItemPlan As eItemPlan

  'status stuff for items like power treads which have different states
  Protected mStates As List(Of String)
  Protected mStateImageURLs As List(Of String)

  Protected mCurStateIndex As Integer

  Protected mCurrentLevel As Integer = 1
  Public Sub New(parent As iDisplayUnit, theparentorBuildname As String)
    Me.ParentGameEntity = parent

    Me.Charges = New ValueWrapper(0) 'item does not have charges, ie doesn't expire
  End Sub


#Region "Props"
  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.GetColor(mName)
    End Get
    Set(value As Color)

    End Set
  End Property
  Public Overridable Property AbilityDescription As String Implements iItem.AbilityDescription
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overridable Property AbilityName As String Implements iItem.AbilityName
    Get
      Return ""
    End Get
    Set(value As String)

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

  Public Property Cooldown As ValueWrapper Implements IUnitUpgrade.mCooldown

  Public Property Damage As ValueWrapper Implements IUnitUpgrade.mDamage

  Public Property DamageType As eDamageType Implements IUnitUpgrade.mDamageType

  Public Property Duration As ValueWrapper Implements IUnitUpgrade.mDuration

  Public Property IsUniqueAttackModifier As Boolean Implements IUnitUpgrade.mIsUniqueAttackModifier

  Public Property ManaCost As ValueWrapper Implements IUnitUpgrade.mManaCost

  Public Property PiercesSpellImmunity As Boolean Implements IUnitUpgrade.mPiercesSpellImmunity

  Public Property Radius As ValueWrapper Implements IUnitUpgrade.mRadius

  Public Property Range As ValueWrapper Implements IUnitUpgrade.mRange

  Public Property RemovedByMagicImmune As Boolean Implements IUnitUpgrade.mRemovedByMagicImmune

  Public Property Charges As ValueWrapper Implements IUnitUpgrade.mCharges

  Public Property Description As String Implements IUnitUpgrade.mDescription

  Public Property ImageURL As String Implements IUnitUpgrade.mImageURL

  Public Property Notes As String Implements IUnitUpgrade.mNotes

  Public Property WebpageLink As String Implements IUnitUpgrade.mWebpageLink

  Public Property ColorText As String Implements IUnitUpgrade.mColorText

  Public Property mBreaksStun As Boolean Implements IUnitUpgrade.mBreaksStun


  Public Property EntityName As eEntity Implements iGameEntity.EntityName

  Public Property Id As dvID Implements iGameEntity.Id

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity

  Public Property ItemName As eItemname Implements iItem.ItemName
    Get
      Return mName
    End Get
    Set(value As eItemname)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return ParentGameEntity.ParentGameEntityType
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property BuildsTo As List(Of eItemname) Implements iItem.BuildsToNames
    Get
      Return mBuildsToNames
    End Get
    Set(value As List(Of eItemname))

    End Set
  End Property

  Public Property CanDisassemble As Boolean Implements iItem.CanDisassemble
    Get
      Return mCanDisassemble
    End Get
    Set(value As Boolean)

    End Set
  End Property

  Public Property GoldCost As ValueWrapper Implements iItem.GoldCost
    Get
      Return mGoldCost
    End Get
    Set(value As ValueWrapper)

    End Set
  End Property

  Public Property IsRecipe As Boolean Implements iItem.IsRecipe
    Get
      Return mIsRecipe
    End Get
    Set(value As Boolean)

    End Set
  End Property



  Public Property SoldFrom As List(Of eShopTypes) Implements iItem.SoldFrom
    Get
      Return mSoldFrom
    End Get
    Set(value As List(Of eShopTypes))

    End Set
  End Property

  Public Property Tier As Integer Implements iItem.Tier
    Get
      Return mTier
    End Get
    Set(value As Integer)

    End Set
  End Property

  Public Property BoughtAtLevel As Integer Implements iItem.BoughtAtLevel

  Public Property MadeFromItemNames As List(Of eItemname) Implements iItem.MadeFromItemNames
    Get
      Return mMadeFromItems
    End Get
    Set(value As List(Of eItemname))

    End Set
  End Property

  Public Property ComponentList As Item_List Implements iItem.ComponentList

  Public Property GoldBalance As Integer Implements iItem.GoldBalance

  Public Property IsConsumable As Boolean Implements iItem.IsConsumable

  Public Property IsCourier As Boolean Implements iItem.IsCourier

  Public Property ItemCategory As eItemCategory Implements iItem.ItemCategory

  Public Property ItemIsDisassembled As Boolean Implements iItem.ItemIsDisassembled

  Public Property ItemIsFromDisassembly As Boolean Implements iItem.ItemIsFromDisassembly

  Public Property ItemPlan As eItemPlan Implements iItem.ItemPlan

  Public Property SoldAtLevel As Integer Implements iItem.SoldAtLevel

  Public Property Willdisassemble As Boolean Implements iItem.Willdisassemble

  Public Property Lifetime As Lifetime Implements IUnitUpgrade.Lifetime

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Item_Info
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property Index As Integer Implements iItem.Index

  Public Property CurrentLevel As Integer Implements IUnitUpgrade.CurrentLevel
    Get
      Return mCurrentLevel
    End Get
    Set(value As Integer)
      mCurrentLevel = value
    End Set
  End Property
#End Region

#Region "Stats"




#End Region

#Region "Mods"
  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Overridable Function GetActiveModifiers(stateindex As Integer, game As dGame, ability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetActiveModifiers
    Return New ModifierList
  End Function

  Public Overridable Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetPassiveModifiers
    Return New ModifierList
  End Function


#End Region

#Region "Targeting"

  Public Property TargetFriendBias As Boolean Implements IUnitUpgrade.mTargetFriendBias

  Public Property TeamEnemyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamEnemyTarget

  Public Property TeamFriendlyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamFriendlyTarget

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

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mDisplayName
    End Get
    Set(value As String)

    End Set
  End Property
#End Region

#Region "States"

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

  Public Property States As List(Of String) Implements IUnitUpgrade.States
    Get
      Return mStates
    End Get
    Set(value As List(Of String))

    End Set
  End Property

  Public Property StateImageUrls As List(Of String) Implements IUnitUpgrade.StateImageUrls
    Get
      'if nothing then we will have to know to use imgurl instead
      Return mStateImageURLs
    End Get
    Set(value As List(Of String))

    End Set
  End Property
#End Region





End Class
