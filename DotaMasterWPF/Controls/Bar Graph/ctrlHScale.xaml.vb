Imports DotaMasterWPF.PageHandler
Public Class ctrlHScale
  Private mtimes As List(Of String)
  Private mBigDiv As Integer
  Private mBigDivTimes As List(Of String)
  Private mLittleDiv As Integer
  Private mHoverLbl As ctrlHScaleLabel
  Private mSelectedLbl As ctrlHScaleLabel

  Private mFriendlytimes As List(Of String)

  Private dayduration As Integer = 4

  Private mHoverColor As SolidColorBrush
  Private mSelectedColor As SolidColorBrush

  Private mSelectedRect As Rectangle

  Private mdaycolor = New SolidColorBrush(PageHandler.dbColors.DayColor)
  Private mnightcolor = New SolidColorBrush(PageHandler.dbColors.NightColor)
  Public Sub New()
    InitializeComponent()


  End Sub

  Public Sub Load(theHovercolor As SolidColorBrush, _
                   theselectedColor As SolidColorBrush, _
                   thetimes As List(Of String), _
                   thebigdivincrement As Integer, _
                   thelittledivincrememnt As Integer, _
                   daycycletimepointcount As Integer, _
                   friendlytimes As List(Of String))

    mHoverColor = theHovercolor

    mSelectedColor = theselectedColor
    mFriendlytimes = friendlytimes
    mtimes = thetimes
    mBigDiv = thebigdivincrement
    mLittleDiv = thelittledivincrememnt
    LayoutRoot.Children.Clear()
    LayoutRoot.ColumnDefinitions.Clear()

    mSelectedRect = New Rectangle
    mSelectedRect.Fill = mSelectedColor
    mSelectedRect.Width = 1
    mSelectedRect.HorizontalAlignment = Windows.HorizontalAlignment.Left

    AddLittleDiv(0)
    mBigDivTimes = New List(Of String)
    ' Dim bigdivcount As Integer = 0
    For i As Integer = 0 To mtimes.Count - 2
      AddLabelColumn(i)
      If (i) Mod mBigDiv = 0 Then
        AddBigDiv(i)
        mBigDivTimes.Add(mFriendlytimes.Item(i))



        If Not i = 0 Then
          Dim lbl As New Label
          'lbl.Content = Helpers.GetFriendlyTime(mtimes.Item(i).CreationTime)
          lbl.Content = mtimes.Item(i)
          lbl.FontSize = 8
          lbl.SetValue(Grid.ColumnProperty, i - 6)
          lbl.Foreground = New SolidColorBrush(dbColors.BodyTextColor)
          lbl.Background = New SolidColorBrush(dbColors.BackgroundColor)

          lbl.HorizontalAlignment = Windows.HorizontalAlignment.Center
          lbl.VerticalAlignment = Windows.VerticalAlignment.Bottom
          lbl.SetValue(Grid.ColumnSpanProperty, 11)
          NumLabelsRoot.Children.Add(lbl)
        End If

      ElseIf (i) Mod mLittleDiv = 0 And Not (i) Mod mBigDiv = 0 Then
        AddLittleDiv(i)
      Else
        AddScaleColumn(i)
      End If
    Next

    Dim colindex = 0
    Dim cyclecount As Integer = 1
    Dim curfill As SolidColorBrush = mdaycolor
    For i As Integer = 0 To mtimes.Count - 1 '4 minute day/night cycle

      Dim col As New ColumnDefinition
      col.Width = New GridLength(1, GridUnitType.Star)
      Dim rect As New Rectangle
      rect.SetValue(Grid.ColumnProperty, colindex)



      rect.Fill = curfill

      Dim remainder As Double = (colindex + 1) Mod daycycletimepointcount
      If remainder = 0 Then
        If cyclecount Mod 2 = 0 Then
          curfill = mdaycolor
        Else
          curfill = mnightcolor
        End If
        cyclecount += 1
      End If
      grdDayNight.Children.Add(rect)
      grdDayNight.ColumnDefinitions.Add(col)

      colindex += 1
    Next

  
    mSelectedLbl = New ctrlHScaleLabel(mSelectedColor)
    PositionLabelRoot.Children.Add(mSelectedLbl)

    mHoverLbl = New ctrlHScaleLabel(mHoverColor)
    PositionLabelRoot.Children.Add(mHoverLbl)

  End Sub

  Public Sub SelectedLblVisible( isvisible As Boolean)
    If isvisible Then
      mSelectedLbl.Visibility = Windows.Visibility.Visible
    Else
      mSelectedLbl.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub
  Public Sub UpdateHoverPosition(thex As Double) ',  thetime As ddFrame) '-1 for no label
    ''temp til I find efficient way to pass in currentcrosshair time
    'mHoverLbl.Visibility = Windows.Visibility.Collapsed

    If thex = -1 Then
      mHoverLbl.Visibility = Windows.Visibility.Collapsed
      Exit Sub
    Else
      mHoverLbl.Visibility = Windows.Visibility.Visible
    End If

    Dim p = GetPosition(thex)
    mHoverLbl.Margin = New Thickness(p.X, 0, p.Y, 0)
    UpdateHoverTime(thex)
  End Sub

  Public Sub UpdateHoverTime(thex As Double)
    Dim timepointcounts = mtimes.Count


    Dim ratio = thex / Me.ActualWidth

    Dim timepoint As Integer = ratio * timepointcounts
    If timepoint < 1 Then timepoint = 1
    If timepoint > timepointcounts Then timepoint = timepointcounts
    mHoverLbl.lblTime.Content = mtimes.Item(timepoint - 1)
  End Sub

  Public Sub UpdateSelectedPosition(highlightedbarrectangle As Rectangle) ',  thetime As ddFrame)

    mSelectedLbl.Visibility = Windows.Visibility.Visible


    ' mSelectedRect.SetValue(Grid.ColumnProperty, theindex)
    mSelectedRect.Margin = highlightedbarrectangle.Margin
    mSelectedRect.Visibility = Windows.Visibility.Visible



    Me.UpdateLayout()

    mSelectedLbl.SetTime(mHoverLbl.lblTime.Content)
    mSelectedLbl.Margin = mHoverLbl.Margin
    'Temp til I figre out how to more efficiently get time for the label

    'Dim theind As Integer
    'If Not theindex - 5 < 0 Then
    '  theind = theindex - 5
    'Else
    '  theind = 0

    'End If
    'mSelectedLbl.SetValue(Grid.ColumnProperty, theind)
    'mSelectedLbl.SetValue(Grid.ColumnSpanProperty, 10)

  End Sub

  Private Function GetPosition( thex As Double) As Point
    Dim w = Me.ActualWidth
    Dim rx As Double
    If thex >= w - (35 / 2) Then
      thex = w - (35 / 2)
      rx = 0
    End If
    If thex <= 35 Then
      thex = 0
      rx = w - 35
    Else
      thex = thex - (35 / 2)
      rx = (w - 35) - thex
    End If

    Return New Point(thex, rx)
  End Function
  Private Sub AddScaleColumn( currentindex)
    Dim col As New ColumnDefinition
    LayoutRoot.ColumnDefinitions.Add(col)
    col.Width = New GridLength(1, GridUnitType.Star)

    Dim rect As New Rectangle
    rect.Fill = New SolidColorBrush(dbColors.ScaleWeakColor)
    rect.SetValue(Grid.ColumnProperty, currentindex)
    rect.Width = 1
    rect.Height = 4
    rect.HorizontalAlignment = Windows.HorizontalAlignment.Left
    rect.VerticalAlignment = Windows.VerticalAlignment.Top
    LayoutRoot.Children.Add(rect)
  End Sub

  Private Sub AddLabelColumn( currentindex)
    Dim col As New ColumnDefinition
    NumLabelsRoot.ColumnDefinitions.Add(col)
    col.Width = New GridLength(1, GridUnitType.Star)

    'Dim rect As New Rectangle
    'rect.Fill = dbColors.ScaleWeakColor
    'rect.SetValue(Grid.ColumnProperty, currentindex)
    'rect.Width = 1
    'rect.Height = 4
    'rect.HorizontalAlignment = Windows.HorizontalAlignment.Left
    'rect.VerticalAlignment = Windows.VerticalAlignment.Top
    'LayoutRoot.Children.Add(rect)
  End Sub
  Private Sub AddBigDiv( currentindex As Integer)
    Dim col As New ColumnDefinition
    LayoutRoot.ColumnDefinitions.Add(col)
    col.Width = New GridLength(1, GridUnitType.Star)

    Dim rect As New Rectangle
    rect.Fill = New SolidColorBrush(dbColors.ScaleStrongColor)
    rect.Height = 8
    rect.SetValue(Grid.ColumnProperty, currentindex)
    rect.Width = 1
    rect.HorizontalAlignment = Windows.HorizontalAlignment.Left
    rect.VerticalAlignment = Windows.VerticalAlignment.Top
    rect.HorizontalAlignment = Windows.HorizontalAlignment.Left
    LayoutRoot.Children.Add(rect)
  End Sub

  Private Sub AddLittleDiv( currentindex As Integer)
    Dim col As New ColumnDefinition
    LayoutRoot.ColumnDefinitions.Add(col)
    col.Width = New GridLength(1, GridUnitType.Star)

    Dim rect As New Rectangle
    rect.Fill = New SolidColorBrush(dbColors.ScaleWeakColor)
    rect.SetValue(Grid.ColumnProperty, currentindex)
    rect.Width = 1
    rect.Height = 6
    rect.HorizontalAlignment = Windows.HorizontalAlignment.Left
    rect.VerticalAlignment = Windows.VerticalAlignment.Top
    LayoutRoot.Children.Add(rect)
  End Sub
End Class
