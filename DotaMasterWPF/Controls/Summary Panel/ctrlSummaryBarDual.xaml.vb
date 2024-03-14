Public Class ctrlSummaryBarDual
  Implements iGraphable

  Private mRadDataitem As iDataItem
  Private mDireDataitem As iDataItem
  Private mMaxval As Double

  Private mRadcolor As SolidColorBrush
  Private mDirecolor As SolidColorBrush
  Private mNeutralColor As SolidColorBrush

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Event DataItemHovered(sender As ctrlSummaryBar)
  Public Event DataItemUnhovered(sender As ctrlSummaryBar)
  Public Sub New(raddataitem As iDataItem, diredataitem As iDataItem, _
                 color As SolidColorBrush, _
                 barwidth As GridLength, margin As GridLength, _
                 neutralcolor As SolidColorBrush, _
                 radcolor As SolidColorBrush, direcolor As SolidColorBrush)

    InitializeComponent()

    rectRadBar.Fill = color
    rectDireBar.Fill = color

    colBar.Width = barwidth
    colLeftMargin.Width = margin
    colRightMargin.Width = margin


    mRadDataitem = raddataitem
    mDireDataitem = diredataitem

    mRadcolor = radcolor
    mDirecolor = direcolor
    mNeutralColor = neutralcolor

    mMaxval = GetMaxValue(mRadDataitem, mDireDataitem)

    rectBaseline.Fill = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeave, AddressOf Me_MouseLeave
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    rectGraphSelected.Stroke = New SolidColorBrush(PageHandler.dbColors.GraphedColor)
  End Sub

  Private Function GetMaxValue(mRadDataitem As iDataItem, diredataitem As iDataItem) As Double

    Dim maxv = mRadDataitem.MaxValue
    If Not maxv Is Nothing Then
      If maxv < 0 Then
        maxv = 0
      End If
    Else
      maxv = 0
    End If

    Dim diremaxv = mDireDataitem.MaxValue
    If Not diremaxv Is Nothing Then
      If diremaxv > maxv Then Return diremaxv
      Return maxv
    Else
      Return maxv
    End If
  End Function
  Public Sub Update(curtime As ddFrame)
    Dim rval = mRadDataitem.Value(curtime)
    If rval Is Nothing Then rval = 0
    If rval < 0 Then rval = 0

    rowRadBar.Height = New GridLength(rval, GridUnitType.Star)
    rowTopMargin.Height = New GridLength(mMaxval - rval, GridUnitType.Star)

    Dim dval = mDireDataitem.Value(curtime)
    If dval Is Nothing Then dval = 0
    If dval < 0 Then dval = 0

    rowDireBar.Height = New GridLength(dval, GridUnitType.Star)
    rowBottomMargin.Height = New GridLength(mMaxval - dval, GridUnitType.Star)

    If rval > dval Then
      rectBaseline.Fill = mRadcolor
    Else
      If Not rval = dval Then
        rectBaseline.Fill = mDirecolor
      Else
        rectBaseline.Fill = mNeutralColor
      End If
    End If

  End Sub


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get

      Dim radlist As New List(Of iDataItem)
      radlist.Add(mRadDataitem)
      Dim direlist As New List(Of iDataItem)
      direlist.Add(mDireDataitem)

      Dim outlist As New List(Of List(Of iDataItem))
      outlist.Add(radlist)
      outlist.Add(direlist)

      Return outlist


    End Get

    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      Dim title = mRadDataitem.ParentGameEntity.DisplayName & "'s & " & mDireDataitem.ParentGameEntity.DisplayName & "'s " & mRadDataitem.DisplayName
      Return New Graph_Preferences(title, eGraphType.Advantage, eBarType.Team, eChartType.Advantage)
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property
  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If isgraphed Then
      rectGraphSelected.Visibility = Windows.Visibility.Visible
    Else
      rectGraphSelected.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)
    RaiseEvent DataItemHovered(sender)
  End Sub

  Private Sub Me_MouseLeave(sender As Object, e As MouseEventArgs)
    RaiseEvent DataItemUnhovered(sender)
  End Sub

  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    RaiseEvent GraphableSelected(Me)
  End Sub
End Class
