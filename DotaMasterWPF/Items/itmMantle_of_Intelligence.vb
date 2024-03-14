Public Class itmMantle_of_Intelligence
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMANTLE_OF_INTELLIGENCE
    Me.EntityName = eEntity.itmMANTLE_OF_INTELLIGENCE

    mDisplayName = "Mantle of Intelligence"
    ColorText = "A beautiful sapphire mantle worn by generations of queens. "
    mGoldCost = New ValueWrapper(150)

    mBuildsToNames.Add(eItemname.itmNULL_TALISMAN)

    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/mantle_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    Description = ""
    Notes = "" '


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

    Dim agival As New modValue(3, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)
    outmods.Add(agimod)

    Return outmods
  End Function
End Class
