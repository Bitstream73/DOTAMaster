Imports DotaMasterWPF.PageHandler

#Const Devmode = False
Public Class ctrlBargraph_Panes_Fixedwidth
  Implements iControlIO



  Private mIsLoading As Boolean = False


  Private zerowidth = New GridLength(0)

  Private mBarDataList As BarDataList
  Private mMmaxteamheight As Double
  Private mMaxheight As Double
  Private mDataItems As List(Of List(Of iDataItem))


  Private mBarTimes As List(Of String) 'friendly times for each bar
  'Graph Scales Stuff
  Private hScaleHeight As Double = 50
  Private vScaleWidth As Double

  Private mStackedFilled As Boolean
  Private mSplitFilled As Boolean
  Private mAdvantageFilled As Boolean

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty
  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Event NewGraphItemSelected(theytpe As eModifierType)
  'Public Event ModTypeChanged( gameentity as igameentity)

  Public Event TimeChanged(theindex As Integer)

  Private mSliderLoaded As Boolean = False

  Private mDireGraphpane As ctrlGraphPane
  Private mRadiantGraphpane As ctrlGraphPane
  Private mStackedGraphpane As ctrlGraphPane
  Private mAdvantageGraphpane As ctrlGraphPane

  Private mSelectedGraphType As eGraphType
  Private mSelectedBarType As eBarType


  Private mSelectedHighlightMargin As Thickness 'for highlighted currenttime vertical bar on chart
  Private mSelectedIndex As Integer

  Private mRadBrush As SolidColorBrush
  Private mRadAcctBrush As SolidColorBrush
  Private mDireBrush As SolidColorBrush
  Private mDireAcctBrush As SolidColorBrush

  Private mSelectedBrush As SolidColorBrush
  Private mGraphDividerBrush As SolidColorBrush
  Private mOneStar As New GridLength(1, GridUnitType.Star)
  Private mZeroHeight As New GridLength(0)
  Private mOneHeight As New GridLength(1)

  Private mCtrlBar_Type As ctrlBar_Type
  Private mCtrlChart_Type As ctrlChart_Type

  'scale stuff
  Private mHScale As ctrlHScale
  Private mDireVScale As ctrlVScale
  Private mRadiantVScale As ctrlVScale
  Private mBothTeamsVscale As ctrlVScale
  Private mAdvantageVScale As ctrlVScale

  Private notselected = New SolidColorBrush(dbColors.ButtonColorNotSelected)
  Private selected = New SolidColorBrush(dbColors.ButtonColorSelected)
  Public Sub New(barcount As Integer, bartimes As List(Of String), bartype As eBarType, graphtype As eGraphType, _
                 graphdividercolor As Color, selectedbarcolor As Color, _
                 radcolor As Color, radaccent As Color, _
                 direcolor As Color, direaccent As Color, _
                 ctrlbartype As ctrlBar_Type, ctrlcharttype As ctrlChart_Type) ' graphheight As Double)


    InitializeComponent()

    mRadBrush = New SolidColorBrush(radcolor)
    If mRadBrush.CanFreeze Then
      mRadBrush.Freeze()
    End If
    mRadAcctBrush = New SolidColorBrush(radaccent)
    If mRadAcctBrush.CanFreeze Then
      mRadAcctBrush.Freeze()
    End If

    mDireBrush = New SolidColorBrush(direcolor)
    If mDireBrush.CanFreeze Then
      mDireBrush.Freeze()
    End If
    mDireAcctBrush = New SolidColorBrush(direaccent)
    If mDireAcctBrush.CanFreeze Then
      mDireAcctBrush.Freeze()
    End If

    mSelectedBrush = New SolidColorBrush(selectedbarcolor)
    If mSelectedBrush.CanFreeze Then
      mSelectedBrush.Freeze()
    End If

    mGraphDividerBrush = New SolidColorBrush(graphdividercolor)
    If mGraphDividerBrush.CanFreeze Then
      mGraphDividerBrush.Freeze()
    End If

    mBarTimes = bartimes


    Me.Height = Double.NaN
    Me.Width = Double.NaN
    AddHandler Me.SizeChanged, AddressOf Me_SizeChanged


    mCtrlBar_Type = ctrlbartype
    AddHandler mCtrlBar_Type.BarTypeChanged, AddressOf BarType_LeftMouseButtonDown
    'AddHandler lblValChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown
    'AddHandler lblOwnerChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown
    'AddHandler lblSourceChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown
    'AddHandler lblTeamChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown

    mCtrlChart_Type = ctrlcharttype
    AddHandler mCtrlChart_Type.ChartTypeChanged, AddressOf ChartType_LeftMouseButtonDown
    'AddHandler lblSplitGraph.MouseLeftButtonDown, AddressOf ChartType_LeftMouseButtonDown
    'AddHandler lblStackedGraph.MouseLeftButtonDown, AddressOf ChartType_LeftMouseButtonDown
    'AddHandler lblAdvantageGraph.MouseLeftButtonDown, AddressOf ChartType_LeftMouseButtonDown


    ' AddHandler cmbScopeSelect.SelectionChanged, AddressOf cmbScopeSelect_SelectionChanged
    ' AddHandler cmbHeroSelect.SelectionChanged, AddressOf cmbHeroSelect_SelectionChanged
    '  AddHandler cmbModifierSelect.SelectionChanged, AddressOf cmbModifierSelect_SelectionChanged



    mDireGraphpane = New ctrlGraphPane(barcount, bartype, ePanetype.DireTeamStacked, mSelectedBrush, mGraphDividerBrush, mRadBrush, mRadAcctBrush, mDireBrush, mDireAcctBrush)
    AddHandler mDireGraphpane.SelectedBarIndexChanged, AddressOf ctrlGraphPane_SelectedChanged
    AddHandler mDireGraphpane.DireCoordinatesUpdated, AddressOf mDireGraphpane_DireCoordinatesUpdated
    AddHandler mDireGraphpane.MouseLeave, AddressOf ctrlGraphPane_MouseLeave
    mDireGraphpane.SetValue(DockPanel.DockProperty, Dock.Top)
    rootChart1.Children.Add(mDireGraphpane)

    mRadiantGraphpane = New ctrlGraphPane(barcount, bartype, ePanetype.RadiantTeamStacked, mSelectedBrush, mGraphDividerBrush, mRadBrush, mRadAcctBrush, mDireBrush, mDireAcctBrush)
    AddHandler mRadiantGraphpane.SelectedBarIndexChanged, AddressOf ctrlGraphPane_SelectedChanged
    AddHandler mRadiantGraphpane.RadiantCoordinatesUpdated, AddressOf mRadiantGraphpane_RadiantCoordinatesUpdated
    AddHandler mRadiantGraphpane.MouseLeave, AddressOf ctrlGraphPane_MouseLeave
    mRadiantGraphpane.SetValue(DockPanel.DockProperty, Dock.Top)
    rootChart2.Children.Add(mRadiantGraphpane)

    mStackedGraphpane = New ctrlGraphPane(barcount, bartype, ePanetype.TeamsStacked, mSelectedBrush, mGraphDividerBrush, mRadBrush, mRadAcctBrush, mDireBrush, mDireAcctBrush)
    AddHandler mStackedGraphpane.SelectedBarIndexChanged, AddressOf ctrlGraphPane_SelectedChanged
    AddHandler mStackedGraphpane.CoordinatesUpdated, AddressOf mStackedGraphpane_CoordinatesUpdated
    AddHandler mStackedGraphpane.MouseLeave, AddressOf ctrlGraphPane_MouseLeave
    mStackedGraphpane.SetValue(DockPanel.DockProperty, Dock.Top)
    rootChart3.Children.Add(mStackedGraphpane)

    mAdvantageGraphpane = New ctrlGraphPane(barcount, bartype, ePanetype.Advantage, mSelectedBrush, mGraphDividerBrush, mRadBrush, mRadAcctBrush, mDireBrush, mDireAcctBrush)
    AddHandler mAdvantageGraphpane.SelectedBarIndexChanged, AddressOf ctrlGraphPane_SelectedChanged
    AddHandler mAdvantageGraphpane.CoordinatesUpdated, AddressOf mAdvantageGraphpane_CoordinatesUpdated
    AddHandler mAdvantageGraphpane.MouseLeave, AddressOf ctrlGraphPane_MouseLeave
    mAdvantageGraphpane.SetValue(DockPanel.DockProperty, Dock.Top)
    rootChart4.Children.Add(mAdvantageGraphpane)





    SetVScales(1, 0, 1, 0, 1, 0)

    SetSelectedBarType(bartype)

    SetSelectedGraphType(graphtype)





    SetUI()


  End Sub




