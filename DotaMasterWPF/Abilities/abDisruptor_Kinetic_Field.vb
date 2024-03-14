Public Class abKinetic_Field
Inherits AbilityBase

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

    mDisplayName = "Kinetic Field"
    mName = eAbilityName.abKinetic_Field
    Me.EntityName = eEntity.abKinetic_Field

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDisruptor

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/disruptor_kinetic_field_hp2.png"

    Description = "After a short formation time, creates a circular barrier of kinetic energy that enemies can't pass."


    ManaCost = New ValueWrapper(70, 70, 70, 70)

    Cooldown = New ValueWrapper(13, 12, 11, 10)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(2.5, 3, 3.5, 4)

    Radius = New ValueWrapper(325, 325, 325, 325)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointargetauraenemyunits = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "", eModifierCategory.Active)

    Dim barrierval As New modValue(1, eModifierType.Barrier, occurencetime)
    barrierval.mValueDuration = Duration

    Dim barmod As New Modifier(barrierval, pointargetauraenemyunits)
    outmods.Add(barmod)

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
