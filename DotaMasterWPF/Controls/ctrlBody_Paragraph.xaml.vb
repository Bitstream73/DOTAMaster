Imports DotaMasterWPF.PageHandler

Public Class ctrlBody_Paragraph
  Public Sub New()
    InitializeComponent()

    LayoutRoot.Foreground = New SolidColorBrush(dbColors.BodyTextColor)
    LayoutRoot.FontFamily = Constants.cBodyFont
    LayoutRoot.FontSize = Constants.cBodyFontSize
    ' LayoutRoot.CharacterSpacing = 100
  End Sub

  Public Sub LoadText( thetext As String,  thecolor As SolidColorBrush)
    LayoutRoot.Text = thetext
    LayoutRoot.Foreground = thecolor
  End Sub

  Public Sub SetItalics( isitalics As Boolean)
    If isitalics Then
      LayoutRoot.FontStyle = FontStyles.Italic
    Else
      LayoutRoot.FontStyle = FontStyles.Normal
    End If

  End Sub
End Class
