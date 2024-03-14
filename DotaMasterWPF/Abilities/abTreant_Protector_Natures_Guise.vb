Public Class abNatures_Guise
Inherits AbilityBase
  Dim movementspeed As ValueWrapper
  Dim fadetime As ValueWrapper
  Dim treeradius As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "If casted on a unit that isn't near a tree, nothing will happen at all, wasting the mana and cooldown.|The buff will be lost if the unit moves more than 375 away from a tree for longer than 1 second (the amount of time left is indicated by a buff timer). The timer will reset once getting within 375 range of a tree.|Treant Protector can cast spells and use items without losing invisibility from Nature's Guise.|Other units can cast spells and use items only during the 2 seconds fade time.|Units can perform attacks within the 2 seconds fade time without breaking the invisibility. Attacking after the fade time will break it.|Nature's Guise has a faster cast point of 0.3s." '"

    mDisplayName = "Nature's Guise"
    mName = eAbilityName.abNatures_Guise
    Me.EntityName = eEntity.abNatures_Guise

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTreant_Protector

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/treant_natures_guise_hp2.png"

    Description = "Causes the targeted unit to blend in with the forest, becoming invisible to enemies and gaining a movement speed bonus when near a tree. If the unit moves away from a tree or the spell is cast on a unit with no nearby trees, Nature's Guise is lost. Treant Protector can cast spells and remain invisible under Nature's Guise."

    ManaCost = New ValueWrapper(60, 60, 60, 60)

    Cooldown = New ValueWrapper(10, 8, 6, 4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnits)

    Duration = New ValueWrapper(15, 30, 45, 60)

    fadetime = New ValueWrapper(2, 2, 2, 2)

    treeradius = New ValueWrapper(375, 375, 375, 375)

    movementspeed = New ValueWrapper(0.1, 0.1, 0.1, 0.1)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedUnitsAndSelf)
    theaffects.Add(eUnit.untAlliedUnit)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)


    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration

    Dim invismod As New Modifier(invisval, unittargetmulti)
    outmods.Add(invismod)



    Dim moveval As New modValue(movementspeed, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittargetmulti)
    outmods.Add(movemod)


    'Dim targetmultieffect As New modInfo(eAbilityType.PointTarget, _
    '                                     theability_InfoID, _
    '                                     thecaster.ID, eSourceType.HeroBuild, _
    '                                     Nothing, _
    '                                     mAffects, _
    '                                     "", eModifierCategory.Active)
    'Dim theduration = New TimeSpan(mDuration.Item(theabilitylevel - 1) * TimeSpan.TicksPerSecond)

    'Dim moveval As New modValue(movementspeedpercent.Item(theabilitylevel - 1), eModifierType.MoveSpeedPercent)
    'moveval.mValueDuration = theduration

    'Dim movementspeed As New Modifier(occurencetime, moveval, targetmultieffect)
    'outmods.Add(movementspeed)



    'Dim invisval As New modValue(1, eModifierType.Invisibility)
    'invisval.mValueDuration = theduration

    'Dim invisibiliy As New Modifier(occurencetime, invisval, targetmultieffect)
    'outmods.Add(invisibiliy)

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
