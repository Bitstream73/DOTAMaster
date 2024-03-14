Public Class itmBelt_of_Strength
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBELT_OF_STRENGTH
    Me.EntityName = eEntity.itmBELT_OF_STRENGTH

    mDisplayName = "Belt of Strength"
    'mDescription = "A valued accessory for improving vitality. "
    mGoldCost = New ValueWrapper(450)

    mBuildsToNames.Add(eItemname.itmPOWER_TREADS)
    mBuildsToNames.Add(eItemname.itmNECRONOMICON_1)
    mBuildsToNames.Add(eItemname.itmSKULL_BASHER)
    mBuildsToNames.Add(eItemname.itmSANGE)

    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/belt_of_strength_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    Description = ""
    Notes = "" 'FixFixFix
    ColorText = "A valued accessory for improving vitality. "
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

    Dim strval As New modValue(6, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)
    outmods.Add(strmod)

    Return outmods
  End Function
End Class
