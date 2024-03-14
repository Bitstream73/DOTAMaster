Public Class abWex
Inherits AbilityBase


  Public attspeed As ValueWrapper
  Public movespeed As ValueWrapper
  Public agiadded As ValueWrapper
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

    mDisplayName = "Wex"
    mName = eAbilityName.abWex
    Me.EntityName = eEntity.abWex

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_wex_hp2.png"

    Description = "Allows manipulation of storm elements and grants a permanent agility bonus. Each Wex instance provides increased attack speed and movement speed."



    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    attspeed = New ValueWrapper(2, 4, 6, 8, 10, 12, 14)
    movespeed = New ValueWrapper(0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07)
    agiadded = New ValueWrapper(2, 4, 6, 8, 10, 12, 14)

    mStates = New List(Of String)
    mStates.Add("All")
    mStates.Add("W")
    mStates.Add("W,W")
    mStates.Add("W,W,W")


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

    Dim attval As New modValue(attspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)

    Dim moveval As New modValue(movespeed, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)


    Select Case thestateindex
      Case 1
        Dim att1 As New Modifier(attval, toggleself)
        outmods.Add(att1)

        Dim move1 As New Modifier(moveval, toggleself)
        outmods.Add(move1)

      Case 2
        Dim att1 As New Modifier(attval, toggleself)
        outmods.Add(att1)
        Dim att2 As New Modifier(attval, toggleself)
        outmods.Add(att2)

        Dim move1 As New Modifier(moveval, toggleself)
        outmods.Add(move1)
        Dim move2 As New Modifier(moveval, toggleself)
        outmods.Add(move2)

      Case 0, 3
        Dim att1 As New Modifier(attval, toggleself)
        outmods.Add(att1)
        Dim att2 As New Modifier(attval, toggleself)
        outmods.Add(att2)
        Dim att3 As New Modifier(attval, toggleself)
        outmods.Add(att3)

        Dim move1 As New Modifier(moveval, toggleself)
        outmods.Add(move1)
        Dim move2 As New Modifier(moveval, toggleself)
        outmods.Add(move2)
        Dim move3 As New Modifier(moveval, toggleself)
        outmods.Add(move3)


      Case Else

        PageHandler.theLog.writelog("Out of Range Stateindex passed to abInvoker_Wex: " & thestateindex.ToString)
    End Select


    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                 caster, _
                                                 target, _
                                                 "", eModifierCategory.Passive)

    Dim agival As New modValue(agiadded, eModifierType.AgiAdded, occurencetime, aghstime)

    Dim agimod As New Modifier(agival, passiveself)
    outmods.Add(agimod)

    Return outmods


  End Function
End Class
