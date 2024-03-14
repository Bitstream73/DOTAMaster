Public Class abMidnight_Pulse
Inherits AbilityBase
  Public maxhealthasdamage As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Midnight Pulse"
    mName = eAbilityName.abMidnight_Pulse

    Me.EntityName = eEntity.abMidnight_Pulse

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnigma

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enigma_midnight_pulse_hp2.png"

    Description = "Steeps an area in dark resonance, damaging enemy units based on their max HP."


    ManaCost = New ValueWrapper(95, 110, 125, 140)


    Cooldown = New ValueWrapper(25, 25, 25, 25)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure

    Duration = New ValueWrapper(11, 11, 11, 11)

    Radius = New ValueWrapper(600, 600, 600, 600)

    Range = New ValueWrapper(700, 700, 700, 700)

    maxhealthasdamage = New ValueWrapper(0.03, 0.0375, 0.045, 0.0525)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetauraenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(maxhealthasdamage, eModifierType.DamagePureAsPercentofMaxHP, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetauraenemies)
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
