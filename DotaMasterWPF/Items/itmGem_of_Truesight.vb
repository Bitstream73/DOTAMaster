Public Class itmGem_of_Truesight
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmGEM_OF_TRUE_SIGHT
    Me.EntityName = eEntity.itmGEM_OF_TRUE_SIGHT

    mDisplayName = "Gem of Truesight"
    'mDescription = "True Sight - Gives the ability to see invisible units and wards. Drops on death, but cannot be destroyed. Disabled while on courier"
    mGoldCost = New ValueWrapper(900)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/gem_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    Radius = New ValueWrapper(1100)
    'mCharges =

    Description = "Passive: True Sight - Gives the ability to see invisible units and wards. Drops on death, but cannot be destroyed. "
    Notes = "The True Sight is provided within the whole area, regardless of the carrier's actual vision. It is fully unobstructed.|The True Sight is provided by an aura, its effect lingers for 0.5 seconds.|Can not detect units under the effect of Shadow Dance and Smoke of Deceit.|True Sight does not work when the Gem is in a courier's or in Lone Druid's Spirit Bear's inventory.|True Sight is disabled by hex and an Aghanim's Scepter upgraded Doom." '
    ColorText = ""

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveauraenemystealthinfo = Helpers.GetPassiveAuraEnemyStealthUnitsInfo(theitem_InfoID, _
                                                                                  theownerid, _
                                                                                  thetarget, _
                                                                                  "", eModifierCategory.Passive)

    Dim visval As New modValue(1, eModifierType.StealthVisibility, occurencetime)

    Dim sitemod As New Modifier(visval, passiveauraenemystealthinfo)

    outmods.Add(sitemod)

    Return outmods
  End Function
End Class
