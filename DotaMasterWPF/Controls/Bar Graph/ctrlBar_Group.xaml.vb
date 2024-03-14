Public Class ctrlBar_Group
  Private mBars As New List(Of ctrlBar)
  'Private mMaxValue As Double
  Private mTotalValue As Double
  'Private mMaxBarHeight As Double

  'builds a bar group out of ctrlbars each with their own big source color
  Dim startrow As RowDefinition
  Dim endrow As RowDefinition
  Public Sub New(ByVal thebars As List(Of ctrlBar))
    InitializeComponent()

    mBars = thebars
    'mMaxBarHeight = maxbarheight

    CalcTotalValue()

    startrow = New RowDefinition
    startrow.Height = New GridLength(0, GridUnitType.Star)
    LayoutRoot.RowDefinitions.Add(startrow)

    For i As Integer = 0 To mBars.Count - 1

      Dim curbar = thebars.Item(i)




      Dim newrow As New RowDefinition
      newrow.Height = New GridLength(curbar.TotalValue, GridUnitType.Star)
      LayoutRoot.RowDefinitions.Add(newrow)

      curbar.SetValue(Grid.RowProperty, i + 1)
      LayoutRoot.Children.Add(curbar)

    Next

    endrow = New RowDefinition
    startrow.Height = New GridLength(0, GridUnitType.Star)
    LayoutRoot.RowDefinitions.Add(endrow)

  End Sub

  Public Sub SetMargin(ByVal themargins As System.Windows.Thickness)

    LayoutRoot.Margin = themargins
  End Sub

  Public Sub New(ByVal thebar As ctrlBar)
    InitializeComponent()

    mBars.Add(thebar)

    mTotalValue = thebar.TotalValue


    Dim newrow As New RowDefinition
    newrow.Height = New GridLength(thebar.TotalValue, GridUnitType.Star)
    LayoutRoot.RowDefinitions.Add(newrow)

    thebar.SetValue(Grid.RowProperty, 0)
    LayoutRoot.Children.Add(thebar)



  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="atbeginning">if true inserts at index 0, if false adds at end</param>
  ''' <param name="maxheight"></param>
  ''' <remarks></remarks>
  Public Sub SetFillerHeight(ByVal atbeginning As Boolean, ByVal maxheight As Double)

    Dim thestarheight = maxheight - mTotalValue
    If thestarheight = 0 Then
      Dim x = 2
    End If

    If thestarheight = 0 Then Exit Sub

    If atbeginning Then
      startrow.Height = New System.Windows.GridLength(thestarheight, GridUnitType.Star)
    Else
      endrow.Height = New System.Windows.GridLength(thestarheight, GridUnitType.Star)
    End If

    'If thestarheight > 0 Then
    '  Dim newrow As New RowDefinition
    '  newrow.Height = New GridLength(thestarheight, GridUnitType.Star)

    '  Dim rect As New Rectangle
    '  rect.Fill = New SolidColorBrush(Color.FromArgb(255, 164, 105, 0))

    '  If atbeginning Then
    '    LayoutRoot.RowDefinitions.Insert(0, newrow)
    '    rect.SetValue(Grid.RowProperty, 0)
    '  Else
    '    LayoutRoot.RowDefinitions.Add(newrow)
    '    rect.SetValue(Grid.RowProperty, LayoutRoot.Children.Count - 1)
    '  End If
    'End If





  End Sub
  Private Sub CalcTotalValue()
    mTotalValue = 0
    For i As Integer = 0 To mBars.Count - 1
      mTotalValue += mBars.Item(i).TotalValue
    Next
  End Sub

  Public ReadOnly Property TotalValue As Double
    Get
      Return mTotalValue
    End Get
  End Property
  Private Sub Me_SizeChanged(sender As Object, e As SizeChangedEventArgs)

  End Sub
End Class
