Public Class abBerserkers_Blood
Inherits AbilityBase


  Public bonusattackspeedperstack As ValueWrapper
  Public bonusresistanceperstack As ValueWrapper
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

    mDisplayName = "Berserker's Blood"
    mName = eAbilityName.abBerserkers_Blood
    Me.EntityName = eEntity.abBerserkers_Blood

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHuskar

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/huskar_berserkers_blood_hp2.png"

    Description = "Huskar's injuries feed his power, giving increased attack speed and magic resistance based on missing health."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    bonusattackspeedperstack = New ValueWrapper(14, 16, 18, 20)

    bonusresistanceperstack = New ValueWrapper(0.04, 0.05, 0.06, 0.07)


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

    Dim speedval As New modValue(bonusattackspeedperstack, eModifierType.BerserkersBonusAttackSpeed, occurencetime, aghstime)

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)


    Dim magval As New modValue(bonusresistanceperstack, eModifierType.BerserkersBonusMagicResistance, occurencetime, aghstime)

    Dim magmod As New Modifier(magval, notargetself)
    outmods.Add(magmod)

    Return outmods
  End Function
End Class
