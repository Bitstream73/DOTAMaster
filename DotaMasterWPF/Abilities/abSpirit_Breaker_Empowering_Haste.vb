Public Class abEmpowering_Haste
Inherits AbilityBase


  Public bonusmovespeed As ValueWrapper
  Public auraradius As ValueWrapper
  Public castaddedbonusspeed As ValueWrapper
  Public castaddedspeedduration As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Has an instant cast time.|While active, Empowering Haste increases from 6/10/14/18% to 9/15/21/27%.|While on cooldown, Empowering Haste decreases from 6/10/14/18% to 3/5/7/9%.|Reseting the cooldown with Refresher Orb also resets the movement speed bonus back to the standard values (6%/10%/14%/18%)" '"

    mDisplayName = "Empowering Haste"
    mName = eAbilityName.abEmpowering_Haste

    Me.EntityName = eEntity.abEmpowering_Haste

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Breaker

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/spirit_breaker_empowering_haste_hp2.png"

    Description = "Causes the Spirit Breaker to gain power with higher movement speed. His presence increases the movement speed of nearby allied units."

    Cooldown = New ValueWrapper(16, 16, 16, 16)

    AbilityTypes.Add(eAbilityType.Passive)
    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untSelf)

    bonusmovespeed = New ValueWrapper(0.06, 0.1, 0.14, 0.18)

    auraradius = New ValueWrapper(900, 900, 900, 900)

    castaddedbonusspeed = New ValueWrapper(0.03, 0.05, 0.07, 0.09)

    castaddedspeedduration = New ValueWrapper(6, 6, 6, 6)
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

    Dim moveval As New modValue(castaddedbonusspeed, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    moveval.mValueDuration = castaddedspeedduration

    Dim themove As New Modifier(moveval, notargetself)
    outmods.Add(themove)




    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    theowner As idisplayunit, _
                                                    thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim moveval As New modValue(bonusmovespeed, eModifierType.MoveSpeedAdded, occurencetime, aghstime)

    Dim themove As New Modifier(moveval, notargetself)
    outmods.Add(themove)


    Dim auraallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                            theowner, _
                                                            thetarget, _
                                                            "", eModifierCategory.Passive)

    Dim allymove As New Modifier(moveval, auraallies)
    outmods.Add(allymove)

    Return outmods
  End Function
End Class
