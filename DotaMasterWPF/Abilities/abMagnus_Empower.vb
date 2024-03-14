Public Class abEmpower
Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public cleavedamage As ValueWrapper
  Public cleaveradius As ValueWrapper
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

    mDisplayName = "Empower"
    mName = eAbilityName.abEmpower
    Me.EntityName = eEntity.abEmpower

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMagnus

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/magnataur_empower_hp2.png"

    Description = "Gives an allied unit bonus damage and cleave on attack."

    ManaCost = New ValueWrapper(30, 40, 50, 60)

    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)
    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(40, 40, 40, 40)

    bonusdamage = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    cleavedamage = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    cleaveradius = New ValueWrapper(200, 200, 200, 200)
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
    theaffects.Add(eUnit.untAlliedUnit)
    Dim unittargetmulit = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim damval As New modValue(bonusdamage, eModifierType.BonusDamagePercent, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetmulit)
    outmods.Add(dammod)


    Dim cleaveval As New modValue(cleavedamage, eModifierType.CleavePercentage, occurencetime, aghstime)
    cleaveval.mRadius = cleaveradius

    Dim cleavemod As New Modifier(cleaveval, unittargetmulit)
    outmods.Add(cleavemod)



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
