Public Class abSearing_Chains
Inherits AbilityBase
  Public damagepersec As ValueWrapper
  Public totaldamage As ValueWrapper

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

    mDisplayName = "Searing Chains"
    mName = eAbilityName.abSearing_Chains
    Me.EntityName = eEntity.abSearing_Chains

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEmber_Spirit

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ember_spirit_searing_chains_hp2.png"

    Description = "Ember Spirit unleashes fiery bolas that wrap around nearby enemies, anchoring them in place and dealing damage each second."

    ManaCost = New ValueWrapper(110, 110, 110, 110)

    Cooldown = New ValueWrapper(14, 12, 10, 8)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(1, 2, 2, 3)

    Radius = New ValueWrapper(400, 400, 400, 400)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notarget2randomenemies = Helpers.GetNoTargetTwoRandomEnemyUnitsInfo(theability_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "", eModifierCategory.Active)

    Dim damval As New modValue(damagepersec, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, notarget2randomenemies)
    outmods.Add(dammod)


    Dim snareval As New modValue(Duration, eModifierType.MuteMove, occurencetime, aghstime)
    snareval.mValueDuration = Duration

    Dim snaremod As New Modifier(snareval, notarget2randomenemies)
    outmods.Add(snaremod)

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
