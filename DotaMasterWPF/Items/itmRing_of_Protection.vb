Public Class itmRing_of_Protection
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRING_OF_PROTECTION
    Me.EntityName = eEntity.itmRING_OF_PROTECTION

    mDisplayName = "Ring of Protection"
    ' mDescription = "A glimmering ring that defends its bearer. "
    mGoldCost = New ValueWrapper(175)

    mBuildsToNames.Add(eItemname.itmRING_OF_BASILIUS)
    mBuildsToNames.Add(eItemname.itmTRANQUIL_BOOTS)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ring_of_protection_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    Description = ""
    Notes = "" '
    ColorText = "A glimmering ring that defends its bearer. "
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

    Dim armorval As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armod As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armod)

    Return outmods
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
