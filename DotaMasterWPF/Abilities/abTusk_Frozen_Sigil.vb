Public Class abFrozen_Sigil
  Inherits AbilityBase
  Public movementslow As ValueWrapper
  Public attackslow As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "If no order is given, the Sigil will follow Tusk.|The sigil is a flying unit.|Requires 3/3/4/4 hero attacks or 12/12/16/16 other attacks to kill it.|The aoe slow is an aura and thus lingers for 0.5 seconds after getting out of range.|Can be loaded inside Snowball, even though it counts as a ward." '"

    mDisplayName = "Frozen Sigil"
    mName = eAbilityName.abFrozen_Sigil
    Me.EntityName = eEntity.abFrozen_Sigil

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTusk

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tusk_frozen_sigil_hp2.png"

    Description = "Tusk summons a Frozen Sigil by calling upon the deepest cold of winter. The Sigil creates a snowstorm which slows all enemy units within 600 range."

    ManaCost = New ValueWrapper(75, 75, 75, 75)

    Cooldown = New ValueWrapper(50, 50, 50, 50)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(600, 600, 600, 600)

    Duration = New ValueWrapper(30, 30, 30, 30)

    movementslow = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    attackslow = New ValueWrapper(30, 40, 50, 60)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetaura = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim moveval As New modValue(movementslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim moveslow As New Modifier(moveval, notargetaura)


    Dim attval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim theattackslow As New Modifier(attval, notargetaura)
    outmods.Add(theattackslow)


    'Dim sigilpet As New HeroPet_Info

    'sigilpet.hitpoints = New ValueWrapper(3, 3, 4, 4)

    'sigilpet.armor = New ValueWrapper(0, 0, 0, 0)
    'sigilpet.armortype = eArmorType.None

    'sigilpet.movementspeed = New ValueWrapper(310, 310, 310, 310)

    'sigilpet.SightRange.Add(New ValueWrapper(400, 400, 400, 400))
    'sigilpet.SightRange.Add(New ValueWrapper(400, 400, 400, 400))


    'sigilpet.bounty = New ValueWrapper(90, 100, 110, 120)


    'sigilpet.xpvalue = New ValueWrapper(0, 0, 0, 0)

    'sigilpet.notes = "Will automatically follow Tusk upon summoning, unless given a command."

    Dim petval As New modValue(1, eModifierType.petFrozen_Sigil, occurencetime)
    '  petval.mPet = sigilpet

    Dim petmod As New Modifier(petval, notargetaura)
    outmods.Add(petmod)

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
