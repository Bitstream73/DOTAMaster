Public Class itmBoots_of_Travel
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBOOTS_OF_TRAVEL
    Me.EntityName = eEntity.itmBOOTS_OF_TRAVEL

    mDisplayName = "Boots of Travel"
    Description = "Winged boots that grant omnipresence. Flat movement speed bonuses from multiple pairs of boots do not stack. "
    mGoldCost = New ValueWrapper(2450)
    mMadeFromItems.Add(eItemname.itmRECIPE_BOOTS_OF_TRAVEL)
    mMadeFromItems.Add(eItemname.itmBOOTS_OF_SPEED)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/travel_boots_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(60)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(75)

    Description = "Active: Teleport - Teleports you to an allied non-hero unit or structure.|Flat movement speed bonuses from multiple pairs of boots do not stack. "
    Notes = "Double clicking the item automatically targets your team's fountain.|When targeting the ground, it automatically targets the closest valid teleport target to the targeted point. Prioritizes buildings within 325 radius.|Can target any allied unit, except for wards, heroes and illusions. Can target them even when invulnerable (e.g. Astral Spirit).|During the channeling, the teleport destination is marked with a visual effect in the same color as the player and a sound is played. Both are visible and audible to everyone.|Also marks the point on the mini-map for allies. The mark is in the player's color and lasts as long as the channeling does.|Provides 200 range flying vision at the destination point while channeling. The vision lingers for 1 second.|Does not destroy trees upon teleporting, making it possible to get stuck between trees.|Unlike with Town Portal Scroll, it does not dispel the buff from Ghost Scepter or Ethereal Blade upon cast.|Shares the cooldown with Town Portal Scroll." '
    ColorText = "Winged boots that grant omnipresence."
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

    Dim speedval As New modValue(100, eModifierType.MoveSpeedAdded, occurencetime)

    Dim speedmod As New Modifier(speedval, passiveselfinfo)

    outmods.Add(speedmod)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Teleports you to an allied non-hero unit or structure"
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

    Dim unittargetselfinfo = Helpers.GetPointTargetSelfInfo(theitem_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)

    Dim tpmod As New Modifier(tpval, unittargetselfinfo)

    outmods.Add(tpmod)

    Return outmods
  End Function
End Class
