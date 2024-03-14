Public Class itmBlade_of_Alacrity
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBLADE_OF_ALACRITY
    Me.EntityName = eEntity.itmBLADE_OF_ALACRITY

    mDisplayName = "Blade of Alacrity"
    ' mDescription = "A long blade imbued with time magic."
    mGoldCost = New ValueWrapper(1000)

    mBuildsToNames.Add(eItemname.itmAGHANIMS_SCEPTER)
    mBuildsToNames.Add(eItemname.itmRECIPE_YASHA)
    mBuildsToNames.Add(eItemname.itmDIFFUSAL_BLADE_1)

    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/blade_of_alacrity_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    Description = ""
    Notes = "" '
    ColorText = "A long blade imbued with time magic. "
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


    Dim agival As New modValue(10, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)

    Return outmods
  End Function
End Class
