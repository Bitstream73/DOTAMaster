Public Class abOmnislash
Inherits AbilityBase
  Public jumps As ValueWrapper
  Public jumpradius As ValueWrapper
  Public sceptercooldown As New List(Of Double?)
  Public scepterjumps As New List(Of Double?)
  Public invulduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Juggernaut is invulnerable and spell immune for the whole duration.|Jumps happen in 0.4 second intervals, so the maximum duration is 0.8/2/3.2 (2/3.2/4.4*) seconds.|On each jump, Juggernaut is positioned at the opposite side of the target from Juggernaut's position.|The jump radius is centered around Juggernaut, not around the current target.|The damage from the jumps is in no way related to Juggernaut's attack damage. Means it can only be reduced by armor. It cannot be evaded by Evasion.|Juggernaut can perform attacks and cast spells and items during Omnislash, however Blade Fury icon.png Blade Fury is disabled for the duration.|Instantly kills Lane creeps and neutral creeps on 1 jump.|Can jump on ethereal and invulnerable units, but won't damage them.|Can not jump on invisible units, hidden units and Tombstone zombies. If no valid targets are in range, Omnislash prematurely stops.|Provides 200 radius flying vision lasting 1 second on each jump around the current target.|Can deal up to 600-675/1200-1350/1800-2025 (1200-1350/1800-2025/2400-2700*) damage to a single target (before reductions).|Mini-stun lasts for 0.13 seconds." '"

    mDisplayName = "Omnislash"
    mName = eAbilityName.abOmnislash
    Me.EntityName = eEntity.abOmnislash

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJuggernaut

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/juggernaut_omni_slash_hp2.png"

    Description = "Juggernaut leaps towards the target enemy unit with a damaging attack, and then slashes other nearby enemy units, dealing between 200-225 damage per slash. Juggernaut is invulnerable for the duration. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 275, 350)

    Cooldown = New ValueWrapper(130, 120, 110)
    sceptercooldown.Add(70)
    sceptercooldown.Add(70)
    sceptercooldown.Add(70)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    jumps = New ValueWrapper(3, 6, 9)
    scepterjumps.Add(6)
    scepterjumps.Add(9)
    scepterjumps.Add(12)
    jumps.LoadScepterValues(scepterjumps)

    jumpradius = New ValueWrapper(425, 425, 425)

    'doesn't reflect worst case of 200 damage :/
    Damage = New ValueWrapper(225, 225, 225, 225)

    invulduration = New ValueWrapper(jumps.Value(0) * 0.4, jumps.Value(1) * 0.4, jumps.Value(2) * 0.4)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList



    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)



    'damage
    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, New ValueWrapper(0.4, 0.4, 0.4, 0.4), occurencetime, aghstime)
    damval.Charges = jumps

    Dim thedamage As New Modifier(damval, unittargetenemies)
    outmods.Add(thedamage)

    'ministun as per dota wiki
    Dim miduration As New ValueWrapper(0.13, 0.13, 0.13, 0.13)
    Dim ministun As New modValue(miduration, eModifierType.MiniStun, occurencetime, aghstime)
    ministun.mValueDuration = miduration

    Dim minimod As New Modifier(ministun, unittargetenemies)
    outmods.Add(minimod)


    'unvulnerablity self
    Dim unvulval As New modValue(invulduration, eModifierType.Invulnerability, occurencetime, aghstime)
    unvulval.mValueDuration = invulduration

    Dim invul As New Modifier(unvulval, notargetself)
    outmods.Add(invul)

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
