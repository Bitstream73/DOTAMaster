Public Class abStorm_Brewmaster_Drunken_Haze
  Inherits AbilityBase
  Private heroduration As ValueWrapper
  Private agsheroduration As List(Of Double?)

  Private creepduration As ValueWrapper
  Private agscreepduration As List(Of Double?)

  Private moveslow As ValueWrapper
  Private agsmoveslow As List(Of Double?)

  Private misschance As ValueWrapper
  Private agsmisschance As List(Of Double?)

  Private agsmanacost As List(Of Double?)
  Private agscooldown As List(Of Double?)
  Private agsradius As List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Drunken Haze"
    mName = eAbilityName.abStorm_Brewmaster_Drunken_Haze
    Me.EntityName = eEntity.abStorm_Brewmaster_Drunken_Haze

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untStorm_Brewmaster

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/brewmaster_drunken_haze_hp2.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Drenches a small area in alcohol, causing their movement speed to be reduced, and causing their attacks to have a chance to miss."
    Notes = "Given to Storm when holding Aghanim's Scepter, at the same level as the original Brewmaster.|Despite the visual effect, Drunken Haze does not use a projectile and is instant, and thus cannot be disjointed."

    ManaCost = New ValueWrapper(50)

    Cooldown = New ValueWrapper(8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)
    '    mAffects.Add(eUnit)

    ManaCost = New ValueWrapper(0, 0, 0, 0)
    agsmanacost = New List(Of Double?)
    agsmanacost.Add(50)
    agsmanacost.Add(50)
    agsmanacost.Add(50)
    agsmanacost.Add(50)
    ManaCost.LoadScepterValues(agsmanacost)

    Cooldown = New ValueWrapper(0, 0, 0, 0)
    agscooldown = New List(Of Double?)
    agscooldown.Add(8)
    agscooldown.Add(8)
    agscooldown.Add(8)
    agscooldown.Add(8)
    Cooldown.LoadScepterValues(agscooldown)

    Radius = New ValueWrapper(-1, -1, -1, -1)
    agsradius = New List(Of Double?)
    agsradius.Add(200)
    agsradius.Add(200)
    agsradius.Add(200)
    agsradius.Add(200)
    Radius.LoadScepterValues(agsradius)



    heroduration = New ValueWrapper(-1, -1, -1, -1)
    agsheroduration = New List(Of Double?)
    agsheroduration.Add(8)
    agsheroduration.Add(8)
    agsheroduration.Add(8)
    agsheroduration.Add(8)
    heroduration.LoadScepterValues(agsheroduration)

    creepduration = New ValueWrapper(12, 12, 12, 12)
    agscreepduration = New List(Of Double?)
    agscreepduration.Add(12)
    agscreepduration.Add(12)
    agscreepduration.Add(12)
    agscreepduration.Add(12)
    creepduration.LoadScepterValues(agscreepduration)


    moveslow = New ValueWrapper(-1, -1, -1, -1)
    agsmoveslow = New List(Of Double?)
    agsmoveslow.Add(0.14)
    agsmoveslow.Add(0.14)
    agsmoveslow.Add(0.14)
    agsmoveslow.Add(0.14)
    moveslow.LoadScepterValues(agsmoveslow)

    misschance = New ValueWrapper(0.45, 0.55, 0.65, 0.75)
    agsmisschance = New List(Of Double?)
    agsmisschance.Add(0.45)
    agsmisschance.Add(0.55)
    agsmisschance.Add(0.65)
    agsmisschance.Add(0.75)
    misschance.LoadScepterValues(agsmisschance)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim pointtargetenemyheroes = Helpers.GetPointTargetEnemyHeroesInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim pointtargetenemycreeps = Helpers.GetPointTargetEnemyCreepsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)
    'movespeed 
    Dim moveheroval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveheroval.mValueDuration = heroduration

    Dim moveheromod As New Modifier(moveheroval, pointtargetenemyheroes)
    outmods.Add(moveheromod)

    Dim movecreepval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    movecreepval.mValueDuration = creepduration

    Dim movecreepmod As New Modifier(moveheroval, pointtargetenemycreeps)
    outmods.Add(movecreepmod)

    'miss chance

    Dim missheroval As New modValue(misschance, eModifierType.MissChance, occurencetime, aghstime)
    missheroval.mValueDuration = heroduration

    Dim missheromod As New Modifier(missheroval, pointtargetenemyheroes)
    outmods.Add(missheromod)

    Dim misscreepval As New modValue(misschance, eModifierType.MissChance, occurencetime, aghstime)
    misscreepval.mValueDuration = creepduration

    Dim misscreepmod As New Modifier(misscreepval, pointtargetenemycreeps)
    outmods.Add(misscreepmod)


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
