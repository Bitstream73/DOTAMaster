Public Class abEcho_Slam
  Inherits AbilityBase
  Public echodamage As ValueWrapper
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

    Notes = "Echo Slam icon.png Echo Slam as an instant cast time, though the backswing animation has to be manually canceled. Interrupts channeling spells.|Each unit within the initial AoE will produce an echo wave, dealing damage to units within a 575 radius around itself (including itself).|Creeps killed by Echo Slam icon.png Echo Slam's initial damage will still give off echo wave damage.|The initial damage is applied instantly in the AoE, while the echo waves travel at a speed of 550.|The Aghanim 's Scepter icon.png Aghanim's Scepter upgrade treats illusions as heroes, means they will echo twice aswell.|Fully affects invisible units and units in Fog of War.|Total damage to a single unit when hitting a certain number of heroes with no creeps nearby (before reductions):|1 Hero: 200/265/340 (240/320/410)|2 Heroes: 240/320/410 (320/430/550)|3 Heroes: 280/375/480 (400/540/690)|4 Heroes: 320/430/550 (480/650/830)|5 Heroes: 360/485/620 (560/760/970)" '"

    mDisplayName = "Echo Slam"
    mName = eAbilityName.abEcho_Slam
    Me.EntityName = eEntity.abEcho_Slam

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarthshaker

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earthshaker_echo_slam_hp2.png"

    Description = "Shockwaves travel through the ground, damaging enemy units. Each enemy hit causes an echo to damage nearby units. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(145, 205, 265)

    Cooldown = New ValueWrapper(150, 130, 110)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(160, 210, 270)

    Radius = New ValueWrapper(575, 575, 575)

    echodamage = New ValueWrapper(40, 55, 70)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, auraenemies)
    outmods.Add(thedamage)


    Dim echoval As New modValue(echodamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim theechodamage As New Modifier(echoval, auraenemies)
    outmods.Add(theechodamage)

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
