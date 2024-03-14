Public Class abSoul_Catcher
Inherits AbilityBase
  Public bonusdamage As ValueWrapper
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

    mDisplayName = "Soul Catcher"
    mName = eAbilityName.abSoul_Catcher
    Me.EntityName = eEntity.abSoul_Catcher

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Demon

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_demon_soul_catcher_hp2.png"

    Description = "Curses a random enemy in an area to take increased damage. The bonus damage is dealt as a separate instance of damage. Units under the effect of Disruption can still be affected by Soul Catcher."

    ManaCost = New ValueWrapper(50, 60, 70, 80)

    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    bonusdamage = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    Duration = New ValueWrapper(12, 12, 12, 12)

    Radius = New ValueWrapper(450, 450, 450, 450)


  End Sub
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetAuraEnemyUnitInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim damval As New modValue(bonusdamage, eModifierType.BonusDamage, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, pointtargetenemies)
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
