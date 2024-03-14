Public Class itmBlinkDagger
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBLINK_DAGGER
    Me.EntityName = eEntity.itmBLINK_DAGGER

    mDisplayName = "Blink Dagger"
    'mDescription = "The fabled dagger used by the fastest assassin ever to walk the lands. Quick-casting will cause you to teleport towards your fountain"
    mGoldCost = New ValueWrapper(2150)
    'mMadeFrom.Add()
    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/blink_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(12)
    'mRadius = 
    'mCharges =
    Description = "Active: Blink - Teleport to a target point up to 1200 units away. If damage is taken, Blink Dagger cannot be used for 3 seconds."
    Notes = "Double clicking the item automatically casts it on your team's fountain, blinking towards its direction.|Does not blink for the full distance when targeting closer than its max distance.|When targeting beyond the max blink distance, it blinks for 960 range towards the targeted direction, instead of 1200.|Disjoints projectile upon cast.|Cannot be cast while ensnared or entangled.|Damage greater than 0 (after reductions) coming from any player (including allies and self) and Roshan puts the dagger on a 3 second cooldown.|Since it is a 3 second cooldown and not actually disabled, it can be refreshed with Refresher Orb and Rearm." '
    ColorText = "The fabled dagger used by the fastest assassin ever to walk the lands."
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
      Return "Teleport to a target point up to 1200 units away. If damage is taken from an enemy hero, Blink Dagger cannot be used for 3 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Blink"
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

    Dim pointtargetselfinfo = Helpers.GetPointTargetSelfInfo(theitem_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)

    Dim tp As New Modifier(tpval, pointtargetselfinfo)

    outmods.Add(tp)

    Return outmods
  End Function
End Class
