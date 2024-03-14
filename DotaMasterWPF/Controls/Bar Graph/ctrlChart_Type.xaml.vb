Public Class ctrlChart_Type
  Event ChartTypeChanged(sender As Object, e As MouseEventArgs)

  Private mSelectedChartType As Label

  Private dbColors As Colors_Database
  Private notselected As SolidColorBrush
  Private selected As SolidColorBrush

  Public Sub New(colorsdb As Colors_Database, defaultchartttype As eChartType, _
                 headingtextbrush As SolidColorBrush, bodytextcolor As SolidColorBrush)

    ' This call is required by the designer.
    InitializeComponent()


    dbColors = colorsdb
    notselected = New SolidColorBrush(dbColors.ButtonColorNotSelected)
    selected = New SolidColorBrush(dbColors.ButtonColorSelected)

    lblSplitGraph.Foreground = headingtextbrush
    AddHandler lblSplitGraph.MouseLeftButtonDown, AddressOf ChartType_LeftMouseButtonDown

    lblStackedGraph.Foreground = headingtextbrush
    AddHandler lblStackedGraph.MouseLeftButtonDown, AddressOf ChartType_LeftMouseButtonDown

    lblAdvantageGraph.Foreground = headingtextbrush
    AddHandler lblAdvantageGraph.MouseLeftButtonDown, AddressOf ChartType_LeftMouseButtonDown

    lblTitle.Foreground = bodytextcolor

    Select Case defaultchartttype
      Case eChartType.Split
        lblSplitGraph.Background = selected
        mSelectedChartType = lblSplitGraph
      Case eChartType.Stacked
        lblStackedGraph.Background = selected
        mSelectedChartType = lblStackedGraph
      Case eChartType.Advantage
        lblAdvantageGraph.Background = selected
        mSelectedChartType = lblAdvantageGraph
    End Select

  End Sub

  Private Sub ChartType_LeftMouseButtonDown(sender As Object, e As MouseButtonEventArgs)
    Dim newselectedcharttype As Label = sender

    If newselectedcharttype Is mSelectedChartType Then Exit Sub

    mSelectedChartType = newselectedcharttype
    lblStackedGraph.Background = notselected
    lblSplitGraph.Background = notselected
    lblAdvantageGraph.Background = notselected

    Select Case newselectedcharttype.Content
      Case " Stacked "
        lblStackedGraph.Background = selected


      Case " Split "
        lblSplitGraph.Background = selected

      Case " Advantage "
        lblAdvantageGraph.Background = selected
    End Select

    RaiseEvent ChartTypeChanged(sender, e)
  End Sub

  Public Sub SetChartType(charttype As eChartType)
    lblAdvantageGraph.Background = notselected
    lblSplitGraph.Background = notselected
    lblStackedGraph.Background = notselected

    Select Case charttype
      Case eChartType.Advantage
        lblAdvantageGraph.Background = selected
      Case eChartType.Split
        lblSplitGraph.Background = selected
      Case eChartType.Stacked
        lblStackedGraph.Background = selected
      Case Else
        Throw New NotImplementedException
    End Select
  End Sub
End Class
