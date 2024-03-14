
Public Enum eAbilityType
  UnitTarget '= 0
  UnitTargetAura
  UnitTeam 'centaur stampede
  UnitTreeTarget
  PointTarget
  PointTargetAura '= 1
  PointTargetChanneled
  Passive '= 3
  PassiveAura '= 4
  ActiveAura
  AutoCast '= 5
  NoTarget '= 6
  Toggle '= 7
  ToggleAura
  Channeled '= 8
  ChnneledAura
  MapWideAura
  NoTargetCone
  PointTargetCone
  UnitTargetCone
  PointTargetLine
  NoTargetLine
  Trail
  Stats
End Enum

'Public Enum eBarColor
'  None = 0
'  Parent
'  Source
'  Value
'  Team
'End Enum
'Public Enum eBadgeAppearance
'  None
'  Full
'  Stats
'End Enum
Public Enum eBarType
  None
  Value
  Parent
  Source
  Team
  'Both
End Enum

Public Enum eChartType
  None
  Split
  Stacked
  Advantage
End Enum
Public Enum eValueFormat
  None
  DecimalNumber
  WholeNumber
  Percent
  ValuePerSecond
  NotForDisplay
  DurationInSeconds
  TrueFalse
End Enum
Public Enum eDetailsType
  None
  Item
  Ability
  Hero
  Modifier
  GraphBar
  Stat
End Enum

Public Enum eRectColor
  None
  Owner
  Source
  Team
End Enum

Public Enum eGraphType
  None
  TeamsStacked
  VersusSplitBars
  Advantage
End Enum

Public Enum ePanetype
  None
  TeamsStacked
  'VersusBars 'two stacked bars side by side, one for radiant, one for dire
  Advantage
  DireTeamStacked
  RadiantTeamStacked
End Enum

Public Enum eItemPlan
  KeepForever
  SellAtOnce ' for components from disassembly
  SellForSpace
  Disassemble
  UseAtOnce 'Courier, Wards?
  UseFor1Level 'Tangos, Clarity.... to calc potential heal and mana
  UseFor2Levels
  UseFor3Levels
  UseFor4Levels
  UseFor5Levels
End Enum
Public Enum eZoomLevel
  Modifiers
  Stats
  Items
  Abilities
  ItemandAbilities
  Hero
  Heroes
  Team
  Teams
  Game
  Games
  Version
  Versions
End Enum

Public Enum eTeamTimeFrame
  none
  OneSecond
  FiveSecond
  TenSecond
  ThirtySecond
  OneMinute
  FiveMinute
  FifteenMinute
End Enum

Public Enum eTeamName
  None
  Radiant
  Dire
End Enum
Public Enum eHeroTimeFrame
  OneMinute
  FiveMinute
  TenMinute
  OneLevel
End Enum
Public Enum ePriorityGoldXP
  None
  Priority1
  Priority2
  Priority3
  Priority4
  Priority5
End Enum

Public Enum eStatSource
  Self
  TeamMembers
  EnemyTeamMembers
End Enum
Public Enum eUnit
  None = 0

  'Units----------------------------------------------
  untRandomUnit
  untRandomEnemyUnit
  untEnemyHero
  untEnemyHeroNearest
  untEnemyUnitNearest
  untAlliedIllusion
  untEnemyIllusion
  untEnemyPet
  untEnemyHeroes
  untEnemyUnit
  untEnemyUnits

  untTwoRandomEnemyUnits 'Ember Spirit Searing Chains
  untUntargetedEnemyUnits 'scepter finger of death aoe damage
  'untEnemyUnitRandom
  untEnemyUnitsNotTargetted ' gyro flak cannon
  untEnemyUnitwLowestHealth 'razor ulti
  untEnemyStealthUnits
  untEnemyRangedTarget 'Skull Basher bash
  untEnemyMeleeTarget 'Skull Bashser bash
  untUnitTarget '= 1
  untHaunt 'for Spectre TP to Haunt ability
  untEnemyTarget
  untDyingEnemyTarget 'Spiderling Spawn Spiderite
  untEnemyTargetsFixedCount 'for abilities that hit only x amount of targets
  untEnemySummonedUnit 'diffusalblade
  untEnemySummonedUnits 'Brewmaster Storm Dispel Magic
  untEnemyStructure
  untEnemyStructures
  untAttackingAbilityCastingEnemyUnits
  untAttackingEnemyUnit
  untPointTarget '= 2
  untPassive '= 3
  untAura '= 4
  untAutoCast '= 5
  untChanneled '= 6
  untNoTarget '= 7
  untNonHeroAlliedTeam 'illusions, pets, creeps under control and meepo clones on your team
  untToggle '= 8
  untHero
  untHeroes '= 9
  untAllHeroesAndCreeps
  untAlliedHero
  untAlliedHeroes '= 10
  untAlliedTeam 'includes all player controlled units
  untTargettedAlly 'HillTroll Priest Heal
  untAlly
  untAlliedUnit
  untAlliedUnits '= 11
  untAlliedUnitsAndSelf 'Enchantress Nature's Attendants. Need one pool for random target determination, so self can't be seperate
  untControlledUnits 'specifivally, only units controlled by the specific hero using this enum
  untAllAlliedControlledUnits 'Lycan Howl
  untAlliedMeleeUnits
  untAlliedRangeUnits 'drow precison aura
  untAlliedRangeHeroes
  untAlliedNonHeroUnits
  untAlliedStructure
  untAlliedHerosAttackingCastersTarget
  untEnemieTeam
  untEnemyTargettingCaster
  untCreep
  untAlliedCreep
  untEnemyCreeps
  untEnemyCreep '= 13 'http://www.reddit.com/r/DotA2/comments/2eulqu/some_facts_about_creep_exp/
  unitTargettedEnemyCreep 'doom devour
  untUnit
  untUnits '= 14

  untRadiant '= 15
  untDire '= 16

  untEarthshaker '= 17
  untSven '= 18
  untTiny '= 19
  untKunkka '= 20
  untBeastmaster '= 21
  untDragon_Knight '= 22
  untClockwerk '= 23
  untOmniknight '= 24
  untHuskar '= 25
  untAlchemist '= 26
  untBrewmaster '= 27
  untTreant_Protector '= 28
  untIo '= 29
  untCentaur_Warrunner '= 30
  untTimbersaw '= 31
  untBristleback '= 32
  untTusk '= 33
  untElder_Titan '= 34
  untLegion_Commander '= 35
  untEarth_Spirit '= 36
  untPhoenix '= 37
  untAnti_Mage '= 38
  untDrow_Ranger '= 39
  untJuggernaut '= 40
  untMirana '= 41
  untMorphling '= 42
  untPhantom_Lancer '= 43
  untVengeful_Spirit '= 44
  untRiki '= 45
  untSniper '= 46
  untTemplar_Assassin '= 47
  untLuna '= 48
  untBounty_Hunter '= 49
  untUrsa '= 50
  untGyrocopter '= 51
  untLone_Druid '= 52
  untNaga_Siren '= 53
  untTroll_Warlord '= 54
  untEmber_Spirit '= 55
  untCrystal_Maiden '= 56
  untPuck '= 57
  untStorm_Spirit '= 58
  untWindranger '= 59
  untZeus '= 60
  untLina '= 61
  untShadow_Shaman '= 62
  untTinker '= 63
  untNatures_Prophet '= 64
  untEnchantress '= 65
  untJakiro '= 66
  untChen '= 67
  untSilencer '= 68
  untOgre_Magi '= 69
  untRubick '= 70
  untDisruptor '= 71
  untKeeper_of_the_Light '= 72
  untSkywrath_Mage '= 73
  untAxe '= 74
  untPudge '= 75
  untSand_King '= 76
  untSlardar '= 77
  untTidehunter '= 78
  untWraith_King '= 79
  untLifestealer '= 80
  untNight_Stalker '= 81
  untDoom '= 82
  untSpirit_Breaker '= 83
  untLycan '= 84
  untChaos_Knight '= 85
  untUndying '= 86
  untMagnus '= 87
  untAbaddon '= 88
  untBloodseeker '= 89
  untShadow_Fiend '= 90
  untRazor '= 91
  untVenomancer '= 92
  untFaceless_Void ' = 93
  untPhantom_Assassin '= 94
  untViper '= 95
  untClinkz '= 96
  untBroodmother '= 97
  untWeaver '= 98
  untSpectre '= 99
  untMeepo '= 100
  untMeepo_Clone
  untNyx_Assassin '= 101
  untSlark '= 102
  untMedusa '= 103
  untTerrorblade '= 104
  untBane '= 105
  untLich '= 106
  untLion '= 107
  untWitch_Doctor '= 108
  untEnigma '= 109
  untNecrophos '= 110
  untWarlock '= 111
  untQueen_of_Pain '= 112
  untDeath_Prophet '= 113
  untPugna '= 114
  untDazzle '= 115
  untLeshrac '= 116
  untDark_Seer '= 117
  untBatrider '= 118
  untAncient_Apparition '= 119
  untInvoker '= 120
  untOutworld_Devourer '= 121
  untShadow_Demon '= 122
  untVisage '= 123
  untTechies

  untTree
  untTrees 'Beastmaster Wild Axes

  untHawk
  untBoar
  untLycan_Wolf
  untUndying_Zombie
  untSpiderling
  untSpiderite
  untTreant
  untEidolon
  untForged_Spirit
  untSkeleton_Warrior
  untNecro_Warrior
  untNecro_Archer
  untEarth_Brewmaster
  untStorm_Brewmaster
  untFire_Brewmaster
  untGolem_Warlock
  untSpirit_Bear
  untFamiliar
  untPlague_Ward
  untSerpent_Ward
  untDeath_Ward
  untHealing_Ward
  untFrozen_Sigil
  untTornado
  untPsionic_Trap
  untLand_Mine
  untStasis_Trap
  untRemote_Mine
  untNether_Ward
  untPower_Cog
  untTombstone
  untPhoenix_Sun
  untObserver_Ward
  untSentry_Ward
  untMelee_Creep
  untSuper_Melee_Creep
  untMega_Melee_Creep
  untRanged_Creep
  untSuper_Ranged_Creep
  untMega_Ranged_Creep
  untSiege_Creep
  untSiege_Creep_Bonus
  untKobold
  untKobold_Soldier
  untKobold_Foreman
  untHill_Troll_Berserker
  untHill_Troll_Priest
  untVhoul_Assassin
  untFell_Spirit
  untGhost
  untHarpy_Scout
  untHarpy_Stormcrafter
  untCentaur_Conqueror
  untCentaur_Courser
  untGiant_Wolf
  untAlpha_Wolf
  untSatyr_Banisher
  untSatyr_Mindstealer
  untOgre_Bruiser
  untOgre_Frostmage
  untMud_Golem
  untSatyr_Tormentor
  untHellbear
  untHellbear_Smasher
  untWildwing
  untWildwing_Ripper
  untDark_Troll_Summoner
  untHill_Trll
  untAncient_Black_Dragon
  untAncient_Black_Drake
  untAncient_Granite_Golem
  untAncient_Rock_Golem
  untAncient_Thunderhide
  untAncient_Rumblehide
  untRoshan


  untSelf '= 17
  untOwnersPets 'Lone Druid Rabid

  untBuilding
  untBuildings

  untSpirit 'Death Prophet ult
  untHoming_Missile 'Gyro ult
  untPet_Phantom_Lancer
End Enum
Public Enum eDamageType
  None
  Physical '= 0
  Magical '= 1
  ' Composite '= 2
  Pure '= 4
  ' HPRemoval '= 5
  'Universal '= 6
End Enum

Public Enum eDataItemType
  None
  Modifier
  Stat
End Enum
Public Enum eHeroName
  None
  untEarthshaker '= 17
  untSven '= 18
  untTiny '= 19
  untKunkka '= 20
  untBeastmaster '= 21
  untDragon_Knight '= 22
  untClockwerk '= 23
  untOmniknight '= 24
  untHuskar '= 25
  untAlchemist '= 26
  untBrewmaster '= 27
  untTreant_Protector '= 28
  untIo '= 29
  untCentaur_Warrunner '= 30
  untTimbersaw '= 31
  untBristleback '= 32
  untTusk '= 33
  untElder_Titan '= 34
  untLegion_Commander '= 35
  untEarth_Spirit '= 36
  untPhoenix '= 37
  untAnti_Mage '= 38
  untDrow_Ranger '= 39
  untJuggernaut '= 40
  untMirana '= 41
  untMorphling '= 42
  untPhantom_Lancer '= 43
  untVengeful_Spirit '= 44
  untRiki '= 45
  untSniper '= 46
  untTemplar_Assassin '= 47
  untLuna '= 48
  untBounty_Hunter '= 49
  untUrsa '= 50
  untGyrocopter '= 51
  untLone_Druid '= 52
  untNaga_Siren '= 53
  untTroll_Warlord '= 54
  untEmber_Spirit '= 55
  untCrystal_Maiden '= 56
  untPuck '= 57
  untStorm_Spirit '= 58
  untWindranger '= 59
  untZeus '= 60
  untLina '= 61
  untShadow_Shaman '= 62
  untTinker '= 63
  untNatures_Prophet '= 64
  untEnchantress '= 65
  untJakiro '= 66
  untChen '= 67
  untSilencer '= 68
  untOgre_Magi '= 69
  untRubick '= 70
  untDisruptor '= 71
  untKeeper_of_the_Light '= 72
  untSkywrath_Mage '= 73
  untAxe '= 74
  untPudge '= 75
  untSand_King '= 76
  untSlardar '= 77
  untTidehunter '= 78
  untWraith_King '= 79
  untLifestealer '= 80
  untNight_Stalker '= 81
  untDoom '= 82
  untSpirit_Breaker '= 83
  untLycan '= 84
  untChaos_Knight '= 85
  untUndying '= 86
  untMagnus '= 87
  untAbaddon '= 88
  untBloodseeker '= 89
  untShadow_Fiend '= 90
  untRazor '= 91
  untVenomancer '= 92
  untFaceless_Void ' = 93
  untPhantom_Assassin '= 94
  untViper '= 95
  untClinkz '= 96
  untBroodmother '= 97
  untWeaver '= 98
  untSpectre '= 99
  untMeepo '= 100
  untNyx_Assassin '= 101
  untSlark '= 102
  untMedusa '= 103
  untTerrorblade '= 104
  untBane '= 105
  untLich '= 106
  untLion '= 107
  untWitch_Doctor '= 108
  untEnigma '= 109
  untNecrophos '= 110
  untWarlock '= 111
  untQueen_of_Pain '= 112
  untDeath_Prophet '= 113
  untPugna '= 114
  untDazzle '= 115
  untLeshrac '= 116
  untDark_Seer '= 117
  untBatrider '= 118
  untAncient_Apparition '= 119
  untInvoker '= 120
  untOutworld_Devourer '= 121
  untShadow_Demon '= 122
  untVisage '= 123
  untTechies
End Enum

Public Enum CreepSource
  None
  Game
  Item
  Ability
End Enum

Public Enum ePetName
  None
  untBeetle
  untHawk
  untBoar
  untUndying_Zombie
  untLycan_Wolf
  untSpiderling
  untSpiderite
  untSpin_Web
  untTreant
  untEidolon
  untForged_Spirit
  untEarth_Brewmaster
  untStorm_Brewmaster
  untFire_Brewmaster
  untGolem_Warlock
  untSpirit_Bear
  untFamiliar
  untPlague_Ward
  untSerpent_Ward
  untDeath_Ward
  untHoming_Missile
  untPsionic_Trap
  untLand_Mine
  untStasis_Trap
  untRemote_Mine
  untNether_Ward
  untPower_Cog
  untTombstone
  untPhoenix_Sun
  untObserver_Ward
  untSentry_Ward
  untHealing_Ward
  untFrozen_Sigil
  untTornado
  untAstral_Spirit
  untSpirit
  untPet_Phantom_Lancer
  untMeepo_Clone
  untNaga_Siren_Illusion
  untDragonKnight_Elder_Dragon_Form
  untMorphling_Replicant
  untTerrorblade_Reflection
  untTerrorblade_Illusion
  untTerrorblade_Demon
End Enum
Public Enum eCreepName
  None
  untSkeleton_Warrior
  untNecro_Warrior
  untNecro_Archer
  untMelee_Creep
  untSuper_Melee_Creep
  untMega_Melee_Creep
  untRanged_Creep
  untSuper_Ranged_Creep
  untMega_Ranged_Creep
  untSiege_Creep
  untSiege_Creep_Bonus
  untKobold
  untKobold_Soldier
  untKobold_Foreman
  untHill_Troll_Berserker
  untHill_Troll_Priest
  untVhoul_Assassin
  untFell_Spirit
  untHarpy_Scout
  untHarpy_Stormcrafter
  untCentaur_Conqueror
  untCentaur_Courser
  untGiant_Wolf
  untAlpha_Wolf
  untSatyr_Banisher
  untSatyr_Mindstealer
  untOgre_Bruiser
  untOgre_Frostmage
  untMud_Golem
  untSatyr_Tormentor
  untHellbear
  untHellbear_Smasher
  untWildwing
  untWildwing_Ripper
  untDark_Troll_Summoner
  untHill_Trll
  untAncient_Black_Dragon
  untAncient_Black_Drake
  untAncient_Granite_Golem
  untAncient_Rock_Golem
  untAncient_Thunderhide
  untAncient_Rumblehide
  untRoshan
  untTower_Tier_1
  untTower_Tier_2
  untTower_Tier_3
  untTower_Tier_4
  untAncient
  untMelee_Barracks
  untRanged_Barracks
  untFountain
  untBuffer_Building
  untGhost
