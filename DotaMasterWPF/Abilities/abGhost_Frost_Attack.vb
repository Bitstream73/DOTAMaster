Public Class abGhost_Frost_Attack
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

    mDisplayName = "Frost Attack"
    mName = eAbilityName.abGhost_Frost_Attack
    Me.EntityName = eEntity.abGhost_Frost_Attack

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGhost

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/7/73/Frost_Attack_%28Ghost%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Ghost"
    Description = "The Ghost launches an eerie attack that chills her enemies to their bones."
    Notes = "The slow from successive attacks don't stack, only the duration gets refreshed.|Does not affect siege creeps, wards and buildings."

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    'mAffects.Add(eUnit)

    Duration = New ValueWrapper(1.5)


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

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, targetenemy)
    outmods.Add(movemod)

    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, targetenemy)

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
