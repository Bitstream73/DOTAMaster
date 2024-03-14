Public Class abExort
  Inherits AbilityBase


  Public intadded As ValueWrapper
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

    mDisplayName = "Exort"
    mName = eAbilityName.abExort
    Me.EntityName = eEntity.abExort

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_exort_hp2.png"

    Description = "Allows manipulation of fire elements and grants a permanent intelligence bonus. Each Exort instance provides increased attack damage."



    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Damage = New ValueWrapper(3, 6, 9, 12, 15, 18, 21)
    intadded = New ValueWrapper(2, 4, 6, 8, 10, 12, 14)

    mStates = New List(Of String)
    mStates.Add("All")
    mStates.Add("E")
    mStates.Add("E,E")
    mStates.Add("E,E,E")


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim toggleself = Helpers.GetToggleSelfInfo(theability_InfoID, _
                                               thecaster, _
                                               thetarget, _
                                               "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.RightClickDamageAdded, occurencetime, aghstime)

    Select Case thestateindex
      Case 1
        Dim dammod1 As New Modifier(damval, toggleself)
        outmods.Add(dammod1)

      Case 2
        Dim dammod1 As New Modifier(damval, toggleself)
        outmods.Add(dammod1)
        Dim dammod2 As New Modifier(damval, toggleself)
        outmods.Add(dammod2)

      Case 0, 3
        Dim dammod1 As New Modifier(damval, toggleself)
        outmods.Add(dammod1)
        Dim dammod2 As New Modifier(damval, toggleself)
        outmods.Add(dammod2)
        Dim dammod3 As New Modifier(damval, toggleself)
        outmods.Add(dammod3)
      Case Else
        PageHandler.theLog.writelog("Out of Range Stateindex passed to abInvoker_Exort: " & thestateindex.ToString)

    End Select
    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                 caster, _
                                                 target, _
                                                 "", eModifierCategory.Passive)

    Dim intval As New modValue(intadded, eModifierType.IntAdded, occurencetime, aghstime)

    Dim intmod As New Modifier(intval, passiveself)
    outmods.Add(intmod)

    Return outmods
  End Function

End Class
