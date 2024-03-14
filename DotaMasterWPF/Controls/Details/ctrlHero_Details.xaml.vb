Public Class ctrlHero_Details
  Implements iDetails, iGameEntity, iGraphable



  Private mID As dvID

  Private dbControls As Controls_Database
  Private mcurtime As ddFrame
  Private mHero As iHeroUnit
  Private mHeroStats As HeroStatPackage
  Private mGame As dGame
  Private mStats As New List(Of ctrlSwatchDataItemLabel)

  Private mHeroBrush As SolidColorBrush

  Private mSelectedGraphable As iGraphable

  Private mSummaryStats As New List(Of List(Of iDataItem))

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(curtime As ddFrame, _
                 hero As iHeroUnit, _
                 controlsdb As Controls_Database, game As dGame)
    InitializeComponent()

    Me.mID = New dvID(Guid.NewGuid, "ctrlHero_Details|New", eEntity.ctrlHerovHeroDetails)

    mGame = game
    dbControls = controlsdb
    mcurtime = curtime
    mHero = hero
    mHeroStats = mGame.StatPackageFactory.GetorCreateHeroStatPackage(mHero)
    mHeroBrush = New SolidColorBrush(mHero.MyColor)
    lblTitle._Content = mHero.DisplayName & " at " & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)
    lblStats._Content = "Stats"
    lblOffense._Content = "Offense"
    lblDefense._Content = "Defense"
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

    ctrlSummary.Load(mSummaryStats.Item(0).Item(0), mSummaryStats, subheads, _
                     New SolidColorBrush(PageHandler.dbColors.HeadingTextColor), New SolidColorBrush(PageHandler.dbColors.BodyTextColor), _
                     Constants.cBodyFontSize, False, _
                     New GridLength(10, GridUnitType.Star), New GridLength(4, GridUnitType.Star), mGame)

    AddHandler ctrlSummary.GraphableSelected, AddressOf ctrlSummary_GraphableSelected

  End Sub

  Private Sub FillComponents()
    Dim dataitems As New List(Of iDataItem)

    For i = 0 To mHeroStats.mStats.Count - 1
      Dim curstat = mHeroStats.mStats.Item(i)
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
    Dim statslist As New List(Of iDataItem)

    'STATS --------------------------

    'Effective Hitpoints
    AddStatLabel(mHeroStats.effectiveHP, mHeroStats.effectiveHP.DisplayName, "", 0)
    statslist.Add(mHeroStats.effectiveHP)


    'Hit Points
    AddStatLabel(mHeroStats.hitpoints, mHeroStats.hitpoints.DisplayName, "", 0)
    statslist.Add(mHeroStats.hitpoints)


    'Hit Point Regen
    AddStatLabel(mHeroStats.hpregen, mHeroStats.hpremoval.DisplayName, "", 2)
    statslist.Add(mHeroStats.hpregen)


    AddHorizontalLine(eDetailsLocation.Stats)

    'Mana
    AddStatLabel(mHeroStats.mana, mHeroStats.mana.DisplayName, "", 0)
    statslist.Add(mHeroStats.mana)


    'Mana Regen
    AddStatLabel(mHeroStats.manaregen, mHeroStats.manaregen.DisplayName, "", 0)
    statslist.Add(mHeroStats.manaregen)



    AddHorizontalLine(eDetailsLocation.Stats)

    'int
    AddStatLabel(mHeroStats.intel, mHeroStats.intel.DisplayName, "", 0)
    statslist.Add(mHeroStats.intel)


    'agi
    AddStatLabel(mHeroStats.agility, mHeroStats.agility.DisplayName, "", 0)
    statslist.Add(mHeroStats.agility)


    'str
    AddStatLabel(mHeroStats.strength, mHeroStats.strength.DisplayName, "", 0)
    statslist.Add(mHeroStats.strength)

    AddHorizontalLine(eDetailsLocation.Stats)

    'AttackRange
    AddStatLabel(mHeroStats.attackrange, mHeroStats.attackrange.DisplayName, "", 0)
    statslist.Add(mHeroStats.attackrange)

    'Attacks per sec
    AddStatLabel(mHeroStats.attackspersec, mHeroStats.attackspersec.DisplayName, "", 2)
    statslist.Add(mHeroStats.attackspersec)

    'missile speed
    AddStatLabel(mHeroStats.missilespeed, mHeroStats.missilespeed.DisplayName, "", 0)
    statslist.Add(mHeroStats.missilespeed)

    'Base Attack Time
    AddStatLabel(mHeroStats.baseattacktime, mHeroStats.baseattacktime.DisplayName, "", 2)
    statslist.Add(mHeroStats.baseattacktime)



    'Turn Rate
    'AddStatLabel(eDetailsLocation.Stats, mRadstats.turnrate, mDirestats.turnrate, "Turn Rate", "", 2)





    mSummaryStats.Add(statslist)



  End Sub

  Private Sub FillDefense()
    Dim statslist As New List(Of iDataItem)

    'DEFENSE --------------------------


    'Physical Armor
    AddDefenseLabel(mHeroStats.physicalarmor, mHeroStats.physicalarmor.DisplayName, "", 0)
    statslist.Add(mHeroStats.physicalarmor)


    'Magic Resistance
    AddDefenseLabel(mHeroStats.magicresistance, mHeroStats.magicresistance.DisplayName, "", 0)
    statslist.Add(mHeroStats.magicresistance)


    'Magic Immunity Time Burst
    AddDefenseLabel(mHeroStats.magicimmunityBurst, mHeroStats.magicimmunityBurst.DisplayName, "", 2)
    statslist.Add(mHeroStats.magicimmunityBurst)


    'Magic Immunity Time Avg
    ' AddStatLabel(eDetailsLocation.Defense, mRadstats.magicimmunityavg, mDirestats.magicimmunityavg, "Magic Immunity Time Avg", "", 2)

    'Spell Immunity Count
    AddDefenseLabel(mHeroStats.speelimmunitycount, mHeroStats.speelimmunitycount.DisplayName, "", 0)
    statslist.Add(mHeroStats.speelimmunitycount)


    AddHorizontalLine(eDetailsLocation.Defense)

    'Vision Day area
    AddDefenseLabel(mHeroStats.visiondayarea, mHeroStats.visiondayarea.DisplayName, "", 0)
    statslist.Add(mHeroStats.visiondayarea)


    'Vision night area
    AddDefenseLabel(mHeroStats.visionnightarea, mHeroStats.visionnightarea.DisplayName, "", 0)
    statslist.Add(mHeroStats.visionnightarea)


    'Trusight Area
    AddDefenseLabel(mHeroStats.trusightarea, mHeroStats.trusightarea.DisplayName, "", 0)
    statslist.Add(mHeroStats.trusightarea)


    'Stealth
    AddDefenseLabel(mHeroStats.stealthtime, mHeroStats.stealthtime.DisplayName, "", 0)
    statslist.Add(mHeroStats.stealthtime)


    AddHorizontalLine(eDetailsLocation.Defense)

    'Stun Duration Burst
    AddDefenseLabel(mHeroStats.stundurationburst, mHeroStats.stundurationburst.DisplayName, "", 2)
    statslist.Add(mHeroStats.stundurationburst)


    'Stun Duration Avg
    ' AddStatLabel(eDetailsLocation.Defense, mRadstats.stundurationavg, mDirestats.stundurationavg, "Stun Duration Avg", "", 2)

    'Hex Duration Burst
    AddDefenseLabel(mHeroStats.hexdurationburst, mHeroStats.hexdurationburst.DisplayName, "", 2)
    statslist.Add(mHeroStats.hexdurationburst)


    'Hex Duration Avg
    ' AddStatLabel(eDetailsLocation.Defense, mRadstats.hexdurationavg, mDirestats.hexdurationavg, "Hex Duration Avg", "", 2)
    AddHorizontalLine(eDetailsLocation.Defense)

    'MoveSpeed
    AddDefenseLabel(mHeroStats.movespeed, mHeroStats.movespeed.DisplayName, "", 0)
    statslist.Add(mHeroStats.movespeed)


    mSummaryStats.Add(statslist)

  End Sub

  Private Sub FillOffense()
    Dim statslist As New List(Of iDataItem)

    'Right-Click avg damage
    AddOffenseLabel(mHeroStats.rightclickavgdamage, mHeroStats.rightclickavgdamage.DisplayName, "", 2)
    statslist.Add(mHeroStats.rightclickavgdamage)

    'Rightclidk hi
    AddOffenseLabel(mHeroStats.rightclickhidamage, mHeroStats.rightclickhidamage.DisplayName, "", 0)
    statslist.Add(mHeroStats.rightclickhidamage)


    'rightclick lo
    AddOffenseLabel(mHeroStats.rightclicklodamage, mHeroStats.rightclicklodamage.DisplayName, "", 0)
    statslist.Add(mHeroStats.rightclicklodamage)

    'CritChance
    AddOffenseLabel(mHeroStats.critchance, mHeroStats.critchance.DisplayName, "", 2)
    statslist.Add(mHeroStats.critchance)

    'Crit Damage Multiplier
    AddOffenseLabel(mHeroStats.critmultiplier, mHeroStats.critmultiplier.DisplayName, "", 2)
    statslist.Add(mHeroStats.critmultiplier)

    'crit damage
    AddOffenseLabel(mHeroStats.critDamage, mHeroStats.critDamage.DisplayName, "", 0)
    statslist.Add(mHeroStats.critDamage)

    AddHorizontalLine(eDetailsLocation.Offense)

    'Physical Damage Burst
    AddOffenseLabel(mHeroStats.physicaldamageburst, mHeroStats.physicaldamageburst.DisplayName, "", 0)
    statslist.Add(mHeroStats.physicaldamageburst)

    'physical Damage Avg
    '  AddStatLabel(eDetailsLocation.Offense, mRadstats.physicaldamageavg, mDirestats.physicaldamageburst, "Physical Damage Avg", "", 2)

    AddHorizontalLine(eDetailsLocation.Offense)

    'Magic damage burst
    AddOffenseLabel(mHeroStats.magicdamageburst, mHeroStats.magicimmunityBurst.DisplayName, "", 0)
    statslist.Add(mHeroStats.magicdamageburst)

    'Magic Damage Average
    '  AddStatLabel(eDetailsLocation.Offense, mRadstats.magicdamageavg, mDirestats.magicdamageavg, "Magic Damage Avg", "", 0)

    AddHorizontalLine(eDetailsLocation.Offense)

    'Pure Damage Burst
    AddOffenseLabel(mHeroStats.puredamageburst, mHeroStats.puredamageburst.DisplayName, "", 0)
    statslist.Add(mHeroStats.puredamageburst)

    'Pure Damage Avg
    '   AddStatLabel(eDetailsLocation.Offense, mRadstats.puredamageavg, mDirestats.puredamageavg, "Pure Damage Avg", "", 2)

    AddHorizontalLine(eDetailsLocation.Offense)

    'All Damage Burst
    AddOffenseLabel(mHeroStats.alldamageburst, mHeroStats.alldamageburst.DisplayName, "", 0)
    statslist.Add(mHeroStats.alldamageburst)

    'All Damage Avg
    '   AddStatLabel(eDetailsLocation.Offense, mRadstats.alldamageavg, mDirestats.alldamageavg, "All Damage Avg", "", 0)

    AddHorizontalLine(eDetailsLocation.Offense)

    'HP Removal
    AddOffenseLabel(mHeroStats.hpremoval, mHeroStats.hpremoval.DisplayName, "", 0)
    statslist.Add(mHeroStats.hpremoval)

    ''Negative Regen
    'AddStatLabel(eDetailsLocation.Offense, mRadstats.negativeregen, mDirestats.negativeregen, "Negative Regen", "", 2)


    mSummaryStats.Add(statslist)

  End Sub

  Private Sub FillResources()

    'kills
    AddKillsLabel(mHeroStats.kills, mHeroStats.kills.DisplayName, "", 0)

    'Networth
    AddGoldLabel(mHeroStats.networth, mHeroStats.networth.DisplayName, "", 0)


    'Automatic Gold
    AddGoldLabel(mHeroStats.periodicgold, mHeroStats.periodicgold.DisplayName, "", 0)

    'xp
    AddXPLabel(mHeroStats.xp, mHeroStats.xp.DisplayName, "", 0)

  End Sub
  Private Sub AddGoldLabel(herostat As iDataItem, _
                         prefix As String, suffix As String, _
                         decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               herostat, _
                                               prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlGold.Children.Add(ctrl)
  End Sub

  Private Sub AddKillsLabel(herostat As iDataItem, _
                         prefix As String, suffix As String, _
                         decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               herostat, _
                                               prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlKills.Children.Add(ctrl)
  End Sub

  Private Sub AddXPLabel(herostat As iDataItem, _
                         prefix As String, suffix As String, _
                         decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               herostat, _
                                               prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected
    mStats.Add(ctrl)

    spnlXP.Children.Add(ctrl)
  End Sub
  Private Sub AddStatLabel(herostat As iDataItem, _
                         prefix As String, suffix As String, _
                         decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               herostat, _
                                               prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected
    mStats.Add(ctrl)

    spnlStats.Children.Add(ctrl)
  End Sub

  Private Sub AddOffenseLabel(herostat As iDataItem, _
                         prefix As String, suffix As String, _
                         decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               herostat, _
                                               prefix, suffix)

    AddHandler ctrl.GraphableSelected, AddressOf ChildControl_GraphableSelected

    mStats.Add(ctrl)

    spnlOffense.Children.Add(ctrl)
  End Sub

  Private Sub AddDefenseLabel(herostat As iDataItem, _
                         prefix As String, suffix As String, _
                         decimalplaces As Integer)
    Dim ctrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               herostat, _
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


  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle.Content = mHero.DisplayName & " at " & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)

    For i = 0 To mStats.Count - 1
      mStats.Item(i).UpdateValue(curtime)
    Next

    dviewDataItems.UpdateTime(curtime)
    ctrlSummary.Updatetime(curtime)
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlHeroDetails"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlHero_Details
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
      Return mHero
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
