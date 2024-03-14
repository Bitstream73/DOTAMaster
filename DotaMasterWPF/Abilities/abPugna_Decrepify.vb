Public Class abDecrepify
Inherits AbilityBase
  Public allyincreasemagdamage As ValueWrapper
  Public allymoveslow As ValueWrapper

  Public enincreasemagdamage As ValueWrapper
  Public enmoveslow As ValueWrapper


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

    mDisplayName = "Decrepify"
    mName = eAbilityName.abDecrepify
    Me.EntityName = eEntity.abDecrepify

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPugna

    mAbilityPosition = 2

    mIsUltimate = False '
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/pugna_decrepify_hp2.png"

    Description = "A powerful banishing spell that slows a unit and renders it unable to attack or be attacked. Afflicted units take extra magic damage."

    ManaCost = New ValueWrapper(60, 60, 60, 60)

    Cooldown = New ValueWrapper(12, 10, 8, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)
    Affects.Add(eUnit.untAlliedUnit)

    Duration = New ValueWrapper(2, 2.5, 3, 3.5)

    allyincreasemagdamage = New ValueWrapper(0.25)
    enincreasemagdamage = New ValueWrapper(0.3, 0.4, 0.5, 0.6)
    enmoveslow = New ValueWrapper(0.3, 0.4, 0.5, 0.6)
    allymoveslow = enmoveslow

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

    Dim unittargetally = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    'move slow ally or enemy
    Dim allyslowval As New modValue(allymoveslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    allyslowval.mValueDuration = Duration

    Dim allyslowmod As New Modifier(allyslowval, unittargetally)
    outmods.Add(allyslowmod)


    Dim enslowval As New modValue(enmoveslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    enslowval.mValueDuration = Duration

    Dim enslowmod As New Modifier(enslowval, unittargetenemy)
    outmods.Add(enslowmod)

    'physical damage immunity
    Dim physval As New modValue(Duration, eModifierType.DamagePhysicalImmunity, occurencetime, aghstime)
    physval.mValueDuration = Duration

    Dim physallymod As New Modifier(physval, unittargetally)
    outmods.Add(physallymod)

    Dim physenmod As New Modifier(physval, unittargetenemy)
    outmods.Add(physenmod)


    'lowered magic resistance
    Dim magallyval As New modValue(allyincreasemagdamage, eModifierType.MagicResistancePercentSubtracted, occurencetime, aghstime)
    magallyval.mValueDuration = Duration

    Dim magallymod As New Modifier(magallyval, unittargetally)
    outmods.Add(magallymod)


    Dim magenemyval As New modValue(enincreasemagdamage, eModifierType.MagicResistancePercentSubtracted, occurencetime, aghstime)
    magenemyval.mValueDuration = Duration

    Dim magenmod As New Modifier(magenemyval, unittargetenemy)
    outmods.Add(magenmod)


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
