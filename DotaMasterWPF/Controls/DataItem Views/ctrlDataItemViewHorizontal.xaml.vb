Public Class ctrlDataItemViewHorizontal
  Implements iDetails, iGraphable


  Private mDataitems As List(Of iDataItem)
  Private mColumnCount As Integer

  Private mColumns As List(Of StackPanel)

  Private dbControls As Controls_Database
  Private mGame As dGame
  Private mCurtime As ddFrame

  Private mStatControls As List(Of ctrlSwatchDataItemLabel)
  Private mModControls As List(Of ctrlSwatchDataItemLabel)

  Private mSelectedGraphable As iGraphable
  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected


  Public Sub LoadMe(dataitems As List(Of iDataItem), columncount As Integer, _
                    controlsdb As Controls_Database, game As dGame)

    Layoutroot.ColumnDefinitions.Clear()
    Layoutroot.Children.Clear()

    mStatControls = New List(Of ctrlSwatchDataItemLabel)
    mModControls = New List(Of ctrlSwatchDataItemLabel)
    mColumns = New List(Of StackPanel)

    mDataitems = dataitems
    mColumnCount = columncount
    dbControls = controlsdb
    mGame = game
    mCurtime = mGame.TimeKeeper.CurrentTime

    LoadColumnsAndStackPanels(columncount)


    Dim curcolumnindex = 0
    For i = 0 To dataitems.Count - 1
      Dim curitem = dataitems.Item(i)
      Dim curcolumn = mColumns.Item(curcolumnindex)
      AddDataItemToColumn(curitem, curcolumn)

      curcolumnindex = UpdateCurrentColumnIndex(curcolumnindex)
    Next
  End Sub

  Private Sub LoadColumnsAndStackPanels(columncount As Integer)

    If columncount = 1 Then
      'set up one column centered in control

      Dim leftcol As New ColumnDefinition
      leftcol.Width = New GridLength(1, GridUnitType.Star)
      Layoutroot.ColumnDefinitions.Add(leftcol)

      'content column
      Dim column As New ColumnDefinition
      column.Width = New GridLength(1, GridUnitType.Auto)
      Layoutroot.ColumnDefinitions.Add(column)

      Dim stackpnl As New StackPanel
      'stackpnl.Background = New SolidColorBrush(Color.FromArgb(255, 125, 100, 50))
      'stackpnl.Height = 25
      stackpnl.Orientation = Orientation.Vertical
      stackpnl.SetCurrentValue(Grid.ColumnProperty, 1)
      Layoutroot.Children.Add(stackpnl)
      mColumns.Add(stackpnl)

      Dim rightcol As New ColumnDefinition
      rightcol.Width = leftcol.Width
      Layoutroot.ColumnDefinitions.Add(rightcol)

      Exit Sub
    End If

    For i = 0 To columncount - 1

      Dim column As New ColumnDefinition
      column.Width = New GridLength(1, GridUnitType.Star)
      Layoutroot.ColumnDefinitions.Add(column)

      Dim stackpnl As New StackPanel
      'stackpnl.Background = New SolidColorBrush(Color.FromArgb(255, 125, 100, 50))
      'stackpnl.Height = 25
      stackpnl.Orientation = Orientation.Vertical
      stackpnl.SetCurrentValue(Grid.ColumnProperty, i)
      Layoutroot.Children.Add(stackpnl)
      mColumns.Add(stackpnl)
    Next
  End Sub


  Private Function UpdateCurrentColumnIndex(currentindex As Integer) As Integer
    If currentindex < mColumns.Count - 1 Then
      Return currentindex + 1
    Else
      Return 0
    End If
  End Function
  Private Sub AddDataItemToColumn(dataitem As iDataItem, column As StackPanel)
    Select Case dataitem.DataItemType
      Case eDataItemType.Modifier
        Dim themod As Modifier = DirectCast(dataitem, Modifier)

        Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, themod, _
                                                         themod.ModGenerator.DisplayName & "'s " & themod.DisplayName, "")

        AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected
        mModControls.Add(ctrl)
        column.Children.Add(ctrl)

      Case eDataItemType.Stat
        Dim thestat As Stat = DirectCast(dataitem, Stat)
        Dim team As dTeam = mGame.GetTeamFromGameEntity(thestat.ParentGameEntity)

        Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, thestat,
                                                     thestat.ParentGameEntity.DisplayName & "'s " & thestat.DisplayName, "")

        AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected
        mStatControls.Add(ctrl)
        column.Children.Add(ctrl)

      Case Else
        Throw New NotImplementedException
    End Select


  End Sub

  Public Property MyDetailsGameEntity As iGameEntity Implements iDetails.MyDetailsGameEntity

  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    mCurtime = curtime
    For i = 0 To mStatControls.Count - 1
      mStatControls.Item(i).UpdateValue(mCurtime)
    Next

    For i = 0 To mModControls.Count - 1
      mModControls.Item(i).UpdateValue(mCurtime)
    Next
  End Sub


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mSelectedGraphable Is Nothing Then
        Return mSelectedGraphable.GraphDataItems()
      End If
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property


  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedGraphable Is Nothing Then
      mSelectedGraphable.SetGraphed(isgraphed)
    End If
  End Sub

  Private Sub ChildControl_GraphableSelected(sender As iGraphable)
    mSelectedGraphable = sender
    RaiseEvent GraphableSelected(sender)
  End Sub
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedGraphable Is Nothing Then
        Return mSelectedGraphable.GraphPreferences
      End If
      Return Nothing
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property
End Class
