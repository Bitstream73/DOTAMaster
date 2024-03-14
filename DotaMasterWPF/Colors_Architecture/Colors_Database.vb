Imports System.Windows.Media.Imaging


Public Class Colors_Database
  '  Private mydictbyurl As New Dictionary(Of String, Color)
  Private mColorForID As OneToOneDoubleDictionary(Of Guid, Color)
  Private mColorForModifierType As OneToOneDoubleDictionary(Of eModifierType, Color)
  Private mColorForStatType As OneToOneDoubleDictionary(Of eStattype, Color)
  Private mColorForAbilityName As OneToOneDoubleDictionary(Of eAbilityName, Color)
  Private mColorForHeroName As OneToOneDoubleDictionary(Of eHeroName, Color)
  Private mColorForItemName As OneToOneDoubleDictionary(Of eItemname, Color)
  Private mColorForCreepName As OneToOneDoubleDictionary(Of eCreepName, Color)
  Private mColorForPetName As OneToOneDoubleDictionary(Of ePetName, Color)

  Private mylistbyteampos As New List(Of Color) '0-4 radiant, 5-9 dire

  Private mErrorColor = Color.FromArgb(255, 255, 100, 250)

  Private mBackgroundColor = Color.FromArgb(255, 37, 38, 39)
  Private mBodyTextColor = Color.FromArgb(255, 183, 183, 183)
  Private mHeadingTextColor = Color.FromArgb(255, 230, 230, 230)
  Private mSubHeadingTextColor = Color.FromArgb(255, 230, 230, 230)

  Private mCommentaryTextColor = Color.FromArgb(255, 104, 238, 103)
  Private mValueTextColor = Color.FromArgb(255, 243, 166, 58)
  Private mUlitmateTextColor = Color.FromArgb(255, 255, 0, 0)

  Private mGoldColor = Color.FromArgb(255, 247, 215, 99)
  Private mXpColor = Color.FromArgb(255, 8, 121, 253)

  Private mDefenseColor = Color.FromArgb(255, 176, 118, 48)
  Private mManaColor = Color.FromArgb(255, 8, 121, 253)

  Private mMoveColor = Color.FromArgb(255, 176, 118, 48)
  Private mAttSpeedColor = Color.FromArgb(255, 176, 118, 48)

  Private mHealthColor = Color.FromArgb(255, 0, 199, 0)
  Private mCritColor = Color.FromArgb(255, 87, 221, 87)

  Private mMagicalColor = Color.FromArgb(255, 81, 206, 228)
  Private mPhysicalColor = Color.FromArgb(255, 255, 6, 6)
  Private mPureColor = Color.FromArgb(255, 87, 221, 87)
  Private mHPRemovalColor = Color.FromArgb(255, 255, 6, 6)

  Private mIntColor = Color.FromArgb(255, 81, 206, 228)
  Private mStrColor = Color.FromArgb(255, 255, 6, 6)
  Private mAgiColor = Color.FromArgb(255, 87, 221, 87)

  Private mVisionDayColor = Color.FromArgb(255, 245, 247, 43)
  Private mVisionNightColor = Color.FromArgb(255, 59, 60, 3)
  Private mMetaDataColor = Color.FromArgb(255, 125, 125, 125)

  Private mStealthColor = Color.FromArgb(255, 240, 148, 66)

  Private mRadiantColor = Color.FromArgb(255, 79, 115, 62)
  Private mRadianAccentColor = Color.FromArgb(255, 112, 166, 84)

  Private mDireColor = Color.FromArgb(255, 124, 52, 52)
  Private mDireAccentColor = Color.FromArgb(255, 164, 57, 57)

  Private mNeutralTeamColor = Color.FromArgb(255, 81, 206, 228)

  Private mBtnColorSelected = Color.FromArgb(255, 129, 129, 129)
  Private mBtnColorNotSelected = Color.FromArgb(0, 0, 0, 0)

  Private mTransparent = Color.FromArgb(0, 0, 0, 0)

  Private mTransparency As Integer = 25

  Private mSelectedColor = Color.FromArgb(255, 255, 255, 0)
  Private mHoveredColor = Color.FromArgb(255, 255, 255, 255)
  Private mGraphedColor = Color.FromArgb(255, 81, 206, 228)
  'for things like creeps selected tab
  Private mAccentedColor = Color.FromArgb(255, 110, 110, 110)

  Private mPetColorSwatch = Color.FromArgb(255, 49, 0, 75)

  Private mDarkenOverlay = Color.FromArgb(128, 0, 0, 0)

  Private mBarRectDividerColor = Color.FromArgb(255, 128, 128, 128)
  Private mGraphDividerColor = Color.FromArgb(255, 81, 206, 228)
  Private mScaleStrongColor = Color.FromArgb(64, 255, 255, 255)
  Private mScaleWeakColor = Color.FromArgb(32, 255, 255, 255)

  Private mScaleStrongFill = Color.FromArgb(15, 0, 0, 0)
  Private mScaleWeakFill = Color.FromArgb(0, 0, 0, 0)

  Private mDayColor = Color.FromArgb(64, 255, 255, 0)
  Private mNightColor = Color.FromArgb(64, 0, 174, 240)

  Private mLog As iLogging
  Public Sub New(log As iLogging)
    mLog = log
    LoadTeamColors()
    LoadModifierTypeColors()
    LoadStatTypeColors()
    mColorForAbilityName = New OneToOneDoubleDictionary(Of eAbilityName, Color)(mLog)
    mColorForHeroName = New OneToOneDoubleDictionary(Of eHeroName, Color)(mLog)
    mColorForItemName = New OneToOneDoubleDictionary(Of eItemname, Color)(mLog)
    mColorForCreepName = New OneToOneDoubleDictionary(Of eCreepName, Color)(mLog)
    mColorForPetName = New OneToOneDoubleDictionary(Of ePetName, Color)(mLog)
    mColorForID = New OneToOneDoubleDictionary(Of Guid, Color)(mLog)
  End Sub

  Private Sub LoadStatTypeColors()
    mColorForStatType = New OneToOneDoubleDictionary(Of eStattype, Color)(mLog)

    mColorForStatType.AddorUpdate(eStattype.None, mErrorColor)
    mColorForStatType.AddorUpdate(eStattype.Agility, AgiColor)
    mColorForStatType.AddorUpdate(eStattype.AllDamageAvg, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.AllDamageBurst, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.ArmorxPoint06, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.AttackDamageAverage, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.AttackDamageHigh, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.AttackDamageLow, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.AttackRange, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.AttackSpeed, mAttSpeedColor)
    mColorForStatType.AddorUpdate(eStattype.BaseAttackTime, mAttSpeedColor)
    mColorForStatType.AddorUpdate(eStattype.CritChance, mCritColor)
    mColorForStatType.AddorUpdate(eStattype.CritMultiplier, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.CritDamage, mCritColor)
    mColorForStatType.AddorUpdate(eStattype.EffectiveHP, mHealthColor)
    mColorForStatType.AddorUpdate(eStattype.Experience, mXpColor)
    mColorForStatType.AddorUpdate(eStattype.Hex, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.HexAvg, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.HitPointRegen, mHealthColor)
    mColorForStatType.AddorUpdate(eStattype.HitPoints, mHealthColor)
    mColorForStatType.AddorUpdate(eStattype.HPRemoval, mHPRemovalColor)
    mColorForStatType.AddorUpdate(eStattype.Intelligence, mIntColor)
    mColorForStatType.AddorUpdate(eStattype.Kills, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.MagicalDamageResistance, mMagicalColor)
    mColorForStatType.AddorUpdate(eStattype.MagicDamage, mMagicalColor)
    mColorForStatType.AddorUpdate(eStattype.MagicDamageAvg, mMagicalColor)
    mColorForStatType.AddorUpdate(eStattype.MagicImmunity, mDefenseColor)
    mColorForStatType.AddorUpdate(eStattype.MagicImmunityAvg, mDefenseColor)
    mColorForStatType.AddorUpdate(eStattype.Mana, mManaColor)
    mColorForStatType.AddorUpdate(eStattype.ManaRegen, mManaColor)
    mColorForStatType.AddorUpdate(eStattype.MissileSpeed, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.MovementSpeed, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.Networth, mGoldColor)
    mColorForStatType.AddorUpdate(eStattype.Number1, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.NumberPoint06, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.PeriodicGold, mGoldColor)
    mColorForStatType.AddorUpdate(eStattype.PhysicalArmor, mDefenseColor)
    mColorForStatType.AddorUpdate(eStattype.PhysicalDamage, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.PhysicalDamageAmplification, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.PhysicalDamageAvg, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.PhysicalDamageNegation, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.PhysicalDamageReduction, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.PrimaryAttribute, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.PureDamage, mPureColor)
    mColorForStatType.AddorUpdate(eStattype.PureDamageAvg, mPureColor)
    mColorForStatType.AddorUpdate(eStattype.Resources, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.SpellImmunityCount, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.Stealth, mStealthColor)
    mColorForStatType.AddorUpdate(eStattype.StealthTime, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.Strength, mStrColor)
    mColorForStatType.AddorUpdate(eStattype.Stun, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.StunAvg, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.TrueSight, mVisionDayColor)
    mColorForStatType.AddorUpdate(eStattype.TurnRate, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.VisionDay, mVisionDayColor)
    mColorForStatType.AddorUpdate(eStattype.VisionNight, mVisionNightColor)
    mColorForStatType.AddorUpdate(eStattype.TeamKills, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlEffectiveHP, mHeadingTextColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlDamageHi, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlDamageLo, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlDamageAvg, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlHP, mHealthColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlHPRegen, mHealthColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlMana, mManaColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlManaRegen, mManaColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlVisionDay, mVisionDayColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlVisionNight, mVisionNightColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlDPSPeak, mManaColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlDPSAvg, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlPhysDamageBurst, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlPhysDPSAvg, mPhysicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlMagDamageBurst, mMagicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlMagDPSAvg, mMagicalColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlPureDamageBurst, mPureColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlPureDPSAvg, mPureColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlStunDuratoin, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlHexDuration, mMoveColor)
    mColorForStatType.AddorUpdate(eStattype.TeamTtlSpellImmunityCount, mMetaDataColor)
    mColorForStatType.AddorUpdate(eStattype.TeamPhysicalArmor, mDefenseColor)
    mColorForStatType.AddorUpdate(eStattype.TeamMagicResistance, mDefenseColor)

  End Sub

  Private Sub LoadModifierTypeColors()
    mColorForModifierType = New OneToOneDoubleDictionary(Of eModifierType, Color)(mLog)

    mColorForModifierType.AddorUpdate(eModifierType.None, mErrorColor)
    mColorForModifierType.AddorUpdate(eModifierType.AbilityEffectiveHp, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.AbilitySteal, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.AdaptiveStrikeDamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.AdaptiveStrikeStun, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.AgiAdded, mAgiColor)
    mColorForModifierType.AddorUpdate(eModifierType.AgioT, mAgiColor)
    mColorForModifierType.AddorUpdate(eModifierType.AgiPercent, MagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.AgiSubtracted, MagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArcaneOrb, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorAdded, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorAddedPerSec, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmoroT, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorPercentage, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorStackSubtracted, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorSubtracted, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorSubtractedoT, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ArmorxPoint06, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.AstralSpiritDamageMagicalAdded, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.AstralSpiritMoveSpeedPercentAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.AstrlImpIntStolen, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedAddedPerHeroPerMissHP, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedAddedtoXAttacks, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedMaxed, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedoT, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedPercentAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedPercentofTargetAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedPercentSubtracted, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackSpeedStackAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.AttackspeedSubtracted, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.BackstabRightclickDamageAddedAsPercofAgi, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BallLightDamMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BallLightPushForward, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Barrier, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAgi, MagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAttackRange, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.AgiIncrementAdded, MagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseandBonusDamageReduction, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseArmor, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseArmorDebuff, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseArmorPercentSubtracted, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAttackTime, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAttackTimeChangedTo, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAttackDamageHigh, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAttackDamageLow, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseAttackDamageAvg, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseInt, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseMagicResistance, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseMagicResistancePercentSubtracted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseMana, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseMovementSpeed, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseStr, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseTurnRate, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Bash, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.BearBonusDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BearMoveSpeedAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.BerserkersBonusAttackSpeed, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.BerserkersBonusMagicResistance, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BlindChance, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.BlindDuration, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.BonusDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BonusDamageoT, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BonusDamagePercent, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.BonusGold, mGoldColor)
    mColorForModifierType.AddorUpdate(eModifierType.BountyGold, mGoldColor)
    mColorForModifierType.AddorUpdate(eModifierType.BuildingAttackSpeedPercentAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.CausticFinale, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ChainLightning, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ChenAncientCount, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.ChenCreepFullHeal, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.CleavePercentage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ColdAttack, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.ConjuredImage, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Consumption, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.ControlledCreepHealthBonus, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.Corruption, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.CreepControlled, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.CripplingFearMissChance, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.CritChance, mCritColor)
    mColorForModifierType.AddorUpdate(eModifierType.CritDamage, mCritColor)
    mColorForModifierType.AddorUpdate(eModifierType.CritMultiplier, mCritColor)
    mColorForModifierType.AddorUpdate(eModifierType.Cyclone, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageAbsorbedForMana, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageAllTypesIncomingIncreasesPercent, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageAllTypesPercentAdded, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageAllTypesStackAdded, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageAmplification, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageBlock, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageBlockRemoved, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageBothBlockAdded, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageChainMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageChainPhysicalInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageDelay, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageIncreasePercent, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageInstanceBlock, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageLost, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalAbsorbed, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalAdded, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalAddedToPhysicalAttacks, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalBouncesInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalChain, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalEarthSplitterAdded, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalImmunity, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalInflictedOnSpellCast, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalInflictedPerAlly, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalInflictedPerTarget, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalInflictedPerUnit, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalInflictedUntilSpellcast, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalMinMaxInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicaloTAsMultofStr, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalOverTimeInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalPercent, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalPerCreep, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalPerHero, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalPerMissingHP, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalPerMissingMana, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalPerSec, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalRandomInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMagicalTimesInt, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMeleeAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMeleeBlockAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageMeleemultiplier, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageoTMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.damagePerSecond, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalBouncesInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalEarthSplitterAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalImmunity, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalIncomingIncreasedPercent, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicaloT, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalPercent, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalPerSec, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalStackingInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePhysicalSubtracted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePierceAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePierceChancePercent, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureAdded, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureAsPercentofManaPool, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureAsPercentofMaxHP, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureoTasPercofMaxHP, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureoTInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePurePercent, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagePureRandomInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageRangeAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageRangeBlockAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageRangemultiplier, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageReduction, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageReturnDuration, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamagetoHealPercent, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.DamageTransferedToCaster, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DarknessNight, mVisionNightColor)
    mColorForModifierType.AddorUpdate(eModifierType.DeathlustAttackSpeedAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.DeathlustMoveSpeedPercentAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.DestroysCreep, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DestroysHero, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DestroysHeroBelowThreshold, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DestroysTree, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Disarm, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DisarmMelee, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DisarmRange, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.DisjointRange, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.Dispel, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.DisruptionIllusion, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Dominate, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.DuelBonusDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ElderDragonForm, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Ensnare, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Entangle, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.EssenceAuraManaRestored, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.Ethereal_Time, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.EvasionPercent, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.EvasionRemoved, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.EvilSpirits, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.ExortDamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ExortDamageMagicalInflictedoT, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ExortRightClickBonusDamageAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.FadeBoltDamageMagicalBounces, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.Feedback, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.FrostArrows, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Ghost_Form_Time, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.GlaivesWisdom, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.GreaterBashofCurrentLevel, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Haunt, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.HealAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAddedAsPercOfTargetCurrHP, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAddedoT, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAddedoTAsPercofMaxHP, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAddedPerDeadCreep, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAddedPerDeadHero, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAddedPerUnit, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealAsPercentofHP, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealFriendlyorDamageEnemy, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealFriendlyorMagicDamEnemyoT, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealMinMaxAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealoTSetTo, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealPercent, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealPercentSubtracted, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealthFullyRestored, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealthPercentAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealthRegenAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HealthvalueFrozen, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HeroDamageReducedTo, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.HeroReflection, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Hex, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPoT, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPPercent, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRegenAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRegenSubtracted, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRegenPercent, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRegenPercentofCasters, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRegenPerUnitKilledAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRemoval, mHPRemovalColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRemovalAsPercentofMoveDist, mHPRemovalColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPRemovalSharedWithBoundUnits, mHPRemovalColor)
    mColorForModifierType.AddorUpdate(eModifierType.HPSubtracted, mHPRemovalColor)
    mColorForModifierType.AddorUpdate(eModifierType.IllusionDamageReducedTo, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Impetus, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.ImpetusDamagePureInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.IncapBite, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.InfestCreepHeal, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.InnerVitalityPercentHealAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.IntAdded, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.IntIncrementAdded, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.IntoT, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.IntPercent, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.IntSubtracted, mIntColor)
    mColorForModifierType.AddorUpdate(eModifierType.Invisibility, mStealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.InvisibilityWhenNotAttacking, mStealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.InvokeASpell, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.InvokeSpellCount, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.Invulnerability, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.ItemEffectiveHP, mHPRemovalColor)
    mColorForModifierType.AddorUpdate(eModifierType.KillsPerGoldIncrement, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Knockback, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.KotLSpiritForm, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.LastHitGoldAdded, mGoldColor)
    mColorForModifierType.AddorUpdate(eModifierType.LastHitGoldBonusPerStack, mGoldColor)
    mColorForModifierType.AddorUpdate(eModifierType.Leap, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.LifeDrainDrainfromTarget, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.LifeDrainPercent, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.LifeDrainSelfEffect, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.LifeStealAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.LifestealAddedtoAllAttackers, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.LifeStealPercent, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.LiquidFire, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.LostHealthDamagePercent, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.LucentBeamHits, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.LvlDeathDamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicDamageReceivedMultiplier, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicImmunity, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicResistanceAdded, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicResistanceCapped, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicResistancePercentAdded, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicResistancePercentSubtracted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicResistanceSet, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagicResistanceSubtracted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MagnatizeDamageOverTime, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MaimChance, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaAdded, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaSubtracted, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaBreak, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaBurnDamage, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaBurnManaremoved, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaDrained, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaDrainedUntilSpellcast, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaoT, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaoTSubtracted, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaPercent, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaPercentDrained, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRegenAdded, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRegenSubtracted, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRegenPercent, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRegenPercentofCasters, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRegenPerUnitKillAdded, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRemoved, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRemovedoT, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRemovedPercentoT, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRestored, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.MaxManaAdded, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRestoredAsPercentOfHP, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.ManaRestoredPercent, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.MantaMeleeIllusionDamagePercentage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MantaRangeIllusionDamagePercentage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MeepoClone, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.MeleeSlow, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.MeleeStun, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MeltingStrike, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.MidnightPulsePureDamageAdded, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.Minibash_Damage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MiniMapInvisibility, mStealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.MiniStun, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MirrorImage, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.MissChance, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.MissileSpeed, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedMinimum, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedoT, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercent, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercentAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.rightclickdamageaddedperherobelow75perchealth, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercentAsDamage, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercentofTargetAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercentStackSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedPercentSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedSet, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedStackAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MoveSpeedSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastBloodlustCoolReduction, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastBloodlustRadiusAdded, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastFireblastCoolReduction, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastFireblastManaAdded, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastFourXChance, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastIgniteCastRangeAdded, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastIgniteRadius, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastThreeXChance, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MulticastTwoXChance, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteAbilities, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteAllOnTarget, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteAttacks, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteBlink, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteInvisibility, mStealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteItems, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteMove, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteRightClick, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteTargetability, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteTeleport, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MuteTurn, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.MysticSnakeDamageAdded, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.MysticSnakeManaAdded, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.MysticSnakeManaSubtracted, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseGold, mGoldColor)
    mColorForModifierType.AddorUpdate(eModifierType.NightAttackSpeedAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.NightAttackSpeedSubtracted, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.NightMoveSpeedAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Number1, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.NumberPoint06, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.OpenWoundsSlowInflicted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.PackleaderRClickDamageAsPercofBaseDamandPrimaryStat, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.PauseTime, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.PercentofCreepHealthGained, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.PeriodicGold, mGoldColor)
    mColorForModifierType.AddorUpdate(eModifierType.petAlpha_Wolf, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petAncient_Black_Dragon, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petAncient_Black_Drake, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petAncient_Granite_Golem, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petAncient_Rock_Golem, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petAncient_Rumblehide, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petAncient_Thunderhide, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petBoar, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petCentaur_Conqueror, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petCentaur_Courser, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petDark_Troll_Summoner, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petDeath_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petEarth_Brewmaster, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petEidolon, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petFamiliar, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petFell_Spirit, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petFire_Brewmaster, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petForged_Spirit, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petFrozen_Sigil, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petGhost, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petGiant_Wolf, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petGolem_Warlock, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHarpy_Scout, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHarpy_Stormcrafter, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHawk, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHealing_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHellbear, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHellbear_Smasher, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHill_Trll, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHill_Troll_Berserker, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHill_Troll_Priest, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petHoming_Missile, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petKobold, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petKobold_Foreman, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petKobold_Soldier, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petLand_Mine, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petLycan_Wolf, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petMega_Melee_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petMega_Ranged_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petMelee_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petMud_Golem, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petNecro_Archer, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petNecro_Warrior, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petNether_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petObserver_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petOgre_Bruiser, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petOgre_Frostmage, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petPhantomLancer, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petPhoenix_Sun, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petPlague_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petPower_Cog, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petPsionic_Trap, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petRanged_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petRemote_Mine, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSatyr_Banisher, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSatyr_Mindstealer, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSatyr_Tormentor, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSentry_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSerpent_Ward, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSiege_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSiege_Creep_Bonus, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSkeleton_Warrior, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSpiderite, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSpiderling, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSpirit, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSpirit_Bear, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petStasis_Trap, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petStorm_Brewmaster, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSuper_Melee_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petSuper_Ranged_Creep, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petTombstone, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petTornado, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petTreant, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petUndying_Zombie, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petVhoul_Assassin, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petWildwing, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.petWildwing_Ripper, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Phantasms, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.PhantomStrikeAttSpeedAdded, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Phase_Form, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.PoisonAttack, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.PrimaryStatDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.PrimaryStatDamageAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.PrimaryStatLossPercent, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.Pullback, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.PullForward, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Purge, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.PurgeFrequency, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.PushForward, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.PushSideways, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.QuasCyclone, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.QuasKnockback, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.QuasMoveSpeedPercentChange, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.QuillSprayCast, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RabidAttackSpeedAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.RabidDurationBonus, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RabidMoveSpeedAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.RandomTargetHealAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.RangeSlow, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.RangeStun, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.ReflectedDamageInflicted, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.Reincarnate, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RemoveBuffs, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RemoveDebuffs, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RemoveDisables, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.ReplacedByPets, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Replicant, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.RequiemDamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Reset_Cooldowns, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.ResourceShare, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickAttackAttackSlowInflicted, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickAttackDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickBonusDamageAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickBonusDamageInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickBonusPureDamageInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickBurnedMana, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickCausticFinale, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickCounterAttack, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageAsLine, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageAsPercOfTargetCurrHP, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageFromPrimaryAtt, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageInstanceAvoided, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageMultipleInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageMultiplier, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageoT, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamagePercentageInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamagePercentInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamagePercentSubtracted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageWithBuffs, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamageWithoutBuffs, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickDamPhysStackingInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickHealthasDamagePercInflicted, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickInttoPureDamage, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickMoonGlaiveBounces, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickMoveSpeedPercSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickNetherToxinDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickPureDamageInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.RightClickStun, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.RoshanArmorAddedPer4Min, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.RoshanHealthPer4MinAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.RoshanRClickAttackDamPer4MinAdded, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.RoshanSlamDamageTimeIncrease, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.SanitysManaPercentRemovedwithThreshold, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.SearingArrows, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.SelfDeny, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ShackleTime, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.ShadowPoisonStackDamage, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.ShallowGrave, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Shatter, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.Silence, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.Sleep, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.SpawnSpiderite, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.SpellBlock, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.SpellBlockDuration, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.StaticFieldHealthReduction, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.StaticLinkBonusDamage, mPhysicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.StaticStormDamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.StationaryInvisibility, mStealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.StealthVisibility, mStealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.StrAdded, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.StrIncrementAdded, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.StrAddedPerKill, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.StrengthPercentageAsAllDamage, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.StrengthPercentageCounterAttack, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.StroT, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.StrSubtracted, mStrColor)
    mColorForModifierType.AddorUpdate(eModifierType.Stun, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.StunChain, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.StunRandom, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Sunder, mHPRemovalColor)
    mColorForModifierType.AddorUpdate(eModifierType.SunStrikePureInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.TargetedDamageReflected, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Taunt, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.Teleport, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.TeleportRandom, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.TimeLapse, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.TinyTossBonusDamage, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.TinyTossDamageInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.Traptime, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.TrueFormHPAdded, mHealthColor)
    mColorForModifierType.AddorUpdate(eModifierType.Truesight, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.TruesightofTarget, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.TruesightRadius, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.TurnRateSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.UnobstructedMovementandVision, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.UnobstructedVision, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.VanguardMeleeBlockAdded, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.VanguardRangeblockAdded, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.Vision, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.VisionDay, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.VisionNight, mVisionNightColor)
    mColorForModifierType.AddorUpdate(eModifierType.VisionNightAdded, mVisionNightColor)
    mColorForModifierType.AddorUpdate(eModifierType.VoidMoveSpeedPercentSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.WallHeroReplica, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.Web, mPetColorSwatch)
    mColorForModifierType.AddorUpdate(eModifierType.WexAttackSpeedAdded, mAttSpeedColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexDamageMagicalInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexDamagePureInflicted, mPureColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexDisarm, mDefenseColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexManaRestored, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexMoveSpeedPercentChangeSubtracted, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexMoveSpeedPercentChangeAdded, mMoveColor)
    mColorForModifierType.AddorUpdate(eModifierType.WexVision, mVisionDayColor)
    mColorForModifierType.AddorUpdate(eModifierType.WitchcraftCooldownDecrease, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.WitchcraftManaCostDecrease, mManaColor)
    mColorForModifierType.AddorUpdate(eModifierType.WitchcraftSpiritIncrease, mMetaDataColor)
    mColorForModifierType.AddorUpdate(eModifierType.WrathofNatureMagicDamageBounceInflicted, mMagicalColor)
    mColorForModifierType.AddorUpdate(eModifierType.XPAdded, mXpColor)
    mColorForModifierType.AddorUpdate(eModifierType.BaseXP, mXpColor)
    mColorForModifierType.AddorUpdate(eModifierType.ZombiesPerUnit, mMetaDataColor)


  End Sub
  Private Sub LoadTeamColors()
    Dim R1color = Color.FromArgb(255, 27, 133, 249)
    mylistbyteampos.Add(R1color)

    Dim R2color = Color.FromArgb(255, 136, 82, 181)
    mylistbyteampos.Add(R2color)

    Dim R3color = Color.FromArgb(255, 177, 181, 47)
    mylistbyteampos.Add(R3color)

    Dim R4color = Color.FromArgb(255, 82, 93, 80)
    mylistbyteampos.Add(R4color)

    Dim R5color = Color.FromArgb(255, 229, 151, 68)
    mylistbyteampos.Add(R5color)

    Dim D1color = Color.FromArgb(255, 78, 218, 171)
    mylistbyteampos.Add(D1color)

    Dim D2color = Color.FromArgb(255, 148, 173, 219)
    mylistbyteampos.Add(D2color)

    Dim D3color = Color.FromArgb(255, 225, 41, 127)
    mylistbyteampos.Add(D3color)

    Dim D4color = Color.FromArgb(255, 206, 229, 177)
    mylistbyteampos.Add(D4color)

    Dim D5color = Color.FromArgb(255, 81, 211, 64)
    mylistbyteampos.Add(D5color)


  End Sub

