Public Class abSynergy
  Inherits AbilityBase


  Public bearbonusdamage As ValueWrapper
  Public bearbonusspeed As ValueWrapper

  Public rabiddurationbonus As ValueWrapper
  Public trueformbonushp As ValueWrapper
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

    mDisplayName = "Synergy"
    mName = eAbilityName.abSynergy
    Me.EntityName = eEntity.abSynergy

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLone_Druid

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lone_druid_synergy_hp2.png"

    Description = "Increases the Lone Druid's synergy with his Spirit Bear and himself, upgrading attributes and abilities."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)


    bearbonusdamage = New ValueWrapper(1, 1, 1, 1) 'temp
    bearbonusspeed = New ValueWrapper(1, 1, 1, 1) 'temp

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

    Dim damval As New modValue(bearbonusdamage, eModifierType.BearBonusDamage, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)


    Dim speedval As New modValue(bearbonusspeed, eModifierType.BearMoveSpeedAdded, occurencetime, aghstime)

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)


    Dim rabidval As New modValue(rabiddurationbonus, eModifierType.RabidDurationBonus, occurencetime, aghstime)

    Dim rabidmod As New Modifier(rabidval, notargetself)
    outmods.Add(rabidmod)



    Dim healthval As New modValue(trueformbonushp, eModifierType.TrueFormHPAdded, occurencetime, aghstime)

    Dim healthmod As New Modifier(healthval, notargetself)
    outmods.Add(healthmod)


    Return outmods

  End Function
End Class
