Public Class ctrlBar_Type

  Event BarTypeChanged(sender As Object, e As MouseButtonEventArgs)

  Private mSelectedBarType As Label
  Private dbColors As Colors_Database

  Private notselected As SolidColorBrush
  Private selected As SolidColorBrush

  Public Sub New(colorsdb As Colors_Database, defaulttype As eBarType, _
                 headingtextbrush As SolidColorBrush, bodytextcolor As SolidColorBrush)

    ' This call is required by the designer.
    InitializeComponent()

    dbColors = colorsdb
    notselected = New SolidColorBrush(dbColors.ButtonColorNotSelected)
    selected = New SolidColorBrush(dbColors.ButtonColorSelected)


    lblValChartView.Foreground = headingtextbrush
    AddHandler lblValChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown

    lblOwnerChartView.Foreground = headingtextbrush
    AddHandler lblOwnerChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown

    lblSourceChartView.Foreground = headingtextbrush
    AddHandler lblSourceChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown

    lblTeamChartView.Foreground = headingtextbrush
    AddHandler lblTeamChartView.MouseLeftButtonDown, AddressOf BarType_LeftMouseButtonDown

    lblTitle.Foreground = bodytextcolor

    Select Case defaulttype
      Case eBarType.Parent
        mSelectedBarType = lblOwnerChartView
        lblOwnerChartView.Background = selected
      Case eBarType.Source
        mSelectedBarType = lblSourceChartView
        lblSourceChartView.Background = selected
      Case eBarType.Team
        mSelectedBarType = lblTeamChartView
        lblTeamChartView.Background = selected
      Case eBarType.Value
        mSelectedBarType = lblValChartView
        lblValChartView.Background = selected

    End Select
  End Sub

  Public Sub SetBarType(bartype As eBarType)
    lblOwnerChartView.Background = notselected
    lblSourceChartView.Background = notselected
    lblTeamChartView.Background = notselected
    lblValChartView.Background = notselected

    Select Case bartype
      Case eBarType.Parent
        lblOwnerChartView.Background = selected
      Case eBarType.Source
        lblSourceChartView.Background = selected
      Case eBarType.Team
        lblTeamChartView.Background = selected
      Case eBarType.Value
        lblValChartView.Background = selected
      Case Else
        Throw New NotImplementedException
    End Select

  End Sub
  Private Sub BarType_LeftMouseButtonDown(sender As Object, e As MouseButtonEventArgs)
    Dim selectedtype As Label = sender
    If selectedtype Is mSelectedBarType Then
      Dim x = 2
      Exit Sub
    End If


    mSelectedBarType = selectedtype


    lblOwnerChartView.Background = notselected
    lblValChartView.Background = notselected
    lblSourceChartView.Background = notselected
    lblTeamChartView.Background = notselected


    Select Case mSelectedBarType.Content
      Case " Owner "

        lblOwnerChartView.Background = selected

      Case " Value "

        lblValChartView.Background = selected

      Case " Source "

        lblSourceChartView.Background = selected
      Case " Team "
        lblTeamChartView.Background = selected
      Case Else
        Dim x = 2
    End Select

    RaiseEvent BarTypeChanged(sender, e)

  End Sub

End Class