#Region "Info"

  Public ReadOnly Property NeutralTeamColor As Color
    Get
      Return mNeutralTeamColor
    End Get
  End Property

  Public ReadOnly Property StrColor As Color
    Get
      Return mStrColor
    End Get
  End Property

  Public ReadOnly Property IntColor As Color
    Get
      Return mIntColor
    End Get
  End Property

  Public ReadOnly Property AgiColor As Color
    Get
      Return mAgiColor
    End Get
  End Property
  Public ReadOnly Property DayColor As Color
    Get
      Return mDayColor
    End Get
  End Property

  Public ReadOnly Property NightColor As Color
    Get
      Return mNightColor
    End Get
  End Property

  Public ReadOnly Property ScaleStrongFill As Color
    Get
      Return mScaleStrongFill
    End Get
  End Property

  Public ReadOnly Property ScaleWeakFill As Color
    Get
      Return mScaleWeakFill
    End Get
  End Property
  Public ReadOnly Property HoveredColor As Color
    Get
      Return mHoveredColor
    End Get
  End Property

  Public ReadOnly Property ScaleStrongColor As Color
    Get
      Return mScaleStrongColor
    End Get
  End Property

  Public ReadOnly Property ScaleWeakColor As Color
    Get
      Return mScaleWeakColor
    End Get
  End Property

  ''' <summary>
  ''' for things like creeps selected tab on ctrlherobadge
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property AccentedColor As Color
    Get
      Return mAccentedColor
    End Get
  End Property

  Public ReadOnly Property GraphDividerColor As Color
    Get
      Return mGraphDividerColor
    End Get
  End Property

  Public ReadOnly Property GraphedColor As Color
    Get
      Return mGraphedColor
    End Get
  End Property
  Public ReadOnly Property BarRectDividerColor As Color
    Get
      Return mBarRectDividerColor
    End Get
  End Property
  Public ReadOnly Property DarkenOverlay As Color
    Get
      Return mDarkenOverlay
    End Get
  End Property
  Public ReadOnly Property SelectedColor As Color
    Get
      Return mSelectedColor
    End Get
  End Property

  Public ReadOnly Property PetColor As Color
    Get
      Return mPetColorSwatch
    End Get
  End Property
  Public ReadOnly Property TrasparencyGlobalValue As Integer
    Get
      Return mTransparency
    End Get
  End Property
  Public ReadOnly Property ButtonColorSelected As Color
    Get
      Return mBtnColorSelected
    End Get
  End Property

  Public ReadOnly Property ButtonColorNotSelected As Color
    Get
      Return mBtnColorNotSelected
    End Get
  End Property

  Public ReadOnly Property MagicalColor As Color
    Get
      Return mMagicalColor
    End Get
  End Property

  Public ReadOnly Property PhysicalColor As Color
    Get
      Return mPhysicalColor
    End Get
  End Property

  Public ReadOnly Property PureColor As Color
    Get
      Return mPureColor
    End Get
  End Property

  Public ReadOnly Property BackgroundColor As Color
    Get
      Return mBackgroundColor
    End Get
  End Property
  Public ReadOnly Property BodyTextColor As Color
    Get
      Return mBodyTextColor
    End Get
  End Property

  Public ReadOnly Property HeadingTextColor As Color
    Get
      Return mHeadingTextColor
    End Get
  End Property

  Public ReadOnly Property SubHeadingTextColor As Color
    Get
      Return mSubHeadingTextColor
    End Get
  End Property
  Public ReadOnly Property CommentaryTextColor As Color
    Get
      Return mCommentaryTextColor
    End Get
  End Property

  Public ReadOnly Property UltimateTextColor As Color
    Get
      Return mUlitmateTextColor
    End Get
  End Property
  Public ReadOnly Property ValueTextColor As Color
    Get
      Return mValueTextColor
    End Get
  End Property

  Public ReadOnly Property ErrorColor As Color
    Get
      Return mErrorColor
    End Get
  End Property

  Public ReadOnly Property RadiantColor As Color
    Get
      Return mRadiantColor
    End Get
  End Property

  Public ReadOnly Property RadiantAccentColor As Color
    Get
      Return mRadianAccentColor
    End Get
  End Property
  Public ReadOnly Property DireColor As Color
    Get
      Return mDireColor
    End Get
  End Property

  Public ReadOnly Property DireAccentColor As Color
    Get
      Return mDireAccentColor
    End Get
  End Property

  Public ReadOnly Property Transparent As Color
    Get
      Return mTransparent
    End Get
  End Property

