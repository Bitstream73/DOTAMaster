Public Class itmRobe_of_the_Magi
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmROBE_OF_THE_MAGI
    Me.EntityName = eEntity.itmROBE_OF_THE_MAGI

    mDisplayName = "Robe of the Magi"
    'mDescription = "This robe corrupts the soul of the user, but provides wisdom in return. "
    mGoldCost = New ValueWrapper(450)

    mBuildsToNames.Add(eItemname.itmOBLIVION_STAFF)
    mBuildsToNames.Add(eItemname.itmBLADE_MAIL)
    mBuildsToNames.Add(eItemname.itmDIFFUSAL_BLADE_1)
    mBuildsToNames.Add(eItemname.itmDRUM_OF_ENDURANCE)

    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/robe_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    Description = ""
    Notes = "" '
    ColorText = "This robe corrupts the soul of the user, but provides wisdom in return. "
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

    Dim intval As New modValue(6, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)

    Return outmods
  End Function
End Class
