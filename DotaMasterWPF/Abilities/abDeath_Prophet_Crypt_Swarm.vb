Public Class abCrypt_Swarm
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

    Notes = "Can hit units up to 1110 range away.|With Witchcraft, Crypt Swarm's Cooldown in reduced to: 7 / 6 / 5 / 4|With Witchcraft at max level, Crypt Swarm's Mana cost is reduced to: 80 / 95 / 115 / 140" '"

    mName = eAbilityName.abCrypt_Swarm
    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDeath_Prophet
    Me.EntityName = eEntity.abCrypt_Swarm


    mDisplayName = "Crypt Swarm"
    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/death_prophet_carrion_swarm_hp2.png"

    Description = "Sends a swarm of winged beasts to savage enemy units in front of Death Prophet."


    ManaCost = New ValueWrapper(105, 120, 140, 165)

    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(75, 150, 225, 300)

    Range = New ValueWrapper(810, 810, 810, 810)
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

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, coneenemies)
    outmods.Add(thedamage)

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
