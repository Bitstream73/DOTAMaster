Public Class abViper_Strike
Inherits AbilityBase
  Public dot As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper

  Public scmanacost As New List(Of Double?)
  Public sccooldown As New List(Of Double?)
  Public scrange As New List(Of Double?)
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

    mDisplayName = "Viper Strike"
    mName = eAbilityName.abViper_Strike
    Me.EntityName = eEntity.abViper_Strike

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untViper

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/viper_viper_strike_hp2.png"

    Description = "Viper slows the targeted enemy unit's movement and attack speed while also dealing poison damage over time. The slowing effect reduces over the duration of the poison. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(125, 175, 250)
    scmanacost.Add(125)
    scmanacost.Add(125)
    scmanacost.Add(125)
    ManaCost.LoadScepterValues(scmanacost)

    Cooldown = New ValueWrapper(80, 50, 30)
    sccooldown.Add(12)
    sccooldown.Add(12)
    sccooldown.Add(12)
    Cooldown.LoadScepterValues(sccooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Duration = New ValueWrapper(5.1, 5.1, 5.1)

    dot = New ValueWrapper(60, 100, 145)

    moveslow = New ValueWrapper(0.4, 0.6, 0.8)

    attslow = New ValueWrapper(40, 60, 80)


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

    'move slow
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittargetenemy)
    outmods.Add(movemod)

    'att slow
    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)

    Dim attmod As New Modifier(attval, unittargetenemy)
    outmods.Add(attmod)

    'dot
    Dim dotval As New modValue(dot, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dotmod As New Modifier(dotval, unittargetenemy)
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
