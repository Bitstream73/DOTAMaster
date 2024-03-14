Public Class abGolem_Warlock_Permanent_immolation
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
    mName = eAbilityName.abGolem_Warlock_Permanent_immolation
    Me.EntityName = eEntity.abGolem_Warlock_Permanent_immolation

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untGolem_Warlock

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/d/d3/Permanent_Immolation_%28Warlock%27s_Golem%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Warlock#Warlock.27s_Golem"
    Description = "Burns the Golem's nearby enemy units, with damage per second."
    Notes = "Permanent Immolation is an aura. The debuff lingers for 0.5 seconds.|Deals damage in 1 second intervals, starting 1 second after the debuff is placed.|Can deal up to 1800/2400/3000 damage to a single unit (before reduction) when it stays within range for its whole duration.|Permanent Immolations of multiple golems fully stack with each other.|Does not affect ancient creeps, Roshan, an enemy Warlock's Golem and Brewmaster's Storm and Fire from Primal Split."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    Duration = New ValueWrapper(60, 60, 60)
    Radius = New ValueWrapper(300, 300, 300)

    dps = New ValueWrapper(30, 40, 50)

    DamageType = eDamageType.Magical
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

    Dim dpsval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, occurencetime, aghstime)
    dpsval.mValueDuration = Duration

    Dim dpsmod As New Modifier(dpsval, notargetenemies)
    outmods.Add(dpsmod)


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
