Public Class abSoul_Assumption
Inherits AbilityBase

  Public basedamage As ValueWrapper
  Public souldamage As ValueWrapper
  Public damthreshold As ValueWrapper
  Public maxsouls As ValueWrapper
  Public soulduration As ValueWrapper
  Public assumptionradius As ValueWrapper

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

    mDisplayName = "Soul Assumption"
    mName = eAbilityName.abSoul_Assumption
    Me.EntityName = eEntity.abSoul_Assumption

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVisage

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/visage_soul_assumption_hp2.png"

    Description = "Visage damages the targeted unit based on the number of soul charges. Visage gains a soul charge when damage taken by all heroes around him reaches the damage threshold."

    ManaCost = New ValueWrapper(170, 160, 150, 140)

    Cooldown = New ValueWrapper(4, 4, 4, 4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    basedamage = New ValueWrapper(20, 20, 20, 20)

    souldamage = New ValueWrapper(65, 65, 65, 65)

    damthreshold = New ValueWrapper(110, 110, 110, 110)

    maxsouls = New ValueWrapper(3, 4, 5, 6)

    soulduration = New ValueWrapper(6, 6, 6, 6)

    assumptionradius = New ValueWrapper(1375, 1375, 1375, 1375)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)


    Dim damval As New modValue(basedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim sdamval As New modValue(souldamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    sdamval.Charges = maxsouls
    sdamval.mRadius = assumptionradius

    Dim sdammod As New Modifier(sdamval, unittargetenemy)
    outmods.Add(sdammod)

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
