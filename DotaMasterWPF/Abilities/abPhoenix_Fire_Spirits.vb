Public Class abFire_Spirits
Inherits AbilityBase
  Dim hpcost As ValueWrapper
  Dim spiritduration As ValueWrapper
  Dim burnduration As ValueWrapper
  Dim attspeedslow As ValueWrapper
  Dim dps As ValueWrapper

  Dim spiritcount As ValueWrapper
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

    mDisplayName = "Fire Spirits"
    mName = eAbilityName.abFire_Spirits
    Me.EntityName = eEntity.abFire_Spirits

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhoenix

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phoenix_fire_spirits_hp2.png"

    Description = "Summons 4 fire spirits that circle around Phoenix. Each spirit can be launched independently at a targeted area of effect. Affected enemy units take damage over time and have their attack speed greatly reduced."

    ManaCost = New ValueWrapper(80, 90, 100, 110)

    Cooldown = New ValueWrapper(45, 40, 35, 30)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    hpcost = New ValueWrapper(0.2, 0.2, 0.2, 0.2)

    spiritduration = New ValueWrapper(16, 16, 16, 16)

    Radius = New ValueWrapper(175, 175, 175, 175)

    burnduration = New ValueWrapper(4, 4, 4, 4)

    attspeedslow = New ValueWrapper(80, 100, 120, 140)

    dps = New ValueWrapper(10, 30, 50, 70)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetauraenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(dps, eModifierType.DamageMagicalPerSec, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.Charges = spiritcount
    damval.mValueDuration = burnduration

    Dim dammod As New Modifier(damval, pointtargetauraenemies)
    outmods.Add(dammod)



    Dim attval As New modValue(attspeedslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = burnduration
    attval.Charges = spiritcount

    Dim attmod As New Modifier(attval, pointtargetauraenemies)
    outmods.Add(attmod)

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
