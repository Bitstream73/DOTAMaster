Public Class itmHyperstone
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHYPERSTONE
    Me.EntityName = eEntity.itmHYPERSTONE

    mDisplayName = "Hyperstone"
    'mDescription = "A mystical, carved stone that boosts the fervor of the holder. "
    mGoldCost = New ValueWrapper(2000)

    mBuildsToNames.Add(eItemname.itmASSAULT_CUIRASS)
    mBuildsToNames.Add(eItemname.itmMJOLLNIR)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/hyperstone_lg.png"
    mTier = 0
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

    Description = ""
    Notes = "" '
    ColorText = "A mystical, carved stone that boosts the fervor of the holder."

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

    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)
    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)
    outmods.Add(attackspeed)

    Return outmods

  End Function
End Class
