Public Class itmPlatemail
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPLATEMAIL
    Me.EntityName = eEntity.itmPLATEMAIL

    mDisplayName = "Platemail"
    ' mDescription = "Thick metal plates that protect the entire upper body. Avoid dropping on feet."
    mGoldCost = New ValueWrapper(1400)

    mBuildsToNames.Add(eItemname.itmASSAULT_CUIRASS)
    mBuildsToNames.Add(eItemname.itmSHIVAS_GUARD)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/platemail_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius =

    Description = ""
    Notes = "" '
    ColorText = "Thick metal plates that protect the entire upper body. Avoid dropping on feet."
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

    Dim armorval As New modValue(10, eModifierType.ArmorAdded, occurencetime)

    Dim armod As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armod)

    Return outmods
  End Function
End Class
