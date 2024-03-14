Public Class itmArcane_Boots
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmARCANE_BOOTS
    Me.EntityName = eEntity.itmARCANE_BOOTS

    mDisplayName = "Arcane Boots"
    'mDescription = "Magi equipped with these boots are valued in battle.|Flat movement speed bonuses from multiple pairs of boots do not stack. "
    mGoldCost = New ValueWrapper(1450)

    mMadeFromItems.Add(eItemname.itmBOOTS_OF_SPEED)
    mMadeFromItems.Add(eItemname.itmENERGY_BOOSTER)


    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/arcane_boots_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False

    'ability
    Cooldown = New ValueWrapper(55)

    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(35)

    Description = "Active: Replenish Mana - Restores mana in an area around the hero.|Flat movement speed bonuses from multiple pairs of boots do not stack. "
    Notes = "Interupts the user's channeling spells upon cast.|Effectively restores 100 mana on the caster.Affects every allied unit, including illusions invulnerable units, excluding wards and buildings.|Meepo clones can not cast Replenish Mana." '
    ColorText = "Magi equipped with these boots are valued in battle."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinfo As New modInfo(eAbilityType.Passive, _
                                       theitem_InfoID, _
                                       theownerid, _
                                       Nothing,
                                       eUnit.untSelf, _
                                       "", eModifierCategory.Passive)

    Dim movespeedval As New modValue(55, eModifierType.MoveSpeedAdded, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)

    Dim manaaddval As New modValue(250, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(manaaddval, passiveselfinfo)

    outmods.Add(mana)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Restores mana in an area around the hero."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Replenish Mana"
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

    'Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
    '                                                 thecaster, _
    '                                                 thetarget, _
    '                                                 "", eModifierCategory.Active)

    Dim manaaddval As New modValue(135, eModifierType.ManaAdded, occurencetime)

    '  Dim manaself As New Modifier(manaaddval, passiveselfinfo)

    ' outmods.Add(manaself)


    Dim passiveauraalliedheroesinfo = Helpers.GetPassiveAuraAlliedHeroesInfo(theitem_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim manaalliedheroes As New Modifier(manaaddval, passiveauraalliedheroesinfo)


    outmods.Add(manaalliedheroes)

    Return outmods
  End Function
End Class
