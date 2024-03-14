Public Class abMarch_Of_The_Machines
  Inherits AbilityBase

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

    Notes = "Robotic minions spawn at a rate of 24 per second, for a total of 144 robots.|If an enemy remains in the radius for the entire duration, they would take an average of 282/422/563/704 damage.|Does not affect spell immune units like ancient creeps." '"

    mDisplayName = "March of the Machines"
    mName = eAbilityName.abMarch_Of_The_Machines
    Me.EntityName = eEntity.abMarch_Of_The_Machines

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTinker

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tinker_march_of_the_machines_hp2.png"

    Description = "Enlists an army of robotic minions to destroy enemy units in an area around Tinker."

    ManaCost = New ValueWrapper(145, 150, 165, 190)

    Cooldown = New ValueWrapper(35, 35, 35, 35)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(16, 24, 32, 40)

    Radius = New ValueWrapper(900, 900, 900, 900)

    Duration = New ValueWrapper(6, 6, 6, 6)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim lineenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim machineval As New modValue(Damage, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    machineval.Charges = New ValueWrapper(24, 24, 24, 24) 'persecond
    machineval.mValueDuration = Duration

    Dim themachines As New Modifier(machineval, lineenemies)
    outmods.Add(themachines)

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
