Public Class abQuas
Inherits AbilityBase

  Public bonusstrength As ValueWrapper
  Public HPRegen As ValueWrapper
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

    mDisplayName = "Quas"
    mName = eAbilityName.abQuas
    Me.EntityName = eEntity.abQuas

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_quas_hp2.png"

    Description = "Allows manipulation of ice elements and grants a permanent strength bonus. Each Quas instance provides increased health regeneration. "



    AbilityTypes.Add(eAbilityType.NoTarget)



    Affects.Add(eUnit.untSelf)

    bonusstrength = New ValueWrapper(2, 4, 6, 8, 10, 12, 14)

    HPRegen = New ValueWrapper(1, 2, 3, 4, 5, 6, 7)

    mStates = New List(Of String)
    mStates.Add("All")
    mStates.Add("Q")
    mStates.Add("Q,Q")
    mStates.Add("Q,Q,Q")



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notoggleself = Helpers.GetToggleSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim regenval As New modValue(HPRegen, eModifierType.HealthRegenAdded, occurencetime, aghstime)

    Select Case thestateindex


      Case 1
        Dim mod1 As New Modifier(regenval, notoggleself)
        outmods.Add(mod1)

      Case 2
        Dim mod2 As New Modifier(regenval, notoggleself)
        outmods.Add(mod2)
        Dim mod3 As New Modifier(regenval, notoggleself)
        outmods.Add(mod3)

      Case 0, 3
        Dim mod1 As New Modifier(regenval, notoggleself)
        outmods.Add(mod1)
        Dim mod2 As New Modifier(regenval, notoggleself)
        outmods.Add(mod2)
        Dim mod3 As New Modifier(regenval, notoggleself)
        outmods.Add(mod3)

      Case Else
        PageHandler.theLog.writelog("Out of Range Stateindex passed to abInvoker_Quas: " & thestateindex.ToString)
    End Select

    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList


    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                 caster, _
                                                 target, _
                                                 "", eModifierCategory.Passive)


    Dim strval As New modValue(bonusstrength, eModifierType.StrAdded, occurencetime, aghstime)

    Dim strmod As New Modifier(strval, passiveself)
    outmods.Add(strmod)


    Return outmods
  End Function

End Class
