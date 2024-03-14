Public Class abCall_Of_The_Wild
Inherits AbilityBase
  'Public hawk As HeroPet_Info
  Public hawkduration As ValueWrapper
  ' Public boar As HeroPet_Info
  Public boarduration As ValueWrapper
  Public boarmoveslow As ValueWrapper
  Public boarattackslow As ValueWrapper
  Public boarpoisonduration As ValueWrapper

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
    mDisplayName = "Call of the Wild"
    mName = eAbilityName.abCall_Of_The_Wild
    Me.EntityName = eEntity.abCall_Of_The_Wild

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBeastmaster

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/beastmaster_call_of_the_wild_hp2.png"

    Description = "Beastmaster calls a watchful Hawk. Level 1: Summons a Scout Hawk. Level 2: Summons a Scout Hawk. Level 3: Summons a Greater Hawk. Level 4: Summons a Greater Hawk."

    ManaCost = New ValueWrapper(15, 15, 15, 15)


    Cooldown = New ValueWrapper(40, 40, 40, 40)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    hawkduration = New ValueWrapper(60, 60, 60, 60)
    boarduration = hawkduration

    boarmoveslow = New ValueWrapper(0.1, 0.2, 0.3, 0.4)
    boarattackslow = New ValueWrapper(10, 20, 30, 40)

    boarpoisonduration = New ValueWrapper(3, 3, 3, 3)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    'hawk = New HeroPet_Info()
    'hawk.hitpoints = New ValueWrapper(40, 60, 80, 100)
    'hawk.movementspeed = New ValueWrapper(250, 300, 350, 400)

    'hawk.SightRange.Add(New ValueWrapper(700, 1000, 1300, 1600))
    'hawk.SightRange.Add(New ValueWrapper(700, 800, 900, 1000))

    Dim hawkval As New modValue(1, eModifierType.petHawk, occurencetime)
    ' hawkval.mPet = hawk
    hawkval.mValueDuration = hawkduration

    Dim hawkmod As New Modifier(hawkval, notargetself)
    outmods.Add(hawkmod)

    'boar = New HeroPet_Info()
    'boar.hitpoints = New ValueWrapper(200, 300, 400, 500)
    'boar.DamageHigh = New ValueWrapper(15, 30, 45, 60)
    'boar.BaseAttackSpeed = New ValueWrapper(1.25, 1.25, 1.25, 1.25)

    Dim boarval As New modValue(1, eModifierType.petBoar, occurencetime)
    ' boarval.mPet = boar
    boarval.mValueDuration = boarduration

    Dim boarmod As New Modifier(boarval, notargetself)
    outmods.Add(boarmod)


    'Dim pointtargetallies = Helpers.GetPointTargetAlliedUnitsInfo(theability_InfoID, _
    '                                                              thecaster, _
    '                                                               thetarget, _
    '                                                               "", eModifierCategory.Active)

    'Dim dayvisionval As New modValue(hawk.SightRange.Item(0), eModifierType.VisionDay, occurencetime, aghstime)
    'dayvisionval.mValueDuration = hawkduration

    'Dim daymod As New Modifier(dayvisionval, pointtargetallies)
    'outmods.Add(daymod)


    'Dim nightvisionval As New modValue(hawk.SightRange.Item(1), eModifierType.VisionNight, occurencetime, aghstime)
    'nightvisionval.mValueDuration = hawkduration

    'Dim nightmod As New Modifier(nightvisionval, pointtargetallies)
    'outmods.Add(nightmod)


    'Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
    '                                                              thecaster, _
    '                                                               thetarget, _
    '                                                               "", eModifierCategory.Active)

    'Dim damval As New modValue(boar.DamageHigh, eModifierType.DamagePhysicaloT, boar.BaseAttackSpeed, occurencetime, aghstime)
    'damval.mValueDuration = boarpoisonduration

    'Dim dammod As New Modifier(damval, unittargetenemytarget)
    'outmods.Add(dammod)


    'Dim slowval As New modValue(boarmoveslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    'slowval.mValueDuration = boarpoisonduration

    'Dim slowmod As New Modifier(slowval, unittargetenemytarget)
    'outmods.Add(slowmod)

    'Dim attslowval As New modValue(boarattackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    'attslowval.mValueDuration = boarpoisonduration

    'Dim attmod As New Modifier(attslowval, unittargetenemytarget)
    'outmods.Add(attmod)

    Return outmods

  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
