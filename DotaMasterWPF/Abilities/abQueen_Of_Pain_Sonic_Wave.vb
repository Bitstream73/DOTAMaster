Public Class abSonic_Wave
Inherits AbilityBase

  Public sceptercooldown As New List(Of Double?) ' 40
  Public scepterdamage As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Sonic Wave can hit units up to 1350 units away." '"

    mDisplayName = "Sonic Wave"
    mName = eAbilityName.abSonic_Wave
    Me.EntityName = eEntity.abSonic_Wave

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untQueen_of_Pain

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/queenofpain_sonic_wave_hp2.png"

    Description = "Creates a gigantic wave of sound in front of Queen of Pain, dealing heavy damage to all enemy units in its wake. Upgradable with Aghanim's Scepter."

    ManaCost = New ValueWrapper(250, 360, 500)
    
    Cooldown = New ValueWrapper(135, 135, 135)
    sceptercooldown.Add(40)
    sceptercooldown.Add(40)
    sceptercooldown.Add(40)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    Radius = New ValueWrapper(450, 450, 450)


    Damage = New ValueWrapper(250, 360, 500)
    scepterdamage.Add(325)
    scepterdamage.Add(450)
    scepterdamage.Add(575)
    Damage.LoadScepterValues(scepterdamage)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim ConeEnemies = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim wavedamage As New Modifier(damval, ConeEnemies)
    outmods.Add(wavedamage)

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
