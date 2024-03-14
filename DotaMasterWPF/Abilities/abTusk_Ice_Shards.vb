Public Class abIce_Shards
  Inherits AbilityBase

  Public shardduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Projectile travels with a speed of 900ms.|Projectile provides small vision around itself. However, the shards provide no vision.|Creates 7 shards which are formated like a circle with 250 radius which is open on one side. The open side is always facing the point at which Ice Shards was casted from.|Releases shards when it reaches the target location.|When reaching the targeted point, the open shard circle's center will be exactly at the point Ice Shards was casted.|The shards are visible through the fog of war." '"

    mDisplayName = "Ice Shards"
    mName = eAbilityName.abIce_Shards
    Me.EntityName = eEntity.abIce_Shards

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTusk

    mAbilityPosition = 1

    mIsUltimate = False '
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tusk_ice_shards_hp2.png"

    Description = "Tusk compresses shards of ice into a ball of frozen energy that damages all enemies it comes in contact with. If the ball comes in contact with an enemy hero or reaches its maximum range the shards are released, creating a barrier that lasts for 5 seconds."

    ManaCost = New ValueWrapper(120, 120, 120, 120)
    
    Cooldown = New ValueWrapper(18, 16, 14, 12)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(200, 200, 200, 200)

    Damage = New ValueWrapper(70, 140, 210, 280)

    shardduration = New ValueWrapper(7, 7, 7, 7)

    Range = New ValueWrapper(1800, 1800, 1800, 1800)
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

    Dim pointtargetUnits = Helpers.GetPointTargetUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim sharddamage As New Modifier(damval, pointtargetenemyunits)
    outmods.Add(sharddamage)



    Dim barrierval As New modValue(Range, eModifierType.Barrier, occurencetime, aghstime)
    barrierval.mValueDuration = shardduration
    barrierval.mRadius = Radius

    Dim barrier As New Modifier(barrierval, pointtargetUnits)
    outmods.Add(barrier)


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
