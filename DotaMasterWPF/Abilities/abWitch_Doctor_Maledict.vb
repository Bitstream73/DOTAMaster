Public Class abMaledict
Inherits AbilityBase
  Public Losthealthburstdamage As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Damage is based on the difference between the HP values currently and when Maledict was cast. Any health restored during Maledict will also reduce damage from the next ticks.|Maledict debuff cannot be purged nor can units be denied while under its effect.|To clarify, extra damage doesn't count for every full 100 hp lost, but as a percentage of health lost, so for 150 hp lost, you'll take not 16, but 150 * 16% = 24 damage.|Damage is dealt in one second intervals, with extra damage dealt every 4 seconds (3 times in total) before the static damage. E.g., for level 1 Maledict, you'll get 5, 5, 5, extra damage+5, 5, 5, 5, extra damage+5, 5, 5, 5, extra damage+5.|Becoming magic immune while under the effect of Maledict will block the damage but will not remove the effect, meaning it is still possible to die if magic immunity wears off before Maledict does.|At level 4, assuming standard magic resistance, Maledict will theoretically amplify any health lost before the first tick by +110.7%, along with a base 281 pure damage. Burst heal mitigates that with equal effectiveness, and constant hp regen will work double time as well (+8.4s worth over the 12s duration)." '"
    '"

    mDisplayName = "Maledict"
    mName = eAbilityName.abMaledict
    Me.EntityName = eEntity.abMaledict

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWitch_Doctor

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/witch_doctor_maledict_hp2.png"

    Description = "Curses all enemy Heroes in an area, causing them to take damage every 4 seconds, adding bonus damage for every 100 HP lost since the curse began."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(20, 20, 20, 20)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(5, 10, 15, 20)

    Radius = New ValueWrapper(180, 180, 180, 180)

    Duration = New ValueWrapper(12, 12, 12, 12)

    Losthealthburstdamage = New ValueWrapper(0.16, 0.24, 0.32, 0.4)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointargetenemies = Helpers.GetPointTargetEnemyHeroesInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)





    Dim dpsval As New modValue(Damage, eModifierType.DamageoTMagicalInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dpsval.mValueDuration = Duration

    Dim damageper4sec As New Modifier(dpsval, pointargetenemies)
    outmods.Add(damageper4sec)


    Dim losthealthval As New modValue(Losthealthburstdamage, eModifierType.LostHealthDamagePercent, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    losthealthval.mValueDuration = Duration

    Dim losthealthmod As New Modifier(losthealthval, pointargetenemies)
    outmods.Add(losthealthmod)

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
