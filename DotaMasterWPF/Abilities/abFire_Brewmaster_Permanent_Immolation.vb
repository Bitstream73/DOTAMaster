Public Class abFire_Brewmaster_Permanent_Immolation
  Inherits AbilityBase

  Public dps As ValueWrapper
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

    mDisplayName = "Permanent Immolation"
    mName = eAbilityName.abFire_Brewmaster_Permanent_Immolation
    Me.EntityName = eEntity.abFire_Brewmaster_Permanent_Immolation

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFire_Brewmaster

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/1/1f/Permanent_Immolation_%28Fire%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster#Fire"
    Description = "Burns nearby enemy units."
    Notes = "Permanent Immolation is an aura. Its debuff lingers for 0.5 seconds.|Deals damage in 1 second intervals, starting 1 second after the debuff is placed.|Can deal up to 225/510/855 damage to a single unit (before reduction) when it stays within range for its whole duration.|Does not affect ancient creeps, Roshan, Warlock's Golem and Storm and Fire from Primal Split."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    dps = New ValueWrapper(15, 30, 45)
    Radius = New ValueWrapper(220, 220, 220)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetenemies = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)
    Dim damval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, occurencetime, aghstime)
    damval.mValueInterval = New ValueWrapper(1, 1, 1)

    Dim dammod As New Modifier(damval, notargetenemies)
    outmods.Add(dammod)

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
