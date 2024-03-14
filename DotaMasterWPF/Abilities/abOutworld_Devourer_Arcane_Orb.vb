Public Class abArcane_Orb
  Inherits AbilityBase


  Public manapooltodamage As ValueWrapper
  Public illusiondamage As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Arcane Orb"
    mName = eAbilityName.abArcane_Orb
    Me.EntityName = eEntity.abArcane_Orb

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOutworld_Devourer

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/obsidian_destroyer_arcane_orb_hp2.png"

    Description = "Adds extra pure damage to Outworld Devourer's attacks, based on his remaining mana pool. Arcane Orb also does bonus damage to summoned units and illusions. Arcane Orb is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    manapooltodamage = New ValueWrapper(0.06, 0.07, 0.08, 0.09)

    illusiondamage = New ValueWrapper(100, 200, 300, 400)

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

    Dim unittargetillusion = Helpers.GetUnitTargetEnemyIllusionInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim manaval As New modValue(manapooltodamage, eModifierType.DamagePureAsPercentofManaPool, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, unittargetenemy)
    outmods.Add(manamod)


    Dim illval As New modValue(illusiondamage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim illmod As New Modifier(illval, unittargetillusion)
    outmods.Add(illmod)

    Return outmods
  End Function
End Class
