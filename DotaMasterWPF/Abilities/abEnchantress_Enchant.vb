Public Class abEnchant
Inherits AbilityBase
  Public moveslow As ValueWrapper
  Public enchantduration As ValueWrapper
  Public slowduration As ValueWrapper

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

    mDisplayName = "Enchant"
    mName = eAbilityName.abEnchant
    Me.EntityName = eEntity.abEnchant

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnchantress

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enchantress_enchant_hp2.png"

    Description = "Enchantress charms an enemy, bringing it under her control (if a creep) or slowing it (if a hero)."

    ManaCost = New ValueWrapper(65, 65, 65, 65)

    Cooldown = New ValueWrapper(30, 25, 20, 15)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyCreep)
    Affects.Add(eUnit.untEnemyHero)

    moveslow = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    enchantduration = New ValueWrapper(80, 80, 80, 80)

    slowduration = New ValueWrapper(5.5, 5.5, 5.5, 5.5)



End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemycreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)

    Dim unittargetenemyhero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)


    Dim creepval As New modValue(1, eModifierType.CreepControlled, occurencetime)
    creepval.mValueDuration = enchantduration

    Dim creepmod As New Modifier(creepval, unittargetenemycreep)
    outmods.Add(creepmod)


    Dim heroval As New modValue(slowduration, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    heroval.mValueDuration = slowduration

    Dim heromod As New Modifier(heroval, unittargetenemyhero)
    outmods.Add(heromod)


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
