Public Class abReactive_Armor
Inherits AbilityBase

  Public bonusarmor As ValueWrapper
  Public bonushpregen As ValueWrapper
  Public mStacks As ValueWrapper
  Public stackduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Triggers on attacks from any unit, including allies trying to deny you.|The armor and HP regen buff is applied at the beginning of the attack.|Each stack duration has its own duration and is independant from other stacks.|Amount of stacks are shown on the status buff icon.|The amount of stacks are also visually indicated by a dome which closes over on Timbersaw. Every 4 stacks cause 1 fragment of the dome to appear.|1-4 stacks 1 fragment, 5-8 stacks 2 fragments, 9-13 stacks 3 fragments and at 14-16 stacks the dome is fully closed." '"

    mDisplayName = "Reactive Armor"
    mName = eAbilityName.abReactive_Armor
    Me.EntityName = eEntity.abReactive_Armor

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTimbersaw

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shredder_reactive_armor_hp2.png"

    Description = "Each time Timbersaw is attacked, he gains increased health regen and armor."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    bonusarmor = New ValueWrapper(1, 1, 1, 1)

    bonushpregen = New ValueWrapper(1, 1, 1, 1)

    mStacks = New ValueWrapper(4, 8, 12, 16)

    stackduration = New ValueWrapper(16, 16, 16, 16)
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
                                                   "", eModifierCategory.Passive)

    Dim armorval As New modValue(bonusarmor, eModifierType.ArmorAdded, occurencetime, aghstime)
    armorval.Charges = mStacks
    armorval.mValueDuration = stackduration

    Dim armor As New Modifier(armorval, notargetself)
    outmods.Add(armor)


    Dim hpregenval As New modValue(bonushpregen, eModifierType.HPRegenAdded, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    hpregenval.Charges = mStacks
    hpregenval.mValueDuration = armorval.mValueDuration

    Dim hpregen As New Modifier(hpregenval, notargetself)
    outmods.Add(hpregen)
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
