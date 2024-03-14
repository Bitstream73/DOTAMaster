Public Class abMana_Void
Inherits AbilityBase
  Public ministunduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"
    mDisplayName = "Mana Void"
    mName = eAbilityName.abMana_Void
    Me.EntityName = eEntity.abMana_Void

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAnti_Mage

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/antimage_mana_void_hp2.png"

    Description = "For each point of mana missing by the target unit, damage is dealt to it and surrounding enemies. The main target is also mini-stunned."

    ManaCost = New ValueWrapper(125, 200, 275)

    Cooldown = New ValueWrapper(70, 70, 70)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(0.6, 0.85, 1.1)

    Radius = New ValueWrapper(500, 500, 500)

    ministunduration = New ValueWrapper(0.1, 0.2, 0.3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetauraenemies = Helpers.GetUnitTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                        thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                        thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)
    'damage per missing mana
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalPerMissingMana, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetauraenemies)
    outmods.Add(dammod)

    'ministun
    Dim stunval As New modValue(ministunduration, eModifierType.MiniStun, occurencetime, aghstime)

    Dim stunmod As New Modifier(stunval, unittargetenemytarget)
    outmods.Add(stunmod)

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
