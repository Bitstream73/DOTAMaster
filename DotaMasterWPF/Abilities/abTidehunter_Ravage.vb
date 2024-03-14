Public Class abRavage
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

    Notes = "Stun duration consists of 0.52 seconds air time + 1.5/1.8/2.25 actual stun time.|The tentacles move outwards at a speed of 775ms.|Damage is applied after the 0.52 seconds air time.|Does not affect ancient creeps, Roshan, Warlock's Golem and Storm and Fire From Primal Split icon.png Primal Split." '"

    mDisplayName = "Ravage"
    mName = eAbilityName.abRavage
    Me.EntityName = eEntity.abRavage

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTidehunter

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tidehunter_ravage_hp2.png"

    Description = "Slams the ground, causing tentacles to erupt in all directions, damaging and stunning all nearby enemy units."

    ManaCost = New ValueWrapper(150, 225, 325)

    Cooldown = New ValueWrapper(150, 150, 150)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(200, 290, 380)

    Duration = New ValueWrapper(2.02, 2.32, 2.77)

    Radius = New ValueWrapper(1025, 1025, 1025)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetaura = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)



    Dim stunval As New modValue(Duration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = Duration

    Dim stun As New Modifier(stunval, notargetaura)



    Dim damval As New modValue(Me.Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim damage As New Modifier(damval, notargetaura)


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
