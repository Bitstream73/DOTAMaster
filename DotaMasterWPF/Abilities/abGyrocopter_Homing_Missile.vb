Public Class abHoming_Missile
  Inherits AbilityBase

  Public hitstodestroy As ValueWrapper
  Public towerhitstodestroy As ValueWrapper
  Public stunduration As ValueWrapper
  Public minimumdamage As ValueWrapper '= 50
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    mDisplayName = "Homing Missile"
    Notes = "Homing Missile's initial speed is 340 and increases by 20 per second.|Though the damage is capped, the missile's speed keeps on increasing until it hits the target or is destroyed.|The missile is placed 150 range infront of Gyrocopter and starts moving 3 seconds after cast.|The crosshair over the target is visible to allies only.|Although the spell grants in no way vision over the target, the missile will follow and hit invisible units.|When the missile hits its target, its 400 range flying vision stays at the location for 3.5 seconds.|Only attacks from heroes, illusions (counting as heroes), towers and the fountains (counting as towers) can damage the missile.|The missile's damage is based the distance between the rocket's starting position (150 range in front of Gyrocopter upon cast).|To deal more than the minimum damage, the missile has to hit its target at least 601/301/201/151 range away from its starting position.|This is how much damage the Homing Missile will deal (before reductions) on certain distances:|300 distance: 50/50/75/100 damage|600 distance: 50/100/150/200 damage|900 distance: 75/150/225/300 damage|1200 distance: 100/200/300/400 damage|1500 distance: 125/250/375/500 damage|The damage is capped at 1500 distance." '"

    mName = eAbilityName.abHoming_Missile
    Me.EntityName = eEntity.abHoming_Missile

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGyrocopter

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/gyrocopter_homing_missile_hp2.png"

    Description = "Fires a homing missile to seek the targeted enemy unit. The missile gains speed over time, dealing damage and stunning when it impacts the target. Homing Missile deals greater damage the further it has traveled. Enemy units can destroy the missile before it reaches its target."

    ManaCost = New ValueWrapper(120, 130, 140, 150)

    Cooldown = New ValueWrapper(20, 17, 14, 11)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(125, 250, 375, 500)


    hitstodestroy = New ValueWrapper(3, 3, 4, 5)

    towerhitstodestroy = New ValueWrapper(6, 6, 8, 10)


    stunduration = New ValueWrapper(2.2, 2.4, 2.6, 2.8)

    minimumdamage = New ValueWrapper(50, 50, 50, 50)

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

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamage)


    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, unittargetenemy)
    outmods.Add(thestun)




    'Dim homingmissile As New HeroPet_Info
    'homingmissile.hitpoints = New ValueWrapper(100, 100, 100, 100)

    'homingmissile.armor = New ValueWrapper(0, 0, 0, 0)
    'homingmissile.armortype = eArmorType.None

    'homingmissile.DamageHigh = mDamage
    'homingmissile.DamageLow = New ValueWrapper(50, 50, 50, 50)

    'homingmissile.SightRange.Add(New ValueWrapper(400, 400, 400, 400))
    'homingmissile.SightRange.Add(New ValueWrapper(400, 400, 400, 400))

    'homingmissile.bounty = New ValueWrapper(30, 30, 30, 30)

    'homingmissile.xpvalue = New ValueWrapper(20, 20, 20, 20)

    'homingmissile.notes = ""

    Dim homingmiss As New modValue(1, eModifierType.petHoming_Missile, occurencetime)
    ' homingmiss.mPet = homingmissile
    homingmiss.mValueDuration = Duration

    Dim homingpet As New Modifier(homingmiss, unittargetenemy)
    outmods.Add(homingpet)

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
