Imports DotaMasterWPF.PageHandler
Public Class ctrlBar
  Implements iControlIO

  Private mBarsTime As ddFrame
  Private mValues As List(Of List(Of Double))

  Private mValueColor As Color
  Private mTeamColors As List(Of Color)
  Private mParentColors As List(Of List(Of Color))
  Private mSourceColors As List(Of List(Of Color))

  Private mDataItems As List(Of List(Of iDataItem)) '0 Rad, 1 Dire

  Private mSelectedType As eBarType
  Private mPaneType As ePanetype
  Private mGraphDividerColor As Color

  Private RowAndRectPool As List(Of RowAndRect)
  Private UsedRowAndRectCount As Integer


  Private mRadiantParentRects As New List(Of Rectangle)
  Private mRadiantParentRows As New List(Of RowDefinition)
  Private mRadiantSourceRects As New List(Of Rectangle)
  Private mRadiantSourceRows As New List(Of RowDefinition)

  Private mDireParentRects As New List(Of Rectangle)
  Private mDireParentRows As New List(Of RowDefinition)
  Private mDireSourceRects As New List(Of Rectangle)
  Private mDireSourceRows As New List(Of RowDefinition)

  Private mMaxheight As Double = 0
  Private mMaxTeamHeight As Double = 0


  ' Private mValueTotalHeight As Double
  Private mRadTotalHeight As Double
  Private mDireTotalHeight As Double

  Private zerogridlength As New System.Windows.GridLength(0)
  Private onestargridlength As New System.Windows.GridLength(1, GridUnitType.Star)

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty
  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Event SelectedBarChanged(thebar As ctrlBar)


  '  Private mRadBrush As SolidColorBrush
  Private mRadAcctBrush As SolidColorBrush
  ' Private mDireBrush As SolidColorBrush
  Private mDireAcctBrush As SolidColorBrush

  Private mSelectedBrush As SolidColorBrush
  Private mGraphDividerBrush As SolidColorBrush
  Public mIsSelected As Boolean = False



  Public Sub New(panetype As ePanetype, _
                 graphdividercolor As SolidColorBrush, _
                 radbrush As SolidColorBrush, _
                 radaccent As SolidColorBrush, _
                 direbrush As SolidColorBrush, _
                 direaccent As SolidColorBrush, _
                 selectedbrush As SolidColorBrush)
    InitializeComponent()

    Me.Height = Double.NaN
    Me.Margin = New System.Windows.Thickness(0)

    RectRadColor.Fill = radbrush
    mRadAcctBrush = radaccent
    RectDireColor.Fill = direbrush
    mDireAcctBrush = direaccent

    SetPaneType(panetype)
    mGraphDividerBrush = graphdividercolor

    'rectSelected.Stroke = selectedbrush
    'rectSelected.Visibility = Windows.Visibility.Collapsed

    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    RowAndRectPool = New List(Of RowAndRect)


    rectDivider.Fill = graphdividercolor

  End Sub

  Public Sub FillBar(thebardata As BarData, _
                     maxteamheight As Double, _
                 maxheight As Double, _
                  barsdataitems As List(Of List(Of iDataItem)))


    mBarsTime = thebardata.BarsTime
    mValues = thebardata.Values

    mValueColor = Color.FromArgb(100, thebardata.ValueColor.R, thebardata.ValueColor.G, thebardata.ValueColor.B)
    mTeamColors = thebardata.TeamColors
    mParentColors = thebardata.ParentColors
    mSourceColors = thebardata.SourceColors

    mMaxTeamHeight = maxteamheight
    mMaxheight = maxheight

    mDataItems = barsdataitems

    EmptyBarRowsAndRects()


    mRadTotalHeight = GetTotalvalue(mValues.Item(0))
    mDireTotalHeight = GetTotalvalue(mValues.Item(1))

    Select Case mPaneType
      Case ePanetype.TeamsStacked
        '  mValueTotalHeight = GetTotalvalue(mValues)
        FillStackedBar()

      Case ePanetype.DireTeamStacked
        ' mValueTotalHeight = GetTotalvalue(mValues.Item(1))
        FillDireBar()

      Case ePanetype.RadiantTeamStacked
        '  mValueTotalHeight = GetTotalvalue(mValues.Item(0))
        FillRadiantbar()

      Case ePanetype.Advantage
        '  mValueTotalHeight = GetTotalvalue(mValues)
        FillStackedBar()

      Case Else
        Dim x = 2
    End Select


  End Sub

  Public Sub SetPaneType(panetype As ePanetype)
    mPaneType = panetype
    Select Case panetype
      Case ePanetype.Advantage

      Case ePanetype.DireTeamStacked
        BarRadiantRow.Height = zerogridlength
      Case ePanetype.RadiantTeamStacked
        BarDireRow.Height = zerogridlength
      Case ePanetype.TeamsStacked

      Case Else
        Throw New NotImplementedException

    End Select
  End Sub

  Public Sub SetBarType(bartype As eBarType)
    'Exit Sub
    '' If mSelectedType = bartype Then Exit Sub
    'mSelectedType = bartype
    'ShowParentColumn(False)
    'ShowSourceColumn(False)
    'ShowTeamColumn(False)
    'ShowValueColumn(True)
    'Exit Sub
    Select Case bartype
      Case eBarType.Parent
        ShowParentColumn(True)
        ShowSourceColumn(False)
        ShowTeamColumn(False)
        ShowValueColumn(False)
      Case eBarType.Source
        ShowParentColumn(False)
        ShowSourceColumn(True)
        ShowTeamColumn(False)
        ShowValueColumn(False)

      Case eBarType.Team
        ShowParentColumn(False)
        ShowSourceColumn(False)
        ShowTeamColumn(True)
        ShowValueColumn(False)

      Case eBarType.Value
        ShowParentColumn(False)
        ShowSourceColumn(False)
        ShowTeamColumn(False)
        ShowValueColumn(True)

      Case Else
        Throw New NotImplementedException
    End Select
  End Sub


  Private Sub ShowValueColumn(show As Boolean)
    If show Then
      colValue.Width = onestargridlength
      Exit Sub
    End If
    colValue.Width = zerogridlength
  End Sub

  Private Sub ShowParentColumn(show As Boolean)
    If show Then
      colParentColors.Width = onestargridlength
      Exit Sub
    End If
    colParentColors.Width = zerogridlength
  End Sub

  Private Sub ShowSourceColumn(show As Boolean)
    If show Then
      colSourceColors.Width = onestargridlength
      Exit Sub
    End If
    colSourceColors.Width = zerogridlength
  End Sub

  Private Sub ShowTeamColumn(show As Boolean)
    If show Then
      colTeamColors.Width = onestargridlength
      Exit Sub
    End If
    colTeamColors.Width = zerogridlength
  End Sub


  Private Function GetTotalvalue(thevals As List(Of Double)) As Double
    Dim vals = thevals.Sum

    'here until graphs are able to disply vals < 0
    If vals < 0 Then vals = 0
    Return vals
  End Function

  Private Function GetTotalValue(thevals As List(Of List(Of Double))) As Double
    Dim outval As Double = 0
    For i = 0 To thevals.Count - 1
      outval += GetTotalValue(thevals.Item(i))
    Next
    Return outval
  End Function

  Private Function GetRowAndRect() As RowAndRect

    If RowAndRectPool.Count < 1 Then
      RowAndRectPool = New List(Of RowAndRect)
      RowAndRectPool.Add(New RowAndRect())
      UsedRowAndRectCount = 0
    End If

    If UsedRowAndRectCount < RowAndRectPool.Count Then
      UsedRowAndRectCount += 1
      Try
        Return RowAndRectPool.Item(UsedRowAndRectCount - 1)
      Catch ex As Exception
        Dim x = 2
      End Try

    Else
      UsedRowAndRectCount += 1
      RowAndRectPool.Add(New RowAndRect)
      Try
        Return RowAndRectPool.Item(RowAndRectPool.Count - 1)
      Catch ex As Exception
        Dim x = 2
      End Try

    End If
    Return Nothing

  End Function
  Private Sub EmptyBarRowsAndRects()


    'empty rows and rects from chart and reset rowandrectpoolcount

    UsedRowAndRectCount = 0

    gridRadParents.RowDefinitions.Clear()
    gridRadParents.Children.Clear()
    gridRadiantSources.RowDefinitions.Clear()
    gridRadiantSources.Children.Clear()
    If Not mRadiantParentRows Is Nothing Then
      mRadiantParentRows.Clear()
    End If
    If Not mRadiantParentRects Is Nothing Then
      mRadiantParentRects.Clear()
    End If
    If Not mRadiantSourceRows Is Nothing Then
      mRadiantSourceRows.Clear()
    End If
    If Not mRadiantSourceRects Is Nothing Then
      mRadiantSourceRects.Clear()
    End If


    gridDireSources.RowDefinitions.Clear()
    gridDireSources.Children.Clear()
    gridDireParents.RowDefinitions.Clear()
    gridDireParents.Children.Clear()
    If Not mDireParentRows Is Nothing Then
      mDireParentRows.Clear()
    End If
    If Not mDireParentRects Is Nothing Then
      mDireParentRects.Clear()
    End If
    If Not mDireSourceRows Is Nothing Then
      mDireSourceRows.Clear()
    End If
    If Not mDireSourceRects Is Nothing Then
      mDireSourceRects.Clear()
    End If


  End Sub



