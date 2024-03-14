Public Class itmChainmail
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmCHAINMAIL
    Me.EntityName = eEntity.itmCHAINMAIL

    mDisplayName = "Chainmail"
    'mDescription = "A medium weave of metal chains."
    mGoldCost = New ValueWrapper(550)

    mBuildsToNames.Add(eItemname.itmBUCKLER)
    mBuildsToNames.Add(eItemname.itmASSAULT_CUIRASS)
    mBuildsToNames.Add(eItemname.itmBLADE_MAIL)
    mBuildsToNames.Add(eItemname.itmMEDALLION_OF_COURAGE)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/chainmail_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    '    mCooldown = 
    'mRadius = 
    Description = ""
    Notes = "" '
    ColorText = "A medium weave of metal chains."

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

    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)

    Return outmods
  End Function
End Class
