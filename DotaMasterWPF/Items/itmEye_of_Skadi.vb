Public Class itmEye_of_Skadi
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmEYE_OF_SKADI
    mDisplayName = "Eye of Skadi"
    Description = "Extremely rare artifact, guarded by the azure dragons.|Passive: Cold Attack - Attacks slow the movement and attack speed of the target.|Eye of Skadi is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. Eye of Skadi can be combined with Lifesteal Attack Modifiers. "
    mGoldCost = New ValueWrapper(5675)
    mMadeFromItems.Add(eItemname.itmULTIMATE_ORB)
    mMadeFromItems.Add(eItemname.itmULTIMATE_ORB)
    mMadeFromItems.Add(eItemname.itmPOINT_BOOSTER)
    mMadeFromItems.Add(eItemname.itmORB_OF_VENOM)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/skadi_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManaCost = 

    Description = "Passive: Cold Attack - Attacks slow the movement and attack speed of the target.|Eye of Skadi is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. Eye of Skadi can be combined with Lifesteal Attack Modifiers."
    Notes = "Successive attacks with Eye of Skadi do not stack, but refresh the duration instead.|Works against siege creeps and allied units. Does not work against wards and buildings." '
    ColorText = "Extremely rare artifact, guarded by the azure dragons."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim strval As New modValue(25, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(25, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(25, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim hpaddval As New modValue(250, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(hpaddval, passiveselfinfo)

    outmods.Add(health)


    Dim manaaddval As New modValue(250, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(manaaddval, passiveselfinfo)

    outmods.Add(mana)

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim moveval As New modValue(0.35, eModifierType.MoveSpeedPercentSubtracted, occurencetime)

    Dim moveslow As New Modifier(moveval, unittargetenemytargetinfo)

    outmods.Add(moveslow)


    Dim attspeedval As New modValue(0.35, eModifierType.AttackspeedSubtracted, occurencetime)

    Dim attackspeedslow As New Modifier(attspeedval, unittargetenemytargetinfo)

    outmods.Add(attackspeedslow)

    Return outmods
  End Function
  Public Overrides Property AbilityDescription As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                 thecaster As iDisplayUnit, _
                                 thetarget As iDisplayUnit, _
                                 ftarget As iDisplayUnit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList

  End Function

End Class
