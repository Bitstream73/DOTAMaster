Public Class abTornado_Tempest
  Inherits AbilityBase

  Public fardamageradius As ValueWrapper
  Public closedamageradius As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public closedps As ValueWrapper
  Public fardps As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Tornado Tempest"
    mName = eAbilityName.abTornado_Tempest
    Me.EntityName = eEntity.abTornado_Tempest

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTornado

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/7/7e/Tempest_icon.png?version=1ad3679ef0ae99fb37107ed4ceace82d"
    WebpageLink = "http://dota2.gamepedia.com/Wildwing_Camp#Tornado"
    Description = "The Tornado's overpowering winds slow all nearby enemies, flinging debris at them and inflicting damage every second. Enemies closer to the center of the Tornado take more damage."
    Notes = "The aura's debuff lingers for 0.5 seconds. The damage is not connected with the debuff.|Deals 11.25 close and 3.75 far damage in 0.25 second intervals, starting 0.25 seconds after cast, resulting in 159 possible instance per unit.|Can deal up to 1788.75 damage when close, and 596.25 damage when far and standing within range for its full duration."

    '  mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.ChnneledAura)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    fardamageradius = New ValueWrapper(600)
    closedamageradius = New ValueWrapper(150)

    moveslow = New ValueWrapper(0.15)
    attslow = New ValueWrapper(15)

    closedps = New ValueWrapper(30) 'not 45 since the other 15 will be coming from fardps as they will overlap
    fardps = New ValueWrapper(15)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim activeauraenemies = Helpers.GetChanneledAuraEnemydUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim closedamval As New modValue(closedps, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1), occurencetime, aghstime)
    closedamval.mRadius = closedamageradius

    Dim closedammod As New Modifier(closedamval, activeauraenemies)
    outmods.Add(closedammod)

    Dim fardamval As New modValue(fardps, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1), occurencetime, aghstime)
    fardamval.mRadius = fardamageradius

    Dim fardammod As New Modifier(fardamval, activeauraenemies)
    outmods.Add(fardammod)

    Dim moveslowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveslowval.mRadius = fardamageradius

    Dim moveslowmod As New Modifier(moveslowval, activeauraenemies)
    outmods.Add(moveslowmod)

    Dim attslowval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attslowval.mRadius = fardamageradius

    Dim attslowmod As New Modifier(attslowval, activeauraenemies)
    outmods.Add(attslowmod)

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
