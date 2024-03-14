Public Class ctrlHero_Menu_Item
  Public mHero As HeroBuild
  Public mTooltip As ToolTip
  Public Sub New( thehero As HeroBuild,  thebitmap As BitmapImage)
    InitializeComponent()

    mHero = thehero
    Me.ImageThumb.Source = thebitmap



    'mTooltip = New ToolTip()
    'Dim thick As New Thickness(0)
    'mTooltip.BorderThickness = thick
    'Dim ctrlTT As New ctrlHero_Tooltip(mHero)
    'mTooltip.Content = ctrlTT
    'ToolTipService.SetToolTip(Me, mTooltip)

    'AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    Me.ImageThumb.Source = thebitmap
  End Sub
End Class
