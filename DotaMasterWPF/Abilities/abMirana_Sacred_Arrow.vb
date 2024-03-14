Public Class abSacred_Arrow
Inherits AbilityBase
  Public maxbonusdamage As ValueWrapper
  Public minimumstun As ValueWrapper
  Public maximumstun As ValueWrapper

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

    Notes = "The Sacred Arrow icon.png Sacred Arrow travels at a speed of 857.|Can hit units up to 3115 units away (3000 travel distance + 115 radius).|The stun duration increases by 0.1 seconds and the damage by 2.8 for each 30 distance traveled. So the stun and bonus damage at certain ranges is:|300 distance: 1 second stun, 28 (78/168/258/348) damage|600 distance: 2 seconds stun, 56 (106/196/286/376) damage|900 distance: 3 seconds stun, 84 (134/224/314/404) damage|1200 distance: 4 seconds stun, 112 (162/252/342/432) damage|1500 distance: 5 seconds stun, 140 (190/280/370/460) damage|Sacred Arrow reaches its full potential after traveling for 1500 distance, or for (1500/857=)1.75 seconds. It does not get stronger for the remaining 1500 it can travel.|Sacred Arrow has 650 flying vision, which stays for 3 seconds at the point the arrow hit a target." '"

    mDisplayName = "Sacred Arrow"
    mName = eAbilityName.abSacred_Arrow
    Me.EntityName = eEntity.abSacred_Arrow

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMirana

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/mirana_arrow_hp2.png"

    Description = "Fires an long-range arrow with deadly precision, which stuns and damages the first enemy unit it strikes. The stun duration ranges from 0.01 to 5 seconds, with bonus damage up to 140 added, based on the distance the arrow travels to its target."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(17, 17, 17, 17)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(50, 140, 230, 320)

    Range = New ValueWrapper(3000, 3000, 3000, 3000)

    minimumstun = New ValueWrapper(0.01, 0.01, 0.01, 0.01)

    maximumstun = New ValueWrapper(5, 5, 5, 5)

    maxbonusdamage = New ValueWrapper(140, 140, 140, 140)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim linetargetenemy = Helpers.GetPointTargetLineEnemyUnitInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    'base damage
    Dim thedam As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(thedam, linetargetenemy)
    outmods.Add(thedamage)

    'bonusdamage
    Dim thebonus As New modValue(maxbonusdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thebonusdam As New Modifier(thebonus, linetargetenemy)
    outmods.Add(thebonusdam)

    Dim linetargetenemy2 = Helpers.GetPointTargetLineEnemyUnitInfo(theability_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "Maximum stun shown. Minimum is .01 seconds", eModifierCategory.Active)
    'max stun val
    Dim stunval As New modValue(maximumstun, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = maximumstun

    Dim thestun As New Modifier(stunval, linetargetenemy2)
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
