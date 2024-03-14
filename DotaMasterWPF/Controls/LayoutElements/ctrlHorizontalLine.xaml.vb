Public Class ctrlHorizontalLine
  Public Sub New(leftmarginpercentage As Decimal, rightmarginpercentage As Decimal, linethickness As Integer, linecolor As SolidColorBrush) ', opacity As Double)
    InitializeComponent()


    Dim midstar = (1 - (leftmarginpercentage + rightmarginpercentage)) * 100
    If midstar < 1 Then
      midstar = 0
    End If


    colLeftMargin.Width = New GridLength(leftmarginpercentage * 100, GridUnitType.Star)

    colRightMargin.Width = New GridLength(rightmarginpercentage * 100, GridUnitType.Star)

    colLine.Width = New GridLength(midstar, GridUnitType.Star)
    rectLine.Height = linethickness

    rectLine.Fill = linecolor
    rectLine.Opacity = 0.5
  End Sub
End Class
