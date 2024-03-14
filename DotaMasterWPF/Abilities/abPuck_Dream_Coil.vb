Public Class abDream_Coil
  Inherits AbilityBase

  Public initialstunduration As ValueWrapper

  Public coilduration As ValueWrapper
  Public sceptercoilduration As New List(Of Double?)

  Public initialdamage As ValueWrapper

  Public breakradius As ValueWrapper

  Public breakstunduration As ValueWrapper
  Public scepterbreakstunduration As New List(Of Double?)

  Public breakdamage As ValueWrapper
  Public scepterbreakdamage As New List(Of Double?)



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

    mDisplayName = "Dream Coil"
    mName = eAbilityName.abDream_Coil
    Me.EntityName = eEntity.abDream_Coil

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPuck

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/puck_dream_coil_hp2.png"

    Description = "Creates a coil of volatile magic that latches onto enemy Heroes, stunning them for .5 seconds and damaging them. If the enemy hero stretches the coil by moving too far away, it snaps, stunning and dealing additional damage. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(100, 150, 200)

    Cooldown = New ValueWrapper(85, 85, 85)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyHeroes)

    DamageType = eDamageType.Magical

    coilduration = New ValueWrapper(6, 6, 6)
    sceptercoilduration.Add(8)
    sceptercoilduration.Add(8)
    sceptercoilduration.Add(8)
    coilduration.LoadScepterValues(sceptercoilduration)

    initialstunduration = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    initialdamage = New ValueWrapper(100, 150, 200)

    breakradius = New ValueWrapper(600, 600, 600)

    breakstunduration = New ValueWrapper(1.5, 2.25, 3)
    scepterbreakstunduration.Add(1.5)
    scepterbreakstunduration.Add(3)
    scepterbreakstunduration.Add(4.5)
    breakstunduration.LoadScepterValues(scepterbreakstunduration)

    breakdamage = New ValueWrapper(100, 150, 200)
    scepterbreakdamage.Add(200)
    scepterbreakdamage.Add(250)
    scepterbreakdamage.Add(300)
    breakdamage.LoadScepterValues(scepterbreakdamage)

    Duration = coilduration
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

    'initial stun
    Dim stunval As New modValue(initialstunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = initialstunduration

    Dim stunmod As New Modifier(stunval, pointtargetenemyheroes)
    outmods.Add(stunmod)


    'initial damage
    Dim damval As New modValue(initialdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemyheroes)
    outmods.Add(dammod)


    'snap stun
    Dim snapstunval As New modValue(breakstunduration, eModifierType.Stun, occurencetime, aghstime)
    snapstunval.mValueDuration = breakstunduration

    Dim snapstunmod As New Modifier(snapstunval, pointtargetenemyheroes)
    outmods.Add(snapstunmod)

    'snap damage
    Dim snapdamval As New modValue(breakdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim snapdammod As New Modifier(snapdamval, pointtargetenemyheroes)
    outmods.Add(snapdammod)


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
