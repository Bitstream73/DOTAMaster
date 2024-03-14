Public Class abExorcism
  Inherits AbilityBase
  Public spiritcount As ValueWrapper
  Public lifedrainpercent As ValueWrapper
  Public spiritdamage As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Radius specifies the area around Death Prophet where spirits will choose new targets.|Spawns a maximum of 27 spirits.|The spirits' damage is reduced by armor, but NOT by damage block (Stout Shield, etc.).|The spirits will prioritize damage to the last hostile unit that was targeted.|Each spirit will heal Death Prophet for the amount of damage they have dealt.|Spirits travel at 500 movement speed upon return, making it possible to outrun them as they return.|Can damage siege creeps and structures." '"

    mDisplayName = "Exorcism"
    mName = eAbilityName.abExorcism
    Me.EntityName = eEntity.abExorcism

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDeath_Prophet

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/death_prophet_exorcism_hp2.png"

    Description = "Unleashes evil spirits to drain the life of nearby enemy units and structures. At the end of the spell's duration, Death Prophet is healed in proportion to the damage dealt. Lasts 30 seconds."

    ManaCost = New ValueWrapper(200, 300, 400)

    Cooldown = New ValueWrapper(145, 145, 145)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical



    Radius = New ValueWrapper(700, 700, 700)

    spiritcount = New ValueWrapper(4, 12, 21)

    lifedrainpercent = New ValueWrapper(0.25, 0.25, 0.25)

    spiritdamage = New ValueWrapper(55, 55, 55)

    Duration = New ValueWrapper(30, 30, 30)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    'Dim thecasterinf As HeroBuild = PageHandler.dbHeroBuilds.GetHeroBuild(thecaster)




    Dim notargetenemyunits = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'Dim notargetenemystructures = Helpers.GetNoTargetEnemyStructuresInfo(theability_InfoID, _
    '                                                           thecaster, _
    '                                                           thetarget, _
    '                                                           "", eModifierCategory.Active)


    'Dim drainval As New modValue(lifedrainpercent, eModifierType.LifeDrainPercent, occurencetime, aghstime)
    'drainval.mValueDuration = mDuration
    'drainval.Charges = spiritcount

    'Dim thedrain As New Modifier(drainval, notargetenemyunits)
    'outmods.Add(thedrain)



    'Dim damval As New modValue(spiritdamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    'damval.mValueDuration = mDuration
    'damval.Charges = spiritcount

    'Dim thedamage As New Modifier(damval, notargetenemyunits)
    'outmods.Add(thedamage)




    'Dim thespirits As New HeroPet_Info
    'thespirits.Duration = mDuration

    'thespirits.DamageHigh = New ValueWrapper(58, 58, 58, 58)
    'thespirits.DamageLow = New ValueWrapper(53, 53, 53, 53)

    'thespirits.LifeDrain = New ValueWrapper(0.25, 0.25, 0.25, 0.25)
    'thespirits.movementspeed = New ValueWrapper(500, 500, 500, 500)

    Dim outspirits As New modValue(spiritcount, eModifierType.petSpirit, occurencetime, aghstime)
    'outspirits.mPet = thespirits
    Duration = Duration

    Dim modoutspirits As New Modifier(outspirits, notargetenemyunits)
    outmods.Add(modoutspirits)

    'Dim modstructspirits As New Modifier(outspirits, notargetenemystructures)
    'outmods.Add(modstructspirits)

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
