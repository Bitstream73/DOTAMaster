Public Class abTrack
Inherits AbilityBase
  Public speedradius As ValueWrapper
  Public bonusspeed As ValueWrapper
  Public bonusgoldforself As ValueWrapper
  Public bonusgoldforallies As ValueWrapper
  Public castrange As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Despite the visual effect, the Track debuff is applied instantly on the target.|Gives True Sight and shared vision of the target.|Grants the gold to Bounty Hunter and his allies around the target when the target dies, no matter how it dies.|Bonus gold will be added as reliable gold.|Track can be cast on illusions, but dying illusions will not grant any gold.|Allies will only get the bonus gold if they have the move speed buff on. Bounty Hunter will get the gold regardless of the buff.|The move speed is provided by an aura on the target, so the buff lingers for 0.5 seconds after leaving the affected area.|When Meepos are tracked and he dies, each Meepo will grant the Track gold around them.|The visual effects and sound of Track are only visible and audible to Bounty Hunter and his allies. However, the debuff is visible to everyone.|The visual effects on allies given by the move speed buff are visible to everyone aswell.|The move speed buff is also applied on neutral creeps, including Roshan." '"
    mDisplayName = "Track"
    mName = eAbilityName.abTrack

    Me.EntityName = eEntity.abTrack

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBounty_Hunter

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bounty_hunter_track_hp2.png"

    Description = "Tracks an enemy hero, giving True Sight of it and grants a gain in movement speed to allies near the hunted. If the target dies, Bounty Hunter and nearby heroes collect a bounty in gold."


    ManaCost = New ValueWrapper(50, 50, 50)

    Cooldown = New ValueWrapper(4, 4, 4)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyHeroes)

    speedradius = New ValueWrapper(900, 900, 900)

    bonusspeed = New ValueWrapper(0.2, 0.2, 0.2)

    bonusgoldforself = New ValueWrapper(200, 275, 350)

    bonusgoldforallies = New ValueWrapper(50, 100, 150)

    Duration = New ValueWrapper(30, 30, 30)

    castrange = New ValueWrapper(1200, 1200, 1200)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    'truesight
    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim notargetallies = Helpers.GetNoTargetAlliedHeroesInfo(theability_InfoID, _
                                                           thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)

    Dim trueval As New modValue(Duration, eModifierType.TruesightofTarget, occurencetime, aghstime)
    trueval.mValueDuration = Duration

    Dim BHtruesght As New Modifier(trueval, unittargetenemy)
    outmods.Add(BHtruesght)

    Dim alliestruesight As New Modifier(trueval, notargetallies)
    outmods.Add(alliestruesight)

    'potential self bounty gold
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                               thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim selfbountyval As New modValue(bonusgoldforself, eModifierType.BountyGold, occurencetime, aghstime)

    Dim selfbounty As New Modifier(selfbountyval, notargetself)
    outmods.Add(selfbounty)


    'potential teammate bounty gold
    Dim allybountyval As New modValue(bonusgoldforallies, eModifierType.BountyGold, occurencetime, aghstime)

    Dim allybounty As New Modifier(allybountyval, notargetallies)
    outmods.Add(allybounty)


    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
