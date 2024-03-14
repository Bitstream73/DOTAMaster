Public Class abAphotic_Shield
  Inherits AbilityBase

  Private mAbsorbed_Damage As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mName = eAbilityName.abAphotic_Shield
    Me.EntityName = eEntity.abAphotic_Shield

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAbaddon
    mDisplayName = "Aphotic Shield"
    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/abaddon_aphotic_shield_hp2.png"
    WebpageLink = ""
    Description = "Summons dark energies around an ally unit, creating a shield that absorbs a set amount of damage before expiring. When the shield is destroyed it will burst and deal damage equal to the amount it could absorb to an area around it. Removes certain types of negative buffs and stuns on cast."
    Notes = "If under the effects of Borrowed Time, Abaddon's own Aphotic Shield will not burst.|Will automatically detonate and replace any existing Aphotic Shield already surrounding a target.|Aphotic Shield will burst at the end of its duration if it has not absorbed sufficient damage.|It will always burst for the maximum damage, regardless of how much was absorbed.|Damage is calculated after all reductions.|Can be used on siege creeps.|It will not deal damage to invisible enemy units."


    ManaCost = New ValueWrapper(100, 105, 110, 115)

    Cooldown = New ValueWrapper(12, 10, 8, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untAlliedUnits)

    Duration = New ValueWrapper(15, 15, 15, 15)


    mAbsorbed_Damage = New ValueWrapper(110, 140, 170, 200)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_Info As IUnitUpgrade, thecaster As iDisplayUnit, thetarget As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untSelf)
    theaffects.Add(eUnit.untAlliedHero)

    Dim pointtargetmultiaffectsinfo = Helpers.GetPointTargetMultiAffectsInfo(theability_Info, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active, _
                                                                             theaffects)

    'damage absorption
    Dim absorbval As New modValue(mAbsorbed_Damage, eModifierType.HealAdded, occurencetime, aghstime)
    absorbval.mValueDuration = New ValueWrapper(15, 15, 15, 15) ' New TimeSpan(0, 0, 15)

    Dim damageabsorption As New Modifier(absorbval, pointtargetmultiaffectsinfo)

    outmods.Add(damageabsorption)

    'shield burst
    Dim avtiveauraenemyunits = Helpers.GetActiveAuraEnemyUnitsInfo(theability_Info, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(mAbsorbed_Damage, eModifierType.DamagePhysicalAdded, occurencetime, aghstime)
    Dim damburst As New Modifier(damval, avtiveauraenemyunits)
    outmods.Add(damburst)
    Return outmods
  End Function



End Class
