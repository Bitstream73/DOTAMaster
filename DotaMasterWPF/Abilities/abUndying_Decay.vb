Public Class abDecay
Inherits AbilityBase
  Public strengthsteal As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Decay"
    mName = eAbilityName.abDecay
    Me.EntityName = eEntity.abDecay

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUndying

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/undying_decay_hp2.png"

    Description = "Undying saps the life from enemy Heroes in an area, dealing damage and stealing Strength for the duration."

    ManaCost = New ValueWrapper(70, 90, 110, 130)

    Cooldown = New ValueWrapper(10, 8, 6, 4)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyHeroes)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(20, 60, 100, 140)

    Duration = New ValueWrapper(40, 40, 40, 40)

    Radius = New ValueWrapper(325, 325, 325, 325)

    strengthsteal = New ValueWrapper(4, 4, 4, 4)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)

    Dim pointtargetenemyheroes = Helpers.GetPointTargetEnemyHeroesInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemyheroes)
    outmods.Add(dammod)


    Dim stealval As New modValue(strengthsteal, eModifierType.StrSubtracted, occurencetime, aghstime)
    stealval.mValueDuration = Duration

    Dim stealmod As New Modifier(stealval, pointtargetenemyheroes)
    outmods.Add(stealmod)


    Dim gainval As New modValue(strengthsteal, eModifierType.StrAdded, occurencetime, aghstime)
    gainval.mValueDuration = Duration

    Dim gainmod As New Modifier(gainval, pointtargetself)
    outmods.Add(gainmod)

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
