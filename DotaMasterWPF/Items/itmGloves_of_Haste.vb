Public Class itmGloves_of_Haste
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmGLOVES_OF_HASTE
    Me.EntityName = eEntity.itmGLOVES_OF_HASTE

    mDisplayName = "Gloves of Haste"
    'mDescription = "A pair of magical gloves that seems to render weapons weightless. "
    mGoldCost = New ValueWrapper(500)

    mBuildsToNames.Add(eItemname.itmPOWER_TREADS)
    mBuildsToNames.Add(eItemname.itmHAND_OF_MIDAS)
    mBuildsToNames.Add(eItemname.itmARMLET_OF_MORDIGGIAN)
    mBuildsToNames.Add(eItemname.itmMAELSTROM)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/gloves_lg.png"
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
    Notes = "" '
    ColorText = "A pair of magical gloves that seems to render weapons weightless."

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


    Dim attspeedval As New modValue(15, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attspmod As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attspmod)

    Return outmods
  End Function
End Class
