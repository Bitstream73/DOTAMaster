Public Class itmTown_Portal_Scroll
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmTOWN_PORTAL_SCROLL
    Me.EntityName = eEntity.itmTOWN_PORTAL_SCROLL

    mDisplayName = "Town Portal Scroll" 'PageHandler.dbItems.GetFriendlyName(mName)
    Description = ""
    mGoldCost = New ValueWrapper(135)
    ManaCost = New ValueWrapper(75)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/tpscroll_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False
    'Ability
    Cooldown = New ValueWrapper(65)
    Charges = New ValueWrapper(1)

    Description = "Use: Teleport - Teleports you to a target friendly building. "
    Notes = "Double clicking the item automatically targets your team's fountain.|When targeting far away from buildings, it teleports to the closest building, 575 range away from it.|During the channeling, the teleport destination is marked with a visual effect in the same color as the player and a sound is played. Both are visible and audible to everyone.|Also marks the point on the mini-map for allies. The mark is in the player's color and lasts as long as the channeling does.|Provides 200 range flying vision at the destination point while channeling. The vision lingers for 1 second.|Upon teleport, trees within 200 radius are destroyed.|Dispels the buff from Ghost Scepter and Ethereal Blade upon cast.|The recent teleport check also counts canceled teleports.|Shares the cooldown with Boots of Travel icon.png Boots of Travel." '
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
      Return "Teleports you to a target friendly building."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Teleport"
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                 thecaster As idisplayunit, _
                                 thetarget As idisplayunit, _
                                 ftarget As idisplayunit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim pointtargetselfinfo = Helpers.GetPointTargetSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim tp As New modValue(1, eModifierType.Teleport, occurencetime)

    Dim tpmod As New Modifier(tp, pointtargetselfinfo)

    outmods.Add(tpmod)
    Return outmods
  End Function
End Class
