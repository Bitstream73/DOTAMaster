Public Class abBacktrack
  Inherits AbilityBase


  Public dodgechance As ValueWrapper
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

    mDisplayName = "Backtrack"
    mName = eAbilityName.abBacktrack
    Me.EntityName = eEntity.abBacktrack

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFaceless_Void

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/faceless_void_backtrack_hp2.png"

    Description = "Faceless Void dodges damage by jumping backward in time, eluding both physical and magical attacks."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)


    dodgechance = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

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
                                                   "", eModifierCategory.Passive)

    Dim dodgeval As New modValue(dodgechance, eModifierType.RightClickDamageInstanceAvoided, occurencetime, aghstime)

    Dim dodgemod As New Modifier(dodgeval, notargetself)
    outmods.Add(dodgemod)





    Return outmods
  End Function
End Class
