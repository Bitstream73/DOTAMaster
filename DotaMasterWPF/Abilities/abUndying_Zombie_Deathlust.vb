Public Class abUndying_Zombie_Deathlust
  Inherits AbilityBase






  Public fixedhealthThreshold As ValueWrapper
  Public percentagehealththreshold As ValueWrapper
  Public threshmovespeed As ValueWrapper
  Public threshattspeed As ValueWrapper
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Deathlust"
    mName = eAbilityName.abUndying_Zombie_Deathlust
    Me.EntityName = eEntity.abUndying_Zombie_Deathlust

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUndying_Zombie

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/f/fc/Deathlust_%28Undying_Zombie%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Undying#Undying_Zombie"
    Description = "Slows enemy units on attack. If the attacked unit's health goes below the threshold, the zombie receives enhanced movement and attack speed."
    Notes = "The slow from multiple attacks and multiple zombies fully stack.|Each stack lasts 2.5 seconds. They do not refresh each other's duration.|The number of current stacks can be seen on the debuff icon (a number is visible on it).|The health of the attacked units are checked periodically and the attack speed and movement speed bonus applied instantly."

    '    mManaCost = New ValueWrapper()

    ' mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    '    mAffects.Add(eUnit)

    '    mDuration = New ValueWrapper()
    fixedhealthThreshold = New ValueWrapper(100, 200, 300, 400)
    percentagehealththreshold = New ValueWrapper(0.2, 0.25, 0.3, 0.35)
    threshmovespeed = New ValueWrapper(0.5, 0.5, 0.5, 0.5)
    threshattspeed = New ValueWrapper(50, 50, 50, 50)
    moveslow = New ValueWrapper(0.07, 0.07, 0.07, 0.07)
    slowduration = New ValueWrapper(2.5, 2.5, 2.5, 2.5)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim passiveenemy = Helpers.GetPassiveEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmod As New Modifier(slowval, passiveenemy)
    outmods.Add(slowmod)



    Dim moveval As New modValue(threshmovespeed, eModifierType.DeathlustMoveSpeedPercentAdded, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, passiveself)
    outmods.Add(movemod)


    Dim attval As New modValue(threshattspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, passiveenemy)
    outmods.Add(attmod)


    Return outmods
  End Function




End Class
