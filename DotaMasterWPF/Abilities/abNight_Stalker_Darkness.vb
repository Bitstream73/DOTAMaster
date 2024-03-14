Public Class abDarkness
Inherits AbilityBase

  Public unobstrictedvision As ValueWrapper
  Public scepterunobstructed As New List(Of Double?)

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

    mDisplayName = "Darkness"
    mName = eAbilityName.abDarkness
    Me.EntityName = eEntity.abDarkness

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNight_Stalker

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/night_stalker_darkness_hp2.png"

    Description = "Night Stalker smothers the sun and summons instant darkness, so that he might use his powers at their fullest. While Darkness is in effect, enemy units and buildings have their vision range reduced. When used at night, it extends night time by Darkness' duration. Upgradable by Aghanim's Scepter."

    Cooldown = New ValueWrapper(180, 150, 120)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(80, 50, 25)

    unobstrictedvision = New ValueWrapper(-1, -1, -1)
    scepterunobstructed.Add(1)
    scepterunobstructed.Add(1)
    scepterunobstructed.Add(1)
    unobstrictedvision.LoadScepterValues(scepterunobstructed)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetallenemyunits = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim notargetenemystructs = Helpers.GetNoTargetEnemyStructuresInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)


    Dim nightval As New modValue(Duration, eModifierType.DarknessNight, occurencetime, aghstime)
    nightval.mValueDuration = Duration

    Dim nightmod As New Modifier(nightval, notargetallenemyunits)
    outmods.Add(nightmod)

    Dim structmod As New Modifier(nightval, notargetenemystructs)
    outmods.Add(structmod)



    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim obstructval As New modValue(Duration, eModifierType.UnobstructedVision, occurencetime, aghstime)
    obstructval.mValueDuration = Duration

    Dim obmod As New Modifier(obstructval, notargetself)
    outmods.Add(obmod)


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
