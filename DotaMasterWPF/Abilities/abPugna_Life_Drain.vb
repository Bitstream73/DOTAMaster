Public Class abLife_Drain
Inherits AbilityBase
  Public drainpersec As ValueWrapper
  Public scepterdrainpersec As New List(Of Double?)


Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Life Drain"
    mName = eAbilityName.abLife_Drain
    Me.EntityName = eEntity.abLife_Drain

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPugna

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/pugna_life_drain_hp2.png"

    Description = "CHANNELED - While channelling Life Drain, Pugna siphons HP from the target enemy unit. If Pugna has full HP, and the target is a Hero, Life Drain will restore mana instead. Lasts 10 seconds. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(125, 175, 225)

    Cooldown = New ValueWrapper(22, 22, 22)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)
    Affects.Add(eUnit.untAlliedUnit)

    DamageType = eDamageType.Magical

    drainpersec = New ValueWrapper(120, 160, 200)
    scepterdrainpersec.Add(180)
    scepterdrainpersec.Add(240)
    scepterdrainpersec.Add(300)
    drainpersec.LoadScepterValues(scepterdrainpersec)

    Range = New ValueWrapper(850, 850, 850)

    Duration = New ValueWrapper(10, 10, 10)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedUnit)
    theaffects.Add(eUnit.untEnemyUnit)

    Dim unittargetmutli = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active, theaffects)

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)



    Dim lifeenemyval As New modValue(1, eModifierType.LifeDrainDrainfromTarget, occurencetime)
    lifeenemyval.mValueDuration = Duration

    Dim lifeenemod As New Modifier(lifeenemyval, unittargetmutli)
    outmods.Add(lifeenemod)



    Dim lifeselfval As New modValue(1, eModifierType.LifeDrainSelfEffect, occurencetime)
    lifeselfval.mValueDuration = Duration

    Dim lifeselfmod As New Modifier(lifeselfval, unittargetself)
    outmods.Add(lifeselfmod)

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
