Public Class ddFrame

  ' Implements IComparable(Of ddFrame)

  Public count As Integer

  'Private id As New dvID(Guid.NewGuid, "FU")
  Public Sub New()
    count = 0
  End Sub

  Public Sub New(thecount As Integer)
    count = thecount

  End Sub

  Property TimeIndex As Integer
  'Public Overrides Function Equals(obj As Object) As Boolean
  '  If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
  '    Return False
  '  End If

  '  Dim p As ddFrame = CType(obj, ddFrame)
  '  Return Me.count = p.count
  'End Function

  'Public Overrides Function GetHashCode() As Integer
  '  Return count
  'End Function
  'Public Function CompareTo(other As ddFrame) As Integer Implements IComparable(Of ddFrame).CompareTo

  '  If other Is Nothing Then
  '    Return 1
  '  Else
  '    Dim tcont As String = Me.count
  '    Return tcont.CompareTo(other)

  '  End If

  'End Function
End Class
