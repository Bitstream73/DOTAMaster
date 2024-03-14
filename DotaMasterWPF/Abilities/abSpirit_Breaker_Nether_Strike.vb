Public Class abNether_Strike
  Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public scepterrange As New List(Of Double?)

  Public bashradius As ValueWrapper
  Public scepterbashradius As New List(Of Double?)
  Public sceptercooldown As New List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Has a cast time of 1.2 seconds. If it was interrupted during the cast time, mana and cooldown are preserved, since it is not a channeled spell but a long-casting spell.|During the cast time, the target's model will be visible even when it moved into the Fog of War. Does not grant vision otherwise.|Spirit Breaker appears on the opposite from the target to deliver the Greater Bash.|If Greater Bash is not learnt, it will do nothing but move Spirit Breaker and deal its damage. Aghanim's Scepter upgrade's AoE bash is also dependent on Greater Bash.|The radius from the Aghanim's Scepter AoE Greater Bash aspect is centered around Spirit Breaker.|Does not disjoint projectiles." '"

    mDisplayName = "Nether Strike"
    mName = eAbilityName.abNether_Strike
    Me.EntityName = eEntity.abNether_Strike

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Breaker

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/spirit_breaker_nether_strike_hp2.png"

    Description = "Spirit Breaker slips into the nether realm, reappearing next to his hapless victim. Upon reappearing, a Greater Bash of the current level occurs and deals bonus damage. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(125, 150, 175)
    
    Cooldown = New ValueWrapper(80, 70, 60)
    sceptercooldown.Add(20)
    sceptercooldown.Add(20)
    sceptercooldown.Add(20)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    bonusdamage = New ValueWrapper(150, 250, 350)

    Range = New ValueWrapper(700, 700, 700)
    scepterrange.Add(850)
    scepterrange.Add(850)
    scepterrange.Add(850)
    Range.LoadScepterValues(scepterrange)


    bashradius = New ValueWrapper(-1, -1, -1)
    scepterbashradius.Add(250)
    scepterbashradius.Add(250)
    scepterbashradius.Add(250)
    bashradius.LoadScepterValues(scepterbashradius)



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


    Dim damval As New modValue(bonusdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamage)



    Dim leapval As New modValue(1, eModifierType.Leap, occurencetime)

    Dim theleap As New Modifier(leapval, unittargetenemy)
    outmods.Add(theleap)

    Dim bashval As New modValue(1, eModifierType.GreaterBashofCurrentLevel, occurencetime)

    Dim bashmod As New Modifier(bashval, unittargetenemy)
    outmods.Add(bashmod)





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
