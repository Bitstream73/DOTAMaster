Public Class abElder_Dragon_Form
Inherits AbilityBase

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

    mDisplayName = "Elder Dragon Form"
    mName = eAbilityName.abElder_Dragon_Form
    Me.EntityName = eEntity.abElder_Dragon_Form

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDragon_Knight

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dragon_knight_elder_dragon_form_hp2.png"

    Description = "Dragon Knight takes the form of one of three powerful elder dragons, increasing his damage, speed, and Dragon Tail's range, while granting him new powers. LEVEL 1 Green Dragon - Corrosive Breath: attacks deal 20 poison damage over 5 seconds. Works on structures. LEVEL 2 Red Dragon - Splash Attack: attacks damage all enemy units in a 250 radius, with Corrosive Breath added to the primary target. LEVEL 3 Blue Dragon - Frost Breath: slows movement speed by 30%, and attack speed by 20, of enemy units in Splash Attack range for 3 seconds, with Corrosive Breath added to the primary target."


    ManaCost = New ValueWrapper(50, 50, 50)

    Cooldown = New ValueWrapper(115, 115, 115)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    Duration = New ValueWrapper(60, 60, 60)
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

    Dim dragonval As New modValue(1, eModifierType.ElderDragonForm, occurencetime)
    dragonval.mValueDuration = Duration

    Dim dragonmod As New Modifier(dragonval, notargetself)
    outmods.Add(dragonmod)

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
