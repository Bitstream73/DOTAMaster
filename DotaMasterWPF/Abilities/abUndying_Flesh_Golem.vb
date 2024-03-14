Public Class abFlesh_Golem
Inherits AbilityBase
  Public maxdamageamp As ValueWrapper
  Public scmaxdamageamp As New List(Of Double?)

  Public mindamageamp As ValueWrapper
  Public scmindamageamp As New List(Of Double?)

  Public maxmoveslow As ValueWrapper
  Public minmoveslow As ValueWrapper

  Public deathhealheroes As ValueWrapper
  Public scdeathhealheroes As New List(Of Double?)

  Public deathhealcreeps As ValueWrapper
  Public scdeathhealcreeps As New List(Of Double?)


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

    mDisplayName = "Undying Flesh"
    mName = eAbilityName.abFlesh_Golem
    Me.EntityName = eEntity.abFlesh_Golem

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUndying

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/undying_flesh_golem_hp2.png"

    Description = "Undying transforms into a horrifying flesh golem that possesses a Plague Aura. This aura slows all enemy units within 750 range and amplifies the damage they take; the closer to Undying, the more damage. When a plagued unit dies, Undying is healed equal to a percentage of that unit's maximum health. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(100, 100, 100)
    Cooldown = New ValueWrapper(75, 75, 75)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyHeroes)
    Affects.Add(eUnit.untEnemyCreeps)

    Duration = New ValueWrapper(30, 30, 30)

    maxdamageamp = New ValueWrapper(0.2, 0.25, 0.3)
    scmaxdamageamp.Add(0.3)
    scmaxdamageamp.Add(0.35)
    scmaxdamageamp.Add(0.4)
    maxdamageamp.LoadScepterValues(scmaxdamageamp)

    mindamageamp = New ValueWrapper(0.05, 0.1, 0.15)
    scmindamageamp.Add(0.15)
    scmindamageamp.Add(0.2)
    scmindamageamp.Add(0.25)
    mindamageamp.LoadScepterValues(scmindamageamp)

    maxmoveslow = New ValueWrapper(0.2, 0.2, 0.2)
    minmoveslow = New ValueWrapper(0.05, 0.05, 0.05)

    deathhealheroes = New ValueWrapper(0.06, 0.06, 0.06)
    scdeathhealheroes.Add(0.1)
    scdeathhealheroes.Add(0.1)
    scdeathhealheroes.Add(0.1)
    deathhealheroes.LoadScepterValues(scdeathhealheroes)

    deathhealcreeps = New ValueWrapper(0.02, 0.02, 0.02)
    scdeathhealcreeps.Add(0.03)
    scdeathhealcreeps.Add(0.03)
    scdeathhealcreeps.Add(0.03)
    deathhealcreeps.LoadScepterValues(scdeathhealcreeps)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    'damage debuff
    Dim damval As New modValue(maxdamageamp, eModifierType.DamageAllTypesIncomingIncreasesPercent, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, activeauraenemies)
    outmods.Add(dammod)


    'slow
    Dim slowval As New modValue(maxmoveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)

    Dim slowmod As New Modifier(slowval, activeauraenemies)
    outmods.Add(slowmod)

    'death heal heroes
    Dim heroval As New modValue(deathhealheroes, eModifierType.HealAddedPerDeadHero, occurencetime, aghstime)
    heroval.mValueDuration = Duration

    Dim heromod As New Modifier(heroval, activeauraenemies)
    outmods.Add(heromod)


    'death heal creeps
    Dim creepval As New modValue(deathhealcreeps, eModifierType.HealAddedPerDeadCreep, occurencetime, aghstime)
    creepval.mValueDuration = Duration

    Dim creepmod As New Modifier(creepval, activeauraenemies)
    outmods.Add(creepmod)


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
