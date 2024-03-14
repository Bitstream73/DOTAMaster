Public Class itmTango
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmTANGO
    Me.EntityName = eEntity.itmTANGO

    mDisplayName = "Tango" 'PageHandler.dbItems.GetFriendlyName(mName)
    'mDescription = e to survive on the battlefield. "
    mGoldCost = New ValueWrapper(125)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/tango_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False
    'Ability
    Cooldown = New ValueWrapper(0)
    Charges = New ValueWrapper(3)

    Description = "Use: Eat Tree - Consume a tree to restore health over time.|Use on an allied hero to give them one Tango."
    Notes = "Successive uses with the same unit do not stack, but refresh the duration instead.|Restores health in form of health regeneration, so it heals for 0.071875 health in 0.01 second intervals, which is 7.1875 health per second.|The targeted tree is instantly destroyed upon cast.|One set of Tango can heal for up to 460 health." '
    ColorText = "Forage to survive on the battlefield. "

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
      Return "Consume a tree to restore HP over time. Comes with 3 charges."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Eat Tree"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                 thecaster As idisplayunit, _
                                thetarget As iDisplayUnit, _
                                 ftarget As idisplayunit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim unittargetselfinfo = Helpers.GetUnitTreeSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim healval As New modValue(115, eModifierType.HPoT, occurencetime)
    healval.mValueInterval = New ValueWrapper(16) 'New TimeSpan(0, 0, 16)
    healval.Charges = Charges
    Dim healthmod As New Modifier(healval, unittargetselfinfo)
    outmods.Add(healthmod)
    Return outmods
  End Function
End Class
