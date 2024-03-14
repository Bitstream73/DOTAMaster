Public Class ctrlHerovHeroDetails
  Implements iDetails, iGameEntity, iGraphable



  Private mID As dvID

  Private dbControls As Controls_Database
  Private mcurtime As ddFrame
  Private mRadhero As HeroInstance
  Private mRadstats As HeroStatPackage
  Private mDirehero As HeroInstance
  Private mDirestats As HeroStatPackage

  Private mGame As dGame

  Private mStats As New List(Of ctrlSwatchDataItemLabelDual)

  Private mRadBrush As SolidColorBrush
  Private mDireBrush As SolidColorBrush
  Private mTitle As String

  Private mSelectedGraphable As iGraphable


  Private mRadSummaryStats As New List(Of List(Of iDataItem))
  Private mDireSumamryStats As New List(Of List(Of iDataItem))

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(curtime As ddFrame, _
                 radhero As iPlayerUnit, _
                 direhero As iPlayerUnit, _
                 controlsdb As Controls_Database, game As dGame)
    InitializeComponent()

    Me.mID = New dvID(Guid.NewGuid, "ctrlHerovHeroDetails|New", eEntity.ctrlHerovHeroDetails)

    mGame = game
    dbControls = controlsdb
    mcurtime = curtime
    mRadhero = radhero
    mRadstats = mGame.StatPackageFactory.GetorCreateHeroStatPackage(mRadhero)
    mRadBrush = New SolidColorBrush(mRadhero.MyColor)


    mDirehero = direhero
    mDirestats = mGame.StatPackageFactory.GetorCreateHeroStatPackage(mDirehero)
    mDireBrush = New SolidColorBrush(mDirehero.MyColor)

    mTitle = radhero.DisplayName & " vs " & direhero.DisplayName & " at "
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)
    lblStats._Content = "Stats"
    lblDefense._Content = "Defense"
    lblOffense._Content = "Offense"
    lblResources._Content = "Resources"

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
    grphSummary.Load(mRadSummaryStats, mDireSumamryStats, subheads, _
                     New GridLength(10, GridUnitType.Star), New GridLength(4, GridUnitType.Star), _
                     mGame, _
                     mRadBrush, mDireBrush, _
                     New SolidColorBrush(PageHandler.dbColors.NeutralTeamColor))
  End Sub
  Private Sub FillComponents()

    Dim dataitems As New List(Of iDataItem)

    For i = 0 To mRadstats.mStats.Count - 1
      Dim curstat = mRadstats.mStats.Item(i)
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
      Dim curstat = mDirestats.mStats.Item(i)
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

    Dim radstats As New List(Of iDataItem)
    Dim direstats As New List(Of iDataItem)
    'STATS --------------------------

    'Effective Hitpoints
    AddStatLabel(mRadstats.effectiveHP, mDirestats.effectiveHP, mRadstats.effectiveHP.DisplayName, "", 0)
    radstats.Add(mRadstats.effectiveHP)
    direstats.Add(mDirestats.effectiveHP)


    'Hit Points
    AddStatLabel(mRadstats.hitpoints, mDirestats.hitpoints, mRadstats.hitpoints.DisplayName, "", 0)
    radstats.Add(mRadstats.hitpoints)
    direstats.Add(mDirestats.hitpoints)

    'Hit Point Regen
    AddStatLabel(mRadstats.hpregen, mDirestats.hpregen, mRadstats.hpregen.DisplayName, "", 2)
    radstats.Add(mRadstats.hpregen)
    direstats.Add(mDirestats.hpregen)

    AddHorizontalLine(eDetailsLocation.Stats)

    'Mana
    AddStatLabel(mRadstats.mana, mDirestats.mana, mRadstats.mana.DisplayName, "", 0)
    radstats.Add(mRadstats.mana)
    direstats.Add(mDirestats.mana)

    'Mana Regen
    AddStatLabel(mRadstats.manaregen, mDirestats.manaregen, mRadstats.manaregen.DisplayName, "", 0)
    radstats.Add(mRadstats.manaregen)
    direstats.Add(mDirestats.manaregen)


    AddHorizontalLine(eDetailsLocation.Stats)




    'int
    AddStatLabel(mRadstats.intel, mDirestats.intel, mRadstats.intel.DisplayName, "", 0)
    radstats.Add(mRadstats.intel)
    direstats.Add(mDirestats.intel)

    'agi
    AddStatLabel(mRadstats.agility, mDirestats.agility, mRadstats.agility.DisplayName, "", 0)
    radstats.Add(mRadstats.agility)
    direstats.Add(mDirestats.agility)

    'str
    AddStatLabel(mRadstats.strength, mDirestats.strength, mRadstats.strength.DisplayName, "", 0)
    radstats.Add(mRadstats.strength)
    direstats.Add(mDirestats.strength)

    AddHorizontalLine(eDetailsLocation.Stats)

    'AttackRange
    AddStatLabel(mRadstats.attackrange, mDirestats.attackrange, mRadstats.attackrange.DisplayName, "", 0)
    radstats.Add(mRadstats.attackrange)
    direstats.Add(mDirestats.attackrange)

    'Attacks per sec
    AddStatLabel(mRadstats.attackspersec, mDirestats.attackspersec, mRadstats.attackspersec.DisplayName, "", 2)
    radstats.Add(mRadstats.attackspersec)
    direstats.Add(mDirestats.attackspersec)

    'missile speed
    AddStatLabel(mRadstats.missilespeed, mDirestats.missilespeed, mRadstats.missilespeed.DisplayName, "", 0)
    radstats.Add(mRadstats.missilespeed)
    direstats.Add(mDirestats.missilespeed)

    'Base Attack Time
    AddStatLabel(mRadstats.baseattacktime, mDirestats.baseattacktime, mRadstats.baseattacktime.DisplayName, "", 2)
    radstats.Add(mRadstats.baseattacktime)
    direstats.Add(mDirestats.baseattacktime)



    'Turn Rate
    'AddStatLabel(eDetailsLocation.Stats, mRadstats.turnrate, mDirestats.turnrate, "Turn Rate", "", 2)




    mRadSummaryStats.Add(radstats)
    mDireSumamryStats.Add(direstats)

  End Sub

  Private Sub FillDefense()
    Dim radstats As New List(Of iDataItem)
    Dim direstats As New List(Of iDataItem)
    'DEFENSE --------------------------

    'Physical Armor
    AddDefenseLabel(mRadstats.physicalarmor, mDirestats.physicalarmor, mRadstats.physicalarmor.DisplayName, "", 0)
    radstats.Add(mRadstats.physicalarmor)
    direstats.Add(mDirestats.physicalarmor)

    'Magic Resistance
    AddDefenseLabel(mRadstats.magicresistance, mDirestats.magicresistance, mRadstats.magicresistance.DisplayName, "", 0)
    radstats.Add(mRadstats.magicresistance)
    direstats.Add(mDirestats.magicresistance)

    'Magic Immunity Time Burst
    AddDefenseLabel(mRadstats.magicimmunityBurst, mDirestats.magicimmunityBurst, mRadstats.magicimmunityBurst.DisplayName, "", 2)
    radstats.Add(mRadstats.magicimmunityBurst)
    direstats.Add(mDirestats.magicimmunityBurst)

    'Magic Immunity Time Avg
    ' AddStatLabel(eDetailsLocation.Defense, mRadstats.magicimmunityavg, mDirestats.magicimmunityavg, "Magic Immunity Time Avg", "", 2)

    'Spell Immunity Count
    AddDefenseLabel(mRadstats.speelimmunitycount, mDirestats.speelimmunitycount, mRadstats.speelimmunitycount.DisplayName, "", 0)
    radstats.Add(mRadstats.speelimmunitycount)
    direstats.Add(mDirestats.speelimmunitycount)

    AddHorizontalLine(eDetailsLocation.Defense)

    'Vision Day area
    AddDefenseLabel(mRadstats.visiondayarea, mDirestats.visiondayarea, mDirestats.visiondayarea.DisplayName, "", 0)
    radstats.Add(mRadstats.visiondayarea)
    direstats.Add(mDirestats.visiondayarea)

    'Vision night area
    AddDefenseLabel(mRadstats.visionnightarea, mDirestats.visionnightarea, mRadstats.visionnightarea.DisplayName, "", 0)
    radstats.Add(mRadstats.visionnightarea)
    direstats.Add(mDirestats.visionnightarea)

    'Trusight Area
    AddDefenseLabel(mRadstats.trusightarea, mDirestats.trusightarea, mRadstats.trusightarea.DisplayName, "", 0)
    radstats.Add(mRadstats.trusightarea)
    direstats.Add(mDirestats.trusightarea)

    'Stealth
    AddDefenseLabel(mRadstats.stealthtime, mDirestats.stealthtime, mRadstats.stealthtime.DisplayName, "", 0)
    radstats.Add(mRadstats.stealthtime)
    direstats.Add(mDirestats.stealthtime)

    AddHorizontalLine(eDetailsLocation.Defense)

    'Stun Duration Burst
    AddDefenseLabel(mRadstats.stundurationburst, mDirestats.stundurationburst, mRadstats.stundurationburst.DisplayName, "", 2)
    radstats.Add(mRadstats.stundurationburst)
    direstats.Add(mDirestats.stundurationburst)

    'Stun Duration Avg
    ' AddStatLabel(eDetailsLocation.Defense, mRadstats.stundurationavg, mDirestats.stundurationavg, "Stun Duration Avg", "", 2)

    'Hex Duration Burst
    AddDefenseLabel(mRadstats.hexdurationburst, mDirestats.hexdurationburst, mDirestats.hexdurationburst.DisplayName, "", 2)
    radstats.Add(mRadstats.hexdurationburst)
    direstats.Add(mDirestats.hexdurationburst)

    'Hex Duration Avg
    ' AddStatLabel(eDetailsLocation.Defense, mRadstats.hexdurationavg, mDirestats.hexdurationavg, "Hex Duration Avg", "", 2)

    AddHorizontalLine(eDetailsLocation.Defense)


    'MoveSpeed
    AddDefenseLabel(mRadstats.movespeed, mDirestats.movespeed, mRadstats.movespeed.DisplayName, "", 0)
    radstats.Add(mRadstats.movespeed)
    direstats.Add(mDirestats.movespeed)


    mRadSummaryStats.Add(radstats)
    mDireSumamryStats.Add(direstats)
  End Sub

  Private Sub FillOffense()
    Dim radstats As New List(Of iDataItem)
    Dim direstats As New List(Of iDataItem)

    'Right-Click avg damage
    AddOffenseLabel(mRadstats.rightclickavgdamage, mDirestats.rightclickavgdamage, mRadstats.rightclickavgdamage.DisplayName, "", 2)
    radstats.Add(mRadstats.rightclickavgdamage)
    direstats.Add(mDirestats.rightclickavgdamage)

    AddOffenseLabel(mRadstats.rightclickhidamage, mDirestats.rightclickhidamage, mRadstats.rightclickhidamage.DisplayName, "", 0)
    radstats.Add(mRadstats.rightclickhidamage)
    direstats.Add(mDirestats.rightclickhidamage)

    AddOffenseLabel(mRadstats.rightclicklodamage, mDirestats.rightclicklodamage, mRadstats.rightclicklodamage.DisplayName, "", 0)
    radstats.Add(mRadstats.rightclicklodamage)
    direstats.Add(mDirestats.rightclicklodamage)

    'CritChance
    AddOffenseLabel(mRadstats.critchance, mDirestats.critchance, mRadstats.critchance.DisplayName, "", 2)
    radstats.Add(mRadstats.critchance)
    direstats.Add(mDirestats.critchance)

    'Crit Damage Multiplier
    AddOffenseLabel(mRadstats.critmultiplier, mDirestats.critmultiplier, mRadstats.critmultiplier.DisplayName, "", 2)
    radstats.Add(mRadstats.critmultiplier)
    direstats.Add(mDirestats.critmultiplier)

    'crit damage
    AddOffenseLabel(mRadstats.critDamage, mDirestats.critDamage, mRadstats.critDamage.DisplayName, "", 0)
    radstats.Add(mRadstats.critDamage)
    direstats.Add(mDirestats.critDamage)

    AddHorizontalLine(eDetailsLocation.Offense)

    'Physical Damage Burst
    AddOffenseLabel(mRadstats.physicaldamageburst, mDirestats.physicaldamageburst, mRadstats.physicaldamageburst.DisplayName, "", 0)
    radstats.Add(mRadstats.physicaldamageburst)
    direstats.Add(mDirestats.physicaldamageburst)

    'physical Damage Avg
    '  AddStatLabel(eDetailsLocation.Offense, mRadstats.physicaldamageavg, mDirestats.physicaldamageburst, "Physical Damage Avg", "", 2)

    AddHorizontalLine(eDetailsLocation.Offense)

    'Magic damage burst
    AddOffenseLabel(mRadstats.magicdamageburst, mDirestats.magicdamageburst, mRadstats.magicimmunityBurst.DisplayName, "", 0)
    radstats.Add(mRadstats.magicimmunityBurst)
    direstats.Add(mDirestats.magicimmunityBurst)

    'Magic Damage Average
    '  AddStatLabel(eDetailsLocation.Offense, mRadstats.magicdamageavg, mDirestats.magicdamageavg, "Magic Damage Avg", "", 0)

    AddHorizontalLine(eDetailsLocation.Offense)

    'Pure Damage Burst
    AddOffenseLabel(mRadstats.puredamageburst, mDirestats.puredamageburst, mRadstats.puredamageburst.DisplayName, "", 0)
    radstats.Add(mRadstats.puredamageburst)
    direstats.Add(mDirestats.puredamageburst)

    'Pure Damage Avg
    '   AddStatLabel(eDetailsLocation.Offense, mRadstats.puredamageavg, mDirestats.puredamageavg, "Pure Damage Avg", "", 2)

    AddHorizontalLine(eDetailsLocation.Offense)


    'All Damage Burst
    AddOffenseLabel(mRadstats.alldamageburst, mDirestats.alldamageburst, mRadstats.alldamageburst.DisplayName, "", 0)
    radstats.Add(mRadstats.alldamageburst)
    direstats.Add(mDirestats.alldamageburst)

    'All Damage Avg
    '   AddStatLabel(eDetailsLocation.Offense, mRadstats.alldamageavg, mDirestats.alldamageavg, "All Damage Avg", "", 0)

    AddHorizontalLine(eDetailsLocation.Offense)

    'HP Removal
    AddOffenseLabel(mRadstats.hpremoval, mDirestats.hpremoval, mRadstats.hpremoval.DisplayName, "", 0)
    radstats.Add(mRadstats.hpremoval)
    direstats.Add(mDirestats.hpremoval)

    ''Negative Regen
    'AddStatLabel(eDetailsLocation.Offense, mRadstats.negativeregen, mDirestats.negativeregen, "Negative Regen", "", 2)

    mRadSummaryStats.Add(radstats)
    mDireSumamryStats.Add(direstats)
  End Sub


  Private Sub FillResources()
    'Kills
    AddKillsLabel(mRadstats.kills, mDirestats.kills, mRadstats.kills.DisplayName, "", 0)

    'Networth
    AddGoldLabel(mRadstats.networth, mDirestats.networth, mRadstats.networth.DisplayName, "", 0)

    'Automatic Gold
    AddGoldLabel(mRadstats.periodicgold, mDirestats.periodicgold, mRadstats.periodicgold.DisplayName, "", 0)

    'xp
    AddXPLabel(mRadstats.xp, mDirestats.xp, mRadstats.xp.DisplayName, "", 0)

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
      Case eDetailsLocation.ResourcesGold
        spnlGold.Children.Add(line)
      Case eDetailsLocation.ResourcesKills
        spnlKills.Children.Add(line)
      Case eDetailsLocation.ResourcesXP
        spnlXP.Children.Add(line)
      Case Else
        Throw New NotImplementedException
    End Select
  End Sub

  Private Sub AddGoldLabel(radstat As iDataItem, direstat As iDataItem, _
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

  Private Sub AddKillsLabel(radstat As iDataItem, direstat As iDataItem, _
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

  Private Sub AddXPLabel(radstat As iDataItem, direstat As iDataItem, _
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
  Private Sub AddStatLabel(radstat As iDataItem, direstat As iDataItem, _
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

  Private Sub AddOffenseLabel(radstat As iDataItem, direstat As iDataItem, _
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

  Private Sub AddDefenseLabel(radstat As iDataItem, direstat As iDataItem, _
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
  'Private Sub AddStatLabel(location As eDetailsLocation, _
  '                      radstat As Stat, direstat As Stat, _
  '                         prefix As String, suffix As String, _
  '                         decimalplaces As Integer)


  '  Select Case location
  '    Case eDetailsLocation.Stats
  '      spnlStats.Children.Add(ctrl)

  '    Case eDetailsLocation.Offense
  '      spnlOffense.Children.Add(ctrl)
  '    Case eDetailsLocation.Defense
  '      spnlDefense.Children.Add(ctrl)
  '    Case Else
  '      Throw New NotImplementedException
  '  End Select
  '  End Sub

  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle.Content = mTitle & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)

    For i = 0 To mStats.Count - 1
      mStats.Item(i).UpdateValue(curtime)
    Next

    dviewDataItems.UpdateTime(curtime)
    grphSummary.UpdateTime(curtime)
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlHerovHeroDetails"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlHerovHeroDetails
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
      Return New GameEntity_Tuple(mRadhero, mDirehero, mGame)
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Private Sub ChildControl_GraphableSelected(sender As iGraphable)
    '  If mSelectedGraphable Is sender Then Exit Sub

    If Not mSelectedGraphable Is Nothing Then
      mSelectedGraphable.SetGraphed(False)
    End If

    mSelectedGraphable = sender

    RaiseEvent GraphableSelected(Me)

  End Sub


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      Return mSelectedGraphable.GraphDataItems
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      Return mSelectedGraphable.GraphPreferences
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    mSelectedGraphable.SetGraphed(isgraphed)
  End Sub
End Class

Public Enum eDetailsLocation
  Stats
  Offense
  Defense
  ResourcesKills
  ResourcesGold
  ResourcesXP
End Enum
