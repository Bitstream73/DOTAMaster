Public Class abPlague_Ward_Poison_Sting
  Inherits AbilityBase


  Public dps As ValueWrapper
  Public moveslow As ValueWrapper
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

    mDisplayName = "Poison Sting"
    mName = eAbilityName.abPlague_Ward_Poison_Sting
    Me.EntityName = eEntity.abPoison_Sting

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPlague_Ward

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/69/Poison_Sting_icon.png?version=759ef1e61dbda1779232566942bc44ed"
    WebpageLink = "http://dota2.gamepedia.com/Venomancer#Plague_Ward"
    Description = "Adds poison damage to the Plague Ward's normal attacks, slowing movement speed."
    Notes = "Poison Sting is not a unique attack modifier.|The damage from Poison Sting does not trigger any on-damage effects. This means that the following spells and items will not react on Poison Sting damage: Aphotic Shield, Backtrack, Blade Mail, Blink Dagger, Bottle, Bristleback, Clarity, Cold Snap, Corrosive Skin, Echo Stomp, Fatal Bonds, Healing Salve, Heart of Tarrasque, Kraken Shell, Living Armor, Mana Shield, Mjollnir, Nightmare, Open Wounds, Orchid Malevolence, Recall, Refraction, Return, Soul Assumption, Spiked Carapace, Spin Web, Summon Spirit Bear and Urn of Shadows.|The damage ticks in 1 second intervals, starting immediately when the debuff is placed, resulting in 7/10/13/16 damage ticks.|Can deal up to 35/100/195/320 damage (before reductions)."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    'mAffects.Add(eUnit)

    Duration = New ValueWrapper(6, 9, 12, 15)

    dps = New ValueWrapper(5, 10, 15, 20)
    moveslow = New ValueWrapper(0.11, 0.12, 0.13, 0.14)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim targetenemy = Helpers.GetPassiveEnemyTargetInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, targetenemy)
    outmods.Add(dammod)

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, targetenemy)
    outmods.Add(movemod)


    Return outmods
  End Function
End Class
