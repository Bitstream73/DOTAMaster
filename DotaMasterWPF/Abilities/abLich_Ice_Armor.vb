Public Class abIce_Armor
Inherits AbilityBase

  Public armorbonus As ValueWrapper
  Public slowduration As ValueWrapper
  Public moveslow As ValueWrapper
  Public attackslow As ValueWrapper

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

    mDisplayName = "Ice Armor"
    mName = eAbilityName.abIce_Armor
    Me.EntityName = eEntity.abIce_Armor

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLich

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lich_frost_armor_hp2.png"

    Description = "Creates a shield around the target friendly unit or building, which adds armor and slows attacking units. Has half effect on ranged attackers. Lasts 40 seconds."


    ManaCost = New ValueWrapper(50, 50, 50, 50)


    Cooldown = New ValueWrapper(5, 5, 5, 5)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)


    armorbonus = New ValueWrapper(3, 5, 7, 9)
    slowduration = New ValueWrapper(2, 2, 2, 2)
    moveslow = New ValueWrapper(0.3, 0.3, 0.3, 0.3)
    attackslow = New ValueWrapper(20, 20, 20, 20)

    Duration = New ValueWrapper(40, 40, 40, 40)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedUnit)
    theaffects.Add(eUnit.untAlliedUnitsAndSelf)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim armval As New modValue(armorbonus, eModifierType.ArmorAdded, occurencetime, aghstime)
    armval.mValueDuration = Duration

    Dim armmod As New Modifier(armval, unittargetmulti)
    outmods.Add(armmod)

    Dim notargetattackinenemy = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    'move slow
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, notargetattackinenemy)
    outmods.Add(movemod)

    'att slow
    Dim attval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, notargetattackinenemy)
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
