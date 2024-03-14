Public Class abLeap
Inherits AbilityBase
  Public leapdistance As ValueWrapper
  Public movementbonus As ValueWrapper
  Public attackspeedbonus As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Has an instant cast time, but interrupts channeling spells.|Upon cast, Mirana leaps towards the direction she is facing.|Leaps at a speed of 1600.|Disjoints projectiles upon cast.|Can leap over other units and over impassable terrain.|During the Leap, Mirana can turn, attack, cast spells and use items.|The bonus movement and attack speed is applied at the cast location.|Buff does not appy on invulnerable or hidden allies." '"

    mDisplayName = "Leap"
    mName = eAbilityName.abLeap
    Me.EntityName = eEntity.abLeap

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMirana

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/mirana_leap_hp2.png"

    Description = "Mirana leaps forward into battle, empowering allied units with a ferocious roar that grants bonus attack and movement speed. Speed bonus lasts 10 seconds."


    ManaCost = New ValueWrapper(40, 35, 30, 20)

    Cooldown = New ValueWrapper(30, 26, 22, 18)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    Duration = New ValueWrapper(10, 10, 10, 10)

    leapdistance = New ValueWrapper(600, 700, 800, 900)

    movementbonus = New ValueWrapper(0.04, 0.08, 0.12, 0.16)

    attackspeedbonus = New ValueWrapper(8, 16, 24, 32)

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


    Dim theleapval As New modValue(1, eModifierType.Leap, occurencetime)

    Dim theleap As New Modifier(theleapval, notargetself)
    outmods.Add(theleap)


    Dim themoveval As New modValue(movementbonus, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    themoveval.mValueDuration = Duration

    Dim themove As New Modifier(themoveval, notargetself)
    outmods.Add(themove)


    Dim theattval As New modValue(attackspeedbonus, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    theattval.mValueDuration = Duration

    Dim theatt As New Modifier(theattval, notargetself)
    outmods.Add(theatt)



    Dim alliesaura = Helpers.GetActiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim themoveally As New Modifier(themoveval, alliesaura)
    outmods.Add(themoveally)


    Dim theattally As New Modifier(theattval, alliesaura)
    outmods.Add(theattally)

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
