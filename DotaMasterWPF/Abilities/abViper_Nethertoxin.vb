Public Class abNethertoxin
  Inherits AbilityBase


  Dim basedamage As ValueWrapper
  Dim basecreepdam As ValueWrapper
  Dim basetowerdam As ValueWrapper

  Dim maxdamage As ValueWrapper

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

    mDisplayName = "Nethertoxin"
    mName = eAbilityName.abNethertoxin
    Me.EntityName = eEntity.abNethertoxin

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untViper

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/viper_nethertoxin_hp2.png"

    Description = "Nethertoxin causes Viper's normal attack to deal bonus damage to units based on how much health they are missing. The bonus damage doubles for each 20% of health missing from the target. Nethertoxin deals half damage to creeps and buildings."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    basedamage = New ValueWrapper(2.5, 5, 7.5, 10)

    basecreepdam = New ValueWrapper(basedamage.Value(0) * 0.5, _
                                    basedamage.Value(1) * 0.5, _
                                    basedamage.Value(2) * 0.5, _
                                    basedamage.Value(3) * 0.5)

    basetowerdam = basecreepdam
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing

  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  theowner As idisplayunit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim unittargetcreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)


    Dim unittargetstructure = Helpers.GetUnitTargetEnemyStructureInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)


    'hero damage
    Dim hdamval As New modValue(basedamage, eModifierType.RightClickNetherToxinDamage, occurencetime, aghstime)

    Dim hdammod As New Modifier(hdamval, unittargetenemy)
    outmods.Add(hdammod)



    'creep damage
    Dim cdamval As New modValue(basecreepdam, eModifierType.RightClickNetherToxinDamage, occurencetime, aghstime)

    Dim cdammod As New Modifier(cdamval, unittargetcreep)
    outmods.Add(cdammod)

    'sturct damage 
    Dim sdamval As New modValue(basetowerdam, eModifierType.RightClickNetherToxinDamage, occurencetime, aghstime)

    Dim sdammod As New Modifier(sdamval, unittargetstructure)
    outmods.Add(sdammod)


    'structure damage
    Return outmods
  End Function
End Class
