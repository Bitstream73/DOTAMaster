Public Class abOgre_Frostmage_Ice_Armor
  Inherits AbilityBase

  Public armorbonus As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public armorduration As ValueWrapper
  Public slowduration As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Ice Armor"
    mName = eAbilityName.abOgre_Frostmage_Ice_Armor
    Me.EntityName = eEntity.abOgre_Frostmage_Ice_Armor

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOgre_Frostmage

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/b/b8/Ice_Armor_icon.png/120px-Ice_Armor_icon.png?version=13888c1f6abe0c9b144090df7c6cfdd6"
    WebpageLink = "http://dota2.gamepedia.com/Ogre_Frostmage"
    Description = "The Ogre Frostmage summons an invisible layer of icy air that surrounds the target friendly unit, increasing its armor and temporarily slowing any melee enemies that dare attack it."
    Notes = "The cast of Ice Armor icon.png Ice Armor is never registered as a spell, meaning it won't trigger Curse of the Silent, Last Word, Essence Aura, Magic Stick and Magic Wand.|The slow is applied upon a successful hit on a unit with the buff on.|This means when an attack misses, the slow will not be applied.|Allied units can attack an ally with the buff on without getting slowed.|As a neutral unit: The ogre never casts this spell.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(40)

    Cooldown = New ValueWrapper(5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)
    'mAffects.Add(eUnit)

    armorbonus = New ValueWrapper(8)
    moveslow = New ValueWrapper(0.3)
    attslow = New ValueWrapper(20)

    armorduration = New ValueWrapper(45)
    slowduration = New ValueWrapper(5)

    'mRadius = New ValueWrapper
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
    theaffects.Add(eUnit.untAlliedUnit)

    Dim targetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active, theaffects)

    Dim notargetattackingenemy = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim armval As New modValue(armorbonus, eModifierType.ArmorAdded, occurencetime, aghstime)
    armval.mValueDuration = armorduration

    Dim armmod As New Modifier(armval, targetmulti)
    outmods.Add(armmod)


    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, notargetattackingenemy)
    outmods.Add(movemod)


    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, notargetattackingenemy)
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
