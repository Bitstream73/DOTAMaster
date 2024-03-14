Public Class abMystic_Flare
Inherits AbilityBase
  Public sceptercooldown As New List(Of Double?)
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

    Notes = "Mystic Flare selects from only real heroes to divide damage among its targets (illusions aren't harmed and don't soak any of the damage).|Pulses once every 0.1 seconds (24 pulses at 25/41.66/58.33 damage each, each divided as described above)." '"

    mDisplayName = "Mystic Flare"
    mName = eAbilityName.abMystic_Flare
    Me.EntityName = eEntity.abMystic_Flare

    'mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSkywrath_Mage

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skywrath_mage_mystic_flare_hp2.png"

    Description = "Skywrath Mage uses his ultimate magical ability to conjure a precise and violent mystical field that lays waste to his adversaries. Deals massive damage distributed evenly among any Heroes in the area over 2 seconds. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(350, 575, 800)

    Cooldown = New ValueWrapper(60, 40, 20)
    sceptercooldown.Add(20)
    sceptercooldown.Add(10)
    sceptercooldown.Add(0)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(600, 1000, 1400)

    Duration = New ValueWrapper(2.4, 2.4, 2.4)

    Radius = New ValueWrapper(170, 170, 170)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemytarget = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.mValueDuration = Duration
    damval.mRadius = Radius

    Dim thedamage As New Modifier(damval, pointtargetenemytarget)
    outmods.Add(thedamage)


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
