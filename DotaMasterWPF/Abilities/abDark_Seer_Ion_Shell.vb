Public Class abIon_Shell
Inherits AbilityBase
  Public damageot As ValueWrapper
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

    mDisplayName = "Ion Shell"
    mName = eAbilityName.abIon_Shell
    Me.EntityName = eEntity.abIon_Shell

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDark_Seer

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dark_seer_ion_shell_hp2.png"

    Description = "Surrounds the target unit with a bristling shield that damages enemy units in an area around it."


    ManaCost = New ValueWrapper(70, 90, 110, 130)


    Cooldown = New ValueWrapper(9, 9, 9, 9)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(20, 20, 20, 20)

    Radius = New ValueWrapper(250, 250, 250, 250)

    damageot = New ValueWrapper(30, 50, 70, 90)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetauraenemyunits = Helpers.GetUnitTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    Dim damval As New modValue(damageot, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration
    damval.mRadius = Radius


    Dim dammod As New Modifier(damval, unittargetauraenemyunits)

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
