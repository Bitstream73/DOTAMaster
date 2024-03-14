Public Class abRocket_Barrage
  Inherits AbilityBase
  Public rocketspersec As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    mDisplayName = "Rocket Barrage"
    Notes = "Despite the visual effects, the damage is dealt instantly, rather than on projectiles hit.|Rocket Barrage can't hit invisible units or units in the Fog of War.|Rocket Barrage can hit siege creeps.|Gyrocopter can act freely during Rocket Barrage.|Deals damage in 0.1 second intervals, resulting in 30 damage instances.|Deals a total of 330/450/570/690 damage (before reductions), assuming all rockets hit." '"

    mName = eAbilityName.abRocket_Barrage
    Me.EntityName = eEntity.abRocket_Barrage

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGyrocopter

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/gyrocopter_rocket_barrage_hp2.png"

    Description = "Launches a salvo of rockets at nearby enemy units in a radius around the Gyrocopter. Lasts 3 seconds."

    ManaCost = New ValueWrapper(90, 90, 90, 90)

    Cooldown = New ValueWrapper(7, 6.5, 5, 5.5)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(11, 15, 19, 23)

    Radius = New ValueWrapper(400, 400, 400, 400)

    Duration = New ValueWrapper(3, 3, 3, 3)

    rocketspersec = New ValueWrapper(10, 10, 10, 10)

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




    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, New ValueWrapper(0.1, 0.1, 0.1, 0.1), occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim thedamage As New Modifier(damval, pointtargetenemies)
    outmods.Add(thedamage)


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
