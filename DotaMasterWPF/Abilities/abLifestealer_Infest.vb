Public Class abInfest
Inherits AbilityBase

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Infest"
    mName = eAbilityName.abInfest
    Me.EntityName = eEntity.abInfest

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLifestealer

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/life_stealer_infest_hp2.png"

    Description = "Lifestealer will infest the body of the target unit, lying dormant and undetectable inside. When he reveals himself, he deals damage to all nearby enemy units. If the unit is a creep, he will devour it first, gaining health equal to the unit's current HP. Does not work on enemy Heroes."

    ManaCost = New ValueWrapper(50, 50, 50)

    Cooldown = New ValueWrapper(100, 100, 100)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(150, 275, 400)

    Radius = New ValueWrapper(700, 700, 700)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untCreep)
    theaffects.Add(eUnit.untAlliedHero)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim unittargetcreep = Helpers.GetUnitTargetCreepInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    'if infest is creep the heal on consume
    Dim healval As New modValue(1, eModifierType.InfestCreepHeal, occurencetime)

    Dim healmod As New Modifier(healval, unittargetcreep)
    outmods.Add(healmod)

    'if infest is creep, creep is destroyed
    Dim creepval As New modValue(1, eModifierType.DestroysCreep, occurencetime)

    Dim creepmod As New Modifier(creepval, unittargetcreep)
    outmods.Add(creepmod)

    'damage on consume
    Dim damaval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damaval, activeauraenemies)
    outmods.Add(dammod)





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
