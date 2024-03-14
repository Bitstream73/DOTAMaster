Imports System.IO
Imports System.Windows.Resources
Imports System.Windows.Media.Imaging
#Const Devmode = True

Class PageHandler

  Private mID As dvID

  Private mGame As dGame

  Private mGraph As ctrlBargraph_Panes_Fixedwidth

  Public Shared NoParentID As dvID

  Private mSelectedItemhighlightColor As Color

  Public Shared dbColors As Colors_Database
  Public Shared dbFriendlyNames As FriendlyName_Database

  Public Shared dbImages As Image_Database
  Public Shared dbControls As Controls_Database
  Public Shared theLog As iLogging
  Public Shared mSettings As New Settings

  'Pages
  Private TeamvTeam As TeamvsTeam
  Dim loadscn As LoadingScreen

  Private curSelected As iControlIO
  Private curSelectedGraphed As iGraphable

  Private mHeroInstFactory As HeroInstanceFactory
  Public Sub New()

    InitializeComponent()

    loadscn = New LoadingScreen()
    AddHandler loadscn.WorkComplete, AddressOf load_WorkComplete

    Me.Overlays.Children.Add(loadscn)
    Me.Overlays.Visibility = Windows.Visibility.Visible

  End Sub


  Private Sub load_WorkComplete(startitems As StartupItems)

    If Not Me.CheckAccess Then
      Dispatcher.Invoke(Sub()
                          Dim y = 2
                          Me.load_WorkComplete(startitems)
                          Dim x = 2
                        End Sub)
      Exit Sub
    End If

    Dim swatch As New Stopwatch
    swatch.Start()

    theLog = startitems.theLog

    mID = startitems.mID

    NoParentID = startitems.NoParentID

    dbColors = startitems.dbColors

    dbFriendlyNames = startitems.dbNames

    mGame = New dGame(startitems.dbItems, _
                      startitems.dbAbilities, _
                      startitems.dbHeroBuilds, _
                      startitems.dbCreeps, _
                      startitems.dbFormulas, _
                      startitems.dbNames, _
                      startitems.mTimeKeeper, _
                      startitems.theLog, _
                      dbColors)

    mGame.LoadStartup()


    dbImages = startitems.dbimages

    loadscn.UpdateStatus("Loading Interface")
    dbControls = New Controls_Database(theLog, _
                                       mGame, _
                                       dbImages, _
                                       startitems.dbHeroBuilds.GetFirstBuildForAllHeroes(), _
                                       startitems.dbItems.GetAllItemInfosNoParent(), _
                                       dbColors)

    loadscn.UpdateStatus("Loading Game")

    Dim ti As New Stopwatch
    ti.Start()


    TeamvTeam = New TeamvsTeam(mGame, dbControls, _
                               dbColors.SelectedColor, dbColors.IntColor, _
                               dbColors.HeadingTextColor, dbColors.BodyTextColor,
                               dbColors.RadiantColor, dbColors.RadiantAccentColor, _
                               dbColors.DireColor, dbColors.DireAccentColor)

    AddHandler TeamvTeam.NewHeroPicked, AddressOf TvT_NewHeroPicked
    AddHandler TeamvTeam.GameEntitySelected, AddressOf TvT_GameEntitySelected
    AddHandler TeamvTeam.ctrlNavigationBar.GameEntitySelected, AddressOf Navigator_GameEntitySelected

    AddHandler TeamvTeam.BadgeAppearanceChanged, AddressOf TvT_BadgeAppearanceChanged
    AddHandler TeamvTeam.ctrlDireTargetBadge.NewTargetSelected, AddressOf TargetBadge_NewTargetSelected
    AddHandler TeamvTeam.ctrlRadiantTargetBadge.NewTargetSelected, AddressOf TargetBadge_NewTargetSelected

    ' AddHandler TeamvTeam.Graph.NewGraphItemSelected, AddressOf Graph_NewGraphItemSelected
    AddHandler TeamvTeam.Graph.TimeChanged, AddressOf Graph_TimeChanged

    AddHandler TeamvTeam.GraphableSelected, AddressOf TvT_GraphableSelected

    Dim rmods As New ModifierList(mGame.dbModifiers.GetModsByParentsAndType(mGame.GetAllHeroesForTeam(eTeamName.Radiant), eModifierType.BaseGold))
    Dim dmods As New ModifierList(mGame.dbModifiers.GetModsByParentsAndType(mGame.GetAllHeroesForTeam(eTeamName.Dire), eModifierType.BaseGold))

    Dim outmods As New List(Of ModifierList)
    outmods.Add(rmods)
    outmods.Add(dmods)

    Dim data = mGame.GetGraphData(outmods)

    Dim curtimeframe = mGame.TimeKeeper.TimePoints.TheFrames.Item(200)
    mGame.SetCurrentTime(curtimeframe)

    Dim outdataitems As New List(Of List(Of iDataItem))
    For i = 0 To outmods.Count - 1
      Dim outlist As New List(Of iDataItem)
      outlist.AddRange(outmods.Item(i))
      outdataitems.Add(outlist)

    Next


    'TeamvTeam.Graph.FillGraph(0, eBarType.Team, eGraphType.VersusSplitBars, data.thebardatalist, data.maxteamheight, data.maxheight, outdataitems)
    ' TeamvTeam.ctrlNavigationBar.Load(mGame)
    TeamvTeam.UpdateCurrentTime()


    'TODO FIX enabling setselectedbar throws cross thread exception
    '  mGraph.SetSelectedBar(mGame.mTimeKeeper.CurrentTimeIndex)

    ti.Stop()
    theLog.WriteTestLog("TeamvTeam Done in: " & ti.ElapsedMilliseconds & " msecs")
    '  dbModifiers_ModChanged(Nothing)

    LayoutRoot.Children.Add(TeamvTeam)




    Overlays.Children.Clear()
    Overlays.Visibility = Windows.Visibility.Collapsed

    mHeroInstFactory = New HeroInstanceFactory(mGame, startitems.dbCreeps)

    'menus
    Dim itemmenu = dbControls.ItemMenu
    Overlays.Children.Add(itemmenu)

    Dim heromenu = dbControls.HeroMenu
    Overlays.Children.Add(heromenu)

    swatch.Stop()
    theLog.WriteTestLog("TOTAL STARTUP TIME: " & swatch.ElapsedMilliseconds)
    Me.Cursor = Nothing
  End Sub

