Public Class abHellbear_Smasher_Thunder_Clap
  Inherits AbilityBase

  Dim moveslow As ValueWrapper
  Dim attslow As ValueWrapper
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

    mDisplayName = "Thunder Clap"
    mName = eAbilityName.abHellbear_Smasher_Thunder_Clap
    Me.EntityName = eEntity.abHellbear_Smasher_Thunder_Clap

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHellbear_Smasher

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/c8/Thunder_Clap_%28Hellbear_Smasher%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Hellbear_Camp"
    Description = "The Hellbear Smasher claps his massive hands together, creating a deafening blast. The blast damages nearby enemies and throws them off their footing."
    Notes = "As a neutral unit: The hellbear only casts this spell when 3 or more enemy units within the radius and when it is attacking.|This means it won't cast it when there are 3 invulnerable units, however it will when it is aggroed.|All 3 units must be valid targets for the spell. Units which aren't affected by the spells don't count.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(100)

    Cooldown = New ValueWrapper(12)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    ' mAffects.Add(eUnit)

    Radius = New ValueWrapper(300)
    Damage = New ValueWrapper(150)
    moveslow = New ValueWrapper(0.25)
    attslow = New ValueWrapper(25)
    Duration = New ValueWrapper(3)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetenemies = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetenemies)
    outmods.Add(dammod)


    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, notargetenemies)
    outmods.Add(movemod)


    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, notargetenemies)
    outmods.Add(attmod)

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
