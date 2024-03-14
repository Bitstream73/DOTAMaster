Public Class abBattle_Hunger
  Inherits AbilityBase
  Dim moveslow As ValueWrapper ' = 0.1
  Dim speedbonus As ValueWrapper 'Single = 0.1
  Dim damagepersec As ValueWrapper

  Public Sub New()

    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False
    mDisplayName = "Battle Hunger"
    Notes = "Killing illusions, denying a friendly creep or destroying buildings will also remove the debuff.|Units affected by Battle Hunger cannot be denied.|Killing using summons does not remove debuff.|Has a maximum range of 900.|Total Damage: 150/240/350/480."

    mName = eAbilityName.abBattle_Hunger
    Me.EntityName = eEntity.abBattle_Hunger

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAxe

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/axe_battle_hunger_hp2.png"
    WebpageLink = ""
    Description = "Enrages an enemy unit, causing it to be slowed and take damage over time until it kills another unit or the duration ends. Axe gains movement speed for each unit affected with Battle Hunger."

    ManaCost = New ValueWrapper(75, 75, 75, 75)


    Cooldown = New ValueWrapper(20, 15, 10, 5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(16, 24, 32, 40)


    Duration = New ValueWrapper(10, 10, 10, 10)

    damagepersec = Damage

    moveslow = New ValueWrapper(0.12, 0.12, 0.12, 0.12)

    speedbonus = New ValueWrapper(0.12, 0.12, 0.12, 0.12)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim movespeedval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)

    Dim enemymoveslo As New Modifier(movespeedval, unittargetenemytargetinfo)

    outmods.Add(enemymoveslo)


    Dim dotval As New modValue(damagepersec, eModifierType.DamageMagicalPerSec, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dot As New Modifier(dotval, unittargetenemytargetinfo)

    outmods.Add(dot)


    'axe movespeedbuff
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim moveval As New modValue(speedbonus, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    Dim movemod As New Modifier(moveval, notargetself)

    outmods.Add(movemod)
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
