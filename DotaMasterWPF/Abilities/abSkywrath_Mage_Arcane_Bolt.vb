Public Class abArcane_Bolt
Inherits AbilityBase
  Public basedamage As ValueWrapper
  Public intdamagemultiplier As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The projectile moves very slowly (500 movement speed).|The projectile gives 325 vision around itself.|Cannot be disjointed by blinking, going invisible, etc.|Upon impact, it reveals the target area for 3.34 seconds" '"

    mDisplayName = "Arcane Bolt"
    mName = eAbilityName.abArcane_Bolt
    Me.EntityName = eEntity.abArcane_Bolt

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSkywrath_Mage

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skywrath_mage_arcane_bolt_hp2.png"

    Description = "Skywrath Mage launches a slow-moving bolt of arcane magic, dealing damage to an enemy unit based on Skywrath Mage's intelligence."


    ManaCost = New ValueWrapper(70, 70, 70, 70)

    Cooldown = New ValueWrapper(5, 4, 3, 2)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    basedamage = New ValueWrapper(60, 80, 100, 120)

    intdamagemultiplier = New ValueWrapper(1.6, 1.6, 1.6, 1.6)
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


    Dim basedamval As New modValue(basedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(basedamval, unittargetenemy)
    outmods.Add(thedamage)

    Dim dammultiplierval As New modValue(intdamagemultiplier, eModifierType.DamageMagicalTimesInt, occurencetime, aghstime)

    Dim dammulti As New Modifier(dammultiplierval, unittargetenemy)

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
