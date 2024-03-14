Public Class abHoof_Stomp
Inherits AbilityBase
  Public stunduration As ValueWrapper

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
    mDisplayName = "Hoof Stomp"
    mName = eAbilityName.abHoof_Stomp
    Me.EntityName = eEntity.abHoof_Stomp


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCentaur_Warrunner

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/centaur_hoof_stomp_hp2.png"

    Description = "Slams the ground, stunning and damaging nearby enemy units."

    ManaCost = New ValueWrapper(130, 130, 130, 130)

    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Radius = New ValueWrapper(315, 315, 315, 315)

    stunduration = New ValueWrapper(2, 2.25, 2.5, 2.75)

    Damage = New ValueWrapper(100, 150, 200, 250)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetauraenemies)
    outmods.Add(dammod)


    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration


    Dim stunmod As New Modifier(stunval, notargetauraenemies)
    outmods.Add(stunmod)
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
