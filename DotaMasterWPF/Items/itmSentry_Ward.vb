Public Class itmSentry_Ward
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSENTRY_WARD
    Me.EntityName = eEntity.itmSENTRY_WARD

    mDisplayName = "Sentry Ward"
    ' mDescription = " Places a Sentry Ward to give True Sight of the surrounding area. Lasts 4 minutes. Hold Control to give one Sentry Ward to an allied hero. "
    mGoldCost = New ValueWrapper(200)
    ManaCost = New ValueWrapper(0)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ward_sentry_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    Charges = New ValueWrapper(2)
    Radius = New ValueWrapper(800)

    Description = "Use: Places a Sentry Ward to give True Sight of the surrounding area.|Hold Control to give one Sentry Ward to an allied hero. "
    Notes = "Provides 150 radius ground vision at its location for 12 seconds.|Can not be placed on the elevated area, including the ramp at the fountains or in Roshan's pit.|Sentry Wards are fully sharable. However, holding Control allows the owner to give an ally just one ward, instead of the whole stack.|It is not possible to give couriers or Lone Druid's Spirit Bear a Sentry Ward by holding Control.|The True Sight is provided in its whole area, it is not obstructed by anything.|The True Sight is provided by an aura, its effect lingers for 0.5 seconds.|Can not detect units under the effect of Shadow Dance icon.png Shadow Dance and Smoke of Deceit." '
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

    Dim durationval As New modValue(240, eModifierType.Vision, occurencetime)
    durationval.mValueDuration = New ValueWrapper(240) 'New TimeSpan(0, 4, 0)

    Dim vismod As New Modifier(durationval, passiveauraenemystealthinfo)

    outmods.Add(vismod)

    Return outmods
  End Function
End Class
