#Const devmode = True

Imports DotaMasterWPF.PageHandler
Public Class Build
  Implements iGameEntity




  Public mUniqueName As String
  Private mIDItem As dvID 'dvID
  Private mParentIDItem As dvID
  Private mParent As iGameEntity
  Private mChildIDItem As dvID

  Private mitemList As Item_List 'raw list of items from build

  Public mDevNotes As New List(Of String)

  Public mHeroType As eHeroName
  Public mImage As String

  Private mFilename As String

  Private mPriorityNum As ePriorityGoldXP

  Private myMods As New ModifierList

  Private selfinf As modInfo

  Private mAbilityNames As List(Of eAbilityName)
  Public mAbilityBuildOrderByUIPosition As New List(Of Integer)

  Public Sub New(thedvIDid As dvID, theparentid As dvID, thechildid As dvID, _
                uniquename As String, herotype As eHeroName, _
                itemlist As Item_List, _
                abilitylist As String, thepriority As ePriorityGoldXP)





    mIDItem = thedvIDid
    mIDItem.AppendMetaData("Build/New/" & uniquename & "-" & herotype.ToString)

#If devmode Then
    mDevNotes.Add("ID: " & thedvIDid.ToString)
#End If

    mitemList = itemlist

    mParentIDItem = theparentid

#If devmode Then
    mDevNotes.Add("Parent ID: " & mParentIDItem.ToString)
#End If


    mUniqueName = uniquename

#If devmode Then
    mDevNotes.Add("Uniqueame: " & mUniqueName)
#End If


    mHeroType = herotype

#If devmode Then
    mDevNotes.Add("mHeroType: " & mHeroType.ToString)
#End If


    mFilename = mHeroType.ToString & "-" & mUniqueName & "-" & mIDItem.ToString & ".bld"

#If devmode Then
    mDevNotes.Add("Filename: " & mFilename)
#End If





    'mItemlistitems = PageHandler.dbItems.GetListItems
    If uniquename = "AA1" Then
      Dim x = 2
    End If
    ' mItemBuildSequence = AssembleItems(itemlist)





    If mitemList.Count > 0 Then
      Dim x = 2
    End If
    'For i As Integer = 0 To itemlist.Count - 1
    '  mItemList.Add(PageHandler.dbItems.GetItemInfo(itemlist.Item(i)))
    'Next
    Dim thearray = abilitylist.Split("|")
    For i As Integer = 1 To thearray.Count - 1

      If Not thearray(i) = "" Then
        mAbilityBuildOrderByUIPosition.Add(thearray(i))
      End If

    Next


    mPriorityNum = thepriority

#If devmode Then
    mDevNotes.Add("Priority: " & mPriorityNum.ToString)
#End If


    '  mGoldCurve = PageHandler.manEconomy.GetGoldCurve(mPriorityNum)




    'If PageHandler.DEVMODE Then
    '  Dim x As Integer = 1
    '  For Each item As KeyValuePair(Of DateTime, Integer) In mGoldCurve
    '    mDevNotes.Add(x.ToString & ": " & item.Value.ToString)
    '    x += 1
    '  Next
    'End If

    '  mXPCurve = PageHandler.manEconomy.GetXPCurve(mPriorityNum)

    'If PageHandler.DEVMODE Then
    '  Dim y As Integer = 1
    '  For Each item As KeyValuePair(Of DateTime, Integer) In mXPCurve
    '    mDevNotes.Add(y.ToString & ": " & item.Value.ToString)
    '    y += 1
    '  Next
    'End If


    'CalcItemsPurchaseAtTime()


    'mod initializers

    selfinf = New modInfo(eAbilityType.Passive, Me, Me, Me, eUnit.untSelf, _
                            "", eModifierCategory.Passive)





    'CalcItemTimings()


    calcmods()
  End Sub

#Region "Props"

  Public Property AbilityNames As List(Of eAbilityName)
    Get
      Return mAbilityNames
    End Get
    Set(value As List(Of eAbilityName))

    End Set
  End Property

  Public ReadOnly Property ItemList As Item_List
    Get
      Return mitemList
    End Get
  End Property
  Public Property PriorityLevel As ePriorityGoldXP
    Get
      Return mPriorityNum
    End Get
    Set(value As ePriorityGoldXP)
      mPriorityNum = value
      calcmods()
    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Build
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mIDItem
    End Get
    Set(value As dvID)

    End Set
  End Property
  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Build
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
      Return eSourceType.Build
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "Build"
    End Get
    Set(value As String)

    End Set
  End Property
  Public ReadOnly Property IDItem As dvID
    Get

      Return mIDItem
    End Get
  End Property

  Public Property ParentIDItem As dvID
    Get
      If mParentIDItem Is Nothing Then
        mParentIDItem = New dvID(New Guid("00000000-0000-0000-0000-000000000000"), "No Parent", eEntity.None)
      End If
      Return mParentIDItem
    End Get
    Set(value As dvID)
      mParentIDItem = value
    End Set
  End Property

  Public Property ChildIDItem As dvID
    Get
      If mChildIDItem Is Nothing Then
        mChildIDItem = New dvID(New Guid("00000000-0000-0000-0000-000000000000"), "No Child", eEntity.None)
      End If
      Return mChildIDItem
    End Get
    Set(value As dvID)
      mChildIDItem = value
    End Set
  End Property
#End Region

#Region "ModsIO"

  'Public Function GetBuildModifiers() As ModifierList 'List(Of ModifierList)
  '  'Dim outmods As New List(Of ModifierList) '0 is actives, 1 is passives

  '  Return myMods

  'End Function



#End Region

  Public Function GetFileName(newdvID As dvID) As String
    If newdvID.ToString.Contains("0000") Then
      mIDItem.AppendMetaData("GetFileName/" & mFilename)
      Return mFilename
    Else
      mIDItem.AppendMetaData("GetFileName/NEWFILENAME/" & newdvID.GuidID.ToString)
      Return mHeroType.ToString & "-" & mUniqueName & "-" & newdvID.GuidID.ToString & ".bld"
    End If
  End Function

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.ErrorColor
    End Get
    Set(value As Color)

    End Set
  End Property
End Class
