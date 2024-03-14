Public Class abThunder_Strike
Inherits AbilityBase
  Public strikes As ValueWrapper
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

    mName = eAbilityName.abThunder_Strike
    Me.EntityName = eEntity.abThunder_Strike

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDisruptor

    mDisplayName = "Thunder Strike"
    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/disruptor_thunder_strike_hp2.png"

    Description = "Repeatedly strikes the targeted unit with lightning. Each strike damages nearby enemy units in a small radius."

    ManaCost = New ValueWrapper(130, 130, 130, 130)

    Cooldown = New ValueWrapper(16, 16, 16, 16)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(40, 60, 80, 100)

    Radius = New ValueWrapper(240, 240, 240, 240)

    strikes = New ValueWrapper(4, 4, 4, 4)

    Duration = New ValueWrapper(6, 6, 6, 6)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetauraenemyunits = Helpers.GetUnitTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.Charges = strikes
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetauraenemyunits)
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
