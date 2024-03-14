Public Class abVhoul_Assassin_Envenomed_Weapon
  Inherits AbilityBase


  Public dps As ValueWrapper
  Public heroduration As ValueWrapper
  Public nonheroduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mName = eAbilityName.abVhoul_Assassin_Envenomed_Weapon
    Me.EntityName = eEntity.abVhoul_Assassin_Envenomed_Weapon

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVhoul_Assassin

    mDisplayName = "Envenomed Weapon"
    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/1/1f/Envenomed_Weapon_%28Vhoul_Assassin%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Vhoul"
    Description = "The Vhoul Assassin has soaked his weapons in his own blend of painful predator venoms. Heroes recover from the poison more quickly."
    Notes = "The debuff from multiple Vhoul Assassins' successive attacks don't stack, only the duration gets refreshed.|Deals damage in 1 second intervals, starting 1 second after the debuff is placed, resutling in 10 instances.|Can deal up to 20 (40 to non-heroes) damage (before reductions).|The damage from Envenomed Weapon does not trigger any on-damage effects. This means that the following spells and items will not react on Poison Sting damage: Aphotic Shield, Backtrack, Aegis of the Immortal, Blade Mail, Blink Dagger, Bottle, Bristleback, Clarity, Cold Snap, Corrosive Skin, Echo Stomp, Fatal Bonds, Healing Salve, Heart of Tarrasque, Kraken Shell, Living Armor, Mana Shield, Mjollnir, Nightmare, Open Wounds, Orchid Malevolence, Recall, Refraction, Return, Rune of Regeneration, Soul Assumption, Spiked Carapace, Spin Web, Summon Spirit Bear and Urn of Shadows."

    ' mManaCost = New ValueWrapper()

    ' mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    dps = New ValueWrapper(2)
    heroduration = New ValueWrapper(10)
    nonheroduration = New ValueWrapper(20)

    DamageType = eDamageType.Magical
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

    Dim enemytarget = Helpers.GetPassiveEnemyTargetInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)

    Dim herodpsval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1), occurencetime, aghstime)
    herodpsval.mValueDuration = heroduration


    Dim herodammod As New Modifier(herodpsval, enemytarget)
    outmods.Add(herodammod)



    Dim creepdpsval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1), occurencetime, aghstime)
    creepdpsval.mValueDuration = nonheroduration

    Dim creepdpsmod As New Modifier(creepdpsval, enemytarget)
    outmods.Add(creepdpsmod)


    Return outmods
  End Function
End Class
