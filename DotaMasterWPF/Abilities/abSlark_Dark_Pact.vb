Public Class abDark_Pact
Inherits AbilityBase
  Public delay As ValueWrapper
  Public selfdamage As ValueWrapper
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

    mDisplayName = "Dark Pact"
    mName = eAbilityName.abDark_Pact
    Me.EntityName = eEntity.abDark_Pact

    'mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlark

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slark_dark_pact_hp2.png"

    Description = "After a short delay, Slark sacrifices some of his life blood, purging most negative debuffs and dealing damage to enemy units around him and to himself. Slark only takes 50% of the damage."

    ManaCost = New ValueWrapper(55, 50, 45, 40)

    Cooldown = New ValueWrapper(9, 8, 7, 6)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(75, 150, 225, 300)
    selfdamage = New ValueWrapper(Damage.Value(0) * 0.5, _
                                  Damage.Value(1) * 0.5, _
                                  Damage.Value(2) * 0.5, _
                                  Damage.Value(3) * 0.5)

    Radius = New ValueWrapper(325, 325, 325, 325)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim notargetenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    'pruge debuffs
    Dim debuffval As New modValue(1, eModifierType.RemoveDebuffs, occurencetime)

    Dim debuffmod As New Modifier(debuffval, notargetself)
    outmods.Add(debuffmod)

    'damage self
    Dim sdamval As New modValue(selfdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim sdammod As New Modifier(sdamval, notargetself)
    outmods.Add(sdammod)

    'damage enemies
    Dim edamval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim edammod As New Modifier(edamval, notargetenemies)
    outmods.Add(edammod)

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
