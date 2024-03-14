Public Class abNatural_Order
Inherits AbilityBase


  Public basearmorreduction As ValueWrapper
  Public baseresistreduction As ValueWrapper
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

    mDisplayName = "Natural Order"
    mName = eAbilityName.abNatural_Order
    Me.EntityName = eEntity.abNatural_Order

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untElder_Titan

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/elder_titan_natural_order_hp2.png"

    Description = "Reduces all elements to their basic levels, removing base armor and magic resistance from nearby enemy units."



    AbilityTypes.Add(eAbilityType.Passive)
    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untEnemyUnits)


    Radius = New ValueWrapper(275, 275, 275, 275)

    basearmorreduction = New ValueWrapper(0.4, 0.6, 0.8, 1)
    baseresistreduction = New ValueWrapper(0.12, 0.19, 0.26, 0.33)
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

    Dim armval As New modValue(basearmorreduction, eModifierType.BaseArmorPercentSubtracted, occurencetime, aghstime)

    Dim armmod As New Modifier(armval, passiveauraenemies)
    outmods.Add(armmod)


    Dim magval As New modValue(baseresistreduction, eModifierType.BaseMagicResistancePercentSubtracted, occurencetime, aghstime)

    Dim magmod As New Modifier(magval, passiveauraenemies)
    outmods.Add(magmod)



    Return outmods
  End Function

End Class
