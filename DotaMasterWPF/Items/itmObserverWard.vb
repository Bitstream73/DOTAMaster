Public Class itmObserverWard
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmOBSERVER_WARD
    Me.EntityName = eEntity.itmOBSERVER_WARD

    mDisplayName = "Observer Ward"
    'mDescription = "Places an Observer Ward to give sight of the surrounding area. Lasts 7 minutes. Hold Control to give one Observer Ward to an allied hero. "
    mGoldCost = New ValueWrapper(150)
    ManaCost = New ValueWrapper(0)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ward_observer_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False
    Charges = New ValueWrapper(2)
    Radius = New ValueWrapper(1600)

    Description = "Use: Places an Observer Ward to give sight of the surrounding area. Lasts 7 minutes.|Hold Control to give one Observer Ward to an allied hero. "
    Notes = "" '
    ColorText = ""

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveauraenemyinfo = Helpers.GetPassiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                                    theownerid, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Passive)

    Dim visval As New modValue(1600, eModifierType.Vision, occurencetime)
    visval.mValueDuration = New ValueWrapper(420) 'New TimeSpan(0, 7, 0)

    Dim vismod As New Modifier(visval, passiveauraenemyinfo)

    outmods.Add(vismod)

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