#Region "Props"

  Public ReadOnly Property SelectedBarIndex As Integer
    Get
      Return mSelectedIndex
    End Get
  End Property
  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return False
    End Get
  End Property


#End Region



#Region "Setters"
 
  Public Sub SetSelectedBar(barsindex As Integer, rectselectedhighlightmargin As Thickness)

    mDireGraphpane.SetSelectedBar(barsindex, rectselectedhighlightmargin)
    mRadiantGraphpane.SetSelectedBar(barsindex, rectselectedhighlightmargin)

    mStackedGraphpane.SetSelectedBar(barsindex, rectselectedhighlightmargin)

    mAdvantageGraphpane.SetSelectedBar(barsindex, rectselectedhighlightmargin)


  End Sub
  Public Sub SetSelectedBarType(bartype As eBarType)
    If bartype = mSelectedBarType Then
      Dim x = 2
      Exit Sub
    End If


    mSelectedBarType = bartype

    mDireGraphpane.SetSelectedBarType(bartype)
    mRadiantGraphpane.SetSelectedBarType(bartype)
    mStackedGraphpane.SetSelectedBarType(bartype)
    mAdvantageGraphpane.SetSelectedBarType(bartype)
  End Sub

  Public Sub SetSelectedGraphType(thegraphtype As eGraphType)

    mSelectedGraphType = thegraphtype

  End Sub

