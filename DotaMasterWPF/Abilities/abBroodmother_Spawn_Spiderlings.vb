Public Class abSpawn_Spiderlings
  Inherits AbilityBase

  Public spiderlingcount As ValueWrapper
  'Public movedebuff As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Spawn Spiderlings' projectile travels at a speed of 1200.|Spawn Spiderlings can be disjointed.|Spiderlings will only spawn when the targeted unit dies while having the debuff on.|It doesn 't matter who kills the target, if it dies in any way, the spiderlings will spawn.|Spiderlings possess the Poison Sting icon.png Poison Sting and Spawn Spiderite abilities.|Spiderlings are fully affected by Spin Web icon.png Spin Web." '"
    mDisplayName = "Spawn Spiderlings"
    mName = eAbilityName.abSpawn_Spiderlings
    Me.EntityName = eEntity.abSpawn_Spiderlings

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBroodmother

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/broodmother_spawn_spiderlings_hp2.png"

    Description = "Broodmother injects her young into an enemy unit, dealing damage. The spiderlings will hatch if the target is killed while under this influence."


    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(10, 10, 10, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(75, 150, 225, 300)



    spiderlingcount = New ValueWrapper(1, 2, 3, 4)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'Dim theduration = New TimeSpan(0, 1, 0)


    'Spiderlings and Spiderites

    'Dim spiderling As New HeroPet_Info

    'spiderling.hitpoints = New ValueWrapper(450, 450, 450, 450)

    'spiderling.armor = New ValueWrapper(0, 0, 0, 0)
    'spiderling.armortype = eArmorType.None

    'spiderling.movementspeed = New ValueWrapper(350, 350, 350, 350)

    'spiderling.SightRange.Add(New ValueWrapper(1400, 1400, 1400))
    'spiderling.SightRange.Add(New ValueWrapper(800, 800, 800))

    'spiderling.Duration = New ValueWrapper(60, 60, 60, 60)

    'spiderling.HealthRegen = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    'spiderling.DamageHigh = New ValueWrapper(19, 19, 19, 19)
    'spiderling.DamageLow = New ValueWrapper(18, 18, 18, 18)

    'spiderling.SightRange.Add(New ValueWrapper(1100, 1100, 1100))
    'spiderling.SightRange.Add(New ValueWrapper(800, 800, 800))

    'spiderling.bounty = New ValueWrapper(13, 13, 13, 13)

    'spiderling.notes = "Poison Sting and Spawn Spiderite Abilities"

    'spiderling.xpvalue = New ValueWrapper(31, 31, 31, 31)
    'spiderling.notes = "Abilities: Poison Sting, Spawn Spiderite"

    Dim spiderlingval As New modValue(spiderlingcount, eModifierType.petSpiderling, occurencetime, aghstime)
    ' spiderlingval.mPet = spiderling
    spiderlingval.mValueDuration = New ValueWrapper(60, 60, 60, 60)

    Dim thespiderling As New Modifier(spiderlingval, unittargetenemy)
    outmods.Add(thespiderling)

    'Spiderite
    'Dim spiderite As New HeroPet_Info
    'spiderite.hitpoints = New ValueWrapper(175, 175, 175, 175)

    'spiderite.armor = New ValueWrapper(0, 0, 0, 0)
    'spiderite.armortype = eArmorType.None

    'spiderite.SightRange.Add(New ValueWrapper(1400, 1400, 1400))
    'spiderite.SightRange.Add(New ValueWrapper(800, 800, 800))

    'spiderite.DamageHigh = New ValueWrapper(10, 10, 10, 10)
    'spiderite.DamageLow = New ValueWrapper(9, 9, 9, 9)

    'spiderite.bounty = New ValueWrapper(21, 21, 21, 21)

    'spiderite.notes = "No abilities"
    'spiderite.xpvalue = New ValueWrapper(20, 20, 20, 20)

    'spiderite.notes = "Spiderites will only spawn when the attacked unit dies while having the debuff on.|It doesn't matter who kills the target, if it dies in any way, the spiderites will spawn.|Spawn Spiderite does not affect wards and buildings, but affects allies."

    Dim spideriteval As New modValue(New ValueWrapper(1, 1, 1, 1), eModifierType.petSpiderite, occurencetime, aghstime)
    'spideriteval.mPet = spiderite
    spideriteval.mValueDuration = New ValueWrapper(60, 60, 60, 60)

    Dim thespiderite As New Modifier(spideriteval, unittargetenemy)
    outmods.Add(thespiderite)



    'poison Sting

    'Dim unittargetenemyunit = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
    '                                                           thecaster, _
    '                                                           thetarget, _
    '                                                           "", eModifierCategory.Active)

    'Dim damval As New modValue(mDamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    'Dim dammod As New Modifier(damval, unittargetenemyunit)
    'outmods.Add(dammod)

    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                theowner As iDisplayUnit, _
                                                thetarget As iDisplayUnit, _
                                                ftarget As iDisplayUnit, _
                                                isfriendbias As Boolean, _
                                                occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class