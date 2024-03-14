Public Class abDrunken_Brawler
Inherits AbilityBase


  Public dodgechance As ValueWrapper
  Public critchance As ValueWrapper
  Public critdamagemulitiplier As ValueWrapper
  Public certaintrigger As ValueWrapper
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

    Notes = "Drunken Brawler does stack with other sources of evasion.|The guaranteed critical attack and guaranteed dodge chance are on separate timers.|If Brewmaster is guaranteed to evade the next attack on him, the icon will turn orange, and he will gain a shimmering effect around him. If he is guaranteed to preform a critical strike on his next attack, a red streak will appear on the icon, and he will gain a red shimmering affect around his shoulders and weapon.|Illusions will also have the guaranteed critical hit and evasion." '"
    mDisplayName = "Drunken Brawler"
    mName = eAbilityName.abDrunken_Brawler
    Me.EntityName = eEntity.abDrunken_Brawler

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBrewmaster

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/brewmaster_drunken_brawler_hp2.png"

    Description = "Gives a chance to avoid attacks and to deal critical damage. Drunken Brawler will always activate if you have not attacked, or have not been attacked, in the last 10 seconds."

    '  mManaCost = New ValueWrapper(50, 50, 50, 50)

    'mCooldown

    AbilityTypes.Add(eAbilityType.AutoCast)

    Affects.Add(eUnit.untSelf)

    dodgechance = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    critchance = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    critdamagemulitiplier = New ValueWrapper(2, 2, 2, 2)

    certaintrigger = New ValueWrapper(16, 14, 12, 10)
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
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                  thetarget, _
                                                  "", eModifierCategory.Passive)

    'evasion (dodge)
    Dim dodgeval As New modValue(dodgechance, eModifierType.EvasionPercent, certaintrigger, occurencetime, aghstime)

    Dim thedodge As New Modifier(dodgeval, notargetself)
    outmods.Add(thedodge)


    'crit
    Dim critval As New modValue(critdamagemulitiplier, eModifierType.CritMultiplier, certaintrigger, occurencetime, aghstime)
    critval.mPercentChance = critchance

    Dim critdamage As New Modifier(critval, notargetself)
    outmods.Add(critdamage)


    Return outmods
  End Function


End Class
