Public Class abFiends_Grip
Inherits AbilityBase
  Public manadrain As ValueWrapper
  Public sceptermanadrain As New List(Of Double?)
  Public scepterduration As New List(Of Double?)
  Public scepterdamage As New List(Of Double?)
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

    mName = eAbilityName.abFiends_Grip
    Me.EntityName = eEntity.abFiends_Grip

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBane

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bane_fiends_grip_hp2.png"
    mDisplayName = "Fiends Grip"
    Description = "CHANNELED - Grips an enemy unit, disabling it and causing heavy damage over time, while stealing mana every second based on the unit's maximum mana. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 300, 400)

    Cooldown = New ValueWrapper(100, 100, 100)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    manadrain = New ValueWrapper(0.05, 0.05, 0.05)
    sceptermanadrain.Add(0.1)
    sceptermanadrain.Add(0.1)
    sceptermanadrain.Add(0.1)
    manadrain.LoadScepterValues(sceptermanadrain)


    Damage = New ValueWrapper(100, 155, 215)
    scepterdamage.Add(155)
    scepterdamage.Add(215)
    scepterdamage.Add(270)
    Damage.LoadScepterValues(scepterdamage)


    Duration = New ValueWrapper(5, 5, 5)
    scepterduration.Add(7)
    scepterduration.Add(7)
    scepterduration.Add(7)
    Duration.LoadScepterValues(scepterduration)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim channeledenemytarget = Helpers.GetChanneledEnemyTargetInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim drainval As New modValue(manadrain, eModifierType.ManaPercentDrained, occurencetime, aghstime)
    drainval.mValueDuration = Duration

    Dim drainmod As New Modifier(drainval, channeledenemytarget)
    outmods.Add(drainmod)


    Dim dotval As New modValue(Damage, eModifierType.DamageMagicalPerSec, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dotmod As New Modifier(dotval, channeledenemytarget)
    outmods.Add(dotmod)


    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
