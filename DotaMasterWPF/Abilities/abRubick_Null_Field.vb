Public Class abNull_Field
Inherits AbilityBase
  Public magicresist As ValueWrapper

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

    mDisplayName = "Null Field"
    mName = eAbilityName.abNull_Field
    Me.EntityName = eEntity.abNull_Field

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRubick

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rubick_null_field_hp2.png"

    Description = "Rubick's mastery of the arcane protects nearby allied heroes against weaker magics, granting them magic resistance."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untAlliedHero)

    magicresist = New ValueWrapper(0.05, 0.1, 0.15, 0.2)

    Radius = New ValueWrapper(900, 900, 900, 900)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim unittargetalliedheros = Helpers.GetActiveAuraAlliedHeroesInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim magval As New modValue(magicresist, eModifierType.MagicResistancePercentAdded, occurencetime, aghstime)

    Dim magmodself As New Modifier(magval, notargetself)
    outmods.Add(magmodself)

    Dim magmodallies As New Modifier(magval, unittargetalliedheros)
    outmods.Add(magmodallies)

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
