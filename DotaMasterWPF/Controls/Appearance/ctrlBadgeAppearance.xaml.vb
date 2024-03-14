Public Class ctrlBadgeAppearance


  Private mSelectedAppearance As Label
  Private mHeadingTextBrush As SolidColorBrush
  Private mBodyTextBrush As SolidColorBrush

  Public Event BadgeAppearanceChanged(appearance As eBadgeAppearance)

  Private dbColors As Colors_Database
  Private notselected As SolidColorBrush
  Private selected As SolidColorBrush
  Public Sub New(colorsdb As Colors_Database, defaulttype As eBadgeAppearance, _
                headingtextbrush As SolidColorBrush, bodytextcolor As SolidColorBrush)

    ' This call is required by the designer.
    InitializeComponent()

    dbColors = colorsdb
    notselected = New SolidColorBrush(dbColors.ButtonColorNotSelected)
    selected = New SolidColorBrush(dbColors.ButtonColorSelected)

    mHeadingTextBrush = headingtextbrush
    mBodyTextBrush = bodytextcolor

    lblFull.Foreground = headingtextbrush
    AddHandler lblFull.MouseLeftButtonDown, AddressOf rdo_Click


    lblStats.Foreground = headingtextbrush
    AddHandler lblStats.MouseLeftButtonDown, AddressOf rdo_Click


    lblNone.Foreground = headingtextbrush
    AddHandler lblNone.MouseLeftButtonDown, AddressOf rdo_Click

    lblTitle.Foreground = bodytextcolor


    Select Case defaulttype
      Case eBadgeAppearance.Full
        lblFull.Background = selected

      Case eBadgeAppearance.None
        lblNone.Background = selected

      Case eBadgeAppearance.Stats
        lblStats.Background = selected

    End Select

    'AddHandler rdoFull.Click, AddressOf rdo_Click
    'AddHandler rdoNone.Click, AddressOf rdo_Click
    'AddHandler rdoStats.Click, AddressOf rdo_Click


  End Sub

  Private Sub rdo_Click(sender As Object, e As RoutedEventArgs)

    Dim newselected As Label = sender
    If newselected Is mSelectedAppearance Then Exit Sub

    mSelectedAppearance = newselected

    lblFull.Background = notselected
    lblNone.Background = notselected
    lblStats.Background = notselected


    Select Case newselected.Content
      Case " Full "
        lblFull.Background = selected
        RaiseEvent BadgeAppearanceChanged(eBadgeAppearance.Full)
      Case " Stats "
        lblStats.Background = selected
        RaiseEvent BadgeAppearanceChanged(eBadgeAppearance.Stats)
      Case " None "
        lblNone.Background = selected
        RaiseEvent BadgeAppearanceChanged(eBadgeAppearance.None)
      Case Else
        Throw New NotImplementedException

    End Select


  End Sub

End Class
