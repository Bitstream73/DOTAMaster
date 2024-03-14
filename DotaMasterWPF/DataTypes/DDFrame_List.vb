Public Class DDFrame_List
  Private mFrames As List(Of ddFrame)
  Private mValList As List(Of Integer)

  Public Sub New( theframes As List(Of ddFrame))
    mFrames = theframes
    mValList = New List(Of Integer)
    For i As Integer = 0 To mFrames.Count - 1
      mValList.Add(mFrames.Item(i).count)
    Next

  End Sub

  Public Function GetIndexForFrame( theframe As ddFrame) As Integer
    Return mValList.IndexOf(theframe.count)


  End Function

  Public ReadOnly Property TheFrames As List(Of ddFrame)
    Get
      Return mFrames
    End Get
  End Property

  Public Sub AddFrame( theframe As ddFrame)
    mFrames.Add(theframe)
    mValList.Add(theframe.count)
  End Sub

  Public Function Item( theindex As Integer) As ddFrame
    Return mFrames.Item(theindex)
  End Function
End Class
