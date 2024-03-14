Public Class ValueList
  Public values As List(Of Double?)
  Private mdatelist As List(Of ddFrame)
  Private mDateVals As List(Of Integer) 'list of ddframe.count
  Private startval As Double? = -1000000

  Private mMaxValue As Double?
  Public Sub New( thetimes As List(Of ddFrame))
    mdatelist = thetimes

    values = New List(Of Double?)(mdatelist.Count)
    mDateVals = New List(Of Integer)(mdatelist.Count)
    For i As Integer = 0 To mdatelist.Count - 1
      values.Add(startval)
      mDateVals.Add(mdatelist.Item(i).count)
    Next
  End Sub

  Public Sub Clear()
    For i As Integer = 0 To mdatelist.Count - 1
      values.Add(startval)
    Next
  End Sub

  Public ReadOnly Property Count As Integer
    Get
      Return mdatelist.Count
    End Get
  End Property

  Public Function Item( thekey As ddFrame) As Double?
    'Why the fuck doesn't indexof work here???
    'Dim ind As Integer = mdatelist.IndexOf(thekey)

    'Dim ind As Integer = -1
    'If mdatelist.Item(thekey.count).count = thekey.count Then
    '  ind = thekey.count
    'Else
    '  For i As Integer = 0 To mdatelist.Count - 1
    '    If mdatelist.Item(i).count = thekey.count Then
    '      ind = i
    '      Exit For
    '    End If

    '  Next
    'End If
    If values Is Nothing Then
      Dim x = 2
    End If

    Dim ind = mDateVals.IndexOf(thekey.count)


    If values.Count > ind And ind >= 0 Then
      'If valuelist.Item(ind) = 100 Then
      '  Dim x = 2
      'End If
      Return values.Item(ind)
    Else
      Return Nothing
    End If

  End Function
  Public ReadOnly Property ContainsKey( thekey As ddFrame) As Boolean
    Get
      If mDateVals.Contains(thekey.count) Then
        'Dim ind As Integer = mdatelist.IndexOf(thekey)
        'If values.Item(ind) > startval Then
        Return True
        'End If
      End If
      Return False
    End Get
  End Property

  Public ReadOnly Property ContainsValue( thevalue As Double) As Boolean
    Get
      If values.Contains(thevalue) Then Return True
      Return False
    End Get

  End Property


  Public Sub Add( thetime As ddFrame,  thevalue As Double?)
    Dim ind As Integer = 0
    If mdatelist.Contains(thetime) Then
      ind = mdatelist.IndexOf(thetime)
      values.RemoveAt(ind)
      values.Insert(ind, thevalue)
    End If
  End Sub
  Public ReadOnly Property DateList As List(Of ddFrame)
    Get
      Return mdatelist
    End Get
  End Property

  Public ReadOnly Property MaxValue As Double?
    Get

      Return values.Max
    End Get
  End Property


End Class
