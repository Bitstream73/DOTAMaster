Public Class itmLinkens_Sphere
  Inherits ItemBase

  Public Sub New(ByVal theparent As Object, ByVal theparenttype As eSourceType, ByVal theparentname As eUnit)
    MyBase.New(theparent, theparenttype, theparentname)
    mName = eItemname.itmRECIPE_LINKENS_SPHERE
    mDisplayname = "Linken's Sphere Recipe"
    mDescription = ""
    mGoldCost = 1325

    mCategory = eItemCategory.RECIPE
    mSoldFrom.Add(eShopTypes.Fountain)
    mImageUrl = "http://cdn.dota2.com/apps/dota2/images/items/recipe_lg.png"
    mTier = 0
    mIsRecipe = True
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =
  End Sub
  Public Overrides Function GetPassiveModifiers() As ModifierList
    Return Nothing
  End Function
End Class
