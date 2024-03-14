Public Class abLaser
  Inherits AbilityBase
  Public missrate As ValueWrapper
  Public scepterrange As New List(Of Double?)
  Public blinddurationhero As ValueWrapper
  Public blinddurationcreep As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "This ability can be upgraded by Aghanim's Scepter." '"

    mDisplayName = "Laser"
    mName = eAbilityName.abLaser
    Me.EntityName = eEntity.abLaser

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTinker

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tinker_laser_hp2.png"

    Description = "Fires an intense energy beam, dealing damage and blinding the target for 3 seconds, causing it to miss all physical attacks. Its range is doubled with Aghanim's Scepter."

    ManaCost = New ValueWrapper(95, 120, 145, 170)

    Cooldown = New ValueWrapper(14, 14, 14, 14)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    Damage = New ValueWrapper(80, 160, 240, 320)

    missrate = New ValueWrapper(1, 1, 1, 1)

    Range = New ValueWrapper(550, 550, 550, 550)
    scepterrange.Add(2 * Range.Value(0))
    scepterrange.Add(2 * Range.Value(1))
    scepterrange.Add(2 * Range.Value(2))
    scepterrange.Add(2 * Range.Value(3))
    Range.LoadScepterValues(scepterrange)


    blinddurationhero = New ValueWrapper(3, 3, 3, 3)

    blinddurationcreep = New ValueWrapper(6, 6, 6, 6)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffected As New List(Of eUnit)
    theaffected.Add(eUnit.untEnemyHero)
    theaffected.Add(eUnit.untEnemyCreep)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffected)

    Dim damval As New modValue(Damage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetmulti)
    outmods.Add(thedamage)

    Dim unittargethero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim unittargetCreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim blindvalhero As New modValue(1, eModifierType.BlindChance, occurencetime)
    blindvalhero.mValueDuration = blinddurationhero


    Dim blindhero As New Modifier(blindvalhero, unittargethero)
    outmods.Add(blindhero)



    Dim blindvalcreep As New modValue(1, eModifierType.BlindChance, occurencetime)
    blindvalhero.mValueDuration = blinddurationcreep

    Dim blindcreep As New Modifier(blindvalcreep, unittargetCreep)
    outmods.Add(blindcreep)


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
