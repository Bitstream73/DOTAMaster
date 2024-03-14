Public Class abFamiliar_Stone_Form
  Inherits AbilityBase
  Public effectdelay As ValueWrapper
  Public stundamagedelay As ValueWrapper
  Public healthregenbonus As ValueWrapper
  Public stunduration As ValueWrapper
  Public stoneformduration As ValueWrapper

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

    mDisplayName = "Stone Form"
    mName = eAbilityName.abFamiliar_Stone_Form
    Me.EntityName = eEntity.abFamiliar_Stone_Form

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFamiliar

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/20/Stone_Form_%28Familiar%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Visage#Familiars"
    Description = "After a short delay, the Familiar turns into stone and smashes into the ground, stunning and damaging all targets in the area. The Familiar becomes invulnerable, and will regain its damage charges and health very rapidly. After 8 seconds, the Familiar will automatically leave Stone Form."
    Notes = "Stone Form has an instant cast time.|The health regen, invulnerability and damage charge restore are applied after the effect delay.|The area damage and stun are applied after the stun & damage delay.|During the stun delay, the Familiar is rooted, however, since their movement speed can't be impaired, they still can move during the delay.|Despite the visual effects, the damage and stun area location is determined upon landing, not upon cast.|When a Familiar dies during the effect delay, the area damage and stun are still applied after the stun & damage delay.|Heals for up to 400/549.6/700 health over its duration, so the Familiars will always have full health afterwards.|The Stone Form duration is indicated by a yellow number above the Familiar. This number is visible to Visage only."

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(26)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    ' mAffects.Add(eUnit)

    Duration = New ValueWrapper(8, 8, 8)
    Radius = New ValueWrapper(325, 325, 325)
    effectdelay = New ValueWrapper(0.5, 0.5, 0.5)
    healthregenbonus = New ValueWrapper(50, 68.7, 87.5)
    Damage = New ValueWrapper(60, 100, 140)
    stunduration = New ValueWrapper(1, 1.25, 1.5)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)
    Dim notargetenemies = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetenemies)
    outmods.Add(dammod)

    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, notargetenemies)
    outmods.Add(stunmod)


    Dim healval As New modValue(healthregenbonus, eModifierType.HealAddedoT, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    healval.mValueDuration = Duration

    Dim healmod As New Modifier(healval, notargetself)
    outmods.Add(healmod)

    Dim invulval As New modValue(Duration, eModifierType.Invulnerability, occurencetime, aghstime)
    invulval.mValueDuration = Duration

    Dim invulmod As New Modifier(invulval, notargetself)
    outmods.Add(invulmod)


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
