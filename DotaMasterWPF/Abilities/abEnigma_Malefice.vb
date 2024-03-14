Public Class abMalefice
Inherits AbilityBase
  Public stunduration As ValueWrapper
  Public damageperhit As ValueWrapper
  Public instancecount As ValueWrapper

  Public affectsinterval As ValueWrapper
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

    mDisplayName = "Malefice"
    mName = eAbilityName.abMalefice

    Me.EntityName = eEntity.abMalefice

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnigma

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enigma_malefice_hp2.png"

    Description = "Focuses Enigma's power on a target, causing it to take damage and become repeatedly stunned for multiple instances. An instance strikes every 2 seconds."

    ManaCost = New ValueWrapper(110, 130, 150, 160)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    stunduration = New ValueWrapper(0.25, 0.5, 0.75, 1)
    damageperhit = New ValueWrapper(25, 40, 55, 70)
    instancecount = New ValueWrapper(3, 3, 3, 3)


    affectsinterval = New ValueWrapper(2, 2, 2, 2)
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

    '3 stuns (charges) with 2 second gap between (affectsinterval) 
    Dim stunval As New modValue(stunduration, eModifierType.Stun, affectsinterval, occurencetime, aghstime)
    stunval.Charges = instancecount

    Dim stunmod As New Modifier(stunval, unittargetenemy)
    outmods.Add(stunmod)


    '3 damages (charges) with 2 second gap between (affectsinterval) 
    Dim damval As New modValue(damageperhit, eModifierType.DamageMagicalInflicted, affectsinterval, occurencetime, aghstime)
    damval.Charges = instancecount

    Dim dammmod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammmod)



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
