Public Class abSatyr_Tormentor_Shockwave
  Inherits AbilityBase
  Public startingradius As ValueWrapper
  Public endradius As ValueWrapper
  Public distance As ValueWrapper


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

    mDisplayName = "Shockwave"
    mName = eAbilityName.abShockwave
    Me.EntityName = eEntity.abShockwave

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSatyr_Tormentor

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/d/de/Shockwave_%28Satyr_Tormenter%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Satyr_Tormenter"
    Description = "The Satyr Tormenter tears open an unstable rift to the underworld, creating a shockwave that travels in a line along the ground, dealing damage to enemies it hits."
    Notes = "The shockwave travels at a speed of 1050.|Can hit units up to 1000 range away (800 travel distance + 200 end radius)|The complete affected area is shaped like a cone.|When targeting a unit, it will be casted towards the unit's direction.|As a neutral unit: The satyr only casts Shockwave when 3 or more hostile units are within the cast range and it is getting aggroed.|All 3 units must be valid targets for the spell. Units which aren't affected by the spells don't count.|Always casts it towards the closest of the 3 units.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(100)

    Cooldown = New ValueWrapper(8)

    AbilityTypes.Add(eAbilityType.PointTargetCone)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    Range = New ValueWrapper(700)

    startingradius = New ValueWrapper(180)
    distance = New ValueWrapper(800)
    endradius = New ValueWrapper(200)
    Damage = New ValueWrapper(125)
    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim coneenemies = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.mAreaOfAffected = New ValueWrapper(Helpers.GetTrapezoidArea(startingradius.Value(0), endradius.Value(0), distance.Value(0)) + _
      (Helpers.GetCircleArea(startingradius.Value(0)) / 2) + (Helpers.GetCircleArea(endradius.Value(0)) / 2))

    Dim dammod As New Modifier(damval, coneenemies)
    outmods.Add(dammod)
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
