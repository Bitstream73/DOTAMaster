Public Class abWhirling_Axes__Melee
  Inherits AbilityBase

  'ranged
  Public raxedamage As ValueWrapper
  Public rslowduration As ValueWrapper
  Public rmoveslow As ValueWrapper
  Public rcooldown As ValueWrapper
  Public raxecount As ValueWrapper
  'melee
  Public maxedamage As ValueWrapper
  Public maxeradius As ValueWrapper
  Public mblindduration As ValueWrapper
  Public mmisschance As ValueWrapper
  Public mwhirlduration As ValueWrapper

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


    ''''
    '! needs to do double duty for ranged ability!!!
    ''''

    Notes = "" 'FixFixFix"

    mDisplayName = "Whirling Axes"
    mName = eAbilityName.abWhirling_Axes__Melee
    Me.EntityName = eEntity.abWhirling_Axes__Melee

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTroll_Warlord

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/troll_warlord_whirling_axes_melee_hp2.png"

    Description = "Troll hurls two axes around him in a close range area of effect, damaging enemy units and causing them to miss some attacks."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    raxedamage = New ValueWrapper(75, 75, 75, 75)
    rslowduration = New ValueWrapper(3, 3.75, 4.5, 5.25)
    rmoveslow = New ValueWrapper(0.3, 0.3, 0.3, 0.3)
    raxecount = New ValueWrapper(5, 5, 5, 5)

    maxedamage = New ValueWrapper(75, 125, 175, 225)
    maxeradius = New ValueWrapper(450, 450, 450, 450)
    mblindduration = New ValueWrapper(4, 5, 6, 7)
    mmisschance = New ValueWrapper(0.6, 0.6, 0.6, 0.6)
    mwhirlduration = New ValueWrapper(3, 3, 3, 3)


  End Sub

  'melee
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)


    'damage
    Dim damval As New modValue(maxedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, auraenemies)
    outmods.Add(dammod)

    'blind
    Dim blindval As New modValue(mblindduration, eModifierType.BlindDuration, occurencetime, aghstime)
    blindval.mValueDuration = mblindduration
    blindval.Charges = mmisschance

    Dim blindmod As New Modifier(blindval, auraenemies)

    Return outmods
  End Function

  'ranged
  Public Function GetActiveRangedModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim coneenemies = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)

    'damage
    Dim damval As New modValue(raxedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.Charges = raxecount

    Dim dammod As New Modifier(damval, coneenemies)

    'move slow
    Dim moveval As New modValue(rmoveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = rslowduration

    Dim movemod As New Modifier(moveval, coneenemies)
    outmods.Add(movemod)


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
