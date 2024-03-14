Public Class itmBoots_of_Speed
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBOOTS_OF_SPEED
    Me.EntityName = eEntity.itmBOOTS_OF_SPEED

    mDisplayName = "Boots of Speed"
    ' mDescription = "Fleet footwear, increasing movement. Flat movement speed bonuses from multiple pairs of boots do not stack."
    mGoldCost = New ValueWrapper(450)


    mBuildsToNames.Add(eItemname.itmBOOTS_OF_TRAVEL)
    mBuildsToNames.Add(eItemname.itmPHASE_BOOTS)
    mBuildsToNames.Add(eItemname.itmPOWER_TREADS)
    mBuildsToNames.Add(eItemname.itmTRANQUIL_BOOTS)
    mBuildsToNames.Add(eItemname.itmARCANE_BOOTS)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/boots_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =
    Description = "Flat movement speed bonuses from multiple pairs of boots do not stack. "
    Notes = "" '
    ColorText = "Fleet footwear, increasing movement. "
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

    Dim speedval As New modValue(50, eModifierType.MoveSpeedAdded, occurencetime)

    Dim speedmod As New Modifier(speedval, passiveselfinfo)
    outmods.Add(speedmod)

    Return outmods
  End Function
End Class
