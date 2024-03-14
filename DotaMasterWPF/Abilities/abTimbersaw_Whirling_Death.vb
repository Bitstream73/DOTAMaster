Public Class abWhirling_Death
Inherits AbilityBase

  Public statlosspercent As ValueWrapper
  Public statlossduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False


    Notes = "Has an instant cast time, but interrupts channeling spells.|Stats reduction is applied before damage.|Stats reduction debuff stacks with itself.|Also reduces stats on hit illusions."

    mDisplayName = "Whirling Death"
    mName = eAbilityName.abWhirling_Death
    Me.EntityName = eEntity.abWhirling_Death

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTimbersaw

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shredder_whirling_death_hp2.png"

    Description = "Timbersaw whirls extremely sharp edges, damaging enemies and destroying trees around him in an area. If an enemy hero is affected, it loses some of its primary attribute for a short duration. Whirling Death will deal Pure damage if a tree is cut down in the process."

    ManaCost = New ValueWrapper(70, 80, 90, 100)

    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(300, 300, 300, 300)

    Damage = New ValueWrapper(100, 150, 200, 250)

    statlosspercent = New ValueWrapper(0.15, 0.15, 0.15, 0.15)

    statlossduration = New ValueWrapper(7, 7, 7, 7)

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
                                                          "Pure damage if tree cut down during spell", eModifierCategory.Active)

    Dim damval As New modValue(Me.Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim damage As New Modifier(damval, auraenemies)
    outmods.Add(damage)

    Dim auraenemyheroes = Helpers.GetActiveAuraEnemyHeroesInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "Pure damage if tree cut down during spell", eModifierCategory.Active)

    Dim statlossval As New modValue(statlosspercent, eModifierType.PrimaryStatLossPercent, occurencetime, aghstime)
    statlossval.mValueDuration = statlossduration

    Dim statloss As New Modifier(statlossval, auraenemyheroes)
    outmods.Add(statloss)

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
