Public Class itmFlyingCourier
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmFLYING_COURIER
    Me.EntityName = eEntity.itmFLYING_COURIER

    mDisplayName = "Flying Courier"
    'mDescription = "Fast flying creature that carries items to and from your base. Requires Animal Courier. "
    mGoldCost = New ValueWrapper(220)
    ManaCost = New ValueWrapper(0)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/flying_courier_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = True
    Charges = New ValueWrapper(1)

    Description = "Fast flying creature that carries items to and from your base. Requires Animal Courier."
    Notes = "Buying this item automatically upgrades the Animal Courier into a flying courier.|The Flying Courier is not a valid target for most spells. A list of spells which affect the courier can be find below.|The Flying Courier takes 50% more damage from melee attacks than from ranged attacks.|When the Flying Courier dies, every allied player of the killing unit gains 175 gold.|It is possible to have multiple Flying Couriers. When killing a courier, the killer always gets the bounty, while his team only gets it when no other enemy courier is dead at the time.|The Flying Courier is invulnerable when near its team Fountain.|The Flying Courier's Spell Immunity and Phase buffs are both purgeable by purges which can target spell immune units." '
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
