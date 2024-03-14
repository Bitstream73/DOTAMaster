Public Class abThe_Swarm
Inherits AbilityBase
  Public insectcount As ValueWrapper
  Public armorreduction As ValueWrapper
  Public attackstodestroy As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "The Swarm moves forward at a speed of 600.|The beetles spawn within a 300 radius around of Weaver (random position) and move as a swarm forward.|When an enemy unit comes within 100 radius of a beetle, the beetle will latch onto it.|The beetles can latch on units 3400 range away (300 spawn radius + 3000 travel distance +100 latch radius).|When a beetle latches on a target, it will remain there until it is killed or expires.|The armor reduction is gone once the beetle is killed or expires.|The beetles ignore evasion and can't trigger Reactive Armor icon.png Reactive Armor, Counter Helix icon.png Counter Helix and Moment of Courage icon.png Moment of Courage.|The beetles can latch on invulnerable units, but not on invisible or hidden units.|The beetles instantly die when their latch target turns invisible, but not when they turn invulnerable or hidden.|The armor reduction is independant from the damage. It keeps reducing armor on ethereal targets, but not invulnerable targets.|Beetles attack at 1.35 second intervals, starting immediatly when latching on a unit, resulting in 11/12/14/15 attacks.|The armor reduction is applied with the same intervals, but happens before the damage happens.|The Swarm icon.png The Swarm can deal up to 165/240/350/450 damage (before reductions) to a single unit and reduce up to 11/12/14/15 armor.|The beeles cannot latch on ancient creeps, Roshan, Warlock icon.png Warlock's Golem and the Primal Split icon.png Primal Split spirits." '"

    mDisplayName = "The Swarm"
    mName = eAbilityName.abThe_Swarm
    Me.EntityName = eEntity.abThe_Swarm

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWeaver

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/weaver_the_swarm_hp2.png"

    Description = "Weaver launches a swarm of 12 young Weavers that latch on any enemy unit in their path, attacking and reducing armor until it is killed."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(36, 33, 30, 27)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(15, 20, 25, 30)

    Duration = New ValueWrapper(14, 16, 18, 20)

    insectcount = New ValueWrapper(12, 12, 12, 12)

    armorreduction = New ValueWrapper(1, 1, 1, 1)

    attackstodestroy = New ValueWrapper(8, 8, 8, 8)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim coneenemies = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, New ValueWrapper(1.35, 1.35, 1.35, 1.35), occurencetime, aghstime)
    damval.Charges = insectcount

    Dim thedamage As New Modifier(damval, coneenemies)
    outmods.Add(thedamage)

    Dim armorval As New modValue(armorreduction, eModifierType.ArmorAdded, occurencetime, aghstime)
    armorval.Charges = insectcount

    Dim armorreduct As New Modifier(armorval, coneenemies)
    outmods.Add(armorreduct)

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
