Public Class ctrlSummaryBar
  Implements iGraphable

  Private mDataitem As iDataItem
  Private mMaxval As Double
  Private mTeam As dTeam

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Event DataItemHovered(sender As ctrlSummaryBar)
  Public Event DataItemUnhovered(sender As ctrlSummaryBar)
  Public Sub New(dataitem As iDataItem, color As SolidColorBrush, _
                 barwidth As GridLength, margin As GridLength, team As dTeam)

    InitializeComponent()

    rectBar.Fill = color
    colBar.Width = barwidth
    colLeftMargin.Width = margin
    colRightMargin.Width = margin

    mTeam = team

    mDataitem = dataitem
    Dim maxv = mDataitem.MaxValue
    If Not maxv Is Nothing Then
      If maxv >= 0 Then
        mMaxval = maxv
      Else
        mMaxval = 0
      End If
    Else
      mMaxval = 0
    End If
    rectBaseline.Fill = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeave, AddressOf Me_MouseLeave
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    rectGraphSelected.Stroke = New SolidColorBrush(PageHandler.dbColors.GraphedColor)
  End Sub

  Public Sub Update(curtime As ddFrame)
    Dim val = mDataitem.Value(curtime)
    If val Is Nothing Then val = 0
    If val < 0 Then val = 0

    rowBar.Height = New GridLength(val, GridUnitType.Star)
    rowTopMargin.Height = New GridLength(mMaxval - val, GridUnitType.Star)

  End Sub

  Public ReadOnly Property DataItem As iDataItem
    Get
      Return mDataitem
    End Get
  End Property
  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      Select Case mTeam.TeamName
        Case eTeamName.Radiant
          Dim radlist As New List(Of iDataItem)
          radlist.Add(mDataitem)
          Dim direlist As New List(Of iDataItem)

          Dim outlist As New List(Of List(Of iDataItem))
          outlist.Add(radlist)
          outlist.Add(direlist)
          Return outlist

        Case eTeamName.Dire
          Dim radlist As New List(Of iDataItem)

          Dim direlist As New List(Of iDataItem)
          direlist.Add(mDataitem)

          Dim outlist As New List(Of List(Of iDataItem))
          outlist.Add(radlist)
          outlist.Add(direlist)
          Return outlist


        Case Else

          Throw New NotImplementedException
      End Select
      Return Nothing
    End Get

    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      Dim title = mDataitem.ParentGameEntity.DisplayName & "'s " & mDataitem.DisplayName
      Return New Graph_Preferences(title, eGraphType.TeamsStacked, eBarType.Value, eChartType.Stacked)
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
