Public Class abWarcry
Inherits AbilityBase
  Public bonusarmor As ValueWrapper
  Public bonusspeed As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Has an instant cast time, but interrupts channeling.|Fully stacks with other armor and movement speed granting abilities and items." '"

    mDisplayName = "Warcry"
    mName = eAbilityName.abWarcry
    Me.EntityName = eEntity.abWarcry

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSven

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sven_warcry_hp2.png"

    Description = "Sven's Warcry heartens his allies for battle, increasing their movement speed and armor. Lasts 7 seconds."

    ManaCost = New ValueWrapper(25, 25, 25, 25)

    Cooldown = New ValueWrapper(32, 26, 20, 14)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    bonusarmor = New ValueWrapper(4, 8, 12, 16)

    bonusspeed = New ValueWrapper(0.12, 0.12, 0.12, 0.12)
    
    Duration = New ValueWrapper(7, 7, 7, 7)

    Radius = New ValueWrapper(900, 900, 900, 900)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraallies = Helpers.GetActiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                      thecaster, _
                                                      thetarget, _
                                                      "", eModifierCategory.Active)


    Dim armorval As New modValue(bonusarmor, eModifierType.ArmorAdded, occurencetime, aghstime)
    armorval.mValueDuration = Duration

    Dim thearmor As New Modifier(armorval, auraallies)
    outmods.Add(thearmor)

    Dim myarmor As New Modifier(armorval, notargetself)
    outmods.Add(myarmor)



    Dim speedval As New modValue(bonusspeed, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    speedval.mValueDuration = Duration

    Dim thespeed As New Modifier(speedval, auraallies)
    outmods.Add(thespeed)

    Dim myspeed As New Modifier(speedval, notargetself)
    outmods.Add(myspeed)




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
