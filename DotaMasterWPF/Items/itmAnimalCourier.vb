Public Class itmAnimalCourier
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmANIMAL_COURIER
    Me.EntityName = eEntity.itmANIMAL_COURIER

    mDisplayName = "Animal Courier"

    mGoldCost = New ValueWrapper(150)
    ManaCost = New ValueWrapper(0)
    'mMadeFrom.Add()
    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/courier_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = True

    Charges = New ValueWrapper(1)

    Description = "Creature that carries items to and from your base. "
    Notes = "Interupts the user's channeling spells upon cast.|The Animal Courier is not a valid target for most spells. A list of spells which affect the courier can be found below.|When the Animal Courier dies, every allied player of the killing unit gains 150 gold.|It is possible to have multiple Animal Couriers. When killing a courier, the killer always gets the bounty, while his team only gets it when no other enemy courier is dead at the time.|The Animal Courier is invulnerable when near its team Fountain.|The Animal Courier's Spell Immunity and Phase buffs are both purgeable by purges which can target spell immune units." '
    ColorText = "Losing the donkey is punishable by death. "
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function
End Class
