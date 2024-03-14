Public Class ctrlSummary_Graph
  Implements iGraphable

  Private mColumns As New List(Of ColumnDefinition)

  Private mDataItems As List(Of List(Of iDataItem))


  Private mUpdatablebars As New List(Of ctrlSummaryBar)

  Private mBarWidth As GridLength
  Private mGame As dGame

  Public Event SummaryBarHovered(sender As ctrlSummaryBar)
  Public Event SummaryBarUnhovered(sender As ctrlSummaryBar)

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected


  Private mSelectedSummaryBar As ctrlSummaryBar
  ''' <summary>
  ''' on list(of dataitem) for each subheading. Nothing List items will create a space in graph
  ''' </summary>
  ''' <param name="dataitems"></param>
  ''' <param name="subheadingtitles"></param>
  ''' <remarks></remarks>
  Public Sub Load(dataitems As List(Of List(Of iDataItem)), subheadingtitles As List(Of String), _
                  barwidth As GridLength, margin As GridLength, game As dGame)

    mBarWidth = barwidth
    mGame = game
    mDataItems = dataitems


    AddBars(mDataItems, mBarWidth, margin, mGame)

    AddSubHeads(subheadingtitles)



  End Sub

  Public Sub UpdateTime(curtime As ddFrame)
    For i = 0 To mUpdatablebars.Count - 1
      mUpdatablebars.Item(i).Update(curtime)
    Next


  End Sub


  Public ReadOnly Property SelectedSummmaryBar As ctrlSummaryBar
    Get
      Return mSelectedSummaryBar
    End Get
  End Property
  Private Sub AddSubHeads(subheadingtitles As List(Of String))
    Dim labelcolumnposition = 0
    For i = 0 To subheadingtitles.Count - 1
      Dim curdataitems = mDataItems.Item(i)
      Dim columnwidth = mDataItems.Item(i).Count

      Dim lbl As New ctrlSubHeading()
      lbl._Content = subheadingtitles.Item(i)

      If i = 0 Then
        labelcolumnposition = 0
      Else
        labelcolumnposition = labelcolumnposition + mDataItems.Item(i - 1).Count + 1 '+1 is for spacer column
      End If
      lbl.SetValue(Grid.ColumnProperty, labelcolumnposition)
      lbl.SetValue(Grid.ColumnSpanProperty, columnwidth)
      lbl.SetValue(Grid.RowProperty, 1)
      lbl.HorizontalAlignment = Windows.HorizontalAlignment.Center

      LayoutRoot.Children.Add(lbl)

    Next

  End Sub
  Private Sub AddBars(dataitems As List(Of List(Of iDataItem)), barwidth As GridLength, margin As GridLength, game As dGame)
    Dim curtime = mGame.TimeKeeper.CurrentTime
    'loop thru subheads
    For i = 0 To dataitems.Count - 1

      'loops thru items for each subhead
      Dim curdataitems = dataitems.Item(i)
      For x = 0 To curdataitems.Count - 1
        Dim curdataitem = curdataitems.Item(x)
        If Not curdataitem Is Nothing Then

          Dim myteam As dTeam
          Select Case i
            Case 0
              myteam = mGame.RadiantTeam
            Case 1
              myteam = mGame.DireTeam
            Case Else

          End Select

          AddBar(curtime, curdataitem, New SolidColorBrush(curdataitem.MyColor), barwidth, margin, myteam)

        End If
      Next

      'add spacer between subheads
      AddSpacerBar(barwidth)
    Next

  End Sub


  Private Sub AddSpacerBar(width As GridLength)
    Dim col As New ColumnDefinition
    col.Width = width
    LayoutRoot.ColumnDefinitions.Add(col)
    mColumns.Add(col)
  End Sub
  Private Sub AddBar(curtime As ddFrame, dataitem As iDataItem, _
                     fillbrush As SolidColorBrush, _
                     barwidth As GridLength, margin As GridLength, team As dTeam)

    Dim bar As New ctrlSummaryBar(dataitem, fillbrush, barwidth, margin, team)
    bar.Update(curtime)
    bar.SetValue(Grid.ColumnProperty, mColumns.Count)
    mUpdatablebars.Add(bar)
    LayoutRoot.Children.Add(bar)


    Dim col As New ColumnDefinition
    col.Width = barwidth
    LayoutRoot.ColumnDefinitions.Add(col)
    mColumns.Add(col)

    AddHandler bar.DataItemHovered, AddressOf Bar_DataItemHovered
    AddHandler bar.GraphableSelected, AddressOf Bar_GraphableSelected



  End Sub


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mSelectedSummaryBar Is Nothing Then
        Return mSelectedSummaryBar.GraphDataItems
      End If
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedSummaryBar Is Nothing Then
        Return mSelectedSummaryBar.GraphPreferences
      End If
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedSummaryBar Is Nothing Then
      mSelectedSummaryBar.SetGraphed(isgraphed)
    End If
  End Sub

  Private Sub Bar_DataItemHovered(sender As ctrlSummaryBar)

    RaiseEvent SummaryBarHovered(sender)
  End Sub

  Private Sub Bar_DataItemUnhovered(sender As ctrlSummaryBar)
    RaiseEvent SummaryBarHovered(sender)
  End Sub

  Private Sub Bar_GraphableSelected(sender As iGraphable)
    If Not sender Is mSelectedSummaryBar Then
      mSelectedSummaryBar = sender

      RaiseEvent GraphableSelected(mSelectedSummaryBar)
    End If
  End Sub



End Class
