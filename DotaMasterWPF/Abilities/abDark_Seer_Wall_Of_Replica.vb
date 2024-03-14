Public Class abWall_Of_Replica
Inherits AbilityBase

  Public replicadamage As ValueWrapper
  Public replicadamagetaken As ValueWrapper
  Public scepterreplicadamage As New List(Of Double?)
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

    mDisplayName = "Wall of Replica"
    mName = eAbilityName.abWall_Of_Replica
    Me.EntityName = eEntity.abWall_Of_Replica


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDark_Seer

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dark_seer_wall_of_replica_hp2.png"

    Description = "Raises a wall of warping light that damages and creates replicas of any enemy hero who crosses it. Enemy replicas serve at the Dark Seer's will. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(200, 300, 400)
    Cooldown = New ValueWrapper(100, 100, 100)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyHeroes)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(150, 150, 150)

    Duration = New ValueWrapper(15, 30, 45)







  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemyheroes = Helpers.GetPointTargetLineEnemyHeroesInfo(theability_InfoID, _
                                                                               thecaster, _
                                                                               thetarget, _
                                                                               "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemyheroes)
    outmods.Add(dammod)


    Dim replica As New modValue(1, eModifierType.WallHeroReplica, occurencetime)
    replica.mValueDuration = Duration

    Dim repmod As New Modifier(replica, pointtargetlineenemyheroes)
    outmods.Add(repmod)

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
