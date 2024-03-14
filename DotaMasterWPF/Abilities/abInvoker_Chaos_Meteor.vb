Public Class abChaos_Meteor
  Inherits AbilityBase
  Public effectdelay As ValueWrapper
  Public trvldistance As ValueWrapper
  Public damageperinterval As ValueWrapper
  Public contactdamagetick As ValueWrapper
  Public damagepersec As ValueWrapper
  Public impactdelay As ValueWrapper
  Public burnduration As ValueWrapper
  Public rollduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Chaos Meteor needs 1.3 seconds to land. It lands at the targeted point, not at Invoker's position.|The meteor can hit units up to 1440/1590/1755/1905/2220/2385 range away (cast range + travel distance + radius). The area between Invoker and the targeted point is unaffected.|The visual effects and the sound during the 1.3 seconds effect delay (the meteor falling from the sky) are visible and audible to everyone.|Chaos Meteor rolls at a speed of 300 and always rolls the full distance, so it takes 1.55/2.05/2.6/3.1/3.65/4.15/4.7 seconds to reach the max distance.|After landing, the meteor deals its main damage and places the burn debuff to all affected units within its effect radius in 0.5 second intervals, starting immediately after landing.|The main damage can hit a unit up to 4/5/6/7/8/9/10 times and thus can deal up to 230/375/555/770/1020/1305/1625 damage (before reductions) when a unit is hit by all instances.|The burn debuff deals damage in 1 second intervals, starting 1 second after the debuff is placed, resulting in 3 instances for each debuff.|The debuffs from each interval fully stack and don't refresh each other. So a unit can be affected by 4/5/6/7/8/9/10 instances of the burn debuff per cast.|One instance of the burn debuff can deal up to 34.5/45/55.5/66/76.5/87/97.5 damage (before reductions).|All possible instances of burn damage per unit together can deal up to 138/225/333/462/612/783/975 damage (before reductions).|The whole Chaos Meteor, main and burn damage, can deal up to 368/600/888/1232/1632/2088/2600 damage (before reductions) when a unit is hit by all possible instances.|Does not affect ancient creeps, Roshan, Warlock's Golem and Storm and Fire from Primal Split.|Chaos Meteor provides 400 radius flying vision while it is rolling. This vision does not last.|Also provides the same vision for 3 seconds after reaching its max travel distance." '"

    mDisplayName = "Chaos Meteor"
    mName = eAbilityName.abChaos_Meteor
    Me.EntityName = eEntity.abChaos_Meteor

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1
    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_chaos_meteor_hp2.png"

    Description = "Invoker pulls a flaming meteor from space onto the targeted location. Upon landing, the meteor rolls forward, constantly dealing damage based on the level of Exort, and rolling further based on the level of Wex. Units hit by the meteor will also be set on fire for a short time, receiving additional damage based on the level of Exort."

    ManaCost = New ValueWrapper(200, 200, 200, 200, 200, 200, 200)

    Cooldown = New ValueWrapper(55, 55, 55, 55, 55, 55, 55)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Range = New ValueWrapper(700, 700, 700, 700, 700, 700, 700)

    Radius = New ValueWrapper(275, 275, 275, 275, 275, 275, 275)

    trvldistance = New ValueWrapper(465, 615, 780, 930, 1095, 1245, 1410)

    effectdelay = New ValueWrapper(1.3, 1.3, 1.3, 1.3, 1.3, 1.3, 1.3)


    impactdelay = New ValueWrapper(1.3, 1.3, 1.3, 1.3, 1.3, 1.3, 1.3)

    contactdamagetick = New ValueWrapper(0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5)

    damageperinterval = New ValueWrapper(57.5, 75, 92.5, 110, 127.5, 145, 162.5)

    damagepersec = New ValueWrapper(11.5, 15, 18.5, 22, 25.5, 29, 32.5)

    burnduration = New ValueWrapper(3, 3, 3, 3, 3, 3, 3)

    rollduration = New ValueWrapper(1.55, 2.05, 2.6, 3.1, 3.65, 4.15, 4.7)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                        thecaster As iDisplayUnit, _
                                                        thetarget As iDisplayUnit, _
                                                        ftarget As iDisplayUnit, _
                                                        isfriendbias As Boolean, _
                                                        occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



    Dim outmods As New ModifierList

    'Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
    '                                                              thecaster, _
    '                                                              thetarget, _
    '                                                              "", eModifierCategory.Active)

    Dim lineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim maindamval As New modValue(damageperinterval, eModifierType.ExortDamageMagicalInflictedoT, contactdamagetick, occurencetime, aghstime)
    maindamval.mValueDuration = rollduration

    Dim maindammod As New Modifier(maindamval, lineenemies)
    outmods.Add(maindammod)

    Dim burndamval As New modValue(damagepersec, eModifierType.ExortDamageMagicalInflictedoT, New ValueWrapper(1, 1, 1, 1, 1, 1, 1), occurencetime, aghstime)
    burndamval.mValueDuration = burnduration

    Dim burnmod As New Modifier(burndamval, lineenemies)
    outmods.Add(burnmod)
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
