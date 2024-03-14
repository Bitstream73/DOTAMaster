Public Class abSun_Ray
Inherits AbilityBase
  Public hpcostpersec As ValueWrapper
  Public dps As ValueWrapper

  Public maxhpasdamage As ValueWrapper
  Public maxhpasheal As ValueWrapper

  Public width As ValueWrapper

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

    mDisplayName = "Sun Ray"
    mName = eAbilityName.abSun_Ray

    Me.EntityName = eEntity.abSun_Ray

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhoenix

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phoenix_sun_ray_hp2.png"

    Description = "Drawing from its own inner fire, Phoenix expels a huge beam of light at the cost of its own life energy. The beam damages enemies for a percentage of their life and heals allies for half that amount. Damage scales up to twice the initial damage as the beam fires."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(20, 20, 20, 20)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure

    hpcostpersec = New ValueWrapper(0.06, 0.06, 0.06, 0.06)

    dps = New ValueWrapper(15, 20, 25, 30)
    maxhpasdamage = New ValueWrapper(0.01, 0.02, 0.03, 0.04)

    maxhpasheal = New ValueWrapper(0.5 * maxhpasdamage.Value(0), _
                                   0.5 * maxhpasdamage.Value(1), _
                                   0.5 * maxhpasdamage.Value(2), _
                                   0.5 * maxhpasdamage.Value(3))

    width = New ValueWrapper(130, 130, 130, 130)

    Range = New ValueWrapper(1300, 1300, 1300, 1300)

    Duration = New ValueWrapper(6, 6, 6, 6)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim pointtargetallies = Helpers.GetPointTargetLineAlliedUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim pointtargetsef = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)


    Dim hplossval As New modValue(hpcostpersec, eModifierType.DamagePureInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)

    Dim hplossmod As New Modifier(hplossval, pointtargetsef)
    outmods.Add(hplossmod)


    Dim dpsval As New modValue(dps, eModifierType.DamagePureoTInflicted, occurencetime, aghstime)

    Dim dpsmod As New Modifier(dpsval, pointtargetenemies)
    outmods.Add(dpsmod)


    Dim healval As New modValue(maxhpasheal, eModifierType.HealAddedoTAsPercofMaxHP, occurencetime, aghstime)

    Dim healmod As New Modifier(healval, pointtargetallies)
    outmods.Add(healmod)


    Dim damval As New modValue(maxhpasdamage, eModifierType.DamagePureoTasPercofMaxHP, occurencetime, aghstime)

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
