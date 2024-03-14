﻿Public Class itmRecipe_Wraith_Band
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRECIPE_WRAITH_BAND
    Me.EntityName = eEntity.itmWRAITH_BAND

    mDisplayName = "Wraith Band Recipe"
    Description = ""
    mGoldCost = New ValueWrapper(150)

    mBuildsToNames.Add(eItemname.itmWRAITH_BAND)

    mCategory = eItemCategory.RECIPE
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/recipe_lg.png"
    mTier = 0
    mIsRecipe = True
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = ""
    Notes = "" 'FixFixFix
    ColorText = ""

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function
  Public Overrides Property AbilityDescription As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                 thecaster As iDisplayUnit, _
                                 thetarget As iDisplayUnit, _
                                 ftarget As iDisplayUnit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList

  End Function

End Class
