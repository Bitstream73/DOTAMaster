Public Class abDuel
  Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "The loser of the duel is the hero that dies while under the buff. There is no victor if both heroes are alive at the end of the duration, and no damage bonus is granted.|The dueling units do not have to do the last hit to win the Duel. Allies may interfere.|Silences both, Legion Commander and the target. Dueling units cannot cast spells or items.|Dueling units will fully ignore disarm.|If a dueling unit becomes ethereal, it still is forced to attack the Duel target, and can still be attacked by the Duel target (though still won't be damaged by the physical attacks).|If a dueling unit gets hexed or entangled, it will stop attacking for its duration. However, if Duel is cast on an already hexed or entangled unit, it will attack.|Forces Batrider and Timbersaw (and Rubick) to attack even while having Flaming Lasso or Chakram active.|Duel has priority over Berserker's Call.|Casting Force Staff or  Geomagnetic Grip on a dueling unit will have no effect, wasting the mana and cooldown.|When a dueling unit is defeated and has Aegis of the Immortal or Reincarnation, the victor will still get the bonus damage. This goes for Tresdin and the Duel target.|When Legion Commander dies to the shatter of Ice Blast icon.png Ice Blast, the dueled enemy will not get bonus damage. If the Duel target dies to it instead, Tresdin will get the damage.|Duel can be cast on illusions. However, defeating them grants no bonus damage. But if the illusion is victorious, it will get the bonus damage, which is useless for the illusion." '"

    mDisplayName = "Duel"
    mName = eAbilityName.abDuel
    Me.EntityName = eEntity.abDuel

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLegion_Commander

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/legion_commander_duel_hp2.png"

    Description = "Legion Commander and the target enemy hero are forced to attack each other for a short duration. Neither hero can use items or abilities. If either hero dies during the duration, the hero winning the Duel gains permanent bonus damage."


    ManaCost = New ValueWrapper(75, 75, 75)

    Cooldown = New ValueWrapper(50, 50, 50)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)



    Duration = New ValueWrapper(4, 4.75, 5.5)

    bonusdamage = New ValueWrapper(10, 14, 18)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyhero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim moveval As New modValue(Duration, eModifierType.MuteMove, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemute As New Modifier(moveval, unittargetenemyhero)
    outmods.Add(movemute)


    Dim itemval As New modValue(Duration, eModifierType.MuteItems, occurencetime, aghstime)
    itemval.mValueDuration = Duration

    Dim itemmute As New Modifier(itemval, unittargetenemyhero)
    outmods.Add(itemmute)


    Dim abval As New modValue(Duration, eModifierType.MuteAbilities, occurencetime, aghstime)
    abval.mValueDuration = Duration

    Dim abilitymute As New Modifier(abval, unittargetenemyhero)
    outmods.Add(abilitymute)



    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim lcmovemute As New Modifier(moveval, notargetself)
    outmods.Add(lcmovemute)


    Dim lcitemmute As New Modifier(itemval, notargetself)
    outmods.Add(lcitemmute)


    Dim lcabilitymute As New Modifier(abval, notargetself)
    outmods.Add(lcabilitymute)

    Dim LCorTaget As New List(Of eUnit)
    LCorTaget.Add(eUnit.untSelf)
    LCorTaget.Add(eUnit.untEnemyTarget)

    Dim himorme = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active, LCorTaget)

    Dim bonusval As New modValue(bonusdamage, eModifierType.DuelBonusDamage, occurencetime, aghstime)

    Dim thebonus As New Modifier(bonusval, himorme)
    outmods.Add(thebonus)


    Dim drainval As New modValue(bonusdamage, eModifierType.DamageLost, occurencetime, aghstime)

    Dim thedrain As New Modifier(drainval, himorme)
    outmods.Add(thedrain)



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
