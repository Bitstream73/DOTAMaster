Public Class abCold_Feet
Inherits AbilityBase
  Public damageovertime As ValueWrapper
  Public breakdistance As ValueWrapper
  Public stunduration As ValueWrapper
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

    mName = eAbilityName.abCold_Feet
    Me.EntityName = eEntity.abCold_Feet

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Apparition
    mDisplayName = "Cold Feet"
    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ancient_apparition_cold_feet_hp2.png"

    Description = "Places a frozen hex on an enemy unit that deals damage over time, but can be dispelled by moving away from the initial cast point. If the enemy unit doesn't move outside of the given range, it will be stunned and frozen in place after 4 seconds."

    ManaCost = New ValueWrapper(150, 150, 150, 150)


    Cooldown = New ValueWrapper(15, 13, 11, 9)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    damageovertime = New ValueWrapper(37.5, 50, 62.5, 75)

    breakdistance = New ValueWrapper(740, 740, 740, 740)

    stunduration = New ValueWrapper(1.25, 2, 2.75, 3.5)

    Duration = New ValueWrapper(4, 4, 4, 4)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'DoT
    Dim dotval As New modValue(damageovertime, eModifierType.DamageoTMagicalInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dotmod As New Modifier(dotval, unittargetenemy)
    outmods.Add(dotmod)


    'Stun
    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, unittargetenemy)
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
