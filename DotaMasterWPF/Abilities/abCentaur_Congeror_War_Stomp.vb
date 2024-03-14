Public Class abCentaur_Congeror_War_Stomp
  Inherits AbilityBase

  Public herostunduration As ValueWrapper
  Public nonherostunduration As ValueWrapper
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

    mName = eAbilityName.abCentaur_Congeror_War_Stomp
    Me.EntityName = eEntity.abCentaur_Congeror_War_Stomp

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCentaur_Conqueror

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False
    mDisplayName = "War Stomp"
    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/f/f6/War_Stomp_%28Centaur_Conqueror%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Centaur_Camp"
    Description = "The Centaur Conqueror's powerful hooves stomp the ground, stunning and damaging nearby enemies. Heroes recover more quickly."
    Notes = "As a neutral unit: The centaur only casts this spell when 3 or more enemy units within the radius and when it is attacking.|This means it won't cast it when there are 3 invulnerable units, however it will when it is aggroed.|All 3 units must be valid targets for the spell. Units which aren't affected by the spells don't count.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(100)

    Cooldown = New ValueWrapper(20)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    Radius = New ValueWrapper(250)
    Damage = New ValueWrapper(25)

    herostunduration = New ValueWrapper(2)
    nonherostunduration = New ValueWrapper(3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetheroes = Helpers.GetActiveAuraEnemyHeroesInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim notargetcreeps = Helpers.GetActiveAuraEnemyCreepsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim notargetenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetenemies)
    outmods.Add(dammod)



    Dim herostunval As New modValue(herostunduration, eModifierType.Stun, occurencetime, aghstime)
    herostunval.mValueDuration = herostunduration

    Dim herostunmod As New Modifier(herostunval, notargetheroes)
    outmods.Add(herostunmod)


    Dim creepstunval As New modValue(nonherostunduration, eModifierType.Stun, occurencetime, aghstime)
    creepstunval.mValueDuration = nonherostunduration

    Dim creepstunmod As New Modifier(creepstunval, notargetcreeps)
    outmods.Add(creepstunmod)

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
