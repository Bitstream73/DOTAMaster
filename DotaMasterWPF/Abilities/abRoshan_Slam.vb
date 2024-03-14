Public Class abRoshan_Slam
  Inherits AbilityBase
  Public basedamage As ValueWrapper
  Public extradamper4minutes As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public heroduration As ValueWrapper
  Public nonheroduration As ValueWrapper

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

    mDisplayName = "Slam"
    mName = eAbilityName.abRoshan_Slam
    Me.EntityName = eEntity.abRoshan_Slam

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRoshan

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/4/4b/Slam_%28Roshan%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Roshan"
    Description = "Roshan slams the ground, damaging and slowing all nearby enemies. Slam's damage will increase every 4 minutes."
    Notes = "Roshan only casts Slam when 3 or more enemy units are within the radius.|However, after 3 enemies were once within the radius, he will always use it whenever he's aggroed, regardless of how many enemies are in range.|Damage increases by 20 every 4 minutes since the first creep spawn. The first increase happens just as the first wave spawns.|This is how much damage the Slam deals (before reductions) at certain game times:|12 Minutes: 150 damage|24 Minutes: 210 damage|36 Minutes: 270 damage|48 Minutes: 330 damage|60 Minutes: 390 damage|80 Minutes: 490 damage|100 Minutes: 590 damage|120 Minutes: 690 damage"

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(10)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    DamageType = eDamageType.Magical

    basedamage = New ValueWrapper(70)
    Radius = New ValueWrapper(350)
    extradamper4minutes = New ValueWrapper(20)
    moveslow = New ValueWrapper(0.5)
    attslow = New ValueWrapper(50)
    heroduration = New ValueWrapper(2)
    nonheroduration = New ValueWrapper(4)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim enemyheroes = Helpers.GetNoTargetEnemyHeroesInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim enemycreeps = Helpers.GetNoTargetEnemyCreepsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim slambaseval As New modValue(basedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    slambaseval.mRadius = Radius

    Dim slamcreeps As New Modifier(slambaseval, enemycreeps)
    outmods.Add(slamcreeps)

    Dim slamheros As New Modifier(slambaseval, enemyheroes)
    outmods.Add(slamheros)


    Dim damincval As New modValue(extradamper4minutes, eModifierType.RoshanSlamDamageTimeIncrease, occurencetime, aghstime)

    Dim damincheros As New Modifier(damincval, enemyheroes)
    outmods.Add(damincheros)

    Dim daminccreeps As New Modifier(damincval, enemycreeps)
    outmods.Add(daminccreeps)



    Dim moveheroval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveheroval.mValueDuration = heroduration

    Dim moveheromod As New Modifier(moveheroval, enemyheroes)
    outmods.Add(moveheromod)




    Dim movecreepval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveheroval.mValueDuration = nonheroduration

    Dim movecreepmod As New Modifier(movecreepval, enemycreeps)
    outmods.Add(movecreepmod)



    Dim attheroval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attheroval.mValueDuration = heroduration

    Dim atthermod As New Modifier(attheroval, enemyheroes)
    outmods.Add(atthermod)



    Dim attcreepval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attcreepval.mValueDuration = nonheroduration

    Dim attcreepmod As New Modifier(attcreepval, enemycreeps)
    outmods.Add(attcreepmod)

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
