Public Class Item_List



  Private mylist As New List(Of Item_Info)
  Private mIsSorted As Boolean = False
  'Private ItemPlan As New List(Of eItemPlan) <-- this is now in Item_info
  'Public Function GetListItems() As List(Of ctrlitem_List_Item)
  '  Dim outlist As New List(Of ctrlitem_List_Item)
  '  For i As Integer = 0 To mylist.Count - 1
  '    ' Dim newcombo As New ComboBoxItem
  '    Dim newctrl As New ctrlitem_List_Item(mylist.Item(i), mylist.Item(i).mDisplayname, PageHandler.dbImages.GetItemImage(mylist.Item(i).mName))
  '    'newcombo.Content = newctrl
  '    outlist.Add(newctrl)
  '  Next




  '  Return outlist
  'End Function

  Public Sub SortByCreationTime()
    ' If Not Me.Count = currentcount Then

    If Not mIsSorted Then
      mylist.Sort(AddressOf CompareItemsByCreationTime)
      mIsSorted = True
    End If

    'currentcount = Me.Count
    ' End If



  End Sub

  Public Sub UpdateTargets(thenemeytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendlybias As Boolean)

    For i As Integer = 0 To mylist.Count - 1
      mylist.Item(i).SetTargets(thenemeytarget, thefriendlytarget, isfriendlybias)
    Next
  End Sub

  Public Sub UpdateParent(parent As iDisplayUnit)
    For i = 0 To mylist.Count - 1
      mylist.Item(i).ParentGameEntity = parent
    Next
  End Sub
  Public ReadOnly Property Count As Integer
    Get
      Return mylist.Count
    End Get
  End Property

  Public Function GetItemByName(theitemname As eItemname) As Item_Info
    If Me.ContainsName(theitemname) Then
      For i As Integer = 0 To Me.Count - 1
        If Me.Item(i).ItemName = theitemname Then Return Me.Item(i)
      Next
    End If
    Return Nothing

  End Function

  Public Function GetItemByIdItem(theiditem As dvID) As Item_Info


    For i As Integer = 0 To mylist.Count - 1
      Dim theitem = mylist.Item(i)
      If theitem.ID Is theiditem Then Return theitem
    Next
    Return Nothing
  End Function
  Public Function Item(index As Integer) As Item_Info
    Return mylist.Item(index)
  End Function

  Public Sub Add(theitem As Item_Info)
    If theitem.Lifetime Is Nothing Then
      Dim x = 2
    End If
    mylist.Add(theitem)
    mIsSorted = False
  End Sub

  Public Sub Insert(theindex As Integer, theitem As Item_Info)
    mylist.Insert(theindex, theitem)
    mIsSorted = False
  End Sub
  Public Sub Clear()
    mylist.Clear()
  End Sub
  Public Sub RemoveAt(theindex As Integer)
    mylist.RemoveAt(theindex)
  End Sub
  Public Function Contains(theitem As Item_Info) As Boolean
    If mylist.Contains(theitem) Then Return True
    Return False
  End Function

  Public Sub Remove(theitem As Item_Info)
    mylist.Remove(theitem)
  End Sub
  Public Sub AddItem(theitem As Item_Info)
    mylist.Add(theitem)
    mIsSorted = False
  End Sub
  Public Function ContainsName(thename As eItemname) As Boolean
    For i As Integer = 0 To mylist.Count - 1
      If mylist.Item(i).ItemName = thename Then Return True
    Next
    Return False
  End Function

  Public Function ContainsParentID(thepid As dvID) As Boolean

    For i As Integer = 0 To mylist.Count - 1

      If mylist.Item(i).ParentGameEntity.Id Is thepid Then Return True

    Next
    Return False
  End Function

  Public Function ContainsIDItem( theiditem As dvID) As Boolean
    For i As Integer = 0 To mylist.Count - 1

      If mylist.Item(i).ID Is theiditem Then Return True

    Next
    Return False
  End Function

  Public Function GetByName( thename As eItemname) As Item_Info
    For i As Integer = 0 To mylist.Count - 1
      If mylist.Item(i).ItemName = thename Then Return mylist.Item(i)
    Next
    Return Nothing
  End Function
  Public Sub RemoveByName( thename As eItemname)
    For i As Integer = mylist.Count - 1 To 0 Step -1

      If mylist.Item(i).ItemName = thename Then mylist.Remove(mylist.Item(i))
    Next
  End Sub
  Private Function CompareItemsByCreationTime( _
        x As Item_Info,  y As Item_Info) As Integer
    Dim xdate As ddFrame = x.Lifetime.CreationTime
    Dim ydate As ddFrame = y.Lifetime.CreationTime
    If xdate Is Nothing Then
      If ydate Is Nothing Then
        ' If x is Nothing and y is Nothing, they're
        ' equal. 
        Return 0
      Else
        ' If x is Nothing and y is not Nothing, y
        ' is greater. 
        Return -1
      End If
    Else
      ' If x is not Nothing...
      '
      If ydate Is Nothing Then
        ' ...and y is Nothing, x is greater.
        Return 1
      Else
        ' ...and y is not Nothing, compare the 
        ' lengths of the two strings.
        '
        Dim retval As Integer = _
            xdate.count.CompareTo(ydate.count)

        If retval <> 0 Then
          ' If the strings are not of equal length,
          ' the longer string is greater.
          '
          Return retval
        Else
          ' If the strings are of equal length,
          ' sort them with ordinary string comparison.
          '
          Return xdate.count.CompareTo(ydate.count)
        End If
      End If
    End If

  End Function


  Public Overloads Overrides Function Equals(obj As Object) As Boolean


    Dim otherlist = TryCast(obj, Item_List)

    If otherlist Is Nothing Then Return False

    If otherlist.Count <> Me.Count Then Return False

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).ID.GuidID.ToString <> otherlist.Item(i).ID.GuidID.ToString Then Return False

    Next
    Return True

  End Function

End Class
