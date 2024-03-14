﻿Public Class abGiant_Wolf_Critical_Strike
  Inherits AbilityBase
  Public critchance As ValueWrapper
  Public critmult As ValueWrapper

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

    mDisplayName = "Critical Strike"
    mName = eAbilityName.abGiant_Wolf_Critical_Strike
    Me.EntityName = eEntity.abGiant_Wolf_Critical_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGiant_Wolf

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/69/Critical_Strike_%28Alpha_Wolf%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Alpha_Wolf"
    Description = "The Giant Wolf's ferocious attacks occasionally tear a vital tendon, inflicting critical damage."
    Notes = ""

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyUnits)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    critchance = New ValueWrapper(0.2)
    critmult = New ValueWrapper(2)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim critval As New modValue(critmult, eModifierType.CritMultiplier, occurencetime, aghstime)
    critval.mPercentChance = critchance

    Dim critmod As New Modifier(critval, passiveself)
    outmods.Add(critmod)

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
