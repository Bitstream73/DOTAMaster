Public Class Empty_Item
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.None
    Me.EntityName = eEntity.None


    mDisplayName = "Click to Select"
    Description = ""
    mGoldCost = New ValueWrapper(0)

    mMadeFromItems = New List(Of eItemname)
    mCategory = eItemCategory.NONE

    ImageURL = ""

    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManaCost = 

  End Sub


End Class
