Public Class abChronosphere
Inherits AbilityBase

  Public scepterduration As New List(Of Double?)
  Public sceptercooldown As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Chronosphere"
    mName = eAbilityName.abChronosphere
    Me.EntityName = eEntity.abChronosphere

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFaceless_Void

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/faceless_void_chronosphere_hp2.png"

    Description = "Creates a blister in spacetime, trapping all units caught in its sphere of influence and causes you to move very quickly inside it. Only Faceless Void and any units he controls are unaffected. Invisible units in the sphere will be revealed. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(150, 225, 300)

    Cooldown = New ValueWrapper(130, 115, 100)
    sceptercooldown.Add(4)
    sceptercooldown.Add(5)
    sceptercooldown.Add(6)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untUnits)

    Radius = New ValueWrapper(425, 425, 425)

    Duration = New ValueWrapper(4, 4.5, 5)
    scepterduration.Add(4)
    scepterduration.Add(5)
    scepterduration.Add(6)
    Duration.LoadScepterValues(scepterduration)


  End Sub
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetunits = Helpers.GetPointTargetUnitsInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim notargetcontrolledunits = Helpers.GetNoTargetControlledUnitsInfo(theability_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)


    Dim muteval As New modValue(Duration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    muteval.mValueDuration = Duration


    Dim mutemod As New Modifier(muteval, pointtargetunits)
    outmods.Add(mutemod)


    Dim speedval As New modValue(1000, eModifierType.MoveSpeedMinimum, occurencetime)
    speedval.mValueDuration = Duration

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)


    Dim speedforunits As New Modifier(speedval, notargetcontrolledunits)
    outmods.Add(speedforunits)

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
