Public Class itmSacred_Relic
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSACRED_RELIC
    Me.EntityName = eEntity.itmSACRED_RELIC

    mDisplayName = "Sacred Relic"
    'mDescription = "An ancient weapon that often turns the tides of war. "
    mGoldCost = New ValueWrapper(3800)

    mBuildsToNames.Add(eItemname.itmABYSSAL_BLADE)
    mBuildsToNames.Add(eItemname.itmDIVINE_RAPIER)
    mBuildsToNames.Add(eItemname.itmRADIANCE)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/relic_lg.png"
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
    ColorText = "An ancient weapon that often turns the tides of war."
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

    Dim damval As New modValue(60, eModifierType.DamagePhysicalAdded, occurencetime)
    Dim damage As New Modifier(damval, unittargetenemytargetinfo)
    outmods.Add(damage)

    Return outmods
  End Function
End Class
