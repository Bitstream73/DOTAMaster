Public Class abGush
  Inherits AbilityBase
  Private mslow As ValueWrapper
  Private mArmorReduction As ValueWrapper
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

    Notes = "Can be disjointed.|Projectile speed is 4000ms." '"

    mDisplayName = "Gush"
    mName = eAbilityName.abGush
    Me.EntityName = eEntity.abGush

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTidehunter

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tidehunter_gush_hp2.png"

    Description = "Summons a gush of water to damage an enemy unit, reducing their movement speed and armor. Lasts 4 seconds."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(110, 160, 210, 260)

    mslow = New ValueWrapper(0.4, 0.4, 0.4, 0.4)

    mArmorReduction = New ValueWrapper(2, 3, 4, 5)
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

    Dim magicdamage As New Modifier(damval, unittargetenemy)
    outmods.Add(magicdamage)


    Dim slowval As New modValue(mslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = New ValueWrapper(4, 4, 4, 4)

    Dim moveslow As New Modifier(slowval, unittargetenemy)
    outmods.Add(moveslow)


    Dim armorreductionval As New modValue(mArmorReduction, eModifierType.ArmorSubtracted, occurencetime, aghstime)
    armorreductionval.mValueDuration = slowval.mValueDuration

    Dim armorreduction As New Modifier(armorreductionval, unittargetenemy)
    outmods.Add(armorreduction)
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
