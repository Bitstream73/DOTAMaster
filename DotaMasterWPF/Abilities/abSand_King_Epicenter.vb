Public Class abEpicenter
Inherits AbilityBase
  Public pulses As ValueWrapper
  Public scepterpulses As New List(Of Double?)

  Public damperpulse As ValueWrapper
  Public pulseinterval As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public slowduration As ValueWrapper

  Public sceptercooldown As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Epicenter"
    mName = eAbilityName.abEpicenter

    Me.EntityName = eEntity.abEpicenter

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSand_King

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sandking_epicenter_hp2.png"

    Description = "CHANNELED - After channeling for 2 seconds, Sand King sends a disturbance into the earth, causing it to shudder violently. All enemies caught within range will take damage and become slowed. Each subsequent pulse increases the radius of damage dealt. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(175, 250, 325)

    Cooldown = New ValueWrapper(140, 120, 100)
    sceptercooldown.add(120)
    sceptercooldown.add(100)
    sceptercooldown.add(80)
    Cooldown.LoadScepterValues(sceptercooldown)


    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Channeled)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    pulses = New ValueWrapper(6, 8, 10)
    scepterpulses.Add(8)
    scepterpulses.Add(10)
    scepterpulses.Add(12)
    pulses.LoadScepterValues(scepterpulses)


    damperpulse = New ValueWrapper(110, 110, 110)

    moveslow = New ValueWrapper(0.3, 0.3, 0.3)
    attslow = New ValueWrapper(30, 30, 30)

    slowduration = New ValueWrapper(3, 3, 3)

    pulseinterval = New ValueWrapper(0.25, 0.25, 0.25)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim channeledenemies = Helpers.GetChanneledAuraEnemydUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)


    Dim pulseval As New modValue(damperpulse, eModifierType.DamageMagicalOverTimeInflicted, pulseinterval, occurencetime, aghstime)
    pulseval.Charges = pulses

    Dim pulsemod As New Modifier(pulseval, channeledenemies)
    outmods.Add(pulsemod)


    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, channeledenemies)
    outmods.Add(movemod)


    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, channeledenemies)
    outmods.Add(attmod)

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
