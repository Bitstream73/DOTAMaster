Public Class abGrave_Chill
Inherits AbilityBase
  Public movespeeddrain As ValueWrapper
  Public attspeeddrain As ValueWrapper

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

    mDisplayName = "Grave Chill"
    mName = eAbilityName.abGrave_Chill
    Me.EntityName = eEntity.abGrave_Chill

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVisage

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/visage_grave_chill_hp2.png"

    Description = "Visage drains the movement and attack speed of the targeted unit, gaining it for itself."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(16, 14, 12, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(3, 4, 5, 6)

    movespeeddrain = New ValueWrapper(0.32, 0.32, 0.32, 0.32)
    attspeeddrain = New ValueWrapper(64, 64, 64, 64)
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

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'visage benfits
    Dim moveval As New modValue(movespeeddrain, eModifierType.MoveSpeedPercentofTargetAdded, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittargetself)
    outmods.Add(movemod)

    Dim attval As New modValue(attspeeddrain, eModifierType.AttackSpeedPercentofTargetAdded, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, unittargetself)
    outmods.Add(attmod)



    'target debuffs
    Dim tmoveval As New modValue(movespeeddrain, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    tmoveval.mValueDuration = Duration

    Dim tmovemod As New Modifier(tmoveval, unittargetenemy)
    outmods.Add(tmovemod)


    Dim tattval As New modValue(attspeeddrain, eModifierType.AttackSpeedPercentSubtracted, occurencetime, aghstime)
    tattval.mValueDuration = Duration

    Dim tattmod As New Modifier(tattval, unittargetenemy)
    outmods.Add(tattmod)

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
