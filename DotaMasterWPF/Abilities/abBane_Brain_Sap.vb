Public Class abBrain_Sap
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

mName = eAbilityName.abBrain_Sap

    Me.EntityName = eEntity.abBrain_Sap


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBane

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bane_brain_sap_hp2.png"
    mDisplayName = "Brain Sap"
    Description = "Feasts on the vital energies of an enemy unit, dealing damage and gaining health equal to the damage dealt."

    ManaCost = New ValueWrapper(125, 150, 175, 200)


    Cooldown = New ValueWrapper(14, 14, 14, 14)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Pure


    Damage = New ValueWrapper(90, 160, 230, 300)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                       thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemytarget)
    outmods.Add(dammod)


    Dim healval As New modValue(Damage, eModifierType.HealAdded, occurencetime, aghstime)

    Dim healmod As New Modifier(healval, unittargetself)
    outmods.Add(healmod)


    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
