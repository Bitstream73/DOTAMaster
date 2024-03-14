Imports DotaMasterWPF.PageHandler
Public Class ctrlModTinyDetailsLabel
  Public Sub New( thename As String,  thevalue As String)
    InitializeComponent()
    Layoutroot.Foreground = New SolidColorBrush(dbColors.BodyTextColor)
    Layoutroot.FontFamily = Constants.cBodyFont
    Layoutroot.FontSize = Constants.cSubtextFontSize

    UpdateExistingDetail(thename, thevalue)

    'Layoutroot.CharacterSpacing = 100
  End Sub


  Public Sub UpdateExistingDetail( thename As String,  thevalue As String)
    If Not thename = "" Then
      Layoutroot.Text = thename & ": " & thevalue & "  "
    Else
      Layoutroot.Text = thevalue & "  "

    End If
  End Sub
End Class
