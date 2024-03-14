Public Class itmDivine_Rapier
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDIVINE_RAPIER
    Me.EntityName = eEntity.itmDIVINE_RAPIER

    mDisplayName = "Divine Rapier"
    'mDescription = "So powerful, it cannot have a single owner. "
    mGoldCost = New ValueWrapper(6200)
    mMadeFromItems.Add(eItemname.itmSACRED_RELIC)
    mMadeFromItems.Add(eItemname.itmDEMON_EDGE)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/rapier_lg.png"
    mTier = 2
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

    Description = "Drops on death. Divine Rapier is muted to anyone but the owner, as long as he or his teammates pick it up. As soon as an enemy picks it up, Divine Rapier is unmuted, but cannot be dropped except on death."
    Notes = "" '
    ColorText = "So powerful, it cannot have a single owner."

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

    Dim damval As New modValue(300, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)

    Return outmods
  End Function


End Class
