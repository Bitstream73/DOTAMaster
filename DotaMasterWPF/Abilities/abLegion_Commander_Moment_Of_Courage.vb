Public Class abMoment_Of_Courage
Inherits AbilityBase

  Public chance As ValueWrapper
  Public lifesteal As ValueWrapper
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

    Notes = "Cannot proc more than once every 0.9 seconds.|The lifesteal is not a Unique Attack Modifier.|When this ability triggers while Legion Commander is currently performing an attack, an extra attack is instantly thrown in, without interrupting her current attack.|This instant attack does not count as a regular attack. This means it does not proc Return, Reactive Armor and Counter Helix.|However, it does proc every form of attack modifier.|When this ability triggers while not attacking, a buff will be placed on her, which gives her next attack maximum attack speed. The buff lasts for 1 second or until the next attack.|Illusions have fully functional Moment of Courage.|Uses Pseudo-random distribution." '"

    mDisplayName = "Moment of Courage"
    mName = eAbilityName.abMoment_Of_Courage
    Me.EntityName = eEntity.abMoment_Of_Courage

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLegion_Commander

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/legion_commander_moment_of_courage_hp2.png"

    Description = "When attacked, Legion Commander has a chance to immediately attack again with bonus lifesteal."


    Cooldown = New ValueWrapper(0.9, 0.9, 0.9, 0.9)


    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)


    chance = New ValueWrapper(0.16, 0.18, 0.2, 0.22)

    lifesteal = New ValueWrapper(0.2, 0.4, 0.6, 0.8)

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
                                                     theowner As idisplayunit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetAutoCastEnemyTargetInfo(theability_InfoID, _
                                                                       theowner, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Passive)

    Dim rclickval As New modValue(1, eModifierType.RightClickCounterAttack, occurencetime)
    rclickval.mPercentChance = chance

    Dim rclickcounter As New Modifier(rclickval, unittargetenemytargetinfo)
    outmods.Add(rclickcounter)



    Dim lifeval As New modValue(lifesteal, eModifierType.LifeStealPercent, occurencetime, aghstime)
    lifeval.mPercentChance = chance

    Dim thelifesteal As New Modifier(lifeval, unittargetenemytargetinfo)
    outmods.Add(thelifesteal)




    Return outmods
  End Function
End Class
