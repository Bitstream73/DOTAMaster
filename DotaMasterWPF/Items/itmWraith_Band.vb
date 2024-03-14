Public Class itmWraith_Band
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmWRAITH_BAND
    Me.EntityName = eEntity.itmWRAITH_BAND

    mDisplayName = "Wraith Band"
    Description = "A circlet with faint whispers echoing about it. "
    mGoldCost = New ValueWrapper(485)

    mBuildsToNames.Add(eItemname.itmRING_OF_AQUILA)

    mMadeFromItems.Add(eItemname.itmRECIPE_WRAITH_BAND)
    mMadeFromItems.Add(eItemname.itmCIRCLET)
    mMadeFromItems.Add(eItemname.itmSLIPPERS_OF_AGILITY)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/wraith_band_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = ""
    Notes = "" '
    ColorText = "A circlet with faint whispers echoing about it."

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

    Dim strval As New modValue(3, eModifierType.StrAdded, occurencetime)

    Dim str As New Modifier(strval, passiveselfinfo)

    outmods.Add(str)


    Dim agival As New modValue(6, eModifierType.AgiAdded, occurencetime)

    Dim agi As New Modifier(agival, passiveselfinfo)

    outmods.Add(agi)


    Dim intval As New modValue(3, eModifierType.IntAdded, occurencetime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim damval As New modValue(3, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim dam As New Modifier(damval, passiveselfinfo)

    outmods.Add(dam)

    Return outmods
  End Function
End Class
