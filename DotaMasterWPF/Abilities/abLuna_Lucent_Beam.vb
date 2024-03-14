Public Class abLucent_Beam
  Inherits AbilityBase
  Public stunduration As ValueWrapper
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

    Notes = "Luna's glaive emits some particles during the cast time, visible to everyone." '"

    mName = eAbilityName.abLucent_Beam
    Me.EntityName = eEntity.abLucent_Beam

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLuna

    mAbilityPosition = 1

    mDisplayName = "Beam"
    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/luna_lucent_beam_hp2.png"

    Description = "Luna channels a concentrated beam of lunar energy at an enemy, stunning and dealing damage."

    ManaCost = New ValueWrapper(90, 100, 110, 120)

    Cooldown = New ValueWrapper(6, 6, 6, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(75, 150, 225, 300)

    stunduration = New ValueWrapper(0.6, 0.6, 0.6, 0.6)

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

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamage)


    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, occurencetime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, unittargetenemy)
    outmods.Add(thestun)


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
