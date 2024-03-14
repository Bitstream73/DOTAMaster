Public Class abAlacrity
Inherits AbilityBase
  Public attackspeedbonus As ValueWrapper
  Public attackdamagebonus As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = True

    Notes = "Alacrity can be cast on siege creeps." '"

    mDisplayName = "Alacrity"
    mName = eAbilityName.abAlacrity
    Me.EntityName = eEntity.abAlacrity

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_alacrity_hp2.png"

    Description = "Invoker infuses an ally with an immense surge of energy, increasing their attack speed based on the level of Wex and their damage based on the level of Exort."

    ManaCost = New ValueWrapper(45, 45, 45, 45, 45, 45, 45)

    Cooldown = New ValueWrapper(15, 15, 15, 15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnits)



    Duration = New ValueWrapper(9, 9, 9, 9, 9, 9, 9)

    attackspeedbonus = New ValueWrapper(20, 30, 40, 50, 60, 70, 80)
    attackdamagebonus = New ValueWrapper(20, 30, 40, 50, 60, 70, 80)

    Radius = New ValueWrapper(9, 9, 9, 9, 9, 9, 9)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                      thecaster As iDisplayUnit, _
                                                     thetarget As iDisplayUnit, _
                                                      ftarget As iDisplayUnit, _
                                                      isfriendbias As Boolean, _
                                                      occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untSelf)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untAlliedCreep)

    Dim targetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active, theaffects)

    Dim attval As New modValue(attackspeedbonus, eModifierType.wexAttackSpeedAdded, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, targetmulti)
    outmods.Add(attmod)

    Dim damval As New modValue(attackdamagebonus, eModifierType.ExortRightClickBonusDamageAdded, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, targetmulti)
    outmods.Add(dammod)

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
