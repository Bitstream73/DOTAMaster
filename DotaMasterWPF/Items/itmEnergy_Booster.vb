Public Class itmEnergy_Booster
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmENERGY_BOOSTER
    Me.EntityName = eEntity.itmENERGY_BOOSTER

    mDisplayName = "Energy Booster"
    'mDescription = "This lapis gemstone is commonly added to the collection of wizards seeking to improve their presence in combat. "
    mGoldCost = New ValueWrapper(1000)

    mBuildsToNames.Add(eItemname.itmSOUL_BOOSTER)
    mBuildsToNames.Add(eItemname.itmARCANE_BOOTS)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/energy_booster_lg.png"
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
    ColorText = "This lapis gemstone is commonly added to the collection of wizards seeking to improve their presence in combat."

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

    Dim manaaddval As New modValue(250, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(manaaddval, passiveselfinfo)

    outmods.Add(mana)

    Return outmods

  End Function
End Class
