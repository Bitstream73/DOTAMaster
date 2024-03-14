Public Class ctrlHScaleLabel
  Public Sub New( thecolor As SolidColorBrush)
    InitializeComponent()


    rectBackground.Fill = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
    rectBackground.Stroke = thecolor
    lblTime.Foreground = thecolor

  End Sub

  Public ReadOnly Property MyWidth As Double
    Get
      Return rectBackground.Width
    End Get
  End Property

  Public Sub Setabel( thestring As String)
    lblTime.Content = thestring
  End Sub
  Public Sub SetTime(time As String)
    lblTime.Content = time
    'need to get time from list(of string) times passed in
    'If thetime.count = 0 Then
    '  Dim x = 2
    'End If
    '    lblTime.Content = Helpers.GetFriendlyTime(thetime)
  End Sub
End Class
