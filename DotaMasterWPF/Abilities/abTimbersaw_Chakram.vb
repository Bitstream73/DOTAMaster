Public Class abChakram
Inherits AbilityBase

  Private passdamage As ValueWrapper
  Private damagepersec As ValueWrapper
  Private manacostpersec As ValueWrapper
  Private slow As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Chakram returns to Timbersaw if it gets more than 2000 units away.|The Chakram travels at a speed of 900.|Starts draining mana once the Chakram stops moving and stops draining as soon as it starts flying back.|Drains 10/12.5/15 mana in 0.5 second intervals.|Deals 25/37.5/50 damage (before reductions) in 0.5 second intervals.|Disables Timbersaw's attack as soon as the Chakram is launched, and gains it back once it returned to him.|The first 5% slow are applied at 100%-96% hp.|Slow debuff lasts for 0.5 seconds after leaving the affected area.|Pass damage may only damage the same unit once when flying towards the targeted point, and once again when returning to Timbersaw."

    mDisplayName = "Chakram"
    mName = eAbilityName.abChakram
    Me.EntityName = eEntity.abChakram

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTimbersaw

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shredder_chakram_hp2.png"

    Description = "Fires your main saw blade at the target location where it will spin in place, dealing damage in an area around it. Additionally, for each 5% of health missing, enemies caught in the saw blade move more slowly. The blade deals damage and cuts down trees in its path when fired and retracted. While active the ability costs mana, and you lose the ability to attack."

    ManaCost = New ValueWrapper(100, 150, 200)

    Cooldown = New ValueWrapper(8, 8, 8)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure


    Radius = New ValueWrapper(200, 200, 200)

    passdamage = New ValueWrapper(100, 140, 180)

    damagepersec = New ValueWrapper(50, 75, 100)

    manacostpersec = New ValueWrapper(20, 25, 30)

    slow = New ValueWrapper(0.05, 0.05, 0.05, 0.05)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim linetargetenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim passdamval As New modValue(passdamage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim thepassdamage As New Modifier(passdamval, linetargetenemies)
    outmods.Add(thepassdamage)


    Dim dpsval As New modValue(damagepersec, eModifierType.DamagePureInflicted, New ValueWrapper(1, 1, 1), occurencetime, aghstime)

    Dim dpsdamage As New Modifier(dpsval, pointtargetenemies)
    outmods.Add(dpsdamage)



    Dim manacostpersecval As New modValue(manacostpersec, eModifierType.ManaRemoved, New ValueWrapper(1, 1, 1), occurencetime, aghstime)

    Dim manavala As New Modifier(manacostpersecval, pointtargetenemies)
    outmods.Add(manavala)

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
