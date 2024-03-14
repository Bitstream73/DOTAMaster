Public Class abTornado
Inherits AbilityBase
  Public wextrvldist As ValueWrapper
  Public wexbonusdamage As ValueWrapper
  Public quascycloneduration As ValueWrapper
  Public visionradius As ValueWrapper
  Public visionduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Tornado travels at a speed of 1000 and always travels the full distance, so it takes 0.8/1.2/1.6/2/2.4/2.8/3.2 seconds to reach the max distance.|Tornado can hit units up to 1000/1400/1800/2200/2600/3000/3400 range away (travel distance + 200 effect radius).|Applies a Cyclone effect on the affected units, so it applies a normal dispel on them, turns them invulnerable and fully disables them for its duration.|The damage is applied right after the cyclone ends. Can deal up to 115/160/205/250/295/340/385 damage to each affected unit (before reductions).|Cycloned units lose their collision size for the duration, so units can path below them.|Does not affect ancient creeps, Roshan, Warlock's Golem and Storm and Fire from Primal Split.|Tornado provides 600 radius flying vision as it travels. This vision does not last.|Also provides the same vision for 1.75 seconds after reaching its max travel distance."

    mDisplayName = "Tornado"
    mName = eAbilityName.abTornado
    Me.EntityName = eEntity.abTornado

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_tornado_hp2.png"

    Description = "Unleashes a fast moving tornado that picks up enemy units in its path, suspending them helplessly in the air shortly before allowing them to plummet to their doom. Travels further based on the level of Wex. Holds enemies in the air for a duration based on the level of Quas. Deals damage based on the levels of Quas and Wex."

    ManaCost = New ValueWrapper(150, 150, 150, 150, 150, 150, 150)

    Cooldown = New ValueWrapper(30, 30, 30, 30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Radius = New ValueWrapper(200, 200, 200, 200, 200, 200, 200)
    Damage = New ValueWrapper(70, 70, 70, 70, 70, 70, 70)
    wextrvldist = New ValueWrapper(800, 1200, 1600, 2000, 2400, 2800, 3200)
    wexbonusdamage = New ValueWrapper(45, 90, 135, 180, 225, 270, 315)
    quascycloneduration = New ValueWrapper(0.8, 1.1, 1.4, 1.7, 2, 2.3, 2.5)
    visionradius = New ValueWrapper(600, 600, 600, 600, 600, 600, 600)
    visionduration = New ValueWrapper(0.8 + 1.75, 1.2 + 1.75, 1.6 + 1.75, 2 + 1.75, 2.4 + 1.75, 2.8 + 1.75, 3.2 + 1.75)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     thecaster As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim cycloneval As New modValue(quascycloneduration, eModifierType.QuasCyclone, occurencetime, aghstime)
    cycloneval.mValueDuration = quascycloneduration
    cycloneval.mRange = wextrvldist

    Dim cycmod As New Modifier(cycloneval, pointenemies)
    outmods.Add(cycmod)



    Dim damval As New modValue(Damage, eModifierType.WexDamageMagicalInflicted, occurencetime, aghstime)
    damval.mRange = wextrvldist

    Dim dammod As New Modifier(damval, pointenemies)
    outmods.Add(dammod)



    Dim bdamval As New modValue(wexbonusdamage, eModifierType.WexDamageMagicalInflicted, occurencetime, aghstime)
    bdamval.mRange = wextrvldist

    Dim bdammod As New Modifier(bdamval, pointenemies)
    outmods.Add(bdammod)



    Dim pointtargetallies = Helpers.GetPointTargetAuraAlliedHeroesInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim visval As New modValue(visionradius, eModifierType.WexVision, occurencetime, aghstime)
    visval.mRadius = visionradius
    visval.mValueDuration = visionduration

    Dim vismod As New Modifier(visval, pointtargetallies)
    outmods.Add(vismod)

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
