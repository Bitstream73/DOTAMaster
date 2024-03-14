Public Class abHarpy_Stormcrafter_Chain_Lightning
  Inherits AbilityBase

  Public bouncedistance As ValueWrapper
  Public bouncecount As ValueWrapper
  Public basedamage As ValueWrapper
  Public bouncedamage As ValueWrapper
  Public bouncedamreduction As Double
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Chain Lightning"
    mName = eAbilityName.abHarpy_Stormcrafter_Chain_Lightning
    Me.EntityName = eEntity.abHarpy_Stormcrafter_Chain_Lightning

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHarpy_Stormcrafter

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/c5/Chain_Lightning_%28Harpy_Stormcrafter%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Harpy_Camp"
    Description = "The Harpy Stormcrafter releases a high-voltage bolt of electricity at the target enemy, dealing damage. The bolt jumps to other nearby enemies, losing power with each jump."
    Notes = "The lightning bounces in 0.25 second intervals. So hitting all target takes 0.75 seconds.|Does not bounce on invisible units or units in the Fog of War.|Unlike other chain lightning spells, this one bounces to a random unit within the bounce distance, instead of the closest within the distance.|Can never hit the same unit twice per cast.|The first hit deals 140 damage, the second 105, the third 78.75 and the last 59.1 damage (before reductions).|All bounces together can deal up to 382.81 damage (before reductions).|As a neutral unit: The harpy never casts this spell.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(50)

    Cooldown = New ValueWrapper(4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    Range = New ValueWrapper(900)
    bouncedistance = New ValueWrapper(500)
    bouncecount = New ValueWrapper(4)
    basedamage = New ValueWrapper(140)
    bouncedamreduction = 0.25
    bouncedamage = New ValueWrapper(basedamage.Value(0) * bouncedamreduction)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim unittargetuntargettedenemies = Helpers.GetUnitTargetUntargettedEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim damval As New modValue(basedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)

    Dim bounceval As New modValue(bouncedamage, eModifierType.DamageMagicalBouncesInflicted, occurencetime, aghstime)
    bounceval.Charges = bouncecount

    Dim bouncemod As New Modifier(bounceval, unittargetuntargettedenemies)
    outmods.Add(bouncemod)


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
