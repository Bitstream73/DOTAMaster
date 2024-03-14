Public Class abRocket_Flare
Inherits AbilityBase
  Public visionradius As ValueWrapper
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
    mDisplayName = "Rocket Flare"
    mName = eAbilityName.abRocket_Flare
    Me.EntityName = eEntity.abRocket_Flare


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClockwerk

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rattletrap_rocket_flare_hp2.png"

    Description = "Fires a global range flare that explodes over a given area, damaging enemies and providing vision for 10 seconds."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(20, 18, 16, 14)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(80, 120, 160, 200)

    Radius = New ValueWrapper(575, 575, 575, 575)

    Duration = New ValueWrapper(10, 10, 10, 10)

    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea) 'global

    visionradius = New ValueWrapper(600, 600, 600, 600)

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

    Dim pointtargetself = Helpers.GetPointTargetAlliedHeroesInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)


    Dim pointtargetalliedheroes = Helpers.GetPointTargetAlliedUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim visionval As New modValue(Duration, eModifierType.Vision, occurencetime, aghstime)
    visionval.mRadius = visionradius

    Dim visionmod As New Modifier(visionval, pointtargetalliedheroes)
    outmods.Add(visionmod)

    Dim visionselfmod As New Modifier(visionval, pointtargetself)
    outmods.Add(visionselfmod)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemyunits)
    outmods.Add(dammod)

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
