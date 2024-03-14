Public Class abPrimal_Split
Inherits AbilityBase

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

    Notes = "Has a cast point of 0.65 second.|The split time is 0.6 seconds during which Brewmaster is invulnerable.|During Primal Split, Brewmaster is periodically moved to Earth's position. If Earth dies, to Storm's and if Storm dies, to Fire. This affects multiple things such as:|When Primal Split ends, Brewmaster will appear at the Earth's location. When Earth is dead, at Storm's and when Storm is dead, at Fire's location.|Every aura Brewmaster has (Including Gem of True Sight icon.png Gem of True Sight and Radiance icon.png Radiance) affects units around Earth, if Earth is dead, around Storm and if Storm is dead, around Fire.|Effects which react on heroes' presence, such as Smoke of Deceit icon.png Smoke of Deceit, Marksmanship icon.png Marksmanship or Blur icon.png Blur will react on Earth's presence, when Earth is dead, on Storm, when Storm is dead, on Fire's.|Teleporting effect like Test of Faith (Teleport) icon.png Test of Faith (Teleport) or Relocate icon.png Relocate causes the periodic moving of Brewmaster to get canceled, so that the 3 notes above don't apply anymore.|Primal Split does not change Brewmaster's hp and does not stop any regeneration. So Brewmaster will return with the hp and mana he had before the split + what he could regenerate during it.|Primal Split will not dispell buffs or debuffs.|The Storm, Earth and Fire spirits are treated like heroes by most spells. This means that they cannot be dominated or converted (Holy Persuasion icon.png Holy Persuasion, Hand of Midas icon.png Hand of Midas, Enchant icon.png Enchant will slow instead), buffs and debuffs last as long as they last on heroes and most heroes-only targeted spells can target them (eg Shallow Grave icon.png Shallow Grave.|The spirits also do not take summon bonus damage (eg Arcane Orb icon.png Arcane Orb, Diffusal Blade icon.png Diffusal Blade.|The spirits are affected by Enigma's Black Hole icon.png Black Hole." '"

mName = eAbilityName.abPrimal_Split
    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBrewmaster
    Me.EntityName = eEntity.abPrimal_Split

    mDisplayName = "Primal Split"
    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/brewmaster_primal_split_hp2.png"

    Description = "Splits Brewmaster into elements, forming 3 specialized warriors, adept at survival. If any of them survive until the end of their summoned timer, the Brewmaster is reborn. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(125, 150, 175)

    Cooldown = New ValueWrapper(140, 120, 100)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(15, 17, 19)


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



    Dim herogoneval As New modValue(Duration, eModifierType.ReplacedByPets, occurencetime, aghstime)
    herogoneval.mValueDuration = Duration

    Dim herogone As New Modifier(herogoneval, notargetself)
    outmods.Add(herogone)

    'earth
    'Dim earth As New HeroPet_Info


    'earth.hitpoints = New ValueWrapper(1500, 2250, 3000)


    'earth.mana = New ValueWrapper(400, 500, 600)

    'earth.armor = New ValueWrapper(5, 5, 5)

    'earth.armortype = eArmorType.Heavy

    'earth.movementspeed = New ValueWrapper(325, 325, 325)

    'earth.SightRange.Add(New ValueWrapper(1800, 1800, 1800))
    'earth.SightRange.Add(New ValueWrapper(800, 800, 800))


    'earth.bounty = New ValueWrapper(35, 35, 35)

    'earth.xpvalue = New ValueWrapper(196, 242, 242)

    'earth.notes = "Possesses Hurl Boulder, Spell Immunity, Pulverize, and Resistant Skin (Thunder Clap with Aghanim's Scepter)"


    Dim earthval As New modValue(1, eModifierType.petEarth_Brewmaster, occurencetime)
    ' earthval.mPet = earth
    earthval.mValueDuration = Duration


    Dim earthpet As New Modifier(earthval, notargetself)
    outmods.Add(earthpet)

    'storm
    'Dim storm As New HeroPet_Info

    'storm.hitpoints = New ValueWrapper(1000, 1500, 1900)


    'storm.mana = New ValueWrapper(500, 750, 750)

    'storm.armor = New ValueWrapper(2, 2, 2)

    'storm.armortype = eArmorType.Heavy

    'storm.movementspeed = New ValueWrapper(350, 350, 350)

    'storm.SightRange.Add(New ValueWrapper(1800, 1800, 1800))
    'storm.SightRange.Add(New ValueWrapper(800, 800, 800))

    'storm.MissileSpeed = 1200


    'storm.bounty = New ValueWrapper(15, 15, 35)

    'storm.xpvalue = New ValueWrapper(196, 242, 242)

    'storm.notes = "Possesses Dispel Magic, Cyclone, Wind Walk, and Resistant Skin (Drunken Haze with Aghanim's Scepter)"

    Dim stormval As New modValue(1, eModifierType.petStorm_Brewmaster, occurencetime)
    ' stormval.mPet = storm
    stormval.mValueDuration = Duration

    Dim stormpet As New Modifier(stormval, notargetself)
    outmods.Add(stormpet)

    'fire

    'Dim Fire As New HeroPet_Info


    'Fire.hitpoints = New ValueWrapper(1200, 1200, 1200)

    'Fire.armor = New ValueWrapper(0, 0, 0)

    'Fire.armortype = eArmorType.None

    'Fire.movementspeed = New ValueWrapper(522, 522, 522)

    'Fire.SightRange.Add(New ValueWrapper(1800, 1800, 1800))
    'Fire.SightRange.Add(New ValueWrapper(1800, 1800, 1800))


    'Fire.bounty = New ValueWrapper(35, 35, 35)


    'Fire.xpvalue = New ValueWrapper(196, 242, 242)

    'Fire.notes = "Possesses Permanent Immolation, and Resistant Skin (Drunken Brawler with Aghanim's Scepter)"

    Dim fireval As New modValue(1, eModifierType.petFire_Brewmaster, occurencetime)

    ' fireval.mPet = Fire
    fireval.mValueDuration = Duration

    Dim firepet As New Modifier(fireval, notargetself)
    outmods.Add(firepet)

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
