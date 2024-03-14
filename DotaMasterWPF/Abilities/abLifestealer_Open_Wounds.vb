Public Class abOpen_Wounds
Inherits AbilityBase
  Public lifeleech As ValueWrapper
  Public maxslow As ValueWrapper

  Public slowvals As New List(Of Double?)
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

    mDisplayName = "Open Wounds"
    mName = eAbilityName.abOpen_Wounds
    Me.EntityName = eEntity.abOpen_Wounds

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLifestealer

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/life_stealer_open_wounds_hp2.png"

    Description = "Lifestealer rends an enemy unit, slowing the victim's movespeed and allowing all allies to lifesteal on that unit. All damage dealt will steal life, including damage from spells. The victim recovers movement speed over the duration."

    ManaCost = New ValueWrapper(110, 110, 110, 110)

    Cooldown = New ValueWrapper(24, 20, 16, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)
    Affects.Add(eUnit.untAlliedHeroes)

    lifeleech = New ValueWrapper(0.15, 0.2, 0.25, 0.3)

    maxslow = New ValueWrapper(0.7, 0.7, 0.7, 0.7)

    Duration = New ValueWrapper(8, 8, 8, 8)

    Range = New ValueWrapper(200, 300, 400, 500)

    slowvals.Add(0.7)
    slowvals.Add(0.7)
    slowvals.Add(0.6)
    slowvals.Add(0.5)
    slowvals.Add(0.3)
    slowvals.Add(0.1)
    slowvals.Add(0.1)
    slowvals.Add(0.1)


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

    Dim lifeval As New modValue(lifeleech, eModifierType.LifestealAddedtoAllAttackers, occurencetime, aghstime)
    lifeval.mValueDuration = Duration

    Dim lifemod As New Modifier(lifeval, unittargetenemy)
    outmods.Add(lifemod)


    Dim slowval As New modValue(1, eModifierType.OpenWoundsSlowInflicted, occurencetime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(slowmod)



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
