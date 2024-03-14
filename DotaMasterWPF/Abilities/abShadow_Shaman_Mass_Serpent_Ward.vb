Public Class abMass_Serpent_Ward
Inherits AbilityBase
  Public attackdamage As ValueWrapper
  Public scepterattdamage As New List(Of Double?)

  Public serpentcount As ValueWrapper

  Public lowattackdamage As ValueWrapper
  Public scepterlowattackdamage As New List(Of Double?)
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

    mDisplayName = "Serpent Ward"
    mName = eAbilityName.abMass_Serpent_Ward
    Me.EntityName = eEntity.abMass_Serpent_Ward

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Shaman

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_shaman_mass_serpent_ward_hp2.png"

    Description = "Summons 10 serpent wards to attack enemy units and structures. The wards are immune to magic, and have a small area of splash damage that increases per level. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 350, 600)

    Cooldown = New ValueWrapper(120, 120, 120)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)


    DamageType = eDamageType.Physical

    attackdamage = New ValueWrapper(45, 60, 75)
    scepterattdamage.Add(90)
    scepterattdamage.Add(110)
    scepterattdamage.Add(130)
    attackdamage.LoadScepterValues(scepterattdamage)

    lowattackdamage = New ValueWrapper(40, 55, 70)
    scepterlowattackdamage.Add(85)
    scepterlowattackdamage.Add(105)
    scepterlowattackdamage.Add(125)
    lowattackdamage.LoadScepterValues(scepterlowattackdamage)

    Duration = New ValueWrapper(45, 45, 45)

    serpentcount = New ValueWrapper(10, 10, 10)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    'Dim serpent As New HeroPet_Info
    'serpent.hitpoints = New ValueWrapper(135, 150, 150)

    'serpent.DamageHigh = attackdamage
    'serpent.DamageLow = lowattackdamage

    'serpent.SightRange.Add(New ValueWrapper(1200, 1200, 1200))
    'serpent.SightRange.Add(New ValueWrapper(800, 800, 800))

    'serpent.BaseAttackSpeed = New ValueWrapper(1.5, 1.5, 1.5)

    'serpent.xpvalue = New ValueWrapper(31, 31, 31, 31)

    'serpent.Duration = mDuration

    Dim petval As New modValue(serpentcount, eModifierType.petSerpent_Ward, occurencetime, aghstime)
    petval.mValueDuration = Duration

    Dim petmod As New Modifier(petval, pointtargetenemies)
    outmods.Add(petmod)


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
