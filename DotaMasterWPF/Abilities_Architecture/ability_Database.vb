Public Class ability_Database
  Private mFriendlyNames As New Dictionary(Of eAbilityName, String)
  Private mLog As iLogging
  Private mAbilityInstances As New Dictionary(Of String, Ability_Info) 'Gui, Ability_info
  Private mAbilitiesByEAbilityName As OneToOneDoubleDictionary(Of eAbilityName, iAbility)
  Private dbNames As FriendlyName_Database
#Region "Ability Classes"


  Private _abAftershock As abAftershock 'Aftershock
  Private _abEcho_Slam As abEcho_Slam 'Echo Slam
  Private _abEnchant_Totem As abEnchant_Totem 'Enchant Totem
  Private _abFissure As abFissure 'Fissure
  Private _abGods_Strength As abGods_Strength 'God's Strength
  Private _abGreat_Cleave As abGreat_Cleave 'Great Cleave
  Private _abStorm_Hammer As abStorm_Hammer 'Storm Hammer
  Private _abWarcry As abWarcry 'Warcry
  Private _abAvalanche As abAvalanche 'Avalanche
  Private _abCraggy_Exterior As abCraggy_Exterior 'Craggy Exterior
  Private _abGrow As abGrow 'Grow
  Private _abToss As abToss 'Toss
  Private _abGhostship As abGhostship 'Ghostship
  ' Private _abKunkka_Return As abKunkka_Return 'Return
  Private _abTidebringer As abTidebringer 'Tidebringer
  Private _abTorrent As abTorrent 'Torrent
  Private _abX_Marks_The_Spot As abX_Marks_The_Spot 'X Marks the Spot
  Private _abCall_Of_The_Wild As abCall_Of_The_Wild 'Call of the Wild
  Private _abInner_Beast As abInner_Beast 'Inner Beast
  Private _abPrimal_Roar As abPrimal_Roar 'Primal Roar
  Private _abWild_Axes As abWild_Axes 'Wild Axes
  Private _abBreathe_Fire As abBreathe_Fire 'Breathe Fire
  Private _abDragon_Blood As abDragon_Blood 'Dragon Blood
  Private _abDragon_Tail As abDragon_Tail 'Dragon Tail
  Private _abElder_Dragon_Form As abElder_Dragon_Form 'Elder Dragon Form
  Private _abBattery_Assault As abBattery_Assault 'Battery Assault
  Private _abHookshot As abHookshot 'Hookshot
  Private _abPower_Cogs As abPower_Cogs 'Power Cogs
  Private _abRocket_Flare As abRocket_Flare 'Rocket Flare
  Private _abDegen_Aura As abDegen_Aura 'Degen Aura
  Private _abGuardian_Angel As abGuardian_Angel 'Guardian Angel
  Private _abPurification As abPurification 'Purification
  Private _abRepel As abRepel 'Repel
  Private _abBerserkers_Blood As abBerserkers_Blood 'Berserker's Blood
  Private _abBurning_Spear As abBurning_Spear 'Burning Spear
  Private _abInner_Vitality As abInner_Vitality 'Inner Vitality
  Private _abLife_Break As abLife_Break 'Life Break
  Private _abAcid_Spray As abAcid_Spray 'Acid Spray
  Private _abChemical_Rage As abChemical_Rage 'Chemical Rage
  Private _abGreevils_Greed As abGreevils_Greed 'Greevil's Greed
  Private _abUnstable_Concoction As abUnstable_Concoction 'Unstable Concoction
  'Private _abUnstable_Concoction_Throw As abUnstable_Concoction_Throw 'Unstable Concoction Throw
  Private _abDrunken_Brawler As abDrunken_Brawler 'Drunken Brawler
  Private _abDrunken_Haze As abDrunken_Haze 'Drunken Haze
  Private _abPrimal_Split As abPrimal_Split 'Primal Split
  Private _abThunder_Clap As abThunder_Clap 'Thunder Clap
  Private _abLeech_Seed As abLeech_Seed 'Leech Seed
  Private _abLiving_Armor As abLiving_Armor 'Living Armor
  Private _abNatures_Guise As abNatures_Guise 'Nature's Guise
  Private _abOvergrowth As abOvergrowth 'Overgrowth
  Private _abEyes_In_The_Forest As abTreant_Protector_Eyes_In_The_Forest
  ' Private _abBreak_Tether As abBreak_Tether 'Break Tether
  Private _abOvercharge As abOvercharge 'Overcharge
  Private _abRelocate As abRelocate 'Relocate
  Private _abSpirits As abSpirits 'Spirits
  Private _abSpirit_Bear_Return As abSpirit_Bear_Return
  Private _abSpirit_Bear_Demolish As abSpirit_Bear_Demolish
  Private _abSpirit_Bear_Entangling_Claws As abSpirit_Bear_Entangling_Claws
  'Private _abSpirits_In As abSpirits_In 'Spirits In
  'Private _abSpirits_Out As abSpirits_Out 'Spirits Out
  Private _abTether As abTether 'Tether
  Private _abDouble_Edge As abDouble_Edge 'Double Edge
  Private _abHoof_Stomp As abHoof_Stomp 'Hoof Stomp
  Private _abCentaurReturn As abCentaurReturn 'Return
  Private _abStampede As abStampede 'Stampede
  Private _abChakram As abChakram 'Chakram
  Private _abReactive_Armor As abReactive_Armor 'Reactive Armor
  ' Private _abReturn_Chakram As abReturn_Chakram 'Return Chakram
  Private _abTimber_Chain As abTimber_Chain 'Timber Chain
  Private _abWhirling_Death As abWhirling_Death 'Whirling Death
  Private _abBristleback As abBristleback 'Bristleback
  Private _abQuill_Spray As abQuill_Spray 'Quill Spray
  Private _abViscous_Nasal As abViscous_Nasal 'Viscous Nasal Goo
  Private _abWarpath As abWarpath 'Warpath
  Private _abFrozen_Sigil As abFrozen_Sigil 'Frozen Sigil
  Private _abIce_Shards As abIce_Shards 'Ice Shards
  ' Private _abLaunch_Snowball As abLaunch_Snowball 'Launch Snowball
  Private _abSnowball As abSnowball 'Snowball
  Private _abWalrus_Punch As abWalrus_Punch 'Walrus PUNCH!
  Private _abAstral_Spirit As abAstral_Spirit 'Astral Spirit
  Private _abEarth_Splitter As abEarth_Splitter 'Earth Splitter
  Private _abEcho_Stomp As abEcho_Stomp 'Echo Stomp
  Private _abNatural_Order As abNatural_Order 'Natural Order
  'Private _abReturn_Astral_Spirit As abReturn_Astral_Spirit 'Return Astral Spirit
  Private _abDuel As abDuel 'Duel
  Private _abMoment_Of_Courage As abMoment_Of_Courage 'Moment of Courage
  Private _abOverwhelming_Odds As abOverwhelming_Odds 'Overwhelming Odds
  Private _abPress_The_Attack As abPress_The_Attack 'Press The Attack
  Private _abBoulder_Smash As abBoulder_Smash 'Boulder Smash
  Private _abGeomagnetic_Grip As abGeomagnetic_Grip 'Geomagnetic Grip
  Private _abMagnetize As abMagnetize 'Magnetize
  Private _abRolling_Boulder As abRolling_Boulder 'Rolling Boulder
  'Private _abStone_Remnant As abStone_Remnant 'Stone Remnant
  Private _abFire_Spirits As abFire_Spirits 'Fire Spirits
  Private _abIcarus_Dive As abIcarus_Dive 'Icarus Dive
  ' Private _abLaunch_Fire_Spirit As abLaunch_Fire_Spirit 'Launch Fire Spirit
  ' Private _abStop_Icarus_Dive As abStop_Icarus_Dive 'Stop Icarus Dive
  'Private _abStop_Sun_Ray As abStop_Sun_Ray 'Stop Sun Ray
  Private _abSun_Ray As abSun_Ray 'Sun Ray
  Private _abSupernova As abSupernova 'Supernova
  'Private _abToggle_Movement As abToggle_Movement 'Toggle Movement
  Private _abAnti_Mage_Blink As abAnti_Mage_Blink 'Blink
  Private _abMana_Break As abMana_Break 'Mana Break
  Private _abMana_Void As abMana_Void 'Mana Void
  Private _abSpell_Shield As abSpell_Shield 'Spell Shield
  Private _abFrost_Arrows As abFrost_Arrows 'Frost Arrows
  Private _abGust As abGust 'Gust
  Private _abMarksmanship As abMarksmanship 'Marksmanship
  Private _abPrecision_Aura As abPrecision_Aura 'Precision Aura
  Private _abBlade_Dance As abBlade_Dance 'Blade Dance
  Private _abBlade_Fury As abBlade_Fury 'Blade Fury
  Private _abHealing_Ward As abHealing_Ward 'Healing Ward
  Private _abOmnislash As abOmnislash 'Omnislash
  Private _abLeap As abLeap 'Leap
  Private _abMoonlight_Shadow As abMoonlight_Shadow 'Moonlight Shadow
  Private _abSacred_Arrow As abSacred_Arrow 'Sacred Arrow
  Private _abStarstorm As abStarstorm 'Starstorm
  Private _abAdaptive_Strike As abAdaptive_Strike 'Adaptive Strike
  Private _abMorph__Agility_Gain As abMorph__Agility_Gain 'Morph (Agility Gain)
  'Private _abMorph_Strength_Gain As abMorph_Strength_Gain 'Morph (Strength Gain)
  Private _abMorph_Replicate As abMorph_Replicate 'Morph Replicate
  'Private _abReplicate As abReplicate 'Replicate
  Private _abWaveform As abWaveform 'Waveform
  Private _abDoppelganger As abDoppelganger 'Doppelganger
  Private _abJuxtapose As abJuxtapose 'Juxtapose
  Private _abPhantom_Rush As abPhantom_Rush 'Phantom Edge
  Private _abSpirit_Lance As abSpirit_Lance 'Spirit Lance
  Private _abMagic_Missile As abMagic_Missile 'Magic Missile
  Private _abNether_Swap As abNether_Swap 'Nether Swap
  Private _abVengeance_Aura As abVengeance_Aura 'Vengeance Aura
  Private _abWave_Of_Terror As abWave_Of_Terror 'Wave of Terror
  Private _abBackstab As abBackstab 'Backstab
  Private _abBlink_Strike As abBlink_Strike 'Blink Strike
  Private _abPermanent_Invisibility As abPermanent_Invisibility 'Permanent Invisibility
  Private _abSmoke_Screen As abSmoke_Screen 'Smoke Screen
  Private _abAssassinate As abAssassinate 'Assassinate
  Private _abHeadshot As abHeadshot 'Headshot
  Private _abShrapnel As abShrapnel 'Shrapnel
  Private _abTake_Aim As abTake_Aim 'Take Aim
  Private _abMeld As abMeld 'Meld
  Private _abPsi_Blades As abPsi_Blades 'Psi Blades
  Private _abPsionic_Trap As abPsionic_Trap 'Psionic Trap
  Private _abRefraction As abRefraction 'Refraction
  'Private _abTrap As abTrap 'Trap
  Private _abEclipse As abEclipse 'Eclipse
  Private _abLucent_Beam As abLucent_Beam 'Lucent Beam
  Private _abLunar_Blessing As abLunar_Blessing 'Lunar Blessing
  Private _abMoon_Glaive As abMoon_Glaive 'Moon Glaive
  Private _abJinada As abJinada 'Jinada
  Private _abShadow_Walk As abShadow_Walk 'Shadow Walk
  Private _abShuriken_Toss As abShuriken_Toss 'Shuriken Toss
  Private _abTrack As abTrack 'Track
  Private _abEarthshock As abEarthshock 'Earthshock
  Private _abEnrage As abEnrage 'Enrage
  Private _abFury_Swipes As abFury_Swipes 'Fury Swipes
  Private _abOverpower As abOverpower 'Overpower
  Private _abCall_Down As abCall_Down 'Call Down
  Private _abFlak_Cannon As abFlak_Cannon 'Flak Cannon
  Private _abHoming_Missile As abHoming_Missile 'Homing Missile
  Private _abRocket_Barrage As abRocket_Barrage 'Rocket Barrage
  Private _abBattle_Cry As abBattle_Cry 'Battle Cry
  ' Private _abDruid_Form As abDruid_Form 'Druid Form
  Private _abRabid As abRabid 'Rabid
  Private _abSummon_Spirit_Bear As abSummon_Spirit_Bear 'Summon Spirit Bear
  Private _abSynergy As abSynergy 'Synergy
  Private _abTrue_Form As abTrue_Form 'True Form
  Private _abEnsnare As abEnsnare 'Ensnare
  Private _abMirror_Image As abMirror_Image 'Mirror Image
  Private _abRip_Tide As abRip_Tide 'Rip Tide
  Private _abSong_Of_The_Siren As abSong_Of_The_Siren 'Song of the Siren
  ' Private _abSong_Of_The_Siren_Cancel As abSong_Of_The_Siren_Cancel 'Song of the Siren Cancel
  Private _abBattle_Trance As abBattle_Trance 'Battle Trance
  Private _abBerserkers_Rage As abBerserkers_Rage 'Berserker's Rage
  Private _abFervor As abFervor 'Fervor
  Private _abWhirling_Axes__Melee As abWhirling_Axes__Melee 'Whirling Axes (Melee)
  'Private _abWhirling_Axes__Ranged As abWhirling_Axes__Ranged 'Whirling Axes (Ranged)
  'Private _abActivate_Fire_Remnant As abActivate_Fire_Remnant 'Activate Fire Remnant
  Private _abFire_Remnant As abFire_Remnant 'Fire Remnant
  Private _abFlame_Guard As abFlame_Guard 'Flame Guard
  Private _abSearing_Chains As abSearing_Chains 'Searing Chains
  Private _abSleight_Of_Fist As abSleight_Of_Fist 'Sleight of Fist
  Private _abArcane_Aura As abArcane_Aura 'Arcane Aura
  Private _abCrystal_Nova As abCrystal_Nova 'Crystal Nova
  Private _abFreezing_Field As abFreezing_Field 'Freezing Field
  Private _abFrostbite As abFrostbite 'Frostbite
  Private _abDream_Coil As abDream_Coil 'Dream Coil
  'Private _abEthereal_Jaunt As abEthereal_Jaunt 'Ethereal Jaunt
  Private _abIllusory_Orb As abIllusory_Orb 'Illusory Orb
  Private _abPhase_Shift As abPhase_Shift 'Phase Shift
  Private _abWaning_Rift As abWaning_Rift 'Waning Rift
  Private _abBall_Lightning As abBall_Lightning 'Ball Lightning
  Private _abElectric_Vortex As abElectric_Vortex 'Electric Vortex
  Private _abOverload As abOverload 'Overload
  Private _abStatic_Remnant As abStatic_Remnant 'Static Remnant
  Private _abFocus_Fire As abFocus_Fire 'Focus Fire
  Private _abPowershot As abPowershot 'Powershot
  Private _abShackleshot As abShackleshot 'Shackleshot
  Private _abWindrun As abWindrun 'Windrun
  Private _abArc_Lightning As abArc_Lightning 'Arc Lightning
  Private _abLightning_Bolt As abLightning_Bolt 'Lightning Bolt
  Private _abStatic_Field As abStatic_Field 'Static Field
  Private _abThundergods_Wrath As abThundergods_Wrath 'Thundergod's Wrath
  Private _abDragon_Slave As abDragon_Slave 'Dragon Slave
  Private _abFiery_Soul As abFiery_Soul 'Fiery Soul
  Private _abLaguna_Blade As abLaguna_Blade 'Laguna Blade
  Private _abLight_Strike_Array As abLight_Strike_Array 'Light Strike Array
  Private _abEther_Shock As abEther_Shock 'Ether Shock
  Private _abShadow_Shaman_Hex As abShadow_Shaman_Hex 'Hex
  Private _abMass_Serpent_Ward As abMass_Serpent_Ward 'Mass Serpent Ward
  Private _abShackles As abShackles 'Shackles
  Private _abHeatSeeking_Missile As abHeatSeeking_Missile 'Heat-Seeking Missile
  Private _abLaser As abLaser 'Laser
  Private _abMarch_Of_The_Machines As abMarch_Of_The_Machines 'March of the Machines
  Private _abRearm As abRearm 'Rearm
  Private _abNatures_Call As abNatures_Call 'Nature's Call
  Private _abSprout As abSprout 'Sprout
  Private _abTeleportation As abTeleportation 'Teleportation
  Private _abWrath_Of_Nature As abWrath_Of_Nature 'Wrath of Nature
  Private _abEnchant As abEnchant 'Enchant
  Private _abImpetus As abImpetus 'Impetus
  Private _abNatures_Attendants As abNatures_Attendants 'Nature's Attendants
  Private _abUntouchable As abUntouchable 'Untouchable
  Private _abDual_Breath As abDual_Breath 'Dual Breath
  Private _abIce_Path As abIce_Path 'Ice Path
  Private _abLiquid_Fire As abLiquid_Fire 'Liquid Fire
  Private _abMacropyre As abMacropyre 'Macropyre
  Private _abHand_Of_God As abHand_Of_God 'Hand of God
  Private _abHoly_Persuasion As abHoly_Persuasion 'Holy Persuasion
  Private _abPenitence As abPenitence 'Penitence
  Private _abTest_Of_Faith As abTest_Of_Faith 'Test of Faith
  Private _abCurse_Of_The_Silent As abCurse_Of_The_Silent 'Curse of the Silent
  Private _abGlaives_Of_Wisdom As abGlaives_Of_Wisdom 'Glaives of Wisdom
  Private _abGlobal_Silence As abGlobal_Silence 'Global Silence
  Private _abLast_Word As abLast_Word 'Last Word
  Private _abBloodlust As abBloodlust 'Bloodlust
  Private _abFireblast As abFireblast 'Fireblast
  Private _abIgnite As abIgnite 'Ignite
  Private _abMulticast As abMulticast 'Multicast
  'Private _abUnrefined_Fireblast As abUnrefined_Fireblast 'Unrefined Fireblast
  Private _abFade_Bolt As abFade_Bolt 'Fade Bolt
  Private _abNull_Field As abNull_Field 'Null Field
  Private _abSpell_Steal As abSpell_Steal 'Spell Steal
  Private _abTelekinesis As abTelekinesis 'Telekinesis
  ' Private _abTelekinesis_Land As abTelekinesis_Land 'Telekinesis Land
  Private _abGlimpse As abGlimpse 'Glimpse
  Private _abKinetic_Field As abKinetic_Field 'Kinetic Field
  Private _abStatic_Storm As abStatic_Storm 'Static Storm
  Private _abThunder_Strike As abThunder_Strike 'Thunder Strike
  'Private _abBlinding_Light As abBlinding_Light 'Blinding Light
  Private _abChakra_Magic As abChakra_Magic 'Chakra Magic
  Private _abIlluminate As abIlluminate 'Illuminate
  Private _abMana_Leak As abMana_Leak 'Mana Leak
  'Private _abRecall As abRecall 'Recall
  'Private _abRelease_Illuminate As abRelease_Illuminate 'Release Illuminate
  Private _abSpirit_Form As abSpirit_Form 'Spirit Form
  Private _abAncient_Seal As abAncient_Seal 'Ancient Seal
  Private _abArcane_Bolt As abArcane_Bolt 'Arcane Bolt
  Private _abConcussive_Shot As abConcussive_Shot 'Concussive Shot
  Private _abMystic_Flare As abMystic_Flare 'Mystic Flare
  'Private _abFocused_Detonate As abFocused_Detonate 'Focused Detonate
  Private _abLand_Mines As abLand_Mines 'Land Mines
  'Private _abMinefield_Sign As abMinefield_Sign 'Minefield Sign
  Private _abRemote_Mines As abRemote_Mines 'Remote Mines
  Private _abStasis_Trap As abStasis_Trap 'Stasis Trap
  Private _abSuicide_Squad_Attack As abSuicide_Squad_Attack 'Suicide Squad, Attack!
  Private _abBattle_Hunger As abBattle_Hunger 'Battle Hunger
  Private _abBerserkers_Call As abBerserkers_Call 'Berserker's Call
  Private _abCounter_Helix As abCounter_Helix 'Counter Helix
  Private _abCulling_Blade As abCulling_Blade 'Culling Blade
  Private _abDismember As abDismember 'Dismember
  Private _abFlesh_Heap As abFlesh_Heap 'Flesh Heap
  Private _abMeat_Hook As abMeat_Hook 'Meat Hook
  Private _abRot As abRot 'Rot
  Private _abBurrowstrike As abBurrowstrike 'Burrowstrike
  Private _abCaustic_Finale As abCaustic_Finale 'Caustic Finale
  Private _abEpicenter As abEpicenter 'Epicenter
  Private _abSand_Storm As abSand_Storm 'Sand Storm
  Private _abAmplify_Damage As abAmplify_Damage 'Amplify Damage
  Private _abBash As abBash 'Bash
  Private _abSlithereen_Crush As abSlithereen_Crush 'Slithereen Crush
  Private _abSprint As abSprint 'Sprint
  Private _abAnchor_Smash As abAnchor_Smash 'Anchor Smash
  Private _abGush As abGush 'Gush
  Private _abKraken_Shell As abKraken_Shell 'Kraken Shell
  Private _abRavage As abRavage 'Ravage
  Private _abMortal_Strike As abMortal_Strike 'Mortal Strike
  Private _abReincarnation As abReincarnation 'Reincarnation
  Private _abVampiric_Aura As abVampiric_Aura 'Vampiric Aura
  Private _abWraithfire_Blast As abWraithfire_Blast 'Wraithfire Blast
  'Private _abConsume As abConsume 'Consume
  Private _abFeast As abFeast 'Feast
  Private _abInfest As abInfest 'Infest
  Private _abOpen_Wounds As abOpen_Wounds 'Open Wounds
  Private _abRage As abRage 'Rage
  Private _abCrippling_Fear As abCrippling_Fear 'Crippling Fear
  Private _abDarkness As abDarkness 'Darkness
  Private _abHunter_In_The_Night As abHunter_In_The_Night 'Hunter in the Night
  Private _abVoid As abVoid 'Void
  Private _abDevour As abDevour 'Devour
  Private _abDoom As abDoom 'Doom
  Private _abLvl_Death As abLvl_Death 'LVL? Death
  Private _abScorched_Earth As abScorched_Earth 'Scorched Earth
  Private _abCharge_Of_Darkness As abCharge_Of_Darkness 'Charge of Darkness
  Private _abEmpowering_Haste As abEmpowering_Haste 'Empowering Haste
  Private _abGreater_Bash As abGreater_Bash 'Greater Bash
  Private _abNether_Strike As abNether_Strike 'Nether Strike
  Private _abFeral_Impulse As abFeral_Impulse 'Feral Impulse
  Private _abHowl As abHowl 'Howl
  Private _abShapeshift As abShapeshift 'Shapeshift
  Private _abSummon_Wolves As abSummon_Wolves 'Summon Wolves
  Private _abChaos_Bolt As abChaos_Bolt 'Chaos Bolt
  Private _abChaos_Strike As abChaos_Strike 'Chaos Strike
  Private _abPhantasm As abPhantasm 'Phantasm
  Private _abReality_Rift As abReality_Rift 'Reality Rift
  Private _abDecay As abDecay 'Decay
  Private _abFlesh_Golem As abFlesh_Golem 'Flesh Golem
  Private _abSoul_Rip As abSoul_Rip 'Soul Rip
  Private _abTombstone As abTombstone 'Tombstone
  Private _abEmpower As abEmpower 'Empower
  Private _abReverse_Polarity As abReverse_Polarity 'Reverse Polarity
  Private _abShockwave As abShockwave 'Shockwave
  Private _abSkewer As abSkewer 'Skewer
  Private _abAphotic_Shield As abAphotic_Shield 'Aphotic Shield
  Private _abBorrowed_Time As abBorrowed_Time 'Borrowed Time
  Private _abCurse_Of_Avernus As abCurse_Of_Avernus 'Curse of Avernus
  Private _abMist_Coil As abMist_Coil 'Mist Coil
  Private _abBlood_Rite As abBlood_Rite 'Blood Rite
  Private _abBloodrage As abBloodrage 'Bloodrage
  Private _abRupture As abRupture 'Rupture
  Private _abThirst As abThirst 'Thirst
  Private _abNecromastery As abNecromastery 'Necromastery
  Private _abPresence_Of_The_Dark_Lord As abPresence_Of_The_Dark_Lord 'Presence of the Dark Lord
  Private _abRequiem_Of_Souls As abRequiem_Of_Souls 'Requiem of Souls
  Private _abShadowraze As abShadowraze 'Shadowraze
  Private _abEye_Of_The_Storm As abEye_Of_The_Storm 'Eye of the Storm
  Private _abPlasma_Field As abPlasma_Field 'Plasma Field
  Private _abStatic_Link As abStatic_Link 'Static Link
  Private _abUnstable_Current As abUnstable_Current 'Unstable Current
  Private _abPlague_Ward As abPlague_Ward 'Plague Ward
  Private _abPoison_Nova As abPoison_Nova 'Poison Nova
  Private _abPoison_Sting As abPoison_Sting 'Poison Sting
  Private _abVenomous_Gale As abVenomous_Gale 'Venomous Gale
  Private _abBacktrack As abBacktrack 'Backtrack
  Private _abChronosphere As abChronosphere 'Chronosphere
  Private _abTime_Lock As abTime_Lock 'Time Lock
  Private _abTime_Walk As abTime_Walk 'Time Walk
  Private _abBlur As abBlur 'Blur
  Private _abCoup_De_Grace As abCoup_De_Grace 'Coup de Grace
  Private _abPhantom_Strike As abPhantom_Strike 'Phantom Strike
  Private _abStifling_Dagger As abStifling_Dagger 'Stifling Dagger
  Private _abCorrosive_Skin As abCorrosive_Skin 'Corrosive Skin
  Private _abNethertoxin As abNethertoxin 'Nethertoxin
  Private _abPoison_Attack As abPoison_Attack 'Poison Attack
  Private _abViper_Strike As abViper_Strike 'Viper Strike
  Private _abDeath_Pact As abDeath_Pact 'Death Pact
  Private _abSearing_Arrows As abSearing_Arrows 'Searing Arrows
  Private _abSkeleton_Walk As abSkeleton_Walk 'Skeleton Walk
  Private _abStrafe As abStrafe 'Strafe
  Private _abIncapacitating_Bite As abIncapacitating_Bite 'Incapacitating Bite
  Private _abInsatiable_Hunger As abInsatiable_Hunger 'Insatiable Hunger
  Private _abSpawn_Spiderlings As abSpawn_Spiderlings 'Spawn Spiderlings
  Private _abSpin_Web As abSpin_Web 'Spin Web
  Private _abGeminate_Attack As abGeminate_Attack 'Geminate Attack
  Private _abShukuchi As abShukuchi 'Shukuchi
  Private _abThe_Swarm As abThe_Swarm 'The Swarm
  Private _abTime_Lapse As abTime_Lapse 'Time Lapse
  Private _abDesolate As abDesolate 'Desolate
  Private _abDispersion As abDispersion 'Dispersion
  Private _abHaunt As abHaunt 'Haunt
  'Private _abReality As abReality 'Reality
  Private _abSpectral_Dagger As abSpectral_Dagger 'Spectral Dagger
  Private _abDivided_We_Stand As abDivided_We_Stand 'Divided We Stand
  Private _abEarthbind As abEarthbind 'Earthbind
  Private _abGeostrike As abGeostrike 'Geostrike
  Private _abPoof As abPoof 'Poof
  Private _abImpale As abImpale 'Impale
  Private _abMana_Burn As abMana_Burn 'Mana Burn
  Private _abSpiked_Carapace As abSpiked_Carapace 'Spiked Carapace
  Private _abVendetta As abVendetta 'Vendetta
  Private _abDark_Pact As abDark_Pact 'Dark Pact
  Private _abEssence_Shift As abEssence_Shift 'Essence Shift
  Private _abPounce As abPounce 'Pounce
  Private _abShadow_Dance As abShadow_Dance 'Shadow Dance
  Private _abMana_Shield As abMana_Shield 'Mana Shield
  Private _abMystic_Snake As abMystic_Snake 'Mystic Snake
  Private _abSplit_Shot As abSplit_Shot 'Split Shot
  Private _abStone_Gaze As abStone_Gaze 'Stone Gaze
  Private _abConjure_Image As abConjure_Image 'Conjure Image
  Private _abMetamorphosis As abMetamorphosis 'Metamorphosis
  Private _abReflection As abReflection 'Reflection
  Private _abSunder As abSunder 'Sunder
  Private _abBrain_Sap As abBrain_Sap 'Brain Sap
  Private _abEnfeeble As abEnfeeble 'Enfeeble
  Private _abFiends_Grip As abFiends_Grip 'Fiend's Grip
  Private _abNightmare As abNightmare 'Nightmare
  ' Private _abNightmare_End As abNightmare_End 'Nightmare End
  Private _abChain_Frost As abChain_Frost 'Chain Frost
  Private _abFrost_Blast As abFrost_Blast 'Frost Blast
  Private _abIce_Armor As abIce_Armor 'Ice Armor
  Private _abSacrifice As abSacrifice 'Sacrifice
  Private _abEarth_Spike As abEarth_Spike 'Earth Spike
  Private _abFinger_Of_Death As abFinger_Of_Death 'Finger of Death
  Private _abLion_Hex As abLion_Hex 'Hex
  Private _abMana_Drain As abMana_Drain 'Mana Drain
  Private _abDeath_Ward As abDeath_Ward 'Death Ward
  Private _abMaledict As abMaledict 'Maledict
  Private _abParalyzing_Cask As abParalyzing_Cask 'Paralyzing Cask
  Private _abVoodoo_Restoration As abVoodoo_Restoration 'Voodoo Restoration
  Private _abBlack_Hole As abBlack_Hole 'Black Hole
  Private _abDemonic_Conversion As abDemonic_Conversion 'Demonic Conversion
  Private _abMalefice As abMalefice 'Malefice
  Private _abMidnight_Pulse As abMidnight_Pulse 'Midnight Pulse
  Private _abDeath_Pulse As abDeath_Pulse 'Death Pulse
  Private _abHeartstopper_Aura As abHeartstopper_Aura 'Heartstopper Aura
  Private _abReapers_Scythe As abReapers_Scythe 'Reaper's Scythe
  Private _abSadist As abSadist 'Sadist
  Private _abChaotic_Offering As abChaotic_Offering 'Chaotic Offering
  Private _abFatal_Bonds As abFatal_Bonds 'Fatal Bonds
  Private _abShadow_Word As abShadow_Word 'Shadow Word
  Private _abUpheaval As abUpheaval 'Upheaval
  Private _abQoP_Blink As abQoP_Blink 'Blink
  Private _abScream_Of_Pain As abScream_Of_Pain 'Scream Of Pain
  Private _abShadow_Strike As abShadow_Strike 'Shadow Strike
  Private _abSonic_Wave As abSonic_Wave 'Sonic Wave
  Private _abCrypt_Swarm As abCrypt_Swarm 'Crypt Swarm
  Private _abExorcism As abExorcism 'Exorcism
  Private _abSilence As abSilence 'Silence
  Private _abWitchcraft As abWitchcraft 'Witchcraft
  Private _abDecrepify As abDecrepify 'Decrepify
  Private _abLife_Drain As abLife_Drain 'Life Drain
  Private _abNether_Blast As abNether_Blast 'Nether Blast
  Private _abNether_Ward As abNether_Ward 'Nether Ward
  Private _abPoison_Touch As abPoison_Touch 'Poison Touch
  Private _abShadow_Wave As abShadow_Wave 'Shadow Wave
  Private _abShallow_Grave As abShallow_Grave 'Shallow Grave
  Private _abWeave As abWeave 'Weave
  Private _abDiabolic_Edict As abDiabolic_Edict 'Diabolic Edict
  Private _abLightning_Storm As abLightning_Storm 'Lightning Storm
  Private _abPulse_Nova As abPulse_Nova 'Pulse Nova
  Private _abSplit_Earth As abSplit_Earth 'Split Earth
  Private _abIon_Shell As abIon_Shell 'Ion Shell
  Private _abSurge As abSurge 'Surge
  Private _abVacuum As abVacuum 'Vacuum
  Private _abWall_Of_Replica As abWall_Of_Replica 'Wall of Replica
  Private _abFirefly As abFirefly 'Firefly
  Private _abFlamebreak As abFlamebreak 'Flamebreak
  Private _abFlaming_Lasso As abFlaming_Lasso 'Flaming Lasso
  Private _abSticky_Napalm As abSticky_Napalm 'Sticky Napalm
  Private _abChilling_Touch As abChilling_Touch 'Chilling Touch
  Private _abCold_Feet As abCold_Feet 'Cold Feet
  Private _abIce_Blast As abIce_Blast 'Ice Blast
  Private _abIce_Vortex As abIce_Vortex 'Ice Vortex
  ' Private _abRelease As abRelease 'Release
  Private _abAlacrity As abAlacrity 'Alacrity
  Private _abChaos_Meteor As abChaos_Meteor 'Chaos Meteor
  Private _abCold_Snap As abCold_Snap 'Cold Snap
  Private _abDeafening_Blast As abDeafening_Blast 'Deafening Blast
  Private _abEmp As abEmp 'EMP
  Private _abExort As abExort 'Exort
  Private _abForge_Spirit As abForge_Spirit 'Forge Spirit
  Private _abGhost_Walk As abGhost_Walk 'Ghost Walk
  Private _abIce_Wall As abIce_Wall 'Ice Wall
  Private _abInvoke As abInvoke 'Invoke
  Private _abQuas As abQuas 'Quas
  Private _abSun_Strike As abSun_Strike 'Sun Strike
  Private _abTornado As abTornado 'Tornado
  Private _abWex As abWex 'Wex
  Private _abArcane_Orb As abArcane_Orb 'Arcane Orb
  Private _abAstral_Imprisonment As abAstral_Imprisonment 'Astral Imprisonment
  Private _abEssence_Aura As abEssence_Aura 'Essence Aura
  Private _abSanitys_Eclipse As abSanitys_Eclipse 'Sanity's Eclipse
  Private _abDemonic_Purge As abDemonic_Purge 'Demonic Purge
  Private _abDisruption As abDisruption 'Disruption
  Private _abShadow_Poison As abShadow_Poison 'Shadow Poison
  'Private _abShadow_Poison_Release As abShadow_Poison_Release 'Shadow Poison Release
  Private _abSoul_Catcher As abSoul_Catcher 'Soul Catcher
  Private _abGrave_Chill As abGrave_Chill 'Grave Chill
  Private _abGravekeepers_Cloak As abGravekeepers_Cloak 'Gravekeeper's Cloak
  Private _abSoul_Assumption As abSoul_Assumption 'Soul Assumption
  Private _abSummon_Familiars As abSummon_Familiars 'Summon Familiars

  Private _abSpiderling_Spawn_Spiderite As abSpiderling_Spawn_Spiderite
  Private _abSpiderling_Poison_Sting As abSpiderling_Poison_Sting
  Private _abLycan_Wolf_Critical_Strike As abLycan_Wolf_Critical_Strike
  Private _abLycan_Wolf_Invisibility As abLycan_Wolf_Invisibility
  Private _abStat_Gain As abStat_Gain
  Private _abPlague_Ward_Poison_Sting As abPlague_Ward_Poison_Sting
  Private _abRemote_Mines_Pinpoint_Detonate As abRemote_Mines_Pinpoint_Detonate

  Private _abGolem_Warlock_Permanent_immolation As abGolem_Warlock_Permanent_immolation
  Private _abGolem_Warlock_Flaming_Fists As abGolem_Warlock_Flaming_Fists
  Private _abFamiliar_Spell_Immunity As abFamiliar_Spell_Immunity
  Private _abFamiliar_Stone_Form As abFamiliar_Stone_Form

  Private _abNecro_Archer_Archer_Aura As abNecro_Archer_Archer_Aura
  Private _abNecro_Archer_Mana_Burn As abNecro_Archer_Mana_Burn
  Private _abNecro_Warrior_Last_Will As abNecro_Warrior_Last_Will
  Private _abNecro_Warrior_Mana_Break As abNecro_Warrior_Mana_Break
  Private _abNecro_Warrior_True_Sight As abNecro_Warrior_True_Sight

  Private _abBoar_Poison As abBoar_Poison
  Private _abHawk_Invisibility As abHawk_Invisibility

  Private _abFire_Brewmaster_Drunken_Brawler As abFire_Brewmaster_Drunken_Brawler
  Private _abFire_Brewmaster_Permanent_Immolation As abFire_Brewmaster_Permanent_Immolation
  Private _abEarth_Brewmaster_Hurl_Boulder As abEarth_Brewmaster_Hurl_Boulder
  Private _abEarth_Brewmaster_Pulverize As abEarth_Brewmaster_Pulverize
  Private _abEarth_Brewmaster_Spell_Immunity As abEarth_Brewmaster_Spell_Immunity
  Private _abEarth_Brewmaster_Thunder_Clap As abEarth_Brewmaster_Thunder_Clap
  Private _abStorm_Brewmaster_Cyclone As abStorm_Brewmaster_Cyclone
  Private _abStorm_Brewmaster_Dispel_Magic As abStorm_Brewmaster_Dispel_Magic
  Private _abStorm_Brewmaster_Drunken_Haze As abStorm_Brewmaster_Drunken_Haze
  Private _abStorm_Brewmaster_Wind_Walk As abStorm_Brewmaster_Wind_Walk


  Private _abPsionic_Trap_Self_Trap As abPsionic_Trap_Self_Trap

  Private _abUndying_Zombie_Deathlust As abUndying_Zombie_Deathlust
  Private _abUndying_Zombie_Spell_Immunity As abUndying_Zombie_Spell_Immunity


  Private _abTornado_Tempest As abTornado_Tempest

  Private _abForged_Spirit_Melting_Strike As abForged_Spirit_Melting_Strike

  Private _abKobold_Foreman_Speed_Aura As abKobold_Foreman_Speed_Aura

  Private _abHill_Troll_Priest_Heal As abHill_Troll_Priest_Heal
  Private _abHill_Troll_Priest_Mana_Aura As abHill_Troll_Priest_Mana_Aura

  Private _abVhoul_Assassin_Envenomed_Weapon As abVhoul_Assassin_Envenomed_Weapon

  Private _abGhost_Frost_Attack As abGhost_Frost_Attack

  Private _abHarpy_Stormcrafter_Chain_Lightning As abHarpy_Stormcrafter_Chain_Lightning

  Private _abCentaur_Congeror_War_Stomp As abCentaur_Congeror_War_Stomp

  Private _abGiant_Wolf_Critical_Strike As abGiant_Wolf_Critical_Strike

  Private _abAlpha_Wolf_Packleaders_Aura As abAlpha_Wolf_Packleaders_Aura
  Private _abAlpha_Wolf_Critical_Strike As abAlpha_Wolf_Critical_Strike

  Private _abSatyr_Banisher_Purge As abSatyr_Banisher_Purge
  Private _abSatyr_Mindstealer_Mana_Burn As abSatyr_Mindstealer_Mana_Burn
  Private _abOgre_Frostmage_Ice_Armor As abOgre_Frostmage_Ice_Armor
  Private _abMud_Golem_Spell_Immunity As abMud_Golem_Spell_Immunity
  Private _abSatyr_Tormentor_Shockwave As abSatyr_Tormentor_Shockwave
  Private _abHellbear_Smasher_Thunder_Clap As abHellbear_Smasher_Thunder_Clap
  Private _abHellbear_Smasher_Swiftness_Aura As abHellbear_Smasher_Swiftness_Aura
  Private _abWildwing_Ripper_Tornado As abWildwing_Ripper_Tornado
  Private _abWildwing_Ripper_Toughness_Aua As abWildwing_Ripper_Toughness_Aua
  Private _abDark_Troll_Summoner_Ensnare As abDark_Troll_Summoner_Ensnare
  Private _abDark_Troll_Summoner_Raise_Dead As abDark_Troll_Summoner_Raise_Dead
  Private _abAncient_Black_Dragon_Splash_Attack As abAncient_Black_Dragon_Splash_Attack
  Private _abAncient_Black_Dragon_Spell_Immunity As abAncient_Black_Dragon_Spell_Immunity
  Private _abAncient_Granite_Golem_Granite_Aura As abAncient_Granite_Golem_Granite_Aura
  Private _abAncient_Granite_Golem_Spell_Immunity As abAncient_Granite_Golem_Spell_Immunity
  Private _abAncient_Rock_Golem_Spell_Immunity As abAncient_Rock_Golem_Spell_Immunity
  Private _abAncient_Thunderhide_Slam As abAncient_Thunderhide_Slam
  Private _abAncient_Thunderhide_Frenzy As abAncient_Thunderhide_Frenzy
  Private _abAncient_Thunderhide_Spell_Immunity As abAncient_Thunderhide_Spell_Immunity
  Private _abAncient_Rumblehide_Spell_Immunity As abAncient_Rumblehide_Spell_Immunity
  Private _abRoshan_Spell_Block As abRoshan_Spell_Block
  Private _abRoshan_Bash As abRoshan_Bash
  Private _abRoshan_Slam As abRoshan_Slam
  Private _abRoshan_Strength_Of_The_Immortal As abRoshan_Strength_Of_The_Immortal
  Private _abBuilding_Backdoor_Protection As abBuilding_Backdoor_Protection
  Private _abBuilding_Glyph_of_Fortification As abBuilding_Glyph_of_Fortification

