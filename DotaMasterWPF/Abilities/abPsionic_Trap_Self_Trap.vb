Public Class abPsionic_Trap_Self_Trap
  Inherits AbilityBase

  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mName = eAbilityName.abPsionic_Trap_Self_Trap
    Me.EntityName = eEntity.abPsionic_Trap

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTemplar_Assassin

    mDisplayName = "Self Trap"
    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/a/a7/Psionic_Trap_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Templar_Assassin#Psionic_Trap"
    Description = "Springs the trap, slowing nearby enemies."
    Notes = "This is cast from the trap itself. This allows Templar Assassin to trigger traps from afar without having to trigger nearby traps first.|Has an instant cast time."

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(0.5, 0.5, 0.5)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    Duration = slowduration

    Radius = New ValueWrapper(400, 400, 400)
    moveslow = New ValueWrapper(0.5, 0.5, 0.5)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, notargetauraenemies)
    outmods.Add(slowmod)


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
