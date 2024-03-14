Public Class abHealing_Ward
Inherits AbilityBase
  Public maxhppersec As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The heal comes from an Aura.|Unlike most other auras, the buff lingers for 2.47 seconds.|The heal is hp regeneration, so it heals for 0.2% / 0.3% / 0.4% / 0.5% of maximum hp in 0.1 second intervals.|Heals a total of 54.94% / 82.41% / 109.88% / 137.35% of a unit's maximum health (25 duration + 2,47 seconds lingering buff).|The healing aura of multiple Healing Wards don't stack.|Despite the visual effects, does not provide the healing aura anymore when it dies or expires.|Does not heal siege creeps." '"


    mDisplayName = "Healing Ward"
    mName = eAbilityName.abHealing_Ward
    Me.EntityName = eEntity.abHealing_Ward

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJuggernaut

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/juggernaut_healing_ward_hp2.png"

    Description = "Summons a Healing Ward that heals all nearby allied units, based on their max hit points. The Healing Ward can move at 450 movement speed after being summoned. Lasts 25 seconds."

    ManaCost = New ValueWrapper(80, 100, 120, 140)

    Cooldown = New ValueWrapper(60, 60, 60, 60)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)


    maxhppersec = New ValueWrapper(0.02, 0.03, 0.04, 0.05)

    Duration = New ValueWrapper(25, 25, 25, 25)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim pointtargetauraallies = Helpers.GetPointTargetAuraAlliedUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim theheal As New modValue(maxhppersec, eModifierType.HealAsPercentofHP, occurencetime, aghstime)
    theheal.mValueDuration = Duration

    Dim heal As New Modifier(theheal, pointtargetauraallies)
    outmods.Add(heal)

    'need to eventually have pet powers in there healing instead of as seperate and coming from Jugg
    'Dim healingward As New HeroPet_Info
    'healingward.hitpoints = New ValueWrapper(1, 1, 1, 1)
    'healingward.Duration = mDuration

    'healingward.armor = New ValueWrapper(0, 0, 0, 0)
    'healingward.armortype = eArmorType.None

    'healingward.movementspeed = New ValueWrapper(450, 450, 450, 450)

    'healingward.SightRange.Add(New ValueWrapper(500, 500, 500, 500))
    'healingward.SightRange.Add(New ValueWrapper(500, 500, 500, 500))

    'healingward.bounty = New ValueWrapper(0, 0, 0, 0)

    'healingward.xpvalue = New ValueWrapper(0, 0, 0, 0)

    Dim petval As New modValue(1, eModifierType.petHealing_Ward, occurencetime)
    ' petval.mPet = healingward
    petval.mValueDuration = Duration

    Dim theward As New Modifier(petval, pointtargetauraallies)
    outmods.Add(theward)


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
