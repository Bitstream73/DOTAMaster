Public Class ctrlVScale
  Private mMaxVal As Double
  Private mMinVal As Double
  Private mDividersCount As Integer
  Private mPaneType As ePanetype

  Private mLabelForgroundColor As SolidColorBrush
  Private mLabelBackgroundColor As SolidColorBrush

  Private mTransparentColor As SolidColorBrush

  Private mHoverColor As SolidColorBrush
  Private mHoverlbl As ctrlVScaleLabel
  Private mLabelSpacer As ctrlVScaleLabel

  Private mCurVal As Double

  Private mDecimalPlaces As Integer
  Public Sub New(themaxval As Double, _
                  theminval As Double, _
                  dividerscount As Integer, _
                  thepanetype As ePanetype)

    InitializeComponent()

    mMaxVal = themaxval

    If mMaxVal.ToString.Length > 4 Then
      mDecimalPlaces = 0
    Else
      mDecimalPlaces = 2
    End If
    mMinVal = theminval
    ' mDividersCount = dividerscount
    mPaneType = thepanetype

    setwidth(mMaxVal, mMinVal, mDecimalPlaces)

    Dim col = New SolidColorBrush(PageHandler.dbColors.ScaleWeakColor)
    Dim strongfill = New SolidColorBrush(PageHandler.dbColors.ScaleStrongFill)
    Dim weakfill = New SolidColorBrush(PageHandler.dbColors.ScaleWeakFill)

    mLabelForgroundColor = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
    mLabelBackgroundColor = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
    mTransparentColor = New SolidColorBrush(PageHandler.dbColors.Transparent)
    mHoverColor = New SolidColorBrush(PageHandler.dbColors.HoveredColor)

    mDividersCount = dividerscount

    Dim dividers As Integer
    If mPaneType = ePanetype.Advantage Then
      dividers = dividerscount * 2
    Else
      dividers = dividerscount
    End If
    For i As Integer = 0 To dividers - 1
      Dim newrow As New RowDefinition
      newrow.Height = New GridLength(2, GridUnitType.Star)
      LayoutRoot.RowDefinitions.Add(newrow)


      'add alternating fill

      Dim fillrect As New Rectangle
      fillrect.VerticalAlignment = Windows.VerticalAlignment.Stretch
      fillrect.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
      fillrect.SetValue(Grid.RowProperty, i)
      If (i + 1) Mod 2 = 0 Then
        fillrect.Fill = strongfill
      Else
        fillrect.Fill = weakfill
      End If

      LayoutRoot.Children.Add(fillrect)

      'add line

      Dim newline As New Rectangle
      newline.Height = 1
      newline.VerticalAlignment = Windows.VerticalAlignment.Top
      newline.Fill = col
      newline.SetValue(Grid.RowProperty, i)
      newline.SetValue(Grid.ColumnProperty, 1)
      LayoutRoot.Children.Add(newline)

    Next


    SetLabels()


    rectVertline.Fill = col

    mHoverlbl = New ctrlVScaleLabel(mHoverColor)
    mHoverlbl.HorizontalAlignment = Windows.HorizontalAlignment.Right

    If Not mPaneType = ePanetype.Advantage Then
      mHoverlbl.SetLabel(GetHoverValue(0, mMaxVal, mMinVal, mDecimalPlaces))
    Else
      mHoverlbl.SetLabel("99.99%")
    End If

    PositionLabelRoot.Children.Add(mHoverlbl)
    UpdateLayout()



    'Me.Width = mHoverlbl.ActualWidth + 15
  End Sub

  Private Sub SetLabels()
    Select Case mPaneType
      Case ePanetype.Advantage
        SetAdvantageLabels()
      Case ePanetype.TeamsStacked, ePanetype.DireTeamStacked
        SetRegularLabels()

      Case ePanetype.RadiantTeamStacked
        SetRadiantLabels()
      Case Else
        Dim x = 2

    End Select
  End Sub

  Private Sub SetRegularLabels()
    'spacer for hoverlabelwidth
    mLabelSpacer = New ctrlVScaleLabel(mTransparentColor)

    mLabelSpacer.SetLabel(Math.Round(mMaxVal, mDecimalPlaces).ToString & ".00")

    NumLabelsRoot.Children.Add(mLabelSpacer)
    'add gridline labels
    Dim startrow As New RowDefinition
    startrow.Height = New GridLength(1, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(startrow)


    'labels

    For i As Integer = 1 To mDividersCount - 1

      Dim newrow As New RowDefinition
      newrow.Height = New GridLength(2, GridUnitType.Star)
      NumLabelsRoot.RowDefinitions.Add(newrow)

      Dim lbl As New Label
      lbl.Content = Math.Round(((mMaxVal - mMinVal) / mDividersCount) * (mDividersCount - i), mDecimalPlaces).ToString
      lbl.FontSize = 9
      lbl.SetValue(Grid.RowProperty, i)
      lbl.Foreground = mLabelForgroundColor
      lbl.Background = mLabelBackgroundColor

      lbl.HorizontalAlignment = Windows.HorizontalAlignment.Right
      lbl.VerticalAlignment = Windows.VerticalAlignment.Center

      NumLabelsRoot.Children.Add(lbl)

    Next



    Dim endrow As New RowDefinition
    endrow.Height = New GridLength(1, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(endrow)
  End Sub

  Private Sub SetAdvantageLabels()


    'spacer for hoverlabelwidth
    mLabelSpacer = New ctrlVScaleLabel(mTransparentColor)

    mLabelSpacer.SetLabel(Math.Round(mMaxVal, mDecimalPlaces).ToString & ".00")

    NumLabelsRoot.Children.Add(mLabelSpacer)
    'add gridline labels
    Dim startrow As New RowDefinition
    startrow.Height = New GridLength(1, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(startrow)

    'Dim startrect As New Rectangle
    'startrect.Fill = PageHandler.dbColors.RadiantAccentColor
    'startrect.SetValue(Grid.RowProperty, 0)
    'NumLabelsRoot.Children.Add(startrect)

    'labels

    For i As Integer = 1 To mDividersCount - 1

      Dim newrow As New RowDefinition
      newrow.Height = New GridLength(2, GridUnitType.Star)
      NumLabelsRoot.RowDefinitions.Add(newrow)

      'If i Mod 2 = 0 Then
      '  Dim rect As New Rectangle
      '  rect.Fill = PageHandler.dbColors.ErrorColor
      '  rect.SetValue(Grid.RowProperty, i)
      '  NumLabelsRoot.Children.Add(rect)
      'End If

      Dim lbl As New Label
      lbl.Content = Math.Round(((mMaxVal - mMinVal) / mDividersCount) * (mDividersCount - i) * 100, mDecimalPlaces).ToString & "%"
      lbl.FontSize = 9
      lbl.SetValue(Grid.RowProperty, i)
      lbl.Foreground = mLabelForgroundColor
      lbl.Background = mLabelBackgroundColor

      lbl.HorizontalAlignment = Windows.HorizontalAlignment.Right
      lbl.VerticalAlignment = Windows.VerticalAlignment.Center

      NumLabelsRoot.Children.Add(lbl)

    Next



    'Dim endrow As New RowDefinition
    'endrow.Height = New GridLength(1, GridUnitType.Star)
    'NumLabelsRoot.RowDefinitions.Add(endrow)

    'Dim firstendrect As New Rectangle
    'firstendrect.Fill = PageHandler.dbColors.RadiantColor
    'firstendrect.SetValue(Grid.RowProperty, mDividersCount)
    'NumLabelsRoot.Children.Add(firstendrect)

    ''bottom scale

    ''add gridline labels
    'Dim botstartrow As New RowDefinition
    'botstartrow.Height = New GridLength(1, GridUnitType.Star)
    'NumLabelsRoot.RowDefinitions.Add(botstartrow)

    'Dim secondstartrect As New Rectangle
    'secondstartrect.Fill = PageHandler.dbColors.DireAccentColor
    'secondstartrect.SetValue(Grid.RowProperty, mDividersCount + 1)
    'NumLabelsRoot.Children.Add(secondstartrect)


    'zero row
    Dim zerorow As New RowDefinition
    zerorow.Height = New GridLength(2, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(zerorow)

    Dim zerolbl As New Label
    zerolbl.Content = "0"
    zerolbl.FontSize = 9
    zerolbl.SetValue(Grid.RowProperty, mDividersCount)

    zerolbl.Foreground = mLabelForgroundColor
    zerolbl.Background = mLabelBackgroundColor

    zerolbl.HorizontalAlignment = Windows.HorizontalAlignment.Right
    zerolbl.VerticalAlignment = Windows.VerticalAlignment.Center

    NumLabelsRoot.Children.Add(zerolbl)

    'labels

    ' Dim multiplier = mDividersCount - 1
    For i As Integer = mDividersCount + 1 To (2 * mDividersCount) - 1 ' - 1

      Dim newrow As New RowDefinition
      newrow.Height = New GridLength(2, GridUnitType.Star)
      NumLabelsRoot.RowDefinitions.Add(newrow)

      'If i Mod 2 = 0 Then
      '  Dim rect As New Rectangle
      '  rect.Fill = PageHandler.dbColors.ErrorColor
      '  rect.SetValue(Grid.RowProperty, i)
      '  NumLabelsRoot.Children.Add(rect)
      'End If

      Dim lbl As New Label
      lbl.Content = Math.Round(((mMaxVal - mMinVal) / mDividersCount) * ((i) - mDividersCount) * 100, mDecimalPlaces).ToString & "%"
      lbl.FontSize = 9
      lbl.SetValue(Grid.RowProperty, i)

      lbl.Foreground = mLabelForgroundColor
      lbl.Background = mLabelBackgroundColor

      lbl.HorizontalAlignment = Windows.HorizontalAlignment.Right
      lbl.VerticalAlignment = Windows.VerticalAlignment.Center

      NumLabelsRoot.Children.Add(lbl)
      'multiplier -= 1
    Next



    Dim botendrow As New RowDefinition
    botendrow.Height = New GridLength(1, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(botendrow)
    'Dim endrect As New Rectangle
    'endrect.Fill = PageHandler.dbColors.DireAccentColor
    'endrect.SetValue(Grid.RowProperty, 2 * mDividersCount + 1)
    'NumLabelsRoot.Children.Add(endrect)

  End Sub

  Private Sub SetRadiantLabels()
    'spacer for hoverlabelwidth
    mLabelSpacer = New ctrlVScaleLabel(mTransparentColor)

    mLabelSpacer.SetLabel(Math.Round(mMaxVal, mDecimalPlaces).ToString & ".00")

    NumLabelsRoot.Children.Add(mLabelSpacer)
    'add gridline labels
    Dim startrow As New RowDefinition
    startrow.Height = New GridLength(1, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(startrow)


    'labels
    Dim fground = mLabelForgroundColor
    Dim bground = mLabelBackgroundColor
    ' Dim multiplier = mDividersCount - 1
    For i As Integer = 1 To mDividersCount - 1

      Dim newrow As New RowDefinition
      newrow.Height = New GridLength(2, GridUnitType.Star)
      NumLabelsRoot.RowDefinitions.Add(newrow)

      Dim lbl As New Label
      lbl.Content = Math.Round(((mMaxVal - mMinVal) / mDividersCount) * i, mDecimalPlaces).ToString
      lbl.FontSize = 9
      lbl.SetValue(Grid.RowProperty, i)
      lbl.Foreground = fground
      lbl.Background = bground

      lbl.HorizontalAlignment = Windows.HorizontalAlignment.Right
      lbl.VerticalAlignment = Windows.VerticalAlignment.Center

      NumLabelsRoot.Children.Add(lbl)
      'multiplier -= 1
    Next



    Dim endrow As New RowDefinition
    endrow.Height = New GridLength(1, GridUnitType.Star)
    NumLabelsRoot.RowDefinitions.Add(endrow)
  End Sub
  Public Sub UpdateHoverPosition(they As Double) '-1 for no label
    'Exit Sub
    If they = -1 Then
      mHoverlbl.Visibility = Windows.Visibility.Collapsed
      Exit Sub
    Else
      mHoverlbl.Visibility = Windows.Visibility.Visible
    End If

    Dim p = GetPosition(they)
    mHoverlbl.Margin = New Thickness(0, p.X, 0, p.Y)

    'Dim ratio As Double
    'If mPaneType = ePanetype.RadientTeamStacked Then
    '  Dim myheight = Me.ActualHeight
    '  'ratio = ((p.X + p.Y + 16) - (Me.ActualHeight - they)) / (p.X + p.Y + 16)
    '  ratio = (myheight - (Me.ActualHeight - they)) / myheight

    'ElseIf mPaneType = ePanetype.Advantage Then
    '  Dim teamheight = Me.ActualHeight / 2

    '  If p.X + 8 > Me.ActualHeight / 2 Then
    '    ratio = ((they) - teamheight) / teamheight
    '  Else
    '    ratio = 1 - ((they) / teamheight)
    '  End If
    'Else
    '  Dim myheight = Me.ActualHeight
    '  'ratio = ((p.X + p.Y + 16) - they) / (p.X + p.Y + 16)
    '  ratio = (myheight - they) / myheight
    'End If

    Dim val = GetHoverValue(they, mMaxVal, mMinVal, mDecimalPlaces)
    mHoverlbl.SetLabel(val)


  End Sub

  Private Sub setwidth(maxvalue As Double, minval As Double, decimalplaces As Integer)
    Dim maxv = Math.Round(maxvalue, decimalplaces).ToString.Length
    If mPaneType = ePanetype.Advantage Then
      maxv = 6
    End If
    Me.Width = maxv * 10
  End Sub

  Private Function GetHoverValue(they As Double, maxval As Double, minval As Double, decimalplaces As Integer) As String
    Dim p = GetPosition(they)
    Dim ratio As Double
    If mPaneType = ePanetype.RadiantTeamStacked Then
      Dim myheight = Me.ActualHeight
      'ratio = ((p.X + p.Y + 16) - (Me.ActualHeight - they)) / (p.X + p.Y + 16)
      ratio = (myheight - (Me.ActualHeight - they)) / myheight

    ElseIf mPaneType = ePanetype.Advantage Then
      Dim teamheight = Me.ActualHeight / 2

      If p.X + 8 > Me.ActualHeight / 2 Then
        ratio = ((they) - teamheight) / teamheight
      Else
        ratio = 1 - ((they) / teamheight)
      End If
    Else
      Dim myheight = Me.ActualHeight
      'ratio = ((p.X + p.Y + 16) - they) / (p.X + p.Y + 16)
      ratio = (myheight - they) / myheight
    End If

    Dim val As Double
    If Not mPaneType = ePanetype.Advantage Then
      val = Math.Round(ratio * (maxval - minval), decimalplaces)
      Return val.ToString
    Else
      val = Math.Round(ratio * 100, decimalplaces)
      Return val.ToString & "%"
    End If

  End Function
  Public Sub UpdateInvertedHoverPostion( they As Double)

    UpdateHoverPosition(Me.ActualHeight - they)
  End Sub
  Private Function GetPosition( they As Double) As Point
    Dim h = Me.ActualHeight
    Dim ry As Double
    If they >= h - (16 / 2) Then
      they = h - (16 / 2)
      ry = 0
    End If
    If they <= 16 Then
      they = 0
      ry = h - 16
    Else
      they = they - (16 / 2)
      ry = (h - 16) - they
    End If

    Return New Point(they, ry)
  End Function
End Class
