#Const devmode = True
Public Class TeamvsTeam
  Implements iGraphable

  Public mGame As dGame
  Private mID As dvID
  Private mGraph As ctrlBargraph_Panes_Fixedwidth
  Private mRadBadges As New List(Of ctrlHero_Badge)
  Private mDireBadges As New List(Of ctrlHero_Badge)

  'Private mChart As ctrlBargraph_Canvas
  Private mTestMods As New ModifierList
  Private mTestColors As New List(Of SolidColorBrush)
  Private mTestBars As New List(Of ctrlBar)
  'Private mTestBarBits As New List(Of ctrlBar_Bit)

  Private brshRadiant As SolidColorBrush
  Private brshDire As SolidColorBrush

  'Private ctrlDetails As New ctrlGeneric_Details

  'Targetting
  Public ctrlRadiantTargetBadge As ctrlTargetBadge
  Public ctrlDireTargetBadge As ctrlTargetBadge

  'views
  Private ctrlBadgeAppearnce As ctrlBadgeAppearance
  Private ctrlBarType As ctrlBar_Type
  Private ctrlChartType As ctrlChart_Type

  'Details
  Private ctrlDetails_Handler As ctrlDetailsHandler

  Dim testID As Guid = Guid.NewGuid()

  'Private mGraph As ctrlBargraph_Panes_Fixedwidth
  ' Private mChildGraph As ctrlBargraph_Panes_Fixedwidth

  Private mMyMods As List(Of Modifier)

  ' Private selectedCtrl As DDObject

  Private dbControls As Controls_Database


  Private mSelectedGraphed As iGraphable


  'colors
  Private mSelecteditemhighlightcolor As Color
  Private mGraphdividercolor As Color
  Private mHeadingtextcolor As Color
  Private mBodytextcolor As Color
  Private mRadcolor As Color
  Private mRadaccent As Color
  Private mDirecolor As Color
  Private mDireaccent As Color

  'events
  Public Event NewHeroPicked(newherobuild As HeroBuild, oldhero As HeroInstance, heroteam As dTeam, teamposition As Integer)

  Public Event GameEntitySelected(gameent As iGameEntity)

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  'Public Event ItemSelected(item As ctrlItem_Thumb)
  'Public Event AbilitySelected(ab As ctrlAblityThumb)
  'Public Event HeroSelected(h As ctrlHero_Badge)
  Public Event BadgeAppearanceChanged(appearance As eBadgeAppearance)
  Public Event TargetsChanged()

  Public Sub New(thegame As dGame, controlsdb As Controls_Database, _
                 slecteditemhighlightcolor As Color, _
                 graphdividercolor As Color, _
                 headingtextcolor As Color, _
                 bodytextcolor As Color, _
                 radcolor As Color, _
                 radaccent As Color, _
                 direcolor As Color, _
                 direaccent As Color) ' thegame As dGame)
    InitializeComponent()


    mSelecteditemhighlightcolor = mSelecteditemhighlightcolor
    mGraphdividercolor = graphdividercolor
    mHeadingtextcolor = headingtextcolor
    mBodytextcolor = bodytextcolor
    mRadcolor = radcolor
    mRadaccent = radaccent
    mDirecolor = direcolor
    mDireaccent = direaccent


    brshRadiant = New SolidColorBrush(radcolor)
    If brshRadiant.CanFreeze Then
      brshRadiant.Freeze()
    End If
    brshDire = New SolidColorBrush(direcolor)
    If brshDire.CanFreeze Then
      brshDire.Freeze()
    End If

    mHeadingtextcolor = headingtextcolor
    mBodytextcolor = bodytextcolor


    dbControls = controlsdb
    mGame = thegame
    mID = New dvID(Guid.NewGuid, "TeamvsTeam Added", eEntity.pgTeamvsTeam)


    LoadHeroBadges(thegame.GetHeroInstancesForTeam(eTeamName.Radiant), _
                   thegame.GetHeroInstancesForTeam(eTeamName.Dire))



    LoadUI()

    Dim curtime = New ddFrame(60)

    ShowHeroBadges()

  End Sub

  Private Sub ClearAllBadges(theteam As eTeamName)
    Select Case theteam
      Case eTeamName.Radiant
        mRadBadges.Clear()
      Case eTeamName.Dire
        mDireBadges.Clear()
      Case Else
        PageHandler.theLog.Writelog("ClearAllBadges Unhandled Type")
    End Select
  End Sub



  Public Sub LoadHeroBadge(thehero As iHeroUnit, theteam As dTeam, thebadgeindex As Integer)
    Dim thebadges As List(Of ctrlHero_Badge)
    Select Case theteam.TeamName
      Case eTeamName.Radiant
        thebadges = mRadBadges
      Case eTeamName.Dire
        thebadges = mDireBadges
      Case Else
        PageHandler.theLog.Writelog("LoadHeroBadge unhandled type")
        Throw New NotImplementedException
    End Select

    If thebadges.Count = 0 And thebadgeindex = 0 Then
      Dim thebadge As New ctrlHero_Badge(theteam, 0, mGame, New SolidColorBrush(mHeadingtextcolor), New SolidColorBrush(mBodytextcolor))
      AddHandler thebadge.NewHeroPicked, AddressOf HeroBadge_NewHeroPicked
      AddHandler thebadge.SelectedChanged, AddressOf HeroBadge_SelectionChanged

      thebadge.FillBadge(thehero)
      thebadges.Add(thebadge)
      Exit Sub
    End If
    If thebadgeindex < thebadges.Count Then
      Dim curbadge = thebadges.Item(thebadgeindex)
      curbadge.FillBadge(thehero)
    Else
      For i As Integer = thebadges.Count To thebadgeindex

        If thebadgeindex = i Then
          Dim thebadge As New ctrlHero_Badge(theteam, thebadgeindex, mGame, New SolidColorBrush(mHeadingtextcolor), New SolidColorBrush(mBodytextcolor))
          AddHandler thebadge.NewHeroPicked, AddressOf HeroBadge_NewHeroPicked
          AddHandler thebadge.SelectedChanged, AddressOf HeroBadge_SelectionChanged
          thebadge.FillBadge(thehero)
          thebadges.Add(thebadge)
        Else
          Dim thebadge As New ctrlHero_Badge(theteam, thebadges.Count, mGame, New SolidColorBrush(mHeadingtextcolor), New SolidColorBrush(mBodytextcolor))
          AddHandler thebadge.NewHeroPicked, AddressOf HeroBadge_NewHeroPicked
          AddHandler thebadge.SelectedChanged, AddressOf HeroBadge_SelectionChanged
          thebadges.Add(thebadge)
        End If

      Next

    End If

  End Sub
  Private Sub LoadHeroBadges(theradheroes As List(Of iHeroUnit), thedireheroes As List(Of iHeroUnit))


    For i As Integer = 0 To theradheroes.Count - 1
      Me.LoadHeroBadge(theradheroes.Item(i), mGame.RadiantTeam, i)
    Next

    For i As Integer = 0 To thedireheroes.Count - 1
      Me.LoadHeroBadge(thedireheroes.Item(i), mGame.DireTeam, i)
    Next
  End Sub

  Private Sub ShowHeroBadges()

    dpnlRadiant.Children.Clear()
    dpnlDire.Children.Clear()

    Dim rpnl As New StackPanel
    rpnl.Orientation = Orientation.Vertical

    Dim dpnl As New StackPanel
    dpnl.Orientation = Orientation.Vertical
    For i As Integer = 0 To mRadBadges.Count - 1
      rpnl.Children.Add(mRadBadges.Item(i))
    Next
    dpnlRadiant.Children.Add(rpnl)

    For i As Integer = 0 To mDireBadges.Count - 1
      dpnl.Children.Add(mDireBadges.Item(i))
    Next
    dpnlDire.Children.Add(dpnl)
  End Sub

  Private Sub LoadUI()


    rectDireSwatch.Fill = brshDire
    rectRadSwatch.Fill = brshRadiant

    ' ctrlTimeDisplay.lblCurrentTime.Content = "00:00"

    ctrlDireTargetBadge = New ctrlTargetBadge
    ctrlDireTargetBadge.HorizontalAlignment = Windows.HorizontalAlignment.Center
    'AddHandler ctrlDireTargetBadge.NewTargetSelected, AddressOf ctrlTargetBadge_TargetsChanged

    ctrlDireTargetBadge.Load(mGame.DireTeam, mGame.RadiantTeam, _
                      New SolidColorBrush(mHeadingtextcolor), _
                      New SolidColorBrush(mBodytextcolor))
    ctrlDireTargetBadge.UpdateTargets(mGame.DireTeam.EnemyTarget, mGame.DireTeam.FriendlyTarget, mGame.DireTeam.TargetFriendlyBias)

    spnlDireTarget.Children.Add(ctrlDireTargetBadge)


    ctrlRadiantTargetBadge = New ctrlTargetBadge
    ctrlRadiantTargetBadge.HorizontalAlignment = Windows.HorizontalAlignment.Center
    'AddHandler ctrlRadiantTargetBadge.NewTargetSelected, AddressOf ctrlTargetBadge_TargetsChanged

    ctrlRadiantTargetBadge.Load(mGame.RadiantTeam, mGame.DireTeam, _
                                New SolidColorBrush(mHeadingtextcolor), _
                                New SolidColorBrush(mBodytextcolor))
    ctrlRadiantTargetBadge.UpdateTargets(mGame.RadiantTeam.EnemyTarget, mGame.RadiantTeam.FriendlyTarget, mGame.RadiantTeam.TargetFriendlyBias)

    spnlRadiantTarget.Children.Add(ctrlRadiantTargetBadge)

    Dim headingbrush As New SolidColorBrush(mHeadingtextcolor)
    Dim bodybrush As New SolidColorBrush(mBodytextcolor)
    ctrlBadgeAppearnce = New ctrlBadgeAppearance(mGame.dbColors, eBadgeAppearance.Full, _
                                                 headingbrush, bodybrush)

    AddHandler ctrlBadgeAppearnce.BadgeAppearanceChanged, AddressOf Badges_AppearanceChanged

    spnlGameFooter.Children.Add(ctrlBadgeAppearnce)

    Dim dividerbrush As New SolidColorBrush(mGame.dbColors.ScaleWeakColor)
    Dim divider1 As New Rectangle
    divider1.Width = 1
    divider1.Fill = dividerbrush
    divider1.Margin = New Thickness(5)

    spnlGameFooter.Children.Add(divider1)

    ctrlBarType = New ctrlBar_Type(mGame.dbColors, eBarType.Team, _
                                   headingbrush, bodybrush)

    spnlGameFooter.Children.Add(ctrlBarType)

    Dim divider2 As New Rectangle
    divider2.Width = 1
    divider2.Fill = dividerbrush
    divider2.Margin = New Thickness(5)

    spnlGameFooter.Children.Add(divider2)


    ctrlChartType = New ctrlChart_Type(mGame.dbColors, eChartType.Split, _
                                       headingbrush, bodybrush)

    spnlGameFooter.Children.Add(ctrlChartType)


    mGraph = dbControls.GetGraph(mGame.TimeKeeper.TimePoints.TheFrames.Count, _
                      mGame.TimeKeeper.FriendlyTimes, _
                      eBarType.Team, eGraphType.VersusSplitBars, _
                      mGraphdividercolor, mSelecteditemhighlightcolor, _
                      mRadcolor, mRadaccent, _
                      mDirecolor, mDireaccent, _
                      ctrlBarType, ctrlChartType)

    ChartRoot.Children.Add(mGraph)

    ctrlNavigationBar.Load(mGame)

    ctrlDetails_Handler = New ctrlDetailsHandler(mGame, dbControls)
    AddHandler ctrlDetails_Handler.GraphableSelected, AddressOf ChildControl_GraphableSelected

    spnlDetails.Children.Add(ctrlDetails_Handler)

  End Sub

  Public ReadOnly Property Graph As ctrlBargraph_Panes_Fixedwidth
    Get
      Return mGraph
    End Get
  End Property

