Public Class abParalyzing_Cask
Inherits AbilityBase

  Public herostunduration As ValueWrapper
  Public creepstunduration As ValueWrapper
  Public herodamage As ValueWrapper
  Public bounces As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Targets can be hit multiple times, as long as another unit is struck in between the bounces.|Will not bounce to enemies hidden by invisibility, but will to enemies in fog of war.|Can hit the main target up to 2/3/4/5 times, making the max damage done is 100/150/200/250 (150/300/500/750 to creeps).|Cask will bounce to magic immune units but won't stun them|Paralayzing cask is not disjointable." '"

    mDisplayName = "Paralyzing Cask"
    mName = eAbilityName.abParalyzing_Cask
    Me.EntityName = eEntity.abParalyzing_Cask

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWitch_Doctor

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/witch_doctor_paralyzing_cask_hp2.png"

    Description = "Launches a cask of paralyzing powder that ricochets between enemy units, stunning and damaging those it hits."

    ManaCost = New ValueWrapper(110, 120, 130, 140)

    Cooldown = New ValueWrapper(20, 18, 16, 14)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(75, 100, 125, 150)

    herostunduration = New ValueWrapper(1, 1, 1, 1)

    creepstunduration = New ValueWrapper(5, 5, 5, 5)

    herodamage = New ValueWrapper(50, 50, 50, 50)

    bounces = New ValueWrapper(2, 4, 6, 8)

    charges = New ValueWrapper(bounces.Value(0) + 1, bounces.Value(1) + 1, bounces.Value(2) + 1, bounces.Value(3) + 1)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemis = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)


    Dim herostunval As New modValue(herostunduration, eModifierType.StunChain, occurencetime, aghstime)
    herostunval.mValueDuration = herostunduration
    herostunval.Charges = charges


    Dim herostun As New Modifier(herostunval, unittargetenemis)
    outmods.Add(herostun)



    Dim creepstunval As New modValue(creepstunduration, eModifierType.StunChain, occurencetime, aghstime)
    creepstunval.mValueDuration = creepstunduration
    creepstunval.Charges = charges

    Dim creepstun As New Modifier(creepstunval, unittargetenemis)
    outmods.Add(creepstun)



    Dim damval As New modValue(Damage, eModifierType.DamageChainMagicalInflicted, occurencetime, aghstime)
    damval.Charges = charges

    Dim thedamage As New Modifier(damval, unittargetenemis)
    outmods.Add(thedamage)



    Dim herodamval As New modValue(herodamage, eModifierType.DamageChainMagicalInflicted, occurencetime, aghstime)
    herodamval.Charges = charges

    Dim theherodamage As New Modifier(herodamval, unittargetenemis)
    outmods.Add(theherodamage)

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
