Public Class abFissure
Inherits AbilityBase

  Public stunduration As ValueWrapper
  Public fissurerange As ValueWrapper
  Public fissureduration As ValueWrapper
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

    Notes = "Fissure's pathing blocking width is approximately 80.|Flying units (e.g. Flying Courier (Radiant) icon.png Flying Courier or Summon Familiars icon.png Summon Familiars) and units with free pathing ({Spectral Dagger icon.png Spectral Dagger, Charge of Darkness icon.png Charge of Darkness, Spin Web icon.png Spin Web) are not blocked by Fissure icon.png Fissure.|They still are fully affected by Fissure icon.png Fissure otherwise when hit. They are shoved aside, stunned and damaged.|Lane Creeps and neutral creeps (including Roshan) will not try to path around the Fissure icon.png Fissure, but wait for it to disappear.|However, spell immune lane and neutral creeps completely ignore the Fissure icon.png Fissure and can walk through it." '"

    mDisplayName = "Fissure"
    mName = eAbilityName.abFissure
    Me.EntityName = eEntity.abFissure

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarthshaker

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earthshaker_fissure_hp2.png"

    Description = "Slams the ground with a mighty totem, fissuring the earth while stunning and damaging enemy units in a line. Creates an impassable ridge of stone."


    ManaCost = New ValueWrapper(125, 140, 155, 170)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(125, 175, 225, 275)

    fissurerange = New ValueWrapper(1400, 1400, 1400, 1400)

    fissureduration = New ValueWrapper(8, 8, 8, 8)

    stunduration = New ValueWrapper(1, 1.25, 1.5, 1.75)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim lineenemyunits = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim thefissureval As New modValue(1, eModifierType.Barrier, occurencetime)
    thefissureval.mValueDuration = fissureduration

    Dim fissure As New Modifier(thefissureval, lineenemyunits)
    outmods.Add(fissure)



    Dim damval As New modValue(Me.Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim damage As New Modifier(damval, lineenemyunits)
    outmods.Add(damage)



    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, lineenemyunits)
    outmods.Add(thestun)

    Dim pointtargetUnits = Helpers.GetPointTargetUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim barrierval As New modValue(fissureduration, eModifierType.Barrier, occurencetime, aghstime)
    barrierval.mValueDuration = fissureduration
    barrierval.mRange = fissurerange

    Dim barrier As New Modifier(barrierval, pointtargetUnits)
    outmods.Add(barrier)
    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                             caster As iDisplayUnit, _
                                             target As iDisplayUnit, _
                                             ftarget As iDisplayUnit, _
                                             isfriendbias As Boolean, _
                                             occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function

End Class
