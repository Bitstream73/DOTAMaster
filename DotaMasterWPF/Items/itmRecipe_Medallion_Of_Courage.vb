Public Class itmRecipe_Medallion_Of_Courage
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRECIPE_MEDALLION_OF_COURAGE
    Me.EntityName = eEntity.itmRECIPE_MEDALLION_OF_COURAGE

    mDisplayName = "Medallion of Courage Recipe"
    Description = ""
    mGoldCost = New ValueWrapper(200)

    mBuildsToNames.Add(eItemname.itmMEDALLION_OF_COURAGE)

    mCategory = eItemCategory.RECIPE
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/recipe_lg.png"
    mTier = 0
    mIsRecipe = True
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = ""
    Notes = "" 'FixFixFix
    ColorText = ""
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                   theownerid As idisplayunit, _
                                                   thetarget As idisplayunit, _
                                                   ftarget As idisplayunit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function
End Class
