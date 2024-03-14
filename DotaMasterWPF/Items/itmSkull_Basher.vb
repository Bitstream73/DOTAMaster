Public Class itmSkull_Basher
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSKULL_BASHER
    Me.EntityName = eEntity.itmSKULL_BASHER

    mDisplayName = "Skull Basher"
    ' mDescription = "A feared weapon in the right hands, this maul's ability to shatter the defenses of its opponents should not be underestimated.|Passive: Bash - Gives a chance to stun for 1.4 seconds."
    mGoldCost = New ValueWrapper(2950)
    mMadeFromItems.Add(eItemname.itmRECIPE_SKULL_BASHER)
    mMadeFromItems.Add(eItemname.itmBELT_OF_STRENGTH)
    mMadeFromItems.Add(eItemname.itmJAVELIN)

    mBuildsToNames.Add(eItemname.itmHEAVENS_HALBERD)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/basher_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(2)
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManaCost = 

    Description = "Passive: Bash - Gives a chance to stun for 1.4 seconds."
    Notes = "Multiple Bash sources do not stack, except with the mini-bash from Monkey King Bar|If both proc on the same hit, the one with the longer stun occurs, which always is Skull Basher." '
    ColorText = "A feared weapon in the right hands, this maul's ability to shatter the defenses of its opponents should not be underestimated."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unitenemyrangedinfo = Helpers.GetUnitTargetEnemyRangedTargetInfo(theitem_InfoID, _
                                                                           theownerid, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Passive)

    Dim stunval As New modValue(1.4, eModifierType.Stun, occurencetime)
    stunval.mValueDuration = New ValueWrapper(1.4) 'New TimeSpan(1400)
    stunval.mPercentChance = New ValueWrapper(0.1)

    Dim rangedbash As New Modifier(stunval, unitenemyrangedinfo)

    outmods.Add(rangedbash)


    Dim meleeval As New modValue(1.4, eModifierType.Stun, occurencetime)
    meleeval.mValueDuration = stunval.mValueDuration ' New TimeSpan(1400)
    meleeval.mPercentChance = New ValueWrapper(0.25)

    Dim meleebash As New Modifier(meleeval, unitenemyrangedinfo)

    outmods.Add(meleebash)


    Return outmods
  End Function
End Class
