Public Class abShadow_Wave
Inherits AbilityBase

  Public healarcradius As ValueWrapper
  Public damageradius As ValueWrapper
  Public maxhealtargets As ValueWrapper
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

    Notes = "Prioritizes allied heroes over creeps.|If enemies are near multiple allied units affected by Shadow Wave, they can take multiple instances of damage.|Can deal a maximum of 240/400/600/840 damage (Excludes Dazzle as a source of damage)." '"

    mDisplayName = "Shadow Wave"
    mName = eAbilityName.abShadow_Wave
    Me.EntityName = eEntity.abShadow_Wave

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDazzle

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dazzle_shadow_wave_hp2.png"

    Description = "Shadow Wave heals several allies, which in turn cause damage equal to their healing in a small area around them. Dazzle is always healed by Shadow Wave, and it does not count toward the number of targets."

    ManaCost = New ValueWrapper(80, 90, 100, 110)

    Cooldown = New ValueWrapper(12, 10, 8, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnits)

    DamageType = eDamageType.Physical


    Damage = New ValueWrapper(80, 100, 120, 140)

    healarcradius = New ValueWrapper(80, 100, 120, 140)

    damageradius = New ValueWrapper(185, 185, 185, 185)

    maxhealtargets = New ValueWrapper(4, 5, 6, 7)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyunits = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim unittargetallies = Helpers.GetUnitTargetAlliedUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)


    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)



    'self heal
    Dim theheal As New modValue(Damage, eModifierType.HealAdded, occurencetime, aghstime)
    theheal.Charges = maxhealtargets

    Dim dazzheal As New Modifier(theheal, notargetself)
    outmods.Add(dazzheal)

    'allies heal    
    Dim friendheal As New Modifier(theheal, unittargetallies)
    outmods.Add(friendheal)

    'enemies damage
    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    damval.Charges = maxhealtargets

    Dim enemydam As New Modifier(damval, unittargetenemyunits)
    outmods.Add(enemydam)


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
