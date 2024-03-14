Public Class ctrlVScaleLabel
  Public Sub New( thecolor As SolidColorBrush)
    InitializeComponent()


    If Not thecolor.Color = PageHandler.dbColors.Transparent Then
      rectBackground.Fill = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
      rectBackground.Stroke = thecolor
    Else
      rectBackground.Fill = thecolor
      rectBackground.StrokeThickness = 0
    End If


    lblTime.Foreground = thecolor

  End Sub

  Public ReadOnly Property MyWidth As Double
    Get
      Return rectBackground.Width
    End Get
  End Property

  Public Sub SetLabel(thestring As String)
    lblTime.Content = thestring
  End Sub
  Public Sub SetTime( thetime As ddFrame)
    'If thetime.count = 0 Then
    '  Dim x = 2
    'End If
    lblTime.Content = Helpers.GetFriendlyTime(thetime)
  End Sub
End Class
