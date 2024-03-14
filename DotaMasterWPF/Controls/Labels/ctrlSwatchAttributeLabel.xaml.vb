Public Class ctrlSwatchAttributeLabel
  Implements iControlIO, iGraphable



  Private myStattype As eStattype
  Private mTeamStat As Stat

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

  Private mTeamBrush As SolidColorBrush
  Private mTeam As dTeam

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(curtime As ddFrame, _
                    thestat As Stat, _
                   headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                   thevalcolor As SolidColorBrush, thefontsize As Double, _
                   theprefix As String, thesuffix As String, _
                   teambrush As SolidColorBrush, verticalorientaton As Boolean, team As dTeam) '

    InitializeComponent()

    mTeamBrush = teambrush
    mTeam = team
    LoadMe(curtime, thestat, headingtextbrush, bodytextbrush, _
           thevalcolor, thefontsize, theprefix, thesuffix, verticalorientaton)

    mTooltip = New ToolTip
    Dim thick As New Thickness(0)
    ToolTipService.SetToolTip(Me, mTooltip)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

  End Sub


  Private Sub LoadMe(curtime As ddFrame, _
                  teamstat As Stat, _
                    headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                    thevalcolor As SolidColorBrush, thefontsize As Double, _
                    theprefix As String, thesuffix As String, _
                    verticalorientation As Boolean)

    myStattype = teamstat.StatType

    mTeamStat = teamstat

    mCurtime = curtime
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
      spnlValue.Margin = New Thickness(5, 0, 5, 10)
      spnlLabelOrientation.Children.Add(spnlValue)
      wpnlStatNameLabels.Margin = spnlValue.Margin
      spnlLabelOrientation.Children.Add(wpnlStatNameLabels)
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
      lblstatname.Height = 18
      lblstatname.FontSize = mfontSize
      lblstatname.Padding = New Thickness(0)
      lblstatname.Margin = New Thickness(0)
      wpnlStatNameLabels.Children.Add(lblstatname)
      If prefixes(i).Length > charlength Then charlength = prefixes(i).Length
    Next
    ''I hate wpf for making me do hacks like this. just tell me how wide you are you pima
    'colStatnameoricon.MinWidth = charlength * mfontSize * 1.2

    Dim val As Double?
    If mTeamStat IsNot Nothing Then
      val = mTeamStat.Value(mCurtime)
      If val.HasValue Then
        Dim valdub As Double = val
        lblTeamStatValue.Content = mTeamStat.ValueWithFormatting(mCurtime)
      Else
        val = 0
        lblTeamStatValue.Content = val & mSuffix
      End If

    End If

    elpsSwatch.elpsSwatch.Fill = New SolidColorBrush(TeamStat.MyColor)


  End Sub

  Public Sub RefreshStat()
    ' mMyStat = mMyHerobuild.mGame.dbModifiers.GetStatByParentIDandType(mMyHerobuild.ID, myStattype)
    LoadMe()
  End Sub

  Public ReadOnly Property TeamStat As Stat
    Get
      Return mTeamStat
    End Get
  End Property


  Public Sub UpdateValue(curtime As ddFrame)

    mCurtime = curtime

    Dim val As Double?
    If mTeamStat IsNot Nothing Then
      val = mTeamStat.Value(mCurtime)
      If val.HasValue Then
        Dim valdub As Double = val
        lblTeamStatValue.Content = mTeamStat.ValueWithFormatting(mCurtime)
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

    Dim outstring As New List(Of List(Of String))
    outstring.AddRange(mTeamStat.GetFriendlyFormula(mCurtime))

    Dim tt As New ctrlText_Tooltip(outstring)
    mTooltip.Content = tt

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
      mylist.Add(mTeamStat)
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
      Return New Graph_Preferences(eBarType.Value, eChartType.Stacked, eChartType.Stacked)
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
