Public Class abSacrifice
Inherits AbilityBase
  Public healthconversion As ValueWrapper
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

    mDisplayName = "Sacrifice"
    mName = eAbilityName.abSacrifice
    Me.EntityName = eEntity.abSacrifice

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLich

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lich_dark_ritual_hp2.png"

    Description = "Sacrifices a friendly creep and converts its current hit points into mana for Lich. Grants XP to both enemies and allies."

    ManaCost = New ValueWrapper(25, 25, 25, 25)

    Cooldown = New ValueWrapper(44, 36, 28, 20)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedCreep)

    healthconversion = New ValueWrapper(0.25, 0.4, 0.55, 0.7)


End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetallycreep = Helpers.GetUnitTargetAlliedCreepInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)


    Dim unittargetauraallies = Helpers.GetUnitTargetAuraEnemyHeroesInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)


    Dim unittargetauraenemies = Helpers.GetUnitTargetAuraEnemyHeroesInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim manaval As New modValue(healthconversion, eModifierType.ManaRestoredAsPercentOfHP, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, unittargetself)
    outmods.Add(manamod)


    Dim xpval As New modValue(1, eModifierType.XPAdded, occurencetime)

    Dim xpmodself As New Modifier(xpval, unittargetself)
    outmods.Add(xpmodself)


    Dim xpallies As New Modifier(xpval, unittargetauraallies)
    outmods.Add(xpallies)

    Dim xpenemies As New Modifier(xpval, unittargetauraenemies)
    outmods.Add(xpenemies)


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
