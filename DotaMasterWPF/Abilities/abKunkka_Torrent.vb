Public Class abTorrent
Inherits AbilityBase
  Public slowpercent As ValueWrapper
  Public slowduration As ValueWrapper
  Public stunduration As ValueWrapper
  Public delay As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The delay is 2 seconds at all levels (0.4 cast time + 1.6 delay).|Units tossed in the air will be stunned and still able to be attacked.|Units tossed in the air lose their collision size for the duration, so units can path below them.|After casting, the target area will gain a visual bubbling effect and a sound effect will play for the delay period. This effects can be seen and heard by allies only.|Half of the damage occurs right as the torrent erupts, the rest occurs as 10 ticks over 1.53 second stun duration.|Provides 225 radius ground vision over the targeted area after erupting for a short period of time." '"

    mDisplayName = "Torrent"
    mName = eAbilityName.abTorrent
    Me.EntityName = eEntity.abTorrent

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKunkka

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/kunkka_torrent_hp2.png"

    Description = "Summons a rising torrent that, after a short delay, hurls enemy units into the sky, stunning, dealing damage and slowing movement speed."

    ManaCost = New ValueWrapper(120, 120, 120, 120)
    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(120, 180, 240, 300)

    Radius = New ValueWrapper(225, 225, 225, 225)

    slowpercent = New ValueWrapper(0.35, 0.35, 0.35, 0.35)


    slowduration = New ValueWrapper(1, 2, 3, 4)

    stunduration = New ValueWrapper(1.53, 1.53, 1.53, 1.53)


    delay = New ValueWrapper(1.6, 1.6, 1.6, 1.6)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)


    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, pointtargetenemies)
    outmods.Add(thestun)


    Dim slowval As New modValue(slowpercent, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim theslow As New Modifier(slowval, pointtargetenemies)
    outmods.Add(theslow)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, pointtargetenemies)
    outmods.Add(thedamage)


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
