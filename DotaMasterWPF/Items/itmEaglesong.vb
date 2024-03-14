Public Class itmEaglesong
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmEAGLESONG
    Me.EntityName = eEntity.itmEAGLESONG

    mDisplayName = "Eaglesong"
    'mDescription = "Capturing the majestic call of an eagle, this mystical horn brings limitless dexterity to those who hear it. "
    mGoldCost = New ValueWrapper(3300)

    mBuildsToNames.Add(eItemname.itmBUTTERFLY)
    mBuildsToNames.Add(eItemname.itmETHEREAL_BLADE)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/eagle_lg.png"
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
    ColorText = "Capturing the majestic call of an eagle, this mystical horn brings limitless dexterity to those who hear it."

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

    Dim agival As New modValue(25, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Return outmods
  End Function
End Class
