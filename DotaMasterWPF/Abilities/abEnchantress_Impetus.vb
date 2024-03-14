Public Class abImpetus
Inherits AbilityBase
  Public distancedamage As ValueWrapper
  Public bonusrange As ValueWrapper
  Public scepterbonusrange As New List(Of Double?)
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

    mDisplayName = "Impetus"
    mName = eAbilityName.abImpetus
    Me.EntityName = eEntity.abImpetus

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnchantress

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enchantress_impetus_hp2.png"

    Description = "Places an enchantment on each attack while activated, causing it to deal additional damage based on how far away the target is. The farther the target, the greater the damage dealt. Impetus is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(55, 60, 65)



    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Pure

    distancedamage = New ValueWrapper(0.15, 0.2, 0.25)

    bonusrange = New ValueWrapper(-1, -1, -1)
    scepterbonusrange.Add(190)
    scepterbonusrange.Add(190)
    scepterbonusrange.Add(190)
    bonusrange.LoadScepterValues(scepterbonusrange)



End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Passive)


    Dim damval As New modValue(distancedamage, eModifierType.ImpetusDamagePureInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemytarget)
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
