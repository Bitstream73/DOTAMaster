Public Class abOvergrowth
Inherits AbilityBase
  Public treevisionradius As ValueWrapper
  Public sctreevisionradius As New List(Of Double?)

  Dim damagepersec As ValueWrapper
  Dim scdamagpersec As New List(Of Double?)

  Dim treeduration As ValueWrapper
  Dim sctreeduration As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Fully disables: Blink,Teleportation, Charge of Darkness, Phase Shift and Blink Dagger. The caster will get the error message ""Can't cast this while rooted."" when attempting to cast one of these.|Other blinks and pseudo-blinks (eg Leap icon.png Leap, Phantom Strike icon.png Phantom Strike, Ethereal Jaunt icon.png Ethereal Jaunt, etc) will fully work, although the unit is still rooted afterwards.|Prevents Relocate icon.png Relocate from teleporting Io and his tethered ally.|Units can use invisibility spells during Overgrowth, however they are revealed for the duration.|Interrupts the affected units' current order, canceling out a spell cast and channeling spells." '"

    mDisplayName = "Overgrowth"
    mName = eAbilityName.abOvergrowth
    Me.EntityName = eEntity.abOvergrowth

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTreant_Protector

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/treant_overgrowth_hp2.png"

    Description = "Summons an overgrowth of vines and branches around Treant that prevent afflicted enemies from moving, blinking, going invisible, or attacking.|Aghanim's Scepter adds Eyes In The Forest ability: Treant Protector enchants a tree, which grants him unobstructed vision in that location. If Overgrowth is cast, units within an 800 radius of an enchanted tree will be entangled and damaged."

    ManaCost = New ValueWrapper(150, 175, 200)

    Cooldown = New ValueWrapper(70, 70, 70)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    Affects.Add(eUnit.untSelf)


    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(3, 3.75, 4.5)

    Radius = New ValueWrapper(675, 675, 675)

    treevisionradius = New ValueWrapper(800, 800, 800)

    treevisionradius = New ValueWrapper(-1, -1, -1)
    sctreevisionradius.Add(800)
    sctreevisionradius.Add(800)
    sctreevisionradius.Add(800)
    treevisionradius.LoadScepterValues(sctreevisionradius)

    damagepersec = New ValueWrapper(-1, -1, -1)
    scdamagpersec.Add(175)
    scdamagpersec.Add(175)
    scdamagpersec.Add(175)
    damagepersec.LoadScepterValues(scdamagpersec)

    treeduration = New ValueWrapper(-1, -1, -1)
    sctreeduration.Add(0) 'lasts til destroyed
    sctreeduration.Add(0)
    sctreeduration.Add(0)
    treeduration.LoadScepterValues(sctreeduration)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    '''''
    'Eyes in the forest is not seperate spell since that causes problems... it's not a choosable spell
    'so it can't be added since it doesn't really have a spell position. Adding it would break spell build sequencing
    '''''

    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    'overgrowth
    Dim moveval As New modValue(Duration, eModifierType.MuteMove, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, activeauraenemies)
    outmods.Add(movemod)


    Dim blinkval As New modValue(Duration, eModifierType.MuteBlink, occurencetime, aghstime)
    blinkval.mValueDuration = Duration

    Dim blinkmod As New Modifier(blinkval, activeauraenemies)
    outmods.Add(blinkmod)


    Dim invisval As New modValue(Duration, eModifierType.MuteInvisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration

    Dim invismod As New Modifier(invisval, activeauraenemies)
    outmods.Add(invismod)


    Dim attval As New modValue(Duration, eModifierType.MuteAttacks, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, activeauraenemies)
    outmods.Add(attmod)

    Dim eyesactiveauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "Eyes In The Forest effect", eModifierCategory.Active)


    Dim eyesnotargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "Eyes In The Forest effect", eModifierCategory.Active)




    Dim visval As New modValue(treeduration, eModifierType.Vision, occurencetime, aghstime)
    visval.mRadius = treevisionradius

    Dim vismod As New Modifier(visval, eyesnotargetself)
    outmods.Add(vismod)

    Dim dotval As New modValue(damagepersec, eModifierType.DamageMagicalOverTimeInflicted, occurencetime, aghstime)
    dotval.mValueDuration = Duration 'overgrowth duration

    Dim dotmod As New Modifier(dotval, eyesactiveauraenemies)
    outmods.Add(dotmod)


    ''eyes in the forest
    'If thecaster.HasAghs(occurencetime, aghstime) Then
    '  Dim passiveauraenemyinfo As New modInfo(eAbilityType.PassiveAura, _
    '                              theability_InfoID, _
    '                              thecaster.ID, eSourceType.HeroBuild, _
    '                               Nothing, _
    '                                   eUnit.untEnemyUnits, _
    '                                   "", eModifierCategory.Active)

    '  Dim visval As New modValue(0, eModifierType.Visibility)
    '  visval.mValueDuration = New TimeSpan(0, 7, 0)

    '  Dim vismod As New Modifier(occurencetime, visval, passiveauraenemyinfo)

    '  outmods.Add(vismod)
    'End If

    'Dim notargetenemies As New modInfo(eAbilityType.NoTarget, _
    '                                   theability_InfoID, _
    '                                   thecaster.ID, eSourceType.HeroBuild, _
    '                                   Nothing, _
    '                                   eUnit.untEnemyUnits, _
    '                                   "", eModifierCategory.Active)

    'Dim theduration = New TimeSpan(mDuration.Item(theabilitylevel - 1) * TimeSpan.TicksPerSecond)

    'Dim moveval As New modValue(1, eModifierType.MoveMute)
    'moveval.mValueDuration = theduration

    'Dim movemute As New Modifier(occurencetime, moveval, notargetenemies)
    'outmods.Add(movemute)



    'Dim blinkval As New modValue(1, eModifierType.BlinkMute)
    'blinkval.mValueDuration = theduration

    'Dim blinkmute As New Modifier(occurencetime, blinkval, notargetenemies)
    'outmods.Add(blinkmute)


    'Dim invisval As New modValue(1, eModifierType.InvisibilityMute)
    'invisval.mValueDuration = theduration


    'Dim invisibmute As New Modifier(occurencetime, invisval, notargetenemies)
    'outmods.Add(invisibmute)

    'Dim attval As New modValue(1, eModifierType.RightClickMute)
    'attval.mValueDuration = theduration

    'Dim attackmute As New Modifier(occurencetime, attval, notargetenemies)
    'outmods.Add(attackmute)

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
