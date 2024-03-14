Public Class abBlade_Fury
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

    Notes = "Has an instant cast time. Does not interrupt channeling items.|Juggernaut is silenced for the duration. Items can be used during Blade Fury.|Juggernaut can freely move at his regular move speed during Blade Fury icon.png Blade Fury.|Applies Spell Immunity on Juggernaut for its duration, dispelling buffs and debuffs.|Juggernaut can perform attacks during Blade Fury, but will deal no damage with them against units affected by Blade Fury.|Attack modifier like Monkey King Bar, Diffusal Blade or Skull Basher still fully work and apply their effects on the attacks, including their damage.|Attack modifier which are based on attack damage like crits and Lifesteal have no effect. Crits will still show the red number, but don't actually deal damage.|Cleave is the only exception here. Despite being based on attack damage, cleave will still fully work when attacking a unit affected by Blade Fury.|Blade Fury does not affect buildings, wards and siege creeps. Unaffected units will take full attack damage from Juggernaut during Blade Fury.|Deals 16/20/24/28 damage in 0.2 second intervals.|Deals a total of 400/500/600/700 damage to a single unit (before reductions)." '"

    mDisplayName = "Blade Fury"
    mName = eAbilityName.abBlade_Fury
    Me.EntityName = eEntity.abBlade_Fury

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJuggernaut

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/juggernaut_blade_fury_hp2.png"

    Description = "Causes a bladestorm of destructive force around Juggernaut, rendering him immune to magic and dealing damage to nearby enemy units. Lasts 5 seconds."

    ManaCost = New ValueWrapper(110, 110, 110, 110)

    Cooldown = New ValueWrapper(30, 26, 22, 18)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(80, 100, 120, 140)

    Radius = New ValueWrapper(250, 250, 250, 250)

    Duration = New ValueWrapper(5, 5, 5, 5)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraself = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)



    Dim damval As New modValue(Damage, eModifierType.DamageMagicalPerSec, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim thedamage As New Modifier(damval, auraself)
    outmods.Add(thedamage)



    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim magicval As New modValue(Duration, eModifierType.MagicImmunity, occurencetime, aghstime)
    magicval.mValueDuration = Duration

    Dim magicimmune As New Modifier(magicval, notargetself)
    outmods.Add(magicimmune)

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
