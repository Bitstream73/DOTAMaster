Public Class abCold_Snap
Inherits AbilityBase
  Public damageperquas As ValueWrapper
  Public stundurationperquas As ValueWrapper
  Public triggercooldown As ValueWrapper
  Public debuffduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False



    mDisplayName = "Cold Snap"
    mName = eAbilityName.abCold_Snap
    Me.EntityName = eEntity.abCold_Snap

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_cold_snap_hp2.png"

    Description = "Invoker draws the heat from an enemy, chilling them to their very core for a duration based on the level of Quas. The enemy will take damage and be briefly frozen. Further damage taken in this state will freeze the enemy again, dealing bonus damage. The enemy can only be frozen so often, but the freeze cooldown decreases based on the level of Quas."

    Notes = "Cold Snap immediately triggers on the target upon cast, so the next proc can only happen after the trigger cooldown.|Every time the effect triggers, the target is stunned and damaged. Only triggers on damage greater than 10 after reductions.|Cold Snap does not trigger on self afflicted damage.|With its current trigger cooldown and debuff duration, it can trigger up to 4/5/6/7/8/9/10 times (including the initial trigger upon cast).|Can deal up to 28/70/126/196/280/378/490 damage (before reductions) when triggering as often as possible."
    ManaCost = New ValueWrapper(100, 100, 100, 100, 100, 100, 100)

    Cooldown = New ValueWrapper(20, 20, 20, 20, 20, 20, 20)

    damageperquas = New ValueWrapper(7, 14, 21, 28, 35, 42, 49)

    triggercooldown = New ValueWrapper(0.77, 0.74, 0.71, 0.69, 0.66, 0.63, 0.6)

    debuffduration = New ValueWrapper(3, 3.5, 4, 4.5, 5, 5.5, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical



End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     thecaster As iDisplayUnit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim enemytarger = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim stunval As New modValue(stundurationperquas, eModifierType.StunChain, triggercooldown, occurencetime, aghstime)
    stunval.mValueDuration = debuffduration

    Dim stunmod As New Modifier(stunval, enemytarger)
    outmods.Add(stunmod)


    Dim damval As New modValue(damageperquas, eModifierType.DamageMagicalChain, triggercooldown, occurencetime, aghstime)
    damval.mValueDuration = debuffduration

    Dim dammod As New Modifier(damval, enemytarger)
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