#End Region


#Region "UI stuff"




  Private Sub SetUI()

    ' spnlDevStuff.Visibility = Windows.Visibility.Collapsed
    Dim graphdivcolor = New SolidColorBrush(dbColors.GraphDividerColor)
    rectChartDivider.Fill = graphdivcolor
    rectVscaleDivider.Fill = graphdivcolor

    '  rowHscale.Height = New GridLength(hScaleHeight, GridUnitType.Pixel)

    Select Case mSelectedGraphType
      Case eGraphType.TeamsStacked


        '   spnlChartTitle.Visibility = Windows.Visibility.Visible
        '  spnlChartDataSettings.Visibility = Windows.Visibility.Visible


        mDireGraphpane.Visibility = Windows.Visibility.Collapsed
        rowChart1.Height = New GridLength(0)

        rectChartDivider.Visibility = Windows.Visibility.Collapsed

        mRadiantGraphpane.Visibility = Windows.Visibility.Collapsed
        rowChart2.Height = New GridLength(0)

        mStackedGraphpane.Visibility = Windows.Visibility.Visible
        rowchart3.Height = New GridLength(1, GridUnitType.Star)

        mAdvantageGraphpane.Visibility = Windows.Visibility.Collapsed
        rowchart4.Height = New GridLength(0)

        ' mBothTeamsGraphpane.SetSelectedPaneType(ePanetype.TeamsStacked)

        rowCh1Vscale.Height = mZeroHeight
        mRadiantVScale.Visibility = Windows.Visibility.Collapsed

        rowVscaleDivider.Height = mZeroHeight
        rectVscaleDivider.Visibility = Windows.Visibility.Collapsed

        rowCh2Vscale.Height = mZeroHeight
        mDireVScale.Visibility = Windows.Visibility.Collapsed

        rowCh3Vscale.Height = mOneStar
        mBothTeamsVscale.Visibility = Windows.Visibility.Visible
        mAdvantageVScale.Visibility = Windows.Visibility.Collapsed

   
      Case eGraphType.Advantage


        '.Visibility = Windows.Visibility.Visible
        '  spnlChartDataSettings.Visibility = Windows.Visibility.Visible


        mDireGraphpane.Visibility = Windows.Visibility.Collapsed
        rowChart1.Height = New GridLength(0)

        rectChartDivider.Visibility = Windows.Visibility.Collapsed

        mRadiantGraphpane.Visibility = Windows.Visibility.Collapsed
        rowChart2.Height = New GridLength(0)

        mStackedGraphpane.Visibility = Windows.Visibility.Collapsed
        rowchart3.Height = New GridLength(0)

        mAdvantageGraphpane.Visibility = Windows.Visibility.Visible
        rowchart4.Height = New GridLength(1, GridUnitType.Star)


        '  mBothTeamsGraphpane.SetSelectedPaneType(ePanetype.Advantage)

        rowCh1Vscale.Height = mZeroHeight
        mRadiantVScale.Visibility = Windows.Visibility.Visible

        rowVscaleDivider.Height = mOneHeight
        rectVscaleDivider.Visibility = Windows.Visibility.Visible

        rowCh2Vscale.Height = mZeroHeight
        mDireVScale.Visibility = Windows.Visibility.Visible

        rowCh3Vscale.Height = mOneStar
        mBothTeamsVscale.Visibility = Windows.Visibility.Collapsed
        mAdvantageVScale.Visibility = Windows.Visibility.Visible
      Case eGraphType.VersusSplitBars

        ' spnlChartTitle.Visibility = Windows.Visibility.Visible
        '   spnlChartDataSettings.Visibility = Windows.Visibility.Visible


        mDireGraphpane.Visibility = Windows.Visibility.Visible
        rowChart1.Height = New GridLength(1, GridUnitType.Star)

        rectChartDivider.Visibility = Windows.Visibility.Visible

        mRadiantGraphpane.Visibility = Windows.Visibility.Visible
        rowChart2.Height = New GridLength(1, GridUnitType.Star)

        mStackedGraphpane.Visibility = Windows.Visibility.Collapsed
        rowchart3.Height = New GridLength(0)

        mAdvantageGraphpane.Visibility = Windows.Visibility.Collapsed
        rowchart4.Height = New GridLength(0)

        rowCh1Vscale.Height = mOneStar
        mRadiantVScale.Visibility = Windows.Visibility.Visible

        rowVscaleDivider.Height = mOneHeight
        rectVscaleDivider.Visibility = Windows.Visibility.Visible

        rowCh2Vscale.Height = mOneStar
        mDireVScale.Visibility = Windows.Visibility.Visible

        rowCh3Vscale.Height = mZeroHeight
        mBothTeamsVscale.Visibility = Windows.Visibility.Collapsed
        mAdvantageVScale.Visibility = Windows.Visibility.Collapsed

      Case Else
        Throw New NotImplementedException
    End Select

    mCtrlBar_Type.SetBarType(mSelectedBarType)
    Select Case mSelectedGraphType
      Case eGraphType.Advantage
        mCtrlChart_Type.SetChartType(eChartType.Advantage)
      Case eGraphType.TeamsStacked
        mCtrlChart_Type.SetChartType(eChartType.Stacked)
      Case eGraphType.VersusSplitBars
        mCtrlChart_Type.SetChartType(eChartType.Split)
    End Select


