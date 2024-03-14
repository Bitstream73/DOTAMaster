Public Class abLvl_Death
Inherits AbilityBase
  Public herolevelmultiplier As ValueWrapper
  Public ministunduration As ValueWrapper
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

    mDisplayName = "Lvl? Death"
    mName = eAbilityName.abLvl_Death
    Me.EntityName = eEntity.abLvl_Death

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDoom

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/doom_bringer_lvl_death_hp2.png"

    Description = "Dissipates a piece of an enemy Hero's soul, mini-stunning and dealing bonus damage equal to 20% of the target's maximum health when the enemy's level is a multiple of a specific number or 25."

    ManaCost = New ValueWrapper(110, 110, 110, 110)


    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyHero)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(125, 175, 225, 275)


    herolevelmultiplier = New ValueWrapper(6, 5, 4, 3)

    ministunduration = New ValueWrapper(0.1, 0.1, 0.1, 0.1)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemytarget)
    outmods.Add(dammod)



    Dim stunval As New modValue(ministunduration, eModifierType.MiniStun, occurencetime, aghstime)

    Dim stunmod As New Modifier(stunval, unittargetenemytarget)
    outmods.Add(stunmod)


    Dim lvlval As New modValue(1, eModifierType.LvlDeathDamageMagicalInflicted, occurencetime)

    Dim lvlmod As New Modifier(lvlval, unittargetenemytarget)
    outmods.Add(lvlmod)
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
