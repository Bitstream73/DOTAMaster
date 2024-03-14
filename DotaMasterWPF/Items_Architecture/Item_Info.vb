Public Class Item_Info
  Implements iItem





#Region "Vars"
  Private mIDItem As dvID

  Private mIndex As Integer

  Private mName As eItemname
  Private mDisplayName As String
  Private mParent As iDisplayUnit
  Private mGoldCost As ValueWrapper
  Private mMadeFromItemNames As New List(Of eItemname)
  Private mBuildsFrom As Item_List
  Private mBuildsToNames As New List(Of eItemname)
  Private mImageUrl As String

  Private mCategory As eItemCategory

  Private mColor As Color

  'stuff for display in item_thumb_picker
  Private mGoldBalance As Integer = 0
  Private mLifetime As Lifetime
  Private mBoughtAtLevel As Integer
  Private mSoldAtLevel As Integer


  Private mDevNotes As New List(Of String)
  Private mItemplan As eItemPlan
  Private mSoldFrom As List(Of eShopTypes)

  ' Private mImageUrl As String
  Private mTier As Integer
  Private mIsRecipe As Boolean
  Private mCanDisassemble As Boolean
  Private mWillDisassemble As Boolean = False
  Private mItemIsDisassembled As Boolean = False
  Private mItemisFromDisassembly As Boolean = False

  Private mComponentlist As New Item_List

  Private mIsConsumable As Boolean
  Private mIsCourier As Boolean

  'state info. These will have to be filled by receiver of Item_Info
  Private mStates As List(Of String)
  Private mStateImageUrls As List(Of String)
  Private mCurStateIndex As Integer = 0

  Private mCurrentLevel As Integer = 1
#End Region


  Public Sub New(myid As dvID, _
                 name As eItemname, _
                  theparent As iDisplayUnit, _
                  displayname As String, _
                  description As String, _
                  notes As String, _
                  colortext As String, _
                   goldcost As ValueWrapper, _
                   madefrom As List(Of eItemname), _
                   buildsto As List(Of eItemname), _
                   category As eItemCategory, _
                   soldfrom As List(Of eShopTypes), _
                   imageurl As String, _
                   tier As Integer, _
                   isrecipe As Boolean, _
                   candisassemble As Boolean, _
                   cooldown As ValueWrapper, _
                   radius As ValueWrapper, _
                   charges As ValueWrapper, _
                   duration As ValueWrapper, _
                   manacost As ValueWrapper, _
                   isconsumable As Boolean, _
                   iscourier As Boolean, _
                   thelife As Lifetime)

    If name = eItemname.itmRING_OF_AQUILA Then
      Dim x = 2
    End If



    If candisassemble And madefrom.Count < 1 Then
      Dim x = 2
    End If
    mName = name
    'If theparent IsNot Nothing Then
    '  mIDItem = New dvID(Guid.NewGuid, "Item_Info Instance: " & displayname, eEntity.Item_Info)
    'Else
    '  mIDItem = New dvID(Guid.Empty, "Item_Info NonInstance: " & displayname, eEntity.Item_Info)
    'End If
    mIDItem = myid

    mParent = theparent

    mLifetime = thelife
    If mLifetime Is Nothing Then
      Dim z = 2
    End If
    Me.mDisplayName = displayname

    Me.Description = description
    Me.Notes = notes
    Me.ColorText = colortext

    mGoldCost = goldcost

    mMadeFromItemNames = madefrom
    mBuildsToNames = buildsto

    mCategory = category

    mSoldFrom = soldfrom

    mImageUrl = imageurl
    mTier = tier
    mIsRecipe = isrecipe
    mCanDisassemble = candisassemble
    mIsConsumable = isconsumable
    mIsCourier = iscourier

    'ability
    Me.Cooldown = cooldown
    Me.Radius = radius
    Me.Charges = charges
    Me.Duration = duration
    Me.mManaCost = manacost


  End Sub

  'Public Sub New(name As eItemname, _
  '              theparent As iDisplayUnit, _
  '              displayname As String, _
  '              description As String, _
  '                notes As String, _
  '                colortext As String, _
  '               goldcost As Integer, _
  '               madefrom As List(Of eItemname), _
  '               buildsto As List(Of eItemname), _
  '               category As eItemCategory, _
  '               soldfrom As List(Of eShopTypes), _
  '               imageurl As String, _
  '               tier As Integer, _
  '               isrecipe As Boolean, _
  '               candisassemble As Boolean, _
  '               cooldown As ValueWrapper, _
  '               radius As ValueWrapper, _
  '               charges As Integer, _
  '               duration As ValueWrapper, _
  '               manacost As ValueWrapper, _
  '               isconsumable As Boolean, _
  '               iscourier As Boolean, _
  '               itemplan As eItemPlan, _
  '               itemisdisassembled As Boolean, _
  '               thelife As Lifetime)

  '  Me.New(name, theparent, displayname, _
  '         description, notes, colortext, goldcost, madefrom, _
  '         buildsto, category, soldfrom, _
  '         imageurl, tier, isrecipe, _
  '         candisassemble, cooldown, radius, _
  '         charges, duration, manacost, _
  '         isconsumable, iscourier, thelife)

  '  mItemplan = itemplan
  'End Sub

