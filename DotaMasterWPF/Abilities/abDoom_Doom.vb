Public Class abDoom
Inherits AbilityBase

  Public damagepersec As ValueWrapper
  Public scepterduration As New List(Of Double?)
  Public scepterDamagePerSec As New List(Of Double?)
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

    mDisplayName = "Doom"
    mName = eAbilityName.abDoom
    Me.EntityName = eEntity.abDoom

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDoom

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/doom_bringer_doom_hp2.png"

    Description = "Inflicts a curse that prevents an enemy Hero from casting spells or using items, while taking damage over time. Doom also disables most passive abilities and removes positive buffs on cast. Upgradable by Aghanim's Scepter."

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure


    ManaCost = New ValueWrapper(150, 200, 250)

    Cooldown = New ValueWrapper(100, 100, 100)

    Duration = New ValueWrapper(15, 15, 15)
    scepterduration.Add(16)
    scepterduration.Add(16)
    scepterduration.Add(16)
    Duration.LoadScepterValues(scepterduration)

    damagepersec = New ValueWrapper(20, 35, 50)
    scepterDamagePerSec.Add(40)
    scepterDamagePerSec.Add(60)
    scepterDamagePerSec.Add(80)
    damagepersec.LoadScepterValues(scepterDamagePerSec)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyhero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    'item and spell mte
    Dim spellmuteval As New modValue(Duration, eModifierType.MuteAbilities, occurencetime, aghstime)

    spellmuteval.mValueDuration = Duration

    Dim spellmod As New Modifier(spellmuteval, unittargetenemyhero)
    outmods.Add(spellmod)

    Dim itemmuteval As New modValue(Duration, eModifierType.MuteItems, occurencetime, aghstime)
    itemmuteval.mValueDuration = Duration

    Dim itemmod As New Modifier(itemmuteval, unittargetenemyhero)
    outmods.Add(itemmod)

    'dps
    Dim dpsval As New modValue(damagepersec, eModifierType.DamagePureInflicted, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    dpsval.mValueDuration = Duration

    Dim dpsmod As New Modifier(dpsval, unittargetenemyhero)
    outmods.Add(dpsmod)
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
