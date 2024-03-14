Public Class abNightmare
Inherits AbilityBase

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

    mName = eAbilityName.abNightmare

    Me.EntityName = eEntity.abNightmare

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBane

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bane_nightmare_hp2.png"
    mDisplayName = "Nightmare"
    Description = "Puts the target enemy or friendly Hero to sleep and deals damage per second. Sleeping units are awakened when attacked, but the Nightmare passes to the attacking unit. The nightmared unit instantly wakes up if it takes damage."


    ManaCost = New ValueWrapper(165, 165, 165, 165)


    Cooldown = New ValueWrapper(16, 15, 14, 13)


    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    DamageType = eDamageType.Pure

    Damage = New ValueWrapper(20, 20, 20, 20)

    Duration = New ValueWrapper(4, 5, 6, 7)

    Range = New ValueWrapper(500, 550, 600, 650)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untEnemyHero)

    Dim unittargetunit = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active, theaffects)

    Dim muteval As New modValue(Duration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    muteval.mValueDuration = Duration

    Dim mutemod As New Modifier(muteval, unittargetunit)
    outmods.Add(mutemod)


    Dim damval As New modValue(Damage, eModifierType.HPRemoval, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetunit)
    outmods.Add(dammod)


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