#Region "Props"

  Public ReadOnly Property MyDataItems As List(Of List(Of iDataItem))
    Get
      Return mDataItems
    End Get
  End Property


  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property

  Public ReadOnly Property MyMaxHeight As Double
    Get
      Return mMaxheight
    End Get
  End Property

  Public ReadOnly Property ValueColor As Color
    Get
      Return mValueColor
    End Get
  End Property


#End Region


  Private Sub FillStackedBar()

    FillRadiantbar()

    FillDireBar()


  End Sub

  Private Sub FillBarAccent()

    'this is lazy
    grdAccent.Visibility = Windows.Visibility.Visible



    'position
    Select Case mPaneType
      Case ePanetype.Advantage
        'color
        If mRadTotalHeight = mDireTotalHeight Then
          If mRadTotalHeight <= 0 Then
            grdAccent.Visibility = Windows.Visibility.Hidden
          Else
            rectTeamBarAccent.Fill = mGraphDividerBrush
          End If

        Else
          If mRadTotalHeight > mDireTotalHeight Then
            rectTeamBarAccent.Fill = mRadAcctBrush
          Else
            rectTeamBarAccent.Fill = mDireAcctBrush
          End If

        End If

        'position
        rowAboveAccent.Height = New GridLength(mDireTotalHeight, GridUnitType.Star)
        rowBelowAccent.Height = New GridLength(mRadTotalHeight, GridUnitType.Star)

      Case ePanetype.DireTeamStacked
        'color
        If mRadTotalHeight = mDireTotalHeight Then
          If mRadTotalHeight <= 0 Then
            grdAccent.Visibility = Windows.Visibility.Collapsed
          Else
            rectTeamBarAccent.Fill = mGraphDividerBrush
          End If



        Else
          If mRadTotalHeight > mDireTotalHeight Then
            grdAccent.Visibility = Windows.Visibility.Collapsed
          Else
            rectTeamBarAccent.Fill = mDireAcctBrush

          End If
        End If

        'position
        rowBelowAccent.Height = New GridLength(mDireTotalHeight, GridUnitType.Star)
        rowAboveAccent.Height = New GridLength(mMaxTeamHeight - mDireTotalHeight, GridUnitType.Star)

      Case ePanetype.RadiantTeamStacked
        'color
        If mRadTotalHeight = mDireTotalHeight Then
          rectTeamBarAccent.Fill = mGraphDividerBrush
        Else
          If mRadTotalHeight > mDireTotalHeight Then
            rectTeamBarAccent.Fill = mRadAcctBrush
          Else
            grdAccent.Visibility = Windows.Visibility.Collapsed
          End If
        End If

        'position
        rowAboveAccent.Height = New GridLength(mRadTotalHeight, GridUnitType.Star)
        rowBelowAccent.Height = New GridLength(mMaxTeamHeight - mRadTotalHeight, GridUnitType.Star)

      Case ePanetype.TeamsStacked
        'color
        If mRadTotalHeight = mDireTotalHeight Then
          rectTeamBarAccent.Fill = mGraphDividerBrush
        Else
          If mRadTotalHeight > mDireTotalHeight Then
            rectTeamBarAccent.Fill = mRadAcctBrush
          Else
            rectTeamBarAccent.Fill = mDireAcctBrush
          End If
        End If

        If (mRadTotalHeight + mDireTotalHeight) - mMaxheight = 0 Then
          Dim x = 2
        End If

        'position
        rowBelowAccent.Height = New GridLength(mRadTotalHeight, GridUnitType.Star)
        rowAboveAccent.Height = New GridLength(mMaxheight - mRadTotalHeight, GridUnitType.Star)

    End Select
  End Sub
  Private Sub FillRadiantbar()
    Dim valbrush As New SolidColorBrush(mValueColor)
    If valbrush.CanFreeze Then
      valbrush.Freeze()
    End If
    rectValue.Fill = valbrush

    ' RectRadColor.Fill = New SolidColorBrush(mTeamColors.Item(0))

    'fill radiant mod rects
    Dim rvals = mValues.Item(0)
    For i As Integer = 0 To rvals.Count - 1

      Dim curval = rvals.Item(i)

      If curval > 0 Then
        Dim pbrush As New SolidColorBrush(mParentColors.Item(0).Item(i))
        If pbrush.CanFreeze Then
          pbrush.Freeze()
        End If
        AddRect(eBarType.Parent, eTeamName.Radiant, curval, pbrush)


        Dim sbrush As New SolidColorBrush(mSourceColors.Item(0).Item(i))
        If sbrush.CanFreeze Then
          sbrush.Freeze()
        End If
        AddRect(eBarType.Source, eTeamName.Radiant, curval, sbrush)
      End If


    Next
  End Sub

  Private Sub FillDireBar()
    Dim valbrush As New SolidColorBrush(mValueColor)
    If valbrush.CanFreeze Then
      valbrush.Freeze()
    End If
    rectValue.Fill = valbrush
    'RectDireColor.Fill = New SolidColorBrush(mTeamColors.Item(1))
    'fill dire mod rects
    Dim dvals = mValues.Item(1)
    For i As Integer = 0 To dvals.Count - 1

      Dim curval = dvals.Item(i)

      If curval > 0 Then
        Dim pbrush As New SolidColorBrush(mParentColors.Item(1).Item(i))
        If pbrush.CanFreeze Then
          pbrush.Freeze()
        End If
        AddRect(eBarType.Parent, eTeamName.Dire, curval, pbrush)


        Dim sbrush As New SolidColorBrush(mSourceColors.Item(1).Item(i))
        If sbrush.CanFreeze Then
          sbrush.Freeze()
        End If
        AddRect(eBarType.Source, eTeamName.Dire, curval, sbrush)
      End If


    Next

  End Sub


