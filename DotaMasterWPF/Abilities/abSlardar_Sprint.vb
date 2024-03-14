Public Class abSprint
Inherits AbilityBase
  Public bonusspeed As ValueWrapper
  Public addldamage As ValueWrapper
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

    mDisplayName = "Sprint"
    mName = eAbilityName.abSprint
    Me.EntityName = eEntity.abSprint

    'mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlardar

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slardar_sprint_hp2.png"

    Description = "Slardar moves significantly faster, but takes bonus damage."

    Cooldown = New ValueWrapper(23, 23, 23, 23)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    addldamage = New ValueWrapper(0.15, 0.15, 0.15, 0.15)

    bonusspeed = New ValueWrapper(0.2, 0.28, 0.36, 0.44)

    Duration = New ValueWrapper(16, 16, 16, 16)
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

    Dim moveval As New modValue(bonusspeed, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)


    Dim debuffval As New modValue(addldamage, eModifierType.DamageAllTypesIncomingIncreasesPercent, occurencetime, aghstime)
    debuffval.mValueDuration = Duration

    Dim debuffmod As New Modifier(debuffval, notargetself)
    outmods.Add(debuffmod)


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
