Public Class abAncient_Thunderhide_Slam
  Inherits AbilityBase

  Public heroslowduration As ValueWrapper
  Public nonheroslowduration As ValueWrapper
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
    mName = eAbilityName.abAncient_Thunderhide_Slam
    Me.EntityName = eEntity.abAncient_Thunderhide_Slam

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Thunderhide

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/1/18/Slam_icon.png/120px-Slam_icon.png?version=f08b206b8f708c123d68fed8bc179b8d"
    WebpageLink = "http://dota2.gamepedia.com/Thunderhide_Camp"
    Description = "The Ancient Thunderhide slams his mammoth body against the ground. The shock damages nearby enemies and throws them off their footing. Heroes regain their balance more quickly."
    Notes = "As of now, Slam has no legacy hotkey.|As a neutral unit: The thunderhide never uses this spell.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(90)

    Cooldown = New ValueWrapper(6)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    ' mDuration = New ValueWrapper()

    Radius = New ValueWrapper(250)
    Damage = New ValueWrapper(70)

    heroslowduration = New ValueWrapper(2)

    nonheroslowduration = New ValueWrapper(4)
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

    Dim enemycreeps = Helpers.GetNoTargetConeEnemyCreepsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim heroval As New modValue(heroslowduration, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    heroval.mValueDuration = heroslowduration

    Dim heromod As New Modifier(heroval, enemyheroes)
    outmods.Add(heromod)


    Dim creepval As New modValue(nonheroslowduration, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    creepval.mValueDuration = nonheroslowduration

    Dim creepmod As New Modifier(creepval, enemycreeps)
    outmods.Add(creepmod)

    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
