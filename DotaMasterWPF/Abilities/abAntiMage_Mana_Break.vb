Public Class abMana_Break
  Inherits AbilityBase


  Public manaburnedperhit As ValueWrapper
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
    mDisplayName = "Mana Break"
    mName = eAbilityName.abMana_Break
    Me.EntityName = eEntity.abMana_Break

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAnti_Mage

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/antimage_mana_break_hp2.png"

    Description = "Burns an opponent's mana on each attack. Mana Break deals 60% of the mana burned as damage to the target. Mana Break is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    manaburnedperhit = New ValueWrapper(28, 40, 52, 64)

    Damage = New ValueWrapper(manaburnedperhit.Value(0) * 0.6, _
                               manaburnedperhit.Value(1) * 0.6, _
                               manaburnedperhit.Value(2) * 0.6, _
                             manaburnedperhit.Value(3) * 0.6)

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
                                                 theowner As iDisplayUnit, _
                                                thetarget As iDisplayUnit, _
                                                ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim unittargetenemyunit = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim manaval As New modValue(manaburnedperhit, eModifierType.ManaDrained, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, unittargetenemyunit)
    outmods.Add(manamod)


    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemyunit)
    outmods.Add(dammod)


    Return outmods
  End Function
End Class
