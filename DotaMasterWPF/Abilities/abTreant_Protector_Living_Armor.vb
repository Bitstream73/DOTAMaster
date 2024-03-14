Public Class abLiving_Armor
Inherits AbilityBase
  Public regeneration As ValueWrapper
  Public damageinstances As ValueWrapper
  Public block As ValueWrapper
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

    Notes = "Can be cast through the mini-map.|The total amount of health gained while under the entire duration of Living Armor is 60/105/150/195.|Blocks up to 80/200/360/560 damage.|Blocks damage from all sources and any type.|Regeneration and damage block is applied to buildings.|Damage block is calculated after all reductions or amplifications (armor, magic resistance, etc) and does not block damage lower than 5.|This means when it's casted on a building and then the Glyph of Fortification is used, attacks on that building will not use any charges, ensuring 5 seconds of regeneration from Living Armor." '"

    mDisplayName = "Living Armor"
    mName = eAbilityName.abLiving_Armor
    Me.EntityName = eEntity.abLiving_Armor

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTreant_Protector

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/treant_living_armor_hp2.png"

    Description = "Infuses the target hero or structure with a protective coating which grants bonus regeneration. Also blocks some damage from all sources . Dispels when a number of damage instances are taken."


    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(32, 26, 20, 14)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untAlliedUnit)
    Affects.Add(eUnit.untAlliedStructure)

    Duration = New ValueWrapper(15, 15, 15, 15)

    regeneration = New ValueWrapper(4, 5, 6, 7)

    damageinstances = New ValueWrapper(4, 5, 6, 7)

    regeneration = New ValueWrapper(4, 7, 10, 13)

    block = New ValueWrapper(20, 40, 60, 80)

  End Sub


  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedStructure)
    theaffects.Add(eUnit.untAlliedHero)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)


    'block
    Dim blockval As New modValue(block, eModifierType.DamageBlock, occurencetime, aghstime)
    blockval.Charges = damageinstances

    Dim blockmod As New Modifier(blockval, unittargetmulti)
    outmods.Add(blockmod)

    'regen
    Dim regenval As New modValue(regeneration, eModifierType.HealAddedoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    regenval.mValueDuration = Duration

    Dim regenmod As New Modifier(regenval, unittargetmulti)
    outmods.Add(regenmod)




    'Dim pointtargetmulti As New modInfo(eAbilityType.PointTarget, _
    '                                    theability_InfoID, _
    '                                    thecaster.ID, eSourceType.HeroBuild, _
    '                                    thetarget.ID, _
    '                                    mAffects, _
    '                                    "", eModifierCategory.Active)

    'Dim theduration = New TimeSpan(mDuration.Item(theabilitylevel - 1) * TimeSpan.TicksPerSecond)
    'Dim daminstval As New modValue(1, eModifierType.DamageInstanceBlock)
    'daminstval.mCharges = damageinstances.Item(theabilitylevel - 1)
    'daminstval.mValueDuration = theduration

    'Dim thedamageinstances As New Modifier(occurencetime, daminstval, pointtargetmulti)
    'outmods.Add(thedamageinstances)


    'Dim regenval As New modValue(regeneration.Item(theabilitylevel - 1), eModifierType.HPoT)
    'regenval.mValueDuration = theduration

    'Dim theregen As New Modifier(occurencetime, regenval, pointtargetmulti)
    'outmods.Add(theregen)


    'Dim blockval As New modValue(block.Item(theabilitylevel - 1), eModifierType.DamageBlock)

    'Dim theblock As New Modifier(occurencetime, blockval, pointtargetmulti)
    'outmods.Add(theblock)

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
