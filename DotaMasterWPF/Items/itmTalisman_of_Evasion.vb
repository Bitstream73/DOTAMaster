Public Class itmTalisman_of_Evasion
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmTALISMAN_OF_EVASION
    Me.EntityName = eEntity.itmTALISMAN_OF_EVASION

    mDisplayName = "Talisman of Evasion"
    Description = "A necklace that allows you to anticipate enemy attacks."
    mGoldCost = New ValueWrapper(1800)

    mBuildsToNames.Add(eItemname.itmHEAVENS_HALBERD)
    mBuildsToNames.Add(eItemname.itmBUTTERFLY)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/talisman_of_evasion_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = "Stacks diminishingly with other sources of Evasion."
    Notes = "" '
    ColorText = "A necklace that allows you to anticipate enemy attacks."

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


    Dim evval As New modValue(0.25, eModifierType.EvasionPercent, occurencetime)

    Dim evasion As New Modifier(evval, passiveselfinfo)

    outmods.Add(evasion)

    Return outmods
  End Function
End Class