End Enum
Public Enum eItemname
  'Items----------------------------------------
  None
  itmCLARITY '= 0
  itmTANGO '= 1
  itmHEALING_SALVE '= 2
  itmSMOKE_OF_DECEIT '= 3
  itmTOWN_PORTAL_SCROLL '= 4
  itmDUST_OF_APPEARANCE '= 5
  itmANIMAL_COURIER '= 6
  itmFLYING_COURIER '= 7
  itmOBSERVER_WARD '= 8
  itmSENTRY_WARD '= 9
  itmBOTTLE '= 10

  itmIRON_BRANCH '= 11
  itmGAUNTLETS_OF_STRENGTH '= 12
  itmSLIPPERS_OF_AGILITY '= 13
  itmMANTLE_OF_INTELLIGENCE '= 14
  itmCIRCLET '= 15
  itmBELT_OF_STRENGTH '= 16
  itmBAND_OF_ELVENSKIN '= 17
  itmROBE_OF_THE_MAGI '= 18
  itmOGRE_CLUB '= 19
  itmBLADE_OF_ALACRITY '= 20
  itmSTAFF_OF_WIZARDRY '= 21
  itmULTIMATE_ORB '= 22

  itmRING_OF_PROTECTION '= 23
  itmQUELLING_BLADE '= 24
  itmSTOUT_SHIELD '= 25
  itmBLADES_OF_ATTACK '= 26
  itmCHAINMAIL '= 27
  itmHELM_OF_IRON_WILL '= 28
  itmBROADSWORD '= 29
  itmQUARTERSTAFF '= 30
  itmCLAYMORE '= 31
  itmJAVELIN '= 32
  itmPLATEMAIL '= 33
  itmMITHRIL_HAMMER '= 34

  itmMAGIC_STICK '= 35
  itmSAGES_MASK '= 36
  itmRING_OF_REGEN '= 37
  itmBOOTS_OF_SPEED '= 38
  itmGLOVES_OF_HASTE '= 39
  itmCLOAK '= 40
  itmGEM_OF_TRUE_SIGHT '= 41
  itmMORBID_MASK '= 42
  itmGHOST_SCEPTER '= 43
  itmTALISMAN_OF_EVASION '= 44
  itmBLINK_DAGGER '= 45
  itmSHADOW_AMULET '= 46
  itmWRAITH_BAND '= 47
  itmNULL_TALISMAN '= 48
  itmMAGIC_WAND '= 49
  itmBRACER '= 50
  itmPOOR_MANS_SHIELD '= 51
  itmSOUL_RING '= 52
  itmPHASE_BOOTS '= 53
  itmPOWER_TREADS '= 54
  itmOBLIVION_STAFF '= 55
  itmPERSEVERANCE '= 56
  itmHAND_OF_MIDAS '= 57
  itmBOOTS_OF_TRAVEL '= 58

  itmRING_OF_BASILIUS '= 59
  itmHEADDRESS '= 60
  itmBUCKLER '= 61
  itmURN_OF_SHADOWS '= 62
  itmRING_OF_AQUILA '= 63
  itmTRANQUIL_BOOTS '= 64
  itmMEDALLION_OF_COURAGE '= 65
  itmARCANE_BOOTS '= 66
  itmDRUM_OF_ENDURANCE '= 67
  itmVLADMIRS_OFFERING '= 68
  itmMEKANSM '= 69
  itmPIPE_OF_INSIGHT '= 70

  itmFORCE_STAFF '= 71
  itmNECRONOMICON_1 '= 72
  itmNECRONOMICON_2 '= 73
  itmNECRONOMICON_3 '= 74
  itmEULS_SCEPTER_OF_DIVINITY '= 75
  itmDAGON_1 '= 76
  itmDAGON_2 '= 77
  itmDAGON_3 '= 78
  itmDAGON_4 '= 79
  itmDAGON_5 '= 80
  itmVEIL_OF_DISCORD '= 81
  itmROD_OF_ATOS '= 82
  itmAGHANIMS_SCEPTER '= 83
  itmORCHID_MALEVOLENCE '= 84
  itmREFRESHER_ORB '= 85
  itmSCYTHE_OF_VYSE '= 86

  itmCRYSTALYS '= 87
  itmARMLET_OF_MORDIGGIAN '= 88
  itmSKULL_BASHER '= 89
  itmSHADOW_BLADE '= 90
  itmBATTLE_FURY '= 91
  itmETHEREAL_BLADE '= 92
  itmRADIANCE '= 93
  itmMONKEY_KING_BAR '= 94
  itmDAEDALUS '= 95
  itmBUTTERFLY '= 96
  itmDIVINE_RAPIER
  itmABYSSAL_BLADE '= 97

  itmHOOD_OF_DEFIANCE '= 98
  itmBLADE_MAIL '= 99
  itmVANGUARD '= 100
  itmSOUL_BOOSTER '= 101
  itmBLACK_KING_BAR '= 102
  itmSHIVAS_GUARD '= 103
  itmMANTA_STYLE '= 104
  itmBLOODSTONE '= 105
  itmLINKENS_SPHERE '= 106
  itmASSAULT_CUIRASS '= 107
  itmHEART_OF_TARRASQUE ' = 108

  itmHELM_OF_THE_DOMINATOR '= 109
  itmMASK_OF_MADNESS '= 110
  itmSANGE '= 111
  itmYASHA '= 112
  itmMAELSTROM '= 113
  itmDIFFUSAL_BLADE_1
  itmDIFFUSAL_BLADE_2 '= 114
  itmDESOLATOR '= 115
  itmHEAVENS_HALBERD '= 116
  itmSANGE_AND_YASHA '= 117
  itmMJOLLNIR '= 118
  itmEYE_OF_SKADI '= 119
  itmSATANIC '= 120

  itmDEMON_EDGE '= 121
  itmEAGLESONG '= 122
  itmREAVER '= 123
  itmSACRED_RELIC '= 124
  itmHYPERSTONE '= 125
  itmRING_OF_HEALTH '= 126
  itmVOID_STONE '= 127
  itmMYSTIC_STAFF '= 128
  itmENERGY_BOOSTER '= 129
  itmPOINT_BOOSTER '= 130
  itmVITALITY_BOOSTER ' = 131
  itmORB_OF_VENOM '= 132

  itmRECIPE_WRAITH_BAND '= 133
  itmRECIPE_NULL_TALISMAN '= 134
  itmRECIPE_MAGIC_WAND '= 135
  itmRECIPE_BRACER '= 136
  itmRECIPE_SOUL_RING '= 137
  itmRECIPE_HAND_OF_MIDAS '= 138
  itmRECIPE_BOOTS_OF_TRAVEL '= 139
  itmRECIPE_HEADDRESS '= 140
  itmRECIPE_BUCKLER '= 141
  itmRECIPE_URN_OF_SHADOWS '= 142
  itmRECIPE_MEDALLION_OF_COURAGE '= 143
  itmRECIPE_DRUM_OF_ENDURANCE '= 144
  itmRECIPE_VLADMIRS_OFFERING '= 145
  itmRECIPE_MEKANSM '= 146
  itmRECIPE_PIPE_OF_INSIGHT '= 147
  itmRECIPE_FORCE_STAFF '= 148
  itmRECIPE_NECRONOMICON_1 '= 149
  itmRECIPE_NECRONOMICON_2 '= 150
  itmRECIPE_NECRONOMICON_3 '= 151
  itmRECIPE_EULS_SCEPTER_OF_DIVINITY '= 153
  itmRECIPE_DAGON_1 '= 154
  itmRECIPE_DAGON_2 '= 155
  itmRECIPE_DAGON_3 '= 156
  itmRECIPE_DAGON_4 '= 157
  itmRECIPE_DAGON_5 '= 158
  itmRECIPE_VEIL_OF_DISCORD '= 159
  itmRECIPE_ORCHID_MALEVOLENCE '= 160
  itmRECIPE_REFRESHER_ORB '= 161
  itmRECIPE_CRYSTALYS '= 162
  itmRECIPE_ARMLET_OF_MORDIGGIAN '= 163
  itmRECIPE_SKULL_BASHER '= 164
  itmRECIPE_RADIANCE '= 165
  itmRECIPE_DAEDALUS '= 166
  itmRECIPE_BLACK_KING_BAR '= 167
  itmRECIPE_SHIVAS_GUARD '= 168
  itmRECIPE_MANTA_STYLE '= 169
  itmRECIPE_LINKENS_SPHERE '= 170
  itmRECIPE_ASSAULT_CUIRASS '= 171
  itmRECIPE_HEART_OF_TARRASQUE ' = 172
  itmRECIPE_MASK_OF_MADNESS '= 173
  itmRECIPE_SANGE '= 174
  itmRECIPE_YASHA '= 175
  itmRECIPE_MAELSTROM '= 176
  itmRECIPE_DIFFUSAL_BLADE_1
  itmRECIPE_DIFFUSAL_BLADE_2 '= 177
  itmRECIPE_DESOLATOR '= 178
  itmRECIPE_MJOLLNIR '= 179
  itmRECIPE_SATANIC '= 180

  itmAEGIS_OF_THE_IMMORTAL
  itmCHEESE


End Enum
Public Enum eItemCategory
  NONE
  CONSUMABLES '= 0
  ATTRIBUTES '= 1
  ARMAMENTS '= 2
  ARCANE '= 3
  COMMON '= 4
  SUPPORT '= 5
  CASTER '= 6
  WEAPONS '= 7
  ARMOR '= 8
  ARTIFACTS '= 9
  SECRET '= 10
  RECIPE
  SPECIAL
End Enum
Public Enum eShopTypes
  Fountain '= 0
  Side '= 1
  Secret '= 2
  Roshan
End Enum

Public Enum eSourceType
  None
  Build
  Hero
  HeroBuild
  Pet_Instance
  Pet_Stack
  Version
  BarGraph
  Game
  Team
  Hero_Instance '= 0
  Item_Info '= 1
  Ability_Info '= 2
  Modifier
  Stat
  Creep_Instance
  Creep_Stack
  Control
  GameEntity_Tuple
End Enum

Public Enum eModifierCategory
  None
  Active
  Passive
End Enum

Public Enum eModifierValueType
  None
  ValueList
  'AbilityValueList
  Value
  ValueWrapper
End Enum

Public Enum eBadgeAppearance
  Full
  Stats
  None
End Enum

