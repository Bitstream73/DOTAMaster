Public Class abRolling_Boulder
Inherits AbilityBase
  Public speed As ValueWrapper
  Public speedremnant As ValueWrapper
  Public distance As ValueWrapper
  Public distanceremnant As ValueWrapper
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Rolling Boulder"
    mName = eAbilityName.abRolling_Boulder
    Me.EntityName = eEntity.abRolling_Boulder

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Spirit

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earth_spirit_rolling_boulder_hp2.png"

    Description = "After a 0.6s delay, Earth Spirit becomes a boulder, rolling towards the target position and damaging enemy units, stopping if he collides with an enemy hero or is stunned. If the boulder rolls over a Stone Remnant, the Stone Remnant is consumed and travel distance and speed are improved, and impacted enemies have their movement and attack speed slowed."

    ManaCost = New ValueWrapper(50, 50, 50, 50)


    Cooldown = New ValueWrapper(16, 12, 8, 4)
    Radius = New ValueWrapper(150, 150, 150, 150)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    speed = New ValueWrapper(800, 800, 800, 800)

    speedremnant = New ValueWrapper(1600, 1600, 1600, 1600)

    Damage = New ValueWrapper(100, 100, 100, 100)

    moveslow = New ValueWrapper(0.8, 0.8, 0.8, 0.8)

    slowduration = New ValueWrapper(2, 2, 2, 2)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemies)
    outmods.Add(dammod)


    Dim pointtargetlineenemiescomment = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "Only occurs if Rolling over Stone Remnant", eModifierCategory.Active)

    Dim slowval As New modValue(slowduration, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmod As New Modifier(slowval, pointtargetlineenemiescomment)
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
