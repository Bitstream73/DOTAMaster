Public Class AbilityValueList

  Public mAbValueList As New List(Of Double)
  Private mDateList As List(Of ddFrame)
  Private startval As Double = -1000000
  Public Sub New( thetimes As Lifetime,  theabvalues As List(Of Double))
    mDateList = thetimes.StartTimes

    For i As Integer = 0 To mDateList.Count - 1
      mAbValueList.Add(startval)
    Next
  End Sub

  Public Sub Clear()
    For i As Integer = 0 To mDateList.Count - 1
      mAbValueList.Add(startval)
    Next
  End Sub

  Public ReadOnly Property Count As Integer
    Get
      Return mDateList.Count
    End Get
  End Property

  Public Function Item( thekey As ddFrame) As Double

    Dim ind As Integer = mDateList.IndexOf(thekey)

    If mAbValueList.Count > ind Then
      Return mAbValueList.Item(ind)
    Else
      Return Nothing
    End If

  End Function
  Public ReadOnly Property ContainsKey( thekey As ddFrame) As Boolean
    Get
      If mDateList.Contains(thekey) Then
        Dim ind As Integer = mDateList.IndexOf(thekey)
        If mAbValueList.Item(ind) > startval Then
          Return True
        End If
      End If
      Return False
    End Get
  End Property

  Public Function GetValueForTime( thetime As ddFrame) As Double

    Dim curval As Integer = 0
    For i As Integer = 0 To mDateList.Count - 1
      If thetime.count > mDateList.Item(i).count Then
        curval = AbilityValuesList.Item(i)
      End If
    Next

    Return curval
  End Function
  Public ReadOnly Property ContainsValue( thevalue As Double) As Boolean
    Get
      If mAbValueList.Contains(thevalue) Then Return True
      Return False
    End Get

  End Property
  'Public Sub Add( thetime As DateTime,  thevalue As Double)
  '  Dim ind As Integer = 0
  '  If mdatelist.Contains(thetime) Then
  '    ind = mdatelist.IndexOf(thetime)
  '    valuelist.RemoveAt(ind)
  '    valuelist.Insert(ind, thevalue)
  '  End If
  'End Sub
  Public ReadOnly Property DateList As List(Of ddFrame)
    Get
      Return mDateList
    End Get
  End Property

  Public ReadOnly Property AbilityValuesList As List(Of Double)
    Get
      Return mAbValueList
    End Get
  End Property

End Class
