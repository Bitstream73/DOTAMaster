Public Class abTime_Walk
Inherits AbilityBase
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper

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

    mDisplayName = "Time Walk"
    mName = eAbilityName.abTime_Walk

    Me.EntityName = eEntity.abTime_Walk

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFaceless_Void

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/faceless_void_time_walk_hp2.png"

    Description = "Rushes to a target location while slowing the movement and attack speed of all enemies along its path for 3 seconds."

    ManaCost = New ValueWrapper(90, 90, 90, 90)

    Cooldown = New ValueWrapper(19, 17, 15, 13)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnits)

    moveslow = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    Radius = New ValueWrapper(700, 900, 1100, 1300)

    slowduration = New ValueWrapper(3, 3, 3, 3)
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


    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)


    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, pointtargetenemies)
    outmods.Add(movemod)


    Dim pushval As New modValue(1, eModifierType.PullForward, occurencetime)

    Dim pushmod As New Modifier(pushval, pointtargetself)
    outmods.Add(pushmod)


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
