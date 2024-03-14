Public Class abShadow_Strike
Inherits AbilityBase
  Public StrikeDamage As ValueWrapper
  Public DamageoT As ValueWrapper
  Public MovementSlow As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Damage over time is dealt to the affected units every 3 seconds during 15 seconds.|Affected units slowly regain their original movement speed every second during the 15 seconds.|Units afflicted by Shadow Strike can be denied by their allies when their HP drops below 25% of their maximum health.|Deals a total of 200/275/350/425 damage." '"

    mDisplayName = "Shadow Strike"
    mName = eAbilityName.abShadow_Strike
    Me.EntityName = eEntity.abShadow_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untQueen_of_Pain

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/queenofpain_shadow_strike_hp2.png"

    Description = "Hurls a poisoned dagger which deals large initial damage, and then deals damage over time. The poisoned unit has its movement speed slowed for 15 seconds. An instance of damage is dealt every 3 seconds."

    ManaCost = New ValueWrapper(110, 110, 110, 110)


    Cooldown = New ValueWrapper(16, 12, 8, 4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    StrikeDamage = New ValueWrapper(50, 75, 100, 125)

    DamageoT = New ValueWrapper(30, 40, 50, 60)

    MovementSlow = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    Range = New ValueWrapper(450, 475, 500, 525)
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

    Dim strikeval As New modValue(StrikeDamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim theStrikeDamage As New Modifier(strikeval, unittargetenemy)
    outmods.Add(theStrikeDamage)



    Dim DoTval As New modValue(DamageoT, eModifierType.DamageoTMagicalInflicted, New ValueWrapper(3, 3, 3, 3), occurencetime, aghstime)
    DoTval.mValueDuration = New ValueWrapper(15, 15, 15, 15)

    Dim DamageOverTime As New Modifier(DoTval, unittargetenemy)
    outmods.Add(DamageOverTime)


    Dim moveval As New modValue(MovementSlow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = New ValueWrapper(15, 15, 15, 15)

    Dim themovementslow As New Modifier(moveval, unittargetenemy)
    outmods.Add(themovementslow)

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
