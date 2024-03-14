Public Class abVoid
Inherits AbilityBase

  Public dayduration As ValueWrapper
  Public nightduration As ValueWrapper

  Public moveslow As ValueWrapper
  Public attackslow As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Void"
    mName = eAbilityName.abVoid

    Me.EntityName = eEntity.abVoid

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNight_Stalker

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/night_stalker_void_hp2.png"

    Description = "Creates a damaging void that slows an enemy unit and deals damage. Void also mini-stuns, interrupting channeling abilities. The slowing effect lasts longer at night."

    ManaCost = New ValueWrapper(80, 90, 100, 110)

    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(90, 160, 255, 335) '

    dayduration = New ValueWrapper(2, 2, 2, 2)

    nightduration = New ValueWrapper(4, 4, 4, 4)

    moveslow = New ValueWrapper(0.5, 0.5, 0.5, 0.5)
    attackslow = New ValueWrapper(35, 35, 35, 35)

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

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim moveval As New modValue(moveslow, eModifierType.VoidMoveSpeedPercentSubtracted, occurencetime, aghstime)

    Dim movemod As New Modifier(moveval, unittargetenemy)
    outmods.Add(movemod)


    Dim slowval As New modValue(attackslow, eModifierType.NightAttackSpeedSubtracted, occurencetime, aghstime)

    Dim sowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(sowmod)


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
