Public Class abIce_Wall
Inherits AbilityBase
  Public wallspawndistance As ValueWrapper
  Public walllength As ValueWrapper
  Public wallwidth As ValueWrapper
  Public exortdampersec As ValueWrapper
  Public quasmoveslow As ValueWrapper
  Public quaswallduration As ValueWrapper
  Public slowduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Ice Wall interrupts Invoker's channeling spells upon cast.|Ice Wall is always created in front of Invoker, perpendicular to the line between Invoker and a point 200 range right in front of him.|Creates 15 wall segments, with a spacing of 80 between each, resulting in a total length of 1120. Each segment affects a 105 radius around them.|So the wall's effective length is 1330 (1120 wall length + 105 radius from both sides).|Each segment possesses a movement speed slowing aura. Its debuff lingers for 2 seconds.|The damage is independent from the slow, so getting further than 105 radius away from a segment immediately stops the damage, while the slow still lingers.|Deals damage in 1 second intervals, starting 1 second after cast, resulting in up to 3/4/6/7/9/10/12 possible instances.|Can deal up to 18/48/108/168/270/360/504 damage to a single unit (before reductions), when it stays in range for its full duration.|Damages, but does not slow ancient creeps, Roshan, Warlock's Golem, or Storm or Fire from Primal Split.|Ice Wall is not a pathing blocker. Any unit can pass through it."

    mDisplayName = "Ice Wall"
    mName = eAbilityName.abIce_Wall
    Me.EntityName = eEntity.abIce_Wall

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_ice_wall_hp2.png"

    Description = "Generates a wall of solid ice directly in front of Invoker for a duration based on the level of Quas. The bitter cold emanating from it greatly slows nearby enemies based on the level of Quas and deals damage each second based on the level of Exort."

    ManaCost = New ValueWrapper(175, 175, 175, 175, 175, 175, 175)

    Cooldown = New ValueWrapper(25, 25, 25, 25, 25, 25, 25)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    wallspawndistance = New ValueWrapper(200, 200, 200, 200, 200, 200, 200)
    walllength = New ValueWrapper(1200, 1200, 1200, 1200, 1200, 1200, 1200)
    wallwidth = New ValueWrapper(105, 105, 105, 105, 105, 105, 105)
    exortdampersec = New ValueWrapper(6, 12, 18, 24, 30, 36, 42)
    quasmoveslow = New ValueWrapper(0.2, 0.4, 0.6, 0.8, 1, 1.2, 1.4)
    quaswallduration = New ValueWrapper(3, 4.5, 6, 7.5, 9, 10.5, 12)
    slowduration = New ValueWrapper(2, 2, 2, 2, 2, 2, 2)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                            thecaster As iDisplayUnit, _
                                                            thetarget As iDisplayUnit, _
                                                            ftarget As iDisplayUnit, _
                                                            isfriendbias As Boolean, _
                                                            occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetline = Helpers.GetNoTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(exortdampersec, eModifierType.ExortDamageMagicalInflictedoT, occurencetime, aghstime)
    damval.mValueDuration = quaswallduration
    damval.mAreaOfAffected = New ValueWrapper(1330 * (105 * 2), _
                                              1330 * (105 * 2), _
                                              1330 * (105 * 2), _
                                              1330 * (105 * 2), _
                                              1330 * (105 * 2), _
                                              1330 * (105 * 2), _
                                              1330 * (105 * 2))

    Dim dammod As New Modifier(damval, notargetline)
    outmods.Add(dammod)


    Dim slowval As New modValue(quasmoveslow, eModifierType.QuasMoveSpeedPercentChange, occurencetime, aghstime)
    damval.mValueDuration = slowduration
    damval.mAreaOfAffected = damval.mAreaOfAffected

    Dim slowmod As New Modifier(slowval, notargetline)
    outmods.Add(slowmod)


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
