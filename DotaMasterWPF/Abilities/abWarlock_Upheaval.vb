Public Class abUpheaval
Inherits AbilityBase
  Public slowpersecond As ValueWrapper
  Public slowperinterval As ValueWrapper
  Public maxmoveslow As ValueWrapper
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

    mDisplayName = "Upheaval"
    mName = eAbilityName.abUpheaval
    Me.EntityName = eEntity.abUpheaval

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWarlock

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/warlock_upheaval_hp2.png"

    Description = "CHANNELED - A powerful slowing current that grows stronger as it's channelled. Lasts up to 16 seconds, slowing enemies up to 84%. Enemies are slowed for 3 seconds after leaving the area or the spell ends."

    ManaCost = New ValueWrapper(100, 110, 120, 130)

    Cooldown = New ValueWrapper(50, 46, 42, 38)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(650, 650, 650, 650)

    Duration = New ValueWrapper(16, 16, 16, 16)

    slowpersecond = New ValueWrapper(0.07, 0.14, 0.21, 0.28)

    slowperinterval = New ValueWrapper(slowpersecond.Value(0) / 2, _
                                       slowpersecond.Value(1) / 2, _
                                       slowpersecond.Value(2) / 2, _
                                       slowpersecond.Value(3) / 2)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim slowval As New modValue(slowperinterval, eModifierType.MoveSpeedPercentStackSubtracted, New ValueWrapper(0.5, 0.5, 0.5, 0.5), occurencetime, aghstime)
    slowval.mValueDuration = Duration
    slowval.mValueMax = maxmoveslow

    Dim slowmod As New Modifier(slowval, pointtargetenemies)
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
