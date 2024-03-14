Public Class abHeartstopper_Aura
Inherits AbilityBase

  Public healthdecay As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Heartstopper Aura is negative regeneration, and thus will not disable abilities or items like Blink Dagger or cancel consumables.|Will not affect ancient units or Roshan, despite going through magic immunity|Displays a debuff on enemy units if they are in the aura's radius and if Necrophos is visible. If Necrophos is out of sight, no debuff is displayed yet the negative regeneration still occurs.|Illusions usually bestow the aura that the original hero possesses. However, illusions of Necrophos do not have Heartstopper Aura." '"

    mDisplayName = "Heartstopper Aura"
    mName = eAbilityName.abHeartstopper_Aura
    Me.EntityName = eEntity.abHeartstopper_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecrophos

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/necrolyte_heartstopper_aura_hp2.png"

    Description = "Necrophos stills the hearts of his opponents, causing nearby enemy units to lose a percentage of their max health over time."



    AbilityTypes.Add(eAbilityType.Passive)
    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure


    Radius = New ValueWrapper(1200, 1200, 1200, 1200)

    healthdecay = New ValueWrapper(0.006, 0.009, 0.012, 0.015)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     theowner As idisplayunit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetPassiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                           theowner, _
                                                           thetarget, _
                                                           "", eModifierCategory.Passive)

    Dim dotval As New modValue(healthdecay, eModifierType.HealPercentSubtracted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)

    Dim thehealthdecay As New Modifier(dotval, auraenemies)
    outmods.Add(thehealthdecay)

    Return outmods
  End Function
End Class
