Public Class abDemonic_Purge
Inherits AbilityBase
  Public sceptercooldown As New List(Of Double?)

  Public sceptercharges As New List(Of Double?)

  Public avgslow As ValueWrapper 'average of the decreasing slow over time
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Demonic Purge"
    mName = eAbilityName.abDemonic_Purge
    Me.EntityName = eEntity.abDemonic_Purge

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Demon

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_demon_demonic_purge_hp2.png"

    Description = "Purges the target enemy unit, removing positive buffs, and slowing the target for the duration. The unit slowly regains its speed until the end of the duration, upon which damage is dealt. Units under the effect of Disruption can still be affected by Demonic Purge. Upgradable with Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 200, 200)

    Cooldown = New ValueWrapper(50, 50, 50)
    sceptercooldown.Add(40)
    sceptercooldown.Add(40)
    sceptercooldown.Add(40)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(200, 300, 400)

    Duration = New ValueWrapper(5, 5, 5)

    charges = New ValueWrapper(1, 1, 1)
    sceptercharges.Add(3)
    sceptercharges.Add(3)
    sceptercharges.Add(3)
    charges.LoadScepterValues(sceptercharges)

    avgslow = New ValueWrapper((1 + 0.8 + 0.6 + 0.4 + 0.2) / 5, _
                               (1 + 0.6666 + 0.3333) / 3, _
                               (1 + 0.5) / 2)

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

    'debuff
    Dim buffval As New modValue(charges, eModifierType.RemoveBuffs, occurencetime, aghstime)
    buffval.Charges = charges
    buffval.mCooldown = Cooldown

    Dim buffmod As New Modifier(buffval, unittargetenemy)
    outmods.Add(buffmod)

    'slow

    Dim slowval As New modValue(avgslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration
    slowval.Charges = charges
    slowval.mCooldown = Cooldown

    Dim slowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(slowmod)

    'damage
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.Charges = charges

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


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