#Region "Info"
  'Public Function GetBuildsToItem_Infos(itemdb As item_Database) As Item_List

  '  If mBuildsTo Is Nothing Then
  '    mBuildsTo = New Item_List
  '    If mBuildsToNames.Count > 0 Then

  '      For i As Integer = 0 To mBuildsToNames.Count - 1
  '        mBuildsTo.Add(itemdb.CreateItemInstance(mBuildsToNames.Item(i), Me.Parent.Id, mLifetime))
  '      Next
  '    End If
  '  End If

  '  Return mBuildsTo

  'End Function

  Public Function GetBuildsFromItem_Infos(itemdb As item_Database) As Item_List

    If mBuildsFrom Is Nothing Then
      mBuildsFrom = New Item_List
      If mMadeFromItemNames.Count > 0 Then

        For i As Integer = 0 To mBuildsToNames.Count - 1
          mBuildsFrom.Add(itemdb.CreateItemInstance(mMadeFromItemNames.Item(i), Me.ParentGameEntity, mLifetime))
        Next
      End If
    End If
    Return mBuildsFrom

  End Function

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

  Public Property mDamageType As eDamageType Implements IUnitUpgrade.mDamageType

  Public Property Description As String Implements IUnitUpgrade.mDescription



  Public Property Duration As ValueWrapper Implements IUnitUpgrade.mDuration

  Public Property ImageURL As String Implements IUnitUpgrade.mImageURL
    Get
      If mStates Is Nothing Then Return mImageUrl

      If mStateImageUrls.Count > mCurStateIndex And mCurStateIndex >= 0 Then Return mStateImageUrls.Item(mCurStateIndex)

      Return mImageUrl
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property IsUniqueAttackModifier As Boolean Implements IUnitUpgrade.mIsUniqueAttackModifier

  Public Property mManaCost As ValueWrapper Implements IUnitUpgrade.mManaCost

  Public Property Notes As String Implements IUnitUpgrade.mNotes


  Public Property PiercesSpellImmunity As Boolean Implements IUnitUpgrade.mPiercesSpellImmunity

  Public Property Radius As ValueWrapper Implements IUnitUpgrade.mRadius

  Public Property Range As ValueWrapper Implements IUnitUpgrade.mRange

  Public Property RemovedByMagicImmune As Boolean Implements IUnitUpgrade.mRemovedByMagicImmune

  Public Property WebpageLink As String Implements IUnitUpgrade.mWebpageLink

  Public Property mBreaksStun As Boolean Implements IUnitUpgrade.mBreaksStun



  Public Function ExistsAtTime(thetime As ddFrame) As Boolean

    If thetime.count >= mLifetime.CreationTime.count And thetime.count <= mLifetime.EndTime.count Then Return True
    Return False
  End Function

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
 

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mIDItem
    End Get
    Set(value As dvID)
      mIDItem = value
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
      Return Me.ParentGameEntity.ParentGameEntityType
    End Get
    Set(value As eSourceType)
      Throw New NotImplementedException
    End Set
  End Property

  Public Property BoughtAtLevel As Integer Implements iItem.BoughtAtLevel
    Get
      Return mBoughtAtLevel
    End Get
    Set(value As Integer)
      mBoughtAtLevel = value

    End Set
  End Property

  Public Property BuildsToNames As List(Of eItemname) Implements iItem.BuildsToNames
    Get
      Return mBuildsToNames
    End Get
    Set(value As List(Of eItemname))
      Throw New NotImplementedException

    End Set
  End Property

  Public Property CanDisassemble As Boolean Implements iItem.CanDisassemble
    Get
      Return mCanDisassemble
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property ComponentList As Item_List Implements iItem.ComponentList
    Get
      Return mComponentlist
    End Get
    Set(value As Item_List)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property GoldBalance As Integer Implements iItem.GoldBalance
    Get
      Return mGoldBalance
    End Get
    Set(value As Integer)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property GoldCost As ValueWrapper Implements iItem.GoldCost
    Get
      Return mGoldCost
    End Get
    Set(value As ValueWrapper)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property IsConsumable As Boolean Implements iItem.IsConsumable
    Get
      Return mIsConsumable
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property IsCourier As Boolean Implements iItem.IsCourier
    Get
      Return mIsCourier
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property IsRecipe As Boolean Implements iItem.IsRecipe
    Get
      Return mIsRecipe
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property ItemIsDisassembled As Boolean Implements iItem.ItemIsDisassembled
    Get
      Return mItemIsDisassembled
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property ItemIsFromDisassembly As Boolean Implements iItem.ItemIsFromDisassembly
    Get
      Return mItemisFromDisassembly
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property ItemName As eItemname Implements iItem.ItemName
    Get
      Return mName
    End Get
    Set(value As eItemname)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property ItemPlan As eItemPlan Implements iItem.ItemPlan
    Get
      Return mItemplan
    End Get
    Set(value As eItemPlan)
      mItemplan = value
    End Set
  End Property

  Public Property MadeFromItemNames As List(Of eItemname) Implements iItem.MadeFromItemNames
    Get
      Return mMadeFromItemNames
    End Get
    Set(value As List(Of eItemname))
      Throw New NotImplementedException

    End Set
  End Property

  Public Property SoldAtLevel As Integer Implements iItem.SoldAtLevel
    Get
      Return mSoldAtLevel
    End Get
    Set(value As Integer)
      mSoldAtLevel = value

    End Set
  End Property

  Public Property SoldFrom As List(Of eShopTypes) Implements iItem.SoldFrom
    Get
      Return mSoldFrom
    End Get
    Set(value As List(Of eShopTypes))
      Throw New NotImplementedException

    End Set
  End Property

  Public Property Tier As Integer Implements iItem.Tier
    Get
      Return mTier
    End Get
    Set(value As Integer)
      Throw New NotImplementedException

    End Set
  End Property

  Public Property Willdisassemble As Boolean Implements iItem.Willdisassemble
    Get
      Return mWillDisassemble
    End Get
    Set(value As Boolean)
      Throw New NotImplementedException

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
      outlist.Add(mStates)
      outlist.Add(mStateImageUrls)
      Return outlist
    End Get
    Set(value As List(Of List(Of String)))
      Throw New NotImplementedException

    End Set
  End Property



  Public Property ItemCategory As eItemCategory Implements iItem.ItemCategory
    Get
      Return mCategory
    End Get
    Set(value As eItemCategory)
      Throw New NotImplementedException

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

  Public Property CurrentLevel As Integer Implements IUnitUpgrade.CurrentLevel
    Get
      Return mCurrentLevel
    End Get
    Set(value As Integer)
      mCurrentLevel = value
    End Set
  End Property

