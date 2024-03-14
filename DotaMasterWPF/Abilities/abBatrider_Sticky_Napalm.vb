Public Class abSticky_Napalm
  Inherits AbilityBase
  Public extradamage As ValueWrapper
  Public extradamage_creeps As ValueWrapper
  Public movementslow As ValueWrapper
  Public turnrateslow As ValueWrapper
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

    Notes = "All damage from Batrider's attacks, items and abilities is amplified, except for damage from Radiance, Urn of Shadows and Orb of Venom. This, too, includes buffs, such as Ancient Apparition's Chilling Touch.|Bonus damage for Firefly is dealt per-second.|Sticky Napalm damage is calculated as extra damage per instance, meaning that if damage is calculated per tick (0.1 seconds) it will deal extra damage per tick|Damage from Sticky Napalm is dealt as a separate instance from each instance of damage it amplifies. This makes the ability exceptionally strong at tearing apart Templar Assassin's Refraction, and makes it stack with other amplification, such as Shadow Demon's Soul Catcher especially well.|Provides vision around the target point.|Bonus damage is halved against non-hero units.|1 stack from sticky napalm gives the full turn-rate slow." '"
    mDisplayName = "Sticky Napalm"
    mName = eAbilityName.abSticky_Napalm
    Me.EntityName = eEntity.abSticky_Napalm

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBatrider

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/batrider_sticky_napalm_hp2.png"

    Description = "Drenches an area in sticky oil, amplifying damage from Batrider's attacks and abilities and slowing the movement speed and turn rate of enemies in the area. Additional casts of Sticky Napalm continue to increase damage, up to 10 stacks. The extra damage is halved against creeps."

    ManaCost = New ValueWrapper(20, 20, 20, 20)

    Cooldown = New ValueWrapper(3, 3, 3, 3)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    extradamage = New ValueWrapper(10, 15, 20, 25)
    extradamage_creeps = New ValueWrapper(5, 7.5, 10, 12.5)

    Radius = New ValueWrapper(375, 375, 375, 375)

    Duration = New ValueWrapper(8, 8, 8, 8)

    movementslow = New ValueWrapper(0.03, 0.05, 0.07, 0.09)


    turnrateslow = New ValueWrapper(0.7, 0.7, 0.7, 0.7)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    'rightclick damage added
    Dim unittargetenemyhero = Helpers.GetUnitTargetAlliedHeroInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim valbonus As New modValue(extradamage, eModifierType.RightClickDamageAdded, occurencetime, aghstime)
    valbonus.mValueDuration = Duration

    Dim modbonus As New Modifier(valbonus, unittargetenemyhero)
    outmods.Add(modbonus)

    Dim unittargetenemycreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim valcreepbomus As New modValue(extradamage_creeps, eModifierType.RightClickDamageAdded, occurencetime, aghstime)
    valcreepbomus.mValueDuration = Duration

    Dim modcreepbonus As New Modifier(valcreepbomus, unittargetenemycreep)
    outmods.Add(modcreepbonus)

    'enemy heroes
    Dim pointtargetenemyheroes = Helpers.GetPointTargetEnemyHeroesInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)


    Dim valemove As New modValue(movementslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    valemove.mValueDuration = Duration

    Dim modmove As New Modifier(valemove, pointtargetenemyheroes)
    outmods.Add(modmove)


    Dim valeturn As New modValue(turnrateslow, eModifierType.TurnRateSubtracted, occurencetime, aghstime)
    valeturn.mValueDuration = Duration

    Dim modturn As New Modifier(valeturn, pointtargetenemyheroes)
    outmods.Add(modturn)

    'enemy creeps
    Dim pointtargetenemycreeps = Helpers.GetPointTargetEnemyCreepsInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)


    Dim modcbonus As New Modifier(valemove, pointtargetenemycreeps)
    outmods.Add(modcbonus)

    Dim modcreepturn As New Modifier(valeturn, pointtargetenemycreeps)
    outmods.Add(modcreepturn)

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