#End Region

#Region "GetColor"
  Public Function GetTeamColor(theteam As eTeamName, heroposition As Integer) As Color
    Select Case theteam
      Case eTeamName.Radiant
        If heroposition < 5 Then
          Return mylistbyteampos.Item(heroposition)
        Else
          Return Nothing
        End If

      Case eTeamName.Dire
        If heroposition < 5 Then

          Return mylistbyteampos.Item(heroposition + 5)
        Else
          Return Nothing
        End If
      Case Else
        Dim x = 2


    End Select
  End Function
  Public Function GetColor(gameent As iGameEntity) As Color
    If gameent Is Nothing Then Return mBackgroundColor
    Select Case gameent.MyType
      Case eSourceType.Item_Info
        Dim item As Item_Info = gameent
        Return GetColor(item.ItemName)
      Case eSourceType.Ability_Info
        Dim ab As Ability_Info = gameent
        Return GetColor(ab.AbilityName)
      Case eSourceType.Hero_Instance
        Dim hero As HeroInstance = gameent
        Return GetColor(hero.HeroName)
      Case eSourceType.Creep_Instance
        Dim creep As Creep_Instance = gameent
        Return GetColor(creep.CreepName)
      Case eSourceType.Pet_Instance
        Dim pet As Pet_Instance = gameent
        Return GetColor(pet.PetName)
      Case eSourceType.Team
        Dim team As dTeam = gameent
        Return team.MyColor
      Case Else
        GetColor(gameent.Id)
    End Select

    Return ErrorColor
  End Function

  Public Function GetColor(creepname As eCreepName) As Color
    Dim outcolor = mColorForCreepName.ValueForKey(creepname)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function

  Public Function GetColor(petname As ePetName) As Color
    Dim outcolor = mColorForPetName.ValueForKey(petname)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function

  Public Function GetColor(id As dvID) As Color
    Dim outcolor = mColorForID.ValueForKey(id.GuidID)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function

  Public Function GetColor(heroname As eHeroName) As Color
    Dim outcolor = mColorForHeroName.ValueForKey(heroname)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function
  Public Function GetColor(itemname As eItemname) As Color
    Dim outcolor = mColorForItemName.ValueForKey(itemname)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function
  Public Function GetColor(stattype As eStattype) As Color
    Dim outcolor = mColorForStatType.ValueForKey(stattype)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function

  Public Function GetColor(abilityname As eAbilityName) As Color
    Dim outcolor = mColorForAbilityName.ValueForKey(abilityname)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function

  Public Function GetColor(modtype As eModifierType) As Color
    Dim outcolor = mColorForModifierType.ValueForKey(modtype)

    If outcolor = Nothing Then Throw New NotImplementedException

    Return outcolor
  End Function



  Public Function GetColorForDamageType(thedam As eDamageType) As Color
    Select Case thedam

      Case eDamageType.Magical
        Return MagicalColor 'New SolidColorBrush(Color.FromArgb(255, 221, 198, 7))
      Case eDamageType.None
        Return ErrorColor 'New SolidColorBrush(Color.FromArgb(255, 221, 198, 7))
      Case eDamageType.Physical
        Return PhysicalColor
      Case eDamageType.Pure
        Return PureColor

      Case Else
        mLog.Writelog(thedam.ToString & " not implemented in dbcolors.getcolorfordamagetype")
        Return ErrorColor
    End Select

  End Function
