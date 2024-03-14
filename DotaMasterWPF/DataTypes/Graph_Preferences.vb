Public Class Graph_Preferences

  Private mGraphType As eGraphType
  Private mBarType As eBarType
  Private mChartType As eChartType
  Private mTitle As String
  Public Sub New(title As String, graphtype As eGraphType, bartype As eBarType, charttype As eChartType)
    mBarType = bartype
    mChartType = charttype
    mGraphType = graphtype
    mTitle = title
  End Sub

  Public ReadOnly Property GraphType As eGraphType
    Get
      Return mGraphType
    End Get
  End Property
  Public ReadOnly Property BarType As eBarType
    Get
      Return mBarType
    End Get
  End Property

  Public ReadOnly Property ChartType As eChartType
    Get
      Return mChartType
    End Get
  End Property

  Public ReadOnly Property Title As String
    Get
      Return mTitle
    End Get
  End Property
End Class
