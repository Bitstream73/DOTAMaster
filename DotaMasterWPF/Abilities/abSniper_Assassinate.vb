Public Class abAssassinate
Inherits AbilityBase

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Has a cast time of 2 seconds (0.3 second hero cast time + 1.7 second spell cast time).|The projectile travels at a speed of 2500.|Assassinate icon.png Assassinate can be disjointed.|Assassinate icon.png Assassinate places a debuff on the target as soon as Sniper begins casting. The debuff lasts 4 seconds, or until the projectile lands, or the cast gets canceled.|The debuff grants shared vision with the targeted unit. Does not provide any vision when targeting neutral creeps.|The debuff grants True Sight over the target. This means that Assassinate icon.png Assassinate cannot be canceled by going, or be disjointed with invisibility.|However, since units under the effect of Shadow Dance icon.png Shadow Dance and Smoke of Deceit icon.png Smoke of Deceit are immune to True Sight, they cancel the cast or disjoint the projectile.|The debuff is visible to everyone.|Can directly target invulnerable units, but won't damage or stun them|The cast is not canceled when the target turns invulnerable or hidden during the cast time.|Places a crosshair on the target, which is visible to allies only. The initial sound during the cast time is audible by Sniper only.|The mini-stun lasts for 0.01 seconds." '"

    mDisplayName = "Assassinate"
    mName = eAbilityName.abAssassinate
    Me.EntityName = eEntity.abAssassinate

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSniper

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sniper_assassinate_hp2.png"

    Description = "Sniper locks onto a target enemy unit, and after 1.7 seconds, fires a devastating shot that deals damage at long range, and mini-stuns the target."

    ManaCost = New ValueWrapper(175, 275, 375)

    Cooldown = New ValueWrapper(20, 15, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(355, 505, 655)

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

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamage)

    Dim minival As New modValue(0.1, eModifierType.MiniStun, occurencetime)
    minival.mValueDuration = New ValueWrapper(0.1)

    Dim ministun As New Modifier(minival, unittargetenemy)
    outmods.Add(ministun)

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
