Public Class abAncient_Thunderhide_Frenzy
  Inherits AbilityBase

  Public attackspeedbonus As ValueWrapper
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

    mName = eAbilityName.abAncient_Thunderhide_Frenzy
    Me.EntityName = eEntity.abAncient_Thunderhide_Frenzy

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Thunderhide
    mDisplayName = "Frenzy"
    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/0/0b/Frenzy_icon.png/120px-Frenzy_icon.png?version=1807fed8f8b995a74721ce6b3391f227"
    WebpageLink = "http://dota2.gamepedia.com/Thunderhide_Camp"
    Description = "The Ancient Thunderhide works himself into a frenzy, increasing his attack speed."
    Notes = "As of now, Frenzy has no legacy hotkey.|As a neutral unit: The thunderhide casts this spell whenever it is directly attacked and aggroed.|However, after casting it once, it always cast it when aggroed, even when not directly attacked.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(50)

    Cooldown = New ValueWrapper(8)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    Duration = New ValueWrapper(8)

    attackspeedbonus = New ValueWrapper(75)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim attval As New modValue(attackspeedbonus, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim atmod As New Modifier(attval, notargetself)
    outmods.Add(atmod)

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
