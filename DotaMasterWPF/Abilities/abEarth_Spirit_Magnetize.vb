Public Class abMagnetize
Inherits AbilityBase
  Public damagepersec As ValueWrapper

  Public remnantrefreshradius As ValueWrapper
  Public remnantexplosionradius As ValueWrapper

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

    mDisplayName = "Magnetize"
    mName = eAbilityName.abMagnetize
    Me.EntityName = eEntity.abMagnetize

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Spirit

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earth_spirit_magnetize_hp2.png"

    Description = "Magnetizes units in a small nearby area, causing them to take damage over time for a short duration. Any magnetized heroes cause nearby Stone Remnants to become energized and explode, applying/refreshing the magnetize debuff on all units near the Stone Remnant. This process can repeat multiple times. Stone Remnants are destroyed in this process. If an enemy hero is affected by silence or slows as a result of Geomagnetic Grip or Rolling Boulder, all magnetized heroes share the effects."

    'mManaCost.Add(-1)

    Cooldown = New ValueWrapper(80, 80, 80)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(300, 300, 300)


    damagepersec = New ValueWrapper(50, 75, 100)

    Duration = New ValueWrapper(6, 6, 6)

    remnantrefreshradius = New ValueWrapper(400, 400, 400)
    remnantexplosionradius = New ValueWrapper(600, 600, 600)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim damval As New modValue(damagepersec, eModifierType.MagnatizeDamageOverTime, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, activeauraenemies)
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
