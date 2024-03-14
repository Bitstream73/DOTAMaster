Public Class abTrue_Form
Inherits AbilityBase

  Public baseattacktime As ValueWrapper
  Public bonusarmor As ValueWrapper
  Public bonushp As ValueWrapper
  Public basespeedloss As ValueWrapper
  Public transformtime As ValueWrapper
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

    mDisplayName = "True Form"
    mName = eAbilityName.abTrue_Form
    Me.EntityName = eEntity.abTrue_Form

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLone_Druid

    mAbilityPosition = 5

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lone_druid_true_form_hp2.png"

    Description = "Lone Druid learns to morph himself into a raging bear, losing his ranged advantage and some base movement speed, but gaining melee power as well as the Battle Cry ability. He can morph freely between druid and bear form."

    ManaCost = New ValueWrapper(25, 25, 25)


    'mCooldown = New ValueWrapper(0, 0, 0)


    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    baseattacktime = New ValueWrapper(1.5, 1.5, 1.5)
    bonusarmor = New ValueWrapper(4, 6, 8)
    bonushp = New ValueWrapper(250, 400, 600)
    basespeedloss = New ValueWrapper(45, 45, 45)
    transformtime = New ValueWrapper(1.933, 1.933, 1.933)



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
                                                   "", eModifierCategory.Active)

    Dim attval As New modValue(baseattacktime, eModifierType.BaseAttackTimeChangedTo, occurencetime, aghstime)

    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)


    Dim armval As New modValue(bonusarmor, eModifierType.ArmorAdded, occurencetime, aghstime)

    Dim armmod As New Modifier(armval, notargetself)
    outmods.Add(armmod)

    Dim hpval As New modValue(bonushp, eModifierType.HPAdded, occurencetime, aghstime)

    Dim hpmod As New Modifier(hpval, notargetself)
    outmods.Add(hpmod)


    Dim speedval As New modValue(basespeedloss, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)






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
