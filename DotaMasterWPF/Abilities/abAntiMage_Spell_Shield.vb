Public Class abSpell_Shield
Inherits AbilityBase


  Public magicresistance As ValueWrapper
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
    mDisplayName = "Spell Shield"
    mName = eAbilityName.abSpell_Shield
    Me.EntityName = eEntity.abSpell_Shield

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAnti_Mage

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/antimage_spell_shield_hp2.png"

    Description = "Increases Anti-Mage's resistance to magic damage."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)


    magicresistance = New ValueWrapper(0.26, 0.34, 0.42, 0.5)

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

    Dim resistval As New modValue(magicresistance, eModifierType.MagicResistancePercentAdded, occurencetime, aghstime)

    Dim resistmod As New Modifier(resistval, notargetself)
    outmods.Add(resistmod)



    Return outmods
  End Function
End Class
