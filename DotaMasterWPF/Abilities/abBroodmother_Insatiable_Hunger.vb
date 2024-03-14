Public Class abInsatiable_Hunger
  Inherits AbilityBase
  Public damagebonus As ValueWrapper
  Public lifesteal As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Fully stacks with all other sources of lifesteal.|The damage is added as raw damage bonus, so it can be reduced by e.g. Enfeeble, but not amplified by e.g. Empower. It can crit and cleave.|Lifesteal also works when attacking allies and wards, but not buildings." '"
    mDisplayName = "Insatiable Hunger"
    mName = eAbilityName.abInsatiable_Hunger

    Me.EntityName = eEntity.abInsatiable_Hunger

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBroodmother

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/broodmother_insatiable_hunger_hp2.png"

    Description = "A violent lust for vital fluids increases Broodmother's attack damage and gives her a vampiric attack."

    ManaCost = New ValueWrapper(100, 100, 100)

    Cooldown = New ValueWrapper(45, 45, 45)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    damagebonus = New ValueWrapper(60, 80, 100)

    lifesteal = New ValueWrapper(0.6, 0.8, 1)


    Duration = New ValueWrapper(14, 14, 14)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)



    Dim damval As New modValue(damagebonus, eModifierType.DamagePhysicalAdded, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim thedamagebonus As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamagebonus)



    Dim lifeval As New modValue(lifesteal, eModifierType.LifeStealPercent, occurencetime, aghstime)
    lifeval.mValueDuration = Duration

    Dim thelifesteal As New Modifier(lifeval, unittargetenemy)
    outmods.Add(thelifesteal)

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
