Public Class abFire_Brewmaster_Drunken_Brawler
  Inherits AbilityBase


  Public dodgechance As ValueWrapper
  Public agsdodgechance As List(Of Double?)

  Public critchance As ValueWrapper
  Public agscritchance As List(Of Double?)

  Public critdamagemulitiplier As ValueWrapper
  Public agscritdammultiplier As List(Of Double?)

  Public certaintrigger As ValueWrapper
  Public agscertaintrigger As List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Drunken Brawler"
    mName = eAbilityName.abFire_Brewmaster_Drunken_Brawler
    Me.EntityName = eEntity.abFire_Brewmaster_Drunken_Brawler

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFire_Brewmaster

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/d/d9/Drunken_Brawler_icon.png/120px-Drunken_Brawler_icon.png?version=e532f3ec66ade11eeba0e9d1b7db520b"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster#Fire"
    Description = "Gives a chance to avoid attacks and to deal critical damage. Drunken Brawler will always trigger if you have not attacked, or have been attacked, in the last several seconds."
    Notes = "Given to Fire when holding Aghanim's Scepter, at the same level as the original Brewmaster|Drunken Brawler evasion stacks multiplicatively with other sources of evasion.|The guaranteed critical attack and guaranteed dodge chance are on separate cooldowns.|While on cooldown, Brewmaster can still passively dodge and perform critical strikes.|When the guaranteed critical strike is off cooldown, Fire's upper body emits particles, while a red streak is visible on the icon.|When the guaranteed dodge is off cooldown, Fire's lower body emits particles, while the icon's yellow background turns orange.|The guaranteed critical strike is only used up when the attack actually lands. Missed attacks don't put it on cooldown."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.AutoCast)

    Affects.Add(eUnit.untSelf)

    dodgechance = New ValueWrapper(-1, -1, -1, -1)
    agsdodgechance = New List(Of Double?)
    agsdodgechance.Add(0.1)
    agsdodgechance.Add(0.15)
    agsdodgechance.Add(0.2)
    agsdodgechance.Add(0.25)
    dodgechance.LoadScepterValues(agsdodgechance)


    critchance = New ValueWrapper(-1, -1, -1, -1)
    agscritchance = New List(Of Double?)
    agscritchance.Add(0.1)
    agscritchance.Add(0.15)
    agscritchance.Add(0.2)
    agscritchance.Add(0.25)
    critchance.LoadScepterValues(agscritchance)

    critdamagemulitiplier = New ValueWrapper(-1, -1, -1, -1)
    agscritdammultiplier = New List(Of Double?)
    agscritdammultiplier.Add(2)
    agscritdammultiplier.Add(2)
    agscritdammultiplier.Add(2)
    agscritdammultiplier.Add(2)
    critdamagemulitiplier.LoadScepterValues(agscritdammultiplier)


    certaintrigger = New ValueWrapper(16, 14, 12, 10)
    agscertaintrigger = New List(Of Double?)
    agscertaintrigger.Add(16)
    agscertaintrigger.Add(14)
    agscertaintrigger.Add(12)
    agscertaintrigger.Add(10)
    certaintrigger.LoadScepterValues(agscertaintrigger)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   caster, _
                                                  target, _
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
