Public Class abEarth_Splitter
Inherits AbilityBase
  Public exploddelay As ValueWrapper
  Public crackwidth As ValueWrapper
  Public cracklength As ValueWrapper
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper
  Public scepterslowduration As New List(Of Double?)

  Public maxhpasphysicaldamage As ValueWrapper
  Public maxhpasmagicaldamage As ValueWrapper

  Public disarmduration As ValueWrapper
  Public scepterdisarmduration As New List(Of Double?)

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

    mDisplayName = "Earth Splitter"
    mName = eAbilityName.abEarth_Splitter

    Me.EntityName = eEntity.abEarth_Splitter

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untElder_Titan

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/elder_titan_earth_splitter_hp2.png"

    Description = "Sends forth a jagged crack in front of Elder Titan. After 3 seconds, the crack implodes, slowing movement while dealing damage to each enemy based on their maximum life."


    ManaCost = New ValueWrapper(175, 175, 175)

    Cooldown = New ValueWrapper(100, 100, 100)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    exploddelay = New ValueWrapper(3.14, 3.14, 3.14)

    crackwidth = New ValueWrapper(300, 300, 300)

    cracklength = New ValueWrapper(2400, 2400, 2400)

    moveslow = New ValueWrapper(0.3, 0.4, 0.5)

    slowduration = New ValueWrapper(3, 4, 5)
    scepterslowduration.Add(4)
    scepterslowduration.Add(5)
    scepterslowduration.Add(6)
    slowduration.LoadScepterValues(scepterslowduration)


    maxhpasphysicaldamage = New ValueWrapper(0.175, 0.175, 0.175)
    maxhpasMagicaldamage = New ValueWrapper(0.175, 0.175, 0.175)

    disarmduration = New ValueWrapper(-1, -1, -1)
    scepterdisarmduration = scepterslowduration
    disarmduration.LoadScepterValues(scepterdisarmduration)

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

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration


    Dim movemod As New Modifier(moveval, pointtargetlineenemies)
    outmods.Add(movemod)


    'damage
    Dim physval As New modValue(maxhpasphysicaldamage, eModifierType.DamagePhysicalEarthSplitterAdded, occurencetime, aghstime)

    Dim physmod As New Modifier(physval, pointtargetlineenemies)
    outmods.Add(physmod)


    Dim magval As New modValue(maxhpasmagicaldamage, eModifierType.DamageMagicalEarthSplitterAdded, occurencetime, aghstime)

    Dim magmod As New Modifier(magval, pointtargetlineenemies)
    outmods.Add(magmod)

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
