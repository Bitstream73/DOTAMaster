Public Class abFury_Swipes
Inherits AbilityBase


  Public resettime As ValueWrapper
  Public resettimeroshan As ValueWrapper

  Public damageperattack As ValueWrapper

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

    mDisplayName = "Fury Swipes"
    mName = eAbilityName.abFury_Swipes
    Me.EntityName = eEntity.abFury_Swipes

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUrsa

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ursa_fury_swipes_hp2.png"

    Description = "Ursa's claws dig deeper wounds in the enemy, causing consecutive attacks to the same enemy to deal more damage. If the same target is not attacked after 15 seconds, the bonus damage is lost."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    resettime = New ValueWrapper(15, 15, 15, 15)

    resettimeroshan = New ValueWrapper(6, 6, 6, 6)

    damageperattack = New ValueWrapper(15, 20, 25, 30)

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

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim unittargetRosh = Helpers.GetUnitTargetRoshanInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)


    Dim damval As New modValue(damageperattack, eModifierType.RightClickDamPhysStackingInflicted, occurencetime, aghstime)
    damval.mValueDuration = resettime

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim damroshval As New modValue(damageperattack, eModifierType.RightClickDamPhysStackingInflicted, occurencetime, aghstime)
    damroshval.mValueDuration = resettimeroshan

    Dim damroshmod As New Modifier(damroshval, unittargetRosh)
    outmods.Add(damroshmod)



    Return outmods
  End Function
End Class
