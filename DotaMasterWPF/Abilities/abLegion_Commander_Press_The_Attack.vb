Public Class abPress_The_Attack
Inherits AbilityBase
  Public bonusattackspeed As ValueWrapper
  Public hpregen As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Is a strong dispel.|Heals for 3/4/5/6 hp in 0.1 second intervals.|Regenerates a total of 150/200/250/300 Health." '"

    mDisplayName = "Press the Attack"
    mName = eAbilityName.abPress_The_Attack
    Me.EntityName = eEntity.abPress_The_Attack

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLegion_Commander

    mAbilityPosition = 2

    mIsUltimate = False '
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/legion_commander_press_the_attack_hp2.png"

    Description = "Removes debuffs and disables from the target friendly unit, and grants bonus attack speed and health regen for a short time."

    ManaCost = New ValueWrapper(80, 90, 100, 110)

    Cooldown = New ValueWrapper(16, 15, 14, 13)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)
    Affects.Add(eUnit.untSelf)



    Duration = New ValueWrapper(5, 5, 5, 5)

    bonusattackspeed = New ValueWrapper(60, 80, 100, 120)

    hpregen = New ValueWrapper(30, 40, 50, 60)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untSelf)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untAlliedCreep)

    Dim unittargethero = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active, theaffects)

    Dim debuffpurgeval As New modValue(1, eModifierType.RemoveDebuffs, occurencetime)

    Dim debuffpurge As New Modifier(debuffpurgeval, unittargethero)
    outmods.Add(debuffpurge)



    Dim disablepurgeval As New modValue(1, eModifierType.RemoveDisables, occurencetime)

    Dim purgedisable As New Modifier(disablepurgeval, unittargethero)
    outmods.Add(purgedisable)





    Dim attspeedval As New modValue(bonusattackspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attspeedval.mValueDuration = Duration

    Dim attspeed As New Modifier(attspeedval, unittargethero)
    outmods.Add(attspeed)



    Dim regenval As New modValue(hpregen, eModifierType.HPRegenAdded, occurencetime, aghstime)
    regenval.mValueDuration = Duration

    Dim regen As New Modifier(regenval, unittargethero)
    outmods.Add(regen)



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
