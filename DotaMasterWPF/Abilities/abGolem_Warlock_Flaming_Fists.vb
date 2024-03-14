Public Class abGolem_Warlock_Flaming_Fists
  Inherits AbilityBase

  Public procchance As ValueWrapper

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

    mDisplayName = "Flaming Fists"
    mName = eAbilityName.abGolem_Warlock_Flaming_Fists
    Me.EntityName = eEntity.abGolem_Warlock_Flaming_Fists

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGolem_Warlock

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/03/Flaming_Fists_%28Warlock%27s_Golem%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Warlock#Warlock.27s_Golem"
    Description = "Grants a chance to deal extra damage to nearby units when attacking."
    Notes = "Occurs when the golem attacks an enemy.|Does not trigger on buildings and wards.|Does not damage ethereal units.|The radius is centered around the attacked target.|The damage hits the attack target aswell, not only nearby units."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untEnemyUnits)


    Radius = New ValueWrapper(300, 300, 300)
    Damage = New ValueWrapper(80, 115, 150)
    procchance = New ValueWrapper(0.4, 0.4, 0.4)
    DamageType = eDamageType.Pure
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetPassiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.RightClickPureDamageInflicted, occurencetime, aghstime)
    damval.mPercentChance = procchance

    Dim dammod As New Modifier(damval, auraenemies)
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
