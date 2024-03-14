Public Class abShapeshift
Inherits AbilityBase
  Public movespeed As ValueWrapper
  Public BonusNightVision As ValueWrapper
  Public critchance As ValueWrapper
  Public critdamage As ValueWrapper

  Public transformtime As ValueWrapper

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

    mDisplayName = "Shapeshift"
    mName = eAbilityName.abShapeshift
    Me.EntityName = eEntity.abShapeshift

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLycan

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lycan_shapeshift_hp2.png"

    Description = "Lycan assumes his true form, increasing his combat capabilities. During Shapeshift, Lycan and all units under his control move at maximum speed and cannot be slowed."

    ManaCost = New ValueWrapper(100, 100, 100)

    Cooldown = New ValueWrapper(120, 90, 60)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(18, 18, 18)

    movespeed = New ValueWrapper(650, 650, 650)

    BonusNightVision = New ValueWrapper(1000, 1000, 1000)

    critchance = New ValueWrapper(0.3, 0.3, 0.3)

    critdamage = New ValueWrapper(1.7, 1.7, 1.7)

    transformtime = New ValueWrapper(1.5, 1.5, 1.5)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim notargetcontrolledunits = Helpers.GetNoTargetControlledUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)



    Dim moveval As New modValue(movespeed, eModifierType.MoveSpeedSet, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim moveself As New Modifier(moveval, notargetself)
    outmods.Add(moveself)

    Dim moveothers As New Modifier(moveval, notargetcontrolledunits)
    outmods.Add(moveothers)


    Dim visionval As New modValue(BonusNightVision, eModifierType.VisionNightAdded, occurencetime, aghstime)
    visionval.mValueDuration = Duration

    Dim vismod As New Modifier(visionval, notargetself)
    outmods.Add(vismod)

    Dim critval As New modValue(critdamage, eModifierType.CritDamage, occurencetime, aghstime)
    critval.mValueDuration = critchance

    Dim critmod As New Modifier(critval, notargetself)
    outmods.Add(critmod)



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
