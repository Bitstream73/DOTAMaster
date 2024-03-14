Imports DotaMasterWPF.PageHandler
Public Class ctrlHeadingLabel
  Public Sub New()
    InitializeComponent()

    'LayoutRoot.FontFamily = Constants.cHeadingFont
    'LayoutRoot.Foreground = New SolidColorBrush(dbColors.HeadingTextColor)
    'LayoutRoot.FontSize = Constants.cHeadingFontSize

  End Sub

  Public Property _Content As String
    Get
      Return LayoutRoot.Content
    End Get
    Set(value As String)
      LayoutRoot.FontFamily = Constants.cHeadingFont
      LayoutRoot.Foreground = New SolidColorBrush(dbColors.HeadingTextColor)
      LayoutRoot.FontSize = Constants.cHeadingFontSize
      LayoutRoot.Content = value
    End Set
  End Property
End Class
