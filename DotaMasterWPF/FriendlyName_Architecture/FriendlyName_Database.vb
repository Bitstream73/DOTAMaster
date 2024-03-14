Public Class FriendlyName_Database


  Private mLog As Logging
  Private mAbilityNames As OneToOneDoubleDictionary(Of eAbilityName, String)

  Private mCreepNames As OneToOneDoubleDictionary(Of eCreepName, String)
  Private mPetNames As OneToOneDoubleDictionary(Of ePetName, String)

  Private mStatNames As OneToOneDoubleDictionary(Of eStattype, String)
  Private mModNames As OneToOneDoubleDictionary(Of eModifierType, String)
  Private mDamageNames As OneToOneDoubleDictionary(Of eDamageType, String)
  Private mAbilityTypeNames As OneToOneDoubleDictionary(Of eAbilityType, String)
  Private mItemPlanNames As OneToOneDoubleDictionary(Of eItemPlan, String)
  Private mUnitNames As OneToOneDoubleDictionary(Of eUnit, String)

  Private mSourceNames As OneToOneDoubleDictionary(Of eSourceType, String)
  Private mValueFormatsForMods As OneToOneDoubleDictionary(Of eModifierType, eValueFormat)
  Private mValueFormatsForStats As OneToOneDoubleDictionary(Of eStattype, eValueFormat)
  Public Sub New(thelog As Logging)
    mLog = thelog
    '  LoadAbilityNames()
    LoadCreepNames()
    LoadPetNames()
    LoadStatNames()
    LoadModifierNames()
    LoadDamageNames()
    LoadAbilityTypeNames()
    LoadItemPlanNames()
    LoadUnitNames()

    LoadSourceNames()

    LoadValueFormatsForMods()
    LoadValueFormatsForStats()
  End Sub

#Region "Gets"
  'Public Function GetFriendlyAbilityName(abname As eAbilityName) As String
  '  Dim outname = mAbilityNames.ValuesForKey(abname)

  '  If Not outname = Nothing Then
  '    Return outname
  '  End If
  '  Return abname.ToString

  'End Function

  Public Function GetFriendlyValueFormat(stattype As eStattype) As eValueFormat
    Dim outname = mValueFormatsForStats.ValueForKey(stattype)

    If Not outname = Nothing Then
      Return outname
    End If
    Throw New NotImplementedException
  End Function

  Public Function GetFriendlyValueFormat(modtype As eModifierType) As eValueFormat
    Dim outname = mValueFormatsForMods.ValueForKey(modtype)

    If Not outname = Nothing Then
      Return outname
    End If
    Throw New NotImplementedException
  End Function
  Public Function GetFriendlyCreepName(creepname As eCreepName) As String
    Dim outname = mCreepNames.ValueForKey(creepname)

    If Not outname = Nothing Then
      Return outname
    End If
    Return creepname.ToString
  End Function

  Public Function GetFriendlyPetName(petname As ePetName) As String
    Dim outname = mPetNames.ValueForKey(petname)

    If Not outname = Nothing Then
      Return outname
    End If
    Return petname.ToString
  End Function

  Public Function GetFriendlySourceName(sourcename As eSourceType) As String
    Dim outname = mSourceNames.ValueForKey(sourcename)

    If Not outname = Nothing Then
      Return outname
    End If
    Return sourcename.ToString
  End Function
  Public Function GetFriendlyStatName(stat As eStattype) As String
    Dim outname = mStatNames.ValueForKey(stat)

    If Not outname = Nothing Then
      Return outname
    End If
    Return stat.ToString
  End Function

  Public Function GetFriendlyModifierName(modtype As eModifierType) As String
    Dim outname = mModNames.ValueForKey(modtype)

    If Not outname = Nothing Then
      Return outname
    End If
    Return modtype.ToString
  End Function

  Public Function GetFriendlyDamageType(dam As eDamageType) As String
    Dim outname = mDamageNames.ValueForKey(dam)

    If Not outname Is Nothing Then
      Return outname
    End If

    Return dam.ToString
  End Function

  Public Function GetFriendlyAbilityType(thetype As eAbilityType) As String
    Dim outname = mAbilityTypeNames.ValueForKey(thetype)

    If Not outname Is Nothing Then
      Return outname
    End If

    Return thetype.ToString
  End Function

  Public Function GetFriendlyNameforEItemPlan(theplan As eItemPlan) As String
    Dim outname = mItemPlanNames.ValueForKey(theplan)

    If Not outname Is Nothing Then
      Return outname
    End If
    Return theplan.ToString
  End Function

  Public Function GetFriendlyUnitName(theunit As eUnit) As String
    Dim outname = mUnitNames.ValueForKey(theunit)

    If Not outname Is Nothing Then
      Return outname
    End If
    Return theunit.ToString
  End Function
#End Region