#End Region

#Region "AddColor"

  Public Sub AddColor(petname As ePetName, col As Color)
    mColorForPetName.AddorUpdate(petname, col)
  End Sub
  Public Sub AddColor(creepname As eCreepName, col As Color)
    mColorForCreepName.AddorUpdate(creepname, col)
  End Sub
  Public Sub AddColor(abilityname As eAbilityName, col As Color)
    mColorForAbilityName.AddorUpdate(abilityname, col)
  End Sub

  Public Sub AddColor(heroname As eHeroName, col As Color)
    mColorForHeroName.AddorUpdate(heroname, col)
  End Sub

  Public Sub AddColor(itemname As eItemname, col As Color)
    mColorForItemName.AddorUpdate(itemname, col)
  End Sub

  Public Sub AddColor(gameent As iGameEntity, col As Color)
    Select Case gameent.MyType
      Case eSourceType.Item_Info
        Dim item As Item_Info = gameent
        AddColor(item.ItemName, col)
      Case eSourceType.Ability_Info
        Dim ab As Ability_Info = gameent
        AddColor(ab.AbilityName, col)
      Case eSourceType.Hero_Instance
        Dim hero As HeroInstance = gameent
        AddColor(hero.HeroName, col)
      Case eSourceType.Pet_Instance
        Dim pet As Pet_Instance = gameent
        AddColor(pet.PetName, col)
      Case eSourceType.Creep_Instance
        Dim creep As Creep_Instance = gameent
        AddColor(creep.CreepName, col)
      Case Else
        mColorForID.AddorUpdate(gameent.Id.GuidID, col)

    End Select
  End Sub

#End Region

  'Public Function GetColorFromUri(theurl As String) As Color
  '  If Not mydictbyurl.ContainsKey(theurl) Then
  '    'Return New color(Color.FromArgb(255, 255, 255, 255))

  '    Return ErrorColor
  '  Else
  '    Return mydictbyurl.Item(theurl)
  '  End If
  'End Function

  'Public Sub AddColorForURL(theurl As String, thecolor As Color)
  '  If Not mydictbyurl.ContainsKey(theurl) Then
  '    mydictbyurl.Add(theurl, thecolor)
  '  Else
  '    mydictbyurl.Remove(theurl)
  '    mydictbyurl.Add(theurl, thecolor)
  '  End If
  'End Sub





  'Public Function GetColorFromIDItem(theiditem As dvID) As Color

  '  If Not mydictbyiditem.ContainsKey(theiditem) Then
  '    'Return New color(Color.FromArgb(255, 255, 255, 255))
  '    Return ErrorColor
  '  Else
  '    Return mydictbyiditem.Item(theiditem)
  '  End If
  'End Function
 



End Class
