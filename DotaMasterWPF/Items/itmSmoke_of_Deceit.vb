Public Class itmSmoke_of_Deceit
  Inherits ItemBase



  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSMOKE_OF_DECEIT
    Me.EntityName = eEntity.itmSMOKE_OF_DECEIT

    mDisplayName = "Smoke of Deceit"
    'mDescription = ""
    mGoldCost = New ValueWrapper(100)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/smoke_of_deceit_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False
    'Ability
    Cooldown = New ValueWrapper(90)
    Charges = New ValueWrapper(1)

    Description = "Use: Upon activation, the user and all nearby allied player-controlled units gain invisiblity and bonus movement speed for a brief time. Minimap icons will also be hidden. Upon moving within 1025 range of an enemy hero or tower, the invisibility is lost. "
    Notes = "Interrupts the user's channeling spells upon using.|Affected unit can cast spells and use items while invisible without breaking it. However, attacking does break it.|When attacking, the invisibility is lost upon reaching the attack point, even when the attack misses.|Invisible units can pick up and drop items without breaking the invisibility.|True Sight can not detect units affected by Smoke of Deceit. The only exception is Chronosphere.|Only affects player controlled units. Does not affect invulnerable allies, however, invulnerable enemy heroes or towers dispel it.|The effect is only dispelled when approaching an enemy hero (excluding illusions)or a tower." '
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
      Return " Upon activation, the user and all nearby allied player-controlled units gain invisiblity and bonus movement speed for a brief time. Minimap icons will also be hidden. Upon moving within 1025 range of an enemy hero or tower, the invisibility is lost. "
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Use"
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

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theitem_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)

    Dim speedval As New modValue(0.15, eModifierType.MoveSpeedPercent, occurencetime)

    Dim speedmodself As New Modifier(speedval, pointtargetself)

    outmods.Add(speedmodself)

    Dim invisval As New modValue(0, eModifierType.Invisibility, occurencetime)
    invisval.mValueDuration = New ValueWrapper(35) 'New TimeSpan(0, 0, 35)

    Dim invismodself As New Modifier(invisval, pointtargetself)

    outmods.Add(invismodself)


    Dim pointtargetallies = Helpers.GetPointTargetAlliedUnitsInfo(theitem_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim speedmodallies As New Modifier(speedval, pointtargetallies)

    outmods.Add(speedmodallies)


    Dim invismodallies As New Modifier(invisval, pointtargetallies)

    outmods.Add(invismodallies)

    Return outmods
  End Function
End Class
