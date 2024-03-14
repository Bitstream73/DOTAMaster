Public Class itmRecipe_Linkens_Sphere

  Inherits ItemBase

  Public Sub New(theparent As iDisplayUnit, parentorbuildname As eUnit)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRECIPE_LINKENS_SPHERE
    Me.EntityName = eEntity.itmRECIPE_LINKENS_SPHERE

    mDisplayName = "Linkens Sphere Recipe"
    Description = ""
    mGoldCost = New ValueWrapper(1325)

    mBuildsToNames.Add(eItemname.itmLINKENS_SPHERE)

    mCategory = eItemCategory.RECIPE
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/sphere_lg.png"
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
                                                     theowner As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function
End Class
