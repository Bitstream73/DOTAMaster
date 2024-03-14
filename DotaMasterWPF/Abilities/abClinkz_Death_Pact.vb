Public Class abDeath_Pact
Inherits AbilityBase
  Public healthgain As ValueWrapper
  Public damagegain As ValueWrapper
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
    mDisplayName = "Death Pact"
    mName = eAbilityName.abDeath_Pact

    Me.EntityName = eEntity.abDeath_Pact


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClinkz

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/clinkz_death_pact_hp2.png"

    Description = "Clinkz consumes the target friendly or enemy creep, gaining a percent of its hitpoints as max health and damage."

    ManaCost = New ValueWrapper(100, 100, 100)

    Cooldown = New ValueWrapper(45, 40, 35)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untCreep)

    Duration = New ValueWrapper(35, 35, 35)

    healthgain = New ValueWrapper(0.5, 0.65, 0.8)

    damagegain = New ValueWrapper(0.05, 0.065, 0.08)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim healthval As New modValue(healthgain, eModifierType.PercentofCreepHealthGained, occurencetime, aghstime)
    healthval.mValueDuration = Duration

    Dim healthmod As New Modifier(healthval, unittargetself)
    outmods.Add(healthmod)


    Dim damval As New modValue(damagegain, eModifierType.DamageAllTypesPercentAdded, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetself)
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
