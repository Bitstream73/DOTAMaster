Public Class itmSages_Mask
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSAGES_MASK
    Me.EntityName = eEntity.itmSAGES_MASK

    mDisplayName = "Sage's Mask"
    'mDescription = "A mask commonly used by mages and warlocks for various rituals."
    mGoldCost = New ValueWrapper(325)

    mBuildsToNames.Add(eItemname.itmOBLIVION_STAFF)
    mBuildsToNames.Add(eItemname.itmRING_OF_BASILIUS)
    mBuildsToNames.Add(eItemname.itmURN_OF_SHADOWS)
    mBuildsToNames.Add(eItemname.itmEULS_SCEPTER_OF_DIVINITY)
    mBuildsToNames.Add(eItemname.itmSOUL_RING)
    mBuildsToNames.Add(eItemname.itmMEDALLION_OF_COURAGE)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/sobi_mask_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = ""
    Notes = "" 'FixFixFix
    ColorText = "A mask commonly used by mages and warlocks for various rituals."
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


    Dim manaval As New modValue(0.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manamod As New Modifier(manaval, passiveselfinfo)

    outmods.Add(manamod)

    Return outmods
  End Function
End Class
