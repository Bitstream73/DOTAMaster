Public Class abGhostship
Inherits AbilityBase
  Public impactdelay As ValueWrapper
  Public rumbonusspeed As ValueWrapper
  Public rumduration As ValueWrapper
  Public stunduration As ValueWrapper
  Public linewidt As ValueWrapper
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

    Notes = "Ghost Ship travels at a speed of 650.|Kunkka turns to face the target point; the ship then spawns 1000 units behind Kunkka, travels forward, and finishes 1000 units ahead of Kunkka.|A visual indicator (water whirling and a sword stuck in the ground) will appear at the location the ship will crash in. The indicator is only visible to allies.|The Rum buff applies to allied heroes which come within 425 range of the ship at any time during its travel.|Once the Rum buff expires, a debuff is placed. The debuff deals 5% of the previously reduced damage as damage in 1 second intervals until all the reduced damage is returned.|Delayed damage dealt after the Rum wears off is HP removal. It will not dispel any consumables and can never kill a hero.|Delayed damage can not be avoided by becoming spell immune, however it can be avoided by becoming invulnerable." '"

    mDisplayName = "Ghostship"
    mName = eAbilityName.abGhostship
    Me.EntityName = eEntity.abGhostship

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKunkka

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/kunkka_ghostship_hp2.png"

    Description = "Summons a ghostship to cut a swath through battle, causing damage and stunning enemy units as it crashes through. Allies touched by the ship are doused in Kunkka's Rum, receiving bonus movement speed and a delayed reaction to damage."

    ManaCost = New ValueWrapper(150, 200, 250)

    Cooldown = New ValueWrapper(60, 50, 40)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(400, 500, 600)

    impactdelay = New ValueWrapper(3, 3, 3)

    Radius = New ValueWrapper(1000, 1000, 1000)

    linewidt = New ValueWrapper(425, 425, 425)

    rumbonusspeed = New ValueWrapper(0.1, 0.1, 0.1)

    rumduration = New ValueWrapper(10, 10, 10)

    stunduration = New ValueWrapper(1.4, 1.4, 1.4)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim lineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)




    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, lineenemies)
    outmods.Add(thedamage)



    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, lineenemies)
    outmods.Add(thestun)




    Dim conefriends = Helpers.GetPointTargetLineAlliedUnitsInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)



    Dim moveval As New modValue(rumbonusspeed, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    moveval.mValueDuration = rumduration

    Dim movebuff As New Modifier(moveval, conefriends)
    outmods.Add(movebuff)



    Dim conefriendsdelay = Helpers.GetPointTargetLineAlliedUnitsInfo(theability_InfoID, _
                                                      thecaster, _
                                                      thetarget, _
                                                      "Delays 50% of incoming damage", eModifierCategory.Active)

    Dim damdelayval As New modValue(Duration, eModifierType.DamageDelay, occurencetime, aghstime)
    damdelayval.mValueDuration = Duration

    Dim thedamagedelay As New Modifier(damdelayval, conefriendsdelay)
    outmods.Add(thedamagedelay)


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
