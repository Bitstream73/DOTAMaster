Public Class abHoly_Persuasion
Inherits AbilityBase
  Public maxunits As ValueWrapper
  Public healthbonus As ValueWrapper
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
    mDisplayName = "Holy Persuasion"
    mName = eAbilityName.abHoly_Persuasion
    Me.EntityName = eEntity.abHoly_Persuasion


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untChen

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/chen_holy_persuasion_hp2.png"

    Description = "Gives control of an enemy or neutral creep, and gives it bonus hit points."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(30, 26, 22, 18)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyCreeps)

    maxunits = New ValueWrapper(1, 2, 3, 4)

    healthbonus = New ValueWrapper(75, 150, 225, 300)


End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)

    Dim creepval As New modValue(maxunits, eModifierType.CreepControlled, occurencetime, aghstime)

    Dim creepmod As New Modifier(creepval, unittargetself)
    outmods.Add(creepmod)


    Dim hpval As New modValue(healthbonus, eModifierType.ControlledCreepHealthBonus, occurencetime, aghstime)

    Dim hpmod As New Modifier(hpval, unittargetself)
    outmods.Add(hpmod)

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
