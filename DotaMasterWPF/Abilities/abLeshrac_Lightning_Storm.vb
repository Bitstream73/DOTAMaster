Public Class abLightning_Storm
  Inherits AbilityBase
  Public jumps As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True  '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "" '"

    mDisplayName = "Lightning Storm"
    mName = eAbilityName.abLightning_Storm
    Me.EntityName = eEntity.abLightning_Storm

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLeshrac

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/leshrac_lightning_storm_hp2.png"

    Description = "Summons a lightning storm that blasts the target enemy unit, then jumps to nearby enemy units. Struck enemies are slowed by 75% for 0.5 seconds."

    ManaCost = New ValueWrapper(90, 100, 110, 120)

    Cooldown = New ValueWrapper(4, 4, 4, 4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(80, 140, 200, 260)

    jumps = New ValueWrapper(4, 5, 6, 7)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim thedamval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    thedamval.Charges = jumps


    Dim thedamage As New Modifier(thedamval, unittargetenemies)
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