#Region "Setters"


  Public Sub SetFillerHeight()

    FillBarAccent()

    Select Case mPaneType
      Case ePanetype.Advantage
        SetAdvantageBarFillerHeight()
        Exit Sub
      Case ePanetype.TeamsStacked
        SetDualTeamStackedBarFillerHeight(True)
        Exit Sub

      Case ePanetype.DireTeamStacked
        SetSingleTeamStackedBarFillerHeight(eTeamName.Dire)
        Exit Sub
      Case ePanetype.RadiantTeamStacked
        SetSingleTeamStackedBarFillerHeight(eTeamName.Radiant)
        Exit Sub

      Case Else
        'shouldn't be here
        Dim x = 2
    End Select

  End Sub

  'Public Sub SetMargin(themargins As System.Windows.Thickness)

  '  LayoutRoot.Margin = themargins
  'End Sub

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    '   SetHighlighted(isselected)

    If mIsSelected = isselected Then Exit Sub

    If isselected Then
      mIsSelected = True

    Else
      mIsSelected = False
    End If


  End Sub

  'Public Sub SetHighlighted(isselected As Boolean)
  '  If isselected Then
  '    Dim thewidth = Me.ActualWidth / 10
  '    If thewidth < 1 Then thewidth = 1

  '    Me.rectSelected.StrokeThickness = thewidth

  '    rectSelected.Visibility = Windows.Visibility.Visible
  '  Else
  '    rectSelected.Visibility = Windows.Visibility.Collapsed
  '  End If
  'End Sub
  Private Sub SetAdvantageBarFillerHeight()
    BarRadiantRow.Height = New System.Windows.GridLength(mRadTotalHeight, GridUnitType.Star)
    BarDireRow.Height = New System.Windows.GridLength(mDireTotalHeight, GridUnitType.Star)

    StartRow.Height = New GridLength(0, GridUnitType.Star)
    EndRow.Height = New GridLength(0, GridUnitType.Star)


    ''Accent position
    'rowAboveAccent.Height = New GridLength(mDireTotalHeight, GridUnitType.Star)
    'rowBelowAccent.Height = New GridLength(mRadTotalHeight, GridUnitType.Star)
  End Sub

  Private Sub SetSingleTeamStackedBarFillerHeight(team As eTeamName)

    Select Case team
      Case eTeamName.Radiant

        BarRadiantRow.Height = New System.Windows.GridLength(mRadTotalHeight, GridUnitType.Star)
        BarDireRow.Height = New System.Windows.GridLength(0)

        StartRow.Height = zerogridlength
        EndRow.Height = New System.Windows.GridLength(mMaxTeamHeight - mRadTotalHeight, GridUnitType.Star)

      Case eTeamName.Dire

        BarRadiantRow.Height = New System.Windows.GridLength(0)
        BarDireRow.Height = New System.Windows.GridLength(mDireTotalHeight, GridUnitType.Star)

        StartRow.Height = New System.Windows.GridLength(mMaxTeamHeight - mDireTotalHeight, GridUnitType.Star)
        EndRow.Height = zerogridlength

      Case Else


    End Select







  End Sub

  Private Sub SetDualTeamStackedBarFillerHeight(atbeginning As Boolean)

    Dim thestarheight As Double = (mMaxheight - (mRadTotalHeight + mDireTotalHeight))

    BarRadiantRow.Height = New System.Windows.GridLength(mRadTotalHeight, GridUnitType.Star)
    BarDireRow.Height = New System.Windows.GridLength(mDireTotalHeight, GridUnitType.Star)

    ''Accent
    'rowBelowAccent.Height = New GridLength(mRadTotalHeight, GridUnitType.Star)
    'rowAboveAccent.Height = New GridLength(mMaxheight - mRadTotalHeight, GridUnitType.Star)

    If atbeginning Then
      StartRow.Height = New System.Windows.GridLength(thestarheight, GridUnitType.Star)

      EndRow.Height = zerogridlength
    Else
      StartRow.Height = zerogridlength

      EndRow.Height = New System.Windows.GridLength(thestarheight, GridUnitType.Star)
    End If


  End Sub



