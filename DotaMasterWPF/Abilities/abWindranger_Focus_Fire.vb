Public Class abFocus_Fire
Inherits AbilityBase
  Public damagereduction As ValueWrapper
  Public scdamagereduction As New List(Of Double?)

  Public sccooldown As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Focus Fire"
    mName = eAbilityName.abFocus_Fire
    Me.EntityName = eEntity.abFocus_Fire

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWindranger

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/windrunner_focusfire_hp2.png"

    Description = "Windranger channels the wind, gaining maximum attack speed on the enemy unit or structure, although with reduced damage, including damage from Unique Attack Modifiers and item effects. Lasts 20 seconds. Upgradable with Aghanim's Scepter."

    ManaCost = New ValueWrapper(75, 100, 125)

    Cooldown = New ValueWrapper(60, 60, 60)
    sccooldown.Add(15)
    sccooldown.Add(15)
    sccooldown.Add(15)
    Cooldown.LoadScepterValues(sccooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    damagereduction = New ValueWrapper(0.5, 0.4, 0.3)
    scdamagereduction.Add(0.3)
    scdamagereduction.Add(0.15)
    scdamagereduction.Add(0)
    damagereduction.LoadScepterValues(scdamagereduction)

    Duration = New ValueWrapper(20, 20, 20)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)


    'damagereduction
    Dim redval As New modValue(damagereduction, eModifierType.BaseandBonusDamageReduction, occurencetime, aghstime)
    redval.mValueDuration = Duration

    Dim redmod As New Modifier(redval, unittargetself)
    outmods.Add(redmod)


    'attspeed
    Dim speedval As New modValue(Constants.cMaxAttackSpeed, eModifierType.AttackSpeedMaxed, occurencetime)
    speedval.mValueDuration = Duration

    Dim speedmod As New Modifier(speedval, unittargetself)
    outmods.Add(speedmod)


    'damage
    Dim damval As New modValue(Duration, eModifierType.RightClickDamageInflicted, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetenemy)
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
