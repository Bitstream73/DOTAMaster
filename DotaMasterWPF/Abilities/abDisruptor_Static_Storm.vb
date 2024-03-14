Public Class abStatic_Storm
Inherits AbilityBase
  Public stormdam1 As New List(Of Double?)
  Public stormdam2 As New List(Of Double?)
  Public stormdam3 As New List(Of Double?)

  Public scepterduration As New List(Of Double?)

  Public pulses As ValueWrapper
  Public scepterpulses As New List(Of Double?)

  Public maxdampersec As ValueWrapper

  Public pulseinterval As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Static Storm"
    mName = eAbilityName.abStatic_Storm
    Me.EntityName = eEntity.abStatic_Storm

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDisruptor

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/disruptor_static_storm_hp2.png"

    Description = "Creates a damaging static storm that also silences all enemy units in the area for the duration. The damage starts off weak, but increases in power over the duration. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(125, 175, 225)


    Cooldown = New ValueWrapper(90, 80, 70)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(5, 5, 5)
    scepterduration.Add(7)
    scepterduration.Add(7)
    scepterduration.Add(7)
    Duration.LoadScepterValues(scepterduration)


    Radius = New ValueWrapper(450, 450, 450)


    pulses = New ValueWrapper(20, 20, 20)
    scepterpulses.Add(28)
    scepterpulses.Add(28)
    scepterpulses.Add(28)
    pulses.LoadScepterValues(scepterpulses)

    pulseinterval = New ValueWrapper(0.25, 0.25, 0.25)

    stormdam1.Add(2)
    stormdam1.Add(5)
    stormdam1.Add(7)
    stormdam1.Add(10)
    stormdam1.Add(12)
    stormdam1.Add(15)
    stormdam1.Add(17)
    stormdam1.Add(20)
    stormdam1.Add(22)
    stormdam1.Add(25)
    stormdam1.Add(27)
    stormdam1.Add(30)
    stormdam1.Add(32)
    stormdam1.Add(35)
    stormdam1.Add(37)
    stormdam1.Add(40)
    stormdam1.Add(42)
    stormdam1.Add(45)
    stormdam1.Add(47)
    stormdam1.Add(50)
    stormdam1.Add(52)
    stormdam1.Add(55)
    stormdam1.Add(57)
    stormdam1.Add(60)
    stormdam1.Add(62)
    stormdam1.Add(65)
    stormdam1.Add(67)
    stormdam1.Add(70)

    stormdam2.Add(3)
    stormdam2.Add(6)
    stormdam2.Add(9)
    stormdam2.Add(12)
    stormdam2.Add(15)
    stormdam2.Add(18)
    stormdam2.Add(21)
    stormdam2.Add(25)
    stormdam2.Add(28)
    stormdam2.Add(31)
    stormdam2.Add(34)
    stormdam2.Add(37)
    stormdam2.Add(40)
    stormdam2.Add(43)
    stormdam2.Add(46)
    stormdam2.Add(50)
    stormdam2.Add(53)
    stormdam2.Add(56)
    stormdam2.Add(59)
    stormdam2.Add(62)
    stormdam2.Add(65)
    stormdam2.Add(68)
    stormdam2.Add(71)
    stormdam2.Add(75)
    stormdam2.Add(78)
    stormdam2.Add(81)
    stormdam2.Add(84)
    stormdam2.Add(87)

    stormdam3.Add(3)
    stormdam3.Add(7)
    stormdam3.Add(11)
    stormdam3.Add(15)
    stormdam3.Add(18)
    stormdam3.Add(22)
    stormdam3.Add(26)
    stormdam3.Add(30)
    stormdam3.Add(33)
    stormdam3.Add(37)
    stormdam3.Add(41)
    stormdam3.Add(45)
    stormdam3.Add(48)
    stormdam3.Add(52)
    stormdam3.Add(56)
    stormdam3.Add(60)
    stormdam3.Add(63)
    stormdam3.Add(67)
    stormdam3.Add(71)
    stormdam3.Add(75)
    stormdam3.Add(78)
    stormdam3.Add(82)
    stormdam3.Add(86)
    stormdam3.Add(90)
    stormdam3.Add(93)
    stormdam3.Add(97)
    stormdam3.Add(101)
    stormdam3.Add(105)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetauraenemyunits = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(1, eModifierType.StaticStormDamageMagicalInflicted, occurencetime)
    damval.mValueDuration = Duration
    damval.Charges = pulses


    Dim dammod As New Modifier(damval, pointtargetauraenemyunits)
    outmods.Add(dammod)


    Dim silenceval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    silenceval.mValueDuration = Duration

    Dim silencemod As New Modifier(silenceval, pointtargetauraenemyunits)
    outmods.Add(silencemod)

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
