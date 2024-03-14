Public Class abPresence_Of_The_Dark_Lord
Inherits AbilityBase

  Public armorreduction As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Presense of the Dark Lord"
    mName = eAbilityName.abPresence_Of_The_Dark_Lord
    Me.EntityName = eEntity.abPresence_Of_The_Dark_Lord

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Fiend

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/nevermore_dark_lord_hp2.png"

    Description = "Shadow Fiend's presence reduces the armor of nearby enemies."



    AbilityTypes.Add(eAbilityType.Passive)

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untEnemyUnits)

    armorreduction = New ValueWrapper(3, 4, 5, 6)

    Radius = New ValueWrapper(900, 900, 900, 900)
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

    Dim passiveauraenemies = Helpers.GetPassiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                   theowner, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Passive)

    Dim armval As New modValue(armorreduction, eModifierType.ArmorSubtracted, occurencetime, aghstime)

    Dim armmod As New Modifier(armval, passiveauraenemies)
    outmods.Add(armmod)


    Return outmods
  End Function
End Class
