Public Class abBurning_Spear
Inherits AbilityBase


  Public healthcost As ValueWrapper
  Public dpsduration As ValueWrapper
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

    mDisplayName = "Burning Spear"
    mName = eAbilityName.abBurning_Spear
    Me.EntityName = eEntity.abBurning_Spear

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHuskar

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/huskar_burning_spear_hp2.png"

    Description = "Huskar sets his spears aflame, dealing damage over time with his regular attack. Multiple attacks will stack additional damage. Each attack drains some of Huskar's health. Lasts 8 seconds."



    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(5, 10, 15, 20)

    dpsduration = New ValueWrapper(8, 8, 8, 8)
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

    Dim damval As New modValue(Damage, eModifierType.RightClickDamageAdded, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = dpsduration

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)


    Dim damself As New modValue(Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim damselfmod As New Modifier(damself, notargetself)
    outmods.Add(damselfmod)


    Return outmods
  End Function
End Class
