Public Class abEmp
Inherits AbilityBase
  Public manaburned As ValueWrapper
  Public selfmanagain As ValueWrapper
  Public effectdelay As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Applies the mana loss first, and then the damage.Invoker only gains the mana when it burns mana from heroes. Mana burned on illusions and other units does not restore mana.|The damage and the restored mana are dependent on the amount of mana burned on the enemies. If the enemy had no mana to burn, it deals no damage and doesn't restore mana.|Fully affects invisible units, but not invulnerable or hidden units.|Can deal up to 50/87.5/125/162.5/200/237.5/275 damage to each affected unit (before reductions).|Can restore up to 50/87.5/125/162.5/200/237.5/275 mana for Invoker from each affected hero.|The visual effects and the sound during the 2.9 seconds effect delay are visible and audible to everyone." '

    mDisplayName = "EMP"
    mName = eAbilityName.abEmp
    Me.EntityName = eEntity.abEmp

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_emp_hp2.png"

    Description = "Invoker builds up a charge of electromagnetic energy at a targeted location which automatically detonates after %delay% seconds. The detonation covers an area, draining mana based on the level of Wex. Deals damage for each point of mana drained. If EMP drains mana from an enemy hero, Invoker gains 50% of the mana drained."

    ManaCost = New ValueWrapper(125, 125, 125, 125, 125, 125, 125)

    Cooldown = New ValueWrapper(30, 30, 30, 30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure


    Radius = New ValueWrapper(675, 675, 675, 675, 675, 675, 675)
    Range = New ValueWrapper(950, 950, 950, 950, 950, 950, 950)

    manaburned = New ValueWrapper(100, 175, 250, 325, 400, 475, 550)
    Damage = New ValueWrapper(manaburned.Value(0) / 2, _
                               manaburned.Value(1) / 2, _
                               manaburned.Value(2) / 2, _
                               manaburned.Value(3) / 2, _
                               manaburned.Value(4) / 2, _
                               manaburned.Value(5) / 2, _
                               manaburned.Value(6) / 2)

    selfmanagain = New ValueWrapper(manaburned.Value(0) / 2, _
                               manaburned.Value(1) / 2, _
                               manaburned.Value(2) / 2, _
                               manaburned.Value(3) / 2, _
                               manaburned.Value(4) / 2, _
                               manaburned.Value(5) / 2, _
                               manaburned.Value(6) / 2)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     thecaster As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.WexDamagePureInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemies)
    outmods.Add(dammod)

    Dim manadrain As New modValue(manaburned, eModifierType.ManaRemoved, occurencetime, aghstime)

    Dim manamod As New Modifier(manadrain, pointtargetenemies)
    outmods.Add(manamod)



    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)


    Dim manaselfval As New modValue(selfmanagain, eModifierType.ManaRestored, occurencetime, aghstime)

    Dim manaselfmod As New Modifier(manaselfval, pointtargetenemies)
    outmods.Add(manaselfmod)

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
