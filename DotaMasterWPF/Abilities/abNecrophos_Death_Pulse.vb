Public Class abDeath_Pulse
Inherits AbilityBase
  Public Heal As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Death Pulse can't be disjointed.|Has an instant cast time.|Hits invisible units and units in Fog of War.|Can heal magic immune units.|Projectiles move at about 400 movement speed" '"

    mDisplayName = "Death Pulse"
    mName = eAbilityName.abDeath_Pulse
    Me.EntityName = eEntity.abDeath_Pulse

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecrophos

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/necrolyte_death_pulse_hp2.png"

    Description = "Necrophos releases a wave of death around him, dealing damage to enemy units and healing allied units."


    ManaCost = New ValueWrapper(125, 145, 165, 185)

    Cooldown = New ValueWrapper(8, 7, 6, 5)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(75, 125, 200, 275)


    Radius = New ValueWrapper(475, 475, 475, 475)

    Heal = New ValueWrapper(70, 90, 110, 130)
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


    Dim auraallies = Helpers.GetActiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)


    Dim healval As New modValue(Heal, eModifierType.HealAdded, occurencetime, aghstime)

    Dim theheal As New Modifier(healval, auraallies)
    outmods.Add(theheal)

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
