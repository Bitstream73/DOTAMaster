Public Class abEarth_Spike
  Inherits AbilityBase
  Public length As Integer
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False


    Notes = "Hit units will fly for 0.52 seconds before the real stun is applied (included in the duration on the infobox to the left).|The ability can only be targeted at a range of 500 units on enemies or the ground, but hits units up to 950 units away.|The rock spikes travel for a length of 825 units, and hit units in a 125 radius around this line, therefore enemies at a distance of 950 units are hit.|The wave of tendrils moves at 1600 units per second.|If Earth Spike hits an invisible unit the damage graphic is still displayed." '"

    mName = eAbilityName.abEarth_Spike
    Me.EntityName = eEntity.abEarth_Spike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLion

    mAbilityPosition = 1

    mDisplayName = "Earth Spike"
    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lion_impale_hp2.png"

    Description = "Rock spikes burst from the earth along a straight path. Enemy units are hurled into the air, then are stunned and take damage when they fall."


    ManaCost = New ValueWrapper(100, 120, 145, 170)


    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(80, 140, 200, 260)


    Duration = New ValueWrapper(1.02, 1.52, 2.02, 2.52)
    length = 825

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim lineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, lineenemies)
    outmods.Add(thedamage)


    Dim stunval As New modValue(Duration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = Duration

    Dim thestun As New Modifier(stunval, lineenemies)
    outmods.Add(thestun)




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
