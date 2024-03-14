Public Class ctrlModText
  Dim lblValue As Label
  Public mUpdatableTinyDetails As New Dictionary(Of String, ctrlModTinyDetailsLabel)
  Public Sub New( thevalue As String,  thevalcolor As SolidColorBrush,  themodtext As String)

    InitializeComponent()

    If thevalcolor Is Nothing Then
      Dim x = 2
    End If

    Try
      Dim headc = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
      If Not themodtext.Contains("*") Then
        lblValue = New Label
        lblValue.Content = thevalue
        lblValue.Foreground = thevalcolor
        lblValue.FontFamily = Constants.cBodyFont
        lblValue.FontSize = Constants.cModifierFontSize
        LayoutRoot.Children.Add(lblValue)

        Dim lbltext As New Label
        lbltext.Content = " " & themodtext.Trim
        lbltext.Foreground = headc
        lbltext.FontFamily = Constants.cBodyFont
        lbltext.FontSize = Constants.cModifierFontSize
        LayoutRoot.Children.Add(lbltext)
      Else
        Dim strs = themodtext.Split("*")

        Dim lbltext As New Label
        lbltext.Content = strs(0).Trim & " "
        lbltext.Foreground = headc
        lbltext.FontFamily = Constants.cBodyFont
        lbltext.FontSize = Constants.cModifierFontSize
        LayoutRoot.Children.Add(lbltext)

        lblValue = New Label
        lblValue.Content = thevalue
        lblValue.Foreground = thevalcolor
        lblValue.FontFamily = Constants.cBodyFont
        lblValue.FontSize = Constants.cModifierFontSize
        LayoutRoot.Children.Add(lblValue)

        Dim lbltext2 As New Label
        lbltext2.Content = strs(1).Trim
        lbltext2.Foreground = headc
        lbltext2.FontFamily = Constants.cBodyFont
        lbltext2.FontSize = Constants.cModifierFontSize
        LayoutRoot.Children.Add(lbltext2)
      End If
    Catch ex As Exception
      Dim x = 2
    End Try

  End Sub

  Public Sub UpdateValue( thevalue As String)
    lblValue.Content = thevalue
  End Sub
End Class