#End Region




#Region "Updaters"


#End Region

#Region "UI Stuff"
  Private Sub AddRect(recttype As eBarType, sourceteam As eTeamName, sourcevalue As Double, fillcolor As SolidColorBrush) ',  sourcevalue As Double,  sourcecolor As SolidColorBrush)


    Try
      Dim rowrect = GetRowAndRect()
      Dim newrect = rowrect.mRect
      Dim newrow = rowrect.mRow

      Select Case sourceteam
        Case eTeamName.Dire

          Select Case recttype
            Case eBarType.Parent
              newrect.SetValue(Grid.ColumnProperty, 0)

              gridDireParents.RowDefinitions.Add(newrow)
              mDireParentRows.Add(newrow)

              newrect.SetValue(Grid.RowProperty, gridDireParents.RowDefinitions.Count - 1)


              gridDireParents.Children.Add(newrect)
              mDireParentRects.Add(newrect)

            Case eBarType.Source
              newrect.SetValue(Grid.ColumnProperty, 1)

              gridDireSources.RowDefinitions.Add(newrow)
              mDireSourceRows.Add(newrow)

              newrect.SetValue(Grid.RowProperty, gridDireSources.RowDefinitions.Count - 1)


              gridDireSources.Children.Add(newrect)
              mDireSourceRects.Add(newrect)

            Case Else
              Throw New NotImplementedException
          End Select

        Case eTeamName.Radiant

          Select Case recttype
            Case eBarType.Parent
              newrect.SetValue(Grid.ColumnProperty, 0)

              gridRadParents.RowDefinitions.Add(newrow)
              mRadiantParentRows.Add(newrow)

              newrect.SetValue(Grid.RowProperty, gridRadParents.RowDefinitions.Count - 1)

              gridRadParents.Children.Add(newrect)
              mRadiantParentRects.Add(newrect)

            Case eBarType.Source
              newrect.SetValue(Grid.ColumnProperty, 1)

              gridRadiantSources.RowDefinitions.Add(newrow)
              mRadiantSourceRows.Add(newrow)

              newrect.SetValue(Grid.RowProperty, gridRadiantSources.RowDefinitions.Count - 1)

              gridRadiantSources.Children.Add(newrect)
              mRadiantSourceRects.Add(newrect)
            Case Else
              Throw New NotImplementedException
          End Select



        Case Else
          Dim x = 2
      End Select

      newrect.Fill = fillcolor
      newrect.Height = Double.NaN

      newrow.Height = New GridLength(sourcevalue, GridUnitType.Star)
    Catch ex As Exception
      Throw New NotImplementedException
    End Try


  End Sub



#End Region

#Region "Event Handlers"
  Private Sub Me_SizeChanged(sender As Object, e As SizeChangedEventArgs)
    'If mCurrentHeight = Me.Height Then Exit Sub
    'mCurrentHeight = Me.Height
    'Dim thectrl As ctrlBar = sender
    'Dim parentctrl As Grid = thectrl.Parent

    'RemoveHandler Me.SizeChanged, AddressOf Me_SizeChanged

    'gr.Width = Me.Width * PageHandler.BigSourcePercentWidth

    'For i As Integer = 0 To LayoutRoot.Children.Count - 1
    '  Dim thebarbitctrl As ctrlBar_Bit = LayoutRoot.Children.Item(i)

    '  thebarbitctrl.Height = (thebarbitctrl.mValue / mTotalBitValues) * Me.Height
    '  thebarbitctrl.Width = Me.Width - rectBigSource.Width
    'Next

    'AddHandler Me.SizeChanged, AddressOf Me_SizeChanged

  End Sub
#End Region

  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    If Not mIsSelected Then
      Me.SetSelected(True)

    End If
  End Sub







End Class
