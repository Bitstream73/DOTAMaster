Imports System.Windows.Media.Imaging
Public Class ctrlItem_Tooltip_Icon
  Public mitem As Item_Info
  Private mTooltip As ToolTip

  'Event isSelected( ctrl As ctrlItem_MenuItem)
  Public Sub New( theitem As Item_Info,  thebitmap As BitmapImage)
    InitializeComponent()

    mitem = theitem
    If Not Me.ImageThumb Is Nothing Then

      Me.ImageThumb.Source = thebitmap

    End If
    mTooltip = New ToolTip()
    mTooltip.Content = theitem.DisplayName
    mTooltip.FontFamily = Constants.cBodyFont
    mTooltip.Foreground = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
    mTooltip.Background = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
    ToolTipService.SetToolTip(Me, mTooltip)

    tbkName.Visibility = Windows.Visibility.Collapsed
    'tbkName.Text = theitem.mDisplayname

    'tbkName.FontFamily = PageHandler.bodyFont
    'tbkName.Foreground = PageHandler.dbColors.BodyTextColor



    'AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    Me.ImageThumb.Source = thebitmap
  End Sub

End Class
