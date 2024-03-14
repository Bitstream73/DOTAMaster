Public Class abFlak_Cannon
  Inherits AbilityBase
  Public maxattacks As ValueWrapper

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

    mDisplayName = "Flak Cannon"
    Notes = "Flak Cannon has an instant cast time, but cancels channeling spells.|The flak projectiles travel at a speed of 800, while Gyrocopter's own projectile speed stays at 3000.|The flaks can be disjointed. They also can miss on evasion.|Gyrocopter's attack range remains 365.|The flaks are released at the same time as his attack projectile is released. Means when an attack misses, the flaks are still released.|It does not matter how much damage the initial target from the attack takes, the flaks will always deal damage based on Gyrocopter's base damage + bonus damage.|This means that the armor of the initial attack target does not influence the flaks' damage at all. It also means that damage from attack modifiers like crits do not affect it either.|So the only way to make the flaks deal more damage is to increase Gyrocopter's base damage via stats, give him a raw damage bonus, or reduce the armor of the flak targets.|Other effects of attack modifiers like bash or lifesteal is only applied to the attack target.|Does not target couriers, wards, buildings, invisible units and units in Fog of War in range. Does target siege creeps.|However, attacking couriers, wards or buildings will still cause flaks to hit all valid targets within the range.|The number of left attacks is visible (to everyone) on the buff icon." '"

    mName = eAbilityName.abFlak_Cannon
    Me.EntityName = eEntity.abFlak_Cannon

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGyrocopter

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/gyrocopter_flak_cannon_hp2.png"

    Description = "Gyrocopter's attacks hit all enemy units in an area around it for a limited number of attacks. Only the main target of attacks will receive attack bonuses such as Critical Strike. Lasts 15 seconds or until the attacks are used."


    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Radius = New ValueWrapper(1000, 1000, 1000, 1000)

    maxattacks = New ValueWrapper(3, 4, 5, 6)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim nontargetAura = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)


    Dim rclicknontargetval As New modValue(1, eModifierType.RightClickDamageWithoutBuffs, New ValueWrapper(1, 1, 1, 1), occurencetime)
    rclicknontargetval.Charges = maxattacks

    Dim nontargetdamage As New Modifier(rclicknontargetval, nontargetAura)
    outmods.Add(nontargetdamage)



    Dim targetedAura = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)

    Dim rclicktargetval As New modValue(1, eModifierType.RightClickDamageWithBuffs, occurencetime)
    rclicknontargetval.Charges = maxattacks

    Dim targetdamage As New Modifier(rclicktargetval, targetedAura)
    outmods.Add(targetdamage)



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
