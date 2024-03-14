Public Class abToss
Inherits AbilityBase

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

    Notes = "An enemy under the effects of both Toss and Avalanche will take double damage from Avalanche.|Tossed units are disabled while in air.|Tossed allies will take no damage.|Tiny can toss units to Runes.|Can be disjointed by secondary target with teleportation or blink but not by becoming invisibile.|Buildings cannot be targeted, but will take 33% damage (25/50/75/100) from a unit being tossed near them.|Invisibile enemy units cannot be tossed, but will still take damage from a unit being tossed onto or near them.|Units in the Fog of War can be tossed if they are within a 275 radius of Tiny, but cannot be selected as a target.|Breaks channeling abilities of the tossed (allied/enemy) unit. Even prematurely ends Life Break.|Tossing a unit which is affected by another position changing spell (e.g. Meat Hook icon.png Meat Hook) will interrupt that spell.|Units tossed in the air lose their collision size for the duration, so units can path below them.|The tossed unit takes 20% more damage from Toss icon.png Toss. Grow increases this to 35%/50/65%, and with Aghanim's Scepter to 50%/65%/80%.|Level 0 Grow: 90/180/270/360 damage.|Level 1 Grow: 101.25/202.50/303.75/405 (112.50/225.00/337.50/450) damage.|Level 2 Grow: 112.50/225.00/337.50/450 (123.75/247.50/371.25/495) damage.|Level 3 Grow: 123.75/247.50/371.25/495 (135/270/405/540) damage." '"

    mDisplayName = "Toss"
    mName = eAbilityName.abToss
    Me.EntityName = eEntity.abToss

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTiny

    mAbilityPosition = 2

    mIsUltimate = False '
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tiny_toss_hp2.png"

    Description = "Grabs a random unit in a 275 radius around Tiny, friend or enemy, and launches it at the target unit or rune to deal damage where they land. If the tossed unit is an enemy, it will take an extra 20% damage. Toss does more damage as Tiny's size increases."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(9, 9, 9, 9)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(75, 150, 225, 300)

    Radius = New ValueWrapper(275, 275, 275, 275)
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

    Dim unittargetrandom = Helpers.GetNoTargetRandomUnitInfo(theability_InfoID, _
                                                             thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim valpuch As New modValue(1, eModifierType.PushForward, occurencetime)
    valpuch.mRadius = Radius

    Dim modpush As New Modifier(valpuch, unittargetrandom)

    outmods.Add(modpush)


    Dim valdam As New modValue(Damage, eModifierType.TinyTossDamageInflicted, occurencetime, aghstime)

    Dim moddam As New Modifier(valdam, unittargetenemy)
    outmods.Add(moddam)



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
