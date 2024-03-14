Public Class abEssence_Aura
Inherits AbilityBase
  Public basemana As ValueWrapper
  Public restoredmana As ValueWrapper
  Public restorechance As ValueWrapper

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

    mDisplayName = "Essence Aura"
    mName = eAbilityName.abEssence_Aura
    Me.EntityName = eEntity.abEssence_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOutworld_Devourer

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/obsidian_destroyer_essence_aura_hp2.png"

    Description = "Whenever nearby allied Heroes or Outworld Devourer itself casts a spell, it gains a chance to restore 25% of its mana pool. Outworld Devourer also passively gains a bonus to its base mana pool. Several skills with no cooldown and toggled spells cannot trigger Essence Aura."




    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untHeroes)

    Radius = New ValueWrapper(1000, 1000, 1000, 1000)

    basemana = New ValueWrapper(75, 150, 225, 300)

    restoredmana = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    restorechance = New ValueWrapper(0.4, 0.4, 0.4, 0.4)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraself = Helpers.GetPassiveAuraSelfInfo(theability_InfoID, _
                                                  thecaster, _
                                                  thetarget, _
                                                  "", eModifierCategory.Passive)

    Dim manaval As New modValue(basemana, eModifierType.MaxManaAdded, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, auraself)
    outmods.Add(manamod)


    Dim manarestoreval As New modValue(restoredmana, eModifierType.EssenceAuraManaRestored, occurencetime, aghstime)
    manarestoreval.mPercentChance = restorechance
    manarestoreval.mRadius = Radius

    Dim manarestoremod As New Modifier(manarestoreval, auraself)
    outmods.Add(manarestoremod)

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
