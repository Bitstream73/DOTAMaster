Public Class abWalrus_Punch
  Inherits AbilityBase

  Public critmultiplier As ValueWrapper
  Public airtime As ValueWrapper
  Public slowduration As ValueWrapper
  Public themoveslow As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Walrus Punch cannot miss.|Victim is stunned during Air Time.|Can punch everything, except for wards, buildings, allied and own units. Tusk will regulary attack those without wasting Walrus Punch.|Roshan will not be knocked up, he will be regularly stunned for the same duration instead.|If Tusk doesn't land an attack during the buff duration, the bonus is lost.|Can Cleave with a Battle Fury.|Can be activated during Snowball." '"

    mDisplayName = "Walrus Punch!"
    mName = eAbilityName.abWalrus_Punch
    Me.EntityName = eEntity.abWalrus_Punch

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTusk

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tusk_walrus_punch_hp2.png"

    Description = "Tusk prepares his mighty Walrus Punch; his next attack will do a critical strike and launch the victim into the air. The victim will be slowed upon landing and take damage."

    ManaCost = New ValueWrapper(50, 75, 100)
    
    Cooldown = New ValueWrapper(20, 16, 12)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    critmultiplier = New ValueWrapper(3.5, 3.5, 3.5, 3.5)

    airtime = New ValueWrapper(1, 1, 1, 1)

    slowduration = New ValueWrapper(2, 3, 4)

    themoveslow = New ValueWrapper(0.4, 0.4, 0.4, 0.4)

    Duration = New ValueWrapper(10, 10, 10)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                                thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim slowval As New modValue(themoveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim moveslow As New Modifier(slowval, unittargetenemy)
    outmods.Add(moveslow)


    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                               thecaster, _
                                                                thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim critval As New modValue(3.5, eModifierType.CritMultiplier, occurencetime)
    critval.Charges = New ValueWrapper(1, 1, 1)

    Dim critmultiplier As New Modifier(critval, notargetself)
    outmods.Add(critmultiplier)

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
