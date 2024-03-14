Public Class abPowershot
Inherits AbilityBase
  Public channeltime As ValueWrapper
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

    mDisplayName = "Powershot"
    mName = eAbilityName.abPowershot
    Me.EntityName = eEntity.abPowershot

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWindranger

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/windrunner_powershot_hp2.png"

    Description = "Windranger charges her bow for up to 1 second for a single powerful shot. The arrow deals damage to enemy units and destroys trees in its path. Damage is greatest on first target, and reduces by 10% for each target it pierces thereafter. If the channeling is cancelled early, the shot will still occur but deal less damage."

    ManaCost = New ValueWrapper(90, 100, 110, 120)

    Cooldown = New ValueWrapper(9, 9, 9, 9)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(120, 200, 280, 360)

    Range = New ValueWrapper(2600, 2600, 2600, 2600)

    channeltime = New ValueWrapper(2, 2, 2, 2)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointchanneledenemies = Helpers.GetPointTargetChanneledEnemyUnitsInfo(theability_InfoID, _
                                                                              thecaster, _
                                                                              thetarget, _
                                                                              "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.mValueDuration = channeltime

    Dim dammod As New Modifier(damval, pointchanneledenemies)
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
