Public Class ctrlSwatchDataItemLabel
  Implements iControlIO, iGraphable



  'Private myStattype As eStattype
  Private mdataitem As iDataItem

  Private mCurtime As ddFrame
  Public mTooltip As ToolTip

  Private mValBrush As SolidColorBrush
  Private mHeadingTextBrush As SolidColorBrush
  Private mBodyTextBrush As SolidColorBrush
  Private mfontSize As Integer

  Private mIsSelected As Boolean = False
  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Private mPrefix As String
  Private mSuffix As String
  'Private mDecimalPlaces As Integer

  'Private mTeamBrush As SolidColorBrush
  Private mTeam As dTeam
  Private mGame As dGame

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(dataitem As iDataItem, _
                   headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                   thevalcolor As SolidColorBrush, thefontsize As Double, _
                   theprefix As String, thesuffix As String, _
                    verticalorientaton As Boolean, game As dGame) '

    InitializeComponent()

    mGame = game

    LoadMe(dataitem, headingtextbrush, bodytextbrush, _
           thevalcolor, thefontsize, theprefix, thesuffix, verticalorientaton)

    mTooltip = New ToolTip
    Dim thick As New Thickness(0)
    ToolTipService.SetToolTip(Me, mTooltip)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

  End Sub


  Private Sub LoadMe(dataitem As iDataItem, _
                    headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                    thevalcolor As SolidColorBrush, thefontsize As Double, _
                    theprefix As String, thesuffix As String, _
                    verticalorientation As Boolean)

    '  myStattype = teamstat.StatType

    Dim parent As iGameEntity = dataitem.ParentGameEntity
    Do Until Not mTeam Is Nothing

      mTeam = mGame.GetTeamFromGameEntity(parent)
      parent = parent.ParentGameEntity

    Loop

    mdataitem = dataitem

    mCurtime = mGame.TimeKeeper.CurrentTime
    mPrefix = theprefix
    mSuffix = thesuffix
    '    mDecimalPlaces = thedecimalplaces

    mfontSize = thefontsize
    mValBrush = thevalcolor
    mHeadingTextBrush = headingtextbrush
    mBodyTextBrush = bodytextbrush

    If verticalorientation Then
      spnlLabelOrientation.Orientation = Orientation.Vertical
    Else
      spnlLabelOrientation.Orientation = Orientation.Horizontal

      spnlLabelOrientation.Children.Clear()
      spnlValue.Margin = New Thickness(0)
      spnlValue.VerticalAlignment = Windows.VerticalAlignment.Center
      wpnlStatNameLabels.Margin = New Thickness(0)
      spnlLabelOrientation.Children.Add(spnlValue)
      wpnlStatNameLabels.Margin = New Thickness(5, 0, 5, 0)
      spnlLabelOrientation.Children.Add(wpnlStatNameLabels)
      Me.Margin = New Thickness(0, 0, 0, 10)


    End If

    lblTeamStatValue.Foreground = mHeadingTextBrush
    lblTeamStatValue.FontFamily = Constants.cBodyFont
    lblTeamStatValue.FontSize = mfontSize

    rectGraphed.Visibility = Windows.Visibility.Collapsed
    rectGraphed.Stroke = New SolidColorBrush(PageHandler.dbColors.GraphedColor)

    LoadMe()

  End Sub

  Private Sub LoadMe()




    Dim prefixes = mPrefix.Split(" ")
    Dim charlength As Integer = 0
    For i As Integer = 0 To prefixes.Count - 1

      Dim lblstatname As New Label
      lblstatname.Content = prefixes(i) & " "
      lblstatname.VerticalAlignment = TextAlignment.Center
      lblstatname.HorizontalAlignment = Windows.HorizontalAlignment.Center
      lblstatname.VerticalContentAlignment = Windows.VerticalAlignment.Center
      lblstatname.HorizontalContentAlignment = Windows.HorizontalAlignment.Center
      lblstatname.Foreground = mBodyTextBrush
      lblstatname.FontFamily = Constants.cBodyFont
      ' lblstatname.Height = 18
      lblstatname.FontSize = mfontSize
      lblstatname.Padding = New Thickness(0)
      lblstatname.Margin = New Thickness(0)
      wpnlStatNameLabels.Children.Add(lblstatname)
      If prefixes(i).Length > charlength Then charlength = prefixes(i).Length
    Next
    ''I hate wpf for making me do hacks like this. just tell me how wide you are you pima
    'colStatnameoricon.MinWidth = charlength * mfontSize * 1.2

    Dim val As Double?
    If mdataitem IsNot Nothing Then
      val = mdataitem.Value(mCurtime)
      If val.HasValue Then
        Dim valdub As Double = val
        lblTeamStatValue.Content = mdataitem.ValueWithFormatting(mCurtime)
      Else
        val = 0
        lblTeamStatValue.Content = val & mSuffix
      End If

    End If

    elpsSwatch.elpsSwatch.Fill = New SolidColorBrush(Me.Dataitem.MyColor)


  End Sub

  Public Sub RefreshStat()
    ' mMyStat = mMyHerobuild.mGame.dbModifiers.GetStatByParentIDandType(mMyHerobuild.ID, myStattype)
    LoadMe()
  End Sub

  Public ReadOnly Property Dataitem As iDataItem
    Get
      Return mdataitem
    End Get
  End Property


  Public Sub UpdateValue(curtime As ddFrame)

    mCurtime = curtime

    Dim val As Double?
    If mdataitem IsNot Nothing Then
      val = mdataitem.Value(mCurtime)
      If val.HasValue Then
        Dim valdub As Double = val
        lblTeamStatValue.Content = mdataitem.ValueWithFormatting(mCurtime)
      Else
        val = 0
        lblTeamStatValue.Content = val & mSuffix
      End If

    End If



  End Sub
  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    mIsSelected = True
    RaiseEvent GraphableSelected(Me)
  End Sub

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)

    If mdataitem.MyType = eSourceType.Stat Then
      Dim mystat As Stat = DirectCast(mdataitem, Stat)
      Dim outstring As New List(Of List(Of String))
      outstring.AddRange(mystat.GetFriendlyFormula(mCurtime))


      Dim tt As New ctrlText_Tooltip(outstring)
      mTooltip.Content = tt

    End If


  End Sub



  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property



  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    mIsSelected = isselected
  End Sub



  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      Dim outlist As New List(Of List(Of iDataItem))
      Dim mylist As New List(Of iDataItem)
      mylist.Add(mdataitem)
      Dim otherteamsemptylist As New List(Of iDataItem)

      Select Case mTeam.TeamName
        Case eTeamName.Radiant
          outlist.Add(mylist)
          outlist.Add(otherteamsemptylist)
        Case eTeamName.Dire
          outlist.Add(otherteamsemptylist)
          outlist.Add(mylist)
        Case Else
          Throw New NotImplementedException
      End Select

      Return outlist
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      Dim title = mdataitem.ParentGameEntity.DisplayName & "' s " & mdataitem.DisplayName
      Return New Graph_Preferences(title, eBarType.Value, eChartType.Stacked, eChartType.Stacked)
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If isgraphed Then
      rectGraphed.Visibility = Windows.Visibility.Visible
    Else
      rectGraphed.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub
End Class
