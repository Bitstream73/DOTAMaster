Public Class abStone_Gaze
Inherits AbilityBase
  Public slow As ValueWrapper
  Public stoneduration As ValueWrapper
  Public bonusphysdamage As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Stone Gaze"
    mName = eAbilityName.abStone_Gaze
    Me.EntityName = eEntity.abStone_Gaze

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMedusa

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/medusa_stone_gaze_hp2.png"

    Description = "Any enemy units looking at Medusa will have their movement and attack speed slowed. If 2 seconds of total time is accumulated looking at Medusa while Stone Gaze is active, that unit will turn to stone. Petrified units are stunned, have 100% magic resistance, and take bonus physical damage. If the petrified unit is an illusion, it is immediately killed."

    ManaCost = New ValueWrapper(200, 200, 200)

    Cooldown = New ValueWrapper(90, 90, 90)
    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(1000, 1000, 1000)

    Duration = New ValueWrapper(6, 6, 6)

    slow = New ValueWrapper(0.5, 0.5, 0.5)

    stoneduration = New ValueWrapper(3, 3, 3)

    bonusphysdamage = New ValueWrapper(0.3, 0.3, 0.3)

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

    Dim slowval As New modValue(slow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, notargetenemies)
    outmods.Add(slowmod)


    Dim attval As New modValue(slow, eModifierType.AttackSpeedPercentSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, notargetenemies)
    outmods.Add(attmod)


    Dim stunval As New modValue(stoneduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stoneduration

    Dim stunmod As New Modifier(stunval, notargetenemies)
    outmods.Add(stunmod)



    Dim magval As New modValue(1, eModifierType.MagicResistanceSet, occurencetime)
    magval.mValueDuration = stoneduration

    Dim magmod As New Modifier(magval, notargetenemies)
    outmods.Add(magmod)


    Dim physmod As New modValue(bonusphysdamage, eModifierType.DamagePhysicalIncomingIncreasedPercent, occurencetime, aghstime)
    physmod.mValueDuration = stoneduration

    Dim phys As New Modifier(physmod, notargetenemies)
    outmods.Add(phys)

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
