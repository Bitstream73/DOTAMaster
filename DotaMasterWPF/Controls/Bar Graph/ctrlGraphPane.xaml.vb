Imports DotaMasterWPF.PageHandler
Public Class ctrlGraphPane
  Implements iControlIO


  'for mousemove updates
  Private mPrevPos = New Point(0, 0)
  Private mHoveredBar As ctrlBar

  Private mBarDataList As BarDataList

  Private direBackColor = New SolidColorBrush(Color.FromArgb(255, 84, 36, 36))
  Private radBackColor = New SolidColorBrush(Color.FromArgb(255, 45, 66, 35))

  Private mBars As New List(Of ctrlBar)
  Private mColumns As New List(Of ColumnDefinition)
  Private mMaxheight As Double
  Private mMaxTeamheight As Double

  Private mDataItems As List(Of List(Of iDataItem))

  Private onestargridlength As New GridLength(1, GridUnitType.Star)

  Private mMouseButtonDown As Boolean = False

  Private mSelectedBarType As eBarType

  Private mSelectedPaneType As ePanetype

  Private mSelectedBarIndex As Integer = 0 'index for mbars

  Private mHighestHeight As Double
  Private mHighestTeamHeight As Double

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Event SelectedBarIndexChanged(thebarindex As Integer, rectselectedhighlightrect As Rectangle) ', graph As ctrlGraphPane)

  Public Event DireCoordinatesUpdated(thex As Double, they As Double)
  Public Event RadiantCoordinatesUpdated(thex As Double, they As Double)
  Public Event CoordinatesUpdated(thex As Double, they As Double)


  Private weakcol = New SolidColorBrush(PageHandler.dbColors.ScaleWeakColor)
  Private weakfill = New SolidColorBrush(PageHandler.dbColors.ScaleWeakFill)
  Private strongfill = New SolidColorBrush(PageHandler.dbColors.ScaleStrongFill)

  Private testframe As New ddFrame(0)

  Private mRadBrush As SolidColorBrush
  Private mRadAcctBrush As SolidColorBrush
  Private mDireBrush As SolidColorBrush
  Private mDireAcctBrush As SolidColorBrush

  Private mGraphDividerBrush As SolidColorBrush
  Private mSelectedBrush As SolidColorBrush
  'items under mouse
  Private hitResultsList As New List(Of DependencyObject)
  Public Sub New(barcount As Integer, selectedbartype As eBarType, panetype As ePanetype, _
                 selectedbrush As SolidColorBrush, graphdividerbrush As SolidColorBrush, _
                 radcolor As SolidColorBrush, radaccent As SolidColorBrush, _
                 direcolor As SolidColorBrush, direaccent As SolidColorBrush)

    InitializeComponent()

    mSelectedBarType = selectedbartype
    mSelectedPaneType = panetype
    mGraphDividerBrush = graphdividerbrush
    mSelectedBrush = selectedbrush

    mRadBrush = radcolor
    mRadAcctBrush = radaccent
    mDireBrush = direcolor
    mDireAcctBrush = direaccent

    For i = 0 To barcount - 1
      AddBarToGraph(CreateBar())
    Next

    'change back
    SetSelectedBarType(selectedbartype)



    rectDireBackColor.Fill = direBackColor
    rectRadBackColor.Fill = radBackColor

    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    AddHandler Me.MouseLeftButtonUp, AddressOf Me_MouseLeftButtonUp
    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter

    AddHandler Me.MouseLeave, AddressOf Me_MouseLeave
    AddHandler Me.MouseMove, AddressOf MeMouseMove
    ' AddHandler Me.SizeChanged, AddressOf Me_SizeChanged

    AddHandler Me.rectHCross.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    AddHandler Me.rectVCross.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
  End Sub

  Private Sub SetUI()

    rectAdvantageDivider2.Fill = mGraphDividerBrush



    rectGrid0.Fill = weakfill
    lineGrid0.Fill = weakcol

    rectGrid1.Fill = strongfill
    lineGrid1.Fill = weakcol

    rectGrid2.Fill = weakfill
    lineGrid2.Fill = weakcol

    rectGrid3.Fill = strongfill
    lineGrid3.Fill = weakcol

    Select Case mSelectedPaneType
      Case ePanetype.TeamsStacked

        rectDireBackColor.Visibility = Windows.Visibility.Collapsed
        rectRadBackColor.Visibility = Windows.Visibility.Collapsed
        rectAdvantageDivider2.Visibility = Windows.Visibility.Collapsed

        rectGrid4.Fill = weakfill
        lineGrid4.Fill = weakcol
        lineGrid4.VerticalAlignment = Windows.VerticalAlignment.Top

        rectGrid5.Fill = strongfill
        lineGrid5.Fill = weakcol
        lineGrid5.VerticalAlignment = Windows.VerticalAlignment.Top


        rectGrid6.Fill = weakfill
        lineGrid6.Fill = weakcol
        lineGrid6.VerticalAlignment = Windows.VerticalAlignment.Top


        rectGrid7.Fill = strongfill
        lineGrid7.Fill = weakcol
        lineGrid7.VerticalAlignment = Windows.VerticalAlignment.Top

        lineGrid8.Fill = weakcol
      Case ePanetype.DireTeamStacked


        rectGrid4.Visibility = Windows.Visibility.Collapsed
        lineGrid4.Visibility = Windows.Visibility.Collapsed

        rectGrid5.Visibility = Windows.Visibility.Collapsed
        lineGrid5.Visibility = Windows.Visibility.Collapsed

        rectGrid6.Visibility = Windows.Visibility.Collapsed
        lineGrid6.Visibility = Windows.Visibility.Collapsed

        rectGrid7.Visibility = Windows.Visibility.Collapsed
        lineGrid7.Visibility = Windows.Visibility.Collapsed

        lineGrid8.Visibility = Windows.Visibility.Collapsed

        row4.Height = New GridLength(0)
        row5.Height = New GridLength(0)
        row6.Height = New GridLength(0)
        row7.Height = New GridLength(0)


        rectDireBackColor.Visibility = Windows.Visibility.Collapsed
        rectRadBackColor.Visibility = Windows.Visibility.Collapsed
        'rectDireBackColor.Visibility = Windows.Visibility.Visible
        'rectDireBackColor.SetValue(Grid.RowProperty, 0)
        'rectDireBackColor.SetValue(Grid.RowSpanProperty, 8)

        rectRadBackColor.Visibility = Windows.Visibility.Collapsed

        rectAdvantageDivider2.Visibility = Windows.Visibility.Collapsed

      Case ePanetype.RadiantTeamStacked


        rectGrid4.Visibility = Windows.Visibility.Collapsed
        lineGrid4.Visibility = Windows.Visibility.Collapsed

        rectGrid5.Visibility = Windows.Visibility.Collapsed
        lineGrid5.Visibility = Windows.Visibility.Collapsed

        rectGrid6.Visibility = Windows.Visibility.Collapsed
        lineGrid6.Visibility = Windows.Visibility.Collapsed

        rectGrid7.Visibility = Windows.Visibility.Collapsed
        lineGrid7.Visibility = Windows.Visibility.Collapsed

        lineGrid8.Visibility = Windows.Visibility.Collapsed

        row4.Height = New GridLength(0)
        row5.Height = New GridLength(0)
        row6.Height = New GridLength(0)
        row7.Height = New GridLength(0)

        rectDireBackColor.Visibility = Windows.Visibility.Collapsed
        rectRadBackColor.Visibility = Windows.Visibility.Collapsed
        'rectDireBackColor.Visibility = Windows.Visibility.Collapsed
        'rectRadBackColor.Visibility = Windows.Visibility.Visible
        'rectRadBackColor.SetValue(Grid.RowProperty, 0)
        'rectRadBackColor.SetValue(Grid.RowSpanProperty, 8)

        rectAdvantageDivider2.Visibility = Windows.Visibility.Collapsed

      Case ePanetype.Advantage

        rectDireBackColor.Visibility = Windows.Visibility.Collapsed
        rectRadBackColor.Visibility = Windows.Visibility.Collapsed



        rectGrid4.Fill = weakfill
        lineGrid4.Fill = weakcol
        lineGrid4.VerticalAlignment = Windows.VerticalAlignment.Top

        rectGrid5.Fill = strongfill
        lineGrid5.Fill = weakcol
        lineGrid5.VerticalAlignment = Windows.VerticalAlignment.Top


        rectGrid6.Fill = weakfill
        lineGrid6.Fill = weakcol
        lineGrid6.VerticalAlignment = Windows.VerticalAlignment.Top


        rectGrid7.Fill = strongfill
        lineGrid7.Fill = weakcol
        lineGrid7.VerticalAlignment = Windows.VerticalAlignment.Top

        lineGrid8.Fill = weakcol

        rectAdvantageDivider2.Visibility = Windows.Visibility.Visible

    End Select
  End Sub

  Public ReadOnly Property SelectedPaneType As ePanetype
    Get
      Return mSelectedPaneType
    End Get
  End Property


  Public ReadOnly Property SelectedBarType As eBarType
    Get
      Return mSelectedBarType
    End Get
  End Property


  Public Sub ShowCrosshair(visibility As System.Windows.Visibility)

    rectHCross.Visibility = visibility
    rectVCross.Visibility = visibility
  End Sub
  Private Sub AddBarToGraph(thebar As ctrlBar)
    thebar.SnapsToDevicePixels = True
    AddHandler thebar.SelectedBarChanged, AddressOf ctrlBar_SelectedBarChanged



    Dim newcol As New ColumnDefinition
    newcol.Width = onestargridlength

    Layoutroot.ColumnDefinitions.Add(newcol)
    mColumns.Add(newcol)



    thebar.SetValue(Grid.ColumnProperty, Layoutroot.ColumnDefinitions.Count - 1)

    thebar.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
    thebar.VerticalAlignment = Windows.VerticalAlignment.Stretch
    Layoutroot.Children.Add(thebar)
    mBars.Add(thebar)


  End Sub

  Private Function CreateBar() As ctrlBar

    Dim newbar As New ctrlBar(mSelectedPaneType, mGraphDividerBrush, mRadBrush, mRadAcctBrush, mDireBrush, mDireAcctBrush, mSelectedBrush)

    newbar.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
    newbar.VerticalAlignment = Windows.VerticalAlignment.Stretch

    AddHandler newbar.MouseEnter, AddressOf ctrlBar_MouseEnter


    Return newbar
  End Function


  ''' <summary>
  ''' Pass Nothing value to use existing parameter
  ''' </summary>

  Public Sub FillPane(selectedbarindex As Integer, _
                      selectedbartype As eBarType, _
                      thebardatalist As BarDataList, _
                      maxteamheight As Double, _
                      maxheight As Double, _
                      dataitems As List(Of List(Of iDataItem)))

    Layoutroot.Visibility = Windows.Visibility.Hidden
    mBarDataList = thebardatalist
    mSelectedBarType = selectedbartype
    SetSelectedBarType(mSelectedBarType)

    mBars.Item(mSelectedBarIndex).SetSelected(False)
    mSelectedBarIndex = selectedbarindex
    'mBars.Item(mSelectedBarIndex).SetSelected(True)

    mDataItems = dataitems
    mMaxheight = maxheight
    mMaxTeamheight = maxteamheight

    For i = 0 To mBars.Count - 1
      If i = 200 Then
        Dim x = 2
      End If
      mBars.Item(i).FillBar(mBarDataList.Item(i), mMaxTeamheight, maxheight, mDataItems)
      mBars.Item(i).SetFillerHeight()
    Next

    SetUI()
    Layoutroot.Visibility = Windows.Visibility.Visible
  End Sub



  Public Sub SetSelectedBar(thebarindex As Integer, rectselectedhighlightmargin As Thickness)
    'If thebarindex = mSelectedBarIndex Then Exit Sub


    Dim selectedbar = mBars.Item(mSelectedBarIndex)

    selectedbar.SetSelected(False)

    mSelectedBarIndex = thebarindex
    selectedbar = mBars.Item(mSelectedBarIndex)
    selectedbar.SetSelected(True)

    rectSelectedHighlight.Visibility = Windows.Visibility.Visible
    rectSelectedHighlight.Margin = rectselectedhighlightmargin
  End Sub

  Public Sub SetSelectedBarType(bartype As eBarType)
    ' If mSelectedBarType = bartype Then Exit Sub
    Dim display = Windows.Visibility.Visible
    If Layoutroot.Visibility = Windows.Visibility.Hidden Then
      display = Windows.Visibility.Hidden
    End If
    Layoutroot.Visibility = Windows.Visibility.Hidden
    Select Case bartype
      Case eBarType.Parent
        For i As Integer = 0 To mBars.Count - 1
          mBars.Item(i).SetBarType(eBarType.Parent)
        Next
      Case eBarType.Source
        For i As Integer = 0 To mBars.Count - 1
          mBars.Item(i).SetBarType(eBarType.Source)
        Next

      Case eBarType.Value
        For i As Integer = 0 To mBars.Count - 1
          mBars.Item(i).SetBarType(eBarType.Value)
        Next

      Case eBarType.Team
        For i As Integer = 0 To mBars.Count - 1
          mBars.Item(i).SetBarType(eBarType.Team)
        Next

      Case Else
        Throw New NotImplementedException
    End Select

    mSelectedBarType = bartype

    Layoutroot.Visibility = display

  End Sub


  Private Sub ctrlBar_SelectedBarChanged(thebar As ctrlBar)

    'Dim sbar As ctrlBar = theobj.obj
    Dim index = mBars.IndexOf(thebar)
    If Not index = mSelectedBarIndex Then
      Dim oldbar = mBars.Item(mSelectedBarIndex)
      oldbar.SetSelected(False)
      mSelectedBarIndex = index
      SetSelectedBar(mSelectedBarIndex, rectVCross.Margin)


      RaiseEvent SelectedBarIndexChanged(mSelectedBarIndex, rectVCross) ', Me)

    End If
  End Sub

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return False
    End Get
  End Property

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected

  End Sub


  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)



    e.Handled = True
    mMouseButtonDown = True
    Dim pos = e.GetPosition(Nothing)

    Dim ctrl = GetControlUnderMousePointer(GetType(ctrlBar), e)

    'CHANGED IN WPF
    If Not TryCast(ctrl, ctrlBar) Is Nothing Then
      Dim bar As ctrlBar = ctrl

      Dim index = mBars.IndexOf(bar)
      SetSelectedBar(index, rectVCross.Margin)



      RaiseEvent SelectedBarIndexChanged(index, rectVCross) ', Me)

    End If
  End Sub

  Private Function GetControlUnderMousePointer(thetype As System.Type, e As MouseEventArgs) As Object

    Dim pt As Point = e.GetPosition(Me)
    ' Clear the contents of the list used for hit test results.
    hitResultsList.Clear()

    ' Set up a callback to receive the hit test result enumeration.
    VisualTreeHelper.HitTest(Me, Nothing, New HitTestResultCallback(AddressOf MyHitTestResult), New PointHitTestParameters(pt))

    Dim t As Type
    Dim thectrl As DependencyObject
    For i As Integer = 0 To hitResultsList.Count - 1
      thectrl = DirectCast(hitResultsList.Item(i), DependencyObject)
      t = thectrl.GetType
      While Not thetype = t
        thectrl = VisualTreeHelper.GetParent(thectrl)
        If thectrl Is Nothing Then Exit While
        t = thectrl.GetType
      End While
      If t = thetype Then
        Return thectrl
      End If

    Next

    Return thectrl
  End Function

  Public Function MyHitTestResult(result As HitTestResult) As HitTestResultBehavior
    ' Add the hit test result to the list that will be processed after the enumeration.
    hitResultsList.Add(result.VisualHit)

    ' Set the behavior to return visuals at all z-order levels.
    Return HitTestResultBehavior.Continue
  End Function
  Private Sub MeMouseMove(sender As Object, e As MouseEventArgs)

    If mMouseButtonDown Then
      Dim pos2 = e.GetPosition(Nothing)
      'Dim ctrls = VisualTreeHelper.FindElementsInHostCoordinates(pos2, LayoutRoot)
      Dim ctrl = Mouse.DirectlyOver

      'CHANGED IN WPF
      If Not TryCast(ctrl, ctrlBar) Is Nothing Then
        Dim bar As ctrlBar = ctrl
        Dim index = mBars.IndexOf(bar)
        If index = mSelectedBarIndex Then
          SetSelectedBar(index, rectVCross.Margin)
          RaiseEvent SelectedBarIndexChanged(index, rectVCross) ', Me)
        End If
      End If
    End If
    Dim pos = e.GetPosition(Me)
    If pos = mPrevPos Then Exit Sub

    mPrevPos = pos



    SetCrosshairPos(pos.X, pos.Y)

    Select Case mSelectedPaneType
      Case ePanetype.DireTeamStacked

        RaiseEvent DireCoordinatesUpdated(pos.X, pos.Y) ', testframe) 'thebar.BarsTime)
      Case ePanetype.RadiantTeamStacked

        RaiseEvent RadiantCoordinatesUpdated(pos.X, pos.Y) ', testframe) 'thebar.BarsTime)
      Case Else
        'If Not mHoveredBar Is Nothing Then
        RaiseEvent CoordinatesUpdated(pos.X, pos.Y) ', testframe) ' thebar.BarsTime)
        'End If

    End Select


  End Sub

  Private Sub Me_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
    mMouseButtonDown = False
  End Sub



  Private Sub ctrlBar_MouseEnter(sender As Object, e As MouseEventArgs)
    '  If mHoveredBar Is sender Then Exit Sub
    mHoveredBar = sender
    If mMouseButtonDown Then
      mHoveredBar.SetSelected(True)
    End If
  End Sub

  Private Sub dpnl_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    'Dim dpnl As DockPanel = sender
    'Dim clst As New List(Of Object)
    'For i As Integer = 0 To dpnl.Children.Count - 1
    '  clst.Add(dpnl.Children.Item(i))
    'Next

    'Dim x = 2
  End Sub

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)

    'rectHCross.Visibility = Windows.Visibility.Visible
    'rectVCross.Visibility = Windows.Visibility.Visible
    ShowCrosshair(System.Windows.Visibility.Visible)
  End Sub
  Private Sub Me_MouseLeave(sender As Object, e As MouseEventArgs)
    mMouseButtonDown = False
    'rectHCross.Visibility = Windows.Visibility.Collapsed
    'rectVCross.Visibility = Windows.Visibility.Collapsed
    ShowCrosshair(System.Windows.Visibility.Collapsed)

    Select Case mSelectedPaneType
      Case ePanetype.DireTeamStacked

        RaiseEvent DireCoordinatesUpdated(-1, -1) ', mGame.mTimeKeeper.CurrentTime)
      Case ePanetype.RadiantTeamStacked

        RaiseEvent RadiantCoordinatesUpdated(-1, -1) ', mGame.mTimeKeeper.CurrentTime)
      Case Else

        RaiseEvent CoordinatesUpdated(-1, -1) ', mGame.mTimeKeeper.CurrentTime)

    End Select

  End Sub

  Public Sub SetCrosshairPos(thex As Double, they As Double)

    ShowCrosshair(System.Windows.Visibility.Visible)


    Dim bmarg = Me.ActualHeight - they - rectHCross.ActualHeight
    rectHCross.Margin = New Thickness(0, they, 0, bmarg)

    Dim rmarg = Me.ActualWidth - thex - rectVCross.ActualWidth
    rectVCross.Margin = New Thickness(thex, 0, rmarg, 0)


  End Sub

  Public Sub SetCrosshairPosInverted(thex As Double, they As Double)
    rectHCross.Visibility = Windows.Visibility.Visible
    rectVCross.Visibility = Windows.Visibility.Visible


    'rectHCross.Margin = New Thickness(0, pos.Y, 0, 0)
    'Dim bmarg = Me.ActualHeight - they - rectHCross.Height
    Dim bmarg = Me.ActualHeight - they - rectHCross.ActualHeight
    rectHCross.Margin = New Thickness(0, bmarg, 0, they)
    ' rectVCross.Margin = New Thickness(pos.X, 0, 0, 0)
    'Dim rmarg = Me.ActualWidth - thex - rectVCross.Width
    Dim rmarg = Me.ActualWidth - thex - rectVCross.ActualWidth
    rectVCross.Margin = New Thickness(thex, 0, rmarg, 0)


  End Sub


  'Private Sub Me_SizeChanged(sender As Object, e As SizeChangedEventArgs)
  '  mMyActualHeight = Me.ActualHeight
  '  mMyActualWidth = Me.ActualWidth
  'End Sub
End Class
