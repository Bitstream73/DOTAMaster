Public Class itmCirclet
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmCIRCLET
    Me.EntityName = eEntity.itmCIRCLET


    'moved to be calced when associated property is called to get around calling pagehandler during app startup
    'DisplayName = PageHandler.dbItems.GetFriendlyName(mName)
    mDisplayName = "Circlet"

    ' mDescription = "An elegant circlet designed for human princesses. "
    mGoldCost = New ValueWrapper(185)

    mBuildsToNames.Add(eItemname.itmBRACER)
    mBuildsToNames.Add(eItemname.itmWRAITH_BAND)
    mBuildsToNames.Add(eItemname.itmNULL_TALISMAN)

    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/circlet_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    Description = ""
    Notes = "" '
    ColorText = "An elegant circlet designed for human princesses."

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


    Dim strval As New modValue(2, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(2, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(2, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Return outmods
  End Function
End Class
