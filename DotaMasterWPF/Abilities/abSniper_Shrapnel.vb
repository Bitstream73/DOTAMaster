Public Class abShrapnel
Inherits AbilityBase
  Public movespeed As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Shrapnel starts to damage and slow after a 1.1 second delay (0.3 second cast time + 0.8 second effect delay).|Provides 450 radius flying vision at the targeted area. Unlike the damage and slow, the vision is instantly applied after cast.|Deals damage in 1 second intervals, starting off immediately after the effect delay. The slow debuff is refreshed in the same intervals.|Deals 33% of its damage to buildings (4/8/12/16 damage per second).|Deals a total of 120/240/360/480 (40/80/120/160 to buildings) damage to a single unit.|Does not affect ancient creeps, Roshan,  Warlock's Golem and spirits from Primal Split." '"

    mDisplayName = "Shrapnel"
    mName = eAbilityName.abShrapnel
    Me.EntityName = eEntity.abShrapnel

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSniper

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sniper_shrapnel_hp2.png"

    Description = "Fires a ball of shrapnel that showers the target area in explosive pellets. Enemies are subject to damage and slowed movement. Reveals the targeted area."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(40, 40, 40, 40)

    'mCanBePurged = New ValueWrapper(25, 25, 25, 25)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(12, 24, 36, 48)

    movespeed = New ValueWrapper(12, 24, 36, 48)

    Duration = New ValueWrapper(10, 10, 10, 10)

    Radius = New ValueWrapper(450, 450, 450, 450)
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


    Dim damval As New modValue(Me.Damage, eModifierType.DamageMagicalPerSec, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim damage As New Modifier(damval, pointtargetenemies)
    outmods.Add(damage)


    Dim moveval As New modValue(movespeed, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim move As New Modifier(moveval, pointtargetenemies)
    outmods.Add(move)


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
