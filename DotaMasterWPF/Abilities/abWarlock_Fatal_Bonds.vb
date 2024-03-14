Public Class abFatal_Bonds
Inherits AbilityBase
  Public enemiesbound As ValueWrapper
  Public percdamageshared As ValueWrapper
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

    mDisplayName = "Fatal Bonds"
    mName = eAbilityName.abFatal_Bonds
    Me.EntityName = eEntity.abFatal_Bonds

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWarlock

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/warlock_fatal_bonds_hp2.png"

    Description = "Binds several enemy units together, causing 20% of the damage dealt to one of them to be felt by the others."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(25, 25, 25, 25)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    Duration = New ValueWrapper(25, 25, 25, 25)

    enemiesbound = New ValueWrapper(3, 4, 5, 6)

    percdamageshared = New ValueWrapper(0.25, 0.25, 0.25, 0.25)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyTargetsFixedCountInfo(theability_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "", eModifierCategory.Active)

    Dim damval As New modValue(enemiesbound, eModifierType.HPRemovalSharedWithBoundUnits, occurencetime, aghstime)
    damval.Charges = enemiesbound

    Dim dammod As New Modifier(damval, unittargetenemies)
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
