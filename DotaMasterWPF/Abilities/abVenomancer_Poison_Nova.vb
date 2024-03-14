Public Class abPoison_Nova
Inherits AbilityBase
  Public sccooldown As New List(Of Double?)
  Public scduration As New List(Of Double?)
  Public scdamage As New List(Of Double?)

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Poison Nova"
    mName = eAbilityName.abPoison_Nova
    Me.EntityName = eEntity.abPoison_Nova

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVenomancer

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/venomancer_poison_nova_hp2.png"

    Description = "A spreading ring of poison that does damage over time to enemy units around Venomancer. Poison Nova's effect cannot bring units below 1 HP. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 300, 400)

    Cooldown = New ValueWrapper(140, 120, 100)
    sccooldown.Add(140)
    sccooldown.Add(120)
    sccooldown.Add(60)
    Cooldown.LoadScepterValues(sccooldown)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(830, 830, 830)


    Damage = New ValueWrapper(36, 58, 81)
    scdamage.Add(58)
    scdamage.Add(81)
    scdamage.Add(108)
    Damage.LoadScepterValues(scdamage)


    Duration = New ValueWrapper(12, 14, 15)
    scduration.Add(14)
    scduration.Add(15)
    scduration.Add(16)
    Duration.LoadScepterValues(scduration)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetaura = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim dotval As New modValue(Damage, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration
    dotval.mCooldown = Cooldown

    Dim dotmod As New Modifier(dotval, notargetaura)
    outmods.Add(dotmod)

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
