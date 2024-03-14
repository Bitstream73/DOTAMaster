Public Class abSpirit_Bear_Return
  Inherits AbilityBase

  Public teleportcount As ValueWrapper
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

    mDisplayName = "Return"
    mName = eAbilityName.abSpirit_Bear_Return
    Me.EntityName = eEntity.abSpirit_Bear_Return

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Bear

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/b/b8/Return_%28Spirit_Bear%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Spirit_Bear#Spirit_Bear"
    Description = "Immediately teleports the Spirit Bear back to the Lone Druid. The Spirit Bear cannot teleport if it has taken damage from a player unit in the last 3 seconds."
    Notes = "Return requires Summon Spirit Bear level 2 to be unlocked.|Return has an instant cast time, but interupts the bear's channeling spells upon cast.|Return disjoints projectiles upon cast.|Return can be cast from anywhere on the map.|Taking player based damage puts Return on a 3 second cooldown."

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(0, 5, 5, 5)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSpirit_Bear)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    teleportcount = New ValueWrapper(-1, 1, 1, 1)
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


    Dim tpval As New modValue(teleportcount, eModifierType.Teleport, occurencetime, aghstime)

    Dim tpmod As New Modifier(tpval, notargetself)
    outmods.Add(tpmod)

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
