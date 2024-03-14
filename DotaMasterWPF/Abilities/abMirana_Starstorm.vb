Public Class abStarstorm
Inherits AbilityBase
  Public secondhitdamage As ValueWrapper
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

    Notes = "Meteors can not disjointed.|Meteors need 0.57 seconds to hit their targets.|Cannot target invisible, invulnerable or hidden units.|The target for the 2nd meteor is set upon cast of Starstorm icon.png Starstorm, so it can hit its target even after it moved out of the 175 radius.|Starstorm icon.png Starstorm will choose a new target for the second meteor if the set target died before or because of the 1st meteor's impact.|Second meteor deals 56.25/112.5/168.75/225 damage.|Can deal a total of 131.25/262.5/393.75/525 damage to a single target with the second meteor hit." '"

    mDisplayName = "Starstorm"
    mName = eAbilityName.abStarstorm
    Me.EntityName = eEntity.abStarstorm

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMirana

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/mirana_starfall_hp2.png"

    Description = "Calls down a wave of meteors to damage nearby enemy units. One random enemy unit in 175 range will take a second hit for 75% of the damage."

    ManaCost = New ValueWrapper(100, 120, 140, 160)

    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(75, 150, 225, 300)

    secondhitdamage = New ValueWrapper(Damage.Value(0) * 0.75, Damage.Value(1) * 0.75, Damage.Value(2) * 0.75, Damage.Value(3) * 0.75)

    Radius = New ValueWrapper(625, 625, 625, 625)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim thedam As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamageaoe As New Modifier(thedam, auraenemies)
    outmods.Add(thedamageaoe)

    Dim randomenemy = Helpers.GetActiveAuraEnemyUnitRandomInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim thelessdam As New modValue(secondhitdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim lessdamage As New Modifier(thelessdam, randomenemy)
    outmods.Add(lessdamage)

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
