Public Class itmBand_of_Elvenskin
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBAND_OF_ELVENSKIN
    Me.EntityName = eEntity.itmBAND_OF_ELVENSKIN

    mDisplayName = "Band of Elvenskin"
    'mDescription = "A tensile fabric often used for its light weight and ease of movement. "
    mGoldCost = New ValueWrapper(450)
    '    mMadeFrom.Add()
    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/boots_of_elves_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    Description = ""
    Notes = "" '
    ColorText = "ight weight and ease of movement. "
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

    Dim agival As New modValue(6, eModifierType.AgiAdded, occurencetime)
    Dim agimod As New Modifier(agival, passiveselfinfo)
    outmods.Add(agimod)

    Return outmods
  End Function
End Class
