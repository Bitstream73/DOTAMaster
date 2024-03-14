Public Class abNecro_Archer_Mana_Burn
  Inherits AbilityBase

  Public manaburned As ValueWrapper
  Public manaasdamage As ValueWrapper

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

    mDisplayName = "Mana Burn"
    mName = eAbilityName.abNecro_Archer_Mana_Burn
    Me.EntityName = eEntity.abNecro_Archer_Mana_Burn

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecro_Archer

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/a/a2/Mana_Burn_%28Necronomicon_Archer%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Necronomicon#Necronomicon_Archer"
    Description = "Burns targeted unit's mana"
    Notes = "This ability has no legacy hotkey currently.|Applies the damage first, and then the mana loss.|Can be cast on units without mana with no effect, wasting the mana and cooldown.|Despite the visual effects, the effects are applied instantly."

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(20, 20, 20)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyTarget)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    Range = New ValueWrapper(600, 600, 600)
    manaburned = New ValueWrapper(125, 175, 225)
    manaasdamage = New ValueWrapper(125, 175, 225)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim targetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim manaval As New modValue(manaburned, eModifierType.ManaBurnManaremoved, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, targetenemy)
    outmods.Add(manamod)


    Dim damval As New modValue(manaasdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, targetenemy)
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
