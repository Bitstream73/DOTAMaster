Public Class abCharge_Of_Darkness
  Inherits AbilityBase
  Public chargespeed As ValueWrapper
  Public stunduration As ValueWrapper
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

    Notes = "Goes into cooldown once the charge ends or is canceled, not upon cast.|The charge indicator above the target is visible to allies only.|During Charge of Darkness, Spirit Breaker moves through other units and impassable terrain.|The charge is canceled when Spirit Breaker gets stunned, cycloned, hexed, ensnared, entangled, slept, paused or hit by any position changing spell (e.g. Force Staff icon.png Force Staff).|While ensnared or entangled, Charge of Darkness icon.png Charge of Darkness cannot be cast. On attempt, the player gets the error message ""Can't cast this while rooted.""|Spirit Breaker can cancel it by issuing a targeted order, like attacking, moving, casting Nether Strike icon.png Nether Strike or any targeted item. Activating Empowering Haste icon.png Empowering Haste does not cancel the charge.|The charge is not canceled by taunts. Spirit Breaker will start attacking the taunting unit once the charge stops. During taunts, the charge can't be manually canceled.|Since Charge of Darkness icon.png Charge of Darkness is not a channeling spell, shift-queuing orders does not work and will cause the charge to get canceled.|However, when the auto-attack setting is turned on, Spirit Breaker can automatically attack units when they get close enough. This won't cancel the charge.|The following items can be used during the charge without canceling it:|Animal Courier, Arcane Boots,  Armlet of Mordiggian, Black King Bar, Blade Mail, Boots of Travel (double-click only), Bottle (including activation of preserved Runes), Buckler, Butterfly, Cheese, Crimson Guard, Drum of Endurance, Dust of Appearance, Ghost Scepter, Magic Stick, Magic Wand, Mask of Madness, Mekansm, Necronomicon, Phase Boots, Pipe of Insight, Power Treads, Radiance, Refresher Orb, Ring of Aquila, Ring of Basilius, Satanic, Shadow Blade, Shiva's Guard, Smoke of Deceit, Soul Ring, Town Portal Scroll (double-click only).|The charge's speed is completely unrelated to Spirit Breaker's movement speed. Slows and move speed buffs do not affect it and it does not affect the damage from Greater Bash icon.png Greater Bash.|Any unit which comes within 300 radius of Spirit Breaker during the charge will get hit by the current level of Greater Bash icon.png Greater Bash (it still gives bonus move speed to Spirit Breaker). If it is not leveled, no bash is applied.|The stun does not stack with the stun of Greater Bash. It follows the regular rule of stuns – the longer stun overrides the shorter one.|If the target dies, the charge is transferred to the nearest valid target within 4000 range of the previous target.|When the target turns invisible, the charge continues. The target's silhouette and the indicator stay visible and vision is still granted. The stun and Greater Bash hit invisible units.|The charge provides shared vision with the targeted unit. Does not provide any vision when targeting neutral creeps." '"

    mDisplayName = "Charge of Darkness"
    mName = eAbilityName.abCharge_Of_Darkness
    Me.EntityName = eEntity.abCharge_Of_Darkness

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Breaker

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/spirit_breaker_charge_of_darkness_hp2.png"

    Description = "Spirit Breaker fixes his sight on an enemy unit and starts charging through all objects. All enemy units passed through and the targeted unit will be hit by a Greater Bash. If the targeted unit dies, Spirit Breaker will change his target to the nearest enemy unit to that location."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(35, 35, 35, 35)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    chargespeed = New ValueWrapper(600, 650, 700, 750)

    stunduration = New ValueWrapper(1.2, 1.6, 2, 2.4)
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

    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, unittargetenemy)
    outmods.Add(thestun)

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