Public Enum eModifierType
  None
  AbilityEffectiveHp '= 87 
  AbilitySteal 'Doom Devour 
  AdaptiveStrikeDamageMagicalInflicted 'Morphling Adaptive Strike. Used Agility to calc damage inflicted 
  AdaptiveStrikeStun 'Morphling Adaptive Strike. Calculated using current strength and agility 
  AgiAdded '= 15 
  AgioT '= 17 
  AgiPercent '= 16 
  AgiSubtracted ' Slark Essence Shift 
  ArcaneOrb '= 50 'OD 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  ArmorAdded
  ArmorAddedPerSec '= 9 
  ArmoroT '= 11 
  ArmorPercentage '= 10 
  ArmorStackSubtracted 'Bristlebakc Nasal Goo 
  ArmorSubtracted
  ArmorSubtractedoT 'Forged Spirit Melting Strike 
  ArmorxPoint06
  AstralSpiritDamageMagicalAdded 'Elder Titan, will have to determine how many units were hit for this to be accurate 
  AstralSpiritMoveSpeedPercentAdded 'Elder Titan, have to determine how many creeps hit 
  AstrlImpIntStolen 'OD Astral Imprisonment. Only steals int if target is enemy hero 
  AttackSpeedAdded '= 25 
  AttackSpeedAddedPerHeroPerMissHP 'Bloodseeker Thirst 
  AttackSpeedAddedtoXAttacks 'Ursa Overpower. Attack speed only added to a certain number of rightclick attacks 
  AttackSpeedMaxed 'Windranger Focus Fire 
  AttackSpeedoT '= 27 
  AttackSpeedPercentAdded '= 26 
  AttackSpeedPercentofTargetAdded 'Visage Grave Chill 
  AttackSpeedPercentSubtracted 'Medusa Stone Gaze 
  AttackSpeedStackAdded 'Lina Fiery Soul 
  AttackspeedSubtracted 'AA Chilling Touch 
  BackstabRightclickDamageAddedAsPercofAgi 'Riki Backstab. only occurs when attacking from rear 
  BallLightDamMagicalInflicted 'Storm Spirit Ball Lightning 
  BallLightPushForward 'SS Ball Lightning charge 
  Barrier 'earthsaker wall, tusk iceshards... 
  BaseAgi '= 89 
  BaseAttackRange
  AgiIncrementAdded 'Innate Agility increment
  BaseandBonusDamageReduction 'Windranger Focus Fire 
  BaseArmor
  'BaseArmorPositive
  'BaseArmorNegative
  'AgilityFactorForArmor '.14 http://dota2.gamepedia.com/Armor
  BaseArmorDebuff
  BaseArmorPercentSubtracted 'Elder Titan Natural Order 
  BaseAttackTime '= 24 
  BaseAttackTimeChangedTo ' Alchemist Chemical Rage 
  BaseAttackDamageHigh
  BaseAttackDamageLow
  BaseAttackDamageAvg 'for calc of physical damage
  'BaseEffectiveHP '= 1 
  'BaseHP '= 0 
  BaseInt '= 90 
  BaseMagicResistance '= 29 
  BaseMagicResistancePercentSubtracted 'Elder Titan Natural Order 
  BaseMana '= 5 
  BaseMovementSpeed
  BaseStr '= 88 
  BaseTurnRate
  Bash '= 35 'http://dota2.gamepedia.com/Bash 
  BearBonusDamage 'Lone Druid Synergy 
  BearMoveSpeedAdded 'Lone Druid Synergy 
  BerserkersBonusAttackSpeed 'Huskar Berserker's Blood. Oy 
  BerserkersBonusMagicResistance 'Huskar Berserker's Blood 
  BlindChance '= 57 'http://dota2.gamepedia.com/Blind 
  BlindDuration '= 58 
  BonusDamage
  BonusDamageoT
  BonusDamagePercent 'Lycan Feral Impulse 
  BonusGold
  BountyGold
  BuildingAttackSpeedPercentAdded 'Spirit Bear Demolish. If attacking a building then attspeed is applied 
  CausticFinale '= 45 'SandKing 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  ChainLightning '= 54 'Maelstrom, Mjolnir 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  'ChainLightningChance 'Maelstrom, Mjolnir 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  ChenAncientCount 'count of potential ancients that can be holy pursuasioned 
  ChenCreepFullHeal 'Chen Hand of God 
  CleavePercentage '= 36 'http://dota2.gamepedia.com/Cleave , http://dota2.gamepedia.com/Mechanics#Cleave_Damage 
  ColdAttack '= 53 'Skadi 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  ConjuredImage 'Terrorblade Conjure Image. Takes stats from TB's current stats 
  Consumption 'Doom Devour 
  ControlledCreepHealthBonus 'Chen Holy Pursuasion 
  Corruption '= 52 'Desolator 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  CreepControlled 'Chen Holy Pursuasion 
  CripplingFearMissChance 'NightStalker. Values change if day or night 
  CritChance '= 37 'http://dota2.gamepedia.com/Critical_strike 
  CritDamage 'Jinada 
  CritMultiplier '= 38 
  Cyclone '= 59 'http://dota2.gamepedia.com/Cyclone 
  DamageAbsorbedForMana 'Medusa Mana Shield .absorbs damage in exchange for mana 
  DamageAllTypesIncomingIncreasesPercent 'Slardar Sprint 
  DamageAllTypesPercentAdded 'Clinkz DeathPact 
  DamageAllTypesStackAdded 'Bristleback Warpath adds damage to spells and abilitys of all damage types 
  DamageAmplification '= 31 'http://dota2.gamepedia.com/Damage_amplification 
  DamageBlock
  DamageBlockRemoved 'SS Hex 
  DamageBothBlockAdded
  DamageChainMagicalInflicted 'WitchDoctor Paralyzing cask 
  DamageChainPhysicalInflicted 'Mjolnir 
  'DamageCompositeAdded 
  'DamageCompositePercent 
  DamageDelay 'Kunka Ghost Ship 
  'DamageHPRemovalPercentage 
  DamageIncreasePercent 'Chen Penitence 
  DamageInstanceBlock 'treant Living Armor 
  DamageLost 'due to LC Duel, Razor static link 
  DamageMagicalAbsorbed 'Ember Spirit Flameguard 
  DamageMagicalAdded 'for passaive abilities 
  DamageMagicalAddedToPhysicalAttacks ' AA Chilling Touch 
  DamageMagicalBouncesInflicted 'Lich ulti 
  DamageMagicalChain 'Invoker Cold Snap 
  DamageMagicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP 
  DamageMagicalImmunity 'OmniKnight Repel 
  DamageMagicalInflicted 'for active abilities 
  DamageMagicalInflictedOnSpellCast 'SS Overload 
  DamageMagicalInflictedPerAlly ' Tusk Snowball 
  DamageMagicalInflictedPerTarget 'SS Ether Shock, for abilities that hit x num of targets, each only once 
  DamageMagicalInflictedPerUnit 'Undying Soul Rip 
  DamageMagicalInflictedUntilSpellcast 'Silencer Curse of the Silent 
  DamageMagicalMinMaxInflicted 'value has a min and max value 
  DamageMagicaloTAsMultofStr 'Pudge Dismemeber 
  DamageMagicalOverTimeInflicted 'LeechSeed pulse 
  DamageMagicalPercent
  DamageMagicalPerCreep 'LC Overwhelming Odds 
  DamageMagicalPerHero 'LC Overwhelming Odds 
  DamageMagicalPerMissingHP 'Necro Reaper's Scythe 
  DamageMagicalPerMissingMana 'Anti Mage Mana Void 
  DamageMagicalPerSec ''axe battle hunger 
  DamageMagicalRandomInflicted 'uses maxval and minval in modvalue for range of random value 
  DamageMagicalTimesInt ' Skywrath Arcane Bolt 
  DamageMeleeAdded
  DamageMeleeBlockAdded '= 32 'http://dota2.gamepedia.com/Damage_Block 
  DamageMeleemultiplier
  DamageoTMagicalInflicted
  damagePerSecond 'Radiance burn 
  DamagePhysicalAdded 'passive abilites 
  DamagePhysicalBouncesInflicted 'Witch doc Death Ward 
  DamagePhysicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP 
  DamagePhysicalImmunity 'OmniKnight Guardian Angel 
  DamagePhysicalIncomingIncreasedPercent 'Medusa Stone Gaze 
  DamagePhysicalInflicted 'active abilities 
  DamagePhysicaloT
  DamagePhysicalPercent
  DamagePhysicalPerSec
  DamagePhysicalStackingInflicted 'Bristelback Quillspray 
  DamagePhysicalSubtracted 'Enfeeble 
  DamagePierceAdded
  DamagePierceChancePercent
  DamagePureAdded
  DamagePureAsPercentofManaPool 'OD Arcane Orb 
  DamagePureAsPercentofMaxHP 'Enigma Midnight pulse 
  DamagePureInflicted
  DamagePureoTasPercofMaxHP 'Phoenix Sun Ray 
  DamagePureoTInflicted 'Phoenix Sun Ray 
  DamagePurePercent
  DamagePureRandomInflicted 'Chen Test of Faith. uses maxval and minval in modvalue for range of random value 
  DamageRangeAdded
  DamageRangeBlockAdded '= 33 
  DamageRangemultiplier
  DamageReduction 'Tide Anchor smash 
  DamageReturnDuration 'Blademail 
  DamagetoHealPercent 'abadon ulti 
  DamageTransferedToCaster 'abaddon borrowed time 
  DarknessNight 'NightStalker. Artificial night induced. max vis for all enemies 675 
  DeathlustAttackSpeedAdded 'Undying Zombie Deathlust. Attspead added when target is below threshold 
  DeathlustMoveSpeedPercentAdded 'Undying Zombie movement speed added when target below threshold 
  DestroysCreep 'Lich Sacrifice 
  DestroysHero 'Techies Suicide 
  DestroysHeroBelowThreshold 'Axe Culling Blade 
  DestroysTree 'Quellingblade 
  Disarm
  DisarmMelee '= 69 'http://dota2.gamepedia.com/Disarm 
  DisarmRange ' Heaven's Halberd 
  DisjointRange '= 70 'http://dota2.gamepedia.com/Disjoint 
  Dispel '= 71 'http://dota2.gamepedia.com/Dispel 
  DisruptionIllusion 'ShadowDemon Illusion 
  Dominate 'Helm of the dominator 
  DuelBonusDamage 'lc duel, seperate item so we can do a buff icon for it 
  ElderDragonForm 'Dragon Knight 
  Ensnare '= 67 'http://dota2.gamepedia.com/Ensnare 
  Entangle '= 68 'http://dota2.gamepedia.com/Entangle 
  EssenceAuraManaRestored 'instances of this determined by amount of enemies in range? 
  Ethereal_Time '= 77 'http://dota2.gamepedia.com/Ethereal 
  EvasionPercent
  EvasionRemoved ' SS Hex removes all evasion 
  EvilSpirits 'special modtype since spirit count is affected by witchcraft, so has to be calced from inside the mod itself 
  ExortDamageMagicalInflicted 'Invoker Deafening Blast 
  ExortDamageMagicalInflictedoT 'Invoker Chaos Meteor 
  ExortRightClickBonusDamageAdded 'Invoker Alacrity 
  FadeBoltDamageMagicalBounces 'Rubick, Fade Bolt. bounces diminish the damage, thus the unique modifier. also has no bounce limit but cant hit same target twice 
  Feedback '= 55 'Diffusal Blade 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  FrostArrows '= 48 'Drow 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  Ghost_Form_Time 'Ghost scepter, ethereal blade 
  GlaivesWisdom '= 51 'Silencer 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  GreaterBashofCurrentLevel 'Spirit Breaker Nether Strike 
  Haunt 'Spectre haunt. Takes attributes of Spectre at time of cast 
  HealAdded
  HealAddedAsPercOfTargetCurrHP 'Lifestealer Feast 
  HealAddedoT 'Treant Leach Seed 
  HealAddedoTAsPercofMaxHP 'Phoenix Sun Ray 
  HealAddedPerDeadCreep 'Undying Flesh Golem 
  HealAddedPerDeadHero 'Undying Flesh Golem 
  HealAddedPerUnit 'Undying Soul Rip 
  HealAsPercentofHP
  HealFriendlyorDamageEnemy
  HealFriendlyorMagicDamEnemyoT 'Warlock Shadow Word 
  HealMinMaxAdded 'Value has a min and max range 
  HealoTSetTo 'Backdoor Protection 
  HealPercent
  HealPercentSubtracted
  HealthFullyRestored 'Phoenix Supernova 
  HealthPercentAdded 'Ancient Granite Golem Granite Aura. Increases the health capacity of nearby units. 
  HealthRegenAdded 'Alchemist Chemical Rage 
  HealthvalueFrozen 'AA Ice Blast 
  HeroDamageReducedTo 'Backdoor Protection 
  HeroReflection 'Terrorblade Reflection. Takes stats from targetted hero 
  Hex '= 62 'http://dota2.gamepedia.com/Hex 
  HPAdded '= 2 ' amount (pos or neg representing heal of damage) Damage type (puredamagesingletarget, magicdamageAOE, etc) 
  HPoT '= 4 'amount as total amount, damagetype(for negative numbers, otherwise none) 
  ' HPFromStrength
  HPPercent '= 3 ' amount as decimal 
  HPRegenAdded
  HPRegenSubtracted
  HPRegenPercent
  HPRegenPercentofCasters 'io Tether 
  HPRegenPerUnitKilledAdded 'necro sadist 
  HPRemoval
  HPRemovalAsPercentofMoveDist 'Bloodseeker Rupture 
  HPRemovalSharedWithBoundUnits 'Warlock Fatal Bonds 
  HPSubtracted
  'http://dota2.gamepedia.com/Unique_Attack_Modifier 
  IllusionDamageReducedTo 'Backdoor protection 
  Impetus '= 43 'Enchantress 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  ImpetusDamagePureInflicted 'Enchantress Impetus. damage as function of distance 
  IncapBite '= 47 'Broodmother 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  InfestCreepHeal 'Lifestealer Infest. If infest in creep then creep hp as heal on consume 
  InnerVitalityPercentHealAdded 'Huskar Inner Vitality. Will have to check target's health to see which healpercentage to use 
  'IntAsMana
  IntAdded '= 18
  IntIncrementAdded 'Inherent Statin increment gain
  IntoT '= 20 
  IntPercent '= 19 
  IntSubtracted 'slark Essence Shift 
  Invisibility '= 72 'http://dota2.gamepedia.com/Invisibility 
  InvisibilityWhenNotAttacking 'Lycan wolces
  InvokeASpell 'Invoker Invoke 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  InvokeSpellCount 'Invoker Invoke MaxSpells 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  Invulnerability '= 73 'http://dota2.gamepedia.com/Invulnerability 
  ItemEffectiveHP '= 86 
  KillsPerGoldIncrement
  Knockback 'batrider firefly and many others 
  KotLSpiritForm 'Kotl 
  LastHitGoldAdded 'Alchemist Greevil's Greed 
  LastHitGoldBonusPerStack 'Alchemist Greevil's Greed 
  Leap 'slark spiritbreaker 
  LifeDrainDrainfromTarget 'Pugna Life Drain. Different effects depending if target is friend or foe 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  LifeDrainPercent 'DP Exorcism 
  LifeDrainSelfEffect 'Pugna Life Drain. Different effect to pugna depending on whether targeting friend or foe 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  LifeStealAdded '= 56 'Helm of the Dominator, mask of madness, satanic 'http://dota2.gamepedia.com/Lifesteal 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  LifestealAddedtoAllAttackers 'Lifestealer Open Wounds. Allied Heroes get healtch when attacking enemy unit with this debuff 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  LifeStealPercent 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  LiquidFire '= 44 'Jakiro 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  LostHealthDamagePercent 'Witch Doc Maledict 
  LucentBeamHits 'Luna Eclipse 
  LvlDeathDamageMagicalInflicted 'Doom Lvl? Death. has to be calced at time using attacked hero level and abdoom_lvl_death.herolevelmultiplier 
  MagicDamageReceivedMultiplier ' ghost scepter 
  MagicImmunity '= 30 'http://dota2.gamepedia.com/Magic_immunity 
  MagicResistanceAdded
  MagicResistanceCapped 'Lifestealer Rage. Gives 100% Magic Resistance 
  MagicResistancePercentAdded
  MagicResistancePercentSubtracted 'Pugna Decrepify 
  MagicResistanceSet 'Medusa Stone Gaze. Set Magic Resistance at a value 
  MagicResistanceSubtracted 'AA Ice Vortex 
  MagnatizeDamageOverTime 'will have to make concession for num enemyheroes and numboulders 
  MaimChance 'sange 
  ManaAdded '= 6 
  ManaSubtracted
  ManaBreak '= 41 'Anti-Mage 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  ManaBurnDamage 'Nyx Mana Burn. uses target's intelligence to calc damage 
  ManaBurnManaremoved 'Nyx Mana Burn. Uses target's intelligence to calc mana removed. 
  ManaDrained ' antimage manaburn, it damage to mana inflicted. 
  ManaDrainedUntilSpellcast 'Silencer Curse of the Silent. Darinas mana until duration end or target casts spell 
  ManaoT '= 8 
  ManaoTSubtracted
  ManaPercent '= 7 
  ManaPercentDrained 'Bane Fiend's Grip, percent is based off of targets max mana 
  ManaRegenAdded
  ManaRegenSubtracted
  ManaRegenPercent
  ManaRegenPercentofCasters 'IO tether 
  ManaRegenPerUnitKillAdded 'Necro Sadist 
  ManaRemoved 'Invoker EMP 
  ManaRemovedoT 'Morphling Morph 
  ManaRemovedPercentoT 'KotL Mana Leak 
  ManaRestored
  MaxManaAdded
  ManaRestoredAsPercentOfHP 'Lich Sacrifice 
  ManaRestoredPercent
  MantaMeleeIllusionDamagePercentage 'Manta style 
  MantaRangeIllusionDamagePercentage
  MeepoClone 'Meepo Divided We Stand 
  MeleeSlow 'orb of venom 
  MeleeStun ' Abyssal Blade 
  MeltingStrike '= 49 'Invoker's forged Spirit 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  MidnightPulsePureDamageAdded 'Black hole scepter upgrade adds midnight pulse damage at current level 
  'Minibash_Chance 
  Minibash_Damage
  MiniMapInvisibility 'Phantom Ass, Blur 
  MiniStun
  MirrorImage 'Naga Siren Mirror Image. Takes props from hero's stats at time 
  MissChance 'Broodmother incapacitating Bite 
  MissileSpeed
  MoveSpeedAdded '= 21 ''http://dota2.gamepedia.com/Slow 
  MoveSpeedMinimum 'for haste, sets minimum movespeed at time for unit, used for Centaur stampede, etc 
  MoveSpeedoT '= 23 
  MoveSpeedPercent
  MoveSpeedPercentAdded 'Slardar Sprint 
  MoveSpeedPercentAddedPerHeroPerMissHP 'Bloodseeker Thirst 
  rightclickdamageaddedperherobelow75perchealth 'Bloodseeker Thirst
  MoveSpeedPercentAsDamage 'Spiritbreaker greater bash 
  MoveSpeedPercentofTargetAdded 'Visage Grave Chill 
  MoveSpeedPercentStackSubtracted 'Bristleback Nasal Goo 
  MoveSpeedPercentSubtracted 'Bristleback Nasal Goo 
  MoveSpeedSet 'Lycan Shapeshift 
  MoveSpeedStackAdded 'Lina Fiery Soul 
  MoveSpeedSubtracted 'boar moveslow 
  MulticastBloodlustCoolReduction
  MulticastBloodlustRadiusAdded
  MulticastFireblastCoolReduction
  MulticastFireblastManaAdded
  MulticastFourXChance
  MulticastIgniteCastRangeAdded
  MulticastIgniteRadius
  MulticastThreeXChance
  MulticastTwoXChance
  'Multiple sources of damage block don't stack 
  MuteAbilities '= 79 'unable to cast abilities 
  MuteAllOnTarget 'stops eveything on target (items, move, abilities, etc.) Bane Nightmare 
  MuteAttacks 'Flaming Lasso Batrider 
  MuteBlink '= 81 'unable to blink 
  MuteInvisibility 'treant overgrowth 
  MuteItems '= 80 'unable to cast items 
  MuteMove '= 82 'unable to move 
  MuteRightClick '= 84 'unable to rightclick 
  MuteTargetability '= 85 'unable to be targetted 
  MuteTeleport 'Blink (Queen of Pain) , Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger. 
  MuteTurn '= 83 'unable to turn 
  MysticSnakeDamageAdded 'Medusa Mystic Snake. ability bounces between enemies, inflicting more damage the more it jumps 
  MysticSnakeManaAdded 'Medusa Mystic Snake. ability bounces between enemies, grabbing more mana the more it jumps 
  MysticSnakeManaSubtracted 'enemy units hit by mystic snake lose mana 
  BaseGold
  NightAttackSpeedAdded 'Nightstalker Hunter in the Night 
  NightAttackSpeedSubtracted 'Nightstalker Void. Duration differs for day and night 
  NightMoveSpeedAdded 'NightStalker Hunter in the Night 
  Number1
  NumberPoint06
  OpenWoundsSlowInflicted 'Lifestealer Open Wounds. Will have to call list for slow values for each interval 
  PackleaderRClickDamageAsPercofBaseDamandPrimaryStat 'Alpha Wolf Packleader's Aura 
  PauseTime '= 63 'http://dota2.gamepedia.com/Pause 
  PercentofCreepHealthGained 'Clinks DeathPact 
  PeriodicGold
  petAlpha_Wolf
  petAncient_Black_Dragon
  petAncient_Black_Drake
  petAncient_Granite_Golem
  petAncient_Rock_Golem
  petAncient_Rumblehide
  petAncient_Thunderhide
  petBoar
  petCentaur_Conqueror
  petCentaur_Courser
  petDark_Troll_Summoner
  petDeath_Ward
  petEarth_Brewmaster
  petEidolon
  petFamiliar
  petFell_Spirit
  petFire_Brewmaster
  petForged_Spirit
  petFrozen_Sigil
  petGhost
  petGiant_Wolf
  petGolem_Warlock
  petHarpy_Scout
  petHarpy_Stormcrafter
  petHawk
  petHealing_Ward
  petHellbear
  petHellbear_Smasher
  petHill_Trll
  petHill_Troll_Berserker
  petHill_Troll_Priest
  petHoming_Missile
  petKobold
  petKobold_Foreman
  petKobold_Soldier
  petLand_Mine
  petLycan_Wolf
  petMega_Melee_Creep
  petMega_Ranged_Creep
  petMelee_Creep
  petMud_Golem
  petNecro_Archer
  petNecro_Warrior
  petNether_Ward
  petObserver_Ward
  petOgre_Bruiser
  petOgre_Frostmage
  petPhantomLancer
  petPhoenix_Sun
  petPlague_Ward
  petPower_Cog
  petPsionic_Trap
  petRanged_Creep
  petRemote_Mine
  petSatyr_Banisher
  petSatyr_Mindstealer
  petSatyr_Tormentor
  petSentry_Ward
  petSerpent_Ward
  petSiege_Creep
  petSiege_Creep_Bonus
  petSkeleton_Warrior
  petSpiderite
  petSpiderling
  petSpirit
  petSpirit_Bear
  petStasis_Trap
  petStorm_Brewmaster
  petSuper_Melee_Creep
  petSuper_Ranged_Creep
  petTombstone
  petTornado
  petTreant
  petUndying_Zombie
  petVhoul_Assassin
  petWildwing
  petWildwing_Ripper
  Phantasms 'Chaoes night ulti, receiver will have to get current chaos knight build to calc phant stats 
  PhantomStrikeAttSpeedAdded 'Phantom Ass, Phantom Strike. If target is enemy hero the att speed added for mCharge count of rightclick attacks 
  Phase_Form 'phase boots 
  PoisonAttack '= 46 'Viper, Orb of Venom 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  PrimaryStatDamage
  PrimaryStatDamageAdded 'Ethereal Blade 
  PrimaryStatLossPercent 'timeber whirling death 
  Pullback ' x marks, pudgehook 
  PullForward
  Purge '= 74 'http://dota2.gamepedia.com/Purge 
  PurgeFrequency '= 75 
  PushForward 'force staff 
  PushSideways 'Beastmaster Primal Roar 
  QuasCyclone 'Invoker Tornado 
  QuasKnockback 'Invoker Deafening Blas. Duration as distance determined byQuas level 
  QuasMoveSpeedPercentChange 'Invoker Ghost Walk 
  QuillSprayCast 'Bristleback Bristleback ability 
  RabidAttackSpeedAdded 'Lone Druid Rabid. Has to apply to both druid and bear 
  RabidDurationBonus 'Lone Druid 
  RabidMoveSpeedAdded 'Lone Druid Rabid. Needs to add to both druid and bear 
  RandomTargetHealAdded 'Enchantress nature's attendants 
  RangeSlow
  RangeStun 'Abyssal blade 
  ReflectedDamageInflicted 'Nyx Spiked Carapace. damage component of spell. inlficted on attacker 
  Reincarnate 'Aegis 
  RemoveBuffs 'Diffusal Blade 
  RemoveDebuffs ' abaddon ulti 
  RemoveDisables 'LC Press the attack 
  ReplacedByPets 'Brew Primal Split 
  Replicant 'Morphling Replicate. Need to know which hero is targeted at the time 
  RequiemDamageMagicalInflicted 'Shadow Fiend Reqiem of Souls. Damage is per line. Line count is 1 for each 2 soulds in Necromastery 
  Reset_Cooldowns 'Refresher 
  ResourceShare
  RightClickAttackAttackSlowInflicted 'Right click attack also adds an attack speed debuff to target 
  RightClickAttackDamage 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
  RightClickBonusDamageAdded 'TB Metamorphosis 
  RightClickBonusDamageInflicted 'Faceless Void Time Lock 
  RightClickBonusPureDamageInflicted 'Spectre Desolate 
  RightClickBurnedMana 'Necro Warrior Mana Break 
  RightClickCausticFinale 'Sand King Caustic Finale added 
  RightClickCounterAttack 'Axw counter helix, LC MomentofCOurage 
  RightClickDamageAdded 'LC Duel 
  RightClickDamageAsLine 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
  RightClickDamageAsPercOfTargetCurrHP 'lifestealer Feast 
  RightClickDamageFromPrimaryAtt
  RightClickDamageInflicted 'Windranger Focus Fire 
  RightClickDamageInstanceAvoided 'Faceless BackTrack 
  RightClickDamageMultipleInflicted 'Phantom Ass, Coup de Grace 
  RightClickDamageMultiplier 'weaver germinate 
  'RightClickDamageMultiplier 'weaver germinate 
  RightClickDamageoT 'Right Click attack also puts a DoT on target 
  RightClickDamagePercentageInflicted
  RightClickDamagePercentInflicted 'Phantom Lancer Spirit Lance Illusion damage 
  RightClickDamagePercentSubtracted 'SF Requiem of Souls 
  RightClickDamageWithBuffs 'gyro flak cannon 
  RightClickDamageWithoutBuffs 'gyro flak cannon 
  RightClickDamPhysStackingInflicted 'Ursa furry swipes 
  RightClickHealthasDamagePercInflicted 'Ursa Enrage 
  RightClickInttoPureDamage 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage 
  RightClickMoonGlaiveBounces 'Luna moon glaive 
  RightClickMoveSpeedPercSubtracted 'Meepo Geostrike 
  RightClickNetherToxinDamage 'Viper Nethertoxin does damage for each 20% of health missing in target 
  RightClickPureDamageInflicted 'Warlock Golem Flaming Fists 
  RightClickStun 'Faceless TimeLock 
  RoshanArmorAddedPer4Min 'Strength of the Immortal 
  RoshanHealthPer4MinAdded 'Strength of the Immortal 
  RoshanRClickAttackDamPer4MinAdded 'Strength of the Immortal 
  RoshanSlamDamageTimeIncrease 'Roshan Slam increases in damage every 4 minutes 
  SanitysDamageMagicalInflictedAsMultofIntDiff 'OD Sanity's Eclipse. Damage is a multiple of the difference between OD's int and affected enemy's int. if difference is negative, then no effect 
  SanitysManaPercentRemovedwithThreshold 'OD Sanity's Eclipse. If the diff of int between OD and affected enemy is less than threshold then mana removed 
  SearingArrows '= 42 'Clinkz 'http://dota2.gamepedia.com/Unique_Attack_Modifier
  SelfDeny 'Bloodstone Pocket Suicide 
  ShackleTime '= 61 'http://dota2.gamepedia.com/Disable like lasso 
  ShadowPoisonStackDamage 'Shadow Demon Shadow Poison, Each staup up to 5 increases damage, after that it's 50 each addl stack 
  ShallowGrave 'Dazzle 
  Shatter 'AA IceBlast 
  Silence '= 76 'http://dota2.gamepedia.com/Silence 
  Sleep '= 66 'http://dota2.gamepedia.com/Sleep 
  SpawnSpiderite 'Spiderling Spawn Spiderite 
  SpellBlock ' Linken's blocks n spells 
  SpellBlockDuration ' Blocks all spells for n seconds 
  StaticFieldHealthReduction 'Zeus Static Field 
  StaticLinkBonusDamage 'Razer 
  StaticStormDamageMagicalInflicted 'Disruptor Static Storm. Will have to call list for pulse values and calc with or without aghs 
  StationaryInvisibility 'TA Meld. Invis until TA moves 
  StealthVisibility 'dust of appearance, sentry wards 
  StrAdded '= 12 
  StrIncrementAdded 'Hero's innate strength increase perlevel
  StrAddedPerKill 'pudge FleshHeap 
  StrengthPercentageAsAllDamage 'Centaur stampede 
  StrengthPercentageCounterAttack 'Centaur Warrunner Return 
  StroT '= 14 
  ' StrPercent '= 13 
  StrSubtracted 'Slark Essence Shift 
  Stun '= 60 'http://dota2.gamepedia.com/Stun 'Does NOT include MiniStuns 
  StunChain 'Witch doc Paralyzing Cask 
  'StunChance 'Skull Basher 
  StunRandom 'ChaosKnight Chaos Bolt 
  Sunder 'TB Sunder. Swaps health with target 
  SunStrikePureInflicted 'Invoker SunStrike. Damage is divided among enemy targets 
  TargetedDamageReflected 'nyx Spiked Carapace. Only reflects damage targetted directly at nyx 
  TargetsCurrentHealthAsDamageMagicalInfliced 'Huskar Life Break Damage Dealt 
  Taunt '= 65 'http://dota2.gamepedia.com/Taunt 
  Teleport '= 78 
  TeleportRandom 'Chaosknight Reality Rift 
  TimeLapse 'weaver ulti 
  TinyTossBonusDamage 'Tiny Grow 
  TinyTossDamageInflicted 'seperate type to enable check for TinyTossBonusDamage 
  Traptime '= 64 'http://dota2.gamepedia.com/Trap clockwork cogs 
  TrueFormHPAdded 'Lone Druid 
  Truesight '= 39 'http://dota2.gamepedia.com/Invisibility 
  TruesightofTarget 'bounty hunter track 
  TruesightRadius '= 40 
  TurnRateSubtracted 'Batrider Sticky Napalm 
  UnobstructedMovementandVision 'batrider firefly 
  UnobstructedVision 'Nightstalker Darkness 
  VanguardMeleeBlockAdded 'block dependant on whether you are melee or ranged 
  VanguardRangeblockAdded 'Vanguard: 
  Vision 'observerward 
  VisionDay 'beast hawk 
  VisionNight 'beast hawk 
  VisionNightAdded 'Lycan Shapeshift 
  VoidMoveSpeedPercentSubtracted 'Nightstalker void. Duration changes depending on day or night 
  WallHeroReplica 'Dark Seer Wall of Replica 
  Web 'Broodmother Spin Web 
  WexAttackSpeedAdded 'Invoker Alacitry 
  WexDamageMagicalInflicted 'Invoker Tornado 
  WexDamagePureInflicted ' 
  WexDisarm 'Invoker Deafening Blast. Duration determined by wex level 
  WexManaRestored 'Invoker EMP. Restores have of mana burn from heroes ONLY 
  WexMoveSpeedPercentChangeSubtracted 'Invoker Ghost Walk 
  WexMoveSpeedPercentChangeAdded '
  WexVision 'Invoker Tornado 
  WitchcraftCooldownDecrease
  WitchcraftManaCostDecrease 'DP Witchcraft 
  WitchcraftSpiritIncrease
  WrathofNatureMagicDamageBounceInflicted 'Nature's Proph damage increases with each bounce 
  XPAdded 'Lich Sacrifice 
  BaseXP
  ZombiesPerUnit 'Undying Tombstone Zombies 

  'NetWorth

  ''Heropets
  'petHawk
  'petBoar
  'petLycan_Wolf
  'petUndying_Zombie
  'petSpiderling
  'petSpiderite
  'petTreant
  'petEidolon
  'petForged_Spirit
  'petSkeleton_Warrior
  'petNecro_Warrior
  'petNecro_Archer
  'petEarth_Brewmaster
  'petStorm_Brewmaster
  'petFire_Brewmaster
  'petGolem_Warlock
  'petSpirit_Bear
  'petFamiliar
  'petPlague_Ward
  'petSerpent_Ward
  'petDeath_Ward
  'petHealing_Ward
  'petFrozen_Sigil
  'petTornado
  'petPsionic_Trap
  'petLand_Mine
  'petStasis_Trap
  'petRemote_Mine
  'petNether_Ward
  'petPower_Cog
  'petTombstone
  'petPhoenix_Sun
  'petObserver_Ward
  'petSentry_Ward
  'petMelee_Creep
  'petSuper_Melee_Creep
  'petMega_Melee_Creep
  'petRanged_Creep
  'petSuper_Ranged_Creep
  'petMega_Ranged_Creep
  'petSiege_Creep
  'petSiege_Creep_Bonus
  'petSpirit
  'petKobold
  'petKobold_Soldier
  'petKobold_Foreman
  'petHill_Troll_Berserker
  'petHill_Troll_Priest
  'petVhoul_Assassin
  'petFell_Spirit
  'petGhost
  'petHarpy_Scout
  'petHarpy_Stormcrafter
  'petCentaur_Conqueror
  'petCentaur_Courser
  'petGiant_Wolf
  'petAlpha_Wolf
  'petSatyr_Banisher
  'petSatyr_Mindstealer
  'petOgre_Bruiser
  'petOgre_Frostmage
  'petMud_Golem
  'petSatyr_Tormentor
  'petHellbear
  'petHellbear_Smasher
  'petWildwing
  'petWildwing_Ripper
  'petDark_Troll_Summoner
  'petHill_Trll
  'petAncient_Black_Dragon
  'petAncient_Black_Drake
  'petAncient_Granite_Golem
  'petAncient_Rock_Golem
  'petAncient_Thunderhide
  'petAncient_Rumblehide
  'petHoming_Missile
  'petPhantomLancer

  '' WildwindTornadoPet 'Wildwing Ripper Tornado
  'Haunt 'Spectre haunt. Takes attributes of Spectre at time of cast
  'HeroReflection 'Terrorblade Reflection. Takes stats from targetted hero
  'WallHeroReplica 'Dark Seer Wall of Replica
  'ConjuredImage 'Terrorblade Conjure Image. Takes stats from TB's current stats
  'DisruptionIllusion 'ShadowDemon Illusion
  'ElderDragonForm 'Dragon Knight
  'ZombiesPerUnit 'Undying Tombstone Zombies
  'EvilSpirits 'special modtype since spirit count is affected by witchcraft, so has to be calced from inside the mod itself
  'ReplacedByPets 'Brew Primal Split
  'SpawnSpiderite 'Spiderling Spawn Spiderite

  ''Notes: timebased types, 0 means on forever
  'BaseHP '= 0
  'BaseEffectiveHP '= 1
  'ItemEffectiveHP '= 86
  'AbilityEffectiveHp '= 87

  'Barrier 'earthsaker wall, tusk iceshards...

  'MissChance 'Broodmother incapacitating Bite
  'CripplingFearMissChance 'NightStalker. Values change if day or night

  'HPAdded '= 2 ' amount (pos or neg representing heal of damage) Damage type (puredamagesingletarget, magicdamageAOE, etc)
  'HPSubtracted
  'TrueFormHPAdded 'Lone Druid 
  'HPPercent '= 3 ' amount as decimal
  'HPoT '= 4 'amount as total amount, damagetype(for negative numbers, otherwise none)

  'HPRegenAdded
  'HPRegenPerUnitKilledAdded 'necro sadist
  'HPRegenPercentofCasters 'io Tether
  'HPRegenPercent

  'HealAdded
  'HealAddedoT 'Treant Leach Seed
  'HealAddedPerUnit 'Undying Soul Rip
  'HealAddedPerDeadHero 'Undying Flesh Golem
  'HealAddedPerDeadCreep 'Undying Flesh Golem
  'InfestCreepHeal 'Lifestealer Infest. If infest in creep then creep hp as heal on consume
  'HealAddedAsPercOfTargetCurrHP 'Lifestealer Feast
  'HealAddedoTAsPercofMaxHP 'Phoenix Sun Ray
  'HealMinMaxAdded 'Value has a min and max range
  'RandomTargetHealAdded 'Enchantress nature's attendants
  'InnerVitalityPercentHealAdded 'Huskar Inner Vitality. Will have to check target's health to see which healpercentage to use
  'HealthRegenAdded 'Alchemist Chemical Rage
  'HealthPercentAdded 'Ancient Granite Golem Granite Aura. Increases the health capacity of nearby units.
  'RoshanHealthPer4MinAdded 'Strength of the Immortal
  'StaticFieldHealthReduction 'Zeus Static Field
  'HealthvalueFrozen 'AA Ice Blast
  'HealthFullyRestored 'Phoenix Supernova
  'HealPercent
  'HealAsPercentofHP
  'HealFriendlyorDamageEnemy
  'HealFriendlyorMagicDamEnemyoT 'Warlock Shadow Word


  'ManaRegenAdded
  'ManaRegenPerUnitKillAdded 'Necro Sadist
  'ManaRegenPercent
  'ManaRegenPercentofCasters 'IO tether

  'BaseMana '= 5
  'ManaAdded '= 6
  'ManaDrained ' antimage manaburn, it damage to mana inflicted.
  'ManaDrainedUntilSpellcast 'Silencer Curse of the Silent. Darinas mana until duration end or target casts spell
  'ManaPercentDrained 'Bane Fiend's Grip, percent is based off of targets max mana
  'ManaPercent '= 7
  'ManaoT '= 8

  'ManaBurnDamage 'Nyx Mana Burn. uses target's intelligence to calc damage
  'ManaBurnManaremoved 'Nyx Mana Burn. Uses target's intelligence to calc mana removed.
  'MysticSnakeManaAdded 'Medusa Mystic Snake. ability bounces between enemies, grabbing more mana the more it jumps
  'MysticSnakeManaSubtracted 'enemy units hit by mystic snake lose mana
  'MysticSnakeDamageAdded 'Medusa Mystic Snake. ability bounces between enemies, inflicting more damage the more it jumps
  'ManaRestored
  'WexManaRestored 'Invoker EMP. Restores have of mana burn from heroes ONLY
  'ManaRestoredAsPercentOfHP 'Lich Sacrifice
  'EssenceAuraManaRestored 'instances of this determined by amount of enemies in range?
  'ManaRestoredPercent
  'ManaRemovedPercentoT 'KotL Mana Leak
  'ManaRemovedoT 'Morphling Morph
  'ManaRemoved 'Invoker EMP

  'SanitysManaPercentRemovedwithThreshold 'OD Sanity's Eclipse. If the diff of int between OD and affected enemy is less than threshold then mana removed

  'WitchcraftManaCostDecrease 'DP Witchcraft
  'WitchcraftCooldownDecrease
  'WitchcraftSpiritIncrease

  'Web 'Broodmother Spin Web

  ''armor only affects physical damage mitigation
  'ArmorAdded
  'RoshanArmorAddedPer4Min 'Strength of the Immortal
  'ArmorSubtracted
  'ArmorSubtractedoT 'Forged Spirit Melting Strike
  'BaseArmorPercentSubtracted 'Elder Titan Natural Order
  'ArmorStackSubtracted 'Bristlebakc Nasal Goo
  'ArmorAddedPerSec '= 9
  'ArmorPercentage '= 10
  'ArmoroT '= 11

  'EvasionPercent
  'EvasionRemoved ' SS Hex removes all evasion

  'BaseStr '= 88
  'StrAdded '= 12
  'StrSubtracted 'Slark Essence Shift
  'StrAddedPerKill 'pudge FleshHeap
  'StrPercent '= 13
  'StroT '= 14

  'Sunder 'TB Sunder. Swaps health with target

  'BaseAgi '= 89
  'AgiAdded '= 15
  'AgiSubtracted ' Slark Essence Shift
  'AgiPercent '= 16
  'AgioT '= 17

  'BaseInt '= 90
  'IntAdded '= 18
  'IntSubtracted 'slark Essence Shift
  'AstrlImpIntStolen 'OD Astral Imprisonment. Only steals int if target is enemy hero
  'IntPercent '= 19
  'IntoT '= 20

  'MoveSpeedAdded '= 21 ''http://dota2.gamepedia.com/Slow
  'DeathlustMoveSpeedPercentAdded  'Undying Zombie movement speed added when target below threshold
  'NightMoveSpeedAdded 'NightStalker Hunter in the Night
  'BearMoveSpeedAdded 'Lone Druid Synergy
  'MoveSpeedSet 'Lycan Shapeshift
  'RabidMoveSpeedAdded 'Lone Druid Rabid. Needs to add to both druid and bear
  'MoveSpeedStackAdded 'Lina Fiery Soul
  'AstralSpiritMoveSpeedPercentAdded 'Elder Titan, have to determine how many creeps hit
  'MoveSpeedMinimum 'for haste, sets minimum movespeed at time for unit, used for Centaur stampede, etc
  'MoveSpeedSubtracted 'boar moveslow
  'MoveSpeedPercent
  'MoveSpeedPercentAdded 'Slardar Sprint
  'QuasMoveSpeedPercentChange 'Invoker Ghost Walk
  'WexMoveSpeedPercentChange 'Invoker Ghost Walk
  'MoveSpeedPercentAddedPerHeroPerMissHP 'Bloodseeker Thirst
  'MoveSpeedPercentofTargetAdded 'Visage Grave Chill
  'MoveSpeedPercentSubtracted 'Bristleback Nasal Goo
  'VoidMoveSpeedPercentSubtracted 'Nightstalker void. Duration changes depending on day or night
  'MoveSpeedPercentStackSubtracted 'Bristleback Nasal Goo
  'MoveSpeedPercentAsDamage 'Spiritbreaker greater bash
  'MoveSpeedoT '= 23
  'UnobstructedMovementandVision 'batrider firefly
  'UnobstructedVision 'Nightstalker Darkness

  'TurnRateAdded 'Batrider Sticky Napalm

  'XPAdded 'Lich Sacrifice

  'BaseAttackSpeed '= 24
  'BaseAttackTime ' Alchemist Chemical Rage
  'BerserkersBonusAttackSpeed 'Huskar Berserker's Blood. Oy
  'AttackSpeedAdded '= 25
  'DeathlustAttackSpeedAdded 'Undying Zombie Deathlust. Attspead added when target is below threshold
  'WexAttackSpeedAdded 'Invoker Alacitry
  'AttackSpeedMaxed 'Windranger Focus Fire
  'AttackSpeedAddedtoXAttacks 'Ursa Overpower. Attack speed only added to a certain number of rightclick attacks
  'PhantomStrikeAttSpeedAdded 'Phantom Ass, Phantom Strike. If target is enemy hero the att speed added for mCharge count of rightclick attacks
  'NightAttackSpeedAdded 'Nightstalker Hunter in the Night
  'RabidAttackSpeedAdded 'Lone Druid Rabid. Has to apply to both druid and bear
  'RabidDurationBonus 'Lone Druid
  'AttackSpeedStackAdded 'Lina Fiery Soul
  'AttackSpeedAddedPerHeroPerMissHP 'Bloodseeker Thirst
  'AttackspeedSubtracted 'AA Chilling Touch
  'NightAttackSpeedSubtracted 'Nightstalker Void. Duration differs for day and night
  'AttackSpeedPercentAdded '= 26
  'BuildingAttackSpeedPercentAdded 'Spirit Bear Demolish. If attacking a building then attspeed is applied
  'AttackSpeedPercentofTargetAdded 'Visage Grave Chill
  'AttackSpeedPercentSubtracted 'Medusa Stone Gaze
  'AttackSpeedoT '= 27

  'Leap 'slark spiritbreaker
  ''LeapRadius '= 28

  'LucentBeamHits 'Luna Eclipse

  'BaseMagicResistance '= 29
  'BaseMagicResistancePercentSubtracted 'Elder Titan Natural Order
  'BerserkersBonusMagicResistance 'Huskar Berserker's Blood
  'MagicResistanceAdded
  'MagicResistanceCapped 'Lifestealer Rage. Gives 100% Magic Resistance
  'MagicResistanceSubtracted 'AA Ice Vortex
  'MagicResistancePercentAdded
  'MagicResistancePercentSubtracted 'Pugna Decrepify
  'MagicResistanceSet 'Medusa Stone Gaze. Set Magic Resistance at a value

  'MagicImmunity '= 30 'http://dota2.gamepedia.com/Magic_immunity

  'DamageAmplification '= 31 'http://dota2.gamepedia.com/Damage_amplification
  'RightClickDamageMultiplier 'weaver germinate
  'RightClickDamageMultipleInflicted 'Phantom Ass, Coup de Grace
  'DamageDelay 'Kunka Ghost Ship
  'damagePerSecond 'Radiance burn
  ''Multiple sources of damage block don't stack
  'DamageMeleeBlockAdded '= 32 'http://dota2.gamepedia.com/Damage_Block
  'DamageRangeBlockAdded '= 33

  'VanguardRangeblockAdded 'Vanguard:
  'VanguardMeleeBlockAdded 'block dependant on whether you are melee or ranged
  'DamageBothBlockAdded
  '' DamageBlockPercent '= 34
  'DamageBlock
  'DamageBlockRemoved 'SS Hex
  'DamageInstanceBlock 'treant Living Armor

  'DamageLost 'due to LC Duel, Razor static link

  'LostHealthDamagePercent 'Witch Doc Maledict

  'DamageReturnDuration 'Blademail
  ''MagicDamageAdded
  'PrimaryStatDamageAdded 'Ethereal Blade
  'PrimaryStatLossPercent 'timeber whirling death
  'MagicDamageReceivedMultiplier ' ghost scepter


  ''ogremagi multicast effects
  'MulticastFireblastManaAdded
  'MulticastFireblastCoolReduction
  'MulticastIgniteRadius
  'MulticastIgniteCastRangeAdded

  'MulticastBloodlustRadiusAdded
  'MulticastBloodlustCoolReduction

  'MulticastTwoXChance
  'MulticastThreeXChance
  'MulticastFourXChance

  'MeepoClone 'Meepo Divided We Stand
  'PercentofCreepHealthGained 'Clinks DeathPact

  'BonusDamage
  'BonusDamagePercent 'Lycan Feral Impulse
  'BearBonusDamage 'Lone Druid Synergy
  'BonusDamageoT
  'DuelBonusDamage 'lc duel, seperate item so we can do a buff icon for it
  'StaticLinkBonusDamage 'Razer

  ''melee and ranged are both Physical Damage
  'DamageMeleemultiplier
  'DamageRangemultiplier
  'DamagePhysicalPercent
  'DamageMeleeAdded
  'DamageRangeAdded
  'DamagePhysicalAdded 'passive abilites
  'BackstabRightclickDamageAddedAsPercofAgi 'Riki Backstab. only occurs when attacking from rear
  'PackleaderRClickDamageAsPercofBaseDamandPrimaryStat 'Alpha Wolf Packleader's Aura
  'DamagePhysicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP
  'DamageMagicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP
  'DamageAllTypesStackAdded 'Bristleback Warpath adds damage to spells and abilitys of all damage types
  'DamageAllTypesPercentAdded 'Clinkz DeathPact
  'DamageAbsorbedForMana 'Medusa Mana Shield .absorbs damage in exchange for mana
  'DamagePhysicalSubtracted 'Enfeeble
  'DamageChainPhysicalInflicted 'Mjolnir
  'DamagePhysicalInflicted 'active abilities
  'DamagePhysicalImmunity 'OmniKnight Guardian Angel
  'DamagePhysicalIncomingIncreasedPercent 'Medusa Stone Gaze
  'DamageAllTypesIncomingIncreasesPercent 'Slardar Sprint
  'DamagePhysicalStackingInflicted 'Bristelback Quillspray
  'RightClickDamPhysStackingInflicted 'Ursa furry swipes
  'DamagePhysicalBouncesInflicted 'Witch doc Death Ward
  'DamageMagicalBouncesInflicted 'Lich ulti
  'DamagePhysicaloT
  'DamagePhysicalPerSec
  'DamagePierceAdded
  'DamagePierceChancePercent
  'DamageReduction 'Tide Anchor smash
  'BaseandBonusDamageReduction 'Windranger Focus Fire
  'DamageIncreasePercent 'Chen Penitence

  'DamageMagicalAdded 'for passaive abilities
  'DamageMagicalChain 'Invoker Cold Snap
  'DamageMagicalAbsorbed 'Ember Spirit Flameguard
  'AstralSpiritDamageMagicalAdded 'Elder Titan, will have to determine how many units were hit for this to be accurate
  'DamageMagicalAddedToPhysicalAttacks ' AA Chilling Touch
  'DamageMagicalImmunity 'OmniKnight Repel
  'DamageMagicalInflicted 'for active abilities
  'ExortDamageMagicalInflictedoT 'Invoker Chaos Meteor
  'ExortDamageMagicalInflicted 'Invoker Deafening Blast
  'WexDamageMagicalInflicted 'Invoker Tornado
  'DamageMagicalInflictedOnSpellCast 'SS Overload
  'BallLightDamMagicalInflicted 'Storm Spirit Ball Lightning
  'DamageMagicalInflictedUntilSpellcast 'Silencer Curse of the Silent
  'RequiemDamageMagicalInflicted 'Shadow Fiend Reqiem of Souls. Damage is per line. Line count is 1 for each 2 soulds in Necromastery
  'FadeBoltDamageMagicalBounces 'Rubick, Fade Bolt. bounces diminish the damage, thus the unique modifier. also has no bounce limit but cant hit same target twice
  'WrathofNatureMagicDamageBounceInflicted 'Nature's Proph damage increases with each bounce
  'AdaptiveStrikeDamageMagicalInflicted 'Morphling Adaptive Strike. Used Agility to calc damage inflicted
  'DamageMagicalMinMaxInflicted 'value has a min and max value
  'TargetsCurrentHealthAsDamageMagicalInfliced 'Huskar Life Break Damage Dealt
  'SanitysDamageMagicalInflictedAsMultofIntDiff 'OD Sanity's Eclipse. Damage is a multiple of the difference between OD's int and affected enemy's int. if difference is negative, then no effect
  'LvlDeathDamageMagicalInflicted 'Doom Lvl? Death. has to be calced at time using attacked hero level and abdoom_lvl_death.herolevelmultiplier
  'StaticStormDamageMagicalInflicted 'Disruptor Static Storm. Will have to call list for pulse values and calc with or without aghs
  'OpenWoundsSlowInflicted 'Lifestealer Open Wounds. Will have to call list for slow values for each interval
  'DamageMagicalRandomInflicted 'uses maxval and minval in modvalue for range of random value
  'DamagePureRandomInflicted 'Chen Test of Faith. uses maxval and minval in modvalue for range of random value
  'DamageChainMagicalInflicted 'WitchDoctor Paralyzing cask
  'DamageMagicalInflictedPerAlly ' Tusk Snowball
  'DamageMagicalInflictedPerUnit 'Undying Soul Rip
  'DamageMagicalInflictedPerTarget 'SS Ether Shock, for abilities that hit x num of targets, each only once
  'ShadowPoisonStackDamage 'Shadow Demon Shadow Poison, Each staup up to 5 increases damage, after that it's 50 each addl stack
  'DamageMagicalTimesInt ' Skywrath Arcane Bolt
  'DamageoTMagicalInflicted
  'DamageMagicalPercent
  'DamageMagicalPerSec ''axe battle hunger
  'DamageMagicalOverTimeInflicted 'LeechSeed pulse
  'DamageMagicaloTAsMultofStr 'Pudge Dismemeber
  'MagnatizeDamageOverTime 'will have to make concession for num enemyheroes and numboulders
  'DamageMagicalPerMissingHP 'Necro Reaper's Scythe
  'DamageMagicalPerMissingMana 'Anti Mage Mana Void
  'DamageMagicalPerCreep 'LC Overwhelming Odds
  'DamageMagicalPerHero 'LC Overwhelming Odds

  'DamagePureInflicted
  'SunStrikePureInflicted 'Invoker SunStrike. Damage is divided among enemy targets
  'DamagePureoTInflicted 'Phoenix Sun Ray
  'DamagePureoTasPercofMaxHP 'Phoenix Sun Ray
  'ImpetusDamagePureInflicted 'Enchantress Impetus. damage as function of distance
  'DamagePureAdded
  'WexDamagePureInflicted '
  'DamagePureAsPercentofMaxHP 'Enigma Midnight pulse
  'DamagePureAsPercentofManaPool 'OD Arcane Orb
  'DamagePureAsPercentofMoveDist 'Bloodseeker Rupture
  'MidnightPulsePureDamageAdded 'Black hole scepter upgrade adds midnight pulse damage at current level
  'MirrorImage 'Naga Siren Mirror Image. Takes props from hero's stats at time
  'DamagePurePercent

  'DamageTransferedToCaster 'abaddon borrowed time
  'DamageSharedWithBoundUnits 'Warlock Fatal Bonds

  ''RightClickDamageMultiplier 'weaver germinate
  'RightClickDamageWithBuffs 'gyro flak cannon
  'RightClickDamageWithoutBuffs 'gyro flak cannon
  'RightClickHealthasDamagePercInflicted 'Ursa Enrage
  'RightClickInttoPureDamage 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage
  'RightClickAttackDamage 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage
  'RoshanRClickAttackDamPer4MinAdded 'Strength of the Immortal
  'RightClickDamagePercentageInflicted
  'RightClickDamagePercentSubtracted 'SF Requiem of Souls
  'RightClickDamagePercentInflicted 'Phantom Lancer Spirit Lance Illusion damage
  'RightClickDamageoT 'Right Click attack also puts a DoT on target
  'RightClickAttackAttackSlowInflicted 'Right click attack also adds an attack speed debuff to target
  'RightClickDamageInstanceAvoided 'Faceless BackTrack
  'RightClickCounterAttack 'Axw counter helix, LC MomentofCOurage
  'RightClickCausticFinale 'Sand King Caustic Finale added
  'StrengthPercentageCounterAttack 'Centaur Warrunner Return
  'StrengthPercentageAsAllDamage 'Centaur stampede
  'RightClickDamageAdded 'LC Duel
  'RightClickDamageInflicted 'Windranger Focus Fire
  'RightClickPureDamageInflicted 'Warlock Golem Flaming Fists
  'RightClickNetherToxinDamage 'Viper Nethertoxin does damage for each 20% of health missing in target
  'RightClickDamageAsLine 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets
  'RightClickDamageAsPercOfTargetCurrHP 'lifestealer Feast
  'RightClickBonusDamageAdded 'TB Metamorphosis
  'ExortRightClickBonusDamageAdded 'Invoker Alacrity
  'RightClickBonusDamageInflicted 'Faceless Void Time Lock
  'RightClickBonusPureDamageInflicted 'Spectre Desolate
  'RightClickMoonGlaiveBounces 'Luna moon glaive
  'RightClickBurnedMana 'Necro Warrior Mana Break
  'LastHitGoldAdded 'Alchemist Greevil's Greed
  'LastHitGoldBonusPerStack 'Alchemist Greevil's Greed
  ''DamageCompositeAdded
  ''DamageCompositePercent

  ''DamageHPRemovalAdded
  ''DamageHPRemovalPercentage

  ''DamageUniversalAdded
  ''DamageUniversalPercentage

  'DamagetoHealPercent 'abadon ulti
  'DestroysHeroBelowThreshold 'Axe Culling Blade
  'DestroysHero 'Techies Suicide
  'DestroysTree 'Quellingblade
  'DestroysCreep 'Lich Sacrifice
  'Bash '= 35 'http://dota2.gamepedia.com/Bash
  ''Minibash_Chance
  'Minibash_Damage
  'CleavePercentage '= 36 'http://dota2.gamepedia.com/Cleave , http://dota2.gamepedia.com/Mechanics#Cleave_Damage


  'CritChance '= 37 'http://dota2.gamepedia.com/Critical_strike
  'CritMultiplier '= 38
  'CritDamage 'Jinada

  'Truesight '= 39 'http://dota2.gamepedia.com/Invisibility
  'TruesightRadius '= 40
  'TruesightofTarget 'bounty hunter track

  'BountyGold
  'BonusGold
  'SelfDeny 'Bloodstone Pocket Suicide

  'MantaMeleeIllusionDamagePercentage 'Manta style
  'MantaRangeIllusionDamagePercentage
  'IllusionDamageReducedTo 'Backdoor protection
  'HeroDamageReducedTo 'Backdoor Protection
  'HealoTSetTo 'Backdoor Protection
  ''StaticDamageChance 'Mjollnir
  ''StaticDamage
  'MaimChance 'sange

  'SpellBlock ' Linken's blocks n spells
  'SpellBlockDuration ' Blocks all spells for n seconds

  'MeleeSlow 'orb of venom
  'RangeSlow

  'QuillSprayCast 'Bristleback Bristleback ability

  'TimeLapse 'weaver ulti

  'TinyTossBonusDamage 'Tiny Grow
  'TinyTossDamageInflicted 'seperate type to enable check for TinyTossBonusDamage

  ''Unique attack modifiers
  ''http://dota2.gamepedia.com/Unique_Attack_Modifier
  'ManaBreak '= 41 'Anti-Mage
  'SearingArrows '= 42 'Clinkz
  'Impetus '= 43 'Enchantress
  'LiquidFire '= 44 'Jakiro
  'CausticFinale '= 45 'SandKing
  'PoisonAttack '= 46 'Viper, Orb of Venom
  'IncapBite '= 47 'Broodmother
  'InvokeSpellCount 'Invoker Invoke MaxSpells
  'InvokeASpell 'Invoker Invoke
  'FrostArrows '= 48 'Drow
  'MeltingStrike '= 49 'Invoker's forged Spirit
  'ArcaneOrb '= 50 'OD
  'GlaivesWisdom '= 51 'Silencer
  'Corruption '= 52 'Desolator
  'ColdAttack '= 53 'Skadi
  ''ChainLightningChance 'Maelstrom, Mjolnir
  'ChainLightning '= 54 'Maelstrom, Mjolnir
  'Feedback '= 55 'Diffusal Blade
  'LifeStealAdded '= 56 'Helm of the Dominator, mask of madness, satanic 'http://dota2.gamepedia.com/Lifesteal
  'LifeDrainDrainfromTarget 'Pugna Life Drain. Different effects depending if target is friend or foe
  'LifeDrainSelfEffect 'Pugna Life Drain. Different effect to pugna depending on whether targeting friend or foe
  'LifeStealPercent
  'LifestealAddedtoAllAttackers 'Lifestealer Open Wounds. Allied Heroes get healtch when attacking enemy unit with this debuff

  'LifeDrainPercent 'DP Exorcism

  'ChenCreepFullHeal 'Chen Hand of God
  'ChenAncientCount 'count of potential ancients that can be holy pursuasioned
  'CreepControlled 'Chen Holy Pursuasion
  'ControlledCreepHealthBonus 'Chen Holy Pursuasion
  'Consumption 'Doom Devour

  ''Disable and Status Effects
  'BlindChance '= 57 'http://dota2.gamepedia.com/Blind
  'BlindDuration '= 58

  'Cyclone '= 59 'http://dota2.gamepedia.com/Cyclone
  'QuasCyclone 'Invoker Tornado
  'Stun '= 60 'http://dota2.gamepedia.com/Stun 'Does NOT include MiniStuns
  'AdaptiveStrikeStun 'Morphling Adaptive Strike. Calculated using current strength and agility
  'StunRandom 'ChaosKnight Chaos Bolt
  'StunChain 'Witch doc Paralyzing Cask
  'MiniStun
  ''StunChance 'Skull Basher
  'MeleeStun ' Abyssal Blade
  'RangeStun 'Abyssal blade
  'ShackleTime '= 61 'http://dota2.gamepedia.com/Disable like lasso
  'Hex '= 62 'http://dota2.gamepedia.com/Hex
  'PauseTime '= 63 'http://dota2.gamepedia.com/Pause
  'Traptime '= 64 'http://dota2.gamepedia.com/Trap clockwork cogs
  'Taunt '= 65 'http://dota2.gamepedia.com/Taunt
  'Sleep '= 66 'http://dota2.gamepedia.com/Sleep
  'Ensnare '= 67 'http://dota2.gamepedia.com/Ensnare
  'Entangle '= 68 'http://dota2.gamepedia.com/Entangle

  'Disarm
  'WexDisarm 'Invoker Deafening Blast. Duration determined by wex level 
  'DisarmRange ' Heaven's Halberd
  'DisarmMelee '= 69 'http://dota2.gamepedia.com/Disarm
  'DisjointRange '= 70 'http://dota2.gamepedia.com/Disjoint
  'Dispel '= 71 'http://dota2.gamepedia.com/Dispel

  'Invisibility '= 72 'http://dota2.gamepedia.com/Invisibility
  'StationaryInvisibility 'TA Meld. Invis until TA moves
  'MiniMapInvisibility 'Phantom Ass, Blur
  'StealthVisibility 'dust of appearance, sentry wards
  'Vision 'observerward
  'WexVision 'Invoker Tornado
  'VisionDay 'beast hawk

  'Ghost_Form_Time 'Ghost scepter, ethereal blade
  'Phase_Form 'phase boots
  'Invulnerability '= 73 'http://dota2.gamepedia.com/Invulnerability
  'VisionNight 'beast hawk
  'DarknessNight 'NightStalker. Artificial night induced. max vis for all enemies 675
  'VisionNightAdded 'Lycan Shapeshift

  'Phantasms 'Chaoes night ulti, receiver will have to get current chaos knight build to calc phant stats
  'GreaterBashofCurrentLevel 'Spirit Breaker Nether Strike

  'Purge '= 74 'http://dota2.gamepedia.com/Purge
  'PurgeFrequency '= 75

  'Shatter 'AA IceBlast

  'Pullback ' x marks, pudgehook
  'PullForward
  'Knockback 'batrider firefly and many others
  'QuasKnockback 'Invoker Deafening Blas. Duration as distance determined byQuas level
  'KotLSpiritForm 'Kotl
  'Silence '= 76 'http://dota2.gamepedia.com/Silence

  'Ethereal_Time '= 77 'http://dota2.gamepedia.com/Ethereal
  'Teleport '= 78
  'TeleportRandom 'Chaosknight Reality Rift
  'PushForward 'force staff
  'BallLightPushForward 'SS Ball Lightning charge
  'PushSideways 'Beastmaster Primal Roar

  'Dominate 'Helm of the dominator

  'ShallowGrave 'Dazzle

  'Reincarnate 'Aegis

  'Replicant 'Morphling Replicate. Need to know which hero is targeted at the time

  'Reset_Cooldowns 'Refresher
  'RemoveBuffs 'Diffusal Blade
  'RemoveDebuffs ' abaddon ulti
  'RemoveDisables 'LC Press the attack
  ''atomic modfiers (Components of some items above)
  'AttackMute 'Flaming Lasso Batrider
  'AbilityMute '= 79 'unable to cast abilities
  'AbilitySteal 'Doom Devour
  'ItemMute '= 80 'unable to cast items
  'BlinkMute '= 81 'unable to blink
  'MoveMute '= 82 'unable to move
  'TurnMute '= 83 'unable to turn
  'TeleportMute 'Blink (Queen of Pain) , Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger.
  'RightClickMute '= 84 'unable to rightclick
  'RightClickStun 'Faceless TimeLock
  'RoshanSlamDamageTimeIncrease 'Roshan Slam increases in damage every 4 minutes
  'RightClickMoveSpeedPercSubtracted 'Meepo Geostrike
  'TargetabilityMute '= 85 'unable to be targetted
  'TargetedDamageReflected 'nyx Spiked Carapace. Only reflects damage targetted directly at nyx
  'ReflectedDamageInflicted 'Nyx Spiked Carapace. damage component of spell. inlficted on attacker
  'TargetMute 'stops eveything on target (items, move, abilities, etc.) Bane Nightmare
  'InvisibilityMute 'treant overgrowth
