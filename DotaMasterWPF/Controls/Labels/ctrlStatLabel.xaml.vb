Public Class ctrlStatLabel
  Public Sub New( thestatname As String,  theval As String,  thevalcolor As SolidColorBrush)
    InitializeComponent()

    LoadMe(thestatname, theval, thevalcolor, Constants.cBodyFontSize)


  End Sub

  Public Sub New( thestatname As String,  theval As String,  thevalcolor As SolidColorBrush,  thefontsize As Double) '

    InitializeComponent()
    LoadMe(thestatname, theval, thevalcolor, thefontsize)
  End Sub

  Private Sub LoadMe( thestatname As String,  theval As String,  thevalcolor As SolidColorBrush,  thefontsize As Double)
    If Not theval = "" Then
      lblStatName.Content = thestatname.ToUpper & ": "
      lblStatName.Foreground = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
    Else
      lblStatName.Content = thestatname
      lblStatName.Foreground = thevalcolor
    End If

    lblStatName.FontFamily = Constants.cBodyFont
    lblStatName.FontSize = thefontsize
    lblStatName.Foreground = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
    ' lblStatName.CharacterSpacing = 100

    lblStatValue.Content = theval
    lblStatValue.Foreground = thevalcolor
    lblStatValue.FontFamily = Constants.cBodyFont
    lblStatValue.FontSize = thefontsize
    'lblStatValue.CharacterSpacing = 100


  End Sub
End Class