#End Region

#Region "Targetting"
  Public Sub SetTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendlybias As Boolean)

    mTeamEnemyTarget = theenemytarget
    mTeamFriendlyTarget = thefriendlytarget
    TargetFriendBias = isfriendlybias

  End Sub

  Public Property mTeamEnemyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamEnemyTarget

  Public Property mTeamFriendlyTarget As iDisplayUnit Implements IUnitUpgrade.mTeamFriendlyTarget

  Public Property TargetFriendBias As Boolean Implements IUnitUpgrade.mTargetFriendBias

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mDisplayName
    End Get
    Set(value As String)

    End Set
  End Property
#End Region

#Region "Stats"

  Public Sub calcmods() Implements iGameEntity.calcmods
    Throw New NotImplementedException

  End Sub

#End Region
#Region "State"

  ''' <summary>
  ''' pass in nothing for thestateimgurls if all states use default image url
  ''' </summary>
  ''' <param name="thestates"></param>
  ''' <param name="thestateimgurls"></param>
  ''' <remarks></remarks>
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


#End Region

#Region "Abilities"
  Public Property mAbilityLevelCount As Integer Implements IUnitUpgrade.mAbilityLevelCount

  Public Property AbilityTypes As List(Of eAbilityType) Implements IUnitUpgrade.mAbilityTypes

#End Region

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Item_Info
    End Get
    Set(value As eSourceType)

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

  Public Property Index As Integer Implements iItem.Index
    Get
      Return mIndex
    End Get
    Set(value As Integer)
      mIndex = value
    End Set
  End Property
  Public Overridable Function GetActiveModifiers(stateindex As Integer, game As dGame, ability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetActiveModifiers
    Return New ModifierList
  End Function

  Public Overridable Function GetPassiveModifiers(thestateindex As Integer, game As dGame, ability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList Implements IUnitUpgrade.GetPassiveModifiers
    Return New ModifierList
  End Function


  Public Property MyColor As Color Implements IUnitUpgrade.MyColor
    Get
      If Not mColor = Nothing Then
        Return mColor

      Else
        mColor = PageHandler.dbColors.GetColor(Me.ItemName)
        Return mColor
      End If
    End Get
    Set(value As Color)

    End Set
  End Property
End Class