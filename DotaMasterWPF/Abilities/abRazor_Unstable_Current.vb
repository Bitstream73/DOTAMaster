Public Class abUnstable_Current
Inherits AbilityBase

  Public bonusspeed As ValueWrapper
  Public slowduration As ValueWrapper
  Public movespeedslow As ValueWrapper
  Public attackspeedslow As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "nstable Current applies a purge on the affected enemies.|Unstable Current applies its effect before the casted spell takes effect.|This means when the casting unit has low enough health to die to it, the spell will not be cast.|Unstable Current has a global range and affects units through the Fog of War or invisibility.|Unstable Current ensnares affected enemies for the initial 0.33 seconds.|During the very short ensnare the following spells cannot be cast: Queen of Pain Blink, Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger.|Active attack modifier like Frost Arrows or Glaives of Wisdom do not trigger Unstable Current." '"

    mDisplayName = "Unstable Current"
    mName = eAbilityName.abUnstable_Current
    Me.EntityName = eEntity.abUnstable_Current

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRazor

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/razor_unstable_current_hp2.png"

    Description = "Razor moves with increased speed, and any abilites targeted at him are instantly countered with a jolt of electricity which damages, slows, and purges buffs from enemies."

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(40, 70, 100, 130)

    bonusspeed = New ValueWrapper(0.04, 0.08, 0.12, 0.16)

    slowduration = New ValueWrapper(0.5, 1, 1.5, 2)

    movespeedslow = New ValueWrapper(1, 1, 1, 1)

    attackspeedslow = New ValueWrapper(100, 100, 100, 100)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


   Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList


    'Dim thelevel = theabilitylevel - 1
    ' Dim theduration = New TimeSpan(mDuration.Item(thelevel) * TimeSpan.TicksPerSecond)
    Dim notargettargettingenemy = Helpers.GetNoTargetEnemyTargettingCasterInfo(theability_InfoID, _
                                                                               caster, _
                                                                               target, _
                                                                               "", eModifierCategory.Passive)

    Dim valpurge As New modValue(1, eModifierType.Purge, occurencetime)

    Dim modpurge As New Modifier(valpurge, notargettargettingenemy)
    outmods.Add(modpurge)



    Dim valdam As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim moddama As New Modifier(valdam, notargettargettingenemy)
    outmods.Add(moddama)



    Dim valslow As New modValue(movespeedslow, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    valslow.mValueDuration = slowduration

    Dim modslow As New Modifier(valslow, notargettargettingenemy)
    outmods.Add(modslow)

    Dim valattslow As New modValue(attackspeedslow, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    valattslow.mValueDuration = slowduration

    Dim modattslow As New Modifier(valattslow, notargettargettingenemy)
    outmods.Add(modattslow)



    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                               caster, _
                                                                               target, _
                                                                               "", eModifierCategory.Passive)

    Dim valhmove As New modValue(bonusspeed, eModifierType.MoveSpeedPercent, occurencetime, aghstime)

    Dim modhmove As New Modifier(valhmove, notargetself)
    outmods.Add(modhmove)


    Return outmods
  End Function

End Class