#Region "ModsIO"
  Public Sub CalcMods()

  End Sub
#End Region



#Region "Loaders"

  Public Sub LoadDetails(detailsitem As iGameEntity)
    ctrlDetails_Handler.AddDetails(detailsitem)
    ctrlNavigationBar.BackFillMenuItems(ctrlDetails_Handler.MyDetailsGameEntity)
  End Sub
  'Public Sub LoadHerovHeroDetails(radhero As HeroInstance, _
  '                                direhero As HeroInstance)


  '  Dim radstats As New HeroStatPackage(radhero, mGame)
  '  Dim direstats As New HeroStatPackage(direhero, mGame)
  '  Dim hvh As New ctrlHerovHeroDetails(mGame.TimeKeeper.CurrentTime, _
  '                                      radhero, radstats, _
  '                                      direhero, direstats,
  '                                      dbControls)
  '  mVisibleDetails = hvh
  '  spnlDetails.Children.Clear()
  '  spnlDetails.Children.Add(hvh)
  'End Sub

  'Public Sub LoadTeamvTeamDetails(radteam As dTeam, direteam As dTeam)
  '  Dim radstats As New TeamStatPackage(radteam, mGame)
  '  Dim direstats As New TeamStatPackage(direteam, mGame)
  '  Dim tvt As New ctrlTeamvTeamDetails(mGame.TimeKeeper.CurrentTime, radstats, direstats, dbControls)
  '  mVisibleDetails = tvt
  '  spnlDetails.Children.Clear()
  '  spnlDetails.Children.Add(tvt)


  'End Sub
#End Region



#Region "Setters"



  Public Sub SetBadgeAppearance(appearance As eBadgeAppearance)
    For i = 0 To mRadBadges.Count - 1
      mRadBadges.Item(i).ChangeAppearance(appearance)
    Next

    For i = 0 To mDireBadges.Count - 1
      mDireBadges.Item(i).ChangeAppearance(appearance)
    Next
  End Sub
  'Public Sub SetGraphTime(thetime As ddFrame)
  '  mGraph.SetSelectedTime(thetime)

  'End Sub



#End Region

#Region "Updaters"
  'Public Sub UpdateCtrlDetails(thecurrenttime As ddFrame)

  '  ctrlDetails.UpdateExistingDetails(thecurrenttime)
  'End Sub

  'Public Sub UpdateModifierDropdowns(themods As List(Of eModifierType))
  '  mGraph.UpdateModifierDropDowns(themods)
  'End Sub
#End Region



  Public Sub UpdateCurrentTime()
    Dim curtime = mGame.TimeKeeper.CurrentTime
    For i = 0 To mRadBadges.Count - 1
      mRadBadges.Item(i).SetCurrentTime(curtime)
    Next
    For i = 0 To mDireBadges.Count - 1
      mDireBadges.Item(i).SetCurrentTime(curtime)
    Next

    'ctrlTimeDisplay.lblCurrentTime.Content = Helpers.GetFriendlyTime(curtime)

    ctrlDetails_Handler.UpdateTime(curtime)
  End Sub






  Private Sub HeroBadge_NewHeroPicked(newherobuild As HeroBuild, oldhero As HeroInstance, heroteam As dTeam, teamposition As Integer)

    RaiseEvent NewHeroPicked(newherobuild, oldhero, heroteam, teamposition)
  End Sub

  Private Sub HeroBadge_SelectionChanged(gameentity As iGameEntity)
    RaiseEvent GameEntitySelected(gameentity)
  End Sub

  Private Sub Badges_AppearanceChanged(appearance As eBadgeAppearance)
    RaiseEvent BadgeAppearanceChanged(appearance)
  End Sub





  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mSelectedGraphed Is Nothing Then
        Return mSelectedGraphed.GraphDataItems
      End If
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedGraphed Is Nothing Then
        Return mSelectedGraphed.GraphPreferences
      End If
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property
  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedGraphed Is Nothing Then
      mSelectedGraphed.SetGraphed(isgraphed)
    End If
  End Sub

  Private Sub ChildControl_GraphableSelected(sender As iGraphable)
    mSelectedGraphed = sender
    RaiseEvent GraphableSelected(mSelectedGraphed)
  End Sub

End Class
