Public Class abFade_Bolt
Inherits AbilityBase
  Public jumpreduction As ValueWrapper

  Public herodamreduction As ValueWrapper
  Public creepdamreduction As ValueWrapper

  Public debuffduration As ValueWrapper
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

    mDisplayName = "Fade Bolt"
    mName = eAbilityName.abFade_Bolt
    Me.EntityName = eEntity.abFade_Bolt

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRubick

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rubick_fade_bolt_hp2.png"

    Description = "Rubick creates a powerful stream of arcane energy that travels between enemy units, dealing damage and reducing their attack damage. Each jump deals less damage."

    ManaCost = New ValueWrapper(120, 130, 140, 150)

    Cooldown = New ValueWrapper(16, 14, 12, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(70, 140, 210, 280)

    jumpreduction = New ValueWrapper(0.04, 0.04, 0.04, 0.04)

    herodamreduction = New ValueWrapper(14, 20, 26, 32)
    creepdamreduction = New ValueWrapper(7, 10, 13, 16)

    debuffduration = New ValueWrapper(10, 10, 10, 10)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyheroes = Helpers.GetUnitTargetEnemyHeroesInfo(theability_InfoID,
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim unittargetenemycreeps = Helpers.GetUnitTargetEnemyCreepsInfo(theability_InfoID,
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)



    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID,
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)


    'fadebolt bouncing damage
    Dim damval As New modValue(Damage, eModifierType.FadeBoltDamageMagicalBounces, occurencetime, aghstime)


    Dim dammod As New Modifier(damval, unittargetenemies)
    outmods.Add(dammod)

    'target damage reduction, hero and or creep
    Dim heroval As New modValue(herodamreduction, eModifierType.DamageReduction, occurencetime, aghstime)
    heroval.mValueDuration = debuffduration

    Dim heromod As New Modifier(heroval, unittargetenemies)
    outmods.Add(heromod)


    Dim creepval As New modValue(creepdamreduction, eModifierType.DamageReduction, occurencetime, aghstime)
    heroval.mValueDuration = debuffduration

    Dim creepmod As New Modifier(creepval, unittargetenemycreeps)
    outmods.Add(creepmod)


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
