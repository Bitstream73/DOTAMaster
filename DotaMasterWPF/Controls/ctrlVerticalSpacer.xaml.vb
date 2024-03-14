Public Class ctrlVerticalSpacer
  Public Sub New()
    InitializeComponent()
    rowSpacerHeight.Height = New GridLength(5)
  End Sub

  Public Sub New( pixelheight As Double)
    InitializeComponent()

    rowSpacerHeight.Height = New GridLength(pixelheight)
  End Sub
End Class
