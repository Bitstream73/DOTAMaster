Public Class abOverwhelming_Odds
Inherits AbilityBase
  Public basedamage As ValueWrapper
  Public damagepercreep As ValueWrapper
  Public damageperhero As ValueWrapper
  Public illusiondamage As ValueWrapper
  Public speedfromcreeps As ValueWrapper
  Public speedfromheroes As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Summoned unit bonus damage is dealt before normal spell damage.|Invulnerable units, hidden units, siege units, Warlock's Golem, Visage's Familliars and Storm, Earth and Fire spirits from Primal Split are fully ignored.|Lone Druid's Spirit Bear and creeps dominated by Enchant, Holy Persuasion and Helm of the Dominator count as creeps and don't take the summoned units damage.|One part of the spell's sound effect plays during the cast animation, allowing easier fake-casting by canceling the cast."

    mDisplayName = "Overwhelming Odds"
    mName = eAbilityName.abOverwhelming_Odds
    Me.EntityName = eEntity.abOverwhelming_Odds

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLegion_Commander

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/legion_commander_overwhelming_odds_hp2.png"

    Description = "Turns the enemies' numbers against them, dealing damage and granting you bonus movement speed per unit or per hero. Deals bonus damage to illusions and summoned units as a percent of their current health."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(18, 18, 18, 18)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(330, 330, 330, 330)

    basedamage = New ValueWrapper(40, 80, 120, 160)

    damagepercreep = New ValueWrapper(14, 16, 18, 20)

    damageperhero = New ValueWrapper(20, 35, 50, 65)

    illusiondamage = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    speedfromcreeps = New ValueWrapper(0.03, 0.03, 0.03, 0.03)

    speedfromheroes = New ValueWrapper(0.09, 0.09, 0.09, 0.09)

    Duration = New ValueWrapper(7, 7, 7, 7)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    'damage to heroes and creeps, same
    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim basedam As New modValue(basedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thebasedamage As New Modifier(basedam, pointtargetenemies)
    outmods.Add(thebasedamage)




    'damage to heroes and creeps, different
    Dim pointtargetcreeps = Helpers.GetPointTargetEnemyCreepsInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim damcreepval As New modValue(damagepercreep, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thecreepdamage As New Modifier(damcreepval, pointtargetenemies)
    outmods.Add(thecreepdamage)


    Dim pointtargetenemyheroes = Helpers.GetPointTargetEnemyHeroesInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim damheroval As New modValue(damageperhero, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim theherodamage As New Modifier(damheroval, pointtargetenemyheroes)
    outmods.Add(theherodamage)



    'speed from heroes and creeps

    Dim speedcreepval As New modValue(speedfromcreeps, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    speedcreepval.mValueDuration = Duration

    Dim creepspeed As New Modifier(speedcreepval, pointtargetcreeps)
    outmods.Add(creepspeed)



    Dim speedheroval As New modValue(speedfromheroes, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    speedheroval.mValueDuration = Duration

    Dim herospeed As New Modifier(speedheroval, pointtargetenemyheroes)
    outmods.Add(herospeed)





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
