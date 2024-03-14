Public Class abBlack_Hole
Inherits AbilityBase
  Public mindamagepersec As ValueWrapper
  Public maxdamagepersec As ValueWrapper

  Public midnightpusedamageadded As ValueWrapper '0=no 1=yes
  Public sceptermidnightpulsedamageadded As New List(Of Double?)
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

    mDisplayName = "Black Hole"
    mName = eAbilityName.abBlack_Hole
    Me.EntityName = eEntity.abBlack_Hole

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnigma

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enigma_black_hole_hp2.png"

    Description = "CHANNELED - Summons a vortex that sucks in nearby enemy units. Enemies affected by Black Hole cannot move, attack, or cast spells. The closer units get to the center, the more damage is dealt. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(275, 350, 425)

    Cooldown = New ValueWrapper(200, 190, 180)
    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(400, 400, 400)

    Duration = New ValueWrapper(4, 4, 4)

    midnightpusedamageadded = New ValueWrapper(-1, -1, -1)
    sceptermidnightpulsedamageadded.Add(1)
    sceptermidnightpulsedamageadded.Add(1)
    sceptermidnightpulsedamageadded.Add(1)
    midnightpusedamageadded.LoadScepterValues(sceptermidnightpulsedamageadded)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim channeledauraenemies = Helpers.GetChanneledAuraEnemydUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim moveval As New modValue(Duration, eModifierType.MuteMove, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim dammod As New Modifier(moveval, channeledauraenemies)
    outmods.Add(dammod)


    Dim attval As New modValue(Duration, eModifierType.MuteAttacks, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, channeledauraenemies)
    outmods.Add(attmod)


    'scepter pulse damage
    Dim pulseval As New modValue(midnightpusedamageadded, eModifierType.MidnightPulsePureDamageAdded, occurencetime, aghstime)
    pulseval.mValueDuration = Duration


    Dim pulsemod As New Modifier(pulseval, channeledauraenemies)
    outmods.Add(pulsemod)


    Dim pullvall As New modValue(1, eModifierType.Pullback, occurencetime)
    pullvall.mValueDuration = Duration

    Dim pullmod As New Modifier(pullvall, channeledauraenemies)
    outmods.Add(pullmod)

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
