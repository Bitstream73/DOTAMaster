Public Class abSatyr_Banisher_Purge
  Inherits AbilityBase

  Public moveslow As ValueWrapper
  Public summonsdamage As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Banisher Purge"
    mName = eAbilityName.abSatyr_Banisher_Purge
    Me.EntityName = eEntity.abSatyr_Banisher_Purge

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSatyr_Banisher

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/3/34/Purge_%28Satyr_Banisher%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Satyr_Camp"
    Description = "The Satyr Banisher knows every trick in the book, allowing him to remove debuffs from allies or buffs from enemies. His trickery also slows the enemy's movement. If the enemy is a summoned unit or an illusion, it takes damage as well."
    Notes = "Applies a normal dispel on the target upon cast.|The slow deceases in 1 second intervals, so it slows for 100%/80%/60%/40%/20% during the 1st/2nd/3rd/4th/5th second.|Does not slow or damage allied targets.|Can not be cast on invulnerable units.|As a neutral unit: The satyr never casts this spell.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(120)

    Cooldown = New ValueWrapper(5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)
    Affects.Add(eUnit.untAlliedUnit)

    Range = New ValueWrapper(350)

    moveslow = New ValueWrapper(1)

    summonsdamage = New ValueWrapper(400)

    slowduration = New ValueWrapper(5)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim targetfriend = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim enemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untEnemyIllusion)
    theaffects.Add(eUnit.untEnemyPet)
    Dim enemyillusion = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active, _
                                                                             theaffects)


    Dim moveval As New modValue(slowduration, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, enemytarget)
    outmods.Add(movemod)

    Dim buffval As New modValue(1, eModifierType.RemoveBuffs, occurencetime)

    Dim buffmod As New Modifier(buffval, enemytarget)
    outmods.Add(buffmod)


    Dim debuffval As New modValue(1, eModifierType.RemoveDebuffs, occurencetime)

    Dim debuffmod As New Modifier(debuffval, targetfriend)
    outmods.Add(debuffmod)


    Dim damval As New modValue(summonsdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, enemyillusion)
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
