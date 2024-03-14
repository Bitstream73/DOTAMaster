Public Class abVampiric_Aura
Inherits AbilityBase

  Public lifesteal As ValueWrapper
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

    mDisplayName = "Vampiric Aura"
    mName = eAbilityName.abVampiric_Aura
    Me.EntityName = eEntity.abVampiric_Aura

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWraith_King

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skeleton_king_vampiric_aura_hp2.png"

    Description = "Nearby friendly units gain hit points based on their damage dealt when attacking enemy units."



    AbilityTypes.Add(eAbilityType.Passive)
    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)




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
                                                   theowner As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveauraenemies = Helpers.GetPassiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                  theowner, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)


    Dim lifeval As New modValue(lifesteal, eModifierType.LifeStealPercent, occurencetime, aghstime)

    Dim lifemod As New Modifier(lifeval, passiveauraenemies)
    outmods.Add(lifemod)


    Return outmods
  End Function
End Class
