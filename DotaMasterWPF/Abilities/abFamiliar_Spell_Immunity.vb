﻿Public Class abFamiliar_Spell_Immunity
  Inherits AbilityBase


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

    mDisplayName = "Spell Immunity"
    mName = eAbilityName.abFamiliar_Spell_Immunity
    Me.EntityName = eEntity.abFamiliar_Spell_Immunity

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFamiliar

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/0/01/Spell_Immunity_icon.png/120px-Spell_Immunity_icon.png?version=cfaf9011376f0e14d6a26e0de073cb9b"
    WebpageLink = "http://dota2.gamepedia.com/Visage#Familiars"
    Description = "This creature does not feel the effects of most magical spells."
    Notes = ""

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    'mAbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()


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

    Dim immval As New modValue(occurencetime.Lifespan.count, eModifierType.MagicImmunity, occurencetime)
    immval.mValueDuration = New ValueWrapper(occurencetime.Lifespan.count)
    Dim immod As New Modifier(immval, passiveself)
    outmods.Add(immod)
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
