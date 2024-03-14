Public Class abShuriken_Toss
Inherits AbilityBase

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The shuriken travels at a speed of 1000.|Shuriken Toss can be disjointed by the initial target and the bounce targets. When disjointed, it will stop bouncing.|The initial target does not have to have the Track debuff on for the shuriken to bounce. It only bounces to each Tracked unit once.|The mini-stun lasts for 0.1 seconds." '"
    mDisplayName = "Shuriken Toss"
    mName = eAbilityName.abShuriken_Toss
    Me.EntityName = eEntity.abShuriken_Toss

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    AbilityName = eUnit.untBounty_Hunter

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bounty_hunter_shuriken_toss_hp2.png"

    Description = "Hurls a deadly shuriken at an enemy unit, dealing damage and mini-stunning the target."

    ManaCost = New ValueWrapper(90, 115, 135, 155)


    Cooldown = New ValueWrapper(10, 10, 10, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(100, 200, 250, 325)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'damage
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamage)

    'ministun
    Dim stunval As New modValue(0.1, eModifierType.MiniStun, occurencetime)

    Dim stunod As New Modifier(stunval, unittargetenemy)
    outmods.Add(stunod)

    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 caster As iDisplayUnit, _
                                                 target As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
