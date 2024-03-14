Public Class abShukuchi
Inherits AbilityBase

  Public fadetime As ValueWrapper
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

    Notes = "Shukuchi icon.png Shukuchi has an instant cast time and does not interrupt channeling spells.|Shukuchi icon.png Shukuchi can only damage the same unit once per cast.|Shukuchi icon.png Shukuchi hastes Weaver, means he cannot be slowed by anything.|During the fade time, Weaver can cast spells, use items and perform attacks without breaking the invisibility.|Invisibility is broken upon reaching the cast point of spells or items, or upon launching an attack.|Shukuchi icon.png Shukuchi allows Weaver to path through other units, including wards, but not through buildings.|Weaver can pick up or drop items without breaking the invisibility." '"

    mDisplayName = "Shukuchi"
    mName = eAbilityName.abShukuchi
    Me.EntityName = eEntity.abShukuchi

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWeaver

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/weaver_shukuchi_hp2.png"

    Description = "Weaver shifts out of visibility, gaining the ability to move at maximum speed through physical units--doing harm to any enemies it passes through."

    ManaCost = New ValueWrapper(60, 60, 60, 60)

    Cooldown = New ValueWrapper(12, 10, 8, 6)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(75, 100, 125, 150)

    Radius = New ValueWrapper(175, 175, 175, 175)

    fadetime = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    Duration = New ValueWrapper(4, 4, 4, 4)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetenemies = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, notargetenemies)
    outmods.Add(thedamage)



    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)





    Dim phaseval As New modValue(Duration, eModifierType.Phase_Form, occurencetime, aghstime)
    phaseval.mValueDuration = Duration

    Dim phase As New Modifier(phaseval, notargetself)
    outmods.Add(phase)



    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration

    Dim invisibility As New Modifier(invisval, notargetself)
    outmods.Add(invisibility)

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
