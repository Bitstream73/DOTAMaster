Public Class itmBottle
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBOTTLE
    Me.EntityName = eEntity.itmBOTTLE


    mDisplayName = "Bottle"
    ' mDescription = "An old bottle that survived the ages, the contents placed inside become enchanted."
    mGoldCost = New ValueWrapper(650)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/bottle_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(0)
    'mRadius = 
    Charges = New ValueWrapper(3)
    Description = "Use: Regenerate - Restores HP and Mana over time. Effect is lost if unit is attacked. Empty Bottle refills near town fountain. You can also store runes in the bottle, to save for later use. After 2 minutes, stored Runes will be activated automatically. If Bottle does not have full charges and is placed on a courier, the courier will move 30% slower.|Hold Control to use your Bottle on an allied hero. "
    Notes = "Interupts the user's channeling spells upon cast.|Can only be used when the Bottle has currently no Rune stored. Can be cast with no charges left, putting it on Cooldown, but having no other effect.|Successive casts on the same target do not stack, but refresh the duration instead.|When casting without the Control key, it always casts on self in one click. When holding the Control key, a target has to be selected.|Can only target heroes (including illusions), Lone Druid's Spirit Bear, Warlock's Golem, Visage's Familiars and the Primal Split spirits.|However, only heroes and illusions get the regenerate buff. When targeting the other listed units, it will target self instead.|The Spirit Bear and couriers can cast Regenerate, but it only puts it on cooldown without any other effects. It neither regenerates the target, nor wastes a charge.|Unlike most other single targeted abilities, The owner does not have to face the target to give it a Bottle charge.|Restores health and mana in form of regeneration, so it restores 0.45 health and 0.23 mana in 0.1 second intervals, which is 45 health and 23.33 mana per second.|The effect is dispelled by any damage greater than 20 (before reductions), including self afflicted damage.|Is not dispelled by health cost of spells, health manipulating spells, negative regeneration, Poison Sting and Dispersion.|Is always dispelled by attacks, even when the attack dealt no damage.|Fully stacks with other health and mana regeneration increasing effects.|A Rune can be stored into the Bottle by making a right-click on the rune.|The Bottle does not need to be empty for this. It is possible to store runes while having 1/2/3 charges left, wasting the remaining charges.|Only heroes and Lone Druid's Spirit Bear can store Runes. Illusions and couriers can't.|Only one Rune can be stored in a Bottle at a time. Attempting to store another Rune into it will just directly use new targeted Rune.|However, it is possible to have multiple Bottles in the inventory and store a Rune with each of them.|While having a Rune stored, the Regenerate ability cannot be used.|The stored Rune can be activated at any time by using the Bottle. Activating the Rune will fully refill the Bottle with 3 charges.|A Bottle with a Rune stored cannot be dropped from the inventory." '
    ColorText = "An old bottle that survived the ages, the contents placed inside become enchanted. "
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                     theowner As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Restores HP and Mana over time. Effect is lost if unit is attacked. Empty Bottle refills near town fountain. You can also store runes in the bottle, to save for later use. After 2 minutes, stored Runes will be activated. If Bottle is empty, it causes a courier to move 30% slower. Hold Control to use your Bottle on an allied hero. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Regenerate"
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

    Dim outmods As New ModifierList

    Dim affected As New List(Of eUnit)

    affected.Add(eUnit.untAlliedHero)
    affected.Add(eUnit.untSelf)


    Dim unittargetmultiaffects = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active, _
                                                                       affected)

    Dim healval As New modValue(135, eModifierType.HealAdded, occurencetime)
    healval.Charges = Charges
    Dim healmod1 As New Modifier(healval, unittargetmultiaffects)

    outmods.Add(healmod1)




    Dim manaval As New modValue(70, eModifierType.ManaRestored, occurencetime)

    Dim manamod1 As New Modifier(manaval, unittargetmultiaffects)

    outmods.Add(manamod1)





    Return outmods
  End Function
End Class
