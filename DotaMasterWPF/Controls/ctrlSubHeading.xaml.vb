Imports DotaMasterWPF.PageHandler

Public Class ctrlSubHeading
  Public Sub New()
    InitializeComponent()



  End Sub

  Public Property _Content As String
    Get
      Return LayoutRoot.Content
    End Get
    Set(value As String)
      LayoutRoot.Foreground = New SolidColorBrush(dbColors.SubHeadingTextColor)
      LayoutRoot.FontFamily = Constants.cSubHeadingFont
      LayoutRoot.FontSize = Constants.cSubHeadingFontSize
      LayoutRoot.Content = value
    End Set
  End Property
End Class
