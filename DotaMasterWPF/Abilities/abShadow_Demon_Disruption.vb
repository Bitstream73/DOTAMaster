Public Class abDisruption
Inherits AbilityBase
  Public banishduration As ValueWrapper
  Public illduration As ValueWrapper
  Public illdamage As ValueWrapper
  Public illdamagetaken As ValueWrapper

  Public illcount As ValueWrapper
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

    mDisplayName = "Disruption"
    mName = eAbilityName.abDisruption
    Me.EntityName = eEntity.abDisruption

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Demon

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_demon_disruption_hp2.png"

    Description = "Banishes the targeted unit, removing it from play for the duration. Upon returning, two illusions of the unit are created under Shadow Demon's control."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(25, 22, 19, 16)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)
    Affects.Add(eUnit.untAlliedUnit)

    banishduration = New ValueWrapper(2.5, 2.5, 2.5, 2.5)

    illduration = New ValueWrapper(5, 6, 7, 8)

    illdamage = New ValueWrapper(0.3, 0.4, 0.5, 0.6)

    illdamagetaken = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    illcount = New ValueWrapper(2, 2, 2, 2)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedUnit)
    theaffects.Add(eUnit.untEnemyUnit)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim invulval As New modValue(banishduration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    invulval.mValueDuration = banishduration

    Dim invulmod As New Modifier(invulval, unittargetmulti)
    outmods.Add(invulmod)

    'illusions
    Dim illval As New modValue(illcount, eModifierType.DisruptionIllusion, occurencetime, aghstime)
    illval.mValueDuration = illduration

    Dim illmod As New Modifier(illval, notargetself)
    outmods.Add(illmod)




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
