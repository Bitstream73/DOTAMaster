Public Class abFeral_Impulse
Inherits AbilityBase
  Public bonusattackspeed As ValueWrapper
  Public bonusdamage As ValueWrapper
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

    mDisplayName = "Feral Impulse"
    mName = eAbilityName.abFeral_Impulse
    Me.EntityName = eEntity.abFeral_Impulse

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLycan

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lycan_feral_impulse_hp2.png"

    Description = "Increases the damage and attack speed of Lycan and all units under his control."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(900, 900, 900, 900)

    bonusattackspeed = New ValueWrapper(15, 20, 25, 30)

    bonusdamage = New ValueWrapper(0.15, 0.2, 0.25, 0.3)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveauracontrolledunits = Helpers.GetPassiveAuraControlledUnitsInfo(theability_InfoID, _
                                                                               thecaster, _
                                                                               thetarget, _
                                                                               "", eModifierCategory.Passive)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                               thecaster, _
                                                                               thetarget, _
                                                                               "", eModifierCategory.Passive)

    Dim attval As New modValue(bonusattackspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)

    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)

    Dim attpetmod As New Modifier(attval, passiveauracontrolledunits)
    outmods.Add(attpetmod)




    Dim damval As New modValue(bonusdamage, eModifierType.BonusDamagePercent, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)

    Dim dampetmod As New Modifier(damval, passiveauracontrolledunits)
    outmods.Add(dampetmod)

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
