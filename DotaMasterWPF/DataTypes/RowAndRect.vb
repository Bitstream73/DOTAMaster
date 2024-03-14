Public Class RowAndRect
  Public mRow As New RowDefinition
  Public mRect As New Rectangle

  Public Sub New()
    mRect.Width = 100
    mRect.SnapsToDevicePixels = True
    mRect.HorizontalAlignment = HorizontalAlignment.Stretch
    mRect.VerticalAlignment = VerticalAlignment.Stretch
    mRect.Margin = New Thickness(0)
    mRect.StrokeThickness = 0
  End Sub
End Class
