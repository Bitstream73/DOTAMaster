Public Class abStatic_Field
Inherits AbilityBase

  Public healthreduction As ValueWrapper
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

    mDisplayName = "Statid Field"
    mName = eAbilityName.abStatic_Field
    Me.EntityName = eEntity.abStatic_Field

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untZeus

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/zuus_static_field_hp2.png"

    Description = "Zeus shocks all nearby enemy units whenever he casts a spell, causing damage proportional to their current health."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    healthreduction = New ValueWrapper(0.05, 0.07, 0.09, 0.11)

    Range = New ValueWrapper(1200, 1200, 1200, 1200)

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

    Dim autocastauraenemies = Helpers.GetAutoCastEnemyUnitsInfo(theability_InfoID, _
                                                                theowner, _
                                                                thetarget, _
                                                                "", eModifierCategory.Passive)

    Dim damval As New modValue(healthreduction, eModifierType.StaticFieldHealthReduction, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, autocastauraenemies)
    outmods.Add(dammod)


    Return outmods
  End Function
End Class
