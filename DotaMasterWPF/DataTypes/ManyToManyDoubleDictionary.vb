Public Class ManyToManyDoubleDictionary(Of Key0, Key1)

  Implements iDoubleDictionary(Of Key0, Key1), iManyToManyStore(Of Key0, Key1)

  Protected mLeftIndex As New Dictionary(Of Key0, List(Of Key1))
  Private mRightIndex As New Dictionary(Of Key1, List(Of Key0))
  Private mLog As iLogging
  Public Sub New(log As iLogging)
    mLog = log
  End Sub

  Public Sub Add(key As Key0, value As Key1) Implements iDoubleDictionary(Of Key0, Key1).Add
    Dim lst As New List(Of key1)
    lst.Add(value)
    Add(key, lst)
  End Sub
  Public Sub Add(key As Key0, values As IEnumerable(Of Key1)) Implements iManyToManyStore(Of Key0, Key1).Add
    Dim leftList As List(Of Key1)
    If mLeftIndex.ContainsKey(key) Then
      leftList = mLeftIndex.Item(key)
    Else
      leftList = New List(Of Key1)
      mLeftIndex.Item(key) = leftList
    End If

    leftList.AddRange(values)



    For Each item In values
      Dim rightList As List(Of Key0)
      If mRightIndex.ContainsKey(item) Then
        rightList = mRightIndex.Item(item)
      Else
        rightList = New List(Of Key0)
        mRightIndex.Item(item) = rightList
      End If
      If rightList.Contains(key) = False Then rightList.Add(key)
    Next

  End Sub


  Function ValuesForKey(key As Key0) As IEnumerable(Of Key1) Implements iManyToManyStore(Of Key0, Key1).ValuesForKey
    If mLeftIndex.ContainsKey(key) Then
      Return mLeftIndex.Item(key)
    Else
      mLog.WriteLog("Value missing for: " & key.ToString)
      Return New List(Of Key1)
    End If
  End Function

  Function ValuesForKey(key As Key1) As IEnumerable(Of Key0) Implements iManyToManyStore(Of Key0, Key1).ValuesForKey

    If mRightIndex.ContainsKey(key) Then
      Return mRightIndex.Item(key)
    Else
      mLog.WriteLog("Value missing for: " & key.ToString)
      Return New List(Of Key0)

    End If
  End Function

  Function Remove(key As Key0, value As Key1) As Boolean Implements iDoubleDictionary(Of Key0, Key1).Remove
    Dim removed As Boolean = False
    Dim removedRight As Boolean = False
    If mLeftIndex.ContainsKey(key) Then
      removed = mLeftIndex.Item(key).Remove(value)
    End If

    If mRightIndex.ContainsKey(value) Then
      removedRight = mRightIndex.Item(value).Remove(key)
    End If
    Return removed Or removedRight
  End Function

End Class
