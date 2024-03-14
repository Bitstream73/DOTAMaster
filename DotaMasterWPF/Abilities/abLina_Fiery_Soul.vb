Public Class abFiery_Soul
Inherits AbilityBase


  Public attspeedbonus As ValueWrapper
  Public movespeedbonus As ValueWrapper
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

    mDisplayName = "Fiery Soul"
    mName = eAbilityName.abFiery_Soul
    Me.EntityName = eEntity.abFiery_Soul

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLina

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lina_fiery_soul_hp2.png"

    Description = "Grants bonus attack and movement speed each time Lina casts a spell. Stacks with itself. Lasts 9 seconds."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    attspeedbonus = New ValueWrapper(40, 55, 70, 85)

    movespeedbonus = New ValueWrapper(0.05, 0.06, 0.07, 0.08)

    maxstacks = New ValueWrapper(3, 3, 3, 3)

    Duration = New ValueWrapper(10, 10, 10, 10)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
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

    Dim moveval As New modValue(movespeedbonus, eModifierType.MoveSpeedStackAdded, occurencetime, aghstime)
    moveval.Charges = maxstacks
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)


    Dim attval As New modValue(attspeedbonus, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.Charges = maxstacks
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)




    Return outmods
  End Function
End Class