#Region "Loads"
  Public Sub LoadValueFormatsForStats()
    mValueFormatsForStats = New OneToOneDoubleDictionary(Of eStattype, eValueFormat)(mLog)

    mValueFormatsForStats.AddorUpdate(eStattype.None, eValueFormat.None)
    mValueFormatsForStats.AddorUpdate(eStattype.Agility, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.AllDamageAvg, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.AllDamageBurst, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.ArmorxPoint06, eValueFormat.NotForDisplay)
    mValueFormatsForStats.AddorUpdate(eStattype.AttackDamageAverage, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.AttackDamageHigh, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.AttackDamageLow, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.AttackRange, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.AttackSpeed, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.BaseAttackTime, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.CritChance, eValueFormat.Percent)
    mValueFormatsForStats.AddorUpdate(eStattype.CritMultiplier, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.CritDamage, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.EffectiveHP, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Experience, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Hex, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.HexAvg, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.HitPointRegen, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.HitPoints, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.HPRemoval, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Intelligence, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Kills, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.MagicalDamageResistance, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.MagicDamage, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.MagicDamageAvg, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.MagicImmunity, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.MagicImmunityAvg, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.Mana, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.ManaRegen, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.MissileSpeed, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.MovementSpeed, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Networth, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Number1, eValueFormat.NotForDisplay)
    mValueFormatsForStats.AddorUpdate(eStattype.NumberPoint06, eValueFormat.NotForDisplay)
    mValueFormatsForStats.AddorUpdate(eStattype.PeriodicGold, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PhysicalArmor, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PhysicalDamage, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PhysicalDamageAmplification, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PhysicalDamageAvg, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PhysicalDamageNegation, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PhysicalDamageReduction, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PrimaryAttribute, eValueFormat.NotForDisplay)
    mValueFormatsForStats.AddorUpdate(eStattype.PureDamage, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.PureDamageAvg, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Resources, eValueFormat.Percent)
    mValueFormatsForStats.AddorUpdate(eStattype.SpellImmunityCount, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Stealth, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.StealthTime, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.Strength, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.Stun, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.StunAvg, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.TrueSight, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TurnRate, eValueFormat.DecimalNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.VisionDay, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.VisionNight, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamKills, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlEffectiveHP, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlDamageHi, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlDamageLo, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlDamageAvg, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlHP, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlHPRegen, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlMana, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlManaRegen, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlVisionDay, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlVisionNight, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlDPSPeak, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlDPSAvg, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlPhysDamageBurst, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlPhysDPSAvg, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlMagDamageBurst, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlMagDPSAvg, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlPureDamageBurst, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlPureDPSAvg, eValueFormat.ValuePerSecond)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlStunDuratoin, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlHexDuration, eValueFormat.DurationInSeconds)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamTtlSpellImmunityCount, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamPhysicalArmor, eValueFormat.WholeNumber)
    mValueFormatsForStats.AddorUpdate(eStattype.TeamMagicResistance, eValueFormat.DurationInSeconds)

  End Sub
  Public Sub LoadValueFormatsForMods()
    mValueFormatsForMods = New OneToOneDoubleDictionary(Of eModifierType, eValueFormat)(mLog)

    mValueFormatsForMods.AddorUpdate(eModifierType.None, eValueFormat.None)
    mValueFormatsForMods.AddorUpdate(eModifierType.AbilityEffectiveHp, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AbilitySteal, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AdaptiveStrikeDamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AdaptiveStrikeStun, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.AgiAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AgioT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.AgiPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.AgiSubtracted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArcaneOrb, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorAddedPerSec, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmoroT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorPercentage, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorStackSubtracted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorSubtracted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorSubtractedoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ArmorxPoint06, eValueFormat.NotForDisplay)
    mValueFormatsForMods.AddorUpdate(eModifierType.AstralSpiritDamageMagicalAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AstralSpiritMoveSpeedPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.AstrlImpIntStolen, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedAddedPerHeroPerMissHP, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedAddedtoXAttacks, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedPercentofTargetAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedPercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackSpeedStackAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AttackspeedSubtracted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BackstabRightclickDamageAddedAsPercofAgi, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BallLightDamMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BallLightPushForward, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Barrier, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAgi, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAttackRange, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.AgiIncrementAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseandBonusDamageReduction, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseArmor, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseArmorDebuff, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseArmorPercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAttackTime, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAttackTimeChangedTo, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAttackDamageHigh, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAttackDamageLow, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseAttackDamageAvg, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseInt, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseMagicResistance, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseMagicResistancePercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseMana, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseMovementSpeed, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseStr, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseTurnRate, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Bash, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BearBonusDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BearMoveSpeedAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BerserkersBonusAttackSpeed, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BerserkersBonusMagicResistance, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BlindChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.BlindDuration, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.BonusDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BonusDamageoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.BonusDamagePercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.BonusGold, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BountyGold, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BuildingAttackSpeedPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.CausticFinale, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ChainLightning, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ChenAncientCount, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ChenCreepFullHeal, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.CleavePercentage, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.ColdAttack, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ConjuredImage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Consumption, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ControlledCreepHealthBonus, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Corruption, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.CreepControlled, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.CripplingFearMissChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.CritChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.CritDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.CritMultiplier, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Cyclone, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageAbsorbedForMana, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageAllTypesIncomingIncreasesPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageAllTypesPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageAllTypesStackAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageAmplification, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageBlock, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageBlockRemoved, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageBothBlockAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageChainMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageChainPhysicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageDelay, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageIncreasePercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageInstanceBlock, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageLost, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalAbsorbed, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalAddedToPhysicalAttacks, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalBouncesInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalChain, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalEarthSplitterAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalImmunity, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalInflictedOnSpellCast, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalInflictedPerAlly, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalInflictedPerTarget, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalInflictedPerUnit, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalInflictedUntilSpellcast, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalMinMaxInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicaloTAsMultofStr, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalOverTimeInflicted, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalPerCreep, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalPerHero, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalPerMissingHP, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalPerMissingMana, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalPerSec, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalRandomInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMagicalTimesInt, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMeleeAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMeleeBlockAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageMeleemultiplier, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageoTMagicalInflicted, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.damagePerSecond, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalBouncesInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalEarthSplitterAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalImmunity, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalIncomingIncreasedPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicaloT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalPerSec, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalStackingInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePhysicalSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePierceAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePierceChancePercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureAsPercentofManaPool, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureAsPercentofMaxHP, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureoTasPercofMaxHP, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureoTInflicted, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePurePercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagePureRandomInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageRangeAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageRangeBlockAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageRangemultiplier, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageReduction, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageReturnDuration, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamagetoHealPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DamageTransferedToCaster, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DarknessNight, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.DeathlustAttackSpeedAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DeathlustMoveSpeedPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DestroysCreep, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DestroysHero, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DestroysHeroBelowThreshold, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DestroysTree, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Disarm, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DisarmMelee, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.DisarmRange, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DisjointRange, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Dispel, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DisruptionIllusion, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Dominate, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.DuelBonusDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ElderDragonForm, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Ensnare, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Entangle, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.EssenceAuraManaRestored, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Ethereal_Time, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.EvasionPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.EvasionRemoved, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.EvilSpirits, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ExortDamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ExortDamageMagicalInflictedoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ExortRightClickBonusDamageAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.FadeBoltDamageMagicalBounces, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Feedback, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.FrostArrows, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Ghost_Form_Time, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.GlaivesWisdom, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.GreaterBashofCurrentLevel, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Haunt, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAddedAsPercOfTargetCurrHP, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAddedoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAddedoTAsPercofMaxHP, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAddedPerDeadCreep, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAddedPerDeadHero, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAddedPerUnit, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealAsPercentofHP, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealFriendlyorDamageEnemy, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealFriendlyorMagicDamEnemyoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealMinMaxAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealoTSetTo, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealPercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealthFullyRestored, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealthPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealthRegenAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HealthvalueFrozen, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HeroDamageReducedTo, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HeroReflection, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Hex, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRegenAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRegenSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRegenPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRegenPercentofCasters, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRegenPerUnitKilledAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRemoval, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRemovalAsPercentofMoveDist, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPRemovalSharedWithBoundUnits, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.HPSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.IllusionDamageReducedTo, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Impetus, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ImpetusDamagePureInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.IncapBite, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.InfestCreepHeal, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.InnerVitalityPercentHealAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.IntAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.IntIncrementAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.IntoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.IntPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.IntSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Invisibility, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.InvisibilityWhenNotAttacking, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.InvokeASpell, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.InvokeSpellCount, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Invulnerability, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.ItemEffectiveHP, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.KillsPerGoldIncrement, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Knockback, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.KotLSpiritForm, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LastHitGoldAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LastHitGoldBonusPerStack, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Leap, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LifeDrainDrainfromTarget, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.LifeDrainPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.LifeDrainSelfEffect, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.LifeStealAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LifestealAddedtoAllAttackers, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LifeStealPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.LiquidFire, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LostHealthDamagePercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.LucentBeamHits, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.LvlDeathDamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicDamageReceivedMultiplier, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicImmunity, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicResistanceAdded, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicResistanceCapped, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicResistancePercentAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicResistancePercentSubtracted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicResistanceSet, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagicResistanceSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MagnatizeDamageOverTime, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.MaimChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaBreak, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaBurnDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaBurnManaremoved, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaDrained, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaDrainedUntilSpellcast, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaoTSubtracted, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaPercentDrained, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRegenAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRegenSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRegenPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRegenPercentofCasters, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRegenPerUnitKillAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRemoved, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRemovedoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRemovedPercentoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRestored, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MaxManaAdded, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRestoredAsPercentOfHP, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ManaRestoredPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MantaMeleeIllusionDamagePercentage, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MantaRangeIllusionDamagePercentage, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MeepoClone, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MeleeSlow, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MeleeStun, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MeltingStrike, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MidnightPulsePureDamageAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Minibash_Damage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MiniMapInvisibility, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.MiniStun, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MirrorImage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MissChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MissileSpeed, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedMinimum, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercentAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.rightclickdamageaddedperherobelow75perchealth, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercentAsDamage, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercentofTargetAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercentStackSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedPercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedSet, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedStackAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MoveSpeedSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastBloodlustCoolReduction, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastBloodlustRadiusAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastFireblastCoolReduction, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastFireblastManaAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastFourXChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastIgniteCastRangeAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastIgniteRadius, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastThreeXChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MulticastTwoXChance, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteAbilities, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteAllOnTarget, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteAttacks, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteBlink, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteInvisibility, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteItems, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteMove, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteRightClick, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteTargetability, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteTeleport, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MuteTurn, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.MysticSnakeDamageAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MysticSnakeManaAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.MysticSnakeManaSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseGold, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.NightAttackSpeedAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.NightAttackSpeedSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.NightMoveSpeedAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Number1, eValueFormat.NotForDisplay)
    mValueFormatsForMods.AddorUpdate(eModifierType.NumberPoint06, eValueFormat.NotForDisplay)
    mValueFormatsForMods.AddorUpdate(eModifierType.OpenWoundsSlowInflicted, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.PackleaderRClickDamageAsPercofBaseDamandPrimaryStat, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.PauseTime, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.PercentofCreepHealthGained, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.PeriodicGold, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAlpha_Wolf, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAncient_Black_Dragon, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAncient_Black_Drake, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAncient_Granite_Golem, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAncient_Rock_Golem, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAncient_Rumblehide, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petAncient_Thunderhide, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petBoar, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petCentaur_Conqueror, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petCentaur_Courser, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petDark_Troll_Summoner, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petDeath_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petEarth_Brewmaster, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petEidolon, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petFamiliar, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petFell_Spirit, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petFire_Brewmaster, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petForged_Spirit, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petFrozen_Sigil, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petGhost, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petGiant_Wolf, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petGolem_Warlock, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHarpy_Scout, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHarpy_Stormcrafter, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHawk, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHealing_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHellbear, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHellbear_Smasher, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHill_Trll, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHill_Troll_Berserker, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHill_Troll_Priest, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petHoming_Missile, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petKobold, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petKobold_Foreman, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petKobold_Soldier, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petLand_Mine, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petLycan_Wolf, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petMega_Melee_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petMega_Ranged_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petMelee_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petMud_Golem, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petNecro_Archer, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petNecro_Warrior, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petNether_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petObserver_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petOgre_Bruiser, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petOgre_Frostmage, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petPhantomLancer, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petPhoenix_Sun, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petPlague_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petPower_Cog, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petPsionic_Trap, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petRanged_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petRemote_Mine, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSatyr_Banisher, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSatyr_Mindstealer, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSatyr_Tormentor, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSentry_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSerpent_Ward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSiege_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSiege_Creep_Bonus, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSkeleton_Warrior, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSpiderite, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSpiderling, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSpirit, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSpirit_Bear, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petStasis_Trap, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petStorm_Brewmaster, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSuper_Melee_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petSuper_Ranged_Creep, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petTombstone, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petTornado, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petTreant, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petUndying_Zombie, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petVhoul_Assassin, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petWildwing, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.petWildwing_Ripper, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.Phantasms, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.PhantomStrikeAttSpeedAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Phase_Form, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.PoisonAttack, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.PrimaryStatDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.PrimaryStatDamageAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.PrimaryStatLossPercent, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.Pullback, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.PullForward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.Purge, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.PurgeFrequency, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.PushForward, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.PushSideways, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.QuasCyclone, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.QuasKnockback, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.QuasMoveSpeedPercentChange, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.QuillSprayCast, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RabidAttackSpeedAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RabidDurationBonus, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.RabidMoveSpeedAdded, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RandomTargetHealAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RangeSlow, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RangeStun, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.ReflectedDamageInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Reincarnate, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.RemoveBuffs, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.RemoveDebuffs, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.RemoveDisables, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.ReplacedByPets, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Replicant, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.RequiemDamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Reset_Cooldowns, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.ResourceShare, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickAttackAttackSlowInflicted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickAttackDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickBonusDamageAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickBonusDamageInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickBonusPureDamageInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickBurnedMana, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickCausticFinale, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickCounterAttack, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageAsLine, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageAsPercOfTargetCurrHP, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageFromPrimaryAtt, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageInstanceAvoided, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageMultipleInflicted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageMultiplier, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageMultiplier, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageoT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamagePercentageInflicted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamagePercentInflicted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamagePercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageWithBuffs, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamageWithoutBuffs, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickDamPhysStackingInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickHealthasDamagePercInflicted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickInttoPureDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickMoonGlaiveBounces, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickMoveSpeedPercSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickNetherToxinDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickPureDamageInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RightClickStun, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.RoshanArmorAddedPer4Min, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RoshanHealthPer4MinAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RoshanRClickAttackDamPer4MinAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.RoshanSlamDamageTimeIncrease, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.SanitysManaPercentRemovedwithThreshold, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.SearingArrows, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.SelfDeny, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.ShackleTime, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.ShadowPoisonStackDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ShallowGrave, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Shatter, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Silence, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Sleep, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.SpawnSpiderite, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.SpellBlock, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.SpellBlockDuration, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.StaticFieldHealthReduction, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StaticLinkBonusDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StaticStormDamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StationaryInvisibility, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.StealthVisibility, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.StrAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StrIncrementAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StrAddedPerKill, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StrengthPercentageAsAllDamage, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.StrengthPercentageCounterAttack, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.StroT, eValueFormat.ValuePerSecond)
    mValueFormatsForMods.AddorUpdate(eModifierType.StrSubtracted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Stun, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.StunChain, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.StunRandom, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Sunder, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.SunStrikePureInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.TargetedDamageReflected, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Taunt, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Teleport, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.TeleportRandom, eValueFormat.TrueFalse)
    mValueFormatsForMods.AddorUpdate(eModifierType.TimeLapse, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.TinyTossBonusDamage, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.TinyTossDamageInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Traptime, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.TrueFormHPAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.Truesight, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.TruesightofTarget, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.TruesightRadius, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.TurnRateSubtracted, eValueFormat.DecimalNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.UnobstructedMovementandVision, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.UnobstructedVision, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.VanguardMeleeBlockAdded, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.VanguardRangeblockAdded, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Vision, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.VisionDay, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.VisionNight, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.VisionNightAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.VoidMoveSpeedPercentSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.WallHeroReplica, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.Web, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexAttackSpeedAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexDamageMagicalInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexDamagePureInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexDisarm, eValueFormat.DurationInSeconds)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexManaRestored, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexMoveSpeedPercentChangeSubtracted, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexMoveSpeedPercentChangeAdded, eValueFormat.Percent)
    mValueFormatsForMods.AddorUpdate(eModifierType.WexVision, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WitchcraftCooldownDecrease, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WitchcraftManaCostDecrease, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WitchcraftSpiritIncrease, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.WrathofNatureMagicDamageBounceInflicted, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.XPAdded, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.BaseXP, eValueFormat.WholeNumber)
    mValueFormatsForMods.AddorUpdate(eModifierType.ZombiesPerUnit, eValueFormat.WholeNumber)

  End Sub
  Public Sub LoadSourceNames()
    mSourceNames = New OneToOneDoubleDictionary(Of eSourceType, String)(mLog)

    mSourceNames.AddorUpdate(eSourceType.None, "")
    mSourceNames.AddorUpdate(eSourceType.Build, "Build")
    mSourceNames.AddorUpdate(eSourceType.Hero, "Hero")
    mSourceNames.AddorUpdate(eSourceType.HeroBuild, "HeroBuild")
    mSourceNames.AddorUpdate(eSourceType.Pet_Instance, "Pet")
    mSourceNames.AddorUpdate(eSourceType.Pet_Stack, "Pets")
    mSourceNames.AddorUpdate(eSourceType.Version, "Version")
    mSourceNames.AddorUpdate(eSourceType.BarGraph, "Graph")
    mSourceNames.AddorUpdate(eSourceType.Game, "Game")
    mSourceNames.AddorUpdate(eSourceType.Team, "Team")
    mSourceNames.AddorUpdate(eSourceType.Hero_Instance, "Hero")
    mSourceNames.AddorUpdate(eSourceType.Item_Info, "Item")
    mSourceNames.AddorUpdate(eSourceType.Ability_Info, "Ability")
    mSourceNames.AddorUpdate(eSourceType.Modifier, "Component")
    mSourceNames.AddorUpdate(eSourceType.Stat, "Attribute")
    mSourceNames.AddorUpdate(eSourceType.Creep_Instance, "Creep")
    mSourceNames.AddorUpdate(eSourceType.Creep_Stack, "Creeps")
    mSourceNames.AddorUpdate(eSourceType.Control, "Control")
    mSourceNames.AddorUpdate(eSourceType.GameEntity_Tuple, "Pair")

  End Sub

  Public Sub LoadPetNames()
    mPetNames = New OneToOneDoubleDictionary(Of ePetName, String)(mLog)
    mPetNames.AddorUpdate(ePetName.untHawk, "Hawk")
    mPetNames.AddorUpdate(ePetName.untBoar, "Boar")
    mPetNames.AddorUpdate(ePetName.untLycan_Wolf, "Wolf")
    mPetNames.AddorUpdate(ePetName.untUndying_Zombie, "Zombie")
    mPetNames.AddorUpdate(ePetName.untSpiderling, "Spiderling")
    mPetNames.AddorUpdate(ePetName.untSpiderite, "Spiderite")
    mPetNames.AddorUpdate(ePetName.untTreant, "Treant")
    mPetNames.AddorUpdate(ePetName.untEidolon, "Eidolon")
    mPetNames.AddorUpdate(ePetName.untForged_Spirit, "Forged Spirit")
    mPetNames.AddorUpdate(ePetName.untEarth_Brewmaster, "Earth")
    mPetNames.AddorUpdate(ePetName.untStorm_Brewmaster, "Storm")
    mPetNames.AddorUpdate(ePetName.untFire_Brewmaster, "Fire")
    mPetNames.AddorUpdate(ePetName.untGolem_Warlock, "Golem")
    mPetNames.AddorUpdate(ePetName.untSpirit_Bear, "Spirit Bear")
    mPetNames.AddorUpdate(ePetName.untFamiliar, "Familiar")
    mPetNames.AddorUpdate(ePetName.untPlague_Ward, "Plague Ward")
    mPetNames.AddorUpdate(ePetName.untSerpent_Ward, "Serpent Ward")
    mPetNames.AddorUpdate(ePetName.untDeath_Ward, "Death Ward")
    mPetNames.AddorUpdate(ePetName.untHealing_Ward, "Healing Ward")
    mPetNames.AddorUpdate(ePetName.untFrozen_Sigil, "Frozen Sigil")
    mPetNames.AddorUpdate(ePetName.untTornado, "Tornado")
    mPetNames.AddorUpdate(ePetName.untPsionic_Trap, "Psionic Trap")
    mPetNames.AddorUpdate(ePetName.untLand_Mine, "Land Mine")
    mPetNames.AddorUpdate(ePetName.untStasis_Trap, "Stasis Trap")
    mPetNames.AddorUpdate(ePetName.untRemote_Mine, "Remote Mine")
    mPetNames.AddorUpdate(ePetName.untNether_Ward, "Nether Ward")
    mPetNames.AddorUpdate(ePetName.untPower_Cog, "Power Cog")
    mPetNames.AddorUpdate(ePetName.untTombstone, "Tombstone")
    mPetNames.AddorUpdate(ePetName.untPhoenix_Sun, "Phoenix Sun")
    mPetNames.AddorUpdate(ePetName.untObserver_Ward, "Observer Ward")
    mPetNames.AddorUpdate(ePetName.untSentry_Ward, "Sentry Ward")
    mPetNames.AddorUpdate(ePetName.untBeetle, "Beetle")
    mPetNames.AddorUpdate(ePetName.untSpin_Web, "Spin Web")
    mPetNames.AddorUpdate(ePetName.untHoming_Missile, "Homing Missile")
    mPetNames.AddorUpdate(ePetName.untAstral_Spirit, "Astral Spirit")
    mPetNames.AddorUpdate(ePetName.untSpirit, "Spirit")
    mPetNames.AddorUpdate(ePetName.untPet_Phantom_Lancer, "Illusion")
    mPetNames.AddorUpdate(ePetName.untMeepo_Clone, "Clone")
    mPetNames.AddorUpdate(ePetName.untNaga_Siren_Illusion, "Illusion")
    mPetNames.AddorUpdate(ePetName.untDragonKnight_Elder_Dragon_Form, "Elder Dragon Form")
    mPetNames.AddorUpdate(ePetName.untMorphling_Replicant, "Replicant")
    mPetNames.AddorUpdate(ePetName.untTerrorblade_Reflection, "Reflection")
    mPetNames.AddorUpdate(ePetName.untTerrorblade_Illusion, "Illusion")
    mPetNames.AddorUpdate(ePetName.untTerrorblade_Demon, "Demon")
  End Sub
  Public Sub LoadCreepNames()
    mCreepNames = New OneToOneDoubleDictionary(Of eCreepName, String)(mLog)

    mCreepNames.AddorUpdate(eCreepName.untSkeleton_Warrior, "Skeleton Warrior")
    mCreepNames.AddorUpdate(eCreepName.untNecro_Warrior, "Necronomicon Warrior")
    mCreepNames.AddorUpdate(eCreepName.untNecro_Archer, "Necronomicon Warrior")

    mCreepNames.AddorUpdate(eCreepName.untMelee_Creep, "Melee Creep")
    mCreepNames.AddorUpdate(eCreepName.untSuper_Melee_Creep, "Super Melee Creep")
    mCreepNames.AddorUpdate(eCreepName.untMega_Melee_Creep, "Mega Melee Creep")
    mCreepNames.AddorUpdate(eCreepName.untRanged_Creep, "Ranged Creep")
    mCreepNames.AddorUpdate(eCreepName.untSuper_Ranged_Creep, "Super Ranged Creep")
    mCreepNames.AddorUpdate(eCreepName.untMega_Ranged_Creep, "Mega Ranged Creep")
    mCreepNames.AddorUpdate(eCreepName.untSiege_Creep, "Siege Creep")
    mCreepNames.AddorUpdate(eCreepName.untSiege_Creep_Bonus, "Siege Creep Bonus Damage")
    mCreepNames.AddorUpdate(eCreepName.untKobold, "Kobold")
    mCreepNames.AddorUpdate(eCreepName.untKobold_Soldier, "Kobold Soldier")
    mCreepNames.AddorUpdate(eCreepName.untKobold_Foreman, "Kobold Foreman")
    mCreepNames.AddorUpdate(eCreepName.untHill_Troll_Berserker, "Hill Troll Berserker")
    mCreepNames.AddorUpdate(eCreepName.untHill_Troll_Priest, "Hill Troll Priest")
    mCreepNames.AddorUpdate(eCreepName.untVhoul_Assassin, "Vhoul Assassin")
    mCreepNames.AddorUpdate(eCreepName.untFell_Spirit, "Fell Spirit")
    mCreepNames.AddorUpdate(eCreepName.untGhost, "Ghost")
    mCreepNames.AddorUpdate(eCreepName.untHarpy_Scout, "Harpy Scount")
    mCreepNames.AddorUpdate(eCreepName.untHarpy_Stormcrafter, "Harpy Stormcrafter")
    mCreepNames.AddorUpdate(eCreepName.untCentaur_Conqueror, "Centaur Conqueror")
    mCreepNames.AddorUpdate(eCreepName.untCentaur_Courser, "Centaur Courser")
    mCreepNames.AddorUpdate(eCreepName.untGiant_Wolf, "Giant Wolf")
    mCreepNames.AddorUpdate(eCreepName.untAlpha_Wolf, "Alpha Wolf")
    mCreepNames.AddorUpdate(eCreepName.untSatyr_Banisher, "Satyr Banisher")
    mCreepNames.AddorUpdate(eCreepName.untSatyr_Mindstealer, "Satyr Mindstealer")
    mCreepNames.AddorUpdate(eCreepName.untOgre_Bruiser, "Ogre Bruiser")
    mCreepNames.AddorUpdate(eCreepName.untOgre_Frostmage, "Ogre Frostmage")
    mCreepNames.AddorUpdate(eCreepName.untMud_Golem, "Mud Golem")
    mCreepNames.AddorUpdate(eCreepName.untSatyr_Tormentor, "Satyr Tormentor")
    mCreepNames.AddorUpdate(eCreepName.untHellbear, "Hellbear")
    mCreepNames.AddorUpdate(eCreepName.untHellbear_Smasher, "Hellbear Smasher")
    mCreepNames.AddorUpdate(eCreepName.untWildwing, "Wildwing")
    mCreepNames.AddorUpdate(eCreepName.untWildwing_Ripper, "Wildwing Ripper")
    mCreepNames.AddorUpdate(eCreepName.untDark_Troll_Summoner, "Dark Troll Summoner")
    mCreepNames.AddorUpdate(eCreepName.untHill_Trll, "Hill Troll")
    mCreepNames.AddorUpdate(eCreepName.untAncient_Black_Dragon, "Ancient Black Dragon")
    mCreepNames.AddorUpdate(eCreepName.untAncient_Black_Drake, "Ancient Black Drake")
    mCreepNames.AddorUpdate(eCreepName.untAncient_Granite_Golem, "Ancient Granite Golem")
    mCreepNames.AddorUpdate(eCreepName.untAncient_Rock_Golem, "Ancient Rock Golem")
    mCreepNames.AddorUpdate(eCreepName.untAncient_Thunderhide, "Ancient Thunderhide")
    mCreepNames.AddorUpdate(eCreepName.untAncient_Rumblehide, "Ancient Rumblehide")
    mCreepNames.AddorUpdate(eCreepName.untRoshan, "Roshan")
    mCreepNames.AddorUpdate(eCreepName.untTower_Tier_1, "Tier 1 Tower")
    mCreepNames.AddorUpdate(eCreepName.untTower_Tier_2, "Tier 2 Tower")
    mCreepNames.AddorUpdate(eCreepName.untTower_Tier_3, "Tier 3 Tower")
    mCreepNames.AddorUpdate(eCreepName.untTower_Tier_4, "Tier 4 Tower")
    mCreepNames.AddorUpdate(eCreepName.untAncient, "Ancient")
    mCreepNames.AddorUpdate(eCreepName.untMelee_Barracks, "Melee Barracks")
    mCreepNames.AddorUpdate(eCreepName.untRanged_Barracks, "Ranged Barracks")
    mCreepNames.AddorUpdate(eCreepName.untFountain, "Fountain")
    mCreepNames.AddorUpdate(eCreepName.untBuffer_Building, "Bugger Building")


  End Sub

  Public Sub LoadStatNames()
    mStatNames = New OneToOneDoubleDictionary(Of eStattype, String)(mLog)

    mStatNames.AddorUpdate(eStattype.None, "None")
    mStatNames.AddorUpdate(eStattype.AttackSpeed, "Attack Speed")
    mStatNames.AddorUpdate(eStattype.AttackDamageLow, "Attack Damage Low")
    mStatNames.AddorUpdate(eStattype.AttackDamageHigh, "Attack Damage High")
    mStatNames.AddorUpdate(eStattype.AttackRange, "Attack Range")
    mStatNames.AddorUpdate(eStattype.PhysicalArmor, "Physical Armor")
    mStatNames.AddorUpdate(eStattype.PhysicalDamageReduction, "Physical Damage Reduction")
    mStatNames.AddorUpdate(eStattype.PhysicalDamageAmplification, "Physical Damage Amplification")
    mStatNames.AddorUpdate(eStattype.PhysicalDamageNegation, "Physical Damage Negation")
    mStatNames.AddorUpdate(eStattype.MagicalDamageResistance, "Magic Resistance")
    mStatNames.AddorUpdate(eStattype.MovementSpeed, "Movement Speed")
    mStatNames.AddorUpdate(eStattype.Strength, "Strength")
    mStatNames.AddorUpdate(eStattype.Agility, "Agility")
    mStatNames.AddorUpdate(eStattype.Intelligence, "Intelligence")
    mStatNames.AddorUpdate(eStattype.Networth, "Net Worth")
    mStatNames.AddorUpdate(eStattype.Experience, "Experience")
    mStatNames.AddorUpdate(eStattype.MagicDamage, "Magical Damage")
    mStatNames.AddorUpdate(eStattype.PhysicalDamage, "Physical Damage")
    mStatNames.AddorUpdate(eStattype.PureDamage, "Pure Damage")
    mStatNames.AddorUpdate(eStattype.HitPoints, "Hit Points")
    mStatNames.AddorUpdate(eStattype.HitPointRegen, "Health Regeneration")
    mStatNames.AddorUpdate(eStattype.Mana, "Mana")
    mStatNames.AddorUpdate(eStattype.ManaRegen, "Mana Regeneration")
    mStatNames.AddorUpdate(eStattype.VisionDay, "Day Vision")
    mStatNames.AddorUpdate(eStattype.VisionNight, "Night Vision")
    mStatNames.AddorUpdate(eStattype.TrueSight, "TrueSight")
    mStatNames.AddorUpdate(eStattype.Stealth, "Stealth")
    mStatNames.AddorUpdate(eStattype.PrimaryAttribute, "Primary Attribute")
    mStatNames.AddorUpdate(eStattype.AttackDamageAverage, "Attack Damage Avg")
    mStatNames.AddorUpdate(eStattype.PeriodicGold, "Automatic Gold")
    mStatNames.AddorUpdate(eStattype.Kills, "Kills")
    mStatNames.AddorUpdate(eStattype.Resources, "Resource Share")
    mStatNames.AddorUpdate(eStattype.MissileSpeed, "Missile Speed")
    mStatNames.AddorUpdate(eStattype.BaseAttackTime, "Base Attacks/sec")
    mStatNames.AddorUpdate(eStattype.CritChance, "Crit Chance")
    mStatNames.AddorUpdate(eStattype.CritDamage, "Crit Damage")
    mStatNames.AddorUpdate(eStattype.CritMultiplier, "Crit Multiplier")
    mStatNames.AddorUpdate(eStattype.AllDamageBurst, "All Damage Burst")
    mStatNames.AddorUpdate(eStattype.HPRemoval, "HP Removal")
    mStatNames.AddorUpdate(eStattype.EffectiveHP, "Effective Hit Points")
    mStatNames.AddorUpdate(eStattype.MagicImmunity, "Magic Immunity Time")
    mStatNames.AddorUpdate(eStattype.SpellImmunityCount, "Spell Immunity Count")
    mStatNames.AddorUpdate(eStattype.Stun, "Stun Time Burst")
    mStatNames.AddorUpdate(eStattype.Hex, "Hex Time Burst")
    mStatNames.AddorUpdate(eStattype.Number1, "1")
    mStatNames.AddorUpdate(eStattype.NumberPoint06, "0.06")
    mStatNames.AddorUpdate(eStattype.ArmorxPoint06, "Armor x 0.06")

    mStatNames.AddorUpdate(eStattype.TeamKills, "Total Kills")
    mStatNames.AddorUpdate(eStattype.TeamTtlEffectiveHP, "Total Effective HP")
    mStatNames.AddorUpdate(eStattype.TeamTtlDamageHi, "Total Attack Damage Hi")
    mStatNames.AddorUpdate(eStattype.TeamTtlDamageLo, "Total Attack Damge Lo")
    mStatNames.AddorUpdate(eStattype.TeamTtlDamageAvg, "Total Attack Damage Avg")
    mStatNames.AddorUpdate(eStattype.TeamTtlHP, "Total Hit Points")
    mStatNames.AddorUpdate(eStattype.TeamTtlHPRegen, "Total Health Regeneration")
    mStatNames.AddorUpdate(eStattype.TeamTtlMana, "Total Mana")
    mStatNames.AddorUpdate(eStattype.TeamTtlManaRegen, "Total Mana Regeneration")
    mStatNames.AddorUpdate(eStattype.TeamTtlVisionDay, "Total Day Vision")
    mStatNames.AddorUpdate(eStattype.TeamTtlVisionNight, "Total Night Vision")
    mStatNames.AddorUpdate(eStattype.TeamTtlDPSPeak, "Total Damage/Sec")
    mStatNames.AddorUpdate(eStattype.TeamTtlDPSAvg, "Average Damage/Sec")
    mStatNames.AddorUpdate(eStattype.TeamTtlPhysDamageBurst, "Total Physical Damage")
    mStatNames.AddorUpdate(eStattype.TeamTtlPhysDPSAvg, "Average Physical Damage/Sec")
    mStatNames.AddorUpdate(eStattype.TeamTtlMagDamageBurst, "Total Magic Damage")
    mStatNames.AddorUpdate(eStattype.TeamTtlMagDPSAvg, "Average Magic Damage")
    mStatNames.AddorUpdate(eStattype.TeamTtlPureDamageBurst, "Total Pure Damage")
    mStatNames.AddorUpdate(eStattype.TeamTtlPureDPSAvg, "Average Pure Damage/Sec")
    mStatNames.AddorUpdate(eStattype.TeamTtlStunDuratoin, "Total Stun Duration")
    mStatNames.AddorUpdate(eStattype.TeamTtlHexDuration, "Total Hex Duration")
    mStatNames.AddorUpdate(eStattype.TeamTtlSpellImmunityCount, "Total Spell Imunity Count")
    mStatNames.AddorUpdate(eStattype.TeamPhysicalArmor, "Total Physical Armor")
    mStatNames.AddorUpdate(eStattype.TeamMagicResistance, "Total Magic Resistance")

  End Sub
  Public Sub LoadModifierNames()



    mModNames = New OneToOneDoubleDictionary(Of eModifierType, String)(mLog)

    mModNames.AddorUpdate(eModifierType.AbilityEffectiveHp, eModifierType.AbilityEffectiveHp.ToString)

    mModNames.AddorUpdate(eModifierType.MuteAbilities, "Abilities Disabled")

    mModNames.AddorUpdate(eModifierType.AbilitySteal, "Aquires All Targetted Creep's Abilities") 'Doom Devour

    mModNames.AddorUpdate(eModifierType.AdaptiveStrikeDamageMagicalInflicted, "Magic Damage Inflicted") 'Morphling Adaptive Strike. Used Agility to calc damage inflicted

    mModNames.AddorUpdate(eModifierType.AdaptiveStrikeStun, "Stun") 'Morphling Adaptive Strike. Calculated using current strength and agility

    mModNames.AddorUpdate(eModifierType.AgiAdded, "Agility Added") '= 15

    mModNames.AddorUpdate(eModifierType.AgioT, "Agility Over Time Added")

    mModNames.AddorUpdate(eModifierType.AgiPercent, "Agility Increase")

    mModNames.AddorUpdate(eModifierType.AgiSubtracted, "Agility Removed") ' Slark Essence Shift

    mModNames.AddorUpdate(eModifierType.ArcaneOrb, eModifierType.ArcaneOrb.ToString) '= 50 'OD

    mModNames.AddorUpdate(eModifierType.ArmorAdded, "Physical Armor Added")

    mModNames.AddorUpdate(eModifierType.ArmorAddedPerSec, "Physical Armor Added Over Time")

    mModNames.AddorUpdate(eModifierType.ArmoroT, "Physical Armor Added Over Time")

    mModNames.AddorUpdate(eModifierType.ArmorPercentage, "Physical Armor Increase")

    mModNames.AddorUpdate(eModifierType.ArmorStackSubtracted, "Physical Armor Stack Removed") 'Bristlebakc Nasal Goo

    mModNames.AddorUpdate(eModifierType.ArmorSubtracted, "Physical Armor Removed")

    mModNames.AddorUpdate(eModifierType.AstralSpiritDamageMagicalAdded, "Magic Damage Added") 'Elder Titan, will have to determine how many units were hit for this to be accurate

    mModNames.AddorUpdate(eModifierType.AstralSpiritMoveSpeedPercentAdded, "Movement Speed Increase") 'Elder Titan, have to determine how many creeps hit

    mModNames.AddorUpdate(eModifierType.AstrlImpIntStolen, "Intelligence Added") 'OD Astral Imprisonment. Only steals int if target is enemy hero

    mModNames.AddorUpdate(eModifierType.MuteAttacks, "Right-click Disabled") 'Flaming Lasso Batrider

    mModNames.AddorUpdate(eModifierType.AttackSpeedAdded, "Attack Speed Added") '= 25

    mModNames.AddorUpdate(eModifierType.AttackSpeedAddedPerHeroPerMissHP, "Attack Speed Added") 'Bloodseeker Thirst

    mModNames.AddorUpdate(eModifierType.AttackSpeedAddedtoXAttacks, "Attack Speed for ? Attacks") 'Ursa Overpower. Attack speed only added to a certain number of rightclick attacks

    mModNames.AddorUpdate(eModifierType.AttackSpeedMaxed, "Attack Speed Maxed Out") 'Windranger Focus Fire

    mModNames.AddorUpdate(eModifierType.AttackSpeedoT, "Attack Speed Added over Time") '= 27

    mModNames.AddorUpdate(eModifierType.AttackSpeedPercentAdded, "Attack Speed Increase") '= 26

    mModNames.AddorUpdate(eModifierType.AttackSpeedPercentofTargetAdded, "Attack Speed Increase") 'Visage Grave Chill

    mModNames.AddorUpdate(eModifierType.AttackSpeedPercentSubtracted, "Attack Speed Decrease") 'Medusa Stone Gaze

    mModNames.AddorUpdate(eModifierType.AttackSpeedStackAdded, "Attack Speed Stack Added") 'Lina Fiery Soul

    mModNames.AddorUpdate(eModifierType.AttackspeedSubtracted, "Attack Speed Removed") 'AA Chilling Touch

    mModNames.AddorUpdate(eModifierType.BackstabRightclickDamageAddedAsPercofAgi, "Right-click Damage Added") 'Riki Backstab. only occurs when attacking from rear

    mModNames.AddorUpdate(eModifierType.BallLightDamMagicalInflicted, "Magic Damage Inflicted") 'Storm Spirit Ball Lightning

    mModNames.AddorUpdate(eModifierType.BallLightPushForward, "Push Forward") 'SS Ball Lightning charge

    mModNames.AddorUpdate(eModifierType.Barrier, "Barrier") 'earthsaker wall, tusk iceshards...

    mModNames.AddorUpdate(eModifierType.BaseAgi, "Base Agility Added") '= 89

    mModNames.AddorUpdate(eModifierType.BaseandBonusDamageReduction, eModifierType.BaseandBonusDamageReduction.ToString) 'Windranger Focus Fire

    mModNames.AddorUpdate(eModifierType.BaseArmorPercentSubtracted, "Base Physical Armor Decrease") 'Elder Titan Natural Order

    mModNames.AddorUpdate(eModifierType.BaseAttackDamageLow, "Base Attack Damage Low")

    mModNames.AddorUpdate(eModifierType.BaseAttackDamageHigh, "Base Attack Damage High")

    mModNames.AddorUpdate(eModifierType.BaseAttackDamageAvg, "Average Base Attack Damage")

    mModNames.AddorUpdate(eModifierType.BaseAttackRange, "Base Attack Range")

    mModNames.AddorUpdate(eModifierType.BaseAttackTime, "Right-click Attack Speed Added")

    mModNames.AddorUpdate(eModifierType.BaseAttackTimeChangedTo, "Right-click Attack Speed Added") ' Alchemist Chemical Rage

    ''mmodnames.add(eModifierType.BaseEffectiveHP '= 1
    ''  PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
    ', themodtype.ToString
    ''mmodnames.add(eModifierType.BaseHP '= 0
    ''  , "Base HP Added"
    mModNames.AddorUpdate(eModifierType.BaseArmor, "Base Armor")

    mModNames.AddorUpdate(eModifierType.BaseInt, "Base Intelligence Added")

    mModNames.AddorUpdate(eModifierType.BaseMagicResistance, "Base Magic Resistance Added")

    mModNames.AddorUpdate(eModifierType.BaseMagicResistancePercentSubtracted, "Base Magic Resistance Decrease") 'Elder Titan Natural Order

    mModNames.AddorUpdate(eModifierType.BaseMovementSpeed, "Base Movement Speed")

    mModNames.AddorUpdate(eModifierType.BaseMana, "Base Mana Added")

    mModNames.AddorUpdate(eModifierType.BaseStr, "Base Strength Added")

    mModNames.AddorUpdate(eModifierType.BaseXP, "Experience")

    mModNames.AddorUpdate(eModifierType.Bash, "Bash Physical Damage") '= 35 'http://dota2.gamepedia.com/Bash

    mModNames.AddorUpdate(eModifierType.BearBonusDamage, "Bonus Damage") 'Lone Druid Synergy

    mModNames.AddorUpdate(eModifierType.BearMoveSpeedAdded, "Movement Speed Added") 'Lone Druid Synergy

    mModNames.AddorUpdate(eModifierType.BerserkersBonusAttackSpeed, "Attack Speed Added") 'Huskar Berserker's Blood. Oy

    mModNames.AddorUpdate(eModifierType.BerserkersBonusMagicResistance, "Bonus Magic Resistance Added") 'Huskar Berserker's Blood

    mModNames.AddorUpdate(eModifierType.BlindChance, eModifierType.BlindChance.ToString) '= 57 'http://dota2.gamepedia.com/Blind

    mModNames.AddorUpdate(eModifierType.BlindDuration, eModifierType.BlindDuration.ToString)

    mModNames.AddorUpdate(eModifierType.MuteBlink, "Blink Disabled") '= 81 'unable to blink

    mModNames.AddorUpdate(eModifierType.BonusDamage, "Bonus Damage Added")

    mModNames.AddorUpdate(eModifierType.BonusDamageoT, "Bonus Damage Added Over Time")

    mModNames.AddorUpdate(eModifierType.BonusDamagePercent, eModifierType.BonusDamagePercent.ToString) 'Lycan Feral Impulse

    mModNames.AddorUpdate(eModifierType.BonusGold, "Bonus Gold Added")

    mModNames.AddorUpdate(eModifierType.BountyGold, "Gold Added")

    mModNames.AddorUpdate(eModifierType.CausticFinale, eModifierType.CausticFinale.ToString) '= 45 'SandKing

    mModNames.AddorUpdate(eModifierType.ChainLightning, "Chain Lightning Damage") '= 54 'Maelstrom, Mjolnir

    mModNames.AddorUpdate(eModifierType.ChenAncientCount, "Ancients Able to Be Persuaded") 'count of potential ancients that can be holy pursuasioned

    mModNames.AddorUpdate(eModifierType.ChenCreepFullHeal, "Target Creep is Fully Healed") 'Chen Hand of God

    mModNames.AddorUpdate(eModifierType.CleavePercentage, "Cleave Damage Increase") '= 36 'http://dota2.gamepedia.com/Cleave , http://dota2.gamepedia.com/Mechanics#Cleave_Damage

    mModNames.AddorUpdate(eModifierType.ColdAttack, "Cold Attack Added") '= 53 'Skadi

    mModNames.AddorUpdate(eModifierType.ConjuredImage, "Conjured Image") 'Terrorblade Conjure Image. Takes stats from TB's current stats

    mModNames.AddorUpdate(eModifierType.Consumption, "Consumes Enemy") 'Doom Devour

    mModNames.AddorUpdate(eModifierType.ControlledCreepHealthBonus, "HP Added to Controlled Creeps") 'Chen Holy Pursuasion

    mModNames.AddorUpdate(eModifierType.Corruption, "Physical Armor Removed") '= 52 'Desolator

    mModNames.AddorUpdate(eModifierType.CreepControlled, "Creep Controlled") 'Chen Holy Pursuasion

    mModNames.AddorUpdate(eModifierType.CripplingFearMissChance, eModifierType.CripplingFearMissChance.ToString) 'NightStalker. Values change if day or night

    mModNames.AddorUpdate(eModifierType.CritChance, "Right-click Crit Chance Increase") '= 37 'http://dota2.gamepedia.com/Critical_strike

    mModNames.AddorUpdate(eModifierType.CritDamage, "Right-click Crit Damage Added") 'Jinada

    mModNames.AddorUpdate(eModifierType.CritMultiplier, "Right-click Damage Multiplied")

    mModNames.AddorUpdate(eModifierType.Cyclone, "Invulnerability") '= 59 'http://dota2.gamepedia.com/Cyclone

    mModNames.AddorUpdate(eModifierType.DamageAbsorbedForMana, "Incoming Damage Abosorbed/ Mana Removed") 'Medusa Mana Shield .absorbs damage in exchange for mana

    mModNames.AddorUpdate(eModifierType.DamageAllTypesIncomingIncreasesPercent, "All Incoming Damage Increase") 'Slardar Sprint

    mModNames.AddorUpdate(eModifierType.DamageAllTypesPercentAdded, "All Damage Increase") 'Clinkz DeathPact

    mModNames.AddorUpdate(eModifierType.DamageAllTypesStackAdded, "All Damage Added") 'Bristleback Warpath adds damage to spells and abilitys of all damage types

    mModNames.AddorUpdate(eModifierType.DamageAmplification, "All Damage Increase") '= 31 'http://dota2.gamepedia.com/Damage_amplification

    mModNames.AddorUpdate(eModifierType.DamageBlock, "Damage Removed")

    mModNames.AddorUpdate(eModifierType.DamageBlockRemoved, eModifierType.DamageBlockRemoved.ToString)

    mModNames.AddorUpdate(eModifierType.DamageBothBlockAdded, eModifierType.DamageBothBlockAdded.ToString)

    mModNames.AddorUpdate(eModifierType.DamageChainMagicalInflicted, "Magic Damage per Hit Inflicted") 'WitchDoctor Paralyzing cask

    mModNames.AddorUpdate(eModifierType.DamageChainPhysicalInflicted, "Physical Damage per Hit Inflicted") 'Mjolnir

    mModNames.AddorUpdate(eModifierType.DamageDelay, "Damage Delay Time") 'Kunka Ghost Ship

    mModNames.AddorUpdate(eModifierType.DamageIncreasePercent, "All Incoming Damage Increase") 'Chen Penitence

    mModNames.AddorUpdate(eModifierType.DamageInstanceBlock, "Damage Instance Blocked") 'treant Living Armor

    mModNames.AddorUpdate(eModifierType.DamageLost, "Right-click Damage Removed") 'due to LC Duel, Razor static link

    mModNames.AddorUpdate(eModifierType.DamageMagicalAbsorbed, "Magic Damage Removed") 'Ember Spirit Flameguard

    mModNames.AddorUpdate(eModifierType.DamageMagicalAdded, "Magic Damage Added") 'for passaive abilities

    mModNames.AddorUpdate(eModifierType.DamageMagicalAddedToPhysicalAttacks, "Right-click Magic Damage Added") ' AA Chilling Touch

    mModNames.AddorUpdate(eModifierType.DamageMagicalBouncesInflicted, "Magic Damage per Hit Inflicted") 'Lich ulti

    mModNames.AddorUpdate(eModifierType.DamageMagicalEarthSplitterAdded, "Magic Damage Added") 'Elder Titan. Based on unit being attacked's max HP

    mModNames.AddorUpdate(eModifierType.DamageMagicalImmunity, "Magic Damage Removed") 'OmniKnight Repel

    mModNames.AddorUpdate(eModifierType.DamageMagicalInflicted, "Magic Damage Inflicted") 'for active abilities

    mModNames.AddorUpdate(eModifierType.DamageMagicalInflictedOnSpellCast, "Magic Damage Inflicted") 'SS Overload

    mModNames.AddorUpdate(eModifierType.DamageMagicalInflictedPerAlly, "Magic Damage Inflicted") ' Tusk Snowball

    mModNames.AddorUpdate(eModifierType.DamageMagicalInflictedPerTarget, "Magic Damage Inflicted") 'SS Ether Shock, for abilities that hit x num of targets, each only once

    mModNames.AddorUpdate(eModifierType.DamageMagicalInflictedPerUnit, "Magic Damage Inflicted") 'Undying Soul Rip

    mModNames.AddorUpdate(eModifierType.DamageMagicalInflictedUntilSpellcast, "Magic Damage Inflicted Over Time") 'Silencer Curse of the Silent

    mModNames.AddorUpdate(eModifierType.DamageMagicalMinMaxInflicted, "Magic Damage Inflicted Range") 'value has a min and max value

    mModNames.AddorUpdate(eModifierType.DamageMagicaloTAsMultofStr, "Magic Damage Over Time") 'Pudge Dismemeber

    mModNames.AddorUpdate(eModifierType.DamageMagicalOverTimeInflicted, "Magic Damage Over Time") 'LeechSeed pulse

    mModNames.AddorUpdate(eModifierType.DamageMagicalPercent, "Magic Damage Increase")

    mModNames.AddorUpdate(eModifierType.DamageMagicalPerCreep, "Magic Damage Added per Creep") 'LC Overwhelming Odds

    mModNames.AddorUpdate(eModifierType.DamageMagicalPerHero, "Magic Damage Added per Hero") 'LC Overwhelming Odds

    mModNames.AddorUpdate(eModifierType.DamageMagicalPerMissingHP, "Magic Damage Added per Missing HP") 'Necro Reaper's Scythe

    mModNames.AddorUpdate(eModifierType.DamageMagicalPerMissingMana, "Magic Damage Added per Missing Mana") 'Anti Mage Mana Void

    mModNames.AddorUpdate(eModifierType.DamageMagicalPerSec, "Magic Damage Over Time") ''axe battle hunger

    mModNames.AddorUpdate(eModifierType.DamageMagicalRandomInflicted, "Magic Damage Inflicted") 'uses maxval and minval in modvalue for range of random value

    mModNames.AddorUpdate(eModifierType.DamageMagicalTimesInt, "Damage Magical Added") ' Skywrath Arcane Bolt

    mModNames.AddorUpdate(eModifierType.DamageMeleeAdded, "Right-click Melee Damage Added")

    mModNames.AddorUpdate(eModifierType.DamageMeleeBlockAdded, "Right-click Melee Damage Removed") '= 32 'http://dota2.gamepedia.com/Damage_Block

    mModNames.AddorUpdate(eModifierType.DamageMeleemultiplier, "Right-click Melee Damage Multiplied")

    mModNames.AddorUpdate(eModifierType.DamageoTMagicalInflicted, "Magic Damage Over Time Inflicted")

    mModNames.AddorUpdate(eModifierType.damagePerSecond, "Physical Damage Over Time") 'Radiance burn

    mModNames.AddorUpdate(eModifierType.DamagePhysicalAdded, "Physical Damage Added") 'passive abilites

    mModNames.AddorUpdate(eModifierType.DamagePhysicalBouncesInflicted, "Physical Damage Bounces Inflicted") 'Witch doc Death Ward

    mModNames.AddorUpdate(eModifierType.DamagePhysicalEarthSplitterAdded, "Physical Damage Inflicted") 'Elder Titan. Based on unit being attacked's max HP

    mModNames.AddorUpdate(eModifierType.DamagePhysicalImmunity, "Physical Damage Immunity") 'OmniKnight Guardian Angel

    mModNames.AddorUpdate(eModifierType.DamagePhysicalIncomingIncreasedPercent, "Incoming Physical Damage Increase") 'Medusa Stone Gaze

    mModNames.AddorUpdate(eModifierType.DamagePhysicalInflicted, "Physical Damage Inflicted") 'active abilities

    mModNames.AddorUpdate(eModifierType.DamagePhysicaloT, "Physical Damage Inflicted Over Time")

    mModNames.AddorUpdate(eModifierType.DamagePhysicalPercent, "Pysical Damage Increase")

    mModNames.AddorUpdate(eModifierType.DamagePhysicalPerSec, "Physical Damage Over Time")

    mModNames.AddorUpdate(eModifierType.DamagePhysicalStackingInflicted, "Physical Damage Inflicted") 'Bristelback Quillspray

    mModNames.AddorUpdate(eModifierType.DamagePhysicalSubtracted, "Physical Damage Removed") 'Enfeeble

    mModNames.AddorUpdate(eModifierType.DamagePierceAdded, "Piercing Physical Damage Added")

    mModNames.AddorUpdate(eModifierType.DamagePierceChancePercent, "Piercing Physical Damage Chance")

    mModNames.AddorUpdate(eModifierType.DamagePureAdded, "Pure Damage Added")

    mModNames.AddorUpdate(eModifierType.DamagePureAsPercentofManaPool, "Pure Damage Added") 'OD Arcane Orb

    mModNames.AddorUpdate(eModifierType.DamagePureAsPercentofMaxHP, "Pure Damage Added") 'Enigma Midnight pulse

    mModNames.AddorUpdate(eModifierType.HPRemovalAsPercentofMoveDist, "Pure Damage Added") 'Bloodseeker Rupture

    mModNames.AddorUpdate(eModifierType.DamagePureInflicted, "Pure Damage Inflicted")

    mModNames.AddorUpdate(eModifierType.DamagePureoTasPercofMaxHP, "Pure Damage Added Over Time") 'Phoenix Sun Ray

    mModNames.AddorUpdate(eModifierType.DamagePureoTInflicted, "Pure Damage Inflicted Over Time") 'Phoenix Sun Ray

    mModNames.AddorUpdate(eModifierType.DamagePurePercent, "Pure Damage Increase")

    mModNames.AddorUpdate(eModifierType.DamagePureRandomInflicted, "Pure Damage Inflicted") 'Chen Test of Faith. uses maxval and minval in modvalue for range of random value

    mModNames.AddorUpdate(eModifierType.DamageRangeAdded, "Right-click Ranged Damage Added")

    mModNames.AddorUpdate(eModifierType.DamageRangeBlockAdded, "Right-click Ranged Damage Reduced") '= 33

    mModNames.AddorUpdate(eModifierType.DamageRangemultiplier, "Right-click Ranged Damage Multiplied")

    mModNames.AddorUpdate(eModifierType.DamageReduction, "Incoming Damage Decrease") 'Tide Anchor smash

    mModNames.AddorUpdate(eModifierType.DamageReturnDuration, "Damage returned") 'Blademail

    mModNames.AddorUpdate(eModifierType.HPRemovalSharedWithBoundUnits, eModifierType.HPRemovalSharedWithBoundUnits.ToString)  'Warlock Fatal Bonds

    mModNames.AddorUpdate(eModifierType.DamagetoHealPercent, "Health Restored") 'abadon ulti

    mModNames.AddorUpdate(eModifierType.DamageTransferedToCaster, eModifierType.DamageTransferedToCaster.ToString) 'abaddon borrowed time

    mModNames.AddorUpdate(eModifierType.DarknessNight, "Day Turns to Night") 'NightStalker. Artificial night induced. max vis for all enemies 675

    mModNames.AddorUpdate(eModifierType.DestroysCreep, "Creep Killed") 'Lich Sacrifice

    mModNames.AddorUpdate(eModifierType.DestroysHero, "Techies Die") 'Techies Suicide

    mModNames.AddorUpdate(eModifierType.DestroysHeroBelowThreshold, "Hero Dies") 'Axe Culling Blade

    mModNames.AddorUpdate(eModifierType.DestroysTree, "Targetted Tree Destroyed") 'Quellingblade

    mModNames.AddorUpdate(eModifierType.Disarm, "Right-click Disabled")

    mModNames.AddorUpdate(eModifierType.DisarmMelee, eModifierType.DisarmMelee.ToString) '= 69 'http://dota2.gamepedia.com/Disarm

    mModNames.AddorUpdate(eModifierType.DisarmRange, eModifierType.DisarmRange.ToString) ' Heaven's Halberd

    mModNames.AddorUpdate(eModifierType.DisjointRange, "Ranged Projectiles Lose Caster's Target") '= 70 'http://dota2.gamepedia.com/Disjoint

    mModNames.AddorUpdate(eModifierType.Dispel, eModifierType.Dispel.ToString) '= 71 'http://dota2.gamepedia.com/Dispel This may need to be more granular..... normal dispels, magic ummune dispels, strong dispells

    mModNames.AddorUpdate(eModifierType.DisruptionIllusion, "Targetted Hero Illusion") 'ShadowDemon Illusion

    mModNames.AddorUpdate(eModifierType.Dominate, "Targetted Creep Controlled") 'Helm of the dominator

    mModNames.AddorUpdate(eModifierType.DuelBonusDamage, "Right-click Damage Added") 'lc duel, seperate item so we can do a buff icon for it

    mModNames.AddorUpdate(eModifierType.ElderDragonForm, "Elder Dragon Form") 'Dragon Knight

    mModNames.AddorUpdate(eModifierType.Ensnare, "Movement Disabled") '= 67 'http://dota2.gamepedia.com/Ensnare

    mModNames.AddorUpdate(eModifierType.Entangle, "Movement Disabled") '= 68 'http://dota2.gamepedia.com/Entangle

    mModNames.AddorUpdate(eModifierType.EssenceAuraManaRestored, "Mana Restored") 'instances of this determined by amount of enemies in range?

    mModNames.AddorUpdate(eModifierType.Ethereal_Time, "Physical Damage Immunity") 'also mutes movement... may need to add a mod for it'= 77 'http://dota2.gamepedia.com/Ethereal

    mModNames.AddorUpdate(eModifierType.EvasionPercent, "Evasion Increase")

    mModNames.AddorUpdate(eModifierType.EvasionRemoved, "All Evasion Removed") ' SS Hex removes all evasion

    mModNames.AddorUpdate(eModifierType.EvilSpirits, "Evil Spirits") 'special modtype since spirit count is affected by witchcraft, so has to be calced from inside the mod itself

    mModNames.AddorUpdate(eModifierType.FadeBoltDamageMagicalBounces, "Magic Damage Bounces") 'Rubick, Fade Bolt. bounces diminish the damage, thus the unique modifier. also has no bounce limit but cant hit same target twice

    mModNames.AddorUpdate(eModifierType.Feedback, eModifierType.Feedback.ToString) '= 55 'Diffusal Blade

    mModNames.AddorUpdate(eModifierType.FrostArrows, eModifierType.FrostArrows.ToString) '= 48 'Drow

    mModNames.AddorUpdate(eModifierType.Ghost_Form_Time, "Ghost Form") 'Ghost scepter, ethereal blade

    mModNames.AddorUpdate(eModifierType.GlaivesWisdom, eModifierType.GlaivesWisdom.ToString) '= 51 'Silencer

    mModNames.AddorUpdate(eModifierType.GreaterBashofCurrentLevel, "Greater Bash Instance Added") 'Spirit Breaker Nether Strike

    mModNames.AddorUpdate(eModifierType.Haunt, "Haunt") 'Spectre haunt. Takes attributes of Spectre at time of cast

    mModNames.AddorUpdate(eModifierType.HealAdded, "Health Restored")

    mModNames.AddorUpdate(eModifierType.HealAddedAsPercOfTargetCurrHP, "Health Restored") 'Lifestealer Feast

    mModNames.AddorUpdate(eModifierType.HealAddedoT, "Health Restored Over Time") 'Treant Leach Seed

    mModNames.AddorUpdate(eModifierType.HealAddedoTAsPercofMaxHP, "Health Restored") 'Phoenix Sun Ray

    mModNames.AddorUpdate(eModifierType.HealAddedPerDeadCreep, "Health Restored") 'Undying Flesh Golem

    mModNames.AddorUpdate(eModifierType.HealAddedPerDeadHero, "Health Restored") 'Undying Flesh Golem

    mModNames.AddorUpdate(eModifierType.HealAddedPerUnit, "Health Restored per Unit") 'Undying Soul Rip

    mModNames.AddorUpdate(eModifierType.HealAsPercentofHP, "% of Max Health Restored")

    mModNames.AddorUpdate(eModifierType.HealFriendlyorDamageEnemy, "Health Restored or Magic Damage Inflicted")

    mModNames.AddorUpdate(eModifierType.HealFriendlyorMagicDamEnemyoT, "Health Restored or Magic Damage Over Time Inflicted") 'Warlock Shadow Word

    mModNames.AddorUpdate(eModifierType.HealMinMaxAdded, "Health Restored") 'Value has a min and max range

    mModNames.AddorUpdate(eModifierType.HealPercent, "Health Restored")

    mModNames.AddorUpdate(eModifierType.HealthFullyRestored, "Health Fully Restored") 'Phoenix Supernova

    mModNames.AddorUpdate(eModifierType.HealthRegenAdded, "HP Regen Added") 'Alchemist Chemical Rage

    mModNames.AddorUpdate(eModifierType.HealthvalueFrozen, "Immune to Health Regen") 'AA Ice Blast

    'mmodnames.add(eModifierType.Heropet
    '  , "Pet"
    mModNames.AddorUpdate(eModifierType.HeroReflection, eModifierType.HeroReflection.ToString) 'Terrorblade Reflection. Takes stats from targetted hero
    mModNames.AddorUpdate(eModifierType.Hex, "Hex") '= 62 'http://dota2.gamepedia.com/Hex

    mModNames.AddorUpdate(eModifierType.HPAdded, "Hit Points Added") '= 2 ' amount (pos or neg representing heal of damage) Damage type (puredamagesingletarget, magicdamageAOE, etc)

    mModNames.AddorUpdate(eModifierType.HPoT, "Health Restored Over Time") '= 4 'amount as total amount, damagetype(for negative numbers, otherwise none)

    mModNames.AddorUpdate(eModifierType.HPPercent, "Health Increase") '= 3 ' amount as decimal

    mModNames.AddorUpdate(eModifierType.HPRegenAdded, "Health Regen Added")

    mModNames.AddorUpdate(eModifierType.HPRegenSubtracted, "Health Regen Removed")

    mModNames.AddorUpdate(eModifierType.HPRegenPercent, "Health Regen Increase")

    mModNames.AddorUpdate(eModifierType.HPRegenPercentofCasters, "Health Restored") 'io Tether

    mModNames.AddorUpdate(eModifierType.HPRegenPerUnitKilledAdded, "Health Added Per Unit Killed") 'necro sadist

    mModNames.AddorUpdate(eModifierType.HPSubtracted, "Health Removed")

    mModNames.AddorUpdate(eModifierType.Impetus, eModifierType.Impetus.ToString) '= 43 'Enchantress

    mModNames.AddorUpdate(eModifierType.ImpetusDamagePureInflicted, "Pure Damage Inflicted") 'Enchantress Impetus. damage as function of distance

    mModNames.AddorUpdate(eModifierType.IncapBite, eModifierType.IncapBite.ToString) '= 47 'Broodmother

    mModNames.AddorUpdate(eModifierType.InfestCreepHeal, "Health Restored") 'Lifestealer Infest. If infest in creep then creep hp as heal on consume

    mModNames.AddorUpdate(eModifierType.InnerVitalityPercentHealAdded, "Health Restored") 'Huskar Inner Vitality. Will have to check target's health to see which healpercentage to use

    mModNames.AddorUpdate(eModifierType.IntAdded, "Intelligence Added") '= 18

    mModNames.AddorUpdate(eModifierType.IntoT, "Intelligence Added Over Time") '= 20

    mModNames.AddorUpdate(eModifierType.IntPercent, "Intelligence Increase") '= 19

    mModNames.AddorUpdate(eModifierType.IntSubtracted, "Intelligence Removed") 'slark Essence Shift

    mModNames.AddorUpdate(eModifierType.Invisibility, "Invisibility") '= 72 'http://dota2.gamepedia.com/Invisibility

    mModNames.AddorUpdate(eModifierType.MuteInvisibility, "Invisibility Disabled") 'treant overgrowth

    mModNames.AddorUpdate(eModifierType.Invulnerability, "Invulnerability") '= 73 'http://dota2.gamepedia.com/Invulnerability

    mModNames.AddorUpdate(eModifierType.ItemEffectiveHP, eModifierType.ItemEffectiveHP.ToString) '= 86

    mModNames.AddorUpdate(eModifierType.MuteItems, "Item Abilities Disabled") '= 80 'unable to cast items

    mModNames.AddorUpdate(eModifierType.KillsPerGoldIncrement, "Kills Increment")

    mModNames.AddorUpdate(eModifierType.Knockback, "Knockback") 'batrider firefly and many others

    mModNames.AddorUpdate(eModifierType.KotLSpiritForm, "Spirit Form") 'Kotl

    mModNames.AddorUpdate(eModifierType.LastHitGoldAdded, "Gold Added") 'Alchemist Greevil's Greed

    mModNames.AddorUpdate(eModifierType.LastHitGoldBonusPerStack, "Gold Added Per Stack") 'Alchemist Greevil's Greed

    mModNames.AddorUpdate(eModifierType.Leap, "Leap") 'slark spiritbreaker

    mModNames.AddorUpdate(eModifierType.LifeDrainDrainfromTarget, eModifierType.LifeDrainDrainfromTarget.ToString) 'Pugna Life Drain. Different effects depending if target is friend or foe

    mModNames.AddorUpdate(eModifierType.LifeDrainPercent, eModifierType.LifeDrainPercent.ToString) 'DP Exorcism

    mModNames.AddorUpdate(eModifierType.LifeDrainSelfEffect, eModifierType.LifeDrainSelfEffect.ToString) 'Pugna Life Drain. Different effect to pugna depending on whether targeting friend or foe

    mModNames.AddorUpdate(eModifierType.LifeStealAdded, "Health Restored") '= 56 'Helm of the Dominator, mask of madness, satanic 'http://dota2.gamepedia.com/Lifesteal

    mModNames.AddorUpdate(eModifierType.LifestealAddedtoAllAttackers, "Health Added") 'Lifestealer Open Wounds. Allied Heroes get healtch when attacking enemy unit with this debuff

    mModNames.AddorUpdate(eModifierType.LifeStealPercent, "Healing Increase")

    mModNames.AddorUpdate(eModifierType.LiquidFire, "Liquid Fire Damage Inflicted") '= 44 'Jakiro

    mModNames.AddorUpdate(eModifierType.LostHealthDamagePercent, "of Lost health Inflicted as Magic Damage") 'Witch Doc Maledict

    mModNames.AddorUpdate(eModifierType.LucentBeamHits, "Lucent Beams") 'Luna Eclipse

    mModNames.AddorUpdate(eModifierType.LvlDeathDamageMagicalInflicted, "Magic Damage Inflicted") 'Doom Lvl? Death. has to be calced at time using attacked hero level and abdoom_lvl_death.herolevelmultiplier

    mModNames.AddorUpdate(eModifierType.MagicDamageReceivedMultiplier, "Magic Damage Received Increase") ' ghost scepte

    mModNames.AddorUpdate(eModifierType.MagicImmunity, "Magic Immunity") '= 30 'http://dota2.gamepedia.com/Magic_immunity

    mModNames.AddorUpdate(eModifierType.MagicResistanceAdded, "Magic Resistance Added")

    mModNames.AddorUpdate(eModifierType.MagicResistanceCapped, "Magic Resistance Maxed (100%)") 'Lifestealer Rage. Gives 100% Magic Resistance

    mModNames.AddorUpdate(eModifierType.MagicResistancePercentAdded, "Magic Resistance Increase")

    mModNames.AddorUpdate(eModifierType.MagicResistancePercentSubtracted, "Magic Resistance Reduced") 'Pugna Decrepify

    mModNames.AddorUpdate(eModifierType.MagicResistanceSet, "Magic Resistance Set") 'Medusa Stone Gaze. Set Magic Resistance at a value

    mModNames.AddorUpdate(eModifierType.MagicResistanceSubtracted, "Magic Resistance Reduced") 'AA Ice Vortex

    mModNames.AddorUpdate(eModifierType.MagnatizeDamageOverTime, eModifierType.MagnatizeDamageOverTime.ToString) 'will have to make concession for num enemyheroes and numboulders

    mModNames.AddorUpdate(eModifierType.MaimChance, eModifierType.MaimChance.ToString) 'sange 'this shouldn't really be a mod... just perc chance of move slow and att slow

    mModNames.AddorUpdate(eModifierType.ManaAdded, "Mana Added") '= 6

    mModNames.AddorUpdate(eModifierType.ManaBreak, eModifierType.ManaBreak.ToString) '= 41 'Anti-Mage'shouldn't this be mana removed and magic damage?

    mModNames.AddorUpdate(eModifierType.ManaBurnDamage, "Magic Damage Inflicted") 'Nyx Mana Burn. uses target's intelligence to calc damage

    mModNames.AddorUpdate(eModifierType.ManaBurnManaremoved, "Mana Removed") 'Nyx Mana Burn. Uses target's intelligence to calc mana removed.

    mModNames.AddorUpdate(eModifierType.ManaDrained, "Mana Removed") ' antimage manaburn, it damage to mana inflicted.

    mModNames.AddorUpdate(eModifierType.ManaDrainedUntilSpellcast, "Mana Removed") 'Silencer Curse of the Silent. Darinas mana until duration end or target casts spell

    mModNames.AddorUpdate(eModifierType.ManaoT, "Mana Over Time Added") '= 8

    mModNames.AddorUpdate(eModifierType.ManaPercent, "Mana Increase") '= 7

    mModNames.AddorUpdate(eModifierType.ManaPercentDrained, "Mana Decrease") 'Bane Fiend's Grip, percent is based off of targets max mana

    mModNames.AddorUpdate(eModifierType.ManaRegenAdded, "Mana Regen Added")

    mModNames.AddorUpdate(eModifierType.ManaRegenSubtracted, "Mana Regen Removed")

    mModNames.AddorUpdate(eModifierType.ManaRegenPercent, "Mana Regen Increase")

    mModNames.AddorUpdate(eModifierType.ManaRegenPercentofCasters, "Mana Regen Increase") 'IO tether

    mModNames.AddorUpdate(eModifierType.ManaRegenPerUnitKillAdded, "Mana Regen Added") 'Necro Sadist

    mModNames.AddorUpdate(eModifierType.ManaRemovedPercentoT, "Mana Decrease Over Time") 'KotL Mana Leak

    mModNames.AddorUpdate(eModifierType.ManaRestored, "Mana Restored")

    mModNames.AddorUpdate(eModifierType.ManaRestoredAsPercentOfHP, "Mana Restored") 'Lich Sacrifice

    mModNames.AddorUpdate(eModifierType.ManaRestoredPercent, "Mana Restored")

    mModNames.AddorUpdate(eModifierType.MantaMeleeIllusionDamagePercentage, "Physical Melee Damage") 'Manta style

    mModNames.AddorUpdate(eModifierType.MantaRangeIllusionDamagePercentage, "Physical Ranged Damage")

    mModNames.AddorUpdate(eModifierType.MeepoClone, "Clone") 'Meepo Divided We Stand

    mModNames.AddorUpdate(eModifierType.MeleeSlow, "Right-click Melee Attack Speed Removed") 'orb of venom

    mModNames.AddorUpdate(eModifierType.MeleeStun, "Right-click Stun") ' Abyssal Blade

    mModNames.AddorUpdate(eModifierType.MeltingStrike, eModifierType.MeltingStrike.ToString) '= 49 'Invoker's forged Spirit

    mModNames.AddorUpdate(eModifierType.MidnightPulsePureDamageAdded, "Pure Damage Added") 'Black hole scepter upgrade adds midnight pulse damage at current level

    mModNames.AddorUpdate(eModifierType.Minibash_Damage, "Physical Damage")

    mModNames.AddorUpdate(eModifierType.MiniMapInvisibility, "Mini-map Invisibility") 'Phantom Ass, Blur

    mModNames.AddorUpdate(eModifierType.MiniStun, eModifierType.MiniStun.ToString)

    mModNames.AddorUpdate(eModifierType.MirrorImage, "Mirror Image") 'Naga Siren Mirror Image. Takes props from hero's stats at time

    mModNames.AddorUpdate(eModifierType.MissileSpeed, "Missile Speed")

    mModNames.AddorUpdate(eModifierType.MissChance, "Right-Click Miss Chance Added") 'Broodmother incapacitating Bite

    mModNames.AddorUpdate(eModifierType.MuteMove, "Movement Disabled") '= 82 'unable to move

    mModNames.AddorUpdate(eModifierType.MoveSpeedAdded, "Movement Speed Added") '= 21 ''http://dota2.gamepedia.com/Slow

    mModNames.AddorUpdate(eModifierType.MoveSpeedMinimum, "Minimum Movement Speed Set") 'for haste, sets minimum movespeed at time for unit, used for Centaur stampede, etc

    mModNames.AddorUpdate(eModifierType.MoveSpeedoT, "Movement Speed Over Time Added") '= 23

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercent, "Move Speed Increase")

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercentAdded, "Movement Speed Increase") 'Slardar Sprint

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP, "Movement Speed Increase Per Missing Hero HP") 'Bloodseeker Thirst

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercentAsDamage, "Bash Physical Damage Increase") 'Spiritbreaker greater bash

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercentofTargetAdded, "Movement Speed Added") 'Visage Grave Chill

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercentStackSubtracted, "Movement Speed Decreased") 'Bristleback Nasal Goo

    mModNames.AddorUpdate(eModifierType.MoveSpeedPercentSubtracted, "Movement Speed Removed") 'Bristleback Nasal Goo

    mModNames.AddorUpdate(eModifierType.MoveSpeedSet, "Movement Speed Set") 'Lycan Shapeshift

    mModNames.AddorUpdate(eModifierType.MoveSpeedStackAdded, "Movement Speed Added") 'Lina Fiery Soul

    mModNames.AddorUpdate(eModifierType.MoveSpeedSubtracted, "Movement Speed Reduced") 'boar moveslow

    mModNames.AddorUpdate(eModifierType.MulticastBloodlustCoolReduction, "Bloodlust Cooldown Reduction")

    mModNames.AddorUpdate(eModifierType.MulticastBloodlustRadiusAdded, "Bloodlust Radius Added")

    mModNames.AddorUpdate(eModifierType.MulticastFireblastCoolReduction, "FireBlast Cooldown Reduction")

    mModNames.AddorUpdate(eModifierType.MulticastFireblastManaAdded, "FireBlast Mana Added")

    mModNames.AddorUpdate(eModifierType.MulticastFourXChance, "4x Chance")

    mModNames.AddorUpdate(eModifierType.MulticastIgniteCastRangeAdded, "Ignite Range Added")

    mModNames.AddorUpdate(eModifierType.MulticastIgniteRadius, "Ignite Radius Added")

    mModNames.AddorUpdate(eModifierType.MulticastThreeXChance, "3x Chance")

    mModNames.AddorUpdate(eModifierType.MulticastTwoXChance, "2x Chance")

    mModNames.AddorUpdate(eModifierType.MysticSnakeDamageAdded, "Magic Damage Inflicted") 'Medusa Mystic Snake. ability bounces between enemies, inflicting more damage the more it jumps

    mModNames.AddorUpdate(eModifierType.MysticSnakeManaAdded, "Mana Added") 'Medusa Mystic Snake. ability bounces between enemies, grabbing more mana the more it jumps

    mModNames.AddorUpdate(eModifierType.MysticSnakeManaSubtracted, "Mana Reduced") 'enemy units hit by mystic snake lose mana

    mModNames.AddorUpdate(eModifierType.BaseGold, "Gold Accumulated")

    mModNames.AddorUpdate(eModifierType.NightAttackSpeedAdded, "Attack Speed Added") 'Nightstalker Hunter in the Night

    mModNames.AddorUpdate(eModifierType.NightAttackSpeedSubtracted, "Attack Speed Removed") 'Nightstalker Void. Duration differs for day and night

    mModNames.AddorUpdate(eModifierType.NightMoveSpeedAdded, "Movement Speed Added") 'NightStalker Hunter in the Night

    mModNames.AddorUpdate(eModifierType.OpenWoundsSlowInflicted, "Movement Speed Reduced") 'Lifestealer Open Wounds. Will have to call list for slow values for each interval

    mModNames.AddorUpdate(eModifierType.PercentofCreepHealthGained, "HP Added") 'Clinks DeathPact

    mModNames.AddorUpdate(eModifierType.PeriodicGold, "Periodic Gold")

    mModNames.AddorUpdate(eModifierType.Phantasms, "Phantasm") 'Chaoes night ulti, receiver will have to get current chaos knight build to calc phant stats

    mModNames.AddorUpdate(eModifierType.PhantomStrikeAttSpeedAdded, "Right-click Attack Speed Added for ? Attacks") 'Phantom Ass, Phantom Strike. If target is enemy hero the att speed added for mCharge count of rightclick attacks

    mModNames.AddorUpdate(eModifierType.Phase_Form, "Phase Form") 'phase boots

    mModNames.AddorUpdate(eModifierType.PoisonAttack, "Magic Damage Inflicted") '= 46 'Viper, Orb of Venom

    mModNames.AddorUpdate(eModifierType.PrimaryStatDamageAdded, "Physical Damage Inflicted") 'Ethereal Blade

    mModNames.AddorUpdate(eModifierType.PrimaryStatLossPercent, "? Decrease") '? is either int, str, agi'timeber whirling death

    mModNames.AddorUpdate(eModifierType.Pullback, "Pull Back") ' x marks, pudgehook

    mModNames.AddorUpdate(eModifierType.PullForward, "Pull Forward")

    mModNames.AddorUpdate(eModifierType.Purge, "Purde") 'this should at least be accompanied by move slow and att slow '= 74 'http://dota2.gamepedia.com/Purge

    mModNames.AddorUpdate(eModifierType.PurgeFrequency, "Purge Frequency") 'isn't this just purgeval.mchance? '= 75

    mModNames.AddorUpdate(eModifierType.PushForward, "Push Forward") 'force staff

    mModNames.AddorUpdate(eModifierType.PushSideways, "Push SideWays") 'Beastmaster Primal Roar

    mModNames.AddorUpdate(eModifierType.QuillSprayCast, eModifierType.QuillSprayCast.ToString) 'Bristleback Bristleback ability

    mModNames.AddorUpdate(eModifierType.RabidAttackSpeedAdded, "Attack Speed Added") 'Lone Druid Rabid. Has to apply to both druid and bear

    mModNames.AddorUpdate(eModifierType.RabidDurationBonus, "Rabid Duration Time Added") 'Lone Druid

    mModNames.AddorUpdate(eModifierType.RabidMoveSpeedAdded, "Rabid Movespeed Added") 'Lone Druid Rabid. Needs to add to both druid and bear

    mModNames.AddorUpdate(eModifierType.RandomTargetHealAdded, "Health Restored") 'Enchantress nature's attendants

    mModNames.AddorUpdate(eModifierType.RangeSlow, "Right-click Ranged Attack Speed Decreased")

    mModNames.AddorUpdate(eModifierType.RangeStun, "Stun") 'Abyssal blade

    mModNames.AddorUpdate(eModifierType.ReflectedDamageInflicted, "Incoming Damage Inflicted to Damage Source") 'Nyx Spiked Carapace. damage component of spell. inlficted on attacker

    mModNames.AddorUpdate(eModifierType.Reincarnate, "Return To Life Where Unit Died") 'Aegis

    mModNames.AddorUpdate(eModifierType.RemoveBuffs, "Removes Buffs") 'Diffusal Blade

    mModNames.AddorUpdate(eModifierType.RemoveDebuffs, "Removes Debuffs") ' abaddon ulti

    mModNames.AddorUpdate(eModifierType.RemoveDisables, "Removes Disables") 'LC Press the attack

    mModNames.AddorUpdate(eModifierType.ReplacedByPets, "BrewMaster Splits into 3") 'Brew Primal Split

    mModNames.AddorUpdate(eModifierType.ResourceShare, "Resource Share")

    mModNames.AddorUpdate(eModifierType.petEarth_Brewmaster, "Earth Spirit")

    mModNames.AddorUpdate(eModifierType.petStorm_Brewmaster, "Storm Spirit")

    mModNames.AddorUpdate(eModifierType.petFire_Brewmaster, "Fire Spirit")

    mModNames.AddorUpdate(eModifierType.Replicant, "Replicant") 'Morphling Replicate. Need to know which hero is targeted at the time

    mModNames.AddorUpdate(eModifierType.RequiemDamageMagicalInflicted, "Magic Damage Inflicted") 'Shadow Fiend Reqiem of Souls. Damage is per line. Line count is 1 for each 2 soulds in Necromastery

    mModNames.AddorUpdate(eModifierType.Reset_Cooldowns, "Resets Ability and Item Cooldowns") 'Refresher

    mModNames.AddorUpdate(eModifierType.RightClickAttackAttackSlowInflicted, "Attack Speed Reduced") 'Right click attack also adds an attack speed debuff to target

    mModNames.AddorUpdate(eModifierType.RightClickAttackDamage, "Right-click Physical Damage Added") 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage

    mModNames.AddorUpdate(eModifierType.RightClickDamageFromPrimaryAtt, "Right-click Physical Damage from Strength")

    mModNames.AddorUpdate(eModifierType.RightClickBonusDamageAdded, "Right-click Bonus Physical Damage Added") 'TB Metamorphosis

    mModNames.AddorUpdate(eModifierType.RightClickBonusDamageInflicted, "Right Click Bonus Damage Inflicted") 'Faceless Void Time Lock

    mModNames.AddorUpdate(eModifierType.RightClickBonusPureDamageInflicted, "Bonus Pure Damage Inflicted") 'Spectre Desolate

    mModNames.AddorUpdate(eModifierType.RightClickCausticFinale, "Cuastic Finale Damage Added") 'Sand King Caustic Finale added

    mModNames.AddorUpdate(eModifierType.RightClickCounterAttack, "Additional Right-click Inflicted") 'Axw counter helix, LC MomentofCOurage

    mModNames.AddorUpdate(eModifierType.RightClickDamageAdded, "Right-click Physical Damage Added") 'LC Duel

    mModNames.AddorUpdate(eModifierType.RightClickDamageAsLine, "Right-click Physical Damage Inflicted") 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets

    mModNames.AddorUpdate(eModifierType.RightClickDamageAsPercOfTargetCurrHP, "Right-click Physical Damage Inflicted") 'lifestealer Feast

    mModNames.AddorUpdate(eModifierType.RightClickDamageInflicted, "Right-click Physical Damage Inflicted") 'Windranger Focus Fire

    mModNames.AddorUpdate(eModifierType.RightClickDamageInstanceAvoided, "Incoming Right-click Damage Instance Removed") 'Faceless BackTrack

    mModNames.AddorUpdate(eModifierType.RightClickDamageMultipleInflicted, "Right-click Physical Damage Multiple Inflicted") 'Phantom Ass, Coup de Grace

    mModNames.AddorUpdate(eModifierType.RightClickDamageMultiplier, "Right Click Damage Increase") 'weaver germinate

    mModNames.AddorUpdate(eModifierType.RightClickDamageoT, "Right Click Damage Over Time Inflicted") 'Right Click attack also puts a DoT on target

    mModNames.AddorUpdate(eModifierType.RightClickDamagePercentageInflicted, "of Right-click Damage Inflicted")

    mModNames.AddorUpdate(eModifierType.RightClickDamagePercentInflicted, "Right-click Physical Damage Inflicted") 'Phantom Lancer Spirit Lance Illusion damage

    mModNames.AddorUpdate(eModifierType.RightClickDamagePercentSubtracted, "Right-click Physical Damage Decreased") 'SF Requiem of Souls

    mModNames.AddorUpdate(eModifierType.RightClickDamageWithBuffs, "Right-click Physical Damage Inflicted") 'gyro flak cannon

    mModNames.AddorUpdate(eModifierType.RightClickDamageWithoutBuffs, "Right-click Physical Damage Inflicted") 'gyro flak cannon

    mModNames.AddorUpdate(eModifierType.RightClickDamPhysStackingInflicted, "Right-click Physical Damage Inflicted") 'Ursa furry swipes

    mModNames.AddorUpdate(eModifierType.RightClickHealthasDamagePercInflicted, "Right-click Physical Damage Inflicted") 'Ursa Enrage

    mModNames.AddorUpdate(eModifierType.RightClickInttoPureDamage, "Pure Damage Inflicted") 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage

    mModNames.AddorUpdate(eModifierType.RightClickMoonGlaiveBounces, "Right-click Damage Bounces") 'Luna moon glaive

    mModNames.AddorUpdate(eModifierType.RightClickMoveSpeedPercSubtracted, "Movement Speed Reduced") 'Meepo Geostrike

    mModNames.AddorUpdate(eModifierType.MuteRightClick, "Right-click Damage Disabled") '= 84 'unable to rightclick

    mModNames.AddorUpdate(eModifierType.RightClickNetherToxinDamage, "Right-click Physical Damage Inflicted") 'Viper Nethertoxin does damage for each 20% of health missing in target

    mModNames.AddorUpdate(eModifierType.RightClickStun, "Stun") 'Faceless TimeLock

    mModNames.AddorUpdate(eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff, "Magic Damage Inflicted") 'OD Sanity's Eclipse. Damage is a multiple of the difference between OD's int and affected enemy's int. if difference is negative, then no effect

    mModNames.AddorUpdate(eModifierType.SanitysManaPercentRemovedwithThreshold, "Mana Removed") 'OD Sanity's Eclipse. If the diff of int between OD and affected enemy is less than threshold then mana removed

    mModNames.AddorUpdate(eModifierType.SearingArrows, eModifierType.SearingArrows.ToString) '= 42 'Clinkz

    mModNames.AddorUpdate(eModifierType.SelfDeny, "Self Deny") 'Bloodstone Pocket Suicide

    mModNames.AddorUpdate(eModifierType.ShackleTime, eModifierType.ShackleTime.ToString) '= 61 'http://dota2.gamepedia.com/Disable like lasso

    mModNames.AddorUpdate(eModifierType.ShadowPoisonStackDamage, "Magic Damage Added") 'Shadow Demon Shadow Poison, Each staup up to 5 increases damage, after that it's 50 each addl stack

    mModNames.AddorUpdate(eModifierType.ShallowGrave, "Target is Unkillable, But Still Takes Damage") 'Dazzle

    mModNames.AddorUpdate(eModifierType.Shatter, "Target Dies if below *% Health") 'AA IceBlast

    mModNames.AddorUpdate(eModifierType.Silence, "Ability and Item Casts Disabled") '= 76 'http://dota2.gamepedia.com/Silence

    mModNames.AddorUpdate(eModifierType.Sleep, "Unit Stunned until Hit with Damage") '= 66 'http://dota2.gamepedia.com/Sleep

    mModNames.AddorUpdate(eModifierType.SpellBlock, "Blocks ? Incoming Spell") ' Linken's blocks n spells

    mModNames.AddorUpdate(eModifierType.SpellBlockDuration, "Incoming Spell Block") ' Blocks all spells for n seconds

    mModNames.AddorUpdate(eModifierType.StaticFieldHealthReduction, "Health Removed") 'Zeus Static Field

    mModNames.AddorUpdate(eModifierType.StaticLinkBonusDamage, "Right-click Physical Damage Added") 'Razer

    mModNames.AddorUpdate(eModifierType.StaticStormDamageMagicalInflicted, "Magic Damage Inflicted") 'Disruptor Static Storm. Will have to call list for pulse values and calc with or without aghs

    mModNames.AddorUpdate(eModifierType.StationaryInvisibility, "Invisibility until Unit Moves") 'TA Meld. Invis until TA moves

    mModNames.AddorUpdate(eModifierType.StealthVisibility, "Reveals Invisible Enemy Units") 'dust of appearance, sentry wards

    mModNames.AddorUpdate(eModifierType.StrAdded, "Strength Added") '= 12

    mModNames.AddorUpdate(eModifierType.StrAddedPerKill, "Strength Added Per Kill") 'pudge FleshHeap

    mModNames.AddorUpdate(eModifierType.StrengthPercentageAsAllDamage, "Damage All Types Increase") 'Centaur stampede

    mModNames.AddorUpdate(eModifierType.StrengthPercentageCounterAttack, eModifierType.StrengthPercentageCounterAttack.ToString) 'Centaur Warrunner ,

    mModNames.AddorUpdate(eModifierType.StroT, "Strength Added Over Time") '= 14

    mModNames.AddorUpdate(eModifierType.StrSubtracted, "Strength Removed") 'Slark Essence Shift

    mModNames.AddorUpdate(eModifierType.Stun, "Stun") '= 60 'http://dota2.gamepedia.com/Stun 'Does NOT include MiniStuns

    mModNames.AddorUpdate(eModifierType.StunChain, "Stun Instances") 'Witch doc Paralyzing Cask

    mModNames.AddorUpdate(eModifierType.StunRandom, "Random Stun") 'ChaosKnight Chaos Bolt

    mModNames.AddorUpdate(eModifierType.Sunder, "Health Restored") 'TB Sunder. Swaps health with target

    mModNames.AddorUpdate(eModifierType.MuteTargetability, "Abilities Disabled") '= 85 'unable to be targetted

    mModNames.AddorUpdate(eModifierType.TargetedDamageReflected, "Incoming Damage Reflected and Inflicted to Damage Source") 'nyx Spiked Carapace. Only reflects damage targetted directly at nyx

    mModNames.AddorUpdate(eModifierType.MuteAllOnTarget, "Abilities, Items, Movement and Right-click Disabled") 'stops eveything on target (items, move, abilities, etc.) Bane Nightmare

    mModNames.AddorUpdate(eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced, "Magic Damage Inflicted") 'Huskar Life Break Damage Dealt

    mModNames.AddorUpdate(eModifierType.Taunt, "Forces Target to Attack Caster") '= 65 'http://dota2.gamepedia.com/Taunt

    mModNames.AddorUpdate(eModifierType.Teleport, "Teleport") '= 78

    mModNames.AddorUpdate(eModifierType.MuteTeleport, "Teleport Disabled") 'Blink (Queen of Pain) , Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger.

    mModNames.AddorUpdate(eModifierType.TeleportRandom, "Teleport") 'Chaosknight Reality Rift

    mModNames.AddorUpdate(eModifierType.TimeLapse, eModifierType.TimeLapse.ToString) 'weaver ulti

    mModNames.AddorUpdate(eModifierType.TinyTossBonusDamage, "Bonus Damage Added to Toss") 'Tiny Grow

    mModNames.AddorUpdate(eModifierType.TinyTossDamageInflicted, "Magic Damage Inflicted") 'seperate type to enable check for TinyTossBonusDamage

    mModNames.AddorUpdate(eModifierType.Traptime, "Trap") '= 64 'http://dota2.gamepedia.com/Trap clockwork cogs

    mModNames.AddorUpdate(eModifierType.TrueFormHPAdded, "Health Added") 'Lone Druid 

    mModNames.AddorUpdate(eModifierType.Truesight, "TrueSight") '= 39 'http://dota2.gamepedia.com/Invisibility

    mModNames.AddorUpdate(eModifierType.TruesightofTarget, "TrueSight of Target") 'bounty hunter track

    mModNames.AddorUpdate(eModifierType.MuteTurn, "Turning Disabled") '= 83 'unable to turn

    mModNames.AddorUpdate(eModifierType.TurnRateSubtracted, "Turn Rate Added") 'Batrider Sticky Napalm

    mModNames.AddorUpdate(eModifierType.UnobstructedMovementandVision, "Unobstructed Movement & Vision") 'batrider firefly

    mModNames.AddorUpdate(eModifierType.UnobstructedVision, "Unobstructed Vision") 'Nightstalker Darkness

    mModNames.AddorUpdate(eModifierType.VanguardMeleeBlockAdded, "Damage Block Added") 'block dependant on whether you are melee or ranged

    mModNames.AddorUpdate(eModifierType.VanguardRangeblockAdded, "Damage Block Added") 'Vanguard:

    mModNames.AddorUpdate(eModifierType.Vision, "Vision Added") 'observerward

    mModNames.AddorUpdate(eModifierType.VisionDay, "Vision Added") 'beast hawk

    mModNames.AddorUpdate(eModifierType.VisionNight, "Vision Added") 'beast hawk

    mModNames.AddorUpdate(eModifierType.VisionNightAdded, "Vision Added") 'Lycan Shapeshift

    mModNames.AddorUpdate(eModifierType.VoidMoveSpeedPercentSubtracted, "Movement Speed Decreased") 'Nightstalker void. Duration changes depending on day or night

    mModNames.AddorUpdate(eModifierType.WallHeroReplica, "Replica Wall") 'Dark Seer Wall of Replica

    mModNames.AddorUpdate(eModifierType.Web, "Web") 'Broodmother Spin Web

    mModNames.AddorUpdate(eModifierType.WitchcraftCooldownDecrease, "Witchcraft Cooldown Decrease")

    mModNames.AddorUpdate(eModifierType.WitchcraftManaCostDecrease, "Witchcraft Mana Cost Decrease") 'DP Witchcraft

    mModNames.AddorUpdate(eModifierType.WitchcraftSpiritIncrease, "Additional Witchcraft Spirits")

    mModNames.AddorUpdate(eModifierType.WrathofNatureMagicDamageBounceInflicted, "Magic Damage Bounces") 'Nature's Proph damage increases with each bounce

    mModNames.AddorUpdate(eModifierType.XPAdded, "XP Added") 'Lich Sacrifice

    mModNames.AddorUpdate(eModifierType.ZombiesPerUnit, "Zombies Per Unit") 'Undying Tombstone Zombies

    mModNames.AddorUpdate(eModifierType.IntIncrementAdded, "Intelligence Level Increment")

    mModNames.AddorUpdate(eModifierType.AgiIncrementAdded, "Agility Level Increment")

    mModNames.AddorUpdate(eModifierType.StrIncrementAdded, "Strength Level Increment")



  End Sub
  Public Sub LoadDamageNames()
    mDamageNames = New OneToOneDoubleDictionary(Of eDamageType, String)(mLog)
    mDamageNames.AddorUpdate(eDamageType.Magical, "Magical")
    mDamageNames.AddorUpdate(eDamageType.None, "None")
    mDamageNames.AddorUpdate(eDamageType.Physical, "Physical")
    mDamageNames.AddorUpdate(eDamageType.Pure, "Pure")
  End Sub
  Private Sub LoadAbilityTypeNames()
    mAbilityTypeNames = New OneToOneDoubleDictionary(Of eAbilityType, String)(mLog)

    mAbilityTypeNames.AddorUpdate(eAbilityType.ActiveAura, "Active Aura")

    mAbilityTypeNames.AddorUpdate(eAbilityType.AutoCast, "Autocast")

    mAbilityTypeNames.AddorUpdate(eAbilityType.Channeled, "Channeled")

    mAbilityTypeNames.AddorUpdate(eAbilityType.PointTargetCone, "Cone")

    mAbilityTypeNames.AddorUpdate(eAbilityType.PointTargetLine, "Line")

    mAbilityTypeNames.AddorUpdate(eAbilityType.MapWideAura, "Global")

    mAbilityTypeNames.AddorUpdate(eAbilityType.NoTarget, "No Target")

    mAbilityTypeNames.AddorUpdate(eAbilityType.Passive, "Passive")

    mAbilityTypeNames.AddorUpdate(eAbilityType.PassiveAura, "Passive Aura")

    mAbilityTypeNames.AddorUpdate(eAbilityType.PointTarget, "Ground Point Target")

    mAbilityTypeNames.AddorUpdate(eAbilityType.PointTargetAura, "Ground Point Target Aura")

    mAbilityTypeNames.AddorUpdate(eAbilityType.Stats, "Stat Buff")

    mAbilityTypeNames.AddorUpdate(eAbilityType.Toggle, "Toggle")

    mAbilityTypeNames.AddorUpdate(eAbilityType.Trail, "Trail")

    mAbilityTypeNames.AddorUpdate(eAbilityType.UnitTarget, "Unit Target")

  End Sub

  Public Sub LoadItemPlanNames()
    mItemPlanNames = New OneToOneDoubleDictionary(Of eItemPlan, String)(mLog)

    mItemPlanNames.AddorUpdate(eItemPlan.UseAtOnce, "Use at Once")

    mItemPlanNames.AddorUpdate(eItemPlan.Disassemble, "Split for Parts")

    mItemPlanNames.AddorUpdate(eItemPlan.KeepForever, "Keep or Combine")

    mItemPlanNames.AddorUpdate(eItemPlan.SellAtOnce, "Sell at Once")

    mItemPlanNames.AddorUpdate(eItemPlan.SellForSpace, "Sell for Space")

    mItemPlanNames.AddorUpdate(eItemPlan.UseFor1Level, "Keep 1 Level")

    mItemPlanNames.AddorUpdate(eItemPlan.UseFor2Levels, "Keep 2 Levels")

    mItemPlanNames.AddorUpdate(eItemPlan.UseFor3Levels, "Keep 3 Levels")

    mItemPlanNames.AddorUpdate(eItemPlan.UseFor4Levels, "Keep 4 Levels")

    mItemPlanNames.AddorUpdate(eItemPlan.UseFor5Levels, "Keep 5 Levels")

  End Sub

  Public Function GetFriendlyTeamName(team As eTeamName) As String
    Select Case team
      Case eTeamName.Radiant
        Return "Radiant"
      Case eTeamName.Dire
        Return "Dire"
      Case Else
        Throw New NotImplementedException
    End Select
  End Function
  Public Sub LoadUnitNames()
    mUnitNames = New OneToOneDoubleDictionary(Of eUnit, String)(mLog)

    mUnitNames.AddorUpdate(eUnit.untSelf, "Self")

    mUnitNames.AddorUpdate(eUnit.untAlliedHero, "Allied Hero")

    mUnitNames.AddorUpdate(eUnit.untAlliedHeroes, "Allied Heroes")

    mUnitNames.AddorUpdate(eUnit.untAlliedUnit, "Allied Hero or Creep")

    mUnitNames.AddorUpdate(eUnit.untAlly, "Allied Hero or Creep")

    mUnitNames.AddorUpdate(eUnit.untAlliedUnits, "Allied Heroes and Creeps")

    mUnitNames.AddorUpdate(eUnit.untAlliedMeleeUnits, "Melee Ally")

    mUnitNames.AddorUpdate(eUnit.untAlliedNonHeroUnits, "Non-Hero Ally")

    mUnitNames.AddorUpdate(eUnit.untAlliedRangeUnits, "Ranged Ally")

    mUnitNames.AddorUpdate(eUnit.untAlliedStructure, "Allied Structure")

    mUnitNames.AddorUpdate(eUnit.untHeroes, "Allied and Enemy Heroes")

    mUnitNames.AddorUpdate(eUnit.untEnemyTarget, "Targetted Enemy")

    mUnitNames.AddorUpdate(eUnit.unitTargettedEnemyCreep, "Targetted Enemy Creep")

    mUnitNames.AddorUpdate(eUnit.untEnemyUnit, "Enemy Unit")

    mUnitNames.AddorUpdate(eUnit.untEnemyUnits, "Enemies")

    mUnitNames.AddorUpdate(eUnit.untEnemyCreeps, "Enemy Creeps")

    mUnitNames.AddorUpdate(eUnit.untEnemyCreep, "Enemy Creep")

    mUnitNames.AddorUpdate(eUnit.untEnemyHero, "EnemyHero")

    mUnitNames.AddorUpdate(eUnit.untEnemyHeroes, "Enemy Heroes")

    mUnitNames.AddorUpdate(eUnit.untAttackingEnemyUnit, "Attacking Enemy")

    mUnitNames.AddorUpdate(eUnit.untEnemieTeam, "Enemy Team")

    mUnitNames.AddorUpdate(eUnit.untEnemyHeroNearest, "Nearest Enemy Hero")

    mUnitNames.AddorUpdate(eUnit.untEnemyMeleeTarget, "Targetted Enemy Melee Unit")

    mUnitNames.AddorUpdate(eUnit.untEnemyRangedTarget, "Targetted Enemy Ranged Unit")

    mUnitNames.AddorUpdate(eUnit.untEnemyStealthUnits, "Invisible Enemy Units")

    mUnitNames.AddorUpdate(eUnit.untEnemyStructure, "Enemy Structure")

    mUnitNames.AddorUpdate(eUnit.untEnemySummonedUnit, "Summoned Enemy Unit")

    mUnitNames.AddorUpdate(eUnit.untEnemyUnitsNotTargetted, "Untargetted Enemies")

    mUnitNames.AddorUpdate(eUnit.untEnemyUnitwLowestHealth, "Enemy with Lowest Health")

    mUnitNames.AddorUpdate(eUnit.untRandomUnit, "Random Unit")

    mUnitNames.AddorUpdate(eUnit.untRandomEnemyUnit, "Random Enemy Unit")

  End Sub
#End Region

End Class
