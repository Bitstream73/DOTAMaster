Public Class abPoison_Touch
Inherits AbilityBase
  Public slowtime As ValueWrapper
  Private damageduration As ValueWrapper

  Private sec1slowtimes As ValueWrapper
  Private sec2slowtimes As ValueWrapper
  Private sec3slowtimes As ValueWrapper
  Private lvl4stun As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Lvl 1: Slow target by 33% for 3 seconds.|Lvl 2: Slow target by 33% for 2 seconds, then slow target by 66% for 1 second.|Lvl 3: Slow target by 33% for 1 second, then slow target by 66% for 1 second, then slow target by 100% for 1 second.|Lvl 4: Slow target by 33% for 1 second, then slow target by 66% for 1 second, then stun target for 1 second.|The damage is not reduced by damage block abilities (such as Vanguard, Kraken Shell, etc.).|After 3 seconds, damage occurs as 8 damage ticks over 7 seconds, dealing a total of 112/160/208/256 damage|Projectile is dodgeable."

    mDisplayName = "Poison Touch"
    mName = eAbilityName.abPoison_Touch
    Me.EntityName = eEntity.abPoison_Touch



    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDazzle

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dazzle_poison_touch_hp2.png"

    Description = "Casts a poisonous spell on an enemy unit, causing damage and slowness over time, and eventual paralysis. Slow increases per level. Level 1 slows the target by 33% during the set time. Level 2 slows the target by 33% for 2 seconds, then by 66% for 1 second. Level 3 slows the target by 33%, 66%, and 100%, for one second respectively. Level 4 slows the target by 33%, then slows the target by 66% for 1 second, then stuns the target for 1 second."


    ManaCost = New ValueWrapper(100, 115, 130, 145)

    Cooldown = New ValueWrapper(15, 13, 11, 7)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical


    Damage = New ValueWrapper(14, 20, 26, 32)

    slowtime = New ValueWrapper(3, 3, 3, 3)

    damageduration = New ValueWrapper(10, 10, 10, 10)

    sec1slowtimes = New ValueWrapper(0.33, 0.33, 0.33, 0.33)
    sec2slowtimes = New ValueWrapper(0.33, 0.33, 0.66, 0.66)
    sec3slowtimes = New ValueWrapper(0.33, 0.66, 1, 1) ' last one should be stun value somehow


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'slows
    Dim firstsecval As New modValue(sec1slowtimes, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    firstsecval.mValueDuration = New ValueWrapper(1, 1, 1, 1)

    Dim firstmod As New Modifier(firstsecval, unittargetenemy)
    outmods.Add(firstmod)


    Dim secondsecval As New modValue(sec2slowtimes, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    secondsecval.mValueDuration = firstsecval.mValueDuration

    Dim secondmod As New Modifier(secondsecval, unittargetenemy)
    outmods.Add(secondmod)


    Dim thirdsecval As New modValue(sec3slowtimes, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    thirdsecval.mValueDuration = secondsecval.mValueDuration

    Dim thirdmod As New Modifier(thirdsecval, unittargetenemy)
    outmods.Add(thirdmod)

    'damage over time
    Dim damval As New modValue(Damage, eModifierType.DamagePhysicaloT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = slowtime

    Dim dammod As New Modifier(damval, unittargetenemy)
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
