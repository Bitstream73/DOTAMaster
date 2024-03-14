
Public Class Notes

  'SLOWPOKES
  'helpers.getlevelforability
  'helpers.getaffectedunitsforability
  'helpers.getenemyteamunits
  'helpers.getteamfromgameentity
  'helpers.getenemyteam
  'ctrlbargraph_panes_fixedwidth.SetVscales (fully half of time to load chart)
  'ctrlNavigationBar.FillSubMenu (InitializeComponent for swatchminimallarge and ctrlswatchroundminimallarge 90% of LoadDetails time)

  ' A hero class is:
  ' inherited from Herobase
  ' implements iAbility which is a generic set of functions that provides modifiers for each ability 
  ' ability0(statbuff), ability1, abilit2, etc up to max possible abilities(invoker)
  ' 
  'Heroclasses are instantiated with a statbundle passed in thru constructor
  'statbundle object is generated from Dotascraper and represents every static prop of a hero
  '
  'Each instance of heroclass represents a snapshot at each hero level of everything 
  'related to a hero - The hero's stats, the build of the hero, the abilities and the items of the hero

  'the modifiers produced by a hero class are mods for all stats by hero level, modifiers for all items by hero level and modifiers for all abilities by hero level





  'Modifiers are the 'packets' (indivisible pieces of information) that communicate state of heroes, abilities and items
  'they are the communcation between all game objects and are used by the UI to display any data that changes for 
  'each hero level and any modifiers produced by abilities, items and NPC's. 
  '
  'each modifier is one value with metadata about that one value (including Owner (Sven, IronBranch, FrostArmor, etc), ownertype (Hero, Ability or item)
  ' parent (the immmediate producer of a modifier), type (stun, int, damage, etc), the units it affects, 




  ' An item class is
  ' inherited from ItemBase
  ' implements iItemAblility if it has a clickable ability
  '
  ' is basically a modifierlist with some additional functionality and props including itemname, item descrip
  'items only provide a modifierlist which represents all that it is... stat changes and clickable ability



  'An ability class is
  ' inherited from AbilityBase
  ' it's everything EXCEPT the logic used to calculate the modifiers produced from itself. this is because each ability
  ' has its own unique logic. An ability class is basically just the collection of immutable props for an ability


  'HERO CLasS MODIFIER CONSUMPTION
  'will probably need a master list of the order of whose heroes


  'Main Class that is used for Isolated Storage

  'Private Sub CalcValue()
  '  modDB = PageHandler.dbModifiers
  '  gametimepoints = PageHandler.mTimeKeeper.TimePoints
  '  modtypes = New List(Of eModifierType)

  '  Select Case mStatType
  '    Case eStat.AttackSpeed 'AttackSpeed = AttackSpeedBuffs - AttaskSpeedDebuffs
  '      CalcAttackSpeed()
  '    Case eStat.AttackSpeedBuffs
  '      CalcAttackSpeedBuffs()
  '    Case eStat.AttackSpeedDebuffs
  '      CalcAttackSpeedDebuffs()

  '    Case eStat.AttackDamageLow
  '      CalcAttackDamage(True)
  '    Case eStat.AttackDamageHigh
  '      CalcAttackDamage(False)
  '    Case eStat.AttackDamageBuffs
  '      CalcAttackDamageBuffs()
  '    Case eStat.AttackDamageDebuffs
  '      CalcAttackDamageDebuffs()

  '    Case eStat.AttackRange
  '      CalcAttackRange()
  '    Case eStat.AttackRangeBuffs
  '      CalcAttackRangeBuffs()
  '    Case eStat.AttackRangeDebuffs
  '      CalcAttackRangeDebuffs()

  '    Case eStat.BonusAttackDamage
  '      CalcBonusAttackDamage()

  '    Case eStat.PhysicalArmor
  '      CalcPhysicalArmor()
  '    Case eStat.PhysicalArmorBuffs
  '      CalcPhysicalArmorBuffs()
  '    Case eStat.PhysicalArmorDebuffs
  '      CalcPhysicalArmorDebuffs()

  '    Case eStat.PhysicalDamageResistance
  '      CalcPhysicalDamageResistance()
  '    Case eStat.PhysicalDamageResistanceBuffs
  '      CalcPhysicalDamageResistanceBuffs()
  '    Case eStat.PhysicalDamageResistanceDebuffs
  '      CalcPhysicalDamageDebuffs()

  '    Case eStat.MagicalDamageResistance
  '      CalcMagicalDamageResistance()
  '    Case eStat.MagicalDamageResistanceBuffs
  '      CalcMagicalDamageResistanceBuffs()
  '    Case eStat.MagicalDamageResistanceDebuffs
  '      CalcMagicalDamageResistanceDebuffs()

  '    Case eStat.MovementSpeed
  '      CalcMovementSpeed()
  '    Case eStat.MovementSpeedbuffs
  '      CalcMovementSpeedbuffs()
  '    Case eStat.MovementSpeedDebuffs
  '      CalcMovementSpeedDebuffs()

  '    Case eStat.Strength
  '      CalcStealth()
  '    Case eStat.StrengthBuffs
  '      CalcStealthBuffs()
  '    Case eStat.StrengthDebuffs
  '      CalcStrengthDebuffs()

  '    Case eStat.Agility
  '      CalcAgility()
  '    Case eStat.AgilityBuffs
  '      CalcAgilityBuffs()
  '    Case eStat.AgilityDebuffs
  '      CalcAgilityDebuffs()

  '    Case eStat.Intelligence
  '      CalcIntelligence()
  '    Case eStat.IntelligenceBuffs
  '      CalcIntelligenceBuffs()
  '    Case eStat.IntelligenceDebuffs
  '      CalcIntelligenceDebuffs()

  '    Case eStat.Gold
  '      CalcGold()
  '    Case eStat.GoldBuffs '(Hand of midas)
  '      CalcGoldBuffs()
  '    Case eStat.GoldDebuffs '(not sure there are any)
  '      CalcGoldDebuffs()

  '    Case eStat.Experience
  '      CalcExperience()

  '    Case eStat.MagicDamage
  '      CalcMagicDamage()
  '    Case eStat.MagicDamageBuffs
  '      CalcMagicDamageBuffs()
  '    Case eStat.MagicDamageDebuffs
  '      CalcMagicalDamageResistanceDebuffs()

  '    Case eStat.PhysicalDamage
  '      CalcPhysicalDamage()
  '    Case eStat.PhysicalDamageBuffs
  '      CalcPhysicalDamageBuffs()
  '    Case eStat.PhysicalDamageDebuffs
  '      CalcPhysicalDamageDebuffs()

  '    Case eStat.PureDamage
  '      CalcPureDamage()
  '    Case eStat.PureDamageBuffs
  '      CalcPureDamageBuffs()
  '    Case eStat.PureDamageDebuffs
  '      CalcPureDamageDebuffs()

  '    Case eStat.HitPoints
  '      CalcHitPoints()
  '    Case eStat.HitPointBuffs
  '      CalcHitPointBuffs()
  '    Case eStat.HitPointDebuffs
  '      CalcHitPointDebuffs()

  '    Case eStat.HitPointRegen
  '      CalcHitPointRegen()
  '    Case eStat.HitPointRegenBuffs
  '      CalcHitPointRegenBuffs()
  '    Case eStat.HitPointRegenDebuffs
  '      CalcHitPointRegenDebuffs()

  '    Case eStat.Mana
  '      CalcMana()
  '    Case eStat.ManaBuffs
  '      CalcManaBuffs()
  '    Case eStat.Manadebuffs
  '      CalcManadebuffs()

  '    Case eStat.ManaRegen
  '      CalcManaRegen()
  '    Case eStat.ManaRegenBuffs
  '      CalcManaRegenBuffs()
  '    Case eStat.ManaRegenDebuffs
  '      CalcManaRegenDebuffs()

  '    Case eStat.Vision
  '      CalcVision()
  '    Case eStat.VisionBuffs
  '      CalcVisionBuffs()
  '    Case eStat.VisionDebuffs
  '      CalcVisionDebuffs()

  '    Case eStat.TrueSight
  '      CalcTrueSight()
  '    Case eStat.TrueSightBuffs
  '      CalcTrueSightBuffs()
  '    Case eStat.TrueSightDebuffs
  '      CalcTrueSightDebuffs()

  '    Case eStat.Stealth
  '      CalcStealth()
  '    Case eStat.StealthBuffs
  '      CalcStealthBuffs()
  '    Case eStat.StealthDebuffs
  '      CalcStealthDebuffs()
  '  End Select

  '  mIsDirty = False
  'End Sub
  'Private Sub CalcAttackSpeed() 'AttackSpeed = AttackSpeedBuffs - AttaskSpeedDebuffs	() 
  '  stattypes.Add(eStat.AttackSpeedBuffs)
  '  stattypes.Add(eStat.AttackSpeedDebuffs)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  Dim mbuffs = mOwnerStats.Item(0)
  '  Dim mdebuffs = mOwnerStats.Item(1)

  '  Dim outlist As New List(Of Double?)
  '  For i As Integer = 0 To gametimepoints.TheFrames.Count - 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)
  '    Dim outvalue As Double?
  '    outvalue = mbuffs.GetValue(curframe) - mdebuffs.GetValue(curframe)
  '    If Not outvalue < 0 Then
  '      outlist.Add(outvalue)
  '    Else
  '      outlist.Add(0)
  '    End If
  '  Next
  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAttackSpeedBuffs()
  '  modtypes.Add(eModifierType.BaseAttackTime)
  '  modtypes.Add(eModifierType.AttackSpeedAdded)
  '  modtypes.Add(eModifierType.AttackSpeedAddedPerHeroPerMissHP)
  '  modtypes.Add(eModifierType.AttackSpeedAddedtoXAttacks)
  '  modtypes.Add(eModifierType.AttackSpeedMaxed)
  '  modtypes.Add(eModifierType.AttackSpeedoT)
  '  modtypes.Add(eModifierType.AttackSpeedPercentAdded)
  '  modtypes.Add(eModifierType.AttackSpeedPercentofTargetAdded)
  '  modtypes.Add(eModifierType.AttackSpeedStackAdded)
  '  modtypes.Add(eModifierType.BaseAttackTimeChangedTo)
  '  modtypes.Add(eModifierType.BerserkersBonusAttackSpeed)
  '  modtypes.Add(eModifierType.BuildingAttackSpeedPercentAdded)
  '  modtypes.Add(eModifierType.DeathlustAttackSpeedAdded)
  '  modtypes.Add(eModifierType.NightAttackSpeedAdded)
  '  modtypes.Add(eModifierType.RabidAttackSpeedAdded)
  '  modtypes.Add(eModifierType.WexAttackSpeedAdded)
  '  stattypes.Add(eStat.AgilityBuffs)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  Dim mBaseAttackTimes = thelist.GetModsByType(eModifierType.BaseAttackTime)
  '  Dim mAttackSpeedAddeds = thelist.GetModsByType(eModifierType.AttackSpeedStackAdded)
  '  Dim mAttackSpeedAddedPerHeroMissHPs = thelist.GetModsByType(eModifierType.AttackSpeedAddedPerHeroPerMissHP)
  '  Dim mAttackSpeedAddedtoXAttacks = thelist.GetModsByType(eModifierType.AttackSpeedAddedtoXAttacks)
  '  Dim mAttackSpeedMaxed = thelist.GetModsByType(eModifierType.AttackSpeedMaxed)
  '  Dim mAttackSpeedoT = thelist.GetModsByType(eModifierType.AttackSpeedoT)
  '  Dim mAttackSpeedPercentAdded = thelist.GetModsByType(eModifierType.AttackSpeedPercentAdded)
  '  Dim mBaseAttackSpeedChangedto = thelist.GetModsByType(eModifierType.BaseAttackTimeChangedTo)
  '  Dim mBerserkerBonusAttSpeed = thelist.GetModsByType(eModifierType.BerserkersBonusAttackSpeed)
  '  Dim mBuildingAttackSeedPercentAdded = thelist.GetModsByType(eModifierType.BuildingAttackSpeedPercentAdded)
  '  Dim mDeathLustAttackSpeedAdded = thelist.GetModsByType(eModifierType.DeathlustAttackSpeedAdded)
  '  Dim mNightAttackSpeedAdded = thelist.GetModsByType(eModifierType.NightAttackSpeedAdded)
  '  Dim mRabidAttackSpeedAdded = thelist.GetModsByType(eModifierType.RabidAttackSpeedAdded)
  '  Dim mWexAttSpeedAdded = thelist.GetModsByType(eModifierType.WexAttackSpeedAdded)


  '  Dim outlist As New List(Of Double?)
  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)

  '    Dim maxval = ModFilters.GetSumOfModsForTime(mAttackSpeedMaxed, curframe)
  '    If maxval.HasValue Then

  '      outlist.Add(maxval)
  '      Continue For
  '    End If

  '    Dim BaseAttackTime As Double?
  '    If mBaseAttackSpeedChangedto.Count > 0 Then
  '      BaseAttackTime = mBaseAttackSpeedChangedto.Item(0).Value(curframe)
  '    Else
  '      BaseAttackTime = mBaseAttackTimes.Item(0).Value(curframe)
  '    End If

  '    Dim IAS As Double?

  '    Dim attadded = ModFilters.GetSumOfModsForTime(mAttackSpeedAddeds, curframe)
  '    If attadded.HasValue Then
  '      IAS += attadded
  '    End If



  '    Dim atperhero = ModFilters.GetSumOfModsForTime(mAttackSpeedAddedPerHeroMissHPs, curframe)
  '    If atperhero.HasValue Then
  '      IAS += attadded
  '    End If

  '    Dim atxattacks = ModFilters.GetSumOfModsForTime(mAttackSpeedAddedtoXAttacks, curframe)
  '    If atxattacks.HasValue Then
  '      IAS += atxattacks
  '    End If

  '    Dim atot = ModFilters.GetSumOfModsForTime(mAttackSpeedoT, curframe)
  '    If atot.HasValue Then
  '      IAS += atot
  '    End If

  '    Dim bersattspeed = ModFilters.GetSumOfModsForTime(mBerserkerBonusAttSpeed, curframe)
  '    If bersattspeed.HasValue Then
  '      IAS += bersattspeed
  '    End If

  '    Dim deathatt = ModFilters.GetSumOfModsForTime(mDeathLustAttackSpeedAdded, curframe)
  '    If deathatt.HasValue Then
  '      IAS += deathatt
  '    End If

  '    Dim nightatt = ModFilters.GetSumOfModsForTime(mNightAttackSpeedAdded, curframe)
  '    If nightatt.HasValue Then
  '      IAS += nightatt
  '    End If

  '    Dim rabidatt = ModFilters.GetSumOfModsForTime(mRabidAttackSpeedAdded, curframe)
  '    If rabidatt.HasValue Then
  '      IAS += rabidatt
  '    End If


  '    Dim wexatt = ModFilters.GetSumOfModsForTime(mWexAttSpeedAdded, curframe)
  '    If wexatt.HasValue Then
  '      IAS += wexatt
  '    End If

  '    Dim agi = mOwnerStats.Item(0).GetValue(curframe)
  '    If agi.HasValue Then
  '      IAS += agi
  '    End If

  '    Dim attspeed As Double? = (100 + IAS) * 0.01 / BaseAttackTime

  '    Dim perclist As New List(Of Double?)
  '    For a As Integer = 0 To mAttackSpeedPercentAdded.Count - 1
  '      Dim curval = mAttackSpeedPercentAdded.Item(a).Value(curframe)
  '      If curval.HasValue Then
  '        perclist.Add(attspeed * curval)
  '      End If
  '    Next

  '    For c As Integer = 0 To mBuildingAttackSeedPercentAdded.Count - 1
  '      Dim curval = mBuildingAttackSeedPercentAdded.Item(c).Value(curframe)
  '      If curval.HasValue Then
  '        perclist.Add(attspeed * curval)
  '      End If
  '    Next

  '    For b As Integer = 0 To perclist.Count - 1
  '      attspeed += perclist.Item(b)
  '    Next
  '    outlist.Add(attspeed)
  '  Next
  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAttackSpeedDebuffs()
  '  'modtypes list
  '  modtypes.Add(eModifierType.AttackspeedSubtracted)
  '  modtypes.Add(eModifierType.NightAttackSpeedSubtracted)
  '  modtypes.Add(eModifierType.AttackSpeedPercentSubtracted)
  '  modtypes.Add(eModifierType.BaseAttackTime)
  '  modtypes.Add(eModifierType.BaseAttackTimeChangedTo)
  '  modtypes.Add(eModifierType.AttackSpeedMaxed)
  '  modtypes.Add(eModifierType.RightClickAttackAttackSlowInflicted)
  '  'stattypes list


  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  'dim lists for each modtype
  '  Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)
  '  Dim mNightAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.NightAttackSpeedSubtracted)
  '  Dim mAttSpdPercentSubtracted = thelist.GetModsByType(eModifierType.AttackSpeedPercentSubtracted)
  '  Dim mBaseAttackSpeedChangedto = thelist.GetModsByType(eModifierType.BaseAttackTimeChangedTo)
  '  Dim mAttackSpeedMaxed = thelist.GetModsByType(eModifierType.AttackSpeedMaxed)
  '  Dim mBaseAttackTimes = thelist.GetModsByType(eModifierType.BaseAttackTime)
  '  Dim mRclickAttSlow = thelist.GetModsByType(eModifierType.RightClickAttackAttackSlowInflicted)

  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)

  '    Dim maxval = ModFilters.GetSumOfModsForTime(mAttackSpeedMaxed, curframe)
  '    If maxval.HasValue Then
  '      outlist.Add(Nothing)
  '      Continue For
  '    End If

  '    Dim BaseAttackTime As Double?
  '    If mBaseAttackSpeedChangedto.Count > 0 Then
  '      BaseAttackTime = mBaseAttackSpeedChangedto.Item(0).Value(curframe)
  '    Else
  '      BaseAttackTime = mBaseAttackTimes.Item(0).Value(curframe)
  '    End If

  '    Dim IAS As Double?

  '    Dim attsubd = ModFilters.GetSumOfModsForTime(mAttackSpeedSubtracted, curframe)
  '    If attsubd.HasValue Then
  '      IAS += attsubd
  '    End If

  '    Dim nitsubd = ModFilters.GetSumOfModsForTime(mNightAttackSpeedSubtracted, curframe)
  '    If nitsubd.HasValue Then
  '      IAS += nitsubd
  '    End If

  '    Dim rclickslow = ModFilters.GetSumOfModsForTime(mRclickAttSlow, curframe)
  '    If rclickslow.HasValue Then
  '      IAS += rclickslow
  '    End If

  '    Dim attspeed As Double? = IAS * 0.01 / BaseAttackTime

  '    Dim perclist As New List(Of Double?)
  '    For a As Integer = 0 To mAttSpdPercentSubtracted.Count - 1
  '      Dim curval = mAttSpdPercentSubtracted.Item(a).Value(curframe)
  '      If curval.HasValue Then
  '        perclist.Add(curval * IAS)
  '      End If
  '    Next

  '    For b As Integer = 0 To perclist.Count - 1
  '      attspeed += (perclist.Item(b))
  '    Next
  '    outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist

  'End Sub
  'Private Sub CalcAttackDamage( islow As Boolean)
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)
  '  Select Case islow
  '    Case True
  '      modtypes.Add(eModifierType.BaseAttackDamageLow)
  '    Case False
  '      modtypes.Add(eModifierType.BaseAttackDamageHigh)
  '  End Select
  '  'add rest of mods here

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist

  'End Sub

  'Private Sub CalcAttackDamageBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)
  '  'modtypes.Add(eModifierType.RightClickAttackAttackSlowInflicted) 'Right click attack also adds an attack speed debuff to target 
  '  modtypes.Add(eModifierType.RightClickAttackDamage) 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
  '  modtypes.Add(eModifierType.RightClickBonusDamageAdded) 'TB Metamorphosis 
  '  modtypes.Add(eModifierType.RightClickBonusDamageInflicted) 'Faceless Void Time Lock 
  '  'modtypes.Add(eModifierType.RightClickBonusPureDamageInflicted) 'Spectre Desolate 
  '  'modtypes.Add(eModifierType.RightClickBurnedMana) 'Necro Warrior Mana Break 
  '  modtypes.Add(eModifierType.RightClickCausticFinale) 'Sand King Caustic Finale added 
  '  modtypes.Add(eModifierType.RightClickCounterAttack) 'Axw counter helix, LC MomentofCOurage 
  '  modtypes.Add(eModifierType.RightClickDamageAdded) 'LC Duel 
  '  modtypes.Add(eModifierType.RightClickDamageAsLine) 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
  '  modtypes.Add(eModifierType.RightClickDamageAsPercOfTargetCurrHP) 'lifestealer Feast 
  '  modtypes.Add(eModifierType.RightClickDamageInflicted) 'Windranger Focus Fire 
  '  'modtypes.Add(eModifierType.RightClickDamageInstanceAvoided) 'Faceless BackTrack 
  '  modtypes.Add(eModifierType.RightClickDamageMultipleInflicted) 'Phantom Ass, Coup de Grace 
  '  modtypes.Add(eModifierType.RightClickDamageMultiplier) 'weaver germinate 

  '  modtypes.Add(eModifierType.RightClickDamageoT) 'Right Click attack also puts a DoT on target 
  '  modtypes.Add(eModifierType.RightClickDamagePercentageInflicted)
  '  modtypes.Add(eModifierType.RightClickDamagePercentInflicted) 'Phantom Lancer Spirit Lance Illusion damage 
  '  'modtypes.Add(eModifierType.RightClickDamagePercentSubtracted) 'SF Requiem of Souls 
  '  modtypes.Add(eModifierType.RightClickDamageWithBuffs) 'gyro flak cannon 
  '  modtypes.Add(eModifierType.RightClickDamageWithoutBuffs) 'gyro flak cannon 
  '  modtypes.Add(eModifierType.RightClickDamPhysStackingInflicted) 'Ursa furry swipes 
  '  modtypes.Add(eModifierType.RightClickHealthasDamagePercInflicted) 'Ursa Enrage 
  '  ' modtypes.Add(eModifierType.RightClickInttoPureDamage) 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage 
  '  modtypes.Add(eModifierType.RightClickMoonGlaiveBounces) 'Luna moon glaive 
  '  ' modtypes.Add(eModifierType.RightClickMoveSpeedPercSubtracted) 'Meepo Geostrike 
  '  modtypes.Add(eModifierType.RightClickNetherToxinDamage) 'Viper Nethertoxin does damage for each 20% of health missing in target 
  '  ' modtypes.Add(eModifierType.RightClickPureDamageInflicted) 'Warlock Golem Flaming Fists 
  '  ' modtypes.Add(eModifierType.RightClickStun) 'Faceless TimeLock )

  '  'stattypes list
  '  Select Case GetPrimaryAttribute()
  '    Case ePrimaryStat.Strength
  '      stattypes.Add(eStat.Strength)
  '    Case ePrimaryStat.Intelligence
  '      stattypes.Add(eStat.Intelligence)
  '    Case ePrimaryStat.Agility
  '      stattypes.Add(eStat.Agility)
  '  End Select


  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)

  '  Dim mRightClickAttackDamage = thelist.GetModsByType(eModifierType.RightClickAttackDamage) 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
  '  Dim mRightClickBonusDamageAdded = thelist.GetModsByType(eModifierType.RightClickBonusDamageAdded) 'TB Metamorphosis 
  '  Dim mRightClickBonusDamageInflicted = thelist.GetModsByType(eModifierType.RightClickBonusDamageInflicted) 'Faceless Void Time Lock 

  '  Dim mRightClickCausticFinale = thelist.GetModsByType(eModifierType.RightClickCausticFinale) 'Sand King Caustic Finale added 
  '  Dim mRightClickCounterAttack = thelist.GetModsByType(eModifierType.RightClickCounterAttack) 'Axw counter helix, LC MomentofCOurage 
  '  Dim mRightClickDamageAdded = thelist.GetModsByType(eModifierType.RightClickDamageAdded) 'LC Duel 
  '  Dim mRightClickDamageAsLine = thelist.GetModsByType(eModifierType.RightClickDamageAsLine) 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
  '  Dim mRightClickDamageAsPercOfTargetCurrHP = thelist.GetModsByType(eModifierType.RightClickDamageAsPercOfTargetCurrHP) 'lifestealer Feast 
  '  Dim mRightClickDamageInflicted = thelist.GetModsByType(eModifierType.RightClickDamageInflicted) 'Windranger Focus Fire 

  '  Dim mRightClickDamageMultipleInflicted = thelist.GetModsByType(eModifierType.RightClickDamageMultipleInflicted) 'Phantom Ass, Coup de Grace 
  '  Dim mRightClickDamageMultiplier = thelist.GetModsByType(eModifierType.RightClickDamageMultiplier) 'weaver germinate 

  '  Dim mRightClickDamageoT = thelist.GetModsByType(eModifierType.RightClickDamageoT) 'Right Click attack also puts a DoT on target 
  '  Dim mRightClickDamagePercentageInflicted = thelist.GetModsByType(eModifierType.RightClickDamagePercentageInflicted)
  '  Dim mRightClickDamagePercentInflicted = thelist.GetModsByType(eModifierType.RightClickDamagePercentageInflicted) 'Phantom Lancer Spirit Lance Illusion damage 

  '  Dim mRightClickDamageWithBuffs = thelist.GetModsByType(eModifierType.RightClickDamageWithBuffs) 'gyro flak cannon 
  '  Dim mRightClickDamageWithoutBuffs = thelist.GetModsByType(eModifierType.RightClickDamageWithoutBuffs) 'gyro flak cannon 
  '  Dim mRightClickDamPhysStackingInflicted = thelist.GetModsByType(eModifierType.RightClickDamPhysStackingInflicted) 'Ursa furry swipes 
  '  Dim mRightClickHealthasDamagePercInflicted = thelist.GetModsByType(eModifierType.RightClickHealthasDamagePercInflicted) 'Ursa Enrage 

  '  Dim mRightClickMoonGlaiveBounces = thelist.GetModsByType(eModifierType.RightClickMoonGlaiveBounces) 'Luna moon glaive 

  '  Dim mRightClickNetherToxinDamage = thelist.GetModsByType(eModifierType.RightClickNetherToxinDamage) 'Viper Nethertoxin does damage for each 20% of health missing in target 



  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)

  '    Dim RightClickAttackDamageval = ModFilters.GetSumOfModsForTime(mRightClickAttackDamage, curframe) 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
  '    If RightClickAttackDamageval.HasValue Then
  '      llhkj()
  '    End If

  '    Dim RightClickBonusDamageAddedval = ModFilters.GetSumOfModsForTime(mRightClickBonusDamageAdded, curframe) 'TB Metamorphosis 
  '    If RightClickBonusDamageAddedval.HasValue Then

  '    End If

  '    Dim RightClickBonusDamageInflictedval = ModFilters.GetSumOfModsForTime(mRightClickBonusDamageInflicted, curframe) 'Faceless Void Time Lock 
  '    If RightClickBonusDamageInflictedval.HasValue Then

  '    End If

  '    Dim RightClickCausticFinaleval = ModFilters.GetSumOfModsForTime(mRightClickCausticFinale, curframe) 'Sand King Caustic Finale added 
  '    If RightClickCausticFinaleval.HasValue Then

  '    End If

  '    Dim RightClickCounterAttackval = ModFilters.GetSumOfModsForTime(mRightClickCounterAttack, curframe) 'Axw counter helix, LC MomentofCOurage 
  '    If RightClickCounterAttackval.HasValue Then

  '    End If

  '    Dim RightClickDamageAddedval = ModFilters.GetSumOfModsForTime(mRightClickDamageAdded, curframe) 'LC Duel 
  '    If RightClickDamageAddedval.HasValue Then

  '    End If

  '    Dim RightClickDamageAsLineval = ModFilters.GetSumOfModsForTime(mRightClickDamageAsLine, curframe) 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
  '    If RightClickDamageAsLineval.HasValue Then

  '    End If

  '    Dim RightClickDamageAsPercOfTargetCurrHPval = ModFilters.GetSumOfModsForTime(mRightClickDamageAsPercOfTargetCurrHP, curframe) 'lifestealer Feast 
  '    If RightClickDamageAsPercOfTargetCurrHPval.HasValue Then

  '    End If

  '    Dim RightClickDamageInflictedval = ModFilters.GetSumOfModsForTime(mRightClickDamageInflicted, curframe) 'Windranger Focus Fire
  '    If RightClickBonusDamageInflictedval.HasValue Then

  '    End If


  '    Dim RightClickDamageoTval = ModFilters.GetSumOfModsForTime(mRightClickDamageoT, curframe) 'Right Click attack also puts a DoT on target 
  '    If RightClickDamageoTval.HasValue Then

  '    End If

  '    Dim RightClickDamageWithBuffsval = ModFilters.GetSumOfModsForTime(mRightClickDamageWithBuffs, curframe) 'gyro flak cannon 
  '    If RightClickDamageWithBuffsval.HasValue Then

  '    End If

  '    Dim RightClickDamageWithoutBuffsval = ModFilters.GetSumOfModsForTime(mRightClickDamageWithoutBuffs, curframe) 'gyro flak cannon 
  '    If RightClickDamageWithoutBuffsval.HasValue Then

  '    End If

  '    Dim RightClickDamPhysStackingInflictedval = ModFilters.GetSumOfModsForTime(mRightClickDamPhysStackingInflicted, curframe) 'Ursa furry swipes 
  '    If RightClickDamPhysStackingInflictedval.HasValue Then

  '    End If

  '    Dim RightClickNetherToxinDamageval = ModFilters.GetSumOfModsForTime(mRightClickNetherToxinDamage, curframe) 'Viper Nethertoxin does damage for each 20% of health missing in target 
  '    If RightClickNetherToxinDamageval.HasValue Then

  '    End If

  '    Dim RightClickHealthasDamagePercInflictedval = ModFilters.GetSumOfModsForTime(mRightClickHealthasDamagePercInflicted, curframe) 'Ursa Enrage 
  '    If RightClickHealthasDamagePercInflictedval.HasValue Then
  '      'need to get fury ability for it's curdamage to calc this
  '    End If

  '    For a As Integer = 0 To mRightClickDamageMultipleInflicted.Count - 1

  '    Next

  '    For b As Integer = 0 To mRightClickDamageMultiplier.Count - 1

  '    Next

  '    For c As Integer = 0 To mRightClickDamagePercentageInflicted.Count - 1

  '    Next

  '    For d As Integer = 0 To mRightClickDamagePercentInflicted.Count - 1

  '    Next


  '    For e As Integer = 0 To mRightClickMoonGlaiveBounces.Count

  '    Next


  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAttackDamageDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)
  '  'modtypes.Add(eModifierType.RightClickAttackAttackSlowInflicted) 'Right click attack also adds an attack speed debuff to target 
  '  'modtypes.Add(eModifierType.RightClickAttackDamage) 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
  '  'modtypes.Add(eModifierType.RightClickBonusDamageAdded) 'TB Metamorphosis 
  '  'modtypes.Add(eModifierType.RightClickBonusDamageInflicted) 'Faceless Void Time Lock 
  '  'modtypes.Add(eModifierType.RightClickBonusPureDamageInflicted) 'Spectre Desolate 
  '  ' modtypes.Add(eModifierType.RightClickBurnedMana) 'Necro Warrior Mana Break 
  '  'modtypes.Add(eModifierType.RightClickCausticFinale) 'Sand King Caustic Finale added 
  '  'modtypes.Add(eModifierType.RightClickCounterAttack) 'Axw counter helix, LC MomentofCOurage 
  '  'modtypes.Add(eModifierType.RightClickDamageAdded) 'LC Duel 
  '  'modtypes.Add(eModifierType.RightClickDamageAsLine) 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
  '  'modtypes.Add(eModifierType.RightClickDamageAsPercOfTargetCurrHP) 'lifestealer Feast 
  '  'modtypes.Add(eModifierType.RightClickDamageInflicted) 'Windranger Focus Fire 
  '  'modtypes.Add(eModifierType.RightClickDamageInstanceAvoided) 'Faceless BackTrack 
  '  'modtypes.Add(eModifierType.RightClickDamageMultipleInflicted) 'Phantom Ass, Coup de Grace 
  '  'modtypes.Add(eModifierType.RightClickDamageMultiplier) 'weaver germinate 
  '  'modtypes.Add(eModifierType.RightClickDamageoT) 'Right Click attack also puts a DoT on target 
  '  'modtypes.Add(eModifierType.RightClickDamagePercentageInflicted)
  '  'modtypes.Add(eModifierType.RightClickDamagePercentInflicted) 'Phantom Lancer Spirit Lance Illusion damage 
  '  modtypes.Add(eModifierType.RightClickDamagePercentSubtracted) 'SF Requiem of Souls 
  '  ' modtypes.Add(eModifierType.RightClickDamageWithBuffs) 'gyro flak cannon 
  '  'modtypes.Add(eModifierType.RightClickDamageWithoutBuffs) 'gyro flak cannon 
  '  'modtypes.Add(eModifierType.RightClickDamPhysStackingInflicted) 'Ursa furry swipes 
  '  'modtypes.Add(eModifierType.RightClickHealthasDamagePercInflicted) 'Ursa Enrage 
  '  ' modtypes.Add(eModifierType.RightClickInttoPureDamage) 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage 
  '  'modtypes.Add(eModifierType.RightClickMoonGlaiveBounces) 'Luna moon glaive 
  '  ' modtypes.Add(eModifierType.RightClickMoveSpeedPercSubtracted) 'Meepo Geostrike 
  '  'modtypes.Add(eModifierType.RightClickNetherToxinDamage) 'Viper Nethertoxin does damage for each 20% of health missing in target 
  '  ' modtypes.Add(eModifierType.RightClickPureDamageInflicted) 'Warlock Golem Flaming Fists 
  '  ' modtypes.Add(eModifierType.RightClickStun) 'Faceless TimeLock )
  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.AttackDamageBuffs)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)
  '  Dim mRightClickDamagePercentSubtracted = thelist.GetModsByType(eModifierType.RightClickDamagePercentSubtracted) 'SF Requiem of Souls 

  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)

  '    For a As Integer = 0 To mRightClickDamagePercentSubtracted.Count - 1

  '    Next

  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAttackRange()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAttackRangeBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAttackRangeDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcBonusAttackDamage()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalArmor()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalArmorBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalArmorDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalDamageResistance()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalDamageResistanceBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalDamageResistanceDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMagicalDamageResistance()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMagicalDamageResistanceBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMagicalDamageResistanceDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMovementSpeed()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMovementSpeedbuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMovementSpeedDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcStrength()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcStrengthBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcStrengthDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAgility()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAgilityBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcAgilityDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcIntelligence()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcIntelligenceBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcIntelligenceDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcGold()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcGoldBuffs() '(Hand of midas)	
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcGoldDebuffs() '(not sure there are any)	
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcExperience()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMagicDamage()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMagicDamageBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMagicDamageDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalDamage()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalDamageBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPhysicalDamageDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPureDamage()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPureDamageBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcPureDamageDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcHitPoints()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcHitPointBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcHitPointDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcHitPointRegen()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcHitPointRegenBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcHitPointRegenDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcMana()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcManaBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcManadebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcManaRegen()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcManaRegenBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcManaRegenDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcVision()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcVisionBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcVisionDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcTrueSight()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcTrueSightBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcTrueSightDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcStealth()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcStealthBuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub
  'Private Sub CalcStealthDebuffs()
  '  'modtypes list
  '  'modtypes.Add(eModifierType.AttackspeedSubtracted)

  '  'stattypes list
  '  'stattypes.Add(eStat.Agility)

  '  Dim thelist As New ModifierList
  '  mOwnerMods = modDB.GetModsByParentAndTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerAsTargetMods = modDB.GetModsByTargetandTypes(mParentID, modtypes)
  '  thelist.AddList(mOwnerMods)

  '  mOwnerStats = modDB.GetStatsByParentandType(mParentID, eStat.Agility)

  '  'dim lists for each modtype
  '  'Dim mAttackSpeedSubtracted = thelist.GetModsByType(eModifierType.AttackspeedSubtracted)


  '  Dim outlist As New List(Of Double?)

  '  For i As Integer = 0 To gametimepoints.TheFrames.Count = 1
  '    Dim curframe = gametimepoints.TheFrames.Item(i)


  '    ' outlist.Add(attspeed)
  '  Next

  '  mValue = New ValueList(gametimepoints.TheFrames)
  '  mValue.valuelist = outlist
  'End Sub

End Class
