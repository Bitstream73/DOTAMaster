Public Class itmBuckler
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBUCKLER
    Me.EntityName = eEntity.itmBUCKLER

    mDisplayName = "Buckler"
    'mDescription = "A powerful shield that imbues the bearer with the strength of heroes past, it is capable of protecting entire armies in battle."
    mGoldCost = New ValueWrapper(800)
    mMadeFromItems.Add(eItemname.itmRECIPE_BUCKLER)
    mMadeFromItems.Add(eItemname.itmCHAINMAIL)
    mMadeFromItems.Add(eItemname.itmIRON_BRANCH)

    mBuildsToNames.Add(eItemname.itmMEKANSM)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/buckler_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(25)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(10)
    Description = "Active: Armor Bonus - Gives +2 to all nearby allied units. Lasts 25 seconds on heroes, 30 seconds on units."
    Notes = "Interupts the user's channeling spells upon cast.|Guard bonus armor does not stack with the armor gained from Mekansm and Crimson Guard active abilities.|Does not affect wards, buildings and invulnerable units." '
    ColorText = "A powerful shield that imbues the bearer with the strength of heroes past, it is capable of protecting entire armies in battle."

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

    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)

    Dim strval As New modValue(2, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)
    outmods.Add(strmod)

    Dim intval As New modValue(2, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(2, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Gives +2 to all nearby allied units. Lasts 25 seconds on heroes, 30 seconds on units."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Armor Bonus"
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

    Dim activeauraalliesinfo = Helpers.GetActiveAuraAlliedHeroesInfo(theitem_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)


    Dim armorval As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armorauraalliedheroes As New Modifier(armorval, activeauraalliesinfo)

    outmods.Add(armorauraalliedheroes)

    Dim activeauraselfinfo = Helpers.GetActiveAuraSelfInfo(theitem_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim armorauraself As New Modifier(armorval, activeauraselfinfo)

    outmods.Add(armorauraself)

    Return outmods
  End Function
End Class
