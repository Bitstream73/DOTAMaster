Public Class abShadow_Word
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

    mDisplayName = "Shadow Word"
    mName = eAbilityName.abShadow_Word
    Me.EntityName = eEntity.abShadow_Word

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWarlock

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/warlock_shadow_word_hp2.png"

    Description = "Demnok whispers an incantation, healing a friendly unit or damaging an enemy unit over time."

    ManaCost = New ValueWrapper(90, 110, 130, 150)

    Cooldown = New ValueWrapper(16, 16, 16, 16)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(15, 25, 35, 45)

    Duration = New ValueWrapper(11, 11, 11, 11)
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

    Dim damheal As New modValue(Damage, eModifierType.HealFriendlyorMagicDamEnemyoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damheal.mValueDuration = Damage

    Dim dammod As New Modifier(damheal, unittargetmulti)
    outmods.Add(dammod)


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
