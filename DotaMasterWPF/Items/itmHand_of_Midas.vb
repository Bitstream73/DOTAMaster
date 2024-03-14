Public Class itmHand_of_Midas
  Inherits ItemBase



  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHAND_OF_MIDAS
    Me.EntityName = eEntity.itmHAND_OF_MIDAS

    mDisplayName = "Hand of Midas"
    Description = "Preserved through unknown magical means, the Hand of Midas is a weapon of greed, sacrificing animals to line the owner's pockets. "
    mGoldCost = New ValueWrapper(2050)
    mMadeFromItems.Add(eItemname.itmRECIPE_HAND_OF_MIDAS)
    mMadeFromItems.Add(eItemname.itmGLOVES_OF_HASTE)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/hand_of_midas_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(100)
    'mRadius = 
    'mCharges =

    Description = "Active: Transmute - Kills a non-hero target for 190 gold and 2.5x experience. Cannot be used on Ancient Creeps."
    Notes = "The user does not get the default experience and gold bounty of the targeted unit.|It only gains 2.5× times the target's default experience and a set 190 gold as reliable gold.|Despite the visual effects, the gold and experience are granted instantly.|Deals damage equal to the target's current health to kill it. This damage fully ignores any form of reduction or amplification.|Can not be cast on couriers, wards, buildings, ancient creeps, Roshan, Spirit Bears, Warlock's golems, Familiars, Primal Split spirits and Necronomicon summons.|Assuming it is always used when off cooldown, it increases the user's GPM by 114." '
    ColorText = "Preserved through unknown magical means, the Hand of Midas is a weapon of greed, sacrificing animals to line the owner's pockets."

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


    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Kills a non-hero target for 190 gold and 2.5x experience. Cannot be used on Ancients. "
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Transmute"
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


    'may need to work this at some point
    Return Nothing
  End Function
End Class
