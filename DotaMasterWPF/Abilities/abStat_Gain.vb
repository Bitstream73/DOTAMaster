Public Class abStat_Gain
  Inherits AbilityBase


  Public strgain As ValueWrapper
  Public intgain As ValueWrapper
  Public agigain As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Adding one level to Attribute Bonus is functionally equivalent to having a Circlet or two Iron Branches.|Attribute Bonus can be leveled 10 times.|Invoker does not possess this ability because Quas, Wex, and Exort passively improve his attributes.|Because of the associated bonuses of each attribute, each level of Attribute Bonus has the following cumulative effects: 2 damage - 38 maximum health; 0.06 health regeneration - 0.28 armor; 2 attack speed - 26 maximum mana and 0.08 mana regeneration."

    mDisplayName = "Stat Gain"
    mName = eAbilityName.abStat_Gain
    Me.EntityName = eEntity.abStat_Gain

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntity = Nothing 'need special case here for StatGain since it could be anyone

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    'mAbilityImage = "\Assets\Stats.png"
    mAbilityImage = "http://devilesk.com/media/images/spellicons/attribute_bonus.png"
    WebpageLink = ""
    Description = "Increase Strength, Intelligence and Agility by 2"


    AbilityTypes.Add(eAbilityType.Passive)


    Affects.Add(eUnit.untSelf)

    strgain = New ValueWrapper(2, 4, 6, 8, 10, 12, 14, 16, 18, 20)
    agigain = New ValueWrapper(2, 4, 6, 8, 10, 12, 14, 16, 18, 20)
    intgain = New ValueWrapper(2, 4, 6, 8, 10, 12, 14, 16, 18, 20)

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

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim intval As New modValue(intgain, eModifierType.IntAdded, occurencetime, aghstime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim strval As New modValue(strgain, eModifierType.StrAdded, occurencetime, aghstime)

    Dim str As New Modifier(strval, passiveselfinfo)

    outmods.Add(str)


    Dim agival As New modValue(agigain, eModifierType.AgiAdded, occurencetime, aghstime)

    Dim agi As New Modifier(agival, passiveselfinfo)

    outmods.Add(agi)

    Return outmods


  End Function
End Class
