Public Class itmMithril_Hammer
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMITHRIL_HAMMER
    Me.EntityName = eEntity.itmMITHRIL_HAMMER

    mDisplayName = "Mithril Hammer"
    'mDescription = "A hammer forged of pure mithril. "
    mGoldCost = New ValueWrapper(1600)

    mBuildsToNames.Add(eItemname.itmBLACK_KING_BAR)
    mBuildsToNames.Add(eItemname.itmMAELSTROM)
    mBuildsToNames.Add(eItemname.itmDESOLATOR)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/mithril_hammer_lg.png"
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
    ColorText = "A hammer forged of pure mithril."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)


    Dim damval As New modValue(21, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim dammod As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(dammod)

    Return outmods
  End Function
End Class
