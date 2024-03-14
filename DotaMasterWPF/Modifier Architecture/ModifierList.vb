Imports DotaMasterWPF.PageHandler

Public Class ModifierList
  'Modifiers are all, property changes that can affect
  'a Unit (Hero, Creep, Structure). It's just a collection
  'of modifier objects

  Inherits List(Of Modifier)
  'Public myDict As New Dictionary(Of dvID, Modifier) ' the raw modifiers

  Private modsattime As New Dictionary(Of DateTime, List(Of dvID)) 'listing of which modifiers are active at which points in time as determined by game length and framerate


  'comparer strngs
  Private curComparer As eComparerType


  Public Sub New()

  End Sub

  Public Sub New(themods As List(Of Modifier))
    Me.AddRange(themods)
  End Sub
  'Public Function GetModsSortedByParent() As List(Of ModifierList)

  'End Function
  Public Function GetModsByType( thetype As eModifierType) As ModifierList
    Dim outmods As New ModifierList

    'For Each kv As KeyValuePair(Of dvID, Modifier) In myDict
    '  If kv.Value.Type = thetype Then
    '    outmods.Add(kv.Value)
    '  End If
    'Next

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).Type = thetype Then
        outmods.Add(Me.Item(i))
      End If
    Next

    Return outmods
  End Function



  'Public Function GetModsAsdict() As Dictionary(Of dvID, Modifier)
  '  Return myDict


  'End Function
  Public Sub SortListByModID()
    ' If Not Me.Count = currentcount Then

    curComparer = eComparerType.MyID
    Me.Sort(AddressOf CompareItemsByString)
    'currentcount = Me.Count
    ' End If
  End Sub

  Public Sub SortListByParentID()
    ' If Not Me.Count = currentcount Then

    curComparer = eComparerType.ParentGameEntityID
    Me.Sort(AddressOf CompareItemsByString)
    'currentcount = Me.Count
    ' End If

  End Sub
  Public Sub SortListByParentGameEntityType()
    curComparer = eComparerType.ParentGameEntityType
    Me.Sort(AddressOf CompareItemsByString)
  End Sub

  Public Sub SortListBySourceID()
    curComparer = eComparerType.SourceID
    Me.Sort(AddressOf CompareItemsByString)
  End Sub

  Public Sub SortListBySourceType()
    curComparer = eComparerType.SourceType
    Me.Sort(AddressOf CompareItemsByString)
  End Sub

  Public Sub SortlistByModType()
    curComparer = eComparerType.ModifierType
    Me.Sort(AddressOf CompareItemsByString)
  End Sub

  'Public Sub SortmodifierListByTargetIds(thelist As ModifierList, namesdb As FriendlyName_Database, thetime As TimeKeeper)
  '  curComparer = eComparerType.TargetIDs
  '  'curComparer = eComparerType.ParentType


  '  'Me.Sort(AddressOf CompareItemsByString)

  '  'This crappy sort is here cuz me.sort by target ID's throws
  '  'error argumentoutofrangeexception

  '  Dim curtargs As String = ""
  '  Dim targlists As New Dictionary(Of String, List(Of Modifier))
  '  For i As Integer = 0 To Me.Count - 1
  '    If i = 33 Then
  '      Dim x = 2
  '    End If
  '    curtargs = Helpers.GetInGameTargetsStringForMod(Me.Item(i), ) 'Me.Item(i).GetInGameTargetsString
  '    If Not targlists.ContainsKey(curtargs) Then
  '      Dim newlist As New List(Of Modifier)
  '      newlist.Add(Me.Item(i))
  '      targlists.Add(curtargs, newlist)
  '    Else
  '      Dim curlist = targlists.Item(curtargs)
  '      curlist.Add(Me.Item(i))
  '    End If
  '  Next



  '  Me.Clear()
  '  For Each kv As KeyValuePair(Of String, List(Of Modifier)) In targlists
  '    Dim curlist = kv.Value

  '    For i As Integer = 0 To curlist.Count - 1
  '      Me.Add(curlist.Item(i))
  '    Next

  '  Next

  'End Sub

  'Public Sub SortListbyTeamof1stTargetID()
  '  curComparer = eComparerType.TeamOf1stTargetID
  '  Me.Sort(AddressOf CompareItemsByString)
  'End Sub
  Private Function CompareItemsByToModId( _
       x As Modifier, y As Modifier) As Integer
    Dim xname As String = x.IDItem.ToString
    Dim yname As String = y.IDItem.ToString
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



  Private Function CompareItemsByString(x As Modifier, y As Modifier) As Integer
    Dim xname As String
    Dim yname As String

    Select Case curComparer
      Case eComparerType.MyID
        xname = x.IDItem.ToString
        yname = y.IDItem.ToString

      Case eComparerType.ParentGameEntityID
        xname = x.Parent.ToString
        yname = y.Parent.ToString

      Case eComparerType.ParentGameEntityType
        xname = x.ParentGameEntityType
        yname = y.ParentGameEntityType

      Case eComparerType.SourceID
        xname = x.TheModInfo.ModGenerator.ToString
        yname = y.TheModInfo.ModGenerator.ToString

      Case eComparerType.SourceType
        xname = x.TheModInfo.ModGenerator.MyType
        yname = y.TheModInfo.ModGenerator.MyType

      Case eComparerType.ModifierType
        xname = x.ModifierType.ToString
        yname = x.ModifierType.ToString

      Case eComparerType.TargetIDs
        Throw New NotImplementedException
        ' Dim namesdb As New FriendlyName_Database(PageHandler.thelog)
        'xname = Helpers.GetInGameTargetsStringForMod(x, namesdb, m
        'yname = Helpers.GetInGameTargetsStringForMod(y, namesdb)


      Case Else
        xname = x.IDItem.ToString
        yname = x.IDItem.ToString
        PageHandler.theLog.writelog("ModifierList.CompareItemsByString missing EComparertype: " & curComparer.ToString)
    End Select

    If xname Is Nothing Then
      If yname Is Nothing Then
        'PageHandler.theLog.writelog("retval: 0")
        Return 0
      Else
        'PageHandler.theLog.writelog("retval: -1")
        Return -1
      End If
    Else
      If yname Is Nothing Then
        ' PageHandler.theLog.writelog("retval: 1")
        Return 1
      Else
        Dim retval As Integer = _
            xname.CompareTo(yname)

        If retval <> 0 Then
          ' PageHandler.theLog.writelog("retval:" & retval.ToString)
          Return retval
        Else
          'PageHandler.theLog.writelog("retval xtoy:" & xname.CompareTo(yname).ToString)
          Return xname.CompareTo(yname)
        End If
      End If
    End If

  End Function

  Public Function GetFirstMod() As Modifier
    'For Each kv As KeyValuePair(Of dvID, Modifier) In myDict
    '  Return kv.Value
    '  Exit For
    'Next

    If Me.Count > 0 Then
      Return Me.Item(0)
    End If
    Return Nothing
  End Function

  Public Function GetModsbyOwnerType(theownertype As eSourceType) As ModifierList
    Dim outmods As New ModifierList

    'For Each kv As KeyValuePair(Of dvID, Modifier) In myDict
    '  If kv.Value.ParentType = theownertype Then
    '    outmods.Add(kv.Value)
    '  End If
    'Next

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).ParentGameEntityType = theownertype Then
        outmods.Add(Me.Item(i))
      End If
    Next

    Return outmods
  End Function

  Public Function GetModsbyParentID(theparentid As dvID) As List(Of Modifier)
    Dim outmods As New ModifierList

    'For Each kv As KeyValuePair(Of dvID, Modifier) In myDict
    '  If kv.Value.ParentID = theparentid Then
    '    outmods.Add(kv.Value)
    '  End If
    'Next

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).Parent.Id.GuidID = theparentid.GuidID Then
        outmods.Add(Me.Item(i))
      End If
    Next
    Return outmods
  End Function


  Public Function GetModByIDItem( theiditem As dvID) As Modifier

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i) Is theiditem Then
        Return Me.Item(i)
      End If
    Next
    Return Nothing
  End Function
  'Public Function GetModsbyHeroLevel( theherolevel As Integer) As ModifierList

  '  Dim outmods As New ModifierList

  '  'For Each kv As KeyValuePair(Of dvID, Modifier) In myDict
  '  '  If kv.Value.HeroLevel = theherolevel Then
  '  '    outmods.Add(kv.Value)
  '  '  End If
  '  'Next

  '  For i As Integer = 0 To Me.Count - 1
  '    If Me.Item(i).HeroLevel = theherolevel Then
  '      outmods.Add(Me.Item(i))
  '    End If
  '  Next
  '  Return outmods
  'End Function

  Public Function GetModsAtTime( thetime As DateTime) As List(Of Modifier)

    Dim outlist As New List(Of Modifier)

    If modsattime.ContainsKey(thetime) Then
      Dim theiditems = modsattime.Item(thetime)

      For i As Integer = 0 To theiditems.Count - 1
        outlist.Add(GetModByIDItem(theiditems.Item(i)))
      Next
    End If


    Return outlist
  End Function

  'Public Sub Add( themod As Modifier)
  '  ' Dim themod As Modifier = thelist.Item(i)
  '  Me.Add(themod)

  '  Dim thetimes = Helpers.GetAllTimesFromLifetime(themod.Lifetime, mTimeKeeper.Framerate)
  '  AddModAtTimes(thetimes, themod)
  'End Sub
  Public Sub AddModList( thelist As ModifierList)

    'For Each kv As KeyValuePair(Of dvID, Modifier) In thelist.myDict

    '  Add(kv.Value)
    'Next

    For i As Integer = 0 To thelist.Count - 1
      If Not Me.Contains(thelist.Item(i)) Then Me.Add(thelist.Item(i))
    Next
  End Sub

  Public Sub AddList( thelist As List(Of Modifier))
    If thelist Is Nothing Then Exit Sub
    For i As Integer = 0 To thelist.Count - 1

      If Not Me.Contains(thelist.Item(i)) Then Me.Add(thelist.Item(i))

    Next

  End Sub

  'Public ReadOnly Property Count As Integer
  '  Get
  '    Return myDict.Count
  '  End Get
  'End Property

  Private Sub AddModAtTimes( thetimes As List(Of DateTime),  themod As Modifier)

    For i As Integer = 0 To thetimes.Count - 1

      Dim thetime = thetimes.Item(i)
      If modsattime.ContainsKey(thetime) Then

        Dim thelist As List(Of dvID) = modsattime.Item(thetime)
        If Not thelist.Contains(themod.IDItem) Then thelist.Add(themod.IDItem)

      Else
        Dim newlist As New List(Of dvID)
        newlist.Add(themod.IDItem)

        modsattime.Add(thetime, newlist)
      End If
    Next

  End Sub

  'Public Function GetModsbyParent( theparent As String) As ModifierList
  '  Dim outmods As New ModifierList

  '  For i As Integer = 0 To Me.Count - 1
  '    If Me.Item(i).Parent = theparent Then
  '      outmods.Add(Me.Item(i))
  '    End If
  '  Next
  '  Return outmods
  'End Function
  Public Function ContainsModIDItem( theiditem As dvID) As Boolean
    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).IDItem Is theiditem Then Return True
    Next

    Return False
  End Function

  Public Function ContainsModType( thetype As eModifierType) As Boolean
    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).ModifierType = thetype Then Return True
    Next
    Return False
  End Function
  Public Sub RemoveByModIDItem( theiditem As dvID)

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).IDItem Is theiditem Then Me.Remove(Me.Item(i))
    Next
  End Sub

  Public Function GetIndexforIDItem( theiditem As dvID) As Integer

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).IDItem Is theiditem Then Return i
    Next
    Return -1
  End Function
  Public Sub ReplaceAtIndex( theindex As Integer,  themod As Modifier)
    If theindex < Me.Count Then
      Me.RemoveAt(theindex)
      Me.Insert(theindex, themod)
    Else
      Me.Add(themod)
    End If

  End Sub
  'Public Sub RemoveByID( theid As dvID)
  '  If myDict.ContainsKey(theid) Then myDict.Remove(theid)

  'End Sub
  Public Function GetModsbyAffectedUnittypes( thetypes As List(Of eUnit)) As ModifierList
    Dim outmods As New ModifierList

    Dim currlist As New ModifierList
    For x As Integer = 0 To thetypes.Count - 1
      currlist = New ModifierList
      currlist = GetModsbyAffectedUnitType(thetypes.Item(x))

      For i As Integer = 0 To currlist.Count - 1
        If Not outmods.Contains(currlist.Item(i)) Then
          outmods.Add(currlist.Item(i))
        End If
      Next
    Next

    Return outmods
  End Function

  Public Function GetModsbyAffectedUnitType( thetype As eUnit) As ModifierList
    Dim outmods As New ModifierList

    'For Each kv As KeyValuePair(Of dvID, Modifier) In myDict
    '  If kv.Value.AffectedUnitTypes.Contains(thetype) Then
    '    outmods.Add(kv.Value)
    '  End If
    'Next

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).AffectedUnitTypes.Contains(thetype) Then
        outmods.Add(Me.Item(i))
      End If
    Next
    Return outmods
  End Function
End Class