End Enum

'Public Enum eModifierGroup
'  AllDamage
'  AllMagicDamage
'  AllPureDamage
'  AllPhysDamage
'  AllVision
'  AllStealth
'  AllStun
'  AllInt
'  AllStr
'  AllAgi
'  AllHeroes
'  AllPets
'  AllCreeps
'  AllStructs
'End Enum

'Public Enum eCalcType
'  None

'End Enum



Public Enum eMathAction
  None
  InputDividedByValue 'averages
  InputdividedbyAlliedHeroCount
  InputPlusValue
  InputPlusPercentageOfPrePercValue
  InputMultipliedByValue
  InputPlusProductofValueAndStaticVal
  InputMinusValue
  InputMinusPercetageofPrePercValue
  SetToValueIfValueExists
  SetToMaxValueIfValueExists
  SetToMinValueIfValueExists
  SetToValueIfGreaterThanInput
End Enum
Public Enum eStattype
  None
  Agility
  AllDamageAvg
  AllDamageBurst
  ArmorxPoint06
  AttackDamageAverage
  AttackDamageHigh
  AttackDamageLow
  AttackRange
  AttackSpeed 'AttackSpeed = AttackSpeedBuffs - AttaskSpeedDebuffs
  BaseAttackTime
  CritChance
  CritMultiplier
  CritDamage
  EffectiveHP
  Experience
  Hex
  HexAvg
  HitPointRegen
  HitPoints
  HPRemoval
  Intelligence
  Kills
  MagicalDamageResistance
  MagicDamage
  MagicDamageAvg
  MagicImmunity
  MagicImmunityAvg
  Mana
  ManaRegen
  MissileSpeed
  MovementSpeed
  Networth
  Number1
  NumberPoint06
  PeriodicGold
  PhysicalArmor
  PhysicalDamage
  PhysicalDamageAmplification
  PhysicalDamageAvg
  PhysicalDamageNegation
  PhysicalDamageReduction
  PrimaryAttribute
  PureDamage
  PureDamageAvg
  Resources
  SpellImmunityCount
  Stealth
  StealthTime
  Strength
  Stun
  StunAvg
  TrueSight
  TurnRate
  VisionDay
  VisionNight


  TeamKills
  TeamTtlEffectiveHP
  TeamTtlDamageHi
  TeamTtlDamageLo
  TeamTtlDamageAvg
  TeamTtlHP
  TeamTtlHPRegen
  TeamTtlMana
  TeamTtlManaRegen
  TeamTtlVisionDay
  TeamTtlVisionNight
  TeamTtlDPSPeak
  TeamTtlDPSAvg
  TeamTtlPhysDamageBurst
  TeamTtlPhysDPSAvg
  TeamTtlMagDamageBurst
  TeamTtlMagDPSAvg
  TeamTtlPureDamageBurst
  TeamTtlPureDPSAvg
  TeamTtlStunDuratoin
  TeamTtlHexDuration
  TeamTtlSpellImmunityCount
  TeamPhysicalArmor
  TeamMagicResistance
