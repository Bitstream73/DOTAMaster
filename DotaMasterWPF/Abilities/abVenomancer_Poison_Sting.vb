Public Class abPoison_Sting
  Inherits AbilityBase


  Public damageovertime As ValueWrapper
  Public slow As ValueWrapper
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

    mDisplayName = "Poison Sting"
    mName = eAbilityName.abPoison_Sting
    Me.EntityName = eEntity.abPoison_Sting

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVenomancer

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/venomancer_poison_sting_hp2.png"

    Description = "Adds poison damage to Venomancer's normal attacks, slowing movement speed."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Duration = New ValueWrapper(6, 9, 12, 15)

    damageovertime = New ValueWrapper(5, 10, 15, 20)

    slow = New ValueWrapper(0.11, 0.12, 0.13, 0.14)
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

    Dim damval As New modValue(damageovertime, eModifierType.RightClickDamageoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim slowval As New modValue(slow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(slowmod)


    Return outmods
  End Function


End Class
