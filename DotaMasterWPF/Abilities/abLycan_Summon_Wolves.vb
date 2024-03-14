Public Class abSummon_Wolves
Inherits AbilityBase
  Public baseattacktime As ValueWrapper
  Public hp As ValueWrapper
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

    mName = eAbilityName.abSummon_Wolves
    Me.EntityName = eEntity.abSummon_Wolves

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLycan

    mDisplayName = "Summon Wolves"
    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lycan_summon_wolves_hp2.png"

    Description = "Summons two wolves to fight for Lycan. Level 2-4 wolves have Critical Strike, level 3-4 wolves have permanent invisibility, and level 4 wolves have 15 HP regen."

    ManaCost = New ValueWrapper(145, 145, 145, 145)

    Cooldown = New ValueWrapper(30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(55, 55, 55, 55)


    baseattacktime = New ValueWrapper(1.25, 1.2, 1.15, 1.1)

    Damage = New ValueWrapper(18, 29, 37, 46)

    hp = New ValueWrapper(200, 240, 280, 320)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    'Dim wolf As New HeroPet_Info
    'wolf.hitpoints = hp
    'wolf.Duration = mDuration
    'wolf.HealthRegen = New ValueWrapper(0.5, 0.5, 0.5, 15)

    'wolf.DamageHigh = New ValueWrapper(18, 30, 40, 49)
    'wolf.DamageLow = New ValueWrapper(17, 27, 34, 43)

    'wolf.armor = New ValueWrapper(1, 1, 1, 1)

    'wolf.movementspeed = New ValueWrapper(400, 420, 440, 460)

    'wolf.SightRange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    'wolf.SightRange.Add(New ValueWrapper(800, 800, 800, 800))

    'wolf.BaseAttackSpeed = New ValueWrapper(1.25, 1.2, 1.15, 1.1)

    'wolf.bounty = New ValueWrapper(21, 26, 36, 41)

    'wolf.xpvalue = New ValueWrapper(20, 20, 20, 20)


    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim wolfval As New modValue(2, eModifierType.petLycan_Wolf, occurencetime)
    'wolfval.mPet = wolf


    Dim wolfmod As New Modifier(wolfval, notargetself)
    outmods.Add(wolfmod)



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
