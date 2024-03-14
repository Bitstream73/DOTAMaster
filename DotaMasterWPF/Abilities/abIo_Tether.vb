Public Class abTether
  Inherits AbilityBase
  Public maxtetherdistance As ValueWrapper
  Public movementspeedbonus As ValueWrapper
  Public enemymoveslow As ValueWrapper
  Public enemyattackslow As ValueWrapper
  Public enemyslowduration As ValueWrapper
  Public healthmanamultiplier As ValueWrapper
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

    Notes = "Has a sub-ability that lets you break the tether.|If Io tries to tether a unit that is 700 units or further away, Io will latch on and pull itself with 1000ms closer to the target (to a distance of 300).|Can pull Io over impassable terrain and eventually get stuck.|Destroys trees within 350 aoe around Io right after the pull.|If Io breaks the Tether while getting pulled to the tethered target, the pull will immediatly stop.|When the distance between Io and the tethered target gets greater than 700, the link's visual appereance changes. At 700 it turns from teal to blue and at 800 it starts to flicker.|The tethered unit will benefit from Overcharge, Relocate, and from Io regenerating or replenishing health and mana.|Tethered units still benifit from all those effects even when turning magic immune, invulnerable or when hidden.|The health and mana regeneration will only be applied on the tethered unit if Io's respective pool isn't full.|The regeneration of any instant healing effect like Mekansm will be applied to the tethered unit depending on how much health was replenished on Io.|The regeneration of any instant mana regeneration effect like the Arcane Boots will be applied fully to the tethered unit if 1 or more mana was replenished on Io's mana pool.|A unit may only be slowed once per cast of Tether.|If an enemy Io is tethered to an invisible unit, the link is not correctly drawn for his enemies. The link draws between Io and the last known location of the invisible unit.|Disablehelp will prevent an allied Io from casting Tether on you." '"

    mDisplayName = "Tether"
    mName = eAbilityName.abTether
    Me.EntityName = eEntity.abTether

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untIo

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/wisp_tether_hp2.png"

    Description = "Tether yourself to an allied unit, granting both of you bonus movement speed. When you restore health or mana, your target gains 1.5x the amount. Any enemy unit that crosses the tether is slowed. The tether breaks when the allied unit moves too far away, or Io cancels the tether."

    ManaCost = New ValueWrapper(40, 40, 40, 40)

    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedHero)

    movementspeedbonus = New ValueWrapper(0.17, 0.17, 0.17, 0.17)

    Duration = New ValueWrapper(12, 12, 12, 12)

    enemymoveslow = New ValueWrapper(1, 1, 1, 1)

    enemyattackslow = New ValueWrapper(100, 100, 100, 100)

    enemyslowduration = New ValueWrapper(0.75, 1.25, 1.75, 2.25)

    healthmanamultiplier = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    maxtetherdistance = New ValueWrapper(900, 900, 900, 900)

    Radius = New ValueWrapper(maxtetherdistance.Value(0) / 2, _
                               maxtetherdistance.Value(1) / 2, _
                               maxtetherdistance.Value(2) / 2, _
                               maxtetherdistance.Value(3) / 2) 'used to compute affecteed targets of slow, etc
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetally = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim moveval As New modValue(movementspeedbonus, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim moveally As New Modifier(moveval, unittargetally)
    outmods.Add(moveally)

    Dim moveself As New Modifier(moveval, notargetself)



    Dim hpregenval As New modValue(healthmanamultiplier, eModifierType.HPRegenPercentofCasters, occurencetime, aghstime)
    hpregenval.mValueDuration = Duration

    Dim hpregenally As New Modifier(hpregenval, unittargetally)
    outmods.Add(hpregenally)

    Dim manaregen As New modValue(healthmanamultiplier, eModifierType.ManaRegenPercent, occurencetime, aghstime)
    hpregenval.mValueDuration = Duration

    Dim manaregenally As New Modifier(manaregen, unittargetally)
    outmods.Add(manaregenally)



    Dim enemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)


    Dim slowval As New modValue(enemymoveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = enemyslowduration
    slowval.mRadius = Radius
    Dim theenemymoveslow As New Modifier(slowval, enemies)
    outmods.Add(theenemymoveslow)



    Dim attslowval As New modValue(enemyattackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attslowval.mValueDuration = enemyslowduration
    attslowval.mRadius = Radius

    Dim theenemyattackslow As New Modifier(attslowval, enemies)
    outmods.Add(theenemyattackslow)



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
