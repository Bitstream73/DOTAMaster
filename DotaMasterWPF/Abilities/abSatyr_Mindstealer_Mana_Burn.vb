Public Class abSatyr_Mindstealer_Mana_Burn
  Inherits AbilityBase

  Public manaburned As ValueWrapper

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
    mName = eAbilityName.abSatyr_Mindstealer_Mana_Burn
    Me.EntityName = eEntity.abSatyr_Mindstealer_Mana_Burn

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSatyr_Mindstealer

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '  mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/cc/Mana_Burn_%28Satyr_Mindstealer%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Satyr_Camp"
    Description = "The Satyr Mindstealer removes a fragment of his enemy's soul, burning away some mana and dealing damage equal to the amount of mana burned."
    Notes = "Applies the damage first, and then the mana loss.|Can be cast on units with no mana pool with no effect, wasting the mana and cooldown.|As a neutral unit: The satyr never casts this spell.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(50)

    Cooldown = New ValueWrapper(18)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untDyingEnemyTarget)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    manaburned = New ValueWrapper(100)
    Damage = manaburned
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

    Dim manaval As New modValue(manaburned, eModifierType.ManaDrained, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, targetenemy)
    outmods.Add(manamod)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

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
