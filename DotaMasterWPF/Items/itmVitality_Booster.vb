Public Class itmVitality_Booster
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmVITALITY_BOOSTER
    Me.EntityName = eEntity.itmVITALITY_BOOSTER

    mDisplayName = "Vitality Booster"
    'mDescription = "A ruby gemstone that has been passed down through generations of warrior kin. "
    mGoldCost = New ValueWrapper(1100)

    mBuildsToNames.Add(eItemname.itmHEART_OF_TARRASQUE)
    mBuildsToNames.Add(eItemname.itmMANTA_STYLE)
    mBuildsToNames.Add(eItemname.itmSOUL_BOOSTER)
    mBuildsToNames.Add(eItemname.itmROD_OF_ATOS)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/vitality_booster_lg.png"
    mTier =
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
    ColorText = "A ruby gemstone that has been passed down through generations of warrior kin."

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

    Dim hpval As New modValue(250, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(hpval, passiveselfinfo)

    outmods.Add(health)

    Return outmods
  End Function
End Class

