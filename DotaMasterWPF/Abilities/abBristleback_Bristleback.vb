Public Class abBristleback
Inherits AbilityBase

  Public sidedamagereduction As ValueWrapper
  Public backdamagereduction As ValueWrapper
  Public quillspraydamagethreshold As ValueWrapper
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
    mDisplayName = "Bristleback"
    mName = eAbilityName.abBristleback
    Me.EntityName = eEntity.abBristleback

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBristleback

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bristleback_bristleback_hp2.png"

    Description = "Bristleback takes less damage if hit on the sides or rear. If Bristleback takes 250 damage from the rear, he releases a Quill Spray of the current level."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    sidedamagereduction = New ValueWrapper(0.08, 0.12, 0.16, 0.2)
    backdamagereduction = New ValueWrapper(0.16, 0.24, 0.32, 0.4)

    quillspraydamagethreshold = New ValueWrapper(250, 250, 250, 250)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetattacker = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Passive)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Passive)

    Dim sideval As New modValue(sidedamagereduction, eModifierType.DamageReduction, occurencetime, aghstime)

    Dim sidemod As New Modifier(sideval, notargetself)
    outmods.Add(sidemod)

    Dim backval As New modValue(backdamagereduction, eModifierType.DamageReduction, occurencetime, aghstime)

    Dim backmod As New Modifier(backval, notargetattacker)
    outmods.Add(backmod)


    'quillspray
    Dim quillval As New modValue(1, eModifierType.QuillSprayCast, occurencetime)
    quillval.mThreshold = quillspraydamagethreshold

    Dim quillmod As New Modifier(quillval, notargetattacker)
    outmods.Add(quillmod)

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
