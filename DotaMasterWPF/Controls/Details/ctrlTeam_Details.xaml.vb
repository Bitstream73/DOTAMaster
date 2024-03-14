Public Class ctrlTeam_Details
  Implements iDetails, iGameEntity, iGraphable




  Private mID As dvID
  Private mTeam As dTeam
  Private mTeamStats As TeamStatPackage

  Private dbControls As Controls_Database
  Private mGame As dGame

  Private mStats As New List(Of ctrlSwatchDataItemLabel)
  Private mStatsForSummaryGraph As New List(Of List(Of iDataItem))

  Private mCurtime As ddFrame

  Private mTeamBrush As SolidColorBrush

  Private mTitle As String

  Private mSelectedGraphable As iGraphable

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(curtime As ddFrame, team As dTeam, _
                 controlsdb As Controls_Database, game As dGame)

    InitializeComponent()

    mGame = game
    mTeam = team
    mTeamStats = mGame.StatPackageFactory.GetorCreateTeamStatPackage(mTeam)

    dbControls = controlsdb

    mCurtime = curtime

    mTeamBrush = New SolidColorBrush(team.MyColor)

    Me.mID = New dvID(Guid.NewGuid, "ctrlTeam_Details", eEntity.ctrlTeam_Details)

    mTitle = mTeam.DisplayName & " at "
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)
    lblStats._Content = "Stats"
    lblDefense._Content = "Defense"
    lblOffense._Content = "Offense"
    lblResources._Content = "Resources"
    lblComponents._Content = "Components"

    FillStats()

    FillDefense()

    FillOffense()

    FillResources()

    FillComponents()

    FillSummary()
  End Sub

  Private Sub FillSummary()
    Dim subheads As New List(Of String)
    subheads.Add("Stats")
    subheads.Add("Defense")
    subheads.Add("Offense")


    'grphSummary.Load(mStatsForSummaryGraph, subheads, New GridLength(10, GridUnitType.Star), New GridLength(4, GridUnitType.Star), mGame)

    ctrlSummary.Load(mStatsForSummaryGraph.Item(0).Item(0), mStatsForSummaryGraph, subheads, _
                     New SolidColorBrush(PageHandler.dbColors.HeadingTextColor), New SolidColorBrush(PageHandler.dbColors.BodyTextColor), _
                     Constants.cBodyFontSize, False, _
                     New GridLength(10, GridUnitType.Star), New GridLength(4, GridUnitType.Star), mGame)

    AddHandler ctrlSummary.GraphableSelected, AddressOf ctrlSummary_GraphableSelected

  End Sub

  Private Sub FillComponents()
    Dim dataitems As New List(Of iDataItem)

    For i = 0 To mTeamStats.mStats.Count - 1
      Dim curstat As Stat = DirectCast(mTeamStats.mStats.Item(i), Stat)
      If Not curstat Is Nothing Then
        Dim modlists = curstat.MyModsByType
        Dim stats = curstat.MyStats

        Dim ditems As New List(Of iDataItem)
        ditems.AddRange(stats)

        For Each modlist In modlists
          ditems.AddRange(modlist.Value)
        Next
        dataitems.AddRange(ditems)

      End If
    Next

    dviewDataItems.LoadMe(dataitems, 1, dbControls, mGame)
    AddHandler dviewDataItems.GraphableSelected, AddressOf ChildControl_GraphableSelected
  End Sub


  Private Sub FillStats()
    Dim statslistforSummary As New List(Of iDataItem)

    AddStatLabel(mTeamStats.TeamTtlEffectiveHP, mTeamStats.TeamTtlEffectiveHP.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlEffectiveHP)

    AddStatLabel(mTeamStats.TeamTtlHP, mTeamStats.TeamTtlHP.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlHP)

    AddStatLabel(mTeamStats.TeamTtlHPRegen, mTeamStats.TeamTtlHPRegen.DisplayName, "", 2)
    statslistforSummary.Add(mTeamStats.TeamTtlHPRegen)

    AddHorizontalLine(eDetailsLocation.Stats)

    AddStatLabel(mTeamStats.TeamTtlMana, mTeamStats.TeamTtlMana.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlMana)

    AddStatLabel(mTeamStats.TeamTtlManaRegen, mTeamStats.TeamTtlManaRegen.DisplayName, "", 2)
    statslistforSummary.Add(mTeamStats.TeamTtlManaRegen)

    mStatsForSummaryGraph.Add(statslistforSummary)


  End Sub

  Private Sub FillOffense()
    Dim statslistforSummary As New List(Of iDataItem)


    AddOffenseLabel(mTeamStats.TeamTtlDamageAvg, mTeamStats.TeamTtlDamageAvg.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlDamageAvg)

    AddOffenseLabel(mTeamStats.TeamTtlDamageLo, mTeamStats.TeamTtlDamageLo.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlDamageLo)

    AddOffenseLabel(mTeamStats.TeamTtlDamageHi, mTeamStats.TeamTtlDamageHi.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlDamageHi)

    AddHorizontalLine(eDetailsLocation.Offense)

    AddOffenseLabel(mTeamStats.TeamTtlPhysDamageBurst, mTeamStats.TeamTtlPhysDamageBurst.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlPhysDamageBurst)

    AddHorizontalLine(eDetailsLocation.Offense)

    AddOffenseLabel(mTeamStats.TeamTtlMagDamageBurst, mTeamStats.TeamTtlMagDamageBurst.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlMagDamageBurst)

    AddHorizontalLine(eDetailsLocation.Offense)

    AddOffenseLabel(mTeamStats.TeamTtlPureDamageBurst, mTeamStats.TeamTtlPureDamageBurst.DisplayName, "", 0)
    statslistforSummary.Add(mTeamStats.TeamTtlPureDamageBurst)


    mStatsForSummaryGraph.Add(statslistforSummary)
  End Sub

  Private Sub FillDefense()
    Dim statslistforsummary As New List(Of iDataItem)

    AddDefenseLabel(mTeamStats.TeamPhysicalArmor, mTeamStats.TeamPhysicalArmor.DisplayName, "", 0)
    statslistforsummary.Add(mTeamStats.TeamPhysicalArmor)


    AddDefenseLabel(mTeamStats.TeamMagicResistancea, mTeamStats.TeamMagicResistancea.DisplayName, "", 0)
    statslistforsummary.Add(mTeamStats.TeamMagicResistancea)

    AddHorizontalLine(eDetailsLocation.Defense)

    AddDefenseLabel(mTeamStats.TeamTtlSpellImmunityCount, mTeamStats.TeamTtlSpellImmunityCount.DisplayName, "", 0)
    statslistforsummary.Add(mTeamStats.TeamTtlSpellImmunityCount)

    AddDefenseLabel(mTeamStats.TeamTtlVisionDay, mTeamStats.TeamTtlVisionDay.DisplayName, "", 0)
    statslistforsummary.Add(mTeamStats.TeamTtlVisionDay)

    AddDefenseLabel(mTeamStats.TeamTtlVisionNight, mTeamStats.TeamTtlVisionNight.DisplayName, "", 0)
    statslistforsummary.Add(mTeamStats.TeamTtlVisionNight)

    AddHorizontalLine(eDetailsLocation.Defense)

    AddDefenseLabel(mTeamStats.TeamTtlStunDuratoin, mTeamStats.TeamTtlStunDuratoin.DisplayName, "", 2)
    statslistforsummary.Add(mTeamStats.TeamTtlStunDuratoin)

    AddDefenseLabel(mTeamStats.TeamTtlHexDuration, mTeamStats.TeamTtlHexDuration.DisplayName, "", 2)
    statslistforsummary.Add(mTeamStats.TeamTtlHexDuration)


    mStatsForSummaryGraph.Add(statslistforsummary)
  End Sub

  Private Sub FillResources()


    AddKillsLabel(mTeamStats.TeamKills, mTeamStats.TeamKills.DisplayName, "", 0)

  End Sub

  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)

    For i = 0 To mStats.Count - 1
      mStats.Item(i).UpdateValue(curtime)
    Next

    dviewDataItems.UpdateTime(curtime)

    ctrlSummary.Updatetime(curtime)
  End Sub

  Private Sub AddGoldLabel(teamstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, teamstat, _
                                                 prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlGold.Children.Add(ctrl)
  End Sub

  Private Sub AddKillsLabel(teamstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, teamstat, _
                                                 prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlKills.Children.Add(ctrl)
  End Sub

  Private Sub AddXPLabel(teamstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, teamstat, _
                                                 prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlXP.Children.Add(ctrl)
  End Sub

  Private Sub AddStatLabel(teamstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, teamstat, _
                                                 prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlStats.Children.Add(ctrl)
  End Sub

  Private Sub AddOffenseLabel(teamstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, teamstat, _
                                                 prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlOffense.Children.Add(ctrl)
  End Sub

  Private Sub AddDefenseLabel(teamstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mCurtime, teamstat, _
                                                 prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlDefense.Children.Add(ctrl)
  End Sub


  Private Sub AddHorizontalLine(location As eDetailsLocation)
    Dim line = dbControls.GetHorizontalLine(0.35, 0.35, 1)
    Select Case location
      Case eDetailsLocation.Stats
        spnlStats.Children.Add(line)
      Case eDetailsLocation.Offense
        spnlOffense.Children.Add(line)
      Case eDetailsLocation.Defense
        spnlDefense.Children.Add(line)
      Case eDetailsLocation.ResourcesKills
        spnlKills.Children.Add(line)
      Case eDetailsLocation.ResourcesGold
        spnlGold.Children.Add(line)
      Case eDetailsLocation.ResourcesXP
        spnlXP.Children.Add(line)

      Case Else
        Throw New NotImplementedException
    End Select
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlTeam_Details"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlTeam_Details
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return Me.mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.ErrorColor
    End Get
    Set(value As Color)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Control
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Nothing
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return Nothing
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property MyDetailsGameEntity As iGameEntity Implements iDetails.MyDetailsGameEntity
    Get
      Return mTeam
    End Get
    Set(value As iGameEntity)

    End Set
  End Property


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mSelectedGraphable Is Nothing Then
        Return mSelectedGraphable.GraphDataItems
      End If
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedGraphable Is Nothing Then
        Return mSelectedGraphable.GraphPreferences
      End If
      Return Nothing
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedGraphable Is Nothing Then
      mSelectedGraphable.SetGraphed(isgraphed)
    End If
  End Sub

  Private Sub ChildControl_GraphableSelected(sender As iGraphable)
    mSelectedGraphable = sender
    RaiseEvent GraphableSelected(mSelectedGraphable)
  End Sub

  Private Sub ctrlSummary_GraphableSelected(sender As iGraphable)
    If Not mSelectedGraphable Is Nothing Then
      mSelectedGraphable.SetGraphed(False)
    End If
    mSelectedGraphable = sender
    RaiseEvent GraphableSelected(sender)
  End Sub

End Class
