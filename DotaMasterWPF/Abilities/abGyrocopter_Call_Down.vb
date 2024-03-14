Public Class abCall_Down
  Inherits AbilityBase
  Public missileonedamage As ValueWrapper
  Public missiletwodamage As ValueWrapper
  Public missileoneslow As ValueWrapper
  Public missileoneslowduration As ValueWrapper

  Public missiletwoslow As ValueWrapper
  Public missiletwoslowduration As ValueWrapper

  Public sceptermissiletwodamage As New List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    mDisplayName = "Call Down"
    Notes = "The first missile impacts 2 seconds and the second missile 4 seconds after cast.|The missile's damage and slow duration are bound to the missiles, while the slow depends on wether a unit has the slow debuff from the first missile on or not.|This means when a unit does not have the debuff on (first missile missed or the debuff was purged), but is hit by the second missile, it will be slowed for 50%, instead of 20%.|Provides 300 radius flying vision at the targeted area for 4 seconds since cast.|Does not affect ancient creeps, Roshan, Warlock's Golems and the spirits from Primal Split.|The visual areal indicator is visible to allies only, but the sound effects are audible and the missiles visible to everyone." '"

    mName = eAbilityName.abCall_Down
    Me.EntityName = eEntity.abCall_Down

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGyrocopter

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/gyrocopter_call_down_hp2.png"

    Description = "Call down an aerial missile strike on enemy units in a target area. Two missiles arrive in succession, the first dealing major damage and major slow; the second dealing minor damage and minor slow. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(125, 125, 125)


    Cooldown = New ValueWrapper(55, 50, 45)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    missileonedamage = New ValueWrapper(250, 300, 350)
    missileoneslowduration = New ValueWrapper(2, 2, 2, 2)

    missiletwodamage = New ValueWrapper(100, 150, 200)
    missiletwoslowduration = New ValueWrapper(3, 3, 3, 3)

    sceptermissiletwodamage.Add(175)
    sceptermissiletwodamage.Add(225)
    sceptermissiletwodamage.Add(275)
    missiletwodamage.LoadScepterValues(sceptermissiletwodamage)


    missileoneslow = New ValueWrapper(0.3, 0.3, 0.3)

    missiletwoslow = New ValueWrapper(0.6, 0.6, 0.6)

    Radius = New ValueWrapper(600, 600, 600)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim miss1pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "Missile one", eModifierCategory.Active)

    Dim miss2pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "Missile two", eModifierCategory.Active)


    Dim mis1damval As New modValue(missileonedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim mis1damage As New Modifier(mis1damval, miss1pointtargetenemies)
    outmods.Add(mis1damage)



    Dim mis1slowval As New modValue(missileoneslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    mis1slowval.mValueDuration = missileoneslowduration

    Dim mis1slow As New Modifier(mis1slowval, miss1pointtargetenemies)
    outmods.Add(mis1slow)



    Dim mis2damval As New modValue(missiletwodamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim mis2damage As New Modifier(mis2damval, miss2pointtargetenemies)
    outmods.Add(mis2damage)



    Dim mis2slowval As New modValue(missiletwoslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    mis2slowval.mValueDuration = missiletwoslowduration

    Dim mis2slow As New Modifier(mis2slowval, miss2pointtargetenemies)
    outmods.Add(mis2slow)





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
