Public Class abArcane_Aura
  Inherits AbilityBase


  Dim manaregen As ValueWrapper
  Dim selfmanaregen As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False
    mDisplayName = "Arcane Aura"
    Notes = "The bonus is doubled on Crystal Maiden herself.|Stacks with Basilius Aura."

    mName = eAbilityName.abArcane_Aura

    Me.EntityName = eEntity.abArcane_Aura

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCrystal_Maiden

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/crystal_maiden_brilliance_aura_hp2.png"
    WebpageLink = ""
    Description = "Gives additional mana regeneration to all friendly units on the map. This bonus is doubled on Crystal Maiden."




    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)

    Radius = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea) 'global

    manaregen = New ValueWrapper(1, 1.5, 2, 2.5)

    selfmanaregen = New ValueWrapper(2, 3, 4, 5)
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

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Passive)

    Dim buffval As New modValue(selfmanaregen, eModifierType.ManaRegenAdded, occurencetime, aghstime)

    Dim selfbuff As New Modifier(buffval, notargetselfinfo)
    outmods.Add(selfbuff)


    Dim auraalliesinfo = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Passive)

    Dim buffval2 As New modValue(manaregen, eModifierType.ManaRegenAdded, occurencetime, aghstime)

    Dim allybuff As New Modifier(buffval2, auraalliesinfo)
    outmods.Add(allybuff)

    Return outmods
  End Function
End Class
