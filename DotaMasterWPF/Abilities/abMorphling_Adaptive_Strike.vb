Public Class abAdaptive_Strike
Inherits AbilityBase
  Public basedamage As ValueWrapper
  Public damagminagimulti As ValueWrapper
  Public damagmaxagimulti As ValueWrapper

  Public stunmin As ValueWrapper
  Public stunmax As ValueWrapper


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

    mDisplayName = "Adaptive Shield"
    mName = eAbilityName.abAdaptive_Strike
    Me.EntityName = eEntity.abAdaptive_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMorphling

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/morphling_adaptive_strike_hp2.png"

    Description = "Strikes an enemy unit with a blast of water, stunning the target while dealing base damage plus additional damage based on Morphling's agility times a multiplier. If Morphling's agility is 50% higher than strength, the maximum damage and the minimum stun is dealt. If his strength is 50% higher than his agility, the maximum stun and minimum damage are dealt."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(10, 10, 10, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    basedamage = New ValueWrapper(20, 40, 60, 80)

    damagminagimulti = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    damagmaxagimulti = New ValueWrapper(0.5, 1, 1.5, 2)

    stunmin = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    stunmax = New ValueWrapper(1.25, 2.25, 3.25, 4.25)

    Radius = New ValueWrapper(600, 700, 800, 900)
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

    Dim damval As New modValue(basedamage, eModifierType.AdaptiveStrikeDamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim stunval As New modValue(stunmax, eModifierType.AdaptiveStrikeStun, occurencetime, aghstime)

    Dim stunmod As New Modifier(stunval, unittargetenemy)
    outmods.Add(stunmod)


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
