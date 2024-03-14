Public Class abRoshan_Bash
  Inherits AbilityBase

  Public procchance As ValueWrapper
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

    mDisplayName = "Bash"
    mName = eAbilityName.abRoshan_Bash
    Me.EntityName = eEntity.abBash

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRoshan

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/0a/Bash_%28Roshan%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Roshan"
    Description = "Roshan has a chance to stun on attack."
    Notes = "The damage is directly added to Roshan's attack damage, so it is affected by attack damage reduction and it technically can lifesteal off of it.|Adds an average of 7.5 damage to every attack.|Damages, but does not stun wards.|Fully affects buildings."

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    procchance = New ValueWrapper(0.15)
    Damage = New ValueWrapper(50)
    Duration = New ValueWrapper(1.65)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim enemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim stunval As New modValue(Duration, eModifierType.RightClickStun, occurencetime, aghstime)
    stunval.mPercentChance = procchance

    Dim stunmod As New Modifier(stunval, enemytarget)
    outmods.Add(stunmod)

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
