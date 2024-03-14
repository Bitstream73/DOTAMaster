Public Class abLiquid_Fire
Inherits AbilityBase
  Public attackslow As ValueWrapper
  Public burndamage As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Liquid Fire"
    mName = eAbilityName.abLiquid_Fire
    Me.EntityName = eEntity.abLiquid_Fire

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJakiro

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/jakiro_liquid_fire_hp2.png"

    Description = "Jakiro burns his enemies in an area of effect with fire added to his attack, while slowing their attacks. Liquid Fire is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."


    Cooldown = New ValueWrapper(20, 15, 10, 4)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    attackslow = New ValueWrapper(20, 30, 40, 50)

    Radius = New ValueWrapper(300, 300, 300, 300)

    burndamage = New ValueWrapper(12, 16, 20, 24)

    Duration = New ValueWrapper(5, 5, 5, 5)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim attval As New modValue(attackslow, eModifierType.RightClickAttackAttackSlowInflicted, occurencetime, aghstime)
    attval.mValueDuration = Duration
    attval.mCooldown = Cooldown

    Dim attmod As New Modifier(attval, unittargetenemies)
    outmods.Add(attmod)


    Dim burnval As New modValue(burndamage, eModifierType.RightClickDamageoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    burnval.mValueDuration = Duration
    burnval.mCooldown = Cooldown

    Dim burnmod As New Modifier(burnval, unittargetenemies)
    outmods.Add(burnmod)



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
