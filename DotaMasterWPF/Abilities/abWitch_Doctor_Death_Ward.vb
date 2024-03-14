Public Class abDeath_Ward
Inherits AbilityBase
  Public scepterdamage As New List(Of Double?)
  Public scepterbounces As New List(Of Double?)

  Public bounces As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    mDisplayName = "Death Ward"
    Notes = "The Death Ward is invulnerable, and is only destroyed if Witch Doctor is interrupted or its duration expires.|The Death Ward can be controlled, and made to attack a specific hero.|The Death Ward has a 700 attack range and attacks every 0.22 seconds. The bounce range for the level 3 (or Scepter Upgraded) Death Ward is 650.|The Death Ward channel can be maintained while invisible; activating Shadow Blade doesn't interrupt channeling because it's a Wind walk based ability.|Can deal up to 2182/3273/4364 (3273/4364/5456) chaos damage per target over its duration.|Aghanim's Scepter will cause the ward attack to bounce to the entire enemy team (1 main target + 4 bounces = 5 enemy heroes)|Each bounce, including the initial attack, can be evaded normally.|Death Ward can't target or bounce to Ethereal enemies but does full damage to spell immune ones.|Death Ward's damage is not reduced by Damage block (i. e. Stout Shield, Vanguard, Tidehunter's Kraken Shell)."
    mName = eAbilityName.abDeath_Ward
    Me.EntityName = eEntity.abDeath_Ward

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWitch_Doctor

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/witch_doctor_death_ward_hp2.png"

    Description = "CHANNELED - Summons a deadly ward to attack enemy heroes. The Death Ward has attack range of 700, and attacks every .22 seconds. Level 3 Death Ward bounces once. Lasts 8 seconds. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 200, 200)

    Cooldown = New ValueWrapper(80, 80, 80)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(60, 90, 120)
    scepterdamage.Add(90)
    scepterdamage.Add(120)
    scepterdamage.Add(150)
    Damage.LoadScepterValues(scepterdamage)

    bounces = New ValueWrapper(-1, -1, 1)
    scepterbounces.Add(4)
    scepterbounces.Add(4)
    scepterbounces.Add(4)
    bounces.LoadScepterValues(scepterbounces)

    Duration = New ValueWrapper(8, 8, 8)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim channeledenemyheroes = Helpers.GetChanneledEnemyHeroesInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalBouncesInflicted, New ValueWrapper(0.22, 0.22, 0.22), occurencetime, aghstime)
    damval.Charges = bounces
    damval.mValueDuration = Duration

    Dim damageout As New Modifier(damval, channeledenemyheroes)
    outmods.Add(damageout)


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
