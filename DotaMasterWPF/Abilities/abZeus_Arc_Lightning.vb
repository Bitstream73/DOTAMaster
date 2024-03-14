Public Class abArc_Lightning
Inherits AbilityBase
  Public jumpcound As ValueWrapper
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

    mDisplayName = "Arc Lightning"
    mName = eAbilityName.abArc_Lightning
    Me.EntityName = eEntity.abArc_Lightning

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untZeus

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/zuus_arc_lightning_hp2.png"

    Description = "Hurls a bolt of lightning that leaps through nearby enemy units."

    ManaCost = New ValueWrapper(65, 70, 75, 80)

    Cooldown = New ValueWrapper(1.75, 1.75, 1.75, 1.75)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(85, 100, 115, 145)

    jumpcound = New ValueWrapper(5, 7, 9, 15)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyTargetsFixedCountInfo(theability_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalBouncesInflicted, occurencetime, aghstime)
    damval.Charges = jumpcound

    Dim dammod As New Modifier(damval, unittargetenemies)
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
