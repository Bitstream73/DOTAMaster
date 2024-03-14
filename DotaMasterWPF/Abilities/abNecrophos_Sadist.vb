Public Class abSadist
Inherits AbilityBase


  Public manaregenpersec As ValueWrapper
  Public heromanaregenpersec As ValueWrapper

  Public healthregenpersec As ValueWrapper
  Public herohealthregenpersec As ValueWrapper
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

    Notes = "Sadist is also triggered by denies.|Stacks with itself. Each stack operates independently.|Regen a total of 12/24/36/60 mana and 6/12/18/24 health (120/240/360/600 mana and 60/120/180/240 health for hero kill)." '"

    mDisplayName = "Sadist"
    mName = eAbilityName.abSadist
    Me.EntityName = eEntity.abSadist

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecrophos

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/necrolyte_sadist_hp2.png"

    Description = "Necrophos gains hp and mana regeneration for every unit he kills. Hero kills grant 10x the regen bonus."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    manaregenpersec = New ValueWrapper(2, 4, 6, 10)
    heromanaregenpersec = New ValueWrapper(manaregenpersec.Value(0) * 10, manaregenpersec.Value(1) * 10, manaregenpersec.Value(2) * 10, manaregenpersec.Value(3) * 10)

    healthregenpersec = New ValueWrapper(1, 2, 3, 4)
    herohealthregenpersec = New ValueWrapper(healthregenpersec.Value(0) * 10, healthregenpersec.Value(1) * 10, healthregenpersec.Value(2) * 10, healthregenpersec.Value(3) * 10)

    Duration = New ValueWrapper(6, 6, 6, 6)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     theowner As idisplayunit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    'Dim duration = New TimeSpan(0, 0, 6)
    'hero bonuses
    Dim heromanaval As New modValue(heromanaregenpersec, eModifierType.ManaRegenPerUnitKillAdded, occurencetime, aghstime)
    heromanaval.mValueDuration = New ValueWrapper(6, 6, 6, 6) 'duration

    Dim heromana As New Modifier(heromanaval, notargetself)
    outmods.Add(heromana)


    Dim herohpval As New modValue(herohealthregenpersec, eModifierType.HPRegenPerUnitKilledAdded, occurencetime, aghstime)
    herohpval.mValueDuration = New ValueWrapper(6, 6, 6, 6) 'duration

    Dim herohp As New Modifier(herohpval, notargetself)
    outmods.Add(herohp)

    'creep bonuses
    Dim creepmanaval As New modValue(manaregenpersec, eModifierType.ManaRegenAdded, occurencetime, aghstime)
    creepmanaval.mValueDuration = New ValueWrapper(6, 6, 6, 6) 'duration

    Dim creepmana As New Modifier(creepmanaval, notargetself)
    outmods.Add(creepmana)


    Dim creephpval As New modValue(healthregenpersec, eModifierType.HPRegenAdded, occurencetime, aghstime)
    creephpval.mValueDuration = New ValueWrapper(6, 6, 6, 6) 'duration

    Dim creephp As New Modifier(creephpval, notargetself)
    outmods.Add(creephp)

    Return outmods
  End Function
End Class
