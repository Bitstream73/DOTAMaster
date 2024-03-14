Public Class itmSoul_Booster
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSOUL_BOOSTER
    Me.EntityName = eEntity.itmSOUL_BOOSTER

    mDisplayName = "Soul Booster"
    'mDescription = "Regain lost courage. "
    mGoldCost = New ValueWrapper(3300)
    mMadeFromItems.Add(eItemname.itmVITALITY_BOOSTER)
    mMadeFromItems.Add(eItemname.itmENERGY_BOOSTER)
    mMadeFromItems.Add(eItemname.itmPOINT_BOOSTER)

    mBuildsToNames.Add(eItemname.itmBLOODSTONE)

    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/soul_booster_lg.png"
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

    Description = ""
    Notes = "" '
    ColorText = "Regain lost courage."

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

    Dim hpaddval As New modValue(450, eModifierType.HPAdded, occurencetime)
    Dim health As New Modifier(hpaddval, passiveselfinfo)
    outmods.Add(health)

    Dim manaaddval As New modValue(400, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(hpaddval, passiveselfinfo)

    outmods.Add(mana)


    Dim hpregenval As New modValue(4, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)


    Dim manaregenval As New modValue(1, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)

    Return outmods
  End Function
End Class
