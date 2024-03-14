Public Class itmAghanims_Scepter
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmAGHANIMS_SCEPTER
    Me.EntityName = eEntity.itmAGHANIMS_SCEPTER

    mDisplayName = "Aghanim's Scepter"
    ColorText = "The scepter of a wizard with demigod-like powers."
    mGoldCost = New ValueWrapper(4200)
    mMadeFromItems.Add(eItemname.itmPOINT_BOOSTER)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmOGRE_CLUB)
    mMadeFromItems.Add(eItemname.itmBLADE_OF_ALACRITY)

    mCategory = eItemCategory.CASTER
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ultimate_scepter_lg.png"
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
    Description = "Passive: Ultimate Upgrade - Upgrades the ultimate, and some abilities, of certain heroes."
    Notes = "When a hero has an upgrade available, the item's and the upgraded spell's tooltip state what exactly is upgraded.|When a hero has no upgrades available, the ultimate ability gets a green note reading This hero has no upgrade."

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



    Dim strval As New modValue(10, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(10, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(10, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim hpaddval As New modValue(200, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(hpaddval, passiveselfinfo)

    outmods.Add(health)


    Dim manaaddval As New modValue(150, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(manaaddval, passiveselfinfo)

    outmods.Add(mana)

    Return outmods
  End Function
End Class
