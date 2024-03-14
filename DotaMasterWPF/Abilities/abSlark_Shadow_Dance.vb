Public Class abShadow_Dance
Inherits AbilityBase
  Public bonusmovespeed As ValueWrapper
  Public healthregenpersec As ValueWrapper
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

    mDisplayName = "Shadow Dance"
    mName = eAbilityName.abShadow_Dance
    Me.EntityName = eEntity.abShadow_Dance

    ' mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlark

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slark_shadow_dance_hp2.png"

    Description = "When used, Slark hides himself in a cloud of shadows, becoming immune to detection. Attacking, casting spells, and using items will not reveal Slark. Passively, when not visible to the enemy team, Slark gains bonus movement speed and health regeneration."

    ManaCost = New ValueWrapper(120, 120, 120)

    Cooldown = New ValueWrapper(69, 60, 60)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(4, 4, 4)

    bonusmovespeed = New ValueWrapper(0.3, 0.35, 0.4)

    healthregenpersec = New ValueWrapper(0.03, 0.05, 0.07)

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


    Dim moveval As New modValue(bonusmovespeed, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)



    Dim healthval As New modValue(healthregenpersec, eModifierType.HPRegenPercent, occurencetime, aghstime)
    healthval.mValueDuration = Duration

    Dim healthmod As New Modifier(healthval, notargetself)
    outmods.Add(healthmod)



    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration

    Dim invismod As New Modifier(invisval, notargetself)
    outmods.Add(invismod)


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
