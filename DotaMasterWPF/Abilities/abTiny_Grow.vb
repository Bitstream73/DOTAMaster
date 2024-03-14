Public Class abGrow
Inherits AbilityBase

  Public bonusdamage As ValueWrapper
  Public bonusrange As ValueWrapper
  Public attackspeedloss As ValueWrapper
  Public movementspeed As ValueWrapper
  Public tossbonus As ValueWrapper
  Public scepterbonusrange As New List(Of Double?)
  Public cleavedamage As ValueWrapper
  Public sceptercleavedamage As New List(Of Double?)
  Public scepterbonusbuildingdamage As New List(Of Double?) ' theability_InfoID As dvid

  Public sceptertossbonus As New List(Of Double?)

  'Public cleavedamage As ValueWrapper
  Public buildingdamage As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Allies still take no damage from Toss.|Each level changes Tiny's appearance, making him bigger and making his voice deeper.|If Aghanim's Scepter is purchased, Tiny will equip a tree, regardless of level. However, he will not experience improved Toss damage, attack range, cleave, or bonus building damage until Grow is leveled at least once.|Aghanim's Scepter increases attack range to 235 (still considered as melee), gives 50% cleave in a 400 radius, and deals 75% bonus damage to structures.|Cleave damage is reduced by armor type but not by armor value.|The cleave damages a circular area in front of Tiny.|As with all cleave, the Tree Cleave stacks with Battle Fury and Empower." '"

    mDisplayName = "Grow"
    mName = eAbilityName.abGrow
    Me.EntityName = eEntity.abGrow

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTiny

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tiny_grow_hp2.png"

    Description = "Tiny gains craggy mass that increases his power at the cost of his attack speed. Increases Tossed unit damage and improves movement speed. Upgradable by Aghanim's Scepter."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    bonusdamage = New ValueWrapper(50, 100, 150)

    attackspeedloss = New ValueWrapper(20, 35, 50)

    movementspeed = New ValueWrapper(40, 50, 60)

    tossbonus = New ValueWrapper(0.35, 0.5, 0.65)
    sceptertossbonus.Add(0.5)
    sceptertossbonus.Add(0.65)
    sceptertossbonus.Add(0.8)
    tossbonus.LoadScepterValues(sceptertossbonus)

    bonusrange = New ValueWrapper(-1, -1, -1)
    scepterbonusrange.Add(107)
    scepterbonusrange.Add(107)
    scepterbonusrange.Add(107)
    bonusrange.LoadScepterValues(scepterbonusrange)

    buildingdamage = New ValueWrapper(-1, -1, -1)
    scepterbonusbuildingdamage.Add(0.75)
    scepterbonusbuildingdamage.Add(0.75)
    scepterbonusbuildingdamage.Add(0.75)
    buildingdamage.LoadScepterValues(scepterbonusbuildingdamage)

    cleavedamage = New ValueWrapper(-1, -1, -1)
    sceptercleavedamage.Add(0.5)
    sceptercleavedamage.Add(0.5)
    sceptercleavedamage.Add(0.5)
    cleavedamage.LoadScepterValues(sceptercleavedamage)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    theowner As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                                                                       ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                 theowner, _
                                                 thetarget, _
                                                 "", eModifierCategory.Passive)



    Dim valbonusdam As New modValue(bonusdamage, eModifierType.BonusDamage, occurencetime, aghstime)

    Dim modbonus As New Modifier(valbonusdam, passiveself)
    outmods.Add(modbonus)



    Dim valattspeed As New modValue(attackspeedloss, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)

    Dim modattspeed As New Modifier(valattspeed, passiveself)
    outmods.Add(modattspeed)



    Dim valmove As New modValue(movementspeed, eModifierType.MoveSpeedAdded, occurencetime, aghstime)

    Dim modmove As New Modifier(valmove, passiveself)
    outmods.Add(modmove)


    Dim tossbonusval As New modValue(tossbonus, eModifierType.TinyTossBonusDamage, occurencetime, aghstime)

    Dim tossmod As New Modifier(tossbonusval, passiveself)
    outmods.Add(tossmod)







    Dim auranonattackers = Helpers.GetPassiveAuraEnemyUnitesNotTargettedInfo(theability_InfoID, _
                                                 theowner, _
                                                 thetarget, _
                                                 "", eModifierCategory.Passive)

    Dim valcleave As New modValue(cleavedamage, eModifierType.CleavePercentage, occurencetime, aghstime)

    Dim modcleave As New Modifier(valcleave, auranonattackers)
    outmods.Add(modcleave)

    Dim unittargetstructure = Helpers.GetUnitTargetEnemyStructureInfo(theability_InfoID, _
                                                 theowner, _
                                                 thetarget, _
                                                 "", eModifierCategory.Passive)

    Dim dambonus As New modValue(buildingdamage, eModifierType.BonusDamage, occurencetime, aghstime)

    Dim modsceptbonus As New Modifier(dambonus, unittargetstructure)
    outmods.Add(modsceptbonus)







    Return outmods
  End Function
End Class
