Public Class abEclipse
  Inherits AbilityBase
  Public strikeinterval As ValueWrapper
  Public beamscount As ValueWrapper
  Public maxhits As ValueWrapper
  Public scepterbeamcount As New List(Of Double?)
  Public sceptermaxhits As New List(Of Double?)
  Public scepterduration As New List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Beams deal damage based on Luna's current level of Lucent Beam, so if Lucent Beam is not learned, Eclipse icon.png Eclipse will deal no damage.|Eclipse turns day into night for 10 seconds, pausing the current game time.However, it does not interfere with the night caused by Darkness in any way, means Night Stalker's night will not be paused.|Does not hit ancient creeps, Roshan, Warlock's Golem, Storm and Fire from Primal Split, invisible units, or units in Fog of War.|When Luna dies, Eclipse will stop. However, the 10 second night will continue.|Luna's glaive emits some particles during the cast time, visible to everyone.|Maximum possible damage to a single target (before reductions):|Level 1 Lucent Beam: 300 (300/600/900)|Level 2 Lucent Beam: 600 (600/1200/1800)|Level 3 Lucent Beam: 900 (900/1800/2700)|Level 4 Lucent Beam: 1200 (1200/2400/3600)" '"

    mDisplayName = "Eclipse"
    mName = eAbilityName.abEclipse
    Me.EntityName = eEntity.abEclipse

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLuna

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/luna_eclipse_hp2.png"

    Description = "Calls an eclipse that follows Luna, striking units with her current level of Lucent Beam. A single target can only be hit a maximum times. Unlike individual Lucent Beams, Eclipse does not stun. Eclipse turns day into night for 10 seconds. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(150, 200, 250)


    Cooldown = New ValueWrapper(160, 150, 140)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(675, 675, 675)

    strikeinterval = New ValueWrapper(0.6, 0.6, 0.6)

    beamscount = New ValueWrapper(5, 8, 11)
    scepterbeamcount.Add(6)
    scepterbeamcount.Add(10)
    scepterbeamcount.Add(14)
    beamscount.LoadScepterValues(scepterbeamcount)


    maxhits = New ValueWrapper(4, 4, 4)
    sceptermaxhits.Add(6)
    sceptermaxhits.Add(10)
    sceptermaxhits.Add(14)
    maxhits.LoadScepterValues(sceptermaxhits)


    Duration = New ValueWrapper(2.4, 4.2, 6)
    scepterduration.Add(3)
    scepterduration.Add(5.4)
    scepterduration.Add(7.8)
    Duration.LoadScepterValues(scepterduration)












  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)




    Dim damval As New modValue(beamscount, eModifierType.LucentBeamHits, occurencetime, aghstime)
    damval.mValueDuration = Duration


    Dim thedamage As New Modifier(damval, activeauraenemies)
    outmods.Add(thedamage)




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
