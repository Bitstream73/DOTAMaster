Public Class abDiabolic_Edict
  Inherits AbilityBase
  Public explosions As ValueWrapper
  Public structuredamage As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "This damage is not reduced by damage block abilities (such as Vanguard, Kraken Shell, etc.)|Has a cast point of 0.5 seconds.|The explosions will continue even if Leshrac is disabled or killed.|Can damage buildings, spell immune units, and invisible units.|Deals 40% more damage to buildings, up to 400/800/1200/1600 total damage." '"

    mDisplayName = "Diabolic Edict"
    mName = eAbilityName.abDiabolic_Edict
    Me.EntityName = eEntity.abDiabolic_Edict

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLeshrac

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/leshrac_diabolic_edict_hp2.png"

    Description = "Saturates the area around Leshrac with magical explosions that deal mixed damage to enemy units and structures. The fewer units available to attack, the more damage those units will take. Lasts 8 seconds."


    ManaCost = New ValueWrapper(95, 120, 135, 155)

    Cooldown = New ValueWrapper(22, 22, 22, 22)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(9, 18, 27, 36)
    structuredamage = New ValueWrapper(Damage.Value(0) * 1.4, Damage.Value(1) * 1.4, Damage.Value(2) * 1.4, Damage.Value(3) * 1.4)

    Radius = New ValueWrapper(500, 500, 500, 500)

    explosions = New ValueWrapper(32, 32, 32, 32)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim activeaurastructures = Helpers.GetActiveAuraEnemyStructuresInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    damval.Charges = explosions

    Dim thedamage As New Modifier(damval, activeauraenemies)
    outmods.Add(thedamage)


    Dim structdamval As New modValue(structuredamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    structdamval.Charges = explosions

    Dim thestructdam As New Modifier(structdamval, activeaurastructures)

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
