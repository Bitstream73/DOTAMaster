Public Class abBerserkers_Rage
Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public bonusmovespeed As ValueWrapper
  Public baseattacktime As ValueWrapper
  Public bonushp As ValueWrapper
  Public bonusarmor As ValueWrapper
  Public bashchance As ValueWrapper
  Public bashduration As ValueWrapper
  Public bashdamage As ValueWrapper
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

    mDisplayName = "Berserker's Rage"
    mName = eAbilityName.abBerserkers_Rage
    Me.EntityName = eEntity.abBerserkers_Rage

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTroll_Warlord

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/troll_warlord_berserkers_rage_hp2.png"

    Description = "Allows the Warlord to use his throwing axes as melee weapons, gaining bonus damage, attack speed, movement speed, hitpoints, armor, and a chance to bash targets on attack. Berserker's Rage also changes the functionality of Whirling Axes."



    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    bonusdamage = New ValueWrapper(15, 15, 15, 15)
    bonusmovespeed = New ValueWrapper(10, 20, 30, 40)
    baseattacktime = New ValueWrapper(1.55, 1.55, 1.55, 1.55)
    bonushp = New ValueWrapper(100, 100, 100, 100)
    bonusarmor = New ValueWrapper(3, 3, 3, 3)
    bashchance = New ValueWrapper(0.1, 0.1, 0.1, 0.1)
    bashduration = New ValueWrapper(0.8, 1.2, 1.6, 2)
    bashdamage = New ValueWrapper(20, 30, 40, 50)


End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim toggleself = Helpers.GetToggleSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    'bonus damage
    Dim bonval As New modValue(bonusdamage, eModifierType.RightClickBonusDamageAdded, occurencetime, aghstime)

    Dim bonmod As New Modifier(bonval, toggleself)
    outmods.Add(bonmod)

    'bonus movespeed
    Dim moveval As New modValue(bonusmovespeed, eModifierType.MoveSpeedAdded, occurencetime, aghstime)

    Dim movemod As New Modifier(moveval, toggleself)
    outmods.Add(movemod)

    'base attack time
    Dim baseval As New modValue(baseattacktime, eModifierType.BaseAttackTimeChangedTo, occurencetime, aghstime)

    Dim basemod As New Modifier(baseval, toggleself)
    outmods.Add(basemod)

    'bonus hp
    Dim hpval As New modValue(bonushp, eModifierType.HPAdded, occurencetime, aghstime)

    Dim hpmod As New Modifier(hpval, toggleself)
    outmods.Add(hpmod)

    'bonusarmor
    Dim armval As New modValue(bonusarmor, eModifierType.ArmorAdded, occurencetime, aghstime)

    Dim armmod As New Modifier(armval, toggleself)
    outmods.Add(armmod)

    'bash damage
    Dim bashval As New modValue(bashdamage, eModifierType.Bash, occurencetime, aghstime)
    bashval.mPercentChance = bashchance
    bashval.mValueDuration = bashduration

    Dim bashmod As New Modifier(bashval, unittargetenemy)
    outmods.Add(bashmod)


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
