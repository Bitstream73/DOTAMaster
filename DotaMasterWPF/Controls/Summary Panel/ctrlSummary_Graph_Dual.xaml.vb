Public Class ctrlSummary_Graph_Dual
  Implements iGraphable

  Private mColumns As New List(Of ColumnDefinition)

  Private mRadDataItems As List(Of List(Of iDataItem))
  Private mDireDataItems As List(Of List(Of iDataItem))

  Private mUpdatablebars As New List(Of ctrlSummaryBarDual)

  Private mBarWidth As GridLength
  Private mGame As dGame

  Public Event SummaryBarHovered(sender As ctrlSummaryBar)
  Public Event SummaryBarUnhovered(sender As ctrlSummaryBar)

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Private mSelectedSummaryBar As ctrlSummaryBarDual

  Public Sub Load(raddataitems As List(Of List(Of iDataItem)), diredataitems As List(Of List(Of iDataItem)), _
                  subheadingtitles As List(Of String), _
                  barwidth As GridLength, margin As GridLength, game As dGame, _
                  radcolor As SolidColorBrush, direcolor As SolidColorBrush, neutralcolor As SolidColorBrush)

    mBarWidth = barwidth
    mGame = game
    mRadDataItems = raddataitems
    mDireDataItems = diredataitems

    AddBars(mRadDataItems, mDireDataItems, mBarWidth, margin, mGame, _
            radcolor, direcolor, neutralcolor)

    AddSubHeads(subheadingtitles)
  End Sub

  Public ReadOnly Property SelectedSummmaryBar As ctrlSummaryBarDual
    Get
      Return mSelectedSummaryBar
    End Get
  End Property
  Public Sub UpdateTime(curtime As ddFrame)
    For i = 0 To mUpdatablebars.Count - 1
      mUpdatablebars.Item(i).Update(curtime)
    Next
  End Sub

  Private Sub AddSubHeads(subheadingtitles As List(Of String))
    Dim labelcolumnposition = 0
    For i = 0 To subheadingtitles.Count - 1
      Dim curdataitems = mRadDataItems.Item(i)
      Dim columnwidth = mRadDataItems.Item(i).Count

      Dim lbl As New ctrlSubHeading()
      lbl._Content = subheadingtitles.Item(i)

      If i = 0 Then
        labelcolumnposition = 0
      Else
        labelcolumnposition = labelcolumnposition + mRadDataItems.Item(i - 1).Count + 1 '+1 is for spacer column
      End If
      lbl.SetValue(Grid.ColumnProperty, labelcolumnposition)
      lbl.SetValue(Grid.ColumnSpanProperty, columnwidth)
      lbl.SetValue(Grid.RowProperty, 1)
      lbl.HorizontalAlignment = Windows.HorizontalAlignment.Center

      LayoutRoot.Children.Add(lbl)

    Next

  End Sub
  Private Sub AddBars(raddataitems As List(Of List(Of iDataItem)), diredataitems As List(Of List(Of iDataItem)), _
                      barwidth As GridLength, margin As GridLength, game As dGame, _
                      radcolor As SolidColorBrush, direcolor As SolidColorBrush, neutralcolor As SolidColorBrush)
    Dim curtime = mGame.TimeKeeper.CurrentTime
    'loop thru subheads
    For i = 0 To raddataitems.Count - 1

      'loops thru items for each subhead
      Dim curRaddataitems = raddataitems.Item(i)
      Dim curDiredataitems = diredataitems.Item(i)

      For x = 0 To curRaddataitems.Count - 1
        Dim curraddataitem = curRaddataitems.Item(x)
        Dim cirdiredataitem = curDiredataitems.Item(x)
        If Not curraddataitem Is Nothing Then



          AddBar(curtime, curraddataitem, cirdiredataitem, _
                 New SolidColorBrush(curraddataitem.MyColor), barwidth, margin, _
                 radcolor, direcolor, neutralcolor)

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
  Private Sub AddBar(curtime As ddFrame, _
                     raddataitem As iDataItem, diredataitem As iDataItem, _
                     fillbrush As SolidColorBrush, _
                     barwidth As GridLength, margin As GridLength, _
                     radcolor As SolidColorBrush, direcolor As SolidColorBrush, neutralcolor As SolidColorBrush)

    Dim bar As New ctrlSummaryBarDual(raddataitem, diredataitem, fillbrush, barwidth, margin, neutralcolor, radcolor, direcolor)
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
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedSummaryBar Is Nothing Then
        Return mSelectedSummaryBar.GraphPreferences

      End If
      Return Nothing
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
