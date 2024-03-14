Public Class abWarpath
Inherits AbilityBase
  Public damageperstack As ValueWrapper
  Public moveperstack As ValueWrapper
  Public stackduration As ValueWrapper
  Public maxstacks As ValueWrapper
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
    mDisplayName = "Warpath"
    mName = eAbilityName.abWarpath
    Me.EntityName = eEntity.abWarpath

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBristleback

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bristleback_warpath_hp2.png"

    Description = "Bristleback works himself up into a fury every time he casts a spell, increasing his movement speed and damage."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    damageperstack = New ValueWrapper(20, 25, 30)
    moveperstack = New ValueWrapper(0.03, 0.04, 0.05)
    stackduration = New ValueWrapper(14, 14, 14)
    maxstacks = New ValueWrapper(5, 6, 7)



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
                                                    "", eModifierCategory.Passive)



    Dim damstackval As New modValue(damageperstack, eModifierType.DamageAllTypesStackAdded, occurencetime, aghstime)
    damstackval.mValueDuration = stackduration
    damstackval.Charges = maxstacks

    Dim dammod As New Modifier(damstackval, notargetself)
    outmods.Add(dammod)


    Dim slowstackval As New modValue(moveperstack, eModifierType.MoveSpeedPercentStackSubtracted, occurencetime, aghstime)
    slowstackval.mValueDuration = stackduration
    slowstackval.Charges = maxstacks

    Dim slowmod As New Modifier(slowstackval, notargetself)
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
