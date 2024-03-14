Public Class abSnowball
  Inherits AbilityBase
  Public basedamage As ValueWrapper
  Public DamagePerAlly As ValueWrapper
  Public bonusspeedperally As ValueWrapper
  Public stunduration As ValueWrapper
  Public gatherradius As ValueWrapper
  Public launchtime As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The snowball's base speed equals to 150% of Tusk's movement speed.|Damage output assuming 4 allied Heroes are gathered: 160/240/320/400.|The following units can be loaded inside the Snowball:|Allied heroes (will add damage and speed)|Meepo clones (will add damage and speed)|Illusions and other units owned by Tusk (including Frozen Sigil, excluding courier and wards) (will not add damage and speed)|Magic immunity and invulnerability doesn't prevent loading in|Special mention: A unit affected by Flaming Lasso icon.png Flaming Lasso cannot be loaded inside the Snowball, however attempting to do so will still add damage and speed to the Snowball.|The snowball stops chasing its target after 3 seconds. It cannot be disjointed.|The snowball grows visually bigger in size the longer it travels. The stun and damage area also increases by 40 per second while traveling.|Tusk cannot be forced out of the Snowball by any means. Other units inside the Snowball however still can be forced out by teleporting spells.|Units inside Snowball are invulnerable and hidden. During Snowball, no items and spells may be used by anyone inside.|Allied units may right-click onto the Snowball during the launch time to jump in.|When Snowball connects with its target, Tusk is given an attack order on the target.|The disable help function prevents an allied Tusk from getting you inside his Snowball.|The snowball destroys trees." 'FixFixFix"

    mDisplayName = "Snowball"
    mName = eAbilityName.abSnowball
    Me.EntityName = eEntity.abSnowball

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTusk

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tusk_snowball_hp2.png"

    Description = "Tusk begins rolling into a snowball, automatically gathering allied Heroes within a 100 radius. Allies within a 400 radius can also be added to the snowball by right-clicking on them. Once launched, any enemies caught in the snowball's path will be stunned and take damage. Each allied Hero in the snowball will add to its speed and damage."

    ManaCost = New ValueWrapper(75, 75, 75, 75)

    Cooldown = New ValueWrapper(21, 20, 19, 18)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    basedamage = New ValueWrapper(80, 120, 160, 200)

    DamagePerAlly = New ValueWrapper(20, 30, 40, 50)

    bonusspeedperally = New ValueWrapper(100, 100, 100, 100)

    stunduration = New ValueWrapper(0.5, 0.75, 1, 1.25)

    gatherradius = New ValueWrapper(100, 100, 100, 100)

    launchtime = New ValueWrapper(4, 4, 4, 4)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                         thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim basedamval As New modValue(basedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim basedamagemod As New Modifier(basedamval, auraenemies)
    outmods.Add(basedamagemod)



    Dim stunval As New modValue(Duration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = Duration

    Dim thestun As New Modifier(stunval, auraenemies)
    outmods.Add(thestun)



    Dim auraenemiesfromallies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                         thecaster, _
                                                          thetarget, _
                                                          "Damage per Ally", eModifierCategory.Active)


    Dim damperally As New modValue(DamagePerAlly, eModifierType.DamageMagicalInflictedPerAlly, occurencetime, aghstime)
    damperally.mRadius = gatherradius

    Dim thedamageperally As New Modifier(damperally, auraenemiesfromallies)
    outmods.Add(thedamageperally)


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
