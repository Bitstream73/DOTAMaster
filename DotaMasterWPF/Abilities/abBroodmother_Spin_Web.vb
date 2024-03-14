Public Class abSpin_Web
Inherits AbilityBase
  Public maxwebs As ValueWrapper
  Public healthregen As ValueWrapper
  Public moveincrease As ValueWrapper
  Public maxwebcharges As ValueWrapper
  Public chargerestortime As ValueWrapper '= 40
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

    Notes = "Spin Web has a cast time of 0.4 seconds.|When learning the 1st level of Spin Web, Broodmother instantly has 1 charge. However, leveling it up does not instantly grant the 2nd, 3rd or 4th charge.|Movement speed, unobstructed movement and health regeneration are instantly granted when entering a Spin Web.|The Invisibility has a fade time of 2 seconds and instantly starts when entering a Spin Web icon.png Spin Web.|When leaving a Spin Web, all its granted effects linger for 0.15 seconds.|When taking damage from an enemy player, the unobstructed pathing is instantly lost and the movement speed bonus instantly reduced to 20%/25%/30%/35%.|When taken out of her unobstructed pathing, trees within 150 radius around her get destroyed.|When Broodmother gets silenced during the fade time, she will not turn invisible. However, once the silence fades, she will instantly turn invisible when still inside a Spin Web.|Doom will fully reveal Broodmother for its full duration. Other bonuses from Spin Web icon.png Spin Webs are not stopped by silence or Doom.|Spiderlings and Spiderites are fully affected by Spin Webs as well, and react the same way as Broodmother when taking damage.|All other units owned by Broodmother are not affected by Spin Webs, including her illusions.|Spin Webs are visible on the mini-map for Broodmother and her allies. They do not provide vision but are selectable for Broodmother through the Fog of War.|The web will distinctly twitch whenever Broodmother walks on it, indicating her position. The twitching is not visible when Broodmother is not visible (enemies require True Sight).|When using Refresher Orb while having no charges, the spell will refresh and no longer require the charges.|Spin Webs possess the Destroy Spin Web ability.|Destroy Spin Web cast from the web itself, allowing Broodmother to destroy webs individually instead of having the oldest one destroyed.|Destroy Spin Web Has an instant cast time.|Spin webs do not leave corpses." '"
    mDisplayName = "Spin Web"
    mName = eAbilityName.abSpin_Web
    Me.EntityName = eEntity.abSpin_Web

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBroodmother

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/broodmother_spin_web_hp2.png"

    Description = "Throws out a web that renders Broodmother invisible, grants a passive movement speed increase, gives free movement, and boosts regeneration while in its vicinity. Free movement is disabled for 3 seconds if damage is taken. Webs never expire. When the maximum limit of webs is exceeded, the oldest web disappears."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    ' mCooldown = New ValueWrapper(30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    maxwebs = New ValueWrapper(2, 4, 6, 8)

    healthregen = New ValueWrapper(2, 4, 6, 8)

    moveincrease = New ValueWrapper(0.4, 0.5, 0.6, 0.7)

    maxwebcharges = New ValueWrapper(1, 2, 3, 4)

    chargerestortime = New ValueWrapper(40, 40, 40, 40)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)


    Dim regenval As New modValue(healthregen, eModifierType.HPRegenAdded, occurencetime, aghstime)

    Dim hpregen As New Modifier(regenval, pointtargetself)
    outmods.Add(hpregen)


    Dim moveval As New modValue(moveincrease, eModifierType.MoveSpeedPercent, occurencetime, aghstime)

    Dim movespeed As New Modifier(moveval, pointtargetself)
    outmods.Add(movespeed)

    'thewebs
    Dim webval As New modValue(maxwebcharges, eModifierType.Web, occurencetime, aghstime)

    Dim webmod As New Modifier(webval, pointtargetself)
    outmods.Add(webmod)

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
