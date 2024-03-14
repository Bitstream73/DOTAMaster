Public Class abReincarnation
  Inherits AbilityBase


  Public reincarntime As ValueWrapper
  Public moveslow As ValueWrapper

  Public attspeedslow As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Reincarnation"
    mName = eAbilityName.abReincarnation
    Me.EntityName = eEntity.abReincarnation

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWraith_King

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skeleton_king_reincarnation_hp2.png"

    Description = "Wraith King's members regroup after death, allowing him to resurrect when killed in battle. Upon death, enemy units in a 900 radius will be slowed."

    ManaCost = New ValueWrapper(160, 160, 160)

    Cooldown = New ValueWrapper(260, 160, 60)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    reincarntime = New ValueWrapper(3, 3, 3)
    moveslow = New ValueWrapper(0.75, 0.75, 0.75)

    attspeedslow = New ValueWrapper(75, 75, 75)

    slowduration = New ValueWrapper(5, 5, 5)
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

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    'enemy slow
    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmod As New Modifier(slowval, activeauraenemies)
    outmods.Add(slowmod)


    'att speed slow
    Dim attval As New modValue(attspeedslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, activeauraenemies)
    outmods.Add(attmod)

    'reincarnate
    Dim carval As New modValue(New ValueWrapper(1, 1, 1), eModifierType.Reincarnate, occurencetime, aghstime)

    Dim carmod As New Modifier(carval, notargetself)
    outmods.Add(carmod)

    Return outmods
  End Function
End Class
