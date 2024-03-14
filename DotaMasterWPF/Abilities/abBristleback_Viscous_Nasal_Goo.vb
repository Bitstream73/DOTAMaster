Public Class abViscous_Nasal
  Inherits AbilityBase
  Public armorloss As ValueWrapper
  Public basemoveslow As ValueWrapper
  Public slowperstack As ValueWrapper
  Public stacklimit As ValueWrapper
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
    mDisplayName = "Viscous Nasal Goo"
    mName = eAbilityName.abViscous_Nasal

    Me.EntityName = eEntity.abViscous_Nasal

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBristleback

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bristleback_viscous_nasal_goo_hp2.png"

    Description = "Covers a target in snot, causing it to have reduced armor and movement speed. Multiple casts stack and refresh the duration."

    ManaCost = New ValueWrapper(30, 30, 30, 30)


    Cooldown = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(5, 5, 5, 5)

    armorloss = New ValueWrapper(1, 1, 2, 2)

    basemoveslow = New ValueWrapper(0.2, 0.2, 0.2, 0.2)

    slowperstack = New ValueWrapper(0.03, 0.06, 0.09, 0.12)

    stacklimit = New ValueWrapper(4, 4, 4, 4)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim moveval As New modValue(basemoveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)

    Dim movemod As New Modifier(moveval, unittargetenemytarget)
    outmods.Add(movemod)


    Dim stackmoveval As New modValue(slowperstack, eModifierType.MoveSpeedPercentStackSubtracted, occurencetime, aghstime)
    stackmoveval.Charges = stacklimit

    Dim stackmod As New Modifier(stackmoveval, unittargetenemytarget)
    outmods.Add(stackmod)


    Dim stackarmorval As New modValue(armorloss, eModifierType.ArmorAdded, occurencetime, aghstime)
    stackarmorval.Charges = stacklimit

    Dim armormod As New Modifier(stackarmorval, unittargetenemytarget)
    outmods.Add(armormod)

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
