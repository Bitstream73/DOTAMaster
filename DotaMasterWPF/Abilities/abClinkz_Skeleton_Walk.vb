Public Class abSkeleton_Walk
Inherits AbilityBase
  Public bonusmovespeed As ValueWrapper
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
    mDisplayName = "Skeleton Walk"
    mName = eAbilityName.abSkeleton_Walk

    Me.EntityName = eEntity.abSkeleton_Walk


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClinkz

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/clinkz_wind_walk_hp2.png"

    Description = "Clinkz moves invisibly through units until the moment he attacks or uses an ability."

    ManaCost = New ValueWrapper(75, 75, 75, 75)


    Cooldown = New ValueWrapper(20, 20, 20, 20)
    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(20, 25, 30, 35)

    bonusmovespeed = New ValueWrapper(0.11, 0.22, 0.33, 0.44)
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

    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration

    Dim invismod As New Modifier(invisval, notargetself)
    outmods.Add(invismod)



    Dim speedval As New modValue(bonusmovespeed, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    speedval.mValueDuration = Duration

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)

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
