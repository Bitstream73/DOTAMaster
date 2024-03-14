Public Class abTombstone
Inherits AbilityBase
  Public thealth As ValueWrapper
  Public tduration As ValueWrapper
  Public zspawnradius As ValueWrapper
  Public deathlustflatThreshold As ValueWrapper
  Public deathlustpctthreshold As ValueWrapper
  Public zspawninterval As ValueWrapper
  Public zcountperunit As ValueWrapper
  Public tombstonecount As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Tombstone"
    mName = eAbilityName.abTombstone
    Me.EntityName = eEntity.abTombstone

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUndying

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/undying_tombstone_hp2.png"

    Description = "Summons a tombstone at the target point. Zombies will frequently spawn next to every enemy unit in the area around the Tombstone, and attack them. Zombies have the Deathlust ability, which causes their attacks to slow the target, and if the target reaches below a certain amount of health, increases the attack and movement speed of the zombie."

    ManaCost = New ValueWrapper(120, 130, 140, 150)

    Cooldown = New ValueWrapper(60, 60, 60, 60)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)


    Duration = New ValueWrapper(30, 25, 20, 15)

    Radius = New ValueWrapper(1000, 800, 600, 400)

    thealth = New ValueWrapper(200, 400, 600, 800)

    tduration = New ValueWrapper(15, 20, 25, 30)

    zspawnradius = New ValueWrapper(600, 800, 100, 1200)

    deathlustflatThreshold = New ValueWrapper(100, 200, 300, 400)

    deathlustpctthreshold = New ValueWrapper(0.2, 0.25, 0.3, 0.35)

    zspawninterval = New ValueWrapper(3, 3, 3, 3)

    Dim count1 As Integer = tduration.Value(0) / zspawninterval.Value(0)
    Dim count2 As Integer = tduration.Value(1) / zspawninterval.Value(1)
    Dim count3 As Integer = tduration.Value(2) / zspawninterval.Value(2)

    zcountperunit = New ValueWrapper(count1, count2, count3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetaura = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    'tombstone
    'Dim tombstone As New HeroPet_Info()
    'tombstone.hitpoints = New ValueWrapper(200, 400, 600, 800)

    'tombstone.SightRange.Add(New ValueWrapper(1800, 1800, 1800, 1800))
    'tombstone.SightRange.Add(New ValueWrapper(1800, 1800, 1800, 1800))

    'tombstone.bounty = New ValueWrapper(75, 100, 125, 150)

    Dim tombval As New modValue(tombstonecount, eModifierType.petTombstone, occurencetime, aghstime)
    '    tombval.mPet = tombstone
    tombval.mValueDuration = Duration

    Dim tombmod As New Modifier(tombval, pointtargetself)
    outmods.Add(tombmod)


    'zombies
    'Dim zom As New HeroPet_Info()
    'zom.hitpoints = New ValueWrapper(30, 30, 30, 30)
    'zom.HealthRegen = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    'zom.DamageHigh = New ValueWrapper(37, 37, 37, 37)
    'zom.DamageLow = New ValueWrapper(45, 45, 45, 45)

    'zom.armor = New ValueWrapper(0, 0, 0, 0)

    'zom.movementspeed = New ValueWrapper(375, 375, 375, 375)

    'zom.SightRange.Add(New ValueWrapper(1400, 1400, 1400, 1400))
    'zom.SightRange.Add(New ValueWrapper(1400, 1400, 1400, 1400))

    'zom.BaseAttackSpeed = New ValueWrapper(1.6, 1.6, 1.6, 1.6)

    'zom.bounty = New ValueWrapper(0, 0, 0, 0)

    'zom.xpvalue = New ValueWrapper(0, 0, 0, 0)


    Dim zval As New modValue(zcountperunit, eModifierType.petUndying_Zombie, occurencetime, aghstime)
    zval.mValueDuration = Duration
    '   zval.mPet = zom


    Dim zmod As New Modifier(zval, pointtargetaura)
    outmods.Add(zmod)


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
