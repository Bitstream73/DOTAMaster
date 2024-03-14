Public Class Bar_Group_Collection
  Private mylist As New List(Of ctrlBar_Group)
  Private mMaxHeight As Double
  Private mMinHeight As Double


  Public Sub New()

    mMinHeight = 1000000
    mMaxHeight = 0


  End Sub

  Public Sub AddBarGroup(ByVal thebargroup As ctrlBar_Group)
    mylist.Add(thebargroup)

    If thebargroup.TotalValue > mMaxHeight Then mMaxHeight = thebargroup.TotalValue
    If thebargroup.TotalValue < mMinHeight Then mMinHeight = thebargroup.TotalValue
  End Sub

  ''' <summary>
  ''' this should only be called once all bars have been added since max and minheight may change!
  ''' </summary>
  ''' <param name="theindex"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetBarGroup(ByVal theindex As Integer) As ctrlBar_Group
    If theindex >= mylist.Count Or theindex < 0 Then Return Nothing

    Dim thegroup = mylist.Item(theindex)
    thegroup.SetFillerHeight(True, mMaxHeight)

    Return thegroup

  End Function


  Public Sub Clear()
    mylist.Clear()
    mMaxHeight = 0
    mMinHeight = 10000000
  End Sub
  Public Function BarGroupCount() As Integer
    Return mylist.Count
  End Function
  'Public Function GetBarGroup(ByVal theindex As Integer) As ctrlBar_Group
  '  Dim thebgroup = mylist.Item(theindex)


  '  Return mylist.Item(theindex)
  'End Function
End Class
