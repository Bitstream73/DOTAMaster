Public Class itmPoint_Booster
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPOINT_BOOSTER
    Me.EntityName = eEntity.itmPOINT_BOOSTER

    mDisplayName = "Point Booster"
    'mDescription = "A perfectly formed amethyst that nourishes body and mind when held. "
    mGoldCost = New ValueWrapper(0)

    mBuildsToNames.Add(eItemname.itmAGHANIMS_SCEPTER)
    mBuildsToNames.Add(eItemname.itmSOUL_BOOSTER)
    mBuildsToNames.Add(eItemname.itmEYE_OF_SKADI)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/point_booster_lg.png"
    mTier = 0
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


    Description = ""
    Notes = "" '
    ColorText = "A perfectly formed amethyst that nourishes body and mind when held."
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

    Dim hpaddval As New modValue(200, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(hpaddval, passiveselfinfo)

    outmods.Add(health)


    Dim manaaddval As New modValue(150, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(manaaddval, passiveselfinfo)

    outmods.Add(mana)

    Return outmods
  End Function
End Class
