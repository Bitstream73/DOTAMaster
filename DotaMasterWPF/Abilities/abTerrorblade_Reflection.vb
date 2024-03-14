Public Class abReflection
Inherits AbilityBase

  Public refdamage As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
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

    mDisplayName = "Reflection"
    mName = eAbilityName.abReflection
    Me.EntityName = eEntity.abReflection

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTerrorblade

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/terrorblade_reflection_hp2.png"

    Description = "Terrorblade brings forth an invulnerable dark illusion of the targeted enemy Hero. The enemy Hero is slowed and attacked by the illusion for a short duration."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(22, 18, 14, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    Duration = New ValueWrapper(5.5, 4.5, 3.5, 2.5)

    refdamage = New ValueWrapper(0.4, 0.5, 0.6, 0.7)

    moveslow = New ValueWrapper(0.6, 0.6, 0.6, 0.6)

    attslow = New ValueWrapper(60, 60, 60, 60)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    'reflection pet
    Dim refval As New modValue(1, eModifierType.HeroReflection, occurencetime)
    refval.mValueDuration = Duration

    Dim refmod As New Modifier(refval, unittargetenemy)
    outmods.Add(refmod)


    'attack slow
    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, unittargetenemy)
    outmods.Add(attmod)


    'move slow
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittargetenemy)
    outmods.Add(movemod)

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
