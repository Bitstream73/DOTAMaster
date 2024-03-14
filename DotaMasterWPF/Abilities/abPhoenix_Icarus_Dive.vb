Public Class abIcarus_Dive
Inherits AbilityBase
  Public hpcost As ValueWrapper
  Public divelength As ValueWrapper
  Public burnduration As ValueWrapper
  Public dps As ValueWrapper
  Public moveslow As ValueWrapper
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

    mDisplayName = "Icarus Dive"
    mName = eAbilityName.abIcarus_Dive
    Me.EntityName = eEntity.abIcarus_Dive

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhoenix

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phoenix_icarus_dive_hp2.png"

    Description = "Phoenix dives forward in an arc with a fixed distance in the targeted direction, dealing damage over time and slowing the movement speed of any units it comes into contact with, and then orbiting back to its original position. If Phoenix casts Supernova, the dive ends."


    Cooldown = New ValueWrapper(36, 36, 36, 36)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    hpcost = New ValueWrapper(0.15, 0.15, 0.15, 0.15)

    divelength = New ValueWrapper(1400, 1400, 1400, 1400)

    burnduration = New ValueWrapper(4, 4, 4, 4)

    dps = New ValueWrapper(10, 30, 50, 70)

    moveslow = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim pointtargetenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim pushval As New modValue(1, eModifierType.PushForward, occurencetime)
    pushval.mRange = divelength

    Dim pushmod As New Modifier(pushval, pointtargetself)
    outmods.Add(pushmod)



    Dim damval As New modValue(dps, eModifierType.DamageMagicalPerSec, occurencetime, aghstime)
    damval.mValueDuration = burnduration

    Dim dammod As New Modifier(damval, pointtargetenemies)
    outmods.Add(dammod)



    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = burnduration

    Dim slowmod As New Modifier(slowval, pointtargetenemies)
    outmods.Add(slowmod)

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
