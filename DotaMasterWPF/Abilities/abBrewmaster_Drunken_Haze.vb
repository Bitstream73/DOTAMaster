Public Class abDrunken_Haze
Inherits AbilityBase
  Private heroduration As ValueWrapper
  Private creepduration As ValueWrapper
  Private moveslow As ValueWrapper
  Private misschance As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Despite the visual effect, Drunken Haze does not use a projectile and is instant, and thus cannot be disjointed." '"
    mDisplayName = "Drunken Haze"
    mName = eAbilityName.abDrunken_Haze

    Me.EntityName = eEntity.abDrunken_Haze

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBrewmaster

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/brewmaster_drunken_haze_hp2.png"

    Description = "Drenches a small area in alcohol, causing their movement speed to be reduced, and causing their attacks to have a chance to miss."

    
    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Radius = New ValueWrapper(200, 200, 200, 200)

    heroduration = New ValueWrapper(8, 8, 8, 8)
    creepduration = New ValueWrapper(12, 12, 12, 12)

    moveslow = New ValueWrapper(0.14, 0.14, 0.14, 0.14)

    misschance = New ValueWrapper(0.45, 0.55, 0.65, 0.75)


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
    'movespeed 
    Dim moveheroval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveheroval.mValueDuration = heroduration

    Dim moveheromod As New Modifier(moveheroval, pointtargetenemyheroes)
    outmods.Add(moveheromod)

    Dim movecreepval As New modValue(moveslow, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    movecreepval.mValueDuration = creepduration

    Dim movecreepmod As New Modifier(moveheroval, pointtargetenemycreeps)
    outmods.Add(movecreepmod)

    'miss chance

    Dim missheroval As New modValue(misschance, eModifierType.MissChance, occurencetime, aghstime)
    missheroval.mValueDuration = heroduration

    Dim missheromod As New Modifier(missheroval, pointtargetenemyheroes)
    outmods.Add(missheromod)

    Dim misscreepval As New modValue(misschance, eModifierType.MissChance, occurencetime, aghstime)
    misscreepval.mValueDuration = creepduration

    Dim misscreepmod As New Modifier(misscreepval, pointtargetenemycreeps)
    outmods.Add(misscreepmod)


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