#End Region
  Public Sub New(log As iLogging, names As FriendlyName_Database)
    '  LoadFriendlyNames()
    mLog = log
    mAbilitiesByEAbilityName = New OneToOneDoubleDictionary(Of eAbilityName, iAbility)(mLog)
    dbNames = names
  End Sub

  Public Sub Load()
    _abAftershock = New abAftershock 'Aftershock
    _abEcho_Slam = New abEcho_Slam 'Echo Slam
    _abEnchant_Totem = New abEnchant_Totem 'Enchant Totem
    _abFissure = New abFissure 'Fissure
    _abGods_Strength = New abGods_Strength 'God's Strength
    _abGreat_Cleave = New abGreat_Cleave 'Great Cleave
    _abStorm_Hammer = New abStorm_Hammer 'Storm Hammer
    _abWarcry = New abWarcry 'Warcry
    _abAvalanche = New abAvalanche 'Avalanche
    _abCraggy_Exterior = New abCraggy_Exterior 'Craggy Exterior
    _abGrow = New abGrow 'Grow
    _abToss = New abToss 'Toss
    _abGhostship = New abGhostship 'Ghostship
    '_abKunkka_Return = New abKunkka_Return 'Return
    _abTidebringer = New abTidebringer 'Tidebringer
    _abTorrent = New abTorrent 'Torrent
    _abX_Marks_The_Spot = New abX_Marks_The_Spot 'X Marks the Spot
    _abCall_Of_The_Wild = New abCall_Of_The_Wild 'Call of the Wild
    _abInner_Beast = New abInner_Beast 'Inner Beast
    _abPrimal_Roar = New abPrimal_Roar 'Primal Roar
    _abWild_Axes = New abWild_Axes 'Wild Axes
    _abBreathe_Fire = New abBreathe_Fire 'Breathe Fire
    _abDragon_Blood = New abDragon_Blood 'Dragon Blood
    _abDragon_Tail = New abDragon_Tail 'Dragon Tail
    _abElder_Dragon_Form = New abElder_Dragon_Form 'Elder Dragon Form
    _abBattery_Assault = New abBattery_Assault 'Battery Assault
    _abHookshot = New abHookshot 'Hookshot
    _abPower_Cogs = New abPower_Cogs 'Power Cogs
    _abRocket_Flare = New abRocket_Flare 'Rocket Flare
    _abDegen_Aura = New abDegen_Aura 'Degen Aura
    _abGuardian_Angel = New abGuardian_Angel 'Guardian Angel
    _abPurification = New abPurification 'Purification
    _abRepel = New abRepel 'Repel
    _abBerserkers_Blood = New abBerserkers_Blood 'Berserker's Blood
    _abBurning_Spear = New abBurning_Spear 'Burning Spear
    _abInner_Vitality = New abInner_Vitality 'Inner Vitality
    _abLife_Break = New abLife_Break 'Life Break
    _abAcid_Spray = New abAcid_Spray 'Acid Spray
    _abChemical_Rage = New abChemical_Rage 'Chemical Rage
    _abGreevils_Greed = New abGreevils_Greed 'Greevil's Greed
    _abUnstable_Concoction = New abUnstable_Concoction 'Unstable Concoction
    '_abUnstable_Concoction_Throw = New abUnstable_Concoction_Throw 'Unstable Concoction Throw
    _abDrunken_Brawler = New abDrunken_Brawler 'Drunken Brawler
    _abDrunken_Haze = New abDrunken_Haze 'Drunken Haze
    _abPrimal_Split = New abPrimal_Split 'Primal Split
    _abThunder_Clap = New abThunder_Clap 'Thunder Clap
    _abLeech_Seed = New abLeech_Seed 'Leech Seed
    _abLiving_Armor = New abLiving_Armor 'Living Armor
    _abNatures_Guise = New abNatures_Guise 'Nature's Guise
    _abOvergrowth = New abOvergrowth 'Overgrowth
    _abEyes_In_The_Forest = New abTreant_Protector_Eyes_In_The_Forest
    '_abBreak_Tether = New abBreak_Tether 'Break Tether
    _abOvercharge = New abOvercharge 'Overcharge
    _abRelocate = New abRelocate 'Relocate
    _abSpirits = New abSpirits 'Spirits
    _abSpirit_Bear_Return = New abSpirit_Bear_Return
    _abSpirit_Bear_Demolish = New abSpirit_Bear_Demolish
    _abSpirit_Bear_Entangling_Claws = New abSpirit_Bear_Entangling_Claws
    ' _abSpirits_In = New abSpirits_In 'Spirits In
    '_abSpirits_Out = New abSpirits_Out 'Spirits Out
    _abTether = New abTether 'Tether
    _abDouble_Edge = New abDouble_Edge 'Double Edge
    _abHoof_Stomp = New abHoof_Stomp 'Hoof Stomp
    _abCentaurReturn = New abCentaurReturn 'Return
    _abStampede = New abStampede 'Stampede
    _abChakram = New abChakram 'Chakram
    _abReactive_Armor = New abReactive_Armor 'Reactive Armor
    ' _abReturn_Chakram = New abReturn_Chakram 'Return Chakram
    _abTimber_Chain = New abTimber_Chain 'Timber Chain
    _abWhirling_Death = New abWhirling_Death 'Whirling Death
    _abBristleback = New abBristleback 'Bristleback
    _abQuill_Spray = New abQuill_Spray 'Quill Spray
    _abViscous_Nasal = New abViscous_Nasal 'Viscous Nasal Goo
    _abWarpath = New abWarpath 'Warpath
    _abFrozen_Sigil = New abFrozen_Sigil 'Frozen Sigil
    _abIce_Shards = New abIce_Shards 'Ice Shards
    '_abLaunch_Snowball = New abLaunch_Snowball 'Launch Snowball
    _abSnowball = New abSnowball 'Snowball
    _abWalrus_Punch = New abWalrus_Punch 'Walrus PUNCH!
    _abAstral_Spirit = New abAstral_Spirit 'Astral Spirit
    _abEarth_Splitter = New abEarth_Splitter 'Earth Splitter
    _abEcho_Stomp = New abEcho_Stomp 'Echo Stomp
    _abNatural_Order = New abNatural_Order 'Natural Order
    '_abReturn_Astral_Spirit = New abReturn_Astral_Spirit 'Return Astral Spirit
    _abDuel = New abDuel 'Duel
    _abMoment_Of_Courage = New abMoment_Of_Courage 'Moment of Courage
    _abOverwhelming_Odds = New abOverwhelming_Odds 'Overwhelming Odds
    _abPress_The_Attack = New abPress_The_Attack 'Press The Attack
    _abBoulder_Smash = New abBoulder_Smash 'Boulder Smash
    _abGeomagnetic_Grip = New abGeomagnetic_Grip 'Geomagnetic Grip
    _abMagnetize = New abMagnetize 'Magnetize
    _abRolling_Boulder = New abRolling_Boulder 'Rolling Boulder
    ' _abStone_Remnant = New abStone_Remnant 'Stone Remnant
    _abFire_Spirits = New abFire_Spirits 'Fire Spirits
    _abIcarus_Dive = New abIcarus_Dive 'Icarus Dive
    ' _abLaunch_Fire_Spirit = New abLaunch_Fire_Spirit 'Launch Fire Spirit
    ' _abStop_Icarus_Dive = New abStop_Icarus_Dive 'Stop Icarus Dive
    '_abStop_Sun_Ray = New abStop_Sun_Ray 'Stop Sun Ray
    _abSun_Ray = New abSun_Ray 'Sun Ray
    _abSupernova = New abSupernova 'Supernova
    '_abToggle_Movement = New abToggle_Movement 'Toggle Movement
    _abAnti_Mage_Blink = New abAnti_Mage_Blink 'Blink
    _abMana_Break = New abMana_Break 'Mana Break
    _abMana_Void = New abMana_Void 'Mana Void
    _abSpell_Shield = New abSpell_Shield 'Spell Shield
    _abFrost_Arrows = New abFrost_Arrows 'Frost Arrows
    _abGust = New abGust 'Gust
    _abMarksmanship = New abMarksmanship 'Marksmanship
    _abPrecision_Aura = New abPrecision_Aura 'Precision Aura
    _abBlade_Dance = New abBlade_Dance 'Blade Dance
    _abBlade_Fury = New abBlade_Fury 'Blade Fury
    _abHealing_Ward = New abHealing_Ward 'Healing Ward
    _abOmnislash = New abOmnislash 'Omnislash
    _abLeap = New abLeap 'Leap
    _abMoonlight_Shadow = New abMoonlight_Shadow 'Moonlight Shadow
    _abSacred_Arrow = New abSacred_Arrow 'Sacred Arrow
    _abStarstorm = New abStarstorm 'Starstorm
    _abAdaptive_Strike = New abAdaptive_Strike 'Adaptive Strike
    _abMorph__Agility_Gain = New abMorph__Agility_Gain 'Morph (Agility Gain)
    '_abMorph_Strength_Gain = New abMorph_Strength_Gain 'Morph (Strength Gain)
    _abMorph_Replicate = New abMorph_Replicate 'Morph Replicate
    '_abReplicate = New abReplicate 'Replicate
    _abWaveform = New abWaveform 'Waveform
    _abDoppelganger = New abDoppelganger 'Doppelganger
    _abJuxtapose = New abJuxtapose 'Juxtapose
    _abPhantom_Rush = New abPhantom_Rush 'Phantom Rush
    _abSpirit_Lance = New abSpirit_Lance 'Spirit Lance
    _abMagic_Missile = New abMagic_Missile 'Magic Missile
    _abNether_Swap = New abNether_Swap 'Nether Swap
    _abVengeance_Aura = New abVengeance_Aura 'Vengeance Aura
    _abWave_Of_Terror = New abWave_Of_Terror 'Wave of Terror
    _abBackstab = New abBackstab 'Backstab
    _abBlink_Strike = New abBlink_Strike 'Blink Strike
    _abPermanent_Invisibility = New abPermanent_Invisibility 'Permanent Invisibility
    _abSmoke_Screen = New abSmoke_Screen 'Smoke Screen
    _abAssassinate = New abAssassinate 'Assassinate
    _abHeadshot = New abHeadshot 'Headshot
    _abShrapnel = New abShrapnel 'Shrapnel
    _abTake_Aim = New abTake_Aim 'Take Aim
    _abMeld = New abMeld 'Meld
    _abPsi_Blades = New abPsi_Blades 'Psi Blades
    _abPsionic_Trap = New abPsionic_Trap 'Psionic Trap
    _abRefraction = New abRefraction 'Refraction
    '_abTrap = New abTrap 'Trap
    _abEclipse = New abEclipse 'Eclipse
    _abLucent_Beam = New abLucent_Beam 'Lucent Beam
    _abLunar_Blessing = New abLunar_Blessing 'Lunar Blessing
    _abMoon_Glaive = New abMoon_Glaive 'Moon Glaive
    _abJinada = New abJinada 'Jinada
    _abShadow_Walk = New abShadow_Walk 'Shadow Walk
    _abShuriken_Toss = New abShuriken_Toss 'Shuriken Toss
    _abTrack = New abTrack 'Track
    _abEarthshock = New abEarthshock 'Earthshock
    _abEnrage = New abEnrage 'Enrage
    _abFury_Swipes = New abFury_Swipes 'Fury Swipes
    _abOverpower = New abOverpower 'Overpower
    _abCall_Down = New abCall_Down 'Call Down
    _abFlak_Cannon = New abFlak_Cannon 'Flak Cannon
    _abHoming_Missile = New abHoming_Missile 'Homing Missile
    _abRocket_Barrage = New abRocket_Barrage 'Rocket Barrage
    _abBattle_Cry = New abBattle_Cry 'Battle Cry
    '_abDruid_Form = New abDruid_Form 'Druid Form
    _abRabid = New abRabid 'Rabid
    _abSummon_Spirit_Bear = New abSummon_Spirit_Bear 'Summon Spirit Bear
    _abSynergy = New abSynergy 'Synergy
    _abTrue_Form = New abTrue_Form 'True Form
    _abEnsnare = New abEnsnare 'Ensnare
    _abMirror_Image = New abMirror_Image 'Mirror Image
    _abRip_Tide = New abRip_Tide 'Rip Tide
    _abSong_Of_The_Siren = New abSong_Of_The_Siren 'Song of the Siren
    '_abSong_Of_The_Siren_Cancel = New abSong_Of_The_Siren_Cancel 'Song of the Siren Cancel
    _abBattle_Trance = New abBattle_Trance 'Battle Trance
    _abBerserkers_Rage = New abBerserkers_Rage 'Berserker's Rage
    _abFervor = New abFervor 'Fervor
    _abWhirling_Axes__Melee = New abWhirling_Axes__Melee 'Whirling Axes (Melee)
    '_abWhirling_Axes__Ranged = New abWhirling_Axes__Ranged 'Whirling Axes (Ranged)
    '_abActivate_Fire_Remnant = New abActivate_Fire_Remnant 'Activate Fire Remnant
    _abFire_Remnant = New abFire_Remnant 'Fire Remnant
    _abFlame_Guard = New abFlame_Guard 'Flame Guard
    _abSearing_Chains = New abSearing_Chains 'Searing Chains
    _abSleight_Of_Fist = New abSleight_Of_Fist 'Sleight of Fist
    _abArcane_Aura = New abArcane_Aura 'Arcane Aura
    _abCrystal_Nova = New abCrystal_Nova 'Crystal Nova
    _abFreezing_Field = New abFreezing_Field 'Freezing Field
    _abFrostbite = New abFrostbite 'Frostbite
    _abDream_Coil = New abDream_Coil 'Dream Coil
    '_abEthereal_Jaunt = New abEthereal_Jaunt 'Ethereal Jaunt
    _abIllusory_Orb = New abIllusory_Orb 'Illusory Orb
    _abPhase_Shift = New abPhase_Shift 'Phase Shift
    _abWaning_Rift = New abWaning_Rift 'Waning Rift
    _abBall_Lightning = New abBall_Lightning 'Ball Lightning
    _abElectric_Vortex = New abElectric_Vortex 'Electric Vortex
    _abOverload = New abOverload 'Overload
    _abStatic_Remnant = New abStatic_Remnant 'Static Remnant
    _abFocus_Fire = New abFocus_Fire 'Focus Fire
    _abPowershot = New abPowershot 'Powershot
    _abShackleshot = New abShackleshot 'Shackleshot
    _abWindrun = New abWindrun 'Windrun
    _abArc_Lightning = New abArc_Lightning 'Arc Lightning
    _abLightning_Bolt = New abLightning_Bolt 'Lightning Bolt
    _abStatic_Field = New abStatic_Field 'Static Field
    _abThundergods_Wrath = New abThundergods_Wrath 'Thundergod's Wrath
    _abDragon_Slave = New abDragon_Slave 'Dragon Slave
    _abFiery_Soul = New abFiery_Soul 'Fiery Soul
    _abLaguna_Blade = New abLaguna_Blade 'Laguna Blade
    _abLight_Strike_Array = New abLight_Strike_Array 'Light Strike Array
    _abEther_Shock = New abEther_Shock 'Ether Shock
    _abShadow_Shaman_Hex = New abShadow_Shaman_Hex 'Hex
    _abMass_Serpent_Ward = New abMass_Serpent_Ward 'Mass Serpent Ward
    _abShackles = New abShackles 'Shackles
    _abHeatSeeking_Missile = New abHeatSeeking_Missile 'Heat-Seeking Missile
    _abLaser = New abLaser 'Laser
    _abMarch_Of_The_Machines = New abMarch_Of_The_Machines 'March of the Machines
    _abRearm = New abRearm 'Rearm
    _abNatures_Call = New abNatures_Call 'Nature's Call
    _abSprout = New abSprout 'Sprout
    _abTeleportation = New abTeleportation 'Teleportation
    _abWrath_Of_Nature = New abWrath_Of_Nature 'Wrath of Nature
    _abEnchant = New abEnchant 'Enchant
    _abImpetus = New abImpetus 'Impetus
    _abNatures_Attendants = New abNatures_Attendants 'Nature's Attendants
    _abUntouchable = New abUntouchable 'Untouchable
    _abDual_Breath = New abDual_Breath 'Dual Breath
    _abIce_Path = New abIce_Path 'Ice Path
    _abLiquid_Fire = New abLiquid_Fire 'Liquid Fire
    _abMacropyre = New abMacropyre 'Macropyre
    _abHand_Of_God = New abHand_Of_God 'Hand of God
    _abHoly_Persuasion = New abHoly_Persuasion 'Holy Persuasion
    _abPenitence = New abPenitence 'Penitence
    _abTest_Of_Faith = New abTest_Of_Faith 'Test of Faith
    _abCurse_Of_The_Silent = New abCurse_Of_The_Silent 'Curse of the Silent
    _abGlaives_Of_Wisdom = New abGlaives_Of_Wisdom 'Glaives of Wisdom
    _abGlobal_Silence = New abGlobal_Silence 'Global Silence
    _abLast_Word = New abLast_Word 'Last Word
    _abBloodlust = New abBloodlust 'Bloodlust
    _abFireblast = New abFireblast 'Fireblast
    _abIgnite = New abIgnite 'Ignite
    _abMulticast = New abMulticast 'Multicast
    '_abUnrefined_Fireblast = New abUnrefined_Fireblast 'Unrefined Fireblast
    _abFade_Bolt = New abFade_Bolt 'Fade Bolt
    _abNull_Field = New abNull_Field 'Null Field
    _abSpell_Steal = New abSpell_Steal 'Spell Steal
    _abTelekinesis = New abTelekinesis 'Telekinesis
    '_abTelekinesis_Land = New abTelekinesis_Land 'Telekinesis Land
    _abGlimpse = New abGlimpse 'Glimpse
    _abKinetic_Field = New abKinetic_Field 'Kinetic Field
    _abStatic_Storm = New abStatic_Storm 'Static Storm
    _abThunder_Strike = New abThunder_Strike 'Thunder Strike
    '_abBlinding_Light = New abBlinding_Light 'Blinding Light
    _abChakra_Magic = New abChakra_Magic 'Chakra Magic
    _abIlluminate = New abIlluminate 'Illuminate
    _abMana_Leak = New abMana_Leak 'Mana Leak
    '_abRecall = New abRecall 'Recall
    '_abRelease_Illuminate = New abRelease_Illuminate 'Release Illuminate
    _abSpirit_Form = New abSpirit_Form 'Spirit Form
    _abAncient_Seal = New abAncient_Seal 'Ancient Seal
    _abArcane_Bolt = New abArcane_Bolt 'Arcane Bolt
    _abConcussive_Shot = New abConcussive_Shot 'Concussive Shot
    _abMystic_Flare = New abMystic_Flare 'Mystic Flare
    '_abFocused_Detonate = New abFocused_Detonate 'Focused Detonate
    _abLand_Mines = New abLand_Mines 'Land Mines
    '_abMinefield_Sign = New abMinefield_Sign 'Minefield Sign
    _abRemote_Mines = New abRemote_Mines 'Remote Mines
    _abStasis_Trap = New abStasis_Trap 'Stasis Trap
    _abSuicide_Squad_Attack = New abSuicide_Squad_Attack 'Suicide Squad, Attack!
    _abBattle_Hunger = New abBattle_Hunger 'Battle Hunger
    _abBerserkers_Call = New abBerserkers_Call 'Berserker's Call
    _abCounter_Helix = New abCounter_Helix 'Counter Helix
    _abCulling_Blade = New abCulling_Blade 'Culling Blade
    _abDismember = New abDismember 'Dismember
    _abFlesh_Heap = New abFlesh_Heap 'Flesh Heap
    _abMeat_Hook = New abMeat_Hook 'Meat Hook
    _abRot = New abRot 'Rot
    _abBurrowstrike = New abBurrowstrike 'Burrowstrike
    _abCaustic_Finale = New abCaustic_Finale 'Caustic Finale
    _abEpicenter = New abEpicenter 'Epicenter
    _abSand_Storm = New abSand_Storm 'Sand Storm
    _abAmplify_Damage = New abAmplify_Damage 'Amplify Damage
    _abBash = New abBash 'Bash
    _abSlithereen_Crush = New abSlithereen_Crush 'Slithereen Crush
    _abSprint = New abSprint 'Sprint
    _abAnchor_Smash = New abAnchor_Smash 'Anchor Smash
    _abGush = New abGush 'Gush
    _abKraken_Shell = New abKraken_Shell 'Kraken Shell
    _abRavage = New abRavage 'Ravage
    _abMortal_Strike = New abMortal_Strike 'Mortal Strike
    _abReincarnation = New abReincarnation 'Reincarnation
    _abVampiric_Aura = New abVampiric_Aura 'Vampiric Aura
    _abWraithfire_Blast = New abWraithfire_Blast 'Wraithfire Blast
    '_abConsume = New abConsume 'Consume
    _abFeast = New abFeast 'Feast
    _abInfest = New abInfest 'Infest
    _abOpen_Wounds = New abOpen_Wounds 'Open Wounds
    _abRage = New abRage 'Rage
    _abCrippling_Fear = New abCrippling_Fear 'Crippling Fear
    _abDarkness = New abDarkness 'Darkness
    _abHunter_In_The_Night = New abHunter_In_The_Night 'Hunter in the Night
    _abVoid = New abVoid 'Void
    _abDevour = New abDevour 'Devour
    _abDoom = New abDoom 'Doom
    _abLvl_Death = New abLvl_Death 'LVL? Death
    _abScorched_Earth = New abScorched_Earth 'Scorched Earth
    _abCharge_Of_Darkness = New abCharge_Of_Darkness 'Charge of Darkness
    _abEmpowering_Haste = New abEmpowering_Haste 'Empowering Haste
    _abGreater_Bash = New abGreater_Bash 'Greater Bash
    _abNether_Strike = New abNether_Strike 'Nether Strike
    _abFeral_Impulse = New abFeral_Impulse 'Feral Impulse
    _abHowl = New abHowl 'Howl
    _abShapeshift = New abShapeshift 'Shapeshift
    _abSummon_Wolves = New abSummon_Wolves 'Summon Wolves
    _abChaos_Bolt = New abChaos_Bolt 'Chaos Bolt
    _abChaos_Strike = New abChaos_Strike 'Chaos Strike
    _abPhantasm = New abPhantasm 'Phantasm
    _abReality_Rift = New abReality_Rift 'Reality Rift
    _abDecay = New abDecay 'Decay
    _abFlesh_Golem = New abFlesh_Golem 'Flesh Golem
    _abSoul_Rip = New abSoul_Rip 'Soul Rip
    _abTombstone = New abTombstone 'Tombstone
    _abEmpower = New abEmpower 'Empower
    _abReverse_Polarity = New abReverse_Polarity 'Reverse Polarity
    _abShockwave = New abShockwave 'Shockwave
    _abSkewer = New abSkewer 'Skewer
    _abAphotic_Shield = New abAphotic_Shield 'Aphotic Shield
    _abBorrowed_Time = New abBorrowed_Time 'Borrowed Time
    _abCurse_Of_Avernus = New abCurse_Of_Avernus 'Curse of Avernus
    _abMist_Coil = New abMist_Coil 'Mist Coil
    _abBlood_Rite = New abBlood_Rite 'Blood Rite
    _abBloodrage = New abBloodrage 'Bloodrage
    _abRupture = New abRupture 'Rupture
    _abThirst = New abThirst 'Thirst
    _abNecromastery = New abNecromastery 'Necromastery
    _abPresence_Of_The_Dark_Lord = New abPresence_Of_The_Dark_Lord 'Presence of the Dark Lord
    _abRequiem_Of_Souls = New abRequiem_Of_Souls 'Requiem of Souls
    _abShadowraze = New abShadowraze 'Shadowraze
    _abEye_Of_The_Storm = New abEye_Of_The_Storm 'Eye of the Storm
    _abPlasma_Field = New abPlasma_Field 'Plasma Field
    _abStatic_Link = New abStatic_Link 'Static Link
    _abUnstable_Current = New abUnstable_Current 'Unstable Current
    _abPlague_Ward = New abPlague_Ward 'Plague Ward
    _abPoison_Nova = New abPoison_Nova 'Poison Nova
    _abPoison_Sting = New abPoison_Sting 'Poison Sting
    _abVenomous_Gale = New abVenomous_Gale 'Venomous Gale
    _abBacktrack = New abBacktrack 'Backtrack
    _abChronosphere = New abChronosphere 'Chronosphere
    _abTime_Lock = New abTime_Lock 'Time Lock
    _abTime_Walk = New abTime_Walk 'Time Walk
    _abBlur = New abBlur 'Blur
    _abCoup_De_Grace = New abCoup_De_Grace 'Coup de Grace
    _abPhantom_Strike = New abPhantom_Strike 'Phantom Strike
    _abStifling_Dagger = New abStifling_Dagger 'Stifling Dagger
    _abCorrosive_Skin = New abCorrosive_Skin 'Corrosive Skin
    _abNethertoxin = New abNethertoxin 'Nethertoxin
    _abPoison_Attack = New abPoison_Attack 'Poison Attack
    _abViper_Strike = New abViper_Strike 'Viper Strike
    _abDeath_Pact = New abDeath_Pact 'Death Pact
    _abSearing_Arrows = New abSearing_Arrows 'Searing Arrows
    _abSkeleton_Walk = New abSkeleton_Walk 'Skeleton Walk
    _abStrafe = New abStrafe 'Strafe
    _abIncapacitating_Bite = New abIncapacitating_Bite 'Incapacitating Bite
    _abInsatiable_Hunger = New abInsatiable_Hunger 'Insatiable Hunger
    _abSpawn_Spiderlings = New abSpawn_Spiderlings 'Spawn Spiderlings
    _abSpin_Web = New abSpin_Web 'Spin Web
    _abGeminate_Attack = New abGeminate_Attack 'Geminate Attack
    _abShukuchi = New abShukuchi 'Shukuchi
    _abThe_Swarm = New abThe_Swarm 'The Swarm
    _abTime_Lapse = New abTime_Lapse 'Time Lapse
    _abDesolate = New abDesolate 'Desolate
    _abDispersion = New abDispersion 'Dispersion
    _abHaunt = New abHaunt 'Haunt
    '_abReality = New abReality 'Reality
    _abSpectral_Dagger = New abSpectral_Dagger 'Spectral Dagger
    _abDivided_We_Stand = New abDivided_We_Stand 'Divided We Stand
    _abEarthbind = New abEarthbind 'Earthbind
    _abGeostrike = New abGeostrike 'Geostrike
    _abPoof = New abPoof 'Poof
    _abImpale = New abImpale 'Impale
    _abMana_Burn = New abMana_Burn 'Mana Burn
    _abSpiked_Carapace = New abSpiked_Carapace 'Spiked Carapace
    _abVendetta = New abVendetta 'Vendetta
    _abDark_Pact = New abDark_Pact 'Dark Pact
    _abEssence_Shift = New abEssence_Shift 'Essence Shift
    _abPounce = New abPounce 'Pounce
    _abShadow_Dance = New abShadow_Dance 'Shadow Dance
    _abMana_Shield = New abMana_Shield 'Mana Shield
    _abMystic_Snake = New abMystic_Snake 'Mystic Snake
    _abSplit_Shot = New abSplit_Shot 'Split Shot
    _abStone_Gaze = New abStone_Gaze 'Stone Gaze
    _abConjure_Image = New abConjure_Image 'Conjure Image
    _abMetamorphosis = New abMetamorphosis 'Metamorphosis
    _abReflection = New abReflection 'Reflection
    _abSunder = New abSunder 'Sunder
    _abBrain_Sap = New abBrain_Sap 'Brain Sap
    _abEnfeeble = New abEnfeeble 'Enfeeble
    _abFiends_Grip = New abFiends_Grip 'Fiend's Grip
    _abNightmare = New abNightmare 'Nightmare
    '_abNightmare_End = New abNightmare_End 'Nightmare End
    _abChain_Frost = New abChain_Frost 'Chain Frost
    _abFrost_Blast = New abFrost_Blast 'Frost Blast
    _abIce_Armor = New abIce_Armor 'Ice Armor
    _abSacrifice = New abSacrifice 'Sacrifice
    _abEarth_Spike = New abEarth_Spike 'Earth Spike
    _abFinger_Of_Death = New abFinger_Of_Death 'Finger of Death
    _abLion_Hex = New abLion_Hex 'Hex
    _abMana_Drain = New abMana_Drain 'Mana Drain
    _abDeath_Ward = New abDeath_Ward 'Death Ward
    _abMaledict = New abMaledict 'Maledict
    _abParalyzing_Cask = New abParalyzing_Cask 'Paralyzing Cask
    _abVoodoo_Restoration = New abVoodoo_Restoration 'Voodoo Restoration
    _abBlack_Hole = New abBlack_Hole 'Black Hole
    _abDemonic_Conversion = New abDemonic_Conversion 'Demonic Conversion
    _abMalefice = New abMalefice 'Malefice
    _abMidnight_Pulse = New abMidnight_Pulse 'Midnight Pulse
    _abDeath_Pulse = New abDeath_Pulse 'Death Pulse
    _abHeartstopper_Aura = New abHeartstopper_Aura 'Heartstopper Aura
    _abReapers_Scythe = New abReapers_Scythe 'Reaper's Scythe
    _abSadist = New abSadist 'Sadist
    _abChaotic_Offering = New abChaotic_Offering 'Chaotic Offering
    _abFatal_Bonds = New abFatal_Bonds 'Fatal Bonds
    _abShadow_Word = New abShadow_Word 'Shadow Word
    _abUpheaval = New abUpheaval 'Upheaval
    _abQoP_Blink = New abQoP_Blink 'Blink
    _abScream_Of_Pain = New abScream_Of_Pain 'Scream Of Pain
    _abShadow_Strike = New abShadow_Strike 'Shadow Strike
    _abSonic_Wave = New abSonic_Wave 'Sonic Wave
    _abCrypt_Swarm = New abCrypt_Swarm 'Crypt Swarm
    _abExorcism = New abExorcism 'Exorcism
    _abSilence = New abSilence 'Silence
    _abWitchcraft = New abWitchcraft 'Witchcraft
    _abDecrepify = New abDecrepify 'Decrepify
    _abLife_Drain = New abLife_Drain 'Life Drain
    _abNether_Blast = New abNether_Blast 'Nether Blast
    _abNether_Ward = New abNether_Ward 'Nether Ward
    _abPoison_Touch = New abPoison_Touch 'Poison Touch
    _abShadow_Wave = New abShadow_Wave 'Shadow Wave
    _abShallow_Grave = New abShallow_Grave 'Shallow Grave
    _abWeave = New abWeave 'Weave
    _abDiabolic_Edict = New abDiabolic_Edict 'Diabolic Edict
    _abLightning_Storm = New abLightning_Storm 'Lightning Storm
    _abPulse_Nova = New abPulse_Nova 'Pulse Nova
    _abSplit_Earth = New abSplit_Earth 'Split Earth
    _abIon_Shell = New abIon_Shell 'Ion Shell
    _abSurge = New abSurge 'Surge
    _abVacuum = New abVacuum 'Vacuum
    _abWall_Of_Replica = New abWall_Of_Replica 'Wall of Replica
    _abFirefly = New abFirefly 'Firefly
    _abFlamebreak = New abFlamebreak 'Flamebreak
    _abFlaming_Lasso = New abFlaming_Lasso 'Flaming Lasso
    _abSticky_Napalm = New abSticky_Napalm 'Sticky Napalm
    _abChilling_Touch = New abChilling_Touch 'Chilling Touch
    _abCold_Feet = New abCold_Feet 'Cold Feet
    _abIce_Blast = New abIce_Blast 'Ice Blast
    _abIce_Vortex = New abIce_Vortex 'Ice Vortex
    '_abRelease = New abRelease 'Release
    _abAlacrity = New abAlacrity 'Alacrity
    _abChaos_Meteor = New abChaos_Meteor 'Chaos Meteor
    _abCold_Snap = New abCold_Snap 'Cold Snap
    _abDeafening_Blast = New abDeafening_Blast 'Deafening Blast
    _abEmp = New abEmp 'EMP
    _abExort = New abExort 'Exort
    _abForge_Spirit = New abForge_Spirit 'Forge Spirit
    _abGhost_Walk = New abGhost_Walk 'Ghost Walk
    _abIce_Wall = New abIce_Wall 'Ice Wall
    _abInvoke = New abInvoke 'Invoke
    _abQuas = New abQuas 'Quas
    _abSun_Strike = New abSun_Strike 'Sun Strike
    _abTornado = New abTornado 'Tornado
    _abWex = New abWex 'Wex
    _abArcane_Orb = New abArcane_Orb 'Arcane Orb
    _abAstral_Imprisonment = New abAstral_Imprisonment 'Astral Imprisonment
    _abEssence_Aura = New abEssence_Aura 'Essence Aura
    _abSanitys_Eclipse = New abSanitys_Eclipse 'Sanity's Eclipse
    _abDemonic_Purge = New abDemonic_Purge 'Demonic Purge
    _abDisruption = New abDisruption 'Disruption
    _abShadow_Poison = New abShadow_Poison 'Shadow Poison
    ' _abShadow_Poison_Release = New abShadow_Poison_Release 'Shadow Poison Release
    _abSoul_Catcher = New abSoul_Catcher 'Soul Catcher
    _abGrave_Chill = New abGrave_Chill 'Grave Chill
    _abGravekeepers_Cloak = New abGravekeepers_Cloak 'Gravekeeper's Cloak
    _abSoul_Assumption = New abSoul_Assumption 'Soul Assumption
    _abSummon_Familiars = New abSummon_Familiars 'Summon Familiars
    _abSpiderling_Spawn_Spiderite = New abSpiderling_Spawn_Spiderite
    _abSpiderling_Poison_Sting = New abSpiderling_Poison_Sting
    _abLycan_Wolf_Critical_Strike = New abLycan_Wolf_Critical_Strike
    _abLycan_Wolf_Invisibility = New abLycan_Wolf_Invisibility
    _abPlague_Ward_Poison_Sting = New abPlague_Ward_Poison_Sting
    _abRemote_Mines_Pinpoint_Detonate = New abRemote_Mines_Pinpoint_Detonate
    _abGolem_Warlock_Flaming_Fists = New abGolem_Warlock_Flaming_Fists
    _abGolem_Warlock_Permanent_immolation = New abGolem_Warlock_Permanent_immolation
    _abFamiliar_Spell_Immunity = New abFamiliar_Spell_Immunity
    _abFamiliar_Stone_Form = New abFamiliar_Stone_Form

    _abNecro_Archer_Archer_Aura = New abNecro_Archer_Archer_Aura
    _abNecro_Archer_Mana_Burn = New abNecro_Archer_Mana_Burn
    _abNecro_Warrior_Last_Will = New abNecro_Warrior_Last_Will
    _abNecro_Warrior_Mana_Break = New abNecro_Warrior_Mana_Break
    _abNecro_Warrior_True_Sight = New abNecro_Warrior_True_Sight


    _abBoar_Poison = New abBoar_Poison
    _abHawk_Invisibility = New abHawk_Invisibility

    _abFire_Brewmaster_Drunken_Brawler = New abFire_Brewmaster_Drunken_Brawler
    _abFire_Brewmaster_Permanent_Immolation = New abFire_Brewmaster_Permanent_Immolation
    _abEarth_Brewmaster_Hurl_Boulder = New abEarth_Brewmaster_Hurl_Boulder
    _abEarth_Brewmaster_Pulverize = New abEarth_Brewmaster_Pulverize
    _abEarth_Brewmaster_Spell_Immunity = New abEarth_Brewmaster_Spell_Immunity
    _abEarth_Brewmaster_Thunder_Clap = New abEarth_Brewmaster_Thunder_Clap
    _abStorm_Brewmaster_Cyclone = New abStorm_Brewmaster_Cyclone
    _abStorm_Brewmaster_Dispel_Magic = New abStorm_Brewmaster_Dispel_Magic
    _abStorm_Brewmaster_Drunken_Haze = New abStorm_Brewmaster_Drunken_Haze
    _abStorm_Brewmaster_Wind_Walk = New abStorm_Brewmaster_Wind_Walk

    _abUndying_Zombie_Deathlust = New abUndying_Zombie_Deathlust
    _abUndying_Zombie_Spell_Immunity = New abUndying_Zombie_Spell_Immunity

    _abForged_Spirit_Melting_Strike = New abForged_Spirit_Melting_Strike

    _abPsionic_Trap_Self_Trap = New abPsionic_Trap_Self_Trap

    _abTornado_Tempest = New abTornado_Tempest

    _abKobold_Foreman_Speed_Aura = New abKobold_Foreman_Speed_Aura


    _abHill_Troll_Priest_Heal = New abHill_Troll_Priest_Heal
    _abHill_Troll_Priest_Mana_Aura = New abHill_Troll_Priest_Mana_Aura

    _abVhoul_Assassin_Envenomed_Weapon = New abVhoul_Assassin_Envenomed_Weapon

    _abGhost_Frost_Attack = New abGhost_Frost_Attack

    _abHarpy_Stormcrafter_Chain_Lightning = New abHarpy_Stormcrafter_Chain_Lightning

    _abCentaur_Congeror_War_Stomp = New abCentaur_Congeror_War_Stomp

    _abGiant_Wolf_Critical_Strike = New abGiant_Wolf_Critical_Strike

    _abAlpha_Wolf_Packleaders_Aura = New abAlpha_Wolf_Packleaders_Aura
    _abAlpha_Wolf_Critical_Strike = New abAlpha_Wolf_Critical_Strike

    _abSatyr_Banisher_Purge = New abSatyr_Banisher_Purge
    _abSatyr_Mindstealer_Mana_Burn = New abSatyr_Mindstealer_Mana_Burn
    _abOgre_Frostmage_Ice_Armor = New abOgre_Frostmage_Ice_Armor
    _abMud_Golem_Spell_Immunity = New abMud_Golem_Spell_Immunity
    _abSatyr_Tormentor_Shockwave = New abSatyr_Tormentor_Shockwave
    _abHellbear_Smasher_Thunder_Clap = New abHellbear_Smasher_Thunder_Clap
    _abHellbear_Smasher_Swiftness_Aura = New abHellbear_Smasher_Swiftness_Aura
    _abWildwing_Ripper_Tornado = New abWildwing_Ripper_Tornado
    _abWildwing_Ripper_Toughness_Aua = New abWildwing_Ripper_Toughness_Aua
    _abDark_Troll_Summoner_Ensnare = New abDark_Troll_Summoner_Ensnare
    _abDark_Troll_Summoner_Raise_Dead = New abDark_Troll_Summoner_Raise_Dead
    _abAncient_Black_Dragon_Splash_Attack = New abAncient_Black_Dragon_Splash_Attack
    _abAncient_Black_Dragon_Spell_Immunity = New abAncient_Black_Dragon_Spell_Immunity
    _abAncient_Granite_Golem_Granite_Aura = New abAncient_Granite_Golem_Granite_Aura
    _abAncient_Granite_Golem_Spell_Immunity = New abAncient_Granite_Golem_Spell_Immunity
    _abAncient_Rock_Golem_Spell_Immunity = New abAncient_Rock_Golem_Spell_Immunity
    _abAncient_Thunderhide_Slam = New abAncient_Thunderhide_Slam
    _abAncient_Thunderhide_Frenzy = New abAncient_Thunderhide_Frenzy
    _abAncient_Thunderhide_Spell_Immunity = New abAncient_Thunderhide_Spell_Immunity
    _abAncient_Rumblehide_Spell_Immunity = New abAncient_Rumblehide_Spell_Immunity
    _abRoshan_Spell_Block = New abRoshan_Spell_Block
    _abRoshan_Bash = New abRoshan_Bash
    _abRoshan_Slam = New abRoshan_Slam
    _abRoshan_Strength_Of_The_Immortal = New abRoshan_Strength_Of_The_Immortal
    _abBuilding_Backdoor_Protection = New abBuilding_Backdoor_Protection
    _abBuilding_Glyph_of_Fortification = New abBuilding_Glyph_of_Fortification


    _abStat_Gain = New abStat_Gain

    'add to doubledictionary
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAftershock, _abAftershock)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEcho_Slam, _abEcho_Slam)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEnchant_Totem, _abEnchant_Totem)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFissure, _abFissure)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGods_Strength, _abGods_Strength)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGreat_Cleave, _abGreat_Cleave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStorm_Hammer, _abStorm_Hammer)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWarcry, _abWarcry)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAvalanche, _abAvalanche)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCraggy_Exterior, _abCraggy_Exterior)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGrow, _abGrow)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abToss, _abToss)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGhostship, _abGhostship)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTidebringer, _abTidebringer)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTorrent, _abTorrent)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abX_Marks_The_Spot, _abX_Marks_The_Spot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCall_Of_The_Wild, _abCall_Of_The_Wild)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abInner_Beast, _abInner_Beast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPrimal_Roar, _abPrimal_Roar)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWild_Axes, _abWild_Axes)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBreathe_Fire, _abBreathe_Fire)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDragon_Blood, _abDragon_Blood)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDragon_Tail, _abDragon_Tail)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abElder_Dragon_Form, _abElder_Dragon_Form)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBattery_Assault, _abBattery_Assault)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHookshot, _abHookshot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPower_Cogs, _abPower_Cogs)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRocket_Flare, _abRocket_Flare)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDegen_Aura, _abDegen_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGuardian_Angel, _abGuardian_Angel)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPurification, _abPurification)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRepel, _abRepel)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBerserkers_Blood, _abBerserkers_Blood)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBurning_Spear, _abBurning_Spear)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abInner_Vitality, _abInner_Vitality)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLife_Break, _abLife_Break)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAcid_Spray, _abAcid_Spray)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChemical_Rage, _abChemical_Rage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGreevils_Greed, _abGreevils_Greed)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abUnstable_Concoction, _abUnstable_Concoction)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDrunken_Brawler, _abDrunken_Brawler)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDrunken_Haze, _abDrunken_Haze)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPrimal_Split, _abPrimal_Split)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abThunder_Clap, _abThunder_Clap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLeech_Seed, _abLeech_Seed)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLiving_Armor, _abLiving_Armor)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNatures_Guise, _abNatures_Guise)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOvergrowth, _abOvergrowth)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEyes_In_The_Forest, _abEyes_In_The_Forest)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOvercharge, _abOvercharge)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRelocate, _abRelocate)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpirits, _abSpirits)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpirit_Bear_Return, _abSpirit_Bear_Return)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpirit_Bear_Demolish, _abSpirit_Bear_Demolish)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpirit_Bear_Entangling_Claws, _abSpirit_Bear_Entangling_Claws)


    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTether, _abTether)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDouble_Edge, _abDouble_Edge)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHoof_Stomp, _abHoof_Stomp)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCentaurReturn, _abCentaurReturn)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStampede, _abStampede)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChakram, _abChakram)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abReactive_Armor, _abReactive_Armor)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTimber_Chain, _abTimber_Chain)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWhirling_Death, _abWhirling_Death)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBristleback, _abBristleback)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abQuill_Spray, _abQuill_Spray)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abViscous_Nasal, _abViscous_Nasal)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWarpath, _abWarpath)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFrozen_Sigil, _abFrozen_Sigil)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIce_Shards, _abIce_Shards)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSnowball, _abSnowball)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWalrus_Punch, _abWalrus_Punch)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAstral_Spirit, _abAstral_Spirit)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarth_Splitter, _abEarth_Splitter)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEcho_Stomp, _abEcho_Stomp)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNatural_Order, _abNatural_Order)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDuel, _abDuel)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMoment_Of_Courage, _abMoment_Of_Courage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOverwhelming_Odds, _abOverwhelming_Odds)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPress_The_Attack, _abPress_The_Attack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBoulder_Smash, _abBoulder_Smash)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGeomagnetic_Grip, _abGeomagnetic_Grip)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMagnetize, _abMagnetize)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRolling_Boulder, _abRolling_Boulder)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFire_Spirits, _abFire_Spirits)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIcarus_Dive, _abIcarus_Dive)



    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSun_Ray, _abSun_Ray)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSupernova, _abSupernova)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAnti_Mage_Blink, _abAnti_Mage_Blink)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMana_Break, _abMana_Break)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMana_Void, _abMana_Void)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpell_Shield, _abSpell_Shield)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFrost_Arrows, _abFrost_Arrows)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGust, _abGust)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMarksmanship, _abMarksmanship)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPrecision_Aura, _abPrecision_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBlade_Dance, _abBlade_Dance)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBlade_Fury, _abBlade_Fury)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHealing_Ward, _abHealing_Ward)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOmnislash, _abOmnislash)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLeap, _abLeap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMoonlight_Shadow, _abMoonlight_Shadow)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSacred_Arrow, _abSacred_Arrow)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStarstorm, _abStarstorm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAdaptive_Strike, _abAdaptive_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMorph_Agility_Gain, _abMorph__Agility_Gain)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMorph_Replicate, _abMorph_Replicate)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWaveform, _abWaveform)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDoppelganger, _abDoppelganger)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abJuxtapose, _abJuxtapose)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPhantom_Rush, _abPhantom_Rush)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpirit_Lance, _abSpirit_Lance)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMagic_Missile, _abMagic_Missile)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNether_Swap, _abNether_Swap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVengeance_Aura, _abVengeance_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWave_Of_Terror, _abWave_Of_Terror)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBackstab, _abBackstab)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBlink_Strike, _abBlink_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPermanent_Invisibility, _abPermanent_Invisibility)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSmoke_Screen, _abSmoke_Screen)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAssassinate, _abAssassinate)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHeadshot, _abHeadshot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShrapnel, _abShrapnel)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTake_Aim, _abTake_Aim)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMeld, _abMeld)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPsi_Blades, _abPsi_Blades)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPsionic_Trap, _abPsionic_Trap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRefraction, _abRefraction)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEclipse, _abEclipse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLucent_Beam, _abLucent_Beam)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLunar_Blessing, _abLunar_Blessing)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMoon_Glaive, _abMoon_Glaive)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abJinada, _abJinada)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Walk, _abShadow_Walk)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShuriken_Toss, _abShuriken_Toss)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTrack, _abTrack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarthshock, _abEarthshock)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEnrage, _abEnrage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFury_Swipes, _abFury_Swipes)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOverpower, _abOverpower)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCall_Down, _abCall_Down)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFlak_Cannon, _abFlak_Cannon)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHoming_Missile, _abHoming_Missile)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRocket_Barrage, _abRocket_Barrage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBattle_Cry, _abBattle_Cry)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRabid, _abRabid)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSummon_Spirit_Bear, _abSummon_Spirit_Bear)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSynergy, _abSynergy)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTrue_Form, _abTrue_Form)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEnsnare, _abEnsnare)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMirror_Image, _abMirror_Image)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRip_Tide, _abRip_Tide)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSong_Of_The_Siren, _abSong_Of_The_Siren)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBattle_Trance, _abBattle_Trance)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBerserkers_Rage, _abBerserkers_Rage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFervor, _abFervor)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWhirling_Axes__Melee, _abWhirling_Axes__Melee)


    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFire_Remnant, _abFire_Remnant)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFlame_Guard, _abFlame_Guard)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSearing_Chains, _abSearing_Chains)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSleight_Of_Fist, _abSleight_Of_Fist)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abArcane_Aura, _abArcane_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCrystal_Nova, _abCrystal_Nova)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFreezing_Field, _abFreezing_Field)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFrostbite, _abFrostbite)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDream_Coil, _abDream_Coil)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIllusory_Orb, _abIllusory_Orb)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPhase_Shift, _abPhase_Shift)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWaning_Rift, _abWaning_Rift)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBall_Lightning, _abBall_Lightning)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abElectric_Vortex, _abElectric_Vortex)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOverload, _abOverload)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStatic_Remnant, _abStatic_Remnant)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFocus_Fire, _abFocus_Fire)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPowershot, _abPowershot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShackleshot, _abShackleshot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWindrun, _abWindrun)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abArc_Lightning, _abArc_Lightning)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLightning_Bolt, _abLightning_Bolt)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStatic_Field, _abStatic_Field)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abThundergods_Wrath, _abThundergods_Wrath)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDragon_Slave, _abDragon_Slave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFiery_Soul, _abFiery_Soul)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLaguna_Blade, _abLaguna_Blade)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLight_Strike_Array, _abLight_Strike_Array)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEther_Shock, _abEther_Shock)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Shaman_Hex, _abShadow_Shaman_Hex)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMass_Serpent_Ward, _abMass_Serpent_Ward)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShackles, _abShackles)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHeatSeeking_Missile, _abHeatSeeking_Missile)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLaser, _abLaser)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMarch_Of_The_Machines, _abMarch_Of_The_Machines)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRearm, _abRearm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNatures_Call, _abNatures_Call)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSprout, _abSprout)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTeleportation, _abTeleportation)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWrath_Of_Nature, _abWrath_Of_Nature)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEnchant, _abEnchant)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abImpetus, _abImpetus)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNatures_Attendants, _abNatures_Attendants)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abUntouchable, _abUntouchable)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDual_Breath, _abDual_Breath)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIce_Path, _abIce_Path)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLiquid_Fire, _abLiquid_Fire)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMacropyre, _abMacropyre)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHand_Of_God, _abHand_Of_God)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHoly_Persuasion, _abHoly_Persuasion)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPenitence, _abPenitence)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTest_Of_Faith, _abTest_Of_Faith)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCurse_Of_The_Silent, _abCurse_Of_The_Silent)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGlaives_Of_Wisdom, _abGlaives_Of_Wisdom)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGlobal_Silence, _abGlobal_Silence)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLast_Word, _abLast_Word)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBloodlust, _abBloodlust)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFireblast, _abFireblast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIgnite, _abIgnite)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMulticast, _abMulticast)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFade_Bolt, _abFade_Bolt)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNull_Field, _abNull_Field)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpell_Steal, _abSpell_Steal)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTelekinesis, _abTelekinesis)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGlimpse, _abGlimpse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abKinetic_Field, _abKinetic_Field)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStatic_Storm, _abStatic_Storm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abThunder_Strike, _abThunder_Strike)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChakra_Magic, _abChakra_Magic)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIlluminate, _abIlluminate)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMana_Leak, _abMana_Leak)


    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpirit_Form, _abSpirit_Form)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Seal, _abAncient_Seal)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abArcane_Bolt, _abArcane_Bolt)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abConcussive_Shot, _abConcussive_Shot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMystic_Flare, _abMystic_Flare)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLand_Mines, _abLand_Mines)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRemote_Mines, _abRemote_Mines)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStasis_Trap, _abStasis_Trap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSuicide_Squad_Attack, _abSuicide_Squad_Attack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBattle_Hunger, _abBattle_Hunger)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBerserkers_Call, _abBerserkers_Call)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCounter_Helix, _abCounter_Helix)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCulling_Blade, _abCulling_Blade)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDismember, _abDismember)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFlesh_Heap, _abFlesh_Heap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMeat_Hook, _abMeat_Hook)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRot, _abRot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBurrowstrike, _abBurrowstrike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCaustic_Finale, _abCaustic_Finale)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEpicenter, _abEpicenter)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSand_Storm, _abSand_Storm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAmplify_Damage, _abAmplify_Damage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBash, _abBash)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSlithereen_Crush, _abSlithereen_Crush)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSprint, _abSprint)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAnchor_Smash, _abAnchor_Smash)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGush, _abGush)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abKraken_Shell, _abKraken_Shell)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRavage, _abRavage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMortal_Strike, _abMortal_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abReincarnation, _abReincarnation)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVampiric_Aura, _abVampiric_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWraithfire_Blast, _abWraithfire_Blast)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFeast, _abFeast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abInfest, _abInfest)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOpen_Wounds, _abOpen_Wounds)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRage, _abRage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCrippling_Fear, _abCrippling_Fear)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDarkness, _abDarkness)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHunter_In_The_Night, _abHunter_In_The_Night)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVoid, _abVoid)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDevour, _abDevour)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDoom, _abDoom)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLvl_Death, _abLvl_Death)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abScorched_Earth, _abScorched_Earth)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCharge_Of_Darkness, _abCharge_Of_Darkness)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEmpowering_Haste, _abEmpowering_Haste)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGreater_Bash, _abGreater_Bash)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNether_Strike, _abNether_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFeral_Impulse, _abFeral_Impulse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHowl, _abHowl)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShapeshift, _abShapeshift)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSummon_Wolves, _abSummon_Wolves)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChaos_Bolt, _abChaos_Bolt)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChaos_Strike, _abChaos_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPhantasm, _abPhantasm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abReality_Rift, _abReality_Rift)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDecay, _abDecay)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFlesh_Golem, _abFlesh_Golem)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSoul_Rip, _abSoul_Rip)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTombstone, _abTombstone)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEmpower, _abEmpower)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abReverse_Polarity, _abReverse_Polarity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShockwave, _abShockwave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSkewer, _abSkewer)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAphotic_Shield, _abAphotic_Shield)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBorrowed_Time, _abBorrowed_Time)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCurse_Of_Avernus, _abCurse_Of_Avernus)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMist_Coil, _abMist_Coil)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBlood_Rite, _abBlood_Rite)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBloodrage, _abBloodrage)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRupture, _abRupture)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abThirst, _abThirst)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNecromastery, _abNecromastery)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPresence_Of_The_Dark_Lord, _abPresence_Of_The_Dark_Lord)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRequiem_Of_Souls, _abRequiem_Of_Souls)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadowraze, _abShadowraze)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEye_Of_The_Storm, _abEye_Of_The_Storm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPlasma_Field, _abPlasma_Field)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStatic_Link, _abStatic_Link)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abUnstable_Current, _abUnstable_Current)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPlague_Ward, _abPlague_Ward)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPoison_Nova, _abPoison_Nova)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPoison_Sting, _abPoison_Sting)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVenomous_Gale, _abVenomous_Gale)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBacktrack, _abBacktrack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChronosphere, _abChronosphere)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTime_Lock, _abTime_Lock)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTime_Walk, _abTime_Walk)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBlur, _abBlur)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCoup_De_Grace, _abCoup_De_Grace)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPhantom_Strike, _abPhantom_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStifling_Dagger, _abStifling_Dagger)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCorrosive_Skin, _abCorrosive_Skin)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNethertoxin, _abNethertoxin)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPoison_Attack, _abPoison_Attack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abViper_Strike, _abViper_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDeath_Pact, _abDeath_Pact)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSearing_Arrows, _abSearing_Arrows)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSkeleton_Walk, _abSkeleton_Walk)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStrafe, _abStrafe)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIncapacitating_Bite, _abIncapacitating_Bite)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abInsatiable_Hunger, _abInsatiable_Hunger)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpawn_Spiderlings, _abSpawn_Spiderlings)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpin_Web, _abSpin_Web)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGeminate_Attack, _abGeminate_Attack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShukuchi, _abShukuchi)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abThe_Swarm, _abThe_Swarm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTime_Lapse, _abTime_Lapse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDesolate, _abDesolate)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDispersion, _abDispersion)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHaunt, _abHaunt)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpectral_Dagger, _abSpectral_Dagger)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDivided_We_Stand, _abDivided_We_Stand)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarthbind, _abEarthbind)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGeostrike, _abGeostrike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPoof, _abPoof)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abImpale, _abImpale)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMana_Burn, _abMana_Burn)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpiked_Carapace, _abSpiked_Carapace)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVendetta, _abVendetta)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDark_Pact, _abDark_Pact)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEssence_Shift, _abEssence_Shift)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPounce, _abPounce)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Dance, _abShadow_Dance)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMana_Shield, _abMana_Shield)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMystic_Snake, _abMystic_Snake)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSplit_Shot, _abSplit_Shot)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStone_Gaze, _abStone_Gaze)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abConjure_Image, _abConjure_Image)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMetamorphosis, _abMetamorphosis)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abReflection, _abReflection)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSunder, _abSunder)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBrain_Sap, _abBrain_Sap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEnfeeble, _abEnfeeble)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFiends_Grip, _abFiends_Grip)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNightmare, _abNightmare)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChain_Frost, _abChain_Frost)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFrost_Blast, _abFrost_Blast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIce_Armor, _abIce_Armor)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSacrifice, _abSacrifice)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarth_Spike, _abEarth_Spike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFinger_Of_Death, _abFinger_Of_Death)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLion_Hex, _abLion_Hex)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMana_Drain, _abMana_Drain)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDeath_Ward, _abDeath_Ward)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMaledict, _abMaledict)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abParalyzing_Cask, _abParalyzing_Cask)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVoodoo_Restoration, _abVoodoo_Restoration)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBlack_Hole, _abBlack_Hole)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDemonic_Conversion, _abDemonic_Conversion)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMalefice, _abMalefice)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMidnight_Pulse, _abMidnight_Pulse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDeath_Pulse, _abDeath_Pulse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHeartstopper_Aura, _abHeartstopper_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abReapers_Scythe, _abReapers_Scythe)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSadist, _abSadist)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChaotic_Offering, _abChaotic_Offering)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFatal_Bonds, _abFatal_Bonds)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Word, _abShadow_Word)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abUpheaval, _abUpheaval)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abQoP_Blink, _abQoP_Blink)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abScream_Of_Pain, _abScream_Of_Pain)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Strike, _abShadow_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSonic_Wave, _abSonic_Wave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCrypt_Swarm, _abCrypt_Swarm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abExorcism, _abExorcism)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSilence, _abSilence)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWitchcraft, _abWitchcraft)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDecrepify, _abDecrepify)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLife_Drain, _abLife_Drain)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNether_Blast, _abNether_Blast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNether_Ward, _abNether_Ward)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPoison_Touch, _abPoison_Touch)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Wave, _abShadow_Wave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShallow_Grave, _abShallow_Grave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWeave, _abWeave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDiabolic_Edict, _abDiabolic_Edict)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLightning_Storm, _abLightning_Storm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPulse_Nova, _abPulse_Nova)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSplit_Earth, _abSplit_Earth)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIon_Shell, _abIon_Shell)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSurge, _abSurge)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVacuum, _abVacuum)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWall_Of_Replica, _abWall_Of_Replica)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFirefly, _abFirefly)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFlamebreak, _abFlamebreak)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFlaming_Lasso, _abFlaming_Lasso)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSticky_Napalm, _abSticky_Napalm)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChilling_Touch, _abChilling_Touch)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCold_Feet, _abCold_Feet)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIce_Blast, _abIce_Blast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIce_Vortex, _abIce_Vortex)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAlacrity, _abAlacrity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abChaos_Meteor, _abChaos_Meteor)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCold_Snap, _abCold_Snap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDeafening_Blast, _abDeafening_Blast)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEmp, _abEmp)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abExort, _abExort)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abForge_Spirit, _abForge_Spirit)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGhost_Walk, _abGhost_Walk)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abIce_Wall, _abIce_Wall)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abInvoke, _abInvoke)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abQuas, _abQuas)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSun_Strike, _abSun_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTornado, _abTornado)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWex, _abWex)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abArcane_Orb, _abArcane_Orb)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAstral_Imprisonment, _abAstral_Imprisonment)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEssence_Aura, _abEssence_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSanitys_Eclipse, _abSanitys_Eclipse)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDemonic_Purge, _abDemonic_Purge)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDisruption, _abDisruption)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abShadow_Poison, _abShadow_Poison)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSoul_Catcher, _abSoul_Catcher)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGrave_Chill, _abGrave_Chill)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGravekeepers_Cloak, _abGravekeepers_Cloak)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSoul_Assumption, _abSoul_Assumption)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSummon_Familiars, _abSummon_Familiars)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpiderling_Spawn_Spiderite, _abSpiderling_Spawn_Spiderite)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSpiderling_Poison_Sting, _abSpiderling_Poison_Sting)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLycan_Wolf_Critical_Strike, _abLycan_Wolf_Critical_Strike)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abLycan_Wolf_Invisibility, _abLycan_Wolf_Invisibility)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPlague_Ward_Poison_Sting, _abPlague_Ward_Poison_Sting)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRemote_Mines_Pinpoint_Detonate, _abRemote_Mines_Pinpoint_Detonate)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGolem_Warlock_Flaming_Fists, _abGolem_Warlock_Flaming_Fists)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGolem_Warlock_Permanent_immolation, _abGolem_Warlock_Permanent_immolation)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFamiliar_Spell_Immunity, _abFamiliar_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFamiliar_Stone_Form, _abFamiliar_Stone_Form)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNecro_Archer_Archer_Aura, _abNecro_Archer_Archer_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNecro_Archer_Mana_Burn, _abNecro_Archer_Mana_Burn)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNecro_Warrior_Last_Will, _abNecro_Warrior_Last_Will)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNecro_Warrior_Mana_Break, _abNecro_Warrior_Mana_Break)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abNecro_Warrior_True_Sight, _abNecro_Warrior_True_Sight)


    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBoar_Poison, _abBoar_Poison)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHawk_Invisibility, _abHawk_Invisibility)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFire_Brewmaster_Drunken_Brawler, _abFire_Brewmaster_Drunken_Brawler)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abFire_Brewmaster_Permanent_Immolation, _abFire_Brewmaster_Permanent_Immolation)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarth_Brewmaster_Hurl_Boulder, _abEarth_Brewmaster_Hurl_Boulder)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarth_Brewmaster_Pulverize, _abEarth_Brewmaster_Pulverize)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarth_Brewmaster_Spell_Immunity, _abEarth_Brewmaster_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abEarth_Brewmaster_Thunder_Clap, _abEarth_Brewmaster_Thunder_Clap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStorm_Brewmaster_Cyclone, _abStorm_Brewmaster_Cyclone)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStorm_Brewmaster_Dispel_Magic, _abStorm_Brewmaster_Dispel_Magic)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStorm_Brewmaster_Drunken_Haze, _abStorm_Brewmaster_Drunken_Haze)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStorm_Brewmaster_Wind_Walk, _abStorm_Brewmaster_Wind_Walk)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abUndying_Zombie_Deathlust, _abUndying_Zombie_Deathlust)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abUndying_Zombie_Spell_Immunity, _abUndying_Zombie_Spell_Immunity)


    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abForged_Spirit_Melting_Strike, _abForged_Spirit_Melting_Strike)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abTornado_Tempest, _abTornado_Tempest)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abKobold_Foreman_Speed_Aura, _abKobold_Foreman_Speed_Aura)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHill_Troll_Priest_Heal, _abHill_Troll_Priest_Heal)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHill_Troll_Priest_Mana_Aura, _abHill_Troll_Priest_Mana_Aura)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abPsionic_Trap_Self_Trap, _abPsionic_Trap_Self_Trap)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abVhoul_Assassin_Envenomed_Weapon, _abVhoul_Assassin_Envenomed_Weapon)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGhost_Frost_Attack, _abGhost_Frost_Attack)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHarpy_Stormcrafter_Chain_Lightning, _abHarpy_Stormcrafter_Chain_Lightning)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abCentaur_Congeror_War_Stomp, _abCentaur_Congeror_War_Stomp)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abGiant_Wolf_Critical_Strike, _abGiant_Wolf_Critical_Strike)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAlpha_Wolf_Packleaders_Aura, _abAlpha_Wolf_Packleaders_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAlpha_Wolf_Critical_Strike, _abAlpha_Wolf_Critical_Strike)

    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSatyr_Banisher_Purge, _abSatyr_Banisher_Purge)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSatyr_Mindstealer_Mana_Burn, _abSatyr_Mindstealer_Mana_Burn)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abOgre_Frostmage_Ice_Armor, _abOgre_Frostmage_Ice_Armor)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abMud_Golem_Spell_Immunity, _abMud_Golem_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abSatyr_Tormentor_Shockwave, _abSatyr_Tormentor_Shockwave)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHellbear_Smasher_Thunder_Clap, _abHellbear_Smasher_Thunder_Clap)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abHellbear_Smasher_Swiftness_Aura, _abHellbear_Smasher_Swiftness_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWildwing_Ripper_Tornado, _abWildwing_Ripper_Tornado)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abWildwing_Ripper_Toughness_Aua, _abWildwing_Ripper_Toughness_Aua)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDark_Troll_Summoner_Ensnare, _abDark_Troll_Summoner_Ensnare)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abDark_Troll_Summoner_Raise_Dead, _abDark_Troll_Summoner_Raise_Dead)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Black_Dragon_Splash_Attack, _abAncient_Black_Dragon_Splash_Attack)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Black_Dragon_Spell_Immunity, _abAncient_Black_Dragon_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Granite_Golem_Granite_Aura, _abAncient_Granite_Golem_Granite_Aura)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Granite_Golem_Spell_Immunity, _abAncient_Granite_Golem_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Rock_Golem_Spell_Immunity, _abAncient_Rock_Golem_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Thunderhide_Slam, _abAncient_Thunderhide_Slam)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Thunderhide_Frenzy, _abAncient_Thunderhide_Frenzy)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Thunderhide_Spell_Immunity, _abAncient_Thunderhide_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abAncient_Rumblehide_Spell_Immunity, _abAncient_Rumblehide_Spell_Immunity)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRoshan_Spell_Block, _abRoshan_Spell_Block)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRoshan_Bash, _abRoshan_Bash)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRoshan_Slam, _abRoshan_Slam)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abRoshan_Strength_Of_The_Immortal, _abRoshan_Strength_Of_The_Immortal)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBuilding_Backdoor_Protection, _abBuilding_Backdoor_Protection)
    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abBuilding_Glyph_of_Fortification, _abBuilding_Glyph_of_Fortification)


    mAbilitiesByEAbilityName.AddorUpdate(eAbilityName.abStat_Gain, _abStat_Gain)


  End Sub
 
  Public Function GetAbilityInfoNoParent(abilityname As eAbilityName) As Ability_Info
    Return GetAbility(abilityname, 1, Nothing, Constants.cDefaultLifetime)
  End Function

  Public Function CreateAbilityInfoInstance(abilityname As eAbilityName, abilitylevel As Integer, _
                                 theparent As iDisplayUnit, _
                                 theLifetime As Lifetime) As Ability_Info
    Return GetAbility(abilityname, abilitylevel, theparent, theLifetime)


  End Function
  Private Function GetAbility(abilityname As eAbilityName, abilitylevel As Integer, _
                                 theparent As iDisplayUnit, _
                                 theLifetime As Lifetime) As Ability_Info

    If abilityname = eAbilityName.abUndying_Zombie_Deathlust Then
      Dim x = 2
    End If
    Dim outab As Ability_Info
    Dim selectedability As iAbility = mAbilitiesByEAbilityName.ValueForKey(abilityname)



    If Not selectedability Is Nothing Then
      outab = New Ability_Info(Me, selectedability.AbilityName, _
                                 theparent, _
        selectedability.DisplayName, _
        selectedability.AbilitysUIPosition, _
        selectedability.IsUltimate, _
        selectedability.IsAghsUpgradable, _
        selectedability.mImageURL, _
        selectedability.mWebpageLink, _
        selectedability.mDescription, _
        selectedability.mNotes, _
        selectedability.mManaCost, _
        selectedability.mCooldown, _
        selectedability.mAbilityTypes, _
        selectedability.mAffects, _
        selectedability.mDamageType, _
        selectedability.mDamage, _
        selectedability.mDuration, _
        selectedability.mRadius, _
        selectedability.mRange, _
        selectedability.mBlockedByMagicImmune, _
        selectedability.mRemovedByMagicImmune, _
        selectedability.mCanBePurged, _
        selectedability.mCanBeUsedByIllusions, _
        selectedability.mCanSelfDeny, _
        selectedability.mBlockedByLinkens, _
        selectedability.mBreaksStun, _
        selectedability.mIsUniqueAttackModifier, _
        selectedability.mPiercesSpellImmunity, _
        selectedability.mAbilityLevelCount, _
        abilitylevel, _
        theLifetime)


    End If
    
    If outab IsNot Nothing Then
      If outab.ParentGameEntity IsNot Nothing Then
        mAbilityInstances.Add(outab.Id.GuidID.ToString, outab)
      End If
    Else
      mLog.WriteLog("GetAbility Returning nothing for " & abilityname.ToString)
    End If

    Return outab
  End Function

  Public Function GetItemStateAndUrls( theabilityname As eAbilityName) As List(Of List(Of String))

    Dim ability = mAbilitiesByEAbilityName.ValueForKey(theabilityname)

    If ability IsNot Nothing Then
      Return ability.StatesAndStateUrls
    End If
    Return Nothing 'New List(Of List(Of String))
  End Function
  Public Function GetAbilityList() As Dictionary(Of eAbilityName, String)
    Return mFriendlyNames
  End Function


  Public Function GetAbilityInstance(ByVal theid As dvID) As Ability_Info
    If mAbilityInstances.ContainsKey(theid.GuidID.ToString) Then
      Return mAbilityInstances.Item(theid.GuidID.ToString)
    End If
    Return Nothing
  End Function
  Public Function GetAbilityModifiers(thestateindex As Integer, thegame As dGame, _
                                      ability_Info As iAbility_Info, _
                                      caster As iDisplayUnit, _
                                      etarget As iDisplayUnit, _
                                      ftarget As iDisplayUnit, _
                                      isfriendbias As Boolean, _
                                      occurencetime As Lifetime, aghstime As Lifetime) As List(Of ModifierList)



    Dim outmods As New List(Of ModifierList) '0 is actives, 1 is passives

    Dim selectedability = mAbilitiesByEAbilityName.ValueForKey(ability_Info.AbilityName)

    If selectedability IsNot Nothing Then
      outmods.Add(GetActiveAbilityModifiers(thestateindex, thegame, ability_Info, _
                                                             caster, _
                                                             etarget, _
                                                             ftarget, _
                                                             isfriendbias, _
                                                             occurencetime, aghstime))
      outmods.Add(GetPassiveAbilityModifiers(thestateindex, thegame, ability_Info, _
                                                             caster, _
                                                             etarget, _
                                                             ftarget, _
                                                             isfriendbias, _
                                                             occurencetime, aghstime))
    End If

    Return outmods
  End Function

  Public Function GetActiveAbilityModifiers(thestateindex As Integer, thegame As dGame, _
                                      ability_Info As iAbility_Info, _
                                      caster As iDisplayUnit, _
                                      etarget As iDisplayUnit, _
                                      ftarget As iDisplayUnit, _
                                      isfriendbias As Boolean, _
                                      occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim selectedability = mAbilitiesByEAbilityName.ValueForKey(ability_Info.AbilityName)

    If selectedability IsNot Nothing Then
      Return selectedability.GetActiveModifiers(thestateindex, thegame, ability_Info, _
                                                             caster, _
                                                             etarget, _
                                                             ftarget, _
                                                             isfriendbias, _
                                                             occurencetime, aghstime)

    End If
    Return New ModifierList
  End Function

  Public Function GetPassiveAbilityModifiers(thestateindex As Integer, thegame As dGame, _
                                      ability_Info As iAbility_Info, _
                                      caster As iDisplayUnit, _
                                      etarget As iDisplayUnit, _
                                      ftarget As iDisplayUnit, _
                                      isfriendbias As Boolean, _
                                      occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim selectedability = mAbilitiesByEAbilityName.ValueForKey(ability_Info.AbilityName)

    If selectedability IsNot Nothing Then

      Return selectedability.GetPassiveModifiers(thestateindex, thegame, ability_Info, _
                                                             caster, _
                                                             etarget, _
                                                             ftarget, _
                                                             isfriendbias, _
                                                             occurencetime, aghstime)
    End If
    Return New ModifierList
  End Function

  Protected Overrides Sub Finalize()
    MyBase.Finalize()
  End Sub
End Class
