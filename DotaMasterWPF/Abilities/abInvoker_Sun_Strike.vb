Public Class abSun_Strike
Inherits AbilityBase
  Public effectdelay As ValueWrapper
  Public exortdamage As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = True

    Notes = "The damage is spread evenly among all affected units within the targeted area, including creeps.|This is how much damage Sun Strike icon.png Sun Strike deals when hitting a certain amount of units (before reductions).|2 units: 50/81.25/112.5/143.75/175/206.25/237.5 damage|3 units: 33.33/54.17/75/95.83/116.67/137.5/158.33 damage|4 units: 25/40.63/56.25/71.88/87.5/103.13/118.75 damage|5 units: 20/32.5/45/57.5/70/82.5/95 damage|Damage is only spread among units which are damaged by Sun Strike. All unaffected units do not soak up any damage.|Does not affect ancient creeps, Roshan, Warlock's Golem and the Primal Split spirits.|Provides 300 radius flying vision at the targeted point for 5.5 seconds upon cast.|The visual effects and the sound during the 1.7 seconds effect delay are visible and audible to allies only."

    mDisplayName = "Sun Strike"
    mName = eAbilityName.abSun_Strike
    Me.EntityName = eEntity.abSun_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_sun_strike_hp2.png"

    Description = "Sends a catastrophic ray of fierce energy from the sun at any targeted location, incinerating all enemies standing beneath it once it reaches the earth. Deals damage based on the level of Exort, however this damage is spread evenly over all enemies hit."

    ManaCost = New ValueWrapper(175, 175, 175, 175, 175, 175, 175)

    Cooldown = New ValueWrapper(30, 30, 30, 30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure


    Radius = New ValueWrapper(175, 175, 175, 175, 175, 175, 175)
    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea)
    effectdelay = New ValueWrapper(1.7, 1.7, 1.7, 1.7, 1.7, 1.7, 1.7)
    exortdamage = New ValueWrapper(100, 162.5, 225, 287.5, 350, 412.5, 475)
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


    Dim damval As New modValue(exortdamage, eModifierType.SunStrikePureInflicted, occurencetime, aghstime)
    damval.mRadius = Radius
    damval.mRange = Range

    Dim dammod As New Modifier(damval, pointtargetenemies)
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