#Region "Event handlers"
  Private Sub Navigator_GameEntitySelected(gameent As iGameEntity)
    'temporarily clearing selection until I figure out a good way to set it from here
    If Not curSelected Is Nothing Then
      curSelected.SetSelected(False)
      curSelected = Nothing
    End If


    TeamvTeam.LoadDetails(gameent)
  End Sub
  Private Sub TvT_GameEntitySelected(gameent As iGameEntity)

    If curSelected IsNot Nothing Then
      curSelected.SetSelected(False)

    End If

    curSelected = gameent
    TeamvTeam.LoadDetails(gameent)

  End Sub



  'Private Sub Graph_NewGraphItemSelected(thetype As eModifierType)
  '  '  Dim precursor = Me.Cursor
  '  Me.Cursor = Cursors.Wait
  '  Dim rmods As New ModifierList(mGame.dbModifiers.GetModsByParentsAndType(mGame.GetAllHeroesForTeam(eTeamName.Radiant), thetype))
  '  Dim dmods As New ModifierList(mGame.dbModifiers.GetModsByParentsAndType(mGame.GetAllHeroesForTeam(eTeamName.Dire), thetype))

  '  Dim outmods As New List(Of ModifierList)
  '  outmods.Add(rmods)
  '  outmods.Add(dmods)

  '  Dim data = mGame.GetGraphData(outmods)

  '  Dim bartp = TeamvTeam.Graph.Bartype
  '  Dim graphtp = TeamvTeam.Graph.Graphtype
  '  TeamvTeam.Graph.FillGraph(0, bartp, graphtp, data.thebardatalist, data.maxteamheight, data.maxheight, outmods)
  '  Me.Cursor = Nothing
  'End Sub

  Private Sub TvT_BadgeAppearanceChanged(appearance As eBadgeAppearance)
    TeamvTeam.SetBadgeAppearance(appearance)
  End Sub

  Private Sub Graph_TimeChanged(theindex As Integer)
    mGame.SetCurrentTime(mGame.TimeKeeper.TimePoints.TheFrames.Item(theindex))
    TeamvTeam.UpdateCurrentTime()
  End Sub

  Private Sub TargetBadge_NewTargetSelected(thectrl As ctrlTargetBadge)
    mGame.SetTargets(thectrl.EnemyTarget, thectrl.FriendlyTarget, thectrl.Bias, thectrl.Team)
  End Sub

  Private Sub TvT_NewHeroPicked(newherobuild As HeroBuild, oldhero As HeroInstance, heroteam As dTeam, teamposition As Integer)
    If newherobuild Is Nothing Then Exit Sub
    Dim thehero = mHeroInstFactory.CreateHeroInstance(newherobuild, oldhero.MyColor, _
                                                      heroteam, teamposition, _
                                                     oldhero.Goldcurve.Percentage, _
                                                     oldhero.XPCurve.Percentage)
    thehero.ID.AppendMetaData("dGame.ReplaceHeroInstance")

    mGame.AddorReplaceHeroInstance(thehero, oldhero.MyColor, _
                              heroteam, teamposition, _
                              oldhero.Goldcurve.Percentage, _
                              oldhero.XPCurve.Percentage)

    Select Case heroteam.TeamName
      Case eTeamName.Radiant
        mGame.RadiantTeam.CalcMods()
      Case eTeamName.Dire
        mGame.DireTeam.CalcMods()
      Case Else
        Throw New NotImplementedException
    End Select
    Dim newheroinst As HeroInstance = mGame.GetHeroInstanceByTeamAndPositionIndex(heroteam, teamposition)


    TeamvTeam.LoadHeroBadge(newheroinst, newheroinst.mTeam, newheroinst.mTeamPosition)

    TeamvTeam.ctrlRadiantTargetBadge.UpdateTargets(mGame.RadiantTeam.EnemyTarget, mGame.RadiantTeam.FriendlyTarget, mGame.RadiantTeam.TargetFriendlyBias)
    TeamvTeam.ctrlDireTargetBadge.UpdateTargets(mGame.DireTeam.EnemyTarget, mGame.DireTeam.FriendlyTarget, mGame.DireTeam.TargetFriendlyBias)

    TeamvTeam.ctrlNavigationBar.Load(mGame)
  End Sub
#End Region

  Private Sub TvT_GraphableSelected(sender As iGraphable)
    ' If curSelectedGraphed Is sender Then Exit Sub

    If Not curSelectedGraphed Is Nothing Then
      curSelectedGraphed.SetGraphed(False)
    End If

    curSelectedGraphed = sender

    Dim bardata = mGame.GetGraphData(sender.GraphDataItems)
    sender.SetGraphed(True)
    TeamvTeam.Graph.FillGraph(sender.GraphPreferences.Title, TeamvTeam.Graph.SelectedBarIndex, sender.GraphPreferences.BarType, sender.GraphPreferences.GraphType, _
                              bardata.thebardatalist, bardata.maxteamheight, bardata.maxheight, bardata.dataitems)
  End Sub


  



End Class
