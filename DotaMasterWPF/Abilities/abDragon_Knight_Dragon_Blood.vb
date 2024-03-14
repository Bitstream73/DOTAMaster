Public Class abDragon_Blood
Inherits AbilityBase


  Public healthregen As ValueWrapper
  Public armor As ValueWrapper
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

    mDisplayName = "Dragon Blood"
    mName = eAbilityName.abDragon_Blood
    Me.EntityName = eEntity.abDragon_Blood

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDragon_Knight

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dragon_knight_dragon_blood_hp2.png"

    Description = "The life blood of the Dragon improves health regeneration and strengthens armor."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    healthregen = New ValueWrapper(2, 3, 4, 5)

    armor = New ValueWrapper(3, 6, 9, 12)


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

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                    thetarget, _
                                                    "", eModifierCategory.Passive)

    Dim regenval As New modValue(healthregen, eModifierType.HealthRegenAdded, occurencetime, aghstime)

    Dim regenmod As New Modifier(regenval, notargetself)
    outmods.Add(regenmod)


    Dim armorval As New modValue(armor, eModifierType.ArmorAdded, occurencetime, aghstime)

    Dim armormod As New Modifier(armorval, notargetself)
    outmods.Add(armormod)


    Return outmods
  End Function
End Class
