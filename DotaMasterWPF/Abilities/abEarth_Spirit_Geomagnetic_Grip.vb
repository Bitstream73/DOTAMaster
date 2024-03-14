Public Class abGeomagnetic_Grip
Inherits AbilityBase
  Public silenceduration As ValueWrapper
  Public remnantpullspeed As ValueWrapper
  Public heropullspeed As ValueWrapper
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

    mDisplayName = "Geomantic Grip"
    mName = eAbilityName.abGeomagnetic_Grip
    Me.EntityName = eEntity.abGeomagnetic_Grip

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Spirit

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earth_spirit_geomagnetic_grip_hp2.png"

    Description = "Earth Spirit pulls the target allied unit or Stone Remnant to his location. Enemies struck by the flying target will be silenced, and take damage if the flying target is a Stone Remnant."

    ManaCost = New ValueWrapper(75, 75, 75, 75)



    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(180, 180, 180, 180)

    Damage = New ValueWrapper(50, 125, 200, 275)

    silenceduration = New ValueWrapper(2.5, 3, 3.5, 4)

    remnantpullspeed = New ValueWrapper(1000, 1000, 1000, 1000)

    heropullspeed = New ValueWrapper(600, 600, 600, 600)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemies)
    outmods.Add(dammod)


    Dim silemceval As New modValue(silenceduration, eModifierType.Silence, occurencetime, aghstime)
    silemceval.mValueDuration = silenceduration

    Dim silemcemod As New Modifier(silemceval, pointtargetlineenemies)
    outmods.Add(silemcemod)





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
