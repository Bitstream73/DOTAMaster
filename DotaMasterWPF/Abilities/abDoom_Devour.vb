Public Class abDevour
Inherits AbilityBase
  Private Bonusgold As ValueWrapper
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

    Notes = "Can target all lane creeps, except for siege creeps.|Can target all neutral creeps, except for ancient creeps, Mud Golems and Roshan.|Can target all summons, except for Lone Druid's Spirit Bear, Warlock's Golem, Visage's Familiars, Primal Split spirits, couriers and wards.|Can only gain the abilities of neutral creeps. Abilities are gained instantly. Abilities use the original cast point of the neutral creeps they come from.|Abilities of neutral creeps are kept permanentally, even through death, or until another neutral creep with abilities is devoured.|Devouring a creep with no abilities does not remove the already acquired abilities.|The targeted creep is instantly killed, granting its bounty and experience like a regular last hit.|Places a debuff on Doom himself, which lasts for the creep's current health/20 seconds. The debuff is lost upon death.|While having the debuff on, Doom cannot devour another creep. Devour gold is granted when the debuff expires (losing it upon death does not grant the gold).|The debuff can last longer than the cooldown of the spell when devouring a creep with more than 1400/1200/1000/800 HP.|Assuming it is always used when off cooldown, it increases Doom's GPM by 21/50/90/150. Not including the gold from the creep it is used on."

    mName = eAbilityName.abDevour
    Me.EntityName = eEntity.abDevour

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDoom

    mDisplayName = "Devour"
    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/doom_bringer_devour_hp2.png"

    Description = "Consumes an enemy or neutral creep, acquiring any special abilities that it possessed."

    ManaCost = New ValueWrapper(60, 60, 60, 60)

    Cooldown = New ValueWrapper(70, 60, 50, 40)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)


    Bonusgold = New ValueWrapper(25, 50, 75, 100)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittarget = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim modval As New modValue(1, eModifierType.Consumption, occurencetime)

    Dim modconsumption As New Modifier(modval, unittarget)
    outmods.Add(modconsumption)




    Dim unittargetself = Helpers.GetUnitTargetTreeInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim valgold As New modValue(Bonusgold, eModifierType.BonusGold, occurencetime, aghstime)

    Dim modgold As New Modifier(valgold, unittargetself)
    outmods.Add(modgold)


    Dim valabilities As New modValue(occurencetime.Lifespan.count, eModifierType.AbilitySteal, occurencetime)
    valabilities.mValueDuration = New ValueWrapper(occurencetime.Lifespan.count)

    Dim modabilities As New Modifier(valabilities, unittargetself)
    outmods.Add(modabilities)

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
