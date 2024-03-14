Public Class abWeave
Inherits AbilityBase
  Public allyarmorpersec As ValueWrapper
  Public enemyarmorpersec As ValueWrapper
  Public sceptorradius As New List(Of Double?)
  Public allysceptorarmorpersec As New List(Of Double?)
  Public enemysceptorarmorpersec As New List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Places a buff on units, so entering or leaving the area after the cast has no effect.Increases/Decreases armor by a maximum of 18/24/30 (30/36/42*).|Unobstructed sight (800 range day and night) is provided for 8 seconds.|Cannot be dispelled by anything." '"

    mDisplayName = "Weave"
    mName = eAbilityName.abWeave
    Me.EntityName = eEntity.abWeave

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDazzle

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dazzle_weave_hp2.png"

    Description = "Applies a buff that increases the armor of allied heroes while decreasing the armor of enemy heroes in the target area over time. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(100, 100, 100)

    Cooldown = New ValueWrapper(40, 40, 40)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(575, 575, 575)
    sceptorradius.Add(775)
    sceptorradius.Add(775)
    sceptorradius.Add(775)
    Radius.LoadScepterValues(sceptorradius)

    allyarmorpersec = New ValueWrapper(0.75, 1, 1.25)
    allysceptorarmorpersec.Add(1.25)
    allysceptorarmorpersec.Add(1.5)
    allysceptorarmorpersec.Add(1.75)
    allyarmorpersec.LoadScepterValues(allysceptorarmorpersec)


    enemyarmorpersec = New ValueWrapper(0.75, 1, 1.25)
    enemysceptorarmorpersec.Add(1.25)
    enemysceptorarmorpersec.Add(1.5)
    enemysceptorarmorpersec.Add(1.75)
    enemyarmorpersec.LoadScepterValues(enemysceptorarmorpersec)

    Duration = New ValueWrapper(24, 24, 24)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemyunits = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim pointtargetallies = Helpers.GetPointTargetAlliedUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)








    'allies armor buff
    Dim armoreval As New modValue(allyarmorpersec, eModifierType.ArmorAddedPerSec, occurencetime, aghstime)
    armoreval.mValueDuration = Duration

    Dim thearmorallies As New Modifier(armoreval, pointtargetallies)
    outmods.Add(thearmorallies)


    'enemy armor debuf

    Dim armorenemies As New modValue(enemyarmorpersec, eModifierType.ArmorSubtractedoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    armorenemies.mValueDuration = Duration

    Dim thearmordebuff As New Modifier(armorenemies, pointtargetenemyunits)
    outmods.Add(thearmordebuff)




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
