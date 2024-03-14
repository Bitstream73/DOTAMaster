Public Class itmCheese
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmCHEESE
    Me.EntityName = eEntity.itmCHEESE

    mDisplayName = "Cheese"
    Description = "Made from the milk of a long lost Furbolg vendor, it restores the vitality of those who taste it."
    mGoldCost = New ValueWrapper(0)

    mCategory = eItemCategory.SPECIAL
    mSoldFrom.Add(eShopTypes.Roshan)
    'mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/5/51/Cheese_icon.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False
    'ability
    ' mCooldown = 60
    'mRadius = 
    Charges = New ValueWrapper(1)
    'mDuration = 1.4
    'mManaCost = 150
    Description = ""
    Notes = "Does not overheal." '
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
      Return "Instantly restores 2500 hp and 1000 mana to the user."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Restore"
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
    Dim manaval As New modValue(1000, eModifierType.ManaRestored, occurencetime)

    Dim mana As New Modifier(manaval, notargetselfinfo)

    outmods.Add(mana)


    Dim healval As New modValue(2500, eModifierType.HealAdded, occurencetime)

    Dim health As New Modifier(healval, notargetselfinfo)

    outmods.Add(health)

    Return outmods
  End Function
End Class
