Public Class abAmplify_Damage
Inherits AbilityBase
  Public armorreduction As ValueWrapper
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

    mDisplayName = "Amplify Damage"
    mName = eAbilityName.abAmplify_Damage
    Me.EntityName = eEntity.abAmplify_Damage

    'mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlardar

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slardar_amplify_damage_hp2.png"

    Description = "Reduces enemy armor to amplify physical damage and provides True Sight of the targeted unit, revealing invisibility."

    ManaCost = New ValueWrapper(25, 25, 25)

    Cooldown = New ValueWrapper(5, 5, 5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    armorreduction = New ValueWrapper(10, 15, 20)

    Duration = New ValueWrapper(25, 25, 25)
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

    Dim armval As New modValue(armorreduction, eModifierType.ArmorSubtracted, occurencetime, aghstime)
    armval.mValueDuration = Duration

    Dim armmod As New Modifier(armval, unittargetenemy)
    outmods.Add(armmod)


    Dim siteval As New modValue(Duration, eModifierType.TruesightofTarget, occurencetime, aghstime)
    siteval.mValueDuration = Duration

    Dim sitemod As New Modifier(siteval, unittargetenemy)
    outmods.Add(sitemod)


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
