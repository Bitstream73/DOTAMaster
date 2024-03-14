Public Class abSpirits
Inherits AbilityBase
  Public herodamage As ValueWrapper
  Public creepdamage As ValueWrapper
  Public explosionradius As ValueWrapper
  Public oscillationradius As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Upon use, Io gains 2 sub-abilities to control how far away the spirits orbit.|Spirits are summoned over the course of four seconds.|The spirits complete a revolution every ~2.3 seconds regardless of distance from Io. (Their angular velocity is constant, meaning that spirits move more quickly when further from Io.)|Spirits will not collide and explode on magic immune, invulnerable or hidden heroes.|All unspent spirits will simultaneously detonate at the end of the duration or if recast, dealing full damage to nearby creeps and heroes.|Spirits provide 300 aoe vision for 3 seconds at the location where they collided with a hero. They do not provide vision when exploding caused by expiring or recasting.|Unlike most other spells, the spirits are visible to the enemy even if Io is invisible.|Deals a total of 125/250/375/500 damage (before reductions)." '"

    mDisplayName = "Spirits"
    mName = eAbilityName.abSpirits
    Me.EntityName = eEntity.abSpirits

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untIo

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/wisp_spirits_hp2.png"

    Description = "Summon five particle spirits that dance in a circle around Io, damaging all that they hit around you. If a particle hits an enemy hero, it explodes, damaging all enemy units in an area around it. Creeps take minor damage from touching a particle spirits, but don't cause them to explode. After the duration, the Spirits will explode."

    ManaCost = New ValueWrapper(120, 130, 140, 150)


    Cooldown = New ValueWrapper(20, 18, 16, 14)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    creepdamage = New ValueWrapper(8, 14, 20, 26)

    herodamage = New ValueWrapper(25, 50, 75, 100)

    oscillationradius = New ValueWrapper(875, 875, 875, 875)

    explosionradius = New ValueWrapper(300, 300, 300, 300)

    Duration = New ValueWrapper(19, 19, 19, 19)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    'Dim theaffects As New List(Of eUnit)
    'theaffects.Add(eUnit.untEnemyHero)
    'theaffects.Add(eUnit.untEnemyCreep)

    Dim auraenemyhero = Helpers.GetActiveAuraEnemyHeroesInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim damheroval As New modValue(herodamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damheroval.Charges = New ValueWrapper(5, 5, 5, 5)

    Dim theherodamage As New Modifier(damheroval, auraenemyhero)
    outmods.Add(theherodamage)

    Dim auraenemycreep = Helpers.GetActiveAuraEnemyCreepsInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim creepdamval As New modValue(creepdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)


    Dim thecreepdamage As New Modifier(creepdamval, auraenemycreep)
    outmods.Add(thecreepdamage)

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
