Public Class OneToOneDoubleDictionary(Of key0, key1)
  Implements iDoubleDictionary(Of key0, key1), iOneToOneStore(Of key0, key1)
  Protected mLeftIndex As New Dictionary(Of key0, key1)
  Private mRightIndex As New Dictionary(Of key1, key0)
  Private mLog As iLogging
  Public Sub New(log As iLogging)
    mLog = log
  End Sub
  Public Sub AddorUpdate(key As key0, value As key1) Implements iDoubleDictionary(Of key0, key1).Add

    If mLeftIndex.ContainsKey(key) Then
      mLeftIndex.Item(key) = value
    Else
      mLeftIndex.Add(key, value)
    End If



    If mRightIndex.ContainsKey(value) Then
      mRightIndex.Item(value) = key
    Else
      mRightIndex.Add(value, key)
    End If

  End Sub
  Public Function Remove(key As key0, value As key1) As Boolean Implements iDoubleDictionary(Of key0, key1).Remove
    Dim removed As Boolean = False
    Dim removedRight As Boolean = False

    If mLeftIndex.ContainsKey(key) Then
      removed = mLeftIndex.Remove(key)
    End If

    If mRightIndex.ContainsKey(value) Then
      removedRight = mRightIndex.Remove(value)
    End If
    Return removed Or removedRight
  End Function


  Public Function ValueForKey(key As key0) As key1 Implements iOneToOneStore(Of key0, key1).ValueForKey
    If mLeftIndex.ContainsKey(key) Then
      Return mLeftIndex.Item(key)
    Else

      mLog.Writelog("Value missing for: " & GetType(key0).ToString & "." & key.ToString)
      Return Nothing
    End If
  End Function

  Public Function ValueForKey(key As key1) As key0 Implements iOneToOneStore(Of key0, key1).ValuesForKey
    If mRightIndex.ContainsKey(key) Then
      Return mRightIndex.Item(key)
    Else
      mLog.WriteLog("Value missing for: " & GetType(key1).ToString & "." & key.ToString)
      Return Nothing

    End If
  End Function

  Public Property Count As Integer
    Get
      Return mLeftIndex.Count
    End Get
    Set(value As Integer)

    End Set
  End Property
End Class
