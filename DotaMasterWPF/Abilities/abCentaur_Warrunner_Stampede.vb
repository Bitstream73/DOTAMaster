Public Class abStampede
Inherits AbilityBase
  Public chargeduration As ValueWrapper
  Public strengthmultDamage As ValueWrapper
  Public slowduration As ValueWrapper
  Public trampleradius As ValueWrapper
  Public moveslow As ValueWrapper
  Public hastemovespeed As ValueWrapper
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
    mDisplayName = "Stampede"
    mName = eAbilityName.abStampede
    Me.EntityName = eEntity.abStampede

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCentaur_Warrunner

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/centaur_stampede_hp2.png"

    Description = "Centaur leads all allies into a vicious charge causing them to move through units at max speed and slow enemy units they tread upon. Each enemy can be trampled once and takes damage based on the Warrunner's strength."

    ManaCost = New ValueWrapper(100, 100, 100)

    Cooldown = New ValueWrapper(90, 75, 60)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untAlliedUnits)

    chargeduration = New ValueWrapper(3.75, 3.75, 3.75)

    strengthmultDamage = New ValueWrapper(1, 2, 3)

    slowduration = New ValueWrapper(1.5, 1.5, 1.5)

    trampleradius = New ValueWrapper(105, 105, 105)

    moveslow = New ValueWrapper(1, 1, 1)

    hastemovespeed = New ValueWrapper(522, 522, 522)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetalliedteam = Helpers.GetNoTargetAlliedTeamInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim unitteamenemyunits = Helpers.GetUnitTeamEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim damval As New modValue(strengthmultDamage, eModifierType.StrengthPercentageAsAllDamage, occurencetime, aghstime)
    damval.mRadius = trampleradius

    Dim dammod As New Modifier(damval, unitteamenemyunits)
    outmods.Add(dammod)



    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mRadius = trampleradius
    slowval.mValueDuration = chargeduration

    Dim slowmod As New Modifier(slowval, unitteamenemyunits)
    outmods.Add(slowmod)


    'Haste http://dota2.gamepedia.com/Movement_Speed#Haste
    Dim moveval As New modValue(hastemovespeed, eModifierType.MoveSpeedMinimum, occurencetime, aghstime)
    moveval.mValueDuration = chargeduration

    Dim movemod As New Modifier(moveval, notargetalliedteam)
    outmods.Add(movemod)


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
