Public Class abInner_Vitality
Inherits AbilityBase
  Public healthregenpersec As ValueWrapper
  Public bonusfromAttribute As ValueWrapper
  Public bonuswhenhurt As ValueWrapper

  Public healththreshold As ValueWrapper
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

    mDisplayName = "Inner Vitality"
    mName = eAbilityName.abInner_Vitality
    Me.EntityName = eEntity.abInner_Vitality

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHuskar

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/huskar_inner_vitality_hp2.png"

    Description = "Unlocks the regenerative power of a friendly unit, with healing based upon its primary attribute. If the target is below 40% it will heal faster. Lasts 16 seconds."

    ManaCost = New ValueWrapper(170, 170, 170, 170)


    Cooldown = New ValueWrapper(25, 22, 19, 16)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)
    Affects.Add(eUnit.untSelf)

    healthregenpersec = New ValueWrapper(10, 10, 10, 10)

    bonusfromAttribute = New ValueWrapper(0.05, 0.1, 0.15, 0.2)

    bonuswhenhurt = New ValueWrapper(0.2, 0.4, 0.6, 0.8)

    Duration = New ValueWrapper(16, 16, 16, 16)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untSelf)
    theaffects.Add(eUnit.untAlliedUnit)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)


    'base health regen per sec
    Dim basehealval As New modValue(healthregenpersec, eModifierType.HealAdded, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    basehealval.mValueDuration = Duration

    Dim basehealmod As New Modifier(basehealval, unittargetmulti)
    outmods.Add(basehealmod)

    'regen above or below healththreshold. will have to choose base on target's attribute at time
    Dim highregval As New modValue(1, eModifierType.InnerVitalityPercentHealAdded, occurencetime)
    highregval.mThreshold = healththreshold
    highregval.mValueDuration = Duration

    Dim highmod As New Modifier(highregval, unittargetmulti)
    outmods.Add(highmod)




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
