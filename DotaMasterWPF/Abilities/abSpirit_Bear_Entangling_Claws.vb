Public Class abSpirit_Bear_Entangling_Claws
  Inherits AbilityBase


  Public procchance As ValueWrapper
  Public dps As ValueWrapper
  Public heroduration As ValueWrapper
  Public creepduration As ValueWrapper

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

    mDisplayName = "Entangling Claws"
    mName = eAbilityName.abSpirit_Bear_Entangling_Claws
    Me.EntityName = eEntity.abSpirit_Bear_Entangling_Claws

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Bear

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/1/1f/Entangling_Claws_%28Spirit_Bear%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Spirit_Bear#Spirit_Bear"
    Description = "Attacks have a chance to cause roots to burst from the ground, immobilizing the attacked enemy unit, and dealing damage per second."
    Notes = "Entangling Claws requires Summon Spirit Bear level 3 to be unlocked.|Despite the name, Entangling Claws root its target, so affected targets can still attack.|Disables the following spells: Queen of Pain Blink, Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger.|Interrupts channeling spells of the target upon ensnaring, but affected units can channel spells during it.|Entangling Claws reveal invisible affected targets for its duration.|Entangling Claws is not a Unique Attack Modifier."

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(5)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    procchance = New ValueWrapper(0.2)
    dps = New ValueWrapper(60)
    heroduration = New ValueWrapper(3)
    creepduration = New ValueWrapper(9)

    DamageType = eDamageType.Physical
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

    Dim targetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)


    Dim targethero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)

    Dim targetcreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)


    Dim damval As New modValue(dps, eModifierType.RightClickDamageInflicted, occurencetime, aghstime)
    damval.mPercentChance = procchance

    Dim dammod As New Modifier(damval, targetenemy)
    outmods.Add(dammod)


    Dim hsnareval As New modValue(heroduration, eModifierType.MuteMove, occurencetime, aghstime)
    hsnareval.mPercentChance = procchance

    Dim hsnaremod As New Modifier(hsnareval, targethero)
    outmods.Add(hsnaremod)


    Dim csnareval As New modValue(creepduration, eModifierType.MuteMove, occurencetime, aghstime)
    csnareval.mPercentChance = procchance

    Dim csnaremod As New Modifier(csnareval, targetcreep)
    outmods.Add(csnaremod)

    Return outmods

  End Function
End Class
