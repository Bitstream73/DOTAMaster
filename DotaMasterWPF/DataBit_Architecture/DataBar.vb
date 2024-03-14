Public Class DataBar
  Inherits List(Of DataBit)
  Public mZoomLevel As eZoomLevel
  Public mSource As eUnit

  Public ReadOnly Property Value As Double
    Get
      Dim outval As Double
      For i As Integer = 0 To Me.Count - 1
        outval += Me.Item(i).mValue
      Next
      Return outval
    End Get
  End Property

End Class
