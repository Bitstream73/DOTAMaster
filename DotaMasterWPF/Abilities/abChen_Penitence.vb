Public Class abPenitence
Inherits AbilityBase
  Public moveslow As ValueWrapper
  Public bonusdamage As ValueWrapper
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
    mDisplayName = "Penitence"
    mName = eAbilityName.abPenitence
    Me.EntityName = eEntity.abPenitence


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untChen

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/chen_penitence_hp2.png"

    Description = "Forces an enemy unit to move slower and take more damage from attacks and spells."


    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(14, 13, 12, 11)


    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)


    Duration = New ValueWrapper(5, 6, 7, 8)

    moveslow = New ValueWrapper(0.14, 0.18, 0.22, 0.26)

    bonusdamage = New ValueWrapper(0.14, 0.18, 0.22, 0.26)
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

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittargetenemytarget)
    outmods.Add(movemod)



    Dim bonusval As New modValue(bonusdamage, eModifierType.DamageIncreasePercent, occurencetime, aghstime)
    bonusval.mValueDuration = Duration

    Dim bonusmod As New Modifier(bonusval, unittargetenemytarget)
    outmods.Add(bonusmod)

    Return outmods
  End Function
End Class