End Enum
Public Enum eComparerType
  MyID
  ParentGameEntityID
  ParentGameEntityType
  SourceID
  SourceType
  ModifierType
  TargetIDs
  'TeamOf1stTargetID
End Enum
Public Enum eUnittype
  None
  Hero '= 1
  Pet
  LaneCreep '= 2
  JungleCreep '= 3
  Tower '= 4
  MeleeRax '= 5
  RangeRax '= 6
  BufferBuilding '= 7
  AncientCreep '= 8
  Fountain '= 9
  RegularSummons
  Illusion
  CreepHero
  Ward
  CreepNone
  Ancient
  Unclassified
End Enum
Public Enum eArmorType
  None
  Hero '= 1
  Fortified '= 2
  Heavy '= 3
  Medium '= 4
  Light '= 5
  Unarmored '= 6
End Enum
Public Enum ePrimaryStat
  None
  Strength '= 0
  Agility '= 1
  Intelligence '= 2

End Enum
Public Enum eAttackType
  None
  Ranged '= 0
  Melee '= 1
End Enum

Public Enum eAttackSubType
  None
  Normal
  Piercing
  Siege
  Chaos
  Hero
End Enum
Public Enum eRole
  Initiator '= 1
  Disabler '= 2
  Support '= 3
  LaneSupport '= 4
  Nuker '= 5
  Carry '= 6
  Durable '= 7
  Pusher '= 8
  Escape '= 9
  Jungler '= 10
