Public Class abEye_Of_The_Storm
Inherits AbilityBase
  Public strikeinterval As ValueWrapper
  Public armorreduction As ValueWrapper
  Public scepterstrikeinterval As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Eye of the Storm"
    mName = eAbilityName.abEye_Of_The_Storm
    Me.EntityName = eEntity.abEye_Of_The_Storm

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRazor

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/razor_eye_of_the_storm_hp2.png"

    Description = "A powerful lightning storm strikes out at enemy units with the lowest health, dealing damage and reducing their armor. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(100, 150, 200)

    Cooldown = New ValueWrapper(80, 70, 60)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical



    Radius = New ValueWrapper(500, 500, 500)

    Duration = New ValueWrapper(30, 30, 30)

    strikeinterval = New ValueWrapper(0.7, 0.6, 0.5)
    scepterstrikeinterval.Add(0.6)
    scepterstrikeinterval.Add(0.5)
    scepterstrikeinterval.Add(0.4)
    strikeinterval.LoadScepterValues(scepterstrikeinterval)

    armorreduction = New ValueWrapper(-1, -1, -1)

    Damage = New ValueWrapper(37, 50, 63)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetlowesthealth = Helpers.GetUnitTargetEnemyUnitwLowestHealthInfo(theability_InfoID, _
                                                                                 thecaster, _
                                                                                 thetarget, _
                                                                                 "", eModifierCategory.Active)



    Dim valdam As New modValue(Damage, eModifierType.DamagePhysicalInflicted, strikeinterval, occurencetime, aghstime)
    valdam.mValueDuration = Duration

    Dim moddam As New Modifier(valdam, unittargetlowesthealth)
    outmods.Add(moddam)



    Dim valarmor As New modValue(armorreduction, eModifierType.ArmorAdded, occurencetime, aghstime)

    Dim modarmor As New Modifier(valarmor, unittargetlowesthealth)
    outmods.Add(modarmor)



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
