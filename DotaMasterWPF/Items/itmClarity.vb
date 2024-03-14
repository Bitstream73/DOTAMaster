Public Class itmClarity
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmCLARITY
    Me.EntityName = eEntity.itmCLARITY

    mDisplayName = "Clarity" ' PageHandler.dbItems.GetFriendlyName(mName)
    'mDescription = "Clear water that enhances the ability to meditate."
    mGoldCost = New ValueWrapper(50)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/clarity_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False

    Duration = New ValueWrapper(36)
    Description = "Passive: Break - Whenever you attack or are attacked, the health regeneration and 30 Movement Speed are lost for 13 seconds. "
    Notes = "Double clicking the item uses it on self.|Successive casts on the same target do not stack, but refresh the duration instead.|Restores mana in form of mana regeneration, so it restores 0.0375 mana in 0.01 second intervals, which is 3.75 mana per second.|Is dispelled by any damage greater than 20 (before reductions), including self afflicted damage.|Is not dispelled by health cost of spells, health manipulating spells, negative regeneration, Poison Sting and Dispersion.|Is always dispelled by attacks, even when the attack dealt no damage.|Fully stacks with other mana regeneration increasing effects." '
    ColorText = "Clear water that enhances the ability to meditate. "
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
      Return "Restores mana on the target unit over time. If the unit is attacked, the effect is lost."
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

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "", eModifierCategory.Active)

    Dim MoTval As New modValue(3.75, eModifierType.ManaoT, New ValueWrapper(1), occurencetime)
    MoTval.mValueDuration = Me.Duration '135 health over 36 seconds

    Dim manamod As New Modifier(MoTval, notargetselfinfo)

    outmods.Add(manamod)
    Return outmods
  End Function
End Class