End Enum
Public Enum eAbilityName
  'Abilities---------------------------------------
  None

  abStat_Gain

  abAlacrity
  'abFocused_Detonate
  abLand_Mines
  'abMinefield_Sign
  abRemote_Mines
  'abReturn_Chakram
  abStasis_Trap
  abAnti_Mage_Blink
  abSuicide_Squad_Attack
  abShadow_Shaman_Hex
  abQoP_Blink
  'abKunkka_Return
  abAftershock
  abEcho_Slam
  abEnchant_Totem
  abFissure
  abGods_Strength
  abGreat_Cleave
  abStorm_Hammer
  abWarcry
  abAvalanche
  abCraggy_Exterior
  abGrow
  abToss
  abGhostship
  'abKunkkaReturn
  abTidebringer
  abTorrent
  abX_Marks_The_Spot
  abCall_Of_The_Wild
  abInner_Beast
  abPrimal_Roar
  abWild_Axes
  abBreathe_Fire
  abDragon_Blood
  abDragon_Tail
  abElder_Dragon_Form
  abBattery_Assault
  abHookshot
  abPower_Cogs
  abRocket_Flare
  abDegen_Aura
  abGuardian_Angel
  abPurification
  abRepel
  abBerserkers_Blood
  abBurning_Spear
  abInner_Vitality
  abLife_Break
  abAcid_Spray
  abChemical_Rage
  abGreevils_Greed
  abUnstable_Concoction
  'abUnstable_Concoction_Throw
  abDrunken_Brawler
  abDrunken_Haze
  abPrimal_Split
  abThunder_Clap
  abLeech_Seed
  abLiving_Armor
  abNatures_Guise
  abOvergrowth
  abEyes_In_The_Forest
  'abBreak_Tether
  abOvercharge
  abRelocate
  abSpirits
  'abSpirits_In
  'abSpirits_Out
  abTether
  abDouble_Edge
  abHoof_Stomp
  abCentaurReturn
  abStampede
  abChakram
  abReactive_Armor
  abTimber_Chain
  abWhirling_Death
  abBristleback
  abQuill_Spray
  abViscous_Nasal
  abWarpath
  abFrozen_Sigil
  abIce_Shards
  'abLaunch_Snowball
  abSnowball
  abWalrus_Punch
  abAstral_Spirit
  abEarth_Splitter
  abEcho_Stomp
  abNatural_Order
  'abReturn_Astral_Spirit
  abDuel
  abMoment_Of_Courage
  abOverwhelming_Odds
  abPress_The_Attack
  abBoulder_Smash
  abGeomagnetic_Grip
  abMagnetize
  abRolling_Boulder
  'abStone_Remnant
  abFire_Spirits
  abIcarus_Dive
  'abLaunch_Fire_Spirit
  'abStop_Icarus_Dive
  'abStop_Sun_Ray
  abSun_Ray
  abSupernova
  'abToggle_Movement
  'abAnti_Mage_Blink
  abMana_Break
  abMana_Void
  abSpell_Shield
  abFrost_Arrows
  abGust
  abMarksmanship
  abPrecision_Aura
  abBlade_Dance
  abBlade_Fury
  abHealing_Ward
  abOmnislash
  abLeap
  abMoonlight_Shadow
  abSacred_Arrow
  abStarstorm
  abAdaptive_Strike
  abMorph_Agility_Gain
  'abMorph_Strength_Gain
  abMorph_Replicate
  'abReplicate
  abWaveform
  abDoppelganger
  abJuxtapose
  abPhantom_Rush
  abSpirit_Lance
  abMagic_Missile
  abNether_Swap
  abVengeance_Aura
  abWave_Of_Terror
  abBackstab
  abBlink_Strike
  abPermanent_Invisibility
  abSmoke_Screen
  abAssassinate
  abHeadshot
  abShrapnel
  abTake_Aim
  abMeld
  abPsi_Blades
  abPsionic_Trap
  abRefraction
  'abTrap
  abEclipse
  abLucent_Beam
  abLunar_Blessing
  abMoon_Glaive
  abJinada
  abShadow_Walk
  abShuriken_Toss
  abTrack
  abEarthshock
  abEnrage
  abFury_Swipes
  abOverpower
  abCall_Down
  abFlak_Cannon
  abHoming_Missile
  abRocket_Barrage
  abBattle_Cry
  'abDruid_Form
  abRabid
  abSummon_Spirit_Bear
  abSynergy
  abTrue_Form
  abEnsnare
  abMirror_Image
  abRip_Tide
  abSong_Of_The_Siren
  'abSong_Of_The_Siren_Cancel
  abBattle_Trance
  abBerserkers_Rage
  abFervor
  abWhirling_Axes__Melee
  'abWhirling_Axes__Ranged
  'abActivate_Fire_Remnant
  abFire_Remnant
  abFlame_Guard
  abSearing_Chains
  abSleight_Of_Fist
  abArcane_Aura
  abCrystal_Nova
  abFreezing_Field
  abFrostbite
  abDream_Coil
  'abEthereal_Jaunt
  abIllusory_Orb
  abPhase_Shift
  abWaning_Rift
  abBall_Lightning
  abElectric_Vortex
  abOverload
  abStatic_Remnant
  abFocus_Fire
  abPowershot
  abShackleshot
  abWindrun
  abArc_Lightning
  abLightning_Bolt
  abStatic_Field
  abThundergods_Wrath
  abDragon_Slave
  abFiery_Soul
  abLaguna_Blade
  abLight_Strike_Array
  abEther_Shock
  abMass_Serpent_Ward
  abShackles
  abHeatSeeking_Missile
  abLaser
  abMarch_Of_The_Machines
  abRearm
  abNatures_Call
  abSprout
  abTeleportation
  abWrath_Of_Nature
  abEnchant
  abImpetus
  abNatures_Attendants
  abUntouchable
  abDual_Breath
  abIce_Path
  abLiquid_Fire
  abMacropyre
  abHand_Of_God
  abHoly_Persuasion
  abPenitence
  abTest_Of_Faith
  abCurse_Of_The_Silent
  abGlaives_Of_Wisdom
  abGlobal_Silence
  abLast_Word
  abBloodlust
  abFireblast
  abIgnite
  abMulticast
  'abUnrefined_Fireblast
  abFade_Bolt
  abNull_Field
  abSpell_Steal
  abTelekinesis
  'abTelekinesis_Land
  abGlimpse
  abKinetic_Field
  abStatic_Storm
  abThunder_Strike
  'abBlinding_Light
  abChakra_Magic
  abIlluminate
  abMana_Leak
  ' abRecall
  'abRelease_Illuminate
  abSpirit_Form
  abAncient_Seal
  abArcane_Bolt
  abConcussive_Shot
  abMystic_Flare
  abBattle_Hunger
  abBerserkers_Call
  abCounter_Helix
  abCulling_Blade
  abDismember
  abFlesh_Heap
  abMeat_Hook
  abRot
  abBurrowstrike
  abCaustic_Finale
  abEpicenter
  abSand_Storm
  abAmplify_Damage
  abBash
  abSlithereen_Crush
  abSprint
  abAnchor_Smash
  abGush
  abKraken_Shell
  abRavage
  abMortal_Strike
  abReincarnation
  abVampiric_Aura
  abWraithfire_Blast
  'abConsume
  abFeast
  abInfest
  abOpen_Wounds
  abRage
  abCrippling_Fear
  abDarkness
  abHunter_In_The_Night
  abVoid
  abDevour
  abDoom
  abLvl_Death
  abScorched_Earth
  abCharge_Of_Darkness
  abEmpowering_Haste
  abGreater_Bash
  abNether_Strike
  abFeral_Impulse
  abHowl
  abShapeshift
  abSummon_Wolves
  abChaos_Bolt
  abChaos_Strike
  abPhantasm
  abReality_Rift
  abDecay
  abFlesh_Golem
  abSoul_Rip
  abTombstone
  abEmpower
  abReverse_Polarity
  abShockwave
  abSkewer
  abAphotic_Shield
  abBorrowed_Time
  abCurse_Of_Avernus
  abMist_Coil
  abBlood_Rite
  abBloodrage
  abRupture
  abThirst
  abNecromastery
  abPresence_Of_The_Dark_Lord
  abRequiem_Of_Souls
  abShadowraze
  abEye_Of_The_Storm
  abPlasma_Field
  abStatic_Link
  abUnstable_Current
  abPlague_Ward
  abPoison_Nova
  abPoison_Sting
  abVenomous_Gale
  abBacktrack
  abChronosphere
  abTime_Lock
  abTime_Walk
  abBlur
  abCoup_De_Grace
  abPhantom_Strike
  abStifling_Dagger
  abCorrosive_Skin
  abNethertoxin
  abPoison_Attack
  abViper_Strike
  abDeath_Pact
  abSearing_Arrows
  abSkeleton_Walk
  abStrafe
  abIncapacitating_Bite
  abInsatiable_Hunger
  abSpawn_Spiderlings
  abSpin_Web
  abGeminate_Attack
  abShukuchi
  abThe_Swarm
  abTime_Lapse
  abDesolate
  abDispersion
  abHaunt
  'abReality
  abSpectral_Dagger
  abDivided_We_Stand
  abEarthbind
  abGeostrike
  abPoof
  abImpale
  abMana_Burn
  abSpiked_Carapace
  abVendetta
  abDark_Pact
  abEssence_Shift
  abPounce
  abShadow_Dance
  abMana_Shield
  abMystic_Snake
  abSplit_Shot
  abStone_Gaze
  abConjure_Image
  abMetamorphosis
  abReflection
  abSunder
  abBrain_Sap
  abEnfeeble
  abFiends_Grip
  abNightmare
  ' abNightmare_End
  abChain_Frost
  abFrost_Blast
  abIce_Armor
  abSacrifice
  abEarth_Spike
  abFinger_Of_Death
  abLion_Hex
  abMana_Drain
  abDeath_Ward
  abMaledict
  abParalyzing_Cask
  abVoodoo_Restoration
  abBlack_Hole
  abDemonic_Conversion
  abMalefice
  abMidnight_Pulse
  abDeath_Pulse
  abHeartstopper_Aura
  abReapers_Scythe
  abSadist
  abChaotic_Offering
  abFatal_Bonds
  abShadow_Word
  abUpheaval
  'abQoP_Blink
  abScream_Of_Pain
  abShadow_Strike
  abSonic_Wave
  abCrypt_Swarm
  abExorcism
  abSilence
  abWitchcraft
  abDecrepify
  abLife_Drain
  abNether_Blast
  abNether_Ward
  abPoison_Touch
  abShadow_Wave
  abShallow_Grave
  abWeave
  abDiabolic_Edict
  abLightning_Storm
  abPulse_Nova
  abSplit_Earth
  abIon_Shell
  abSurge
  abVacuum
  abWall_Of_Replica
  abFirefly
  abFlamebreak
  abFlaming_Lasso
  abSticky_Napalm
  abChilling_Touch
  abCold_Feet
  abIce_Blast
  abIce_Vortex
  'abRelease
  abChaos_Meteor
  abCold_Snap
  abDeafening_Blast
  abEmp
  abExort
  abForge_Spirit
  abGhost_Walk
  abIce_Wall
  abInvoke
  abQuas
  abSun_Strike
  abTornado
  abWex
  abArcane_Orb
  abAstral_Imprisonment
  abEssence_Aura
  abSanitys_Eclipse
  abDemonic_Purge
  abDisruption
  abShadow_Poison
  'abShadow_Poison_Release
  abSoul_Catcher
  abGrave_Chill
  abGravekeepers_Cloak
  abSoul_Assumption
  abSummon_Familiars

  abHawk_Invisibility
  abBoar_Poison
  abLycan_Wolf_Critical_Strike
  abLycan_Wolf_Invisibility
  abUndying_Zombie_Deathlust
  abUndying_Zombie_Spell_Immunity
  abSpiderling_Poison_Sting
  abSpiderling_Spawn_Spiderite
  abForged_Spirit_Melting_Strike
  abNecro_Warrior_Mana_Break
  abNecro_Warrior_Last_Will
  abNecro_Warrior_True_Sight
  abNecro_Archer_Mana_Burn
  abNecro_Archer_Archer_Aura
  abEarth_Brewmaster_Hurl_Boulder
  abEarth_Brewmaster_Spell_Immunity
  abEarth_Brewmaster_Pulverize
  abEarth_Brewmaster_Thunder_Clap
  abStorm_Brewmaster_Dispel_Magic
  abStorm_Brewmaster_Cyclone
  abStorm_Brewmaster_Wind_Walk
  abStorm_Brewmaster_Drunken_Haze
  abFire_Brewmaster_Permanent_Immolation
  abFire_Brewmaster_Drunken_Brawler
  abGolem_Warlock_Flaming_Fists
  abGolem_Warlock_Permanent_immolation
  abSpirit_Bear_Return
  abSpirit_Bear_Entangling_Claws
  abSpirit_Bear_Demolish
  abFamiliar_Stone_Form
  abFamiliar_Spell_Immunity
  abPlague_Ward_Poison_Sting
  abTornado_Tempest
  'abPsionic_Trap_Trap
  abPsionic_Trap_Self_Trap
  abRemote_Mines_Pinpoint_Detonate
  abKobold_Foreman_Speed_Aura
  abHill_Troll_Priest_Heal
  abHill_Troll_Priest_Mana_Aura
  abVhoul_Assassin_Envenomed_Weapon
  abGhost_Frost_Attack
  abHarpy_Stormcrafter_Chain_Lightning
  abCentaur_Congeror_War_Stomp
  abGiant_Wolf_Critical_Strike
  abAlpha_Wolf_Critical_Strike
  abAlpha_Wolf_Packleaders_Aura
  abSatyr_Banisher_Purge
  abSatyr_Mindstealer_Mana_Burn
  abOgre_Frostmage_Ice_Armor
  abMud_Golem_Spell_Immunity
  abSatyr_Tormentor_Shockwave
  abHellbear_Smasher_Thunder_Clap
  abHellbear_Smasher_Swiftness_Aura
  abWildwing_Ripper_Tornado
  abWildwing_Ripper_Toughness_Aua
  abDark_Troll_Summoner_Ensnare
  abDark_Troll_Summoner_Raise_Dead
  abAncient_Black_Dragon_Splash_Attack
  abAncient_Black_Dragon_Spell_Immunity
  abAncient_Granite_Golem_Granite_Aura
  abAncient_Granite_Golem_Spell_Immunity
  abAncient_Rock_Golem_Spell_Immunity
  abAncient_Thunderhide_Slam
  abAncient_Thunderhide_Frenzy
  abAncient_Thunderhide_Spell_Immunity
  abAncient_Rumblehide_Spell_Immunity
  abRoshan_Spell_Block
  abRoshan_Bash
  abRoshan_Slam
  abRoshan_Strength_Of_The_Immortal
  abBuilding_Backdoor_Protection
  abBuilding_Glyph_of_Fortification

