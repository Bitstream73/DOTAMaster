Public Class abBattery_Assault
Inherits AbilityBase
  Public damageinterval As ValueWrapper
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
    mDisplayName = "Battery Assault"
    mName = eAbilityName.abBattery_Assault
    Me.EntityName = eEntity.abBattery_Assault


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClockwerk

    mAbilityPosition = 1

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rattletrap_battery_assault_hp2.png"

    Description = "Discharges high-powered shrapnel at random nearby enemy units, dealing minor magical damage and ministun."

    ManaCost = New ValueWrapper(75, 75, 75, 75)


    Cooldown = New ValueWrapper(32, 28, 24, 20)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untRandomEnemyUnit)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(15, 35, 55, 75)

    Duration = New ValueWrapper(10.5, 10.5, 10.5, 10.5)

    Radius = New ValueWrapper(275, 275, 275, 275)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetrandomenemy = Helpers.GetNoTargetRandomEnemyUnitInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, damageinterval, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, notargetrandomenemy)
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
