Public Class abWindrun
Inherits AbilityBase

  Public bonusmovespeed As ValueWrapper
  Public evasion As ValueWrapper
  Public enemyslow As ValueWrapper
  Public enemyslowradius As ValueWrapper

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

    mDisplayName = "Windrun"
    mName = eAbilityName.abWindrun
    Me.EntityName = eEntity.abWindrun

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWindranger

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/windrunner_windrun_hp2.png"

    Description = "Increases movement speed and adds evasion from all physical attacks, while slowing movement of nearby enemies."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    bonusmovespeed = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    evasion = New ValueWrapper(1, 1, 1, 1)

    enemyslow = New ValueWrapper(0.08, 0.16, 0.24, 0.3)

    Radius = enemyslowradius

    Duration = New ValueWrapper(3, 4, 5, 6)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 thecaster As iDisplayUnit, _
                                                thetarget As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeauraenemy = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    'enemy slow
    Dim slowval As New modValue(enemyslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, activeauraenemy)
    outmods.Add(slowmod)


    'self speed
    Dim speedval As New modValue(bonusmovespeed, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)
    speedval.mValueDuration = Duration

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)

    'self evaision

    Dim evval As New modValue(evasion, eModifierType.EvasionPercent, occurencetime, aghstime)
    evval.mValueDuration = Duration

    Dim evmod As New Modifier(evval, notargetself)
    outmods.Add(evmod)


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
