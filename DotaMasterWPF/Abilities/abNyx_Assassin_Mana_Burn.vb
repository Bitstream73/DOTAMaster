Public Class abMana_Burn
Inherits AbilityBase
  Public intelligencemulti As ValueWrapper

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

    mDisplayName = "Mana Burn"
    mName = eAbilityName.abMana_Burn
    Me.EntityName = eEntity.abMana_Burn

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNyx_Assassin

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/nyx_assassin_mana_burn_hp2.png"

    Description = "Destroys the target hero's mana equal to a multiplier of its Intelligence, and deals damage equal to the mana burned."

    ManaCost = New ValueWrapper(100, 100, 100, 100)


    Cooldown = New ValueWrapper(28, 20, 12, 4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyHero)

    DamageType = eDamageType.Magical

    intelligencemulti = New ValueWrapper(3.5, 4, 4.5, 5)

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

    Dim damval As New modValue(intelligencemulti, eModifierType.ManaBurnDamage, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim manaval As New modValue(intelligencemulti, eModifierType.ManaBurnManaremoved, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, unittargetenemy)
    outmods.Add(manamod)


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
