Public Class abAcid_Spray
Inherits AbilityBase
  Private damageovertime As ValueWrapper
  Private armorreduction As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix


    Notes = "" 'FixFixFix"

    mName = eAbilityName.abAcid_Spray
    Me.EntityName = eEntity.abAcid_Spray

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAlchemist
    mDisplayName = "Acid Spray"
    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/alchemist_acid_spray_hp2.png"

    Description = "Sprays high-pressure acid across a target area. Enemy units who step across the contaminated terrain take mixed damage per second and have their armor reduced."

    ManaCost = New ValueWrapper(130, 140, 150, 160)


    Cooldown = New ValueWrapper(22, 22, 22, 22)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    PiercesSpellImmunity = True

    Radius = New ValueWrapper(625, 625, 625, 625)

    Duration = New ValueWrapper(16, 16, 16, 16)

    damageovertime = New ValueWrapper(12, 16, 20, 24)

    armorreduction = New ValueWrapper(4, 5, 6, 7)






  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointtargetenemyunits = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)
    'Damage over time
    Dim dotval As New modValue(damageovertime, eModifierType.DamagePhysicaloT, New ValueWrapper(1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dotmod As New Modifier(dotval, pointtargetenemyunits)
    outmods.Add(dotmod)

    'Armor reduction
    Dim armdebuff As New modValue(armorreduction, eModifierType.ArmorSubtracted, occurencetime, aghstime)
    Dim armmod As New Modifier(armdebuff, pointtargetenemyunits)
    outmods.Add(armmod)
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
