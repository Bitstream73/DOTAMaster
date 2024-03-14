Public Class abHunter_In_The_Night
Inherits AbilityBase


  Public nightmovespeed As ValueWrapper
  Public nightattackspeed As ValueWrapper

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

    mDisplayName = "Hunter in the Night"
    mName = eAbilityName.abHunter_In_The_Night
    Me.EntityName = eEntity.abHunter_In_The_Night

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNight_Stalker

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/night_stalker_hunter_in_the_night_hp2.png"

    Description = "Night Stalker is in his element at night, attacking and moving with great swiftness."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    nightmovespeed = New ValueWrapper(0.2, 0.25, 0.3, 0.35)
    nightattackspeed = New ValueWrapper(45, 60, 75, 90)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim moveval As New modValue(1, eModifierType.NightMoveSpeedAdded, occurencetime)

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)


    Dim attval As New modValue(1, eModifierType.NightAttackSpeedAdded, occurencetime)

    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)

    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   theowner As idisplayunit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Return Nothing
  End Function
End Class
