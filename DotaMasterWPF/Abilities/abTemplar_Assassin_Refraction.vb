Public Class abRefraction
Inherits AbilityBase
  Dim instances As ValueWrapper
  Dim attackdamagebonus As ValueWrapper
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

    mDisplayName = "Refraction"
    mName = eAbilityName.abRefraction
    Me.EntityName = eEntity.abRefraction

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTemplar_Assassin

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/templar_assassin_refraction_hp2.png"

    Description = "Templar Assassin becomes highly elusive, avoiding damage and gaining a bonus to her damage. The damage and avoidance effects are separate, and have a limited number of instances."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(17, 17, 17, 17)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Duration = New ValueWrapper(17, 17, 17, 17)

    instances = New ValueWrapper(3, 4, 5, 6)

    attackdamagebonus = New ValueWrapper(20, 40, 60, 80)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim damabsorbval As New modValue(instances, eModifierType.DamageBlock, occurencetime, aghstime)
    damabsorbval.Charges = instances

    Dim damabsmod As New Modifier(damabsorbval, notargetself)
    outmods.Add(damabsmod)


    Dim damval As New modValue(attackdamagebonus, eModifierType.RightClickBonusDamageInflicted, occurencetime, aghstime)
    damval.Charges = instances

    Dim dammod As New Modifier(damval, notargetself)
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
