Public Class abX_Marks_The_Spot
Inherits AbilityBase

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Cannot be dispelled by anything, but becoming spell immune or invulnerable will make the target not return to the X when the duration ends or Return has been cast.|Interrupts channeling spells upon returning.|Provides 300 radius ground vision around the X mark for 5.94 seconds.|The affected unit leaves behind red lines while walking, showing in which direction he went." '"

    mName = eAbilityName.abX_Marks_The_Spot
    Me.EntityName = eEntity.abX_Marks_The_Spot

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKunkka

    mAbilityPosition = 3

    mDisplayName = "X Marks the Spot"
    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/kunkka_x_marks_the_spot_hp2.png"

    Description = "Targets a friendly or enemy Hero, marks their position with an X, and returns them to it after several seconds. Kunkka can trigger the return at any time during the duration. Lasts twice as long on allied heroes."

    ManaCost = New ValueWrapper(80, 80, 80, 80)

    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)




End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untEnemyHero)


    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim returnval As New modValue(1, eModifierType.Pullback, occurencetime)

    Dim thereturn As New Modifier(returnval, unittargetmulti)
    outmods.Add(thereturn)


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
