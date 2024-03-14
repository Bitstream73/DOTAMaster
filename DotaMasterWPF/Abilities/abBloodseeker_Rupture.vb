Public Class abRupture
Inherits AbilityBase
  Public movedamge As ValueWrapper

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
    mDisplayName = "Rupture"
    mName = eAbilityName.abRupture
    Me.EntityName = eEntity.abRupture

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBloodseeker

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bloodseeker_rupture_hp2.png"

    Description = "Causes an enemy unit's skin to rupture, dealing massive damage. If the unit moves while under the effect of Rupture, it takes a percentage of the distance traveled as damage. The damage is dealt through magic immunity."

    ManaCost = New ValueWrapper(150, 200, 250)


    Cooldown = New ValueWrapper(70, 60, 50)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    movedamge = New ValueWrapper(0.2, 0.4, 0.6)

    Duration = New ValueWrapper(12, 12, 12)

    Range = New ValueWrapper(1000, 1000, 1000)
  End Sub



  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargeteney = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim damval As New modValue(movedamge, eModifierType.HPRemovalAsPercentofMoveDist, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargeteney)
    outmods.Add(dammod)


    Return outmods
  End Function


End Class
