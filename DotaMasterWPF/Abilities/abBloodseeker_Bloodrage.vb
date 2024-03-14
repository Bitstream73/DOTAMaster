Public Class abBloodrage
  Inherits AbilityBase

  Public damageincrease As ValueWrapper
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
    mDisplayName = "Bloodrage"
    mName = eAbilityName.abBloodrage
    Me.EntityName = eEntity.abBloodrage

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBloodseeker

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bloodseeker_bloodrage_hp2.png"

    Description = "Drives a unit into a bloodthirsty rage, during which it has higher attack damage, but cannot cast spells and takes damage every second. Bloodrage dispels the target before applying its buff."

    Notes = "Bloodrage has a cast time of 0.2 seconds.|Bloodrage amplifies all three damage types the bloodraged unit deals and takes.|Amplifies for half the value when the dealer and receiver are 2200 range apart from each other.|Does not amplify outgoing damage when it has the no-reflection flag (e.g. damage from Blade Mail, Spiked Carapace, Fatal Bonds).|Bloodrage can be cast on enemy and allied units, as well as Bloodseeker himself.|Bloodrage does not give healing if a unit kills Roshan.|Since the cooldown is shorter than the duration, it's possible to have two units bloodraged at a time.|When a bloodraged unit attacks another bloodraged unit, the damage is overall amplified by 96% (1.4*1.4=1.96).|Does not amplify damage dealt by abilities that use an independent source of damage (e.g. Land Mines, Death Ward)."



    Cooldown = New ValueWrapper(12, 10, 8, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    DamageType = eDamageType.Magical

    damageincrease = New ValueWrapper(0.25, 0.3, 0.35, 0.4)

    Duration = New ValueWrapper(9, 10, 11, 12)
  End Sub




  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList
    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untEnemyHero)
    theaffects.Add(eUnit.untSelf)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active, theaffects)


    Dim selfdam As New modValue(damageincrease, eModifierType.DamageAllTypesIncomingIncreasesPercent, occurencetime, aghstime)
    selfdam.mValueDuration = Duration

    Dim selfmod As New Modifier(selfdam, unittargetmulti)
    outmods.Add(selfmod)

    Dim outdam As New modValue(damageincrease, eModifierType.DamageAllTypesPercentAdded, occurencetime, aghstime)
    outdam.mValueDuration = Duration

    Dim outmod As New Modifier(outdam, unittargetmulti)
    outmods.Add(outmod)

    'no mods for 25% heal. Not sure needed
    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
