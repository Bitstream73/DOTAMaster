Public Class abPurification
Inherits AbilityBase
  Public healdamage As ValueWrapper
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

    mDisplayName = "Purification"
    mName = eAbilityName.abPurification
    Me.EntityName = eEntity.abPurification

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOmniknight

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/omniknight_purification_hp2.png"

    Description = "Instantly heals a friendly unit and damages all nearby enemy units."


    ManaCost = New ValueWrapper(100, 120, 140, 160)

    Cooldown = New ValueWrapper(10, 10, 10, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)
    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    healdamage = New ValueWrapper(90, 180, 270, 360)

    Radius = New ValueWrapper(260, 260, 260, 260)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetally = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim unittargetauraenemies = Helpers.GetUnitTargetAuraEnemyHeroesInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim healval As New modValue(healdamage, eModifierType.HealAdded, occurencetime, aghstime)
    healval.mRadius = Radius

    Dim healmod As New Modifier(healval, unittargetally)
    outmods.Add(healmod)


    Dim damval As New modValue(healdamage, eModifierType.DamagePureInflicted, occurencetime, aghstime)
    damval.mRadius = Radius

    Dim dammod As New Modifier(damval, unittargetauraenemies)
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