End Enum

  'lists everysingle thing in the game
  Public Enum eEntity
    ' cast string to enum value example
    ' Dim notCheckedStatus  = DirectCast([Enum].Parse(GetType(TCheckStatus), "NotChecked"), TCheckStatus)
    ' Dim allStatusNames = [Enum].GetNames(GetType(TCheckStatus))
    ' http://stackoverflow.com/questions/8724387/how-to-retrieve-an-enum-member-given-its-name

    None
    'Items----------------------------------------
    itmCLARITY '= 0
    itmTANGO '= 1
    itmHEALING_SALVE '= 2
    itmSMOKE_OF_DECEIT '= 3
    itmTOWN_PORTAL_SCROLL '= 4
    itmDUST_OF_APPEARANCE '= 5
    itmANIMAL_COURIER '= 6
    itmFLYING_COURIER '= 7
    itmOBSERVER_WARD '= 8
    itmSENTRY_WARD '= 9
    itmBOTTLE '= 10

    itmIRON_BRANCH '= 11
    itmGAUNTLETS_OF_STRENGTH '= 12
    itmSLIPPERS_OF_AGILITY '= 13
    itmMANTLE_OF_INTELLIGENCE '= 14
    itmCIRCLET '= 15
    itmBELT_OF_STRENGTH '= 16
    itmBAND_OF_ELVENSKIN '= 17
    itmROBE_OF_THE_MAGI '= 18
    itmOGRE_CLUB '= 19
    itmBLADE_OF_ALACRITY '= 20
    itmSTAFF_OF_WIZARDRY '= 21
    itmULTIMATE_ORB '= 22

    itmRING_OF_PROTECTION '= 23
    itmQUELLING_BLADE '= 24
    itmSTOUT_SHIELD '= 25
    itmBLADES_OF_ATTACK '= 26
    itmCHAINMAIL '= 27
    itmHELM_OF_IRON_WILL '= 28
    itmBROADSWORD '= 29
    itmQUARTERSTAFF '= 30
    itmCLAYMORE '= 31
    itmJAVELIN '= 32
    itmPLATEMAIL '= 33
    itmMITHRIL_HAMMER '= 34

    itmMAGIC_STICK '= 35
    itmSAGES_MASK '= 36
    itmRING_OF_REGEN '= 37
    itmBOOTS_OF_SPEED '= 38
    itmGLOVES_OF_HASTE '= 39
    itmCLOAK '= 40
    itmGEM_OF_TRUE_SIGHT '= 41
    itmMORBID_MASK '= 42
    itmGHOST_SCEPTER '= 43
    itmTALISMAN_OF_EVASION '= 44
    itmBLINK_DAGGER '= 45
    itmSHADOW_AMULET '= 46
    itmWRAITH_BAND '= 47
    itmNULL_TALISMAN '= 48
    itmMAGIC_WAND '= 49
    itmBRACER '= 50
    itmPOOR_MANS_SHIELD '= 51
    itmSOUL_RING '= 52
    itmPHASE_BOOTS '= 53
    itmPOWER_TREADS '= 54
    itmOBLIVION_STAFF '= 55
    itmPERSEVERANCE '= 56
    itmHAND_OF_MIDAS '= 57
    itmBOOTS_OF_TRAVEL '= 58

    itmRING_OF_BASILIUS '= 59
    itmHEADDRESS '= 60
    itmBUCKLER '= 61
    itmURN_OF_SHADOWS '= 62
    itmRING_OF_AQUILA '= 63
    itmTRANQUIL_BOOTS '= 64
    itmMEDALLION_OF_COURAGE '= 65
    itmARCANE_BOOTS '= 66
    itmDRUM_OF_ENDURANCE '= 67
    itmVLADMIRS_OFFERING '= 68
    itmMEKANSM '= 69
    itmPIPE_OF_INSIGHT '= 70

    itmFORCE_STAFF '= 71
    itmNECRONOMICON_1 '= 72
    itmNECRONOMICON_2 '= 73
    itmNECRONOMICON_3 '= 74
    itmEULS_SCEPTER_OF_DIVINITY '= 75
    itmDAGON_1 '= 76
    itmDAGON_2 '= 77
    itmDAGON_3 '= 78
    itmDAGON_4 '= 79
    itmDAGON_5 '= 80
    itmVEIL_OF_DISCORD '= 81
    itmROD_OF_ATOS '= 82
    itmAGHANIMS_SCEPTER '= 83
    itmORCHID_MALEVOLENCE '= 84
    itmREFRESHER_ORB '= 85
    itmSCYTHE_OF_VYSE '= 86

    itmCRYSTALYS '= 87
    itmARMLET_OF_MORDIGGIAN '= 88
    itmSKULL_BASHER '= 89
    itmSHADOW_BLADE '= 90
    itmBATTLE_FURY '= 91
    itmETHEREAL_BLADE '= 92
    itmRADIANCE '= 93
    itmMONKEY_KING_BAR '= 94
    itmDAEDALUS '= 95
    itmBUTTERFLY '= 96
    itmABYSSAL_BLADE '= 97

    itmHOOD_OF_DEFIANCE '= 98
    itmBLADE_MAIL '= 99
    itmVANGUARD '= 100
    itmSOUL_BOOSTER '= 101
    itmBLACK_KING_BAR '= 102
    itmSHIVAS_GUARD '= 103
    itmMANTA_STYLE '= 104
    itmBLOODSTONE '= 105
    itmLINKENS_SPHERE '= 106
    itmASSAULT_CUIRASS '= 107
    itmHEART_OF_TARRASQUE ' = 108

    itmHELM_OF_THE_DOMINATOR '= 109
    itmMASK_OF_MADNESS '= 110
    itmSANGE '= 111
    itmYASHA '= 112
    itmMAELSTROM '= 113
    itmDIFFUSAL_BLADE '= 114
    itmDESOLATOR '= 115
    itmHEAVENS_HALBERD '= 116
    itmSANGE_AND_YASHA '= 117
    itmMJOLLNIR '= 118
    itmEYE_OF_SKADI '= 119
    itmSATANIC '= 120

    itmDEMON_EDGE '= 121
    itmEAGLESONG '= 122
    itmREAVER '= 123
    itmSACRED_RELIC '= 124
    itmHYPERSTONE '= 125
    itmRING_OF_HEALTH '= 126
    itmVOID_STONE '= 127
    itmMYSTIC_STAFF '= 128
    itmENERGY_BOOSTER '= 129
    itmPOINT_BOOSTER '= 130
    itmVITALITY_BOOSTER ' = 131
  itmORB_OF_VENOM '= 132

  itmAEGIS_OF_THE_IMMORTAL
  itmDIVINE_RAPIER


    itmRECIPE_WRAITH_BAND '= 133
    itmRECIPE_NULL_TALISMAN '= 134
    itmRECIPE_MAGIC_WAND '= 135
    itmRECIPE_BRACER '= 136
    itmRECIPE_SOUL_RING '= 137
    itmRECIPE_HAND_OF_MIDAS '= 138
    itmRECIPE_BOOTS_OF_TRAVEL '= 139
    itmRECIPE_HEADDRESS '= 140
    itmRECIPE_BUCKLER '= 141
    itmRECIPE_URN_OF_SHADOWS '= 142
    itmRECIPE_MEDALLION_OF_COURAGE '= 143
    itmRECIPE_DRUM_OF_ENDURANCE '= 144
    itmRECIPE_VLADMIRS_OFFERING '= 145
    itmRECIPE_MEKANSM '= 146
    itmRECIPE_PIPE_OF_INSIGHT '= 147
    itmRECIPE_FORCE_STAFF '= 148
    itmRECIPE_NECRONOMICON_1 '= 149
    itmRECIPE_NECRONOMICON_2 '= 150
    itmRECIPE_NECRONOMICON_3 '= 151
    itmRECIPE_NECRONOMICON_4 '= 152
    itmRECIPE_EULS_SCEPTER_OF_DIVINITY '= 153
    itmRECIPE_DAGON_1 '= 154
    itmRECIPE_DAGON_2 '= 155
    itmRECIPE_DAGON_3 '= 156
    itmRECIPE_DAGON_4 '= 157
    itmRECIPE_DAGON_5 '= 158
    itmRECIPE_VEIL_OF_DISCORD '= 159
    itmRECIPE_ORCHID_MALEVOLENCE '= 160
    itmRECIPE_REFRESHER_ORB '= 161
    itmRECIPE_CRYSTALYS '= 162
    itmRECIPE_ARMLET_OF_MORDIGGIAN '= 163
    itmRECIPE_SKULL_BASHER '= 164
    itmRECIPE_RADIANCE '= 165
    itmRECIPE_DAEDALUS '= 166
    itmRECIPE_BLACK_KING_BAR '= 167
    itmRECIPE_SHIVAS_GUARD '= 168
    itmRECIPE_MANTA_STYLE '= 169
    itmRECIPE_LINKENS_SPHERE '= 170
    itmRECIPE_ASSAULT_CUIRASS '= 171
    itmRECIPE_HEART_OF_TARRASQUE ' = 172
    itmRECIPE_MASK_OF_MADNESS '= 173
    itmRECIPE_SANGE '= 174
    itmRECIPE_YASHA '= 175
    itmRECIPE_MAELSTROM '= 176
  itmRECIPE_DIFFUSAL_BLADE '= 177
  itmRECIPE_DIFFUSAL_BLADE_2 '= 177
    itmRECIPE_DESOLATOR '= 178
    itmRECIPE_MJOLLNIR '= 179
    itmRECIPE_SATANIC '= 180

    itmmAEIGIS_OF_THE_IMMORTAL
    itmCHEESE

    'Units----------------------------------------------
    untEnemyUnits '= 0
    untUnitTarget '= 1
    untPointTarget '= 2
    untPassive '= 3
    untAura '= 4
    untAutoCast '= 5
    untChanneled '= 6
    untNoTarget '= 7
    untToggle '= 8
    untHeroes '= 9
    untAllies '= 10
    untAlliedUnits '= 11
    untEnemieTeam '= 12
    untEnemyCreeps '= 13 'http://www.reddit.com/r/DotA2/comments/2eulqu/some_facts_about_creep_exp/
    untUnits '= 14

    untRadiant '= 15
    untDire '= 16

    untEarthshaker '= 17
    untSven '= 18
    untTiny '= 19
    untKunkka '= 20
    untBeastmaster '= 21
    untDragon_Knight '= 22
    untClockwerk '= 23
    untOmniknight '= 24
    untHuskar '= 25
    untAlchemist '= 26
    untBrewmaster '= 27
    untTreant_Protector '= 28
    untIo '= 29
    untCentaur_Warrunner '= 30
    untTimbersaw '= 31
    untBristleback '= 32
    untTusk '= 33
    untElder_Titan '= 34
    untLegion_Commander '= 35
    untEarth_Spirit '= 36
    untPhoenix '= 37
    untAnti_Mage '= 38
    untDrow_Ranger '= 39
    untJuggernaut '= 40
    untMirana '= 41
    untMorphling '= 42
    untPhantom_Lancer '= 43
    untVengeful_Spirit '= 44
    untRiki '= 45
    untSniper '= 46
    untTemplar_Assassin '= 47
    untLuna '= 48
    untBounty_Hunter '= 49
    untUrsa '= 50
    untGyrocopter '= 51
    untLone_Druid '= 52
    untNaga_Siren '= 53
    untTroll_Warlord '= 54
    untEmber_Spirit '= 55
    untCrystal_Maiden '= 56
    untPuck '= 57
    untStorm_Spirit '= 58
    untWindranger '= 59
    untZeus '= 60
    untLina '= 61
    untShadow_Shaman '= 62
    untTinker '= 63
    untNatures_Prophet '= 64
    untEnchantress '= 65
    untJakiro '= 66
    untChen '= 67
    untSilencer '= 68
    untOgre_Magi '= 69
    untRubick '= 70
    untDisruptor '= 71
    untKeeper_of_the_Light '= 72
    untSkywrath_Mage '= 73
    untAxe '= 74
    untPudge '= 75
    untSand_King '= 76
    untSlardar '= 77
    untTidehunter '= 78
    untWraith_King '= 79
    untLifestealer '= 80
    untNight_Stalker '= 81
    untDoom '= 82
    untSpirit_Breaker '= 83
    untLycan '= 84
    untChaos_Knight '= 85
    untUndying '= 86
    untMagnus '= 87
    untAbaddon '= 88
    untBloodseeker '= 89
    untShadow_Fiend '= 90
    untRazor '= 91
    untVenomancer '= 92
    untFaceless_Void ' = 93
    untPhantom_Assassin '= 94
    untViper '= 95
    untClinkz '= 96
    untBroodmother '= 97
    untWeaver '= 98
    untSpectre '= 99
  untMeepo '= 100
  untMeepo_Clone
    untNyx_Assassin '= 101
    untSlark '= 102
    untMedusa '= 103
    untTerrorblade '= 104
    untBane '= 105
    untLich '= 106
    untLion '= 107
    untWitch_Doctor '= 108
    untEnigma '= 109
    untNecrophos '= 110
    untWarlock '= 111
    untQueen_of_Pain '= 112
    untDeath_Prophet '= 113
    untPugna '= 114
    untDazzle '= 115
    untLeshrac '= 116
    untDark_Seer '= 117
    untBatrider '= 118
    untAncient_Apparition '= 119
    untInvoker '= 120
    untOutworld_Devourer '= 121
    untShadow_Demon '= 122
    untVisage '= 123

    untT1Tower '= 124
    untT2Tower '= 125
    untT3Tower '= 126
    untT4Tower '= 127
    untRangeRax '= 128
    untMeleeRax '= 129
    untBufferbuilding '= 130
    untAncient '= 131
    untFountain '= 143
    'http://dota2.gamepedia.com/Creeps
    untRoshan '= 144

    untMeleeCreep '= 145
    untMegaMeleeCreep '= 146
    untMegaMeleeCreepBonus '= 147
    untRangeCreep '= 148
    untMegaRangeCreep '= 149
    untMegaRangeCreepBonus '= 150
    untSiegeCreep '= 151
    untSiegeCreepBonus '= 152

    untSmKoboldCamp '= 153
    untSmHillTrollCamp '= 154
    untSmHillTrollKoboldCamp '= 155
    untSmVhouldCamp '= 156
    untSmGhostCamp '= 157
    untSmHarpyCamp '= 158

    untMedCentaurCamp '= 159
    untMedWolfCamp '= 160
    untMedSatyrCamp '= 161
    untMedOgreCamp '= 162
    untMedGolemCamp '= 163

    untLrgDragonCamp '= 164
    untLrgGolemCamp '= 165
    untLrgThunderCamp '= 166

  untSelf '= 167

  untNaga_Siren_Illusion
  untDragonKnight_Elder_Dragon_Form
  untMorphling_Replicant
  untTerrorblade_Reflection
  untTerrorblade_Illusion
  untTerrorblade_Demon

    'Abilities---------------------------------------
    abStat_Gain

    abAftershock
    abEcho_Slam
    abEnchant_Totem
    abFissure
    abGods_Strength
    abGreat_Cleave
    abStorm_Hammer
    abWarcry
    abAvalanche
    abCraggy_Exterior
    abGrow
    abToss
    abGhostship
    abKunkkaReturn
    abTidebringer
    abTorrent
    abX_Marks_The_Spot
    abCall_Of_The_Wild
    abInner_Beast
    abPrimal_Roar
    abWild_Axes
    abBreathe_Fire
    abDragon_Blood
    abDragon_Tail
    abElder_Dragon_Form
    abBattery_Assault
    abHookshot
    abPower_Cogs
    abRocket_Flare
    abDegen_Aura
    abGuardian_Angel
    abPurification
    abRepel
    abBerserkers_Blood
    abBurning_Spear
    abInner_Vitality
    abLife_Break
    abAcid_Spray
    abChemical_Rage
    abGreevils_Greed
    abUnstable_Concoction
    abUnstable_Concoction_Throw
    abDrunken_Brawler
    abDrunken_Haze
    abPrimal_Split
    abThunder_Clap
    abLeech_Seed
    abLiving_Armor
    abNatures_Guise
    abOvergrowth
    abBreak_Tether
    abOvercharge
    abRelocate
    abSpirits
    abSpirits_In
    abSpirits_Out
    abTether
    abDouble_Edge
    abHoof_Stomp
    abCentaurReturn
    abStampede
    abChakram
    abReactive_Armor
    abTimber_Chain
    abWhirling_Death
    abBristleback
    abQuill_Spray
    abViscous_Nasal
    abWarpath
    abFrozen_Sigil
    abIce_Shards
    abLaunch_Snowball
    abSnowball
    abWalrus_Punch
    abAstral_Spirit
    abEarth_Splitter
    abEcho_Stomp
    abNatural_Order
    abReturn_Astral_Spirit
    abDuel
    abMoment_Of_Courage
    abOverwhelming_Odds
    abPress_The_Attack
    abBoulder_Smash
    abGeomagnetic_Grip
    abMagnetize
    abRolling_Boulder
    abStone_Remnant
    abFire_Spirits
    abIcarus_Dive
    abLaunch_Fire_Spirit
    abStop_Icarus_Dive
    abStop_Sun_Ray
    abSun_Ray
    abSupernova
    abToggle_Movement
    abAnti_Mage_Blink
    abMana_Break
    abMana_Void
    abSpell_Shield
    abFrost_Arrows
    abGust
    abMarksmanship
    abPrecision_Aura
    abBlade_Dance
    abBlade_Fury
    abHealing_Ward
    abOmnislash
    abLeap
    abMoonlight_Shadow
    abSacred_Arrow
    abStarstorm
    abAdaptive_Strike
    abMorph_Agility_Gain
    abMorph_Strength_Gain
    abMorph_Replicate
    abReplicate
    abWaveform
    abDoppelwalk
    abJuxtapose
    abPhantom_Edge
    abSpirit_Lance
    abMagic_Missile
    abNether_Swap
    abVengeance_Aura
    abWave_Of_Terror
    abBackstab
    abBlink_Strike
    abPermanent_Invisibility
    abSmoke_Screen
    abAssassinate
    abHeadshot
    abShrapnel
    abTake_Aim
    abMeld
    abPsi_Blades
    abPsionic_Trap
    abRefraction
    abTrap
    abEclipse
    abLucent_Beam
    abLunar_Blessing
    abMoon_Glaive
    abJinada
    abShadow_Walk
    abShuriken_Toss
    abTrack
    abEarthshock
    abEnrage
    abFury_Swipes
    abOverpower
    abCall_Down
    abFlak_Cannon
    abHoming_Missile
    abRocket_Barrage
    abBattle_Cry
    abDruid_Form
    abRabid
    abSummon_Spirit_Bear
    abSynergy
    abTrue_Form
    abEnsnare
    abMirror_Image
    abRip_Tide
    abSong_Of_The_Siren
    abSong_Of_The_Siren_Cancel
    abBattle_Trance
    abBerserkers_Rage
    abFervor
    abWhirling_Axes__Melee
  'abWhirling_Axes__Ranged
  'abActivate_Fire_Remnant
    abFire_Remnant
    abFlame_Guard
    abSearing_Chains
    abSleight_Of_Fist
    abArcane_Aura
    abCrystal_Nova
    abFreezing_Field
    abFrostbite
    abDream_Coil
  'abEthereal_Jaunt
    abIllusory_Orb
    abPhase_Shift
    abWaning_Rift
    abBall_Lightning
    abElectric_Vortex
    abOverload
    abStatic_Remnant
    abFocus_Fire
    abPowershot
    abShackleshot
    abWindrun
    abArc_Lightning
    abLightning_Bolt
    abStatic_Field
    abThundergods_Wrath
    abDragon_Slave
    abFiery_Soul
    abLaguna_Blade
    abLight_Strike_Array
    abEther_Shock
    abShadow_Shaman_Hex
    abMass_Serpent_Ward
    abShackles
    abHeatSeeking_Missile
    abLaser
    abMarch_Of_The_Machines
    abRearm
    abNatures_Call
    abSprout
    abTeleportation
    abWrath_Of_Nature
    abEnchant
    abImpetus
    abNatures_Attendants
    abUntouchable
    abDual_Breath
    abIce_Path
    abLiquid_Fire
    abMacropyre
    abHand_Of_God
    abHoly_Persuasion
    abPenitence
    abTest_Of_Faith
    abCurse_Of_The_Silent
    abGlaives_Of_Wisdom
    abGlobal_Silence
    abLast_Word
    abBloodlust
    abFireblast
    abIgnite
    abMulticast
  '  abUnrefined_Fireblast
    abFade_Bolt
    abNull_Field
    abSpell_Steal
    abTelekinesis
    abTelekinesis_Land
    abGlimpse
    abKinetic_Field
    abStatic_Storm
    abThunder_Strike
  'abBlinding_Light
    abChakra_Magic
    abIlluminate
    abMana_Leak
  'abRecall
    abRelease_Illuminate
    abSpirit_Form
    abAncient_Seal
    abArcane_Bolt
    abConcussive_Shot
    abMystic_Flare
    abBattle_Hunger
    abBerserkers_Call
    abCounter_Helix
    abCulling_Blade
    abDismember
    abFlesh_Heap
    abMeat_Hook
    abRot
    abBurrowstrike
    abCaustic_Finale
    abEpicenter
    abSand_Storm
    abAmplify_Damage
    abBash
    abSlithereen_Crush
    abSprint
    abAnchor_Smash
    abGush
    abKraken_Shell
    abRavage
    abMortal_Strike
    abReincarnation
    abVampiric_Aura
    abWraithfire_Blast
  'abConsume
    abFeast
    abInfest
    abOpen_Wounds
    abRage
    abCrippling_Fear
    abDarkness
    abHunter_In_The_Night
    abVoid
    abDevour
    abDoom
    abLvl_Death
    abScorched_Earth
    abCharge_Of_Darkness
    abEmpowering_Haste
    abGreater_Bash
    abNether_Strike
    abFeral_Impulse
    abHowl
    abShapeshift
    abSummon_Wolves
    abChaos_Bolt
    abChaos_Strike
    abPhantasm
    abReality_Rift
    abDecay
    abFlesh_Golem
    abSoul_Rip
    abTombstone
    abEmpower
    abReverse_Polarity
    abShockwave
    abSkewer
    abAphotic_Shield
    abBorrowed_Time
    abCurse_Of_Avernus
    abMist_Coil
    abBlood_Bath
    abBloodrage
    abRupture
    abThirst
    abNecromastery
    abPresence_Of_The_Dark_Lord
    abRequiem_Of_Souls
    abShadowraze
    abEye_Of_The_Storm
    abPlasma_Field
    abStatic_Link
    abUnstable_Current
    abPlague_Ward
    abPoison_Nova
    abPoison_Sting
    abVenomous_Gale
    abBacktrack
    abChronosphere
    abTime_Lock
    abTime_Walk
    abBlur
    abCoup_De_Grace
    abPhantom_Strike
    abStifling_Dagger
    abCorrosive_Skin
    abNethertoxin
    abPoison_Attack
    abViper_Strike
    abDeath_Pact
    abSearing_Arrows
    abSkeleton_Walk
    abStrafe
    abIncapacitating_Bite
    abInsatiable_Hunger
  abSpawn_Spiderlings
  abSpiderling_Spawn_Spiderite
    abSpin_Web
    abGeminate_Attack
    abShukuchi
    abThe_Swarm
    abTime_Lapse
    abDesolate
    abDispersion
    abHaunt
  'abReality
    abSpectral_Dagger
    abDivided_We_Stand
    abEarthbind
    abGeostrike
    abPoof
    abImpale
    abMana_Burn
    abSpiked_Carapace
    abVendetta
    abDark_Pact
    abEssence_Shift
    abPounce
    abShadow_Dance
    abMana_Shield
    abMystic_Snake
    abSplit_Shot
    abStone_Gaze
    abConjure_Image
    abMetamorphosis
    abReflection
    abSunder
    abBrain_Sap
    abEnfeeble
    abFiends_Grip
    abNightmare
    abNightmare_End
    abChain_Frost
    abFrost_Blast
    abIce_Armor
    abSacrifice
    abEarth_Spike
    abFinger_Of_Death
    abLion_Hex
    abMana_Drain
    abDeath_Ward
    abMaledict
    abParalyzing_Cask
    abVoodoo_Restoration
    abBlack_Hole
    abDemonic_Conversion
    abMalefice
    abMidnight_Pulse
    abDeath_Pulse
    abHeartstopper_Aura
    abReapers_Scythe
    abSadist
    abChaotic_Offering
    abFatal_Bonds
    abShadow_Word
    abUpheaval
    abQoP_Blink
    abScream_Of_Pain
    abShadow_Strike
    abSonic_Wave
    abCrypt_Swarm
    abExorcism
    abSilence
    abWitchcraft
    abDecrepify
    abLife_Drain
    abNether_Blast
    abNether_Ward
    abPoison_Touch
    abShadow_Wave
    abShallow_Grave
    abWeave
    abDiabolic_Edict
    abLightning_Storm
    abPulse_Nova
    abSplit_Earth
    abIon_Shell
    abSurge
    abVacuum
    abWall_Of_Replica
    abFirefly
    abFlamebreak
    abFlaming_Lasso
    abSticky_Napalm
    abChilling_Touch
    abCold_Feet
    abIce_Blast
    abIce_Vortex
  'abRelease
    abChaos_Meteor
    abCold_Snap
    abDeafening_Blast
    abEmp
    abExort
    abForge_Spirit
    abGhost_Walk
    abIce_Wall
    abInvoke
    abQuas
    abSun_Strike
    abTornado
    abWex
    abArcane_Orb
    abAstral_Imprisonment
    abEssence_Aura
    abSanitys_Eclipse
    abDemonic_Purge
    abDisruption
    abShadow_Poison
  'abShadow_Poison_Release
    abSoul_Catcher
    abGrave_Chill
    abGravekeepers_Cloak
    abSoul_Assumption
    abSummon_Familiars
  abLand_Mines
  abStasis_Trap
  abRemote_Mines
  abDark_Troll_Summoner_Raise_Dead

  abAlpha_Wolf_Critical_Strike
  abAlpha_Wolf_Packleaders_Aura
  abAncient_Black_Dragon_Spell_Immunity
  abAncient_Black_Dragon_Splash_Attack
  abAncient_Granite_Golem_Granite_Aura
  abAncient_Granite_Golem_Spell_Immunity
  abAncient_Rock_Golem_Spell_Immunity
  abAncient_Rumblehide_Spell_Immunity
  abAncient_Thunderhide_Frenzy
  abAncient_Thunderhide_Slam
  abAncient_Thunderhide_Spell_Immunity
  abBlood_Rite
  abBoar_Poison
  abBuilding_Back_Door_Protection
  abBuilding_Glyph_Of_Fortification
  abCentaur_Congeror_War_Stomp
  abDark_Troll_Summoner_Ensnare
  abEarth_Brewmaster_Hurl_Boulder
  abEarth_Brewmaster_Pulverize
  abEarth_Brewmaster_Spell_Immunity
  abEarth_Brewmaster_Thunder_Clap
  abFamiliar_Spell_Immunity
  abFamiliar_Stone_Form
  abFire_Brewmaster_Drunken_Brawler
  abFire_Brewmaster_Permanent_Immolation
  abForged_Spirit_Melting_Strike
  abGhost_Frost_Attack
  abGiant_Wolf_Critical_Strike
  abGolem_Warlock_Flaming_Fists
  abGolem_Warlock_Permanent_immolation
  abHarpy_Stormcrafter_Chain_Lightning
  abHawk_Invisibility
  abHellbear_Smasher_Swiftness_Aura
  abHellbear_Smasher_Thunder_Clap
  abHill_Troll_Priest_Heal
  abHill_Troll_Priest_Mana_Aura
  abAlacrity
  abKobold_Foreman_Speed_Aura
  abLycan_Wolf_Critical_Strike
  abLycan_Wolf_Invisibility
  abMud_Golem_Spell_Immunity
  abNecro_Archer_Archer_Aura
  abNecro_Archer_Mana_Burn
  abNecro_Warrior_Last_Will
  abNecro_Warrior_Mana_Break
  abNecro_Warrior_True_Sight
  abOgre_Frostmage_Ice_Armor
  abDoppelganger
  abPhantom_Rush
  abRemote_Mines_Pinpoint_Detonate
  abRoshan_Slam
  abRoshan_Spell_Block
  abRoshan_Strength_Of_The_Immortal
  abSatyr_Banisher_Purge
  abSatyr_Mindstealer_Mana_Burn
  abSpiderling_Poison_Sting
  abSpirit_Bear_Demolish
  abSpirit_Bear_Entangling_Claws
  abSpirit_Bear_Return
  abStorm_Brewmaster_Cyclone
  abStorm_Brewmaster_Dispel_Magic
  abStorm_Brewmaster_Drunken_Haze
  abStorm_Brewmaster_Wind_Walk
  abSuicide_Squad_Attack
  abTornado_Tempest
  abEyes_In_The_Forest
  abUndying_Zombie_Deathlust
  abUndying_Zombie_Spell_Immunity
  abVhoul_Assassin_Envenomed_Weapon
  abWildwing_Ripper_Tornado
  abWildwing_Ripper_Toughness_Aura

  'controls
  ctrlAbilityThumb
  ctrlAbility_Thumb_Picker
  ctrlCreep_Badge
  ctrlHero_Badge
  ctrlIconStatLabel
  ctrlBarGraph
  ctrlHero_Thumb
  ctrlItem_Thumb
  ctrlItem_Thumb_Picker_3
  ctrlLabel
  ctrlBar
  ctrlTeamvTeamDetails
  ctrlTeam_Details
  ctrlHerovHeroDetails
  ctrlHero_Details
  ctrlAbility_Details
  ctrlItem_Detials
  ctrlModifier_Details
  ctrlStat_Details

  'pages
  pgTeamvsTeam

  'objects
  Modifier
  Build
  Hero
  Pet
  Pet_Stack
  Pet_Instance
  Pet_Bundle
  GameVersion
  Creep_Instance
  Creep_Stack
  Creepbundle
  Herobundle
  ItemDatabase
  ControlsDatabase
  ImageDatabase
  Pagehandler
  Hero_Instance
  Ability_Info
  Item_Info
  Creep_Info
  Stat
  Team
  Game
  GameEntity_Tuple
  End Enum
