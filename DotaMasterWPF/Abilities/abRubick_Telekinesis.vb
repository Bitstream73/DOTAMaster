Public Class abTelekinesis
Inherits AbilityBase
  Public liftduration As ValueWrapper
  Public stunduration As ValueWrapper
  Public impactradius As ValueWrapper

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

    mDisplayName = "Telekinesis"
    mName = eAbilityName.abTelekinesis
    Me.EntityName = eEntity.abTelekinesis

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRubick

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rubick_telekinesis_hp2.png"

    Description = "Rubick uses his telekinetic powers to lift the enemy into the air briefly and then hurls them back at the ground. The unit lands on the ground with such force that it stuns nearby enemies."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(22, 22, 22, 22)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    liftduration = New ValueWrapper(1.5, 1.75, 2, 2.25)

    stunduration = New ValueWrapper(1, 1.25, 1.5, 1.75)

    impactradius = New ValueWrapper(325, 325, 325, 325)

    Range = New ValueWrapper(550, 575, 600, 625)

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

    Dim pointtargetauraenemies = Helpers.GetPointTargetAuraUntargetedEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)


    'lift stun
    Dim liftval As New modValue(liftduration, eModifierType.Stun, occurencetime, aghstime)
    liftval.mValueDuration = liftduration

    Dim liftmod As New Modifier(liftval, unittargetenemy)
    outmods.Add(liftmod)

    'land move
    Dim pushval As New modValue(1, eModifierType.Pullback, occurencetime)

    Dim pushmod As New Modifier(pushval, unittargetenemy)
    outmods.Add(pushmod)

    'land stun
    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, pointtargetauraenemies)
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