#If Devmode Then
    spnlDevStuff.Visibility = Windows.Visibility.Visible
#End If

  End Sub

  Private Sub SetHScale()
    mHScale = New ctrlHScale

    mHScale.Load(New SolidColorBrush(dbColors.HoveredColor), New SolidColorBrush(dbColors.SelectedColor), mBarTimes, 24, 12, 24, mBarTimes)
    mHScale.SelectedLblVisible(False)
    spnlHScale.Children.Clear()
    spnlHScale.Children.Add(mHScale)



  End Sub

  Private Sub SetVScales(maxdire As Double, mindire As Double, _
                          maxrad As Double, minrad As Double, _
                          maxstack As Double, minstack As Double)
    mDireVScale = New ctrlVScale(maxdire, mindire, 4, ePanetype.DireTeamStacked)
    rootChart1VScale.Children.Clear()
    rootChart1VScale.Children.Add(mDireVScale)


    mRadiantVScale = New ctrlVScale(maxrad, minrad, 4, ePanetype.RadiantTeamStacked)
    rootChart2Vscale.Children.Clear()
    rootChart2Vscale.Children.Add(mRadiantVScale)

    mBothTeamsVscale = New ctrlVScale(maxstack, minstack, 8, ePanetype.TeamsStacked)
    rootChart3Vscale.Children.Clear()
    rootChart3Vscale.Children.Add(mBothTeamsVscale)

    mAdvantageVScale = New ctrlVScale(1, 0, 4, ePanetype.Advantage)
    rootChart3Vscale.Children.Add(mAdvantageVScale)

  End Sub

