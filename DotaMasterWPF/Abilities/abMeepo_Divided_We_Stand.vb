Public Class abDivided_We_Stand
  Inherits AbilityBase


  Public meepocount As ValueWrapper
  Public respawntimereduction As ValueWrapper
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

    mDisplayName = "Divided We Stand"
    mName = eAbilityName.abDivided_We_Stand

    Me.EntityName = eEntity.abDivided_We_Stand

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMeepo

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/meepo_divided_we_stand_hp2.png"

    Description = "Meepo summons an imperfect, semi-autonomous duplicate of himself, which can gain gold and experience as he does and shares his experience and abilities. However, the clones cannot wield any items but the boots that Meepo himself wears. If any of the clones die, they all die. Increases the speed at which you respawn. Upgradable by Aghanim's Scepter."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    meepocount = New ValueWrapper(1, 2, 3)

    respawntimereduction = New ValueWrapper(0.2, 0.2, 0.2)


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

    Dim meepoval As New modValue(meepocount, eModifierType.MagicDamageReceivedMultiplier, occurencetime, aghstime)

    Dim meepomod As New Modifier(meepoval, notargetself)
    outmods.Add(meepomod)

    Return outmods
  End Function
End Class
