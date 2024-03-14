Public Class abLeech_Seed
Inherits AbilityBase
  Dim damagehealperpulse As ValueWrapper
  Dim movementslow As ValueWrapper
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

    Notes = "Deals a total of 90/180/270/360 damage (before reductions) and heals for a total of 90/180/270/360 health.|The heal is independant from the damage. The healed amount will always stay the same, even when the damage gets amplified, reduced or even blocked.|Damages and emits a healing pulse every 0.75 seconds. Projectile speed is 400ms.|Healing Pulses are still generated after target death.|If the target turns invisible, the pulses will continue coming from its current actual position, making it possible to track them.|Healing pulse projectiles target and heal magic immune allies.|Healing pulse projectiles cannot target invulnerable or hidden units, but already flying projectiles will still heal them." '"

    mDisplayName = "Leech Seed"
    mName = eAbilityName.abLeech_Seed
    Me.EntityName = eEntity.abLeech_Seed

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTreant_Protector

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/treant_leech_seed_hp2.png"

    Description = "Treant plants a life-sapping seed in an enemy unit, draining its health, while simultaneously slowing it. The seed heals friendly units around it equal to the amount drained. Pulses 6 times."

    ManaCost = New ValueWrapper(140, 140, 140, 140)


    Cooldown = New ValueWrapper(16, 14, 12, 10)


    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)
    Affects.Add(eUnit.untAlliedUnits)

    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(4.5, 4.5, 4.5, 4.5)



    damagehealperpulse = New ValueWrapper(15, 30, 45, 60)

    Radius = New ValueWrapper(500, 500, 500, 500)

    movementslow = New ValueWrapper(0.28, 0.28, 0.28, 0.28)

    Duration = New ValueWrapper(4.5, 4.5, 4.5, 4.5)
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

    Dim unittargetallies = Helpers.GetUnitTargetAlliedUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)


    Dim damval As New modValue(damagehealperpulse, eModifierType.DamageMagicalInflicted, New ValueWrapper(0.75, 0.75, 0.75, 0.75), occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim healval As New modValue(damagehealperpulse, eModifierType.HealAddedoT, New ValueWrapper(0.75, 0.75, 0.75, 0.75), occurencetime, aghstime)
    healval.mValueDuration = Duration

    Dim healmod As New Modifier(healval, unittargetallies)
    outmods.Add(healmod)



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