#End Region



#Region "Event Handlers"



  Private Sub cmbScopeSelect_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    Throw New NotImplementedException
  End Sub
  Private Sub cmbHeroSelect_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    Throw New NotImplementedException
  End Sub



  Private Sub Me_SizeChanged(sender As Object, e As SizeChangedEventArgs)



  End Sub
#End Region


  Private Sub BarType_LeftMouseButtonDown(sender As Object, e As MouseButtonEventArgs)
    Me.Cursor = Cursors.Wait
    Dim thelabel As Label = sender
    Select Case thelabel.Content.ToString.Trim
      Case "Value"
        SetSelectedBarType(eBarType.Value)

      Case "Owner"
        SetSelectedBarType(eBarType.Parent)

      Case "Source"
        SetSelectedBarType(eBarType.Source)

      Case "Team"
        SetSelectedBarType(eBarType.Team)

      Case Else
        Dim x = 2
    End Select
    Me.Cursor = Nothing
  End Sub

  Private Sub ChartType_LeftMouseButtonDown(sender As Object, e As MouseButtonEventArgs)
    Me.Cursor = Cursors.Wait
    Dim thelabel As Label = sender


    Select Case thelabel.Content.ToString.Trim
      Case "Split"
        SetSelectedGraphType(eGraphType.VersusSplitBars)
      Case "Stacked"
        SetSelectedGraphType(eGraphType.TeamsStacked)
      Case "Advantage"
        SetSelectedGraphType(eGraphType.Advantage)
      Case Else
        Dim x = 2
    End Select
    FillVisibleGraph(mSelectedIndex, mSelectedBarType, mBarDataList, mMmaxteamheight, mMaxheight, mDataItems)
    SetUI()
    SetSelectedBar(mSelectedBarType, mSelectedHighlightMargin)
    Me.Cursor = Nothing
  End Sub

  Public Sub FillGraph(graphtitle As String, _
                       selectedbarindex As Integer, _
                      bartype As eBarType, _
                      graphtype As eGraphType, _
                      thebardatalist As BarDataList, _
                      maxteamheight As Double, _
                      maxheight As Double, _
                      dataitems As List(Of List(Of iDataItem)))

    lblTitle._Content = graphtitle

    mSelectedIndex = selectedbarindex
    SetSelectedBarType(bartype)
    SetSelectedGraphType(graphtype)
    mBarDataList = thebardatalist
    mMmaxteamheight = maxteamheight
    mMaxheight = maxheight
    mDataItems = dataitems

    mStackedFilled = False
    mAdvantageFilled = False
    mSplitFilled = False

    FillVisibleGraph(selectedbarindex, bartype, mBarDataList, mMmaxteamheight, mMaxheight, mDataItems)

    SetHScale()

    'TEMPORARILY DISABLED BECAUSE IT ACCOUNTED FOR 70% of LOAD TIME
    'SetVScales(mMmaxteamheight, 0, _
    '          mMmaxteamheight, 0, _
    '           mMaxheight, 0)
    SetUI()
  End Sub

  Public Sub UpdateTime(barindex As Integer)

    Throw New NotImplementedException
  End Sub


  Private Sub FillVisibleGraph(selectedbarindex As Integer, selectedbartype As eBarType, mBarDataList As BarDataList, mMmaxteamheight As Double, mMaxheight As Double, dataitems As List(Of List(Of iDataItem)))
    Me.Cursor = Cursors.Wait
    Select Case mSelectedGraphType
      Case eGraphType.Advantage
        If Not mAdvantageFilled Then
          mAdvantageGraphpane.FillPane(selectedbarindex, selectedbartype, mBarDataList, mMmaxteamheight, mMaxheight, dataitems)
          mAdvantageFilled = True
        End If

      Case eGraphType.TeamsStacked
        If Not mStackedFilled Then
          mStackedGraphpane.FillPane(selectedbarindex, selectedbartype, mBarDataList, mMmaxteamheight, mMaxheight, dataitems)
          mStackedFilled = True
        End If

      Case eGraphType.VersusSplitBars
        If Not mSplitFilled Then
          mDireGraphpane.FillPane(selectedbarindex, selectedbartype, mBarDataList, mMmaxteamheight, mMaxheight, dataitems)
          mRadiantGraphpane.FillPane(selectedbarindex, selectedbartype, mBarDataList, mMmaxteamheight, mMaxheight, dataitems)
          mSplitFilled = True
        End If
      Case Else
        Throw New NotImplementedException
    End Select
    Me.Cursor = Nothing
  End Sub

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected

  End Sub


  Private Sub ctrlGraphPane_SelectedChanged(thebarindex As Integer, rectselectedhighlightrectangle As Rectangle) ', theparentpane As ctrlGraphPane)


    If Not mIsLoading Then

      mIsLoading = True

      mSelectedHighlightMargin = rectselectedhighlightrectangle.Margin
      mSelectedIndex = thebarindex

      SetSelectedBar(mSelectedIndex, rectselectedhighlightrectangle.Margin)

      'UNCOMMENT
      mHScale.UpdateSelectedPosition(rectselectedhighlightrectangle)

      'RaiseEvent SelectedBarChanged(thebar, theparentpane)

      'Uncomment
      RaiseEvent TimeChanged(thebarindex)
      mIsLoading = False


    End If


  End Sub

  Public ReadOnly Property Bartype As eBarType
    Get
      Return mSelectedBarType
    End Get
  End Property

  Public ReadOnly Property Graphtype As eGraphType
    Get
      Return mSelectedGraphType
    End Get
  End Property

  Private Sub mDireGraphpane_DireCoordinatesUpdated(thex As Double, they As Double) ',  thetime As ddFrame)
    mRadiantGraphpane.SetCrosshairPosInverted(thex, they)
    mRadiantVScale.UpdateInvertedHoverPostion(they)

    If Not mHScale Is Nothing Then
      mHScale.UpdateHoverPosition(thex) ', thetime)
      mDireVScale.UpdateHoverPosition(they)
    Else
      Dim x = 2
    End If
  End Sub

  Private Sub mRadiantGraphpane_RadiantCoordinatesUpdated(thex As Double, they As Double) ',  thetime As ddFrame)
    mDireGraphpane.SetCrosshairPosInverted(thex, they)
    mDireVScale.UpdateInvertedHoverPostion(they)

    If Not mHScale Is Nothing Then
      mHScale.UpdateHoverPosition(thex) ', thetime)
      mRadiantVScale.UpdateHoverPosition(they)
    Else
      Dim x = 2
    End If
  End Sub

  Private Sub ctrlGraphPane_MouseLeave(sender As Object, e As MouseEventArgs)
    Dim thepane As ctrlGraphPane = sender
    If thepane.SelectedPaneType = ePanetype.DireTeamStacked Then
      mRadiantGraphpane.ShowCrosshair(Windows.Visibility.Collapsed)
    ElseIf thepane.SelectedPaneType = ePanetype.RadiantTeamStacked Then
      mDireGraphpane.ShowCrosshair(Windows.Visibility.Collapsed)
    End If
  End Sub

  Private Sub mAdvantageGraphpane_CoordinatesUpdated(thex As Double, they As Double) ',  thetime As ddFrame)

    If Not mHScale Is Nothing Then
      mHScale.UpdateHoverPosition(thex) ', thetime)
      mAdvantageVScale.UpdateHoverPosition(they)
    End If


  End Sub

  Private Sub mStackedGraphpane_CoordinatesUpdated(thex As Double, they As Double) ',  thetime As ddFrame)

    If Not mHScale Is Nothing Then
      mHScale.UpdateHoverPosition(thex) ', thetime)
      mBothTeamsVscale.UpdateHoverPosition(they)
    End If


  End Sub
End Class
