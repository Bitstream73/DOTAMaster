Public Class abShackleshot
Inherits AbilityBase
  Public shackleduration As ValueWrapper

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

    mDisplayName = "Shackleshot"
    mName = eAbilityName.abShackleshot
    Me.EntityName = eEntity.abShackleshot

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWindranger

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/windrunner_shackleshot_hp2.png"

    Description = "Shackles the target to an enemy unit or tree in a line directly behind it. If no unit or tree is present, the stun duration is reduced to 0.75."

    ManaCost = New ValueWrapper(90, 100, 110, 120)

    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    shackleduration = New ValueWrapper(1.5, 2.25, 3, 3.75)

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

    Dim snareval As New modValue(shackleduration, eModifierType.MuteMove, occurencetime, aghstime)
    snareval.mValueDuration = shackleduration

    Dim snaremod As New Modifier(snareval, unittargetenemy)
    outmods.Add(snaremod)


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
