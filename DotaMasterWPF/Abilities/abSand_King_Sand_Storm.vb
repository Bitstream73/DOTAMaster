Public Class abSand_Storm
Inherits AbilityBase
  Public invisdelay As ValueWrapper
  Public damageinterval As ValueWrapper
  Public invisduration As ValueWrapper
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

    mDisplayName = "Sand Storm"
    mName = eAbilityName.abSand_Storm
    Me.EntityName = eEntity.abSand_Storm

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSand_King

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sandking_sand_storm_hp2.png"

    Description = "CHANNELED - Sand King creates a fearsome sandstorm that damages enemy units while hiding him from vision. The invisibility remains for a short duration after the sandstorm ends."

    ManaCost = New ValueWrapper(60, 50, 40, 30)

    Cooldown = New ValueWrapper(40, 30, 20, 10)


    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Channeled)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(25, 50, 75, 100)

    damageinterval = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    invisdelay = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    Duration = New ValueWrapper(20, 40, 60, 80)

    invisduration = New ValueWrapper(Duration.Value(0) - invisdelay.Value(0), _
                                  Duration.Value(1) - invisdelay.Value(1), _
                                  Duration.Value(2) - invisdelay.Value(2), _
                                  Duration.Value(3) - invisdelay.Value(3))


    Radius = New ValueWrapper(525, 525, 525, 525)



    Radius = New ValueWrapper(525, 525, 525, 525)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetauraenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)


    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalOverTimeInflicted, damageinterval, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, pointtargetauraenemies)
    outmods.Add(dammod)


    Dim invisval As New modValue(invisduration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = invisduration

    Dim invismod As New Modifier(invisval, notargetself)
    outmods.Add(invismod)


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
