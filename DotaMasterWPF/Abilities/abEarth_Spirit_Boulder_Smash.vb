Public Class abBoulder_Smash
Inherits AbilityBase

  Public remnantsmashreadius As ValueWrapper
  Public stunduration As ValueWrapper
  Public travelspeed As ValueWrapper
  Public distance As ValueWrapper
  Public distanceremnant As ValueWrapper
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

    mDisplayName = "Boulder Smash"
    mName = eAbilityName.abBoulder_Smash
    Me.EntityName = eEntity.abBoulder_Smash

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Spirit

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earth_spirit_boulder_smash_hp2.png"

    Description = "Earth Spirit smashes the target enemy, ally, or Stone Remnant, knocking it back in the direction he is facing. The knocked back target deals damage to all units it hits. If the target was a Stone Remnant, damaged targets are also stunned, and the travel distance is improved."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(22, 18, 14, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untHeroes)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(125, 125, 125, 125)

    Radius = New ValueWrapper(200, 200, 200, 200)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemyunits = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemyunits)
    outmods.Add(dammod)


    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, pointtargetlineenemyunits)
    outmods.Add(stunmod)


    Dim knockval As New modValue(1, eModifierType.Knockback, occurencetime)

    Dim knockmod As New Modifier(knockval, pointtargetlineenemyunits)
    outmods.Add(knockmod)


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
