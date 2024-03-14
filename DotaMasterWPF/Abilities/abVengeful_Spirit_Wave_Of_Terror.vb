Public Class abWave_Of_Terror
Inherits AbilityBase
  Public armorreduct As ValueWrapper
  Public debuffduration As ValueWrapper
  Public visionduration As ValueWrapper
  Public visionradius As ValueWrapper
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

    mDisplayName = "Wave of Terror"
    mName = eAbilityName.abWave_Of_Terror
    Me.EntityName = eEntity.abWave_Of_Terror

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVengeful_Spirit

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/vengefulspirit_wave_of_terror_hp2.png"

    Description = "Vengeful Spirit lets loose a wicked cry, weakening the armor of enemies and giving vision of the path ahead."

    ManaCost = New ValueWrapper(40, 40, 40, 40)

    Cooldown = New ValueWrapper(20, 20, 20, 20)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure

    Damage = New ValueWrapper(30, 50, 70, 90)

    armorreduct = New ValueWrapper(3, 4, 5, 6)

    debuffduration = New ValueWrapper(20, 20, 20, 20)

    visionduration = New ValueWrapper(3, 3, 3, 3)

    visionradius = New ValueWrapper(500, 500, 500, 500)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemies)
    outmods.Add(dammod)

    Dim visval As New modValue(visionduration, eModifierType.Vision, occurencetime, aghstime)
    visval.mRadius = visionradius

    Dim vismod As New Modifier(visval, pointtargetenemies)
    outmods.Add(vismod)



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
