Public Class abIce_Path
Inherits AbilityBase
  Public formationdelay As ValueWrapper
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

    mName = eAbilityName.abIce_Path
    Me.EntityName = eEntity.abIce_Path

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJakiro

    mAbilityPosition = 2

    mDisplayName = "Ice Path"
    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/jakiro_ice_path_hp2.png"

    Description = "Creates a path of ice that stuns and damages enemies that touch it."

    ManaCost = New ValueWrapper(90, 90, 90, 90)
    Cooldown = New ValueWrapper(12, 11, 10, 9)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    formationdelay = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    Damage = New ValueWrapper(50, 50, 50, 50)

    Duration = New ValueWrapper(1, 1.4, 1.8, 2.2)

    Radius = New ValueWrapper(150, 150, 150, 150)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)

    Dim stunval As New modValue(Duration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = Duration

    Dim stunmod As New Modifier(stunval, pointlineenemies)
    outmods.Add(stunmod)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointlineenemies)
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
