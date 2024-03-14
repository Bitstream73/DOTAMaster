Public Class abSleight_Of_Fist
Inherits AbilityBase
  Public bonusherodamage As ValueWrapper
  Public attackinterval As ValueWrapper
  Public creepdamagepenalty As ValueWrapper
  Public bonuscreepdamage As ValueWrapper
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

    mDisplayName = "Sleight of Fist"
    mName = eAbilityName.abSleight_Of_Fist
    Me.EntityName = eEntity.abSleight_Of_Fist

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEmber_Spirit

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ember_spirit_sleight_of_fist_hp2.png"

    Description = "Ember Spirit dashes around with blazing speed, attacking all enemies in the targeted area of effect, then returning to his start location. Deals bonus damage to heroes, and less damage to creeps."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(30, 22, 14, 6)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyHeroes)
    Affects.Add(eUnit.untEnemyCreeps)

    DamageType = eDamageType.Physical

    Radius = New ValueWrapper(550, 450, 350, 250)

    bonusherodamage = New ValueWrapper(20, 40, 60, 80)

    attackinterval = New ValueWrapper(0.2, 0.2, 0.2, 0.2)

    creepdamagepenalty = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    bonuscreepdamage = New ValueWrapper(bonusherodamage.Value(0) * creepdamagepenalty.Value(0), _
                                        bonusherodamage.Value(1) * creepdamagepenalty.Value(1), _
                                        bonusherodamage.Value(2) * creepdamagepenalty.Value(2), _
                                        bonusherodamage.Value(3) * creepdamagepenalty.Value(3))
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemyheroes = Helpers.GetPointTargetEnemyHeroesInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                        thetarget, _
                                                                        "", eModifierCategory.Active)

    Dim pointtargetenemycreeps = Helpers.GetPointTargetEnemyCreepsInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                        thetarget, _
                                                                        "", eModifierCategory.Active)

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                        thetarget, _
                                                                        "", eModifierCategory.Active)


    'hero bonus
    Dim herodamval As New modValue(bonusherodamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim herodammod As New Modifier(herodamval, pointtargetenemyheroes)
    outmods.Add(herodammod)

    'creep bonus
    Dim creepdamval As New modValue(bonuscreepdamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim creepdammod As New Modifier(creepdamval, pointtargetenemycreeps)
    outmods.Add(creepdammod)


    'right click
    Dim rdamval As New modValue(1, eModifierType.RightClickAttackDamage, occurencetime)

    Dim rdammod As New Modifier(rdamval, pointtargetenemies)
    outmods.Add(rdammod)

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
