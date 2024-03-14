Public Class abChaotic_Offering
Inherits AbilityBase
  Public gHP As ValueWrapper
  Public scghp As New List(Of Double?)

  Public gdamage As ValueWrapper
  Public scgdamage As New List(Of Double?)

  Public garmor As ValueWrapper
  Public gcount As ValueWrapper
  Public scgcount As New List(Of Double?)

  Public gbounty As ValueWrapper
  Public scgbounty As New List(Of Double?)

  Public stunduration As ValueWrapper
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

    mDisplayName = "Chaotic Offering"
    mName = eAbilityName.abChaotic_Offering
    Me.EntityName = eEntity.abChaotic_Offering

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWarlock

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/warlock_rain_of_chaos_hp2.png"

    Description = "Summons a Golem from the depths, stunning enemies for one second. The Golem lives 60 seconds, takes reduced damage from spells, has Permanent Immolation and Flaming Fists on attack. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 300, 400)

    Cooldown = New ValueWrapper(165, 165, 165)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(600, 600, 600)

    Duration = New ValueWrapper(60, 60, 60)

    stunduration = New ValueWrapper(1, 1, 1)

    gHP = New ValueWrapper(900, 1200, 1500)
    scghp.Add(675)
    scghp.Add(900)
    scghp.Add(1125)
    gHP.LoadScepterValues(scghp)

    gdamage = New ValueWrapper(75, 100, 125)
    scgdamage.Add(56)
    scgdamage.Add(75)
    scgdamage.Add(94)
    gdamage.LoadScepterValues(scgdamage)

    garmor = New ValueWrapper(6, 9, 12)

    gcount = New ValueWrapper(1, 1, 1)
    scgcount.Add(2)
    scgcount.Add(2)
    scgcount.Add(2)
    gcount.LoadScepterValues(scgcount)

    gbounty = New ValueWrapper(100, 150, 200)
    scgbounty.Add(gbounty.Value(0) / 2)
    scgbounty.Add(gbounty.Value(1) / 2)
    scgbounty.Add(gbounty.Value(2) / 2)
    gbounty.LoadScepterValues(scgbounty)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim pointtargetenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim STUNVAL As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    STUNVAL.mValueDuration = stunduration

    Dim stunmod As New Modifier(STUNVAL, pointtargetenemies)
    outmods.Add(stunmod)


    'Dim golem As New HeroPet_Info
    'golem.Duration = mDuration
    'golem.hitpoints = gHP

    'golem.HealthRegen = New ValueWrapper(15, 30, 45)

    'golem.DamageHigh = gdamage
    'golem.DamageLow = gdamage

    'golem.armor = garmor

    'golem.movementspeed = New ValueWrapper(320, 340, 360)

    'golem.SightRange.Add(New ValueWrapper(1800, 1800, 1800))
    'golem.SightRange.Add(New ValueWrapper(1800, 1800, 1800))

    'golem.BaseAttackSpeed = New ValueWrapper(1.2, 1.2, 1.2)

    'golem.bounty = gbounty

    'golem.xpvalue = New ValueWrapper(98, 98, 98)

    Dim gval As New modValue(gcount, eModifierType.petGolem_Warlock, occurencetime, aghstime)
    gval.mValueDuration = Duration
    'gval.mPet = golem

    Dim gmod As New Modifier(gval, pointtargetself)
    outmods.Add(gmod)

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
