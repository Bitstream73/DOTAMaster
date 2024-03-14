Public Class ctrlTeamvTeamDetails
  Implements iDetails, iGameEntity, iGraphable





  Private dbControls As Controls_Database
  Private mcurtime As ddFrame

  Private mGame As dGame

  Private mRadiant As dTeam
  Private mRadstats As TeamStatPackage

  Private mDire As dTeam
  Private mDirestats As TeamStatPackage

  Private mID As dvID

  Private mStats As New List(Of ctrlSwatchDataItemLabelDual)

  Private mRadBrush As SolidColorBrush
  Private mDireBrush As SolidColorBrush

  Private mSelectedGraphable As iGraphable

  Private mTitle As String

  Private mRadStatsforSummary As New List(Of List(Of iDataItem))
  Private mDireStatsForSummary As New List(Of List(Of iDataItem))

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(curtime As ddFrame, _
radteam As dTeam, _
                direteam As dTeam, _
                 controlsdb As Controls_Database, game As dGame)
    InitializeComponent()

    Me.mID = New dvID(Guid.NewGuid, "CtrlTeamvTeamDetails|New", eEntity.ctrlTeamvTeamDetails)

    mGame = game
    dbControls = controlsdb
    mcurtime = curtime
    'mRadheroes = radheros
    mRadiant = radteam
    mRadstats = mGame.StatPackageFactory.GetorCreateTeamStatPackage(mRadiant)
    mRadBrush = New SolidColorBrush(mRadiant.MyColor)

    'mDireheroes = direheros
    mDire = direteam
    mDirestats = mGame.StatPackageFactory.GetorCreateTeamStatPackage(mDire)
    mDireBrush = New SolidColorBrush(mDire.MyColor)

    mTitle = radteam.DisplayName & " vs " & direteam.DisplayName & " at "
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

    ctrlSummary.Load(mRadStatsforSummary.Item(0).Item(0), mDireStatsForSummary.Item(0).Item(0), _
                     mRadStatsforSummary, mDireStatsForSummary, subheads, _
                     New SolidColorBrush(PageHandler.dbColors.HeadingTextColor), _
                     New SolidColorBrush(PageHandler.dbColors.BodyTextColor), _
                     Constants.cBodyFontSize, True, _
                     New GridLength(10, GridUnitType.Star), New GridLength(4, GridUnitType.Star), mGame)
  End Sub

  Private Sub FillComponents()

    Dim dataitems As New List(Of iDataItem)

    For i = 0 To mRadstats.mStats.Count - 1
      Dim curstat As Stat = DirectCast(mRadstats.mStats.Item(i), Stat)
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

    For i = 0 To mDirestats.mStats.Count - 1
      Dim curstat As Stat = DirectCast(mDirestats.mStats.Item(i), Stat)
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
    Dim radlist As New List(Of iDataItem)
    Dim direlist As New List(Of iDataItem)

    AddStatLabel(mRadstats.TeamTtlEffectiveHP, mDirestats.TeamTtlEffectiveHP, mRadstats.TeamTtlEffectiveHP.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlEffectiveHP)
    direlist.Add(mDirestats.TeamTtlEffectiveHP)

    AddStatLabel(mRadstats.TeamTtlHP, mDirestats.TeamTtlHP, mRadstats.TeamTtlHP.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlHP)
    direlist.Add(mDirestats.TeamTtlHP)

    AddStatLabel(mRadstats.TeamTtlHPRegen, mDirestats.TeamTtlHPRegen, mRadstats.TeamTtlHPRegen.DisplayName, "", 2)
    radlist.Add(mRadstats.TeamTtlHPRegen)
    direlist.Add(mDirestats.TeamTtlHPRegen)

    AddHorizontalLine(eDetailsLocation.Stats)

    AddStatLabel(mRadstats.TeamTtlMana, mDirestats.TeamTtlMana, mRadstats.TeamTtlMana.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlMana)
    direlist.Add(mDirestats.TeamTtlMana)

    AddStatLabel(mRadstats.TeamTtlManaRegen, mDirestats.TeamTtlManaRegen, mRadstats.TeamTtlManaRegen.DisplayName, "", 2)
    radlist.Add(mRadstats.TeamTtlManaRegen)
    direlist.Add(mDirestats.TeamTtlManaRegen)

    mRadStatsforSummary.Add(radlist)
    mDireStatsForSummary.Add(direlist)


  End Sub

  Private Sub FillOffense()
    Dim radlist As New List(Of iDataItem)
    Dim direlist As New List(Of iDataItem)

    AddOffenseLabel(mRadstats.TeamTtlDamageAvg, mDirestats.TeamTtlDamageAvg, mRadstats.TeamTtlDamageAvg.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlDamageAvg)
    direlist.Add(mDirestats.TeamTtlDamageAvg)

    AddOffenseLabel(mRadstats.TeamTtlDamageLo, mDirestats.TeamTtlDamageLo, mRadstats.TeamTtlDamageLo.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlDamageLo)
    direlist.Add(mDirestats.TeamTtlDamageLo)

    AddOffenseLabel(mRadstats.TeamTtlDamageHi, mDirestats.TeamTtlDamageHi, mRadstats.TeamTtlDamageHi.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlDamageHi)
    direlist.Add(mDirestats.TeamTtlDamageHi)

    AddHorizontalLine(eDetailsLocation.Offense)

    AddOffenseLabel(mRadstats.TeamTtlPhysDamageBurst, mDirestats.TeamTtlPhysDamageBurst, mRadstats.TeamTtlPhysDamageBurst.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlPhysDamageBurst)
    direlist.Add(mDirestats.TeamTtlPhysDamageBurst)

    AddHorizontalLine(eDetailsLocation.Offense)


    AddOffenseLabel(mRadstats.TeamTtlMagDamageBurst, mDirestats.TeamTtlMagDamageBurst, mRadstats.TeamTtlMagDamageBurst.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlMagDamageBurst)
    direlist.Add(mDirestats.TeamTtlMagDamageBurst)

    AddHorizontalLine(eDetailsLocation.Offense)

    AddOffenseLabel(mRadstats.TeamTtlPureDamageBurst, mDirestats.TeamTtlPureDamageBurst, mRadstats.TeamTtlPureDamageBurst.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlPureDamageBurst)
    direlist.Add(mDirestats.TeamTtlPureDamageBurst)


    mRadStatsforSummary.Add(radlist)
    mDireStatsForSummary.Add(direlist)
  End Sub

  Private Sub FillDefense()
    Dim radlist As New List(Of iDataItem)
    Dim direlist As New List(Of iDataItem)

    AddDefenseLabel(mRadstats.TeamPhysicalArmor, mDirestats.TeamPhysicalArmor, mRadstats.TeamPhysicalArmor.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamPhysicalArmor)
    direlist.Add(mDirestats.TeamPhysicalArmor)

    AddDefenseLabel(mRadstats.TeamMagicResistancea, mDirestats.TeamMagicResistancea, mRadstats.TeamMagicResistancea.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamMagicResistancea)
    direlist.Add(mDirestats.TeamMagicResistancea)

    AddHorizontalLine(eDetailsLocation.Defense)

    AddDefenseLabel(mRadstats.TeamTtlSpellImmunityCount, mDirestats.TeamTtlSpellImmunityCount, mRadstats.TeamTtlSpellImmunityCount.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlSpellImmunityCount)
    direlist.Add(mDirestats.TeamTtlSpellImmunityCount)

    AddDefenseLabel(mRadstats.TeamTtlVisionDay, mDirestats.TeamTtlVisionDay, mRadstats.TeamTtlVisionDay.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlVisionDay)
    direlist.Add(mDirestats.TeamTtlVisionDay)

    AddDefenseLabel(mRadstats.TeamTtlVisionNight, mDirestats.TeamTtlVisionNight, mRadstats.TeamTtlVisionNight.DisplayName, "", 0)
    radlist.Add(mRadstats.TeamTtlVisionNight)
    direlist.Add(mDirestats.TeamTtlVisionNight)

    AddHorizontalLine(eDetailsLocation.Defense)

    AddDefenseLabel(mRadstats.TeamTtlStunDuratoin, mDirestats.TeamTtlStunDuratoin, mRadstats.TeamTtlStunDuratoin.DisplayName, "", 2)
    radlist.Add(mRadstats.TeamTtlStunDuratoin)
    direlist.Add(mDirestats.TeamTtlStunDuratoin)

    AddDefenseLabel(mRadstats.TeamTtlHexDuration, mDirestats.TeamTtlHexDuration, mRadstats.TeamTtlHexDuration.DisplayName, "", 2)
    radlist.Add(mRadstats.TeamTtlHexDuration)
    direlist.Add(mDirestats.TeamTtlHexDuration)

    mRadStatsforSummary.Add(radlist)
    mDireStatsForSummary.Add(direlist)

  End Sub

  Private Sub FillResources()

    AddKillsLabel(mRadstats.TeamKills, mDirestats.TeamKills, mRadstats.TeamKills.DisplayName, "", 0)

  End Sub

  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)

    For i = 0 To mStats.Count - 1
      mStats.Item(i).UpdateValue(curtime)
    Next

    dviewDataItems.UpdateTime(curtime)
    ctrlSummary.Updatetime(curtime)
  End Sub

  Private Sub AddGoldLabel(radstat As Stat, direstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataitemLabelDual(mcurtime, _
                                               radstat, _
                                               direstat, _
                                               prefix, suffix, _
                                               mRadBrush, mDireBrush)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlGold.Children.Add(ctrl)
  End Sub

  Private Sub AddKillsLabel(radstat As Stat, direstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataitemLabelDual(mcurtime, _
                                               radstat, _
                                               direstat, _
                                               prefix, suffix, _
                                               mRadBrush, mDireBrush)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlKills.Children.Add(ctrl)
  End Sub

  Private Sub AddXPLabel(radstat As Stat, direstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataitemLabelDual(mcurtime, _
                                               radstat, _
                                               direstat, _
                                               prefix, suffix, _
                                               mRadBrush, mDireBrush)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected
    mStats.Add(ctrl)

    spnlXP.Children.Add(ctrl)
  End Sub

  Private Sub AddStatLabel(radstat As Stat, direstat As Stat, _
                          prefix As String, suffix As String, _
                          decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataitemLabelDual(mcurtime, _
                                               radstat, _
                                               direstat, _
                                               prefix, suffix, _
                                               mRadBrush, mDireBrush)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlStats.Children.Add(ctrl)
  End Sub

  Private Sub AddOffenseLabel(radstat As Stat, direstat As Stat, _
                           prefix As String, suffix As String, _
                           decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataitemLabelDual(mcurtime, _
                                               radstat, _
                                               direstat, _
                                               prefix, suffix, _
                                               mRadBrush, mDireBrush)


    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected
    mStats.Add(ctrl)

    spnlOffense.Children.Add(ctrl)
  End Sub

  Private Sub AddDefenseLabel(radstat As Stat, direstat As Stat, _
                           prefix As String, suffix As String, _
                           decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataitemLabelDual(mcurtime, _
                                               radstat, _
                                               direstat, _
                                               prefix, suffix, _
                                               mRadBrush, mDireBrush)

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
      Return "ctrlTeamvTeamDetails"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlTeamvTeamDetails
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
      Return New GameEntity_Tuple(mRadiant, mDire, mGame)
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

 

  

End Class
