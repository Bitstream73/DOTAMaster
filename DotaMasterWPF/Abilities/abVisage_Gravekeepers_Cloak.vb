Public Class abGravekeepers_Cloak
  Inherits AbilityBase


  Public armorperlayor As ValueWrapper
  Public resistperlayer As ValueWrapper
  Public maxlayers As ValueWrapper
  Public recoverytime As ValueWrapper

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

    mDisplayName = "Gravekeeper's Cloak"
    mName = eAbilityName.abGravekeepers_Cloak
    Me.EntityName = eEntity.abGravekeepers_Cloak

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVisage

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/visage_gravekeepers_cloak_hp2.png"

    Description = "Visage generates a layered barrier that protects him from physical and magical attacks. If he receives damage from a player, one layer is removed, and takes time to recover."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    armorperlayor = New ValueWrapper(1, 2, 4, 5)
    resistperlayer = New ValueWrapper(0.03, 0.06, 0.12, 0.16)
    maxlayers = New ValueWrapper(4)

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

    Dim armval As New modValue(armorperlayor, eModifierType.ArmorAdded, occurencetime, aghstime)
    armval.Charges = maxlayers

    Dim armmod As New Modifier(armval, notargetself)
    outmods.Add(armmod)


    Return outmods
  End Function
End Class
