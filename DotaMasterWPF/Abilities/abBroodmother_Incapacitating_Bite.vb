Public Class abIncapacitating_Bite
  Inherits AbilityBase
  Public movespeedslow As ValueWrapper
  Public misschance As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = True '
    PiercesSpellImmunity = False

    Notes = "Successive hits with Incapacitating Bite on the same target do not stack, only the debuff gets refreshed.|Incapacitating Bite does not affect buildings and wards." '"
    mDisplayName = "Incapacitating Bite"
    mName = eAbilityName.abIncapacitating_Bite
    Me.EntityName = eEntity.abIncapacitating_Bite

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBroodmother

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/broodmother_incapacitating_bite_hp2.png"

    Description = "Broodmother's venom cripples enemy units, causing her attacks to slow and giving the affected unit a chance to miss its attacks. Incapacitating Bite is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    misschance = New ValueWrapper(0.3, 0.4, 0.5, 0.6)

    movespeedslow = New ValueWrapper(0.1, 0.2, 0.3, 0.4)

    Duration = New ValueWrapper(2, 2, 2, 2)
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


    Dim moveval As New modValue(movespeedslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movespeed As New Modifier(moveval, unittargetenemy)
    outmods.Add(movespeed)

    Dim missval As New modValue(misschance, eModifierType.MissChance, occurencetime, aghstime)
    missval.mValueDuration = Duration

    Dim themisschance As New Modifier(missval, unittargetenemy)
    outmods.Add(themisschance)

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
