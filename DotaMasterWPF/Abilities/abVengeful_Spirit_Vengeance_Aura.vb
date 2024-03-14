Public Class abVengeance_Aura
  Inherits AbilityBase


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

    mDisplayName = "Vengeance Aura"
    mName = eAbilityName.abVengeance_Aura
    Me.EntityName = eEntity.abVengeance_Aura

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVengeful_Spirit

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/vengefulspirit_command_aura_hp2.png"

    Description = "Vengeful Spirit's presence increases the physical damage of nearby friendly units. If Vengeful Spirit is slain, her killer will be possessed with a negative Vengeance Aura, reducing the damage of her killer and its nearby allies until Vengeful Spirit revives."



    AbilityTypes.Add(eAbilityType.Passive)
    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)

    Radius = New ValueWrapper(900, 900, 900, 900)

    bonusdamage = New ValueWrapper(0.12, 0.2, 0.28, 0.36)
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

    Dim passiveauraaliies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                  theowner, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)

    Dim damval As New modValue(bonusdamage, eModifierType.DamagePhysicalPercent, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, passiveauraaliies)
    outmods.Add(dammod)

    Return outmods
  End Function
End Class
