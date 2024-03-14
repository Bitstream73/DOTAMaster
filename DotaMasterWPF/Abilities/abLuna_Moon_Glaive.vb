Public Class abMoon_Glaive
Inherits AbilityBase

  Public bounces As ValueWrapper
  Public damagereduction As ValueWrapper
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

    Notes = "The bouncing glaive travels at a speed of 900 (the same speed as her attack projectile).|When the initial attack is evaded or disjointed, Moon Glaive icon.png Moon Glaive will not bounce.|When a bounce is disjointed however, it will bounce on the disjointing unit again if it's in range. If not, it will bounce on the nearest valid target.|A disjointed bounce will still count as a bounce, so it reduces the amount of bounces left.|It does not matter how much damage the initial target from the attack takes, the bounces will always deal damage based on Luna's avarage base damage + bonus damage.|This means that the armor of the initial attack target does not influence the bounce's damage at all. It also means that damage from attack modifiers like crits do not affect it either.|So the only way to make the glaives deal more damage is to increase Luna's base damage via stats, give her a raw damage bonus, or reduce the armor of the bounce targets.|Other effects of attack modifiers like bash or lifesteal is only applied to the attack target.|Can bounce back to the same units if it already hit all other units nearby. If no other units are nearby, this skill does nothing.|Deals a grand total of 65/107/135/164% extra physical damage assuming max bounces per level.|Does not bounce towards wards, Tombstone and Power Cogs, but it does bounce off of them when attacking them.|Bounces off of allies when attacking them.|Upon learning, Luna's glaive permanentally emits blue particles, visible to everyone." '"

    mDisplayName = "Moon Glaive"
    mName = eAbilityName.abMoon_Glaive

    Me.EntityName = eEntity.abMoon_Glaive

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLuna

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/luna_moon_glaive_hp2.png"

    Description = "Allows Luna's glaive to bounce to enemy units near the attacked unit. Each bounce deals less damage."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)



    Radius = New ValueWrapper(500, 500, 500, 500)

    bounces = New ValueWrapper(1, 2, 3, 4)

    damagereduction = New ValueWrapper(0.35, 0.35, 0.35, 0.35)
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




    Dim unittargetuntargetted = Helpers.GetUnitTargetUntargettedEnemyUnitsInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    'Dim thecasterinf = thegame.dbHeroBuilds.GetHeroBuild(theowner)
    'Dim currdamage = thecasterinf.GetRightClickDamage(occurencetime)


    Dim thedam As New modValue(damagereduction, eModifierType.RightClickMoonGlaiveBounces, occurencetime, aghstime)
    thedam.Charges = bounces

    Dim dammulitplier As New Modifier(thedam, unittargetuntargetted)
    outmods.Add(dammulitplier)







    Return outmods
  End Function
End Class
