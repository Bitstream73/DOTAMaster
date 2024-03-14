Public Class abThirst
Inherits AbilityBase


  Public movespeed As ValueWrapper

  Public movespeedincrement As ValueWrapper
  Public attspeedincrement As ValueWrapper
  Public hppercentinterval As ValueWrapper

  Public maxmovespeedbonusperhero As ValueWrapper
  Public maxattdamagebonusperhero As ValueWrapper

  Public visibilityhealth As ValueWrapper
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
    mDisplayName = "Thirst"
    mName = eAbilityName.abThirst
    Me.EntityName = eEntity.abThirst

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBloodseeker

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bloodseeker_thirst_hp2.png"

    Description = "Enables Bloodseeker to sense enemy Heroes with health below a certain percentage wherever they are, giving him vision of that unit, increased movement speed and increased damage. Bonuses stack per Hero. Bloodseeker gains True Sight of enemy Heroes below half their visiblity threshold."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    movespeedincrement = New ValueWrapper(0.005, 0.01, 0.015, 0.02)

    attspeedincrement = New ValueWrapper(0.5, 1, 1.5, 2)

    hppercentinterval = New ValueWrapper(0.05, 0.05, 0.05, 0.05)

    visibilityhealth = New ValueWrapper(0.3, 0.3, 0.3, 0.3)

    maxmovespeedbonusperhero = New ValueWrapper(0.1, 0.2, 0.3, 0.4)
    maxattdamagebonusperhero = New ValueWrapper(10, 20, 30, 40)
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

    Dim damval As New modValue(maxattdamagebonusperhero, eModifierType.rightclickdamageaddedperherobelow75perchealth, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)


    Dim moveval As New modValue(movespeedincrement, eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP, occurencetime, aghstime)
    moveval.mValueInterval = hppercentinterval

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)


    Dim attval As New modValue(attspeedincrement, eModifierType.AttackSpeedAddedPerHeroPerMissHP, occurencetime, aghstime)
    attval.mValueInterval = hppercentinterval

    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)

    Return outmods
  End Function
End Class
