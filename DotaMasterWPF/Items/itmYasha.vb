Public Class itmYasha
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmYASHA
    Me.EntityName = eEntity.itmYASHA

    mDisplayName = "Yasha"
    'mDescription = "Yasha is regarded as the swiftest weapon ever created.|Yasha-based movement speed bonuses from multiple items do not stack. "
    mGoldCost = New ValueWrapper(2050)
    mMadeFromItems.Add(eItemname.itmRECIPE_YASHA)
    mMadeFromItems.Add(eItemname.itmBLADE_OF_ALACRITY)
    mMadeFromItems.Add(eItemname.itmBAND_OF_ELVENSKIN)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/yasha_lg.png"
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

    Description = "Yasha-based movement speed bonuses from multiple items do not stack."
    Notes = "" 'FixFixFix
    ColorText = "Yasha is regarded as the swiftest weapon ever created."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                                    theownerid As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim agival As New modValue(16, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim attspeedval As New modValue(15, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)



    Dim movespeedval As New modValue(0.1, eModifierType.MoveSpeedPercent, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)

    Return outmods
  End Function
End Class
