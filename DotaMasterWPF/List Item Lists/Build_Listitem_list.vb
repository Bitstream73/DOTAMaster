Public Class Build_Listitem_list
  Inherits List(Of ctrlBuild_List_Item)

  'used to keep track of whether we need to resort
  Private currentcount As Integer = 0

  Public Function GetSortedList() As Build_Listitem_list
    If Not Me.Count = currentcount Then
      Me.Sort(AddressOf CompareItemsByName)
      currentcount = Me.Count
    End If


    Return Me
  End Function


  'Public Function GetSortedList() As List(Of ctrlBuild_List_Item)
  '  Return fu.Sort(Function(x As ctrlBuild_List_Item, y As ctrlBuild_List_Item)
  '                   If x.lblItemName.Content Is Nothing AndAlso y.lblItemName.Content Is Nothing Then
  '                     Return 0
  '                   ElseIf x.lblItemName.Content Is Nothing Then
  '                     Return -1
  '                   ElseIf y.lblItemName.Content Is Nothing Then
  '                     Return 1
  '                   Else
  '                     Return 1
  '                     'Return x.lblItemName.Content.CompareTo(y.lblItemName.Content)
  '                   End If
  '                 End Function)


  '  Return



  'End Function

  Private Function CompareItemsByName( _
        x As ctrlBuild_List_Item,  y As ctrlBuild_List_Item) As Integer
    Dim xname As String = x.lblItemName.Content
    Dim yname As String = y.lblItemName.Content
    If xname Is Nothing Then
      If yname Is Nothing Then
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
      If yname Is Nothing Then
        ' ...and y is Nothing, x is greater.
        Return 1
      Else
        ' ...and y is not Nothing, compare the 
        ' lengths of the two strings.
        '
        Dim retval As Integer = _
            xname.CompareTo(yname)

        If retval <> 0 Then
          ' If the strings are not of equal length,
          ' the longer string is greater.
          '
          Return retval
        Else
          ' If the strings are of equal length,
          ' sort them with ordinary string comparison.
          '
          Return xname.CompareTo(yname)
        End If
      End If
    End If

  End Function
End Class
