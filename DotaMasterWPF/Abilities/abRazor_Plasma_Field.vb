Public Class abPlasma_Field
Inherits AbilityBase

  Public damagemin As ValueWrapper
  Public damagemax As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Plasma Field has an instant cast time, but interrupts channeling spells.|Plasma Field expands and retracts with a speed of 636.|The damage is divided into 2 instances. One instance is applied while expanding, and the other one whiler retracting. Both instances can hit a unit only once each.|Plasma Field 's damaging area is actually a 200 radius ring, which is right infront of the actual visible ring.|This means that upon cast, it instantly will damage units within 200 radius and can hit units up to 900 range away.|So upon expanding, the damage hits 200 range before the visible ring hits, and upon retracting, the damage hits after the ring passed the units already.|Plasma Field is centered on and follows Razor.|Plasma Field provides 700 radius flying vision, following Razor and leaving a trail of vision which lasts 2 seconds." '"

    mDisplayName = "Plasma Field"
    mName = eAbilityName.abPlasma_Field
    Me.EntityName = eEntity.abPlasma_Field

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRazor

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/razor_plasma_field_hp2.png"

    Description = "Releases a wave of energetic plasma that grows in power as it expands, but also zaps on contraction, dealing damage to enemy units caught in its path. Damage increases with distance from Razor."

    ManaCost = New ValueWrapper(125, 125, 125, 125)

    Cooldown = New ValueWrapper(14, 14, 14, 14)

    AbilityTypes.Add(eAbilityType.NoTarget)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(700, 700, 700, 700)
   
    damagemin = New ValueWrapper(30, 50, 70, 90)

    damagemax = New ValueWrapper(160, 230, 300, 370)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList



    Dim notargetenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim damval As New modValue(damagemax, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, notargetenemies)
    outmods.Add(thedamage)
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
