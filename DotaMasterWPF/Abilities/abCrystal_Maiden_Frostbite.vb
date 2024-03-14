Public Class abFrostbite
Inherits AbilityBase
  'Dim damageperhalfsecond As ValueWrapper ' 70
  Dim heroduration As ValueWrapper
  Dim creepduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = True
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    mDisplayName = "Frostbite"
    Notes = "No cast point.|True blink abilities cannot be used while under the effects of Frostbite.|Frostbite does not prevent Phantom Strike, Duel, or Sun Ray's toggled movement. It interrupts Icarus Dive during its effect, but does not prevent it from being cast.|Unique Attack Modifier abilities cannot be manually cast while Frostbite is active.|Units that turn invisible during Frostbite are still revealed for its duration.|Always lasts 10 seconds when cast on creeps, no matter the ability level.|Damage is done in 1 second intervals starting at 0, dealing 140/210/210/280 total damage (or 700 damage on creeps).|Applies an initial mini-stun to the target before the rest of Frostbite's effects."
    mName = eAbilityName.abFrostbite

    Me.EntityName = eEntity.abFrostbite


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCrystal_Maiden

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/crystal_maiden_frostbite_hp2.png"
    WebpageLink = ""
    Description = "Encases an enemy unit in ice, prohibiting movement and attack, while dealing damage per second. Lasts 10 seconds on creeps level 6 or lower."


    ManaCost = New ValueWrapper(115, 125, 140, 150)

    Cooldown = New ValueWrapper(10, 9, 8, 7)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(50, 50, 50, 60)

    Range = New ValueWrapper(500, 500, 500, 500)

    heroduration = New ValueWrapper(1.5, 2, 2.5, 3)

    creepduration = New ValueWrapper(10, 10, 10, 10)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    'receiver of the mods will have to figure out which of the mods to choose (hero or creep)
    'based on the target type (hero or creep, or neither)

    Dim unittargetenemyhero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim unittargetenemycreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    'move mute heroes and creeps
    Dim heromoveval As New modValue(heroduration, eModifierType.MuteMove, occurencetime, aghstime)
    heromoveval.mValueDuration = heroduration

    Dim movemute As New Modifier(heromoveval, unittargetenemyhero)
    outmods.Add(movemute)


    Dim creepmoveval As New modValue(creepduration, eModifierType.MuteMove, occurencetime, aghstime)
    creepmoveval.mValueDuration = creepduration

    Dim creepmovemute As New Modifier(creepmoveval, unittargetenemycreep)
    outmods.Add(creepmovemute)


    'ability mute heroes and creeps
    Dim herocastval As New modValue(heroduration, eModifierType.MuteAbilities, occurencetime, aghstime)
    herocastval.mValueDuration = heroduration

    Dim herocastmute As New Modifier(herocastval, unittargetenemyhero)
    outmods.Add(herocastmute)


    Dim creepcastval As New modValue(creepduration, eModifierType.MuteAbilities, occurencetime, aghstime)
    creepcastval.mValueDuration = creepduration

    Dim creepcastmute As New Modifier(creepcastval, unittargetenemycreep)
    outmods.Add(creepcastmute)

    'damage over time heroes and creeps
    Dim halfsec As New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    Dim herodotval As New modValue(Damage, eModifierType.DamageMagicalAdded, halfsec, occurencetime, aghstime)
    herodotval.mValueDuration = heroduration

    Dim herodot As New Modifier(herodotval, unittargetenemyhero)
    outmods.Add(herodot)


    Dim creepdotval As New modValue(Damage, eModifierType.DamageMagicalAdded, halfsec, occurencetime, aghstime)
    herodotval.mValueDuration = creepduration

    Dim creepdot As New Modifier(creepdotval, unittargetenemyhero)
    outmods.Add(creepdot)


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
