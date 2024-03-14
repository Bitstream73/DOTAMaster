Public Class abScorched_Earth
  Inherits AbilityBase
  Public damageregen As ValueWrapper
  Public damregeninterval As ValueWrapper
  Public bonusmove As ValueWrapper
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

    mDisplayName = "Scorched Earth"
    mName = eAbilityName.abScorched_Earth
    Me.EntityName = eEntity.abScorched_Earth

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDoom

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/doom_bringer_scorched_earth_hp2.png"

    Description = "Carpets the nearby earth in flames, damaging enemies while Doom gains bonus HP regen and increased movement speed."

    ManaCost = New ValueWrapper(60, 65, 70, 75)

    Cooldown = New ValueWrapper(60, 55, 50, 45)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    damageregen = New ValueWrapper(12, 18, 24, 30)

    damregeninterval = New ValueWrapper(1, 1, 1, 1)

    Radius = New ValueWrapper(600, 600, 600, 600)

    bonusmove = New ValueWrapper(0.16, 0.16, 0.16, 0.16)

    Duration = New ValueWrapper(10, 12, 14, 16)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetauraenemyunits = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim notargetcontrolledallies = Helpers.GetNoTargetControlledUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim healval As New modValue(damageregen, eModifierType.HealAdded, damregeninterval, occurencetime, aghstime)
    healval.mValueDuration = Duration


    Dim healself As New Modifier(healval, notargetself)
    outmods.Add(healself)

    Dim healteammates As New Modifier(healval, notargetcontrolledallies)
    outmods.Add(healteammates)

    Dim moveval As New modValue(bonusmove, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim moveself As New Modifier(moveval, notargetself)
    outmods.Add(moveself)

    Dim moveteammates As New Modifier(moveval, notargetcontrolledallies)
    outmods.Add(moveteammates)


    'damage
    Dim damval As New modValue(damageregen, eModifierType.DamageMagicalOverTimeInflicted, damregeninterval, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, notargetauraenemyunits)
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
