Public Class abBoar_Poison
  Inherits AbilityBase

  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
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

    mName = eAbilityName.abBoar_Poison
    Me.EntityName = eEntity.abBoar_Poison

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBoar

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False
    mDisplayName = "Poison"
    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/9/9c/Poison_%28Boar%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Beastmaster#Beastmaster.27s_Boar"
    Description = "Inflicts a poison that slows attack and movement speeds."
    Notes = "Level scales together with Call of the Wild's level. However, the level of already summoned boars does not adapt.|Successive attacks do not stack the slow, they refresh the duration."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)
    'mAffects.Add(eUnit)

    Duration = New ValueWrapper(3, 3, 3, 3)

    moveslow = New ValueWrapper(0.1, 0.2, 0.3, 0.4)
    attslow = New ValueWrapper(10, 20, 30, 40)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim targetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, targetenemy)
    outmods.Add(movemod)

    Dim attval As New modValue(attslow, eModifierType.AttackSpeedPercentSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, targetenemy)
    outmods.Add(attmod)


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
