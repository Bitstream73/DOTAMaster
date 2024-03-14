Public Class itmDust_Of_Appearance
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDUST_OF_APPEARANCE
    Me.EntityName = eEntity.itmDUST_OF_APPEARANCE

    mDisplayName = "Dust of Appearance"
    Description = ""
    mGoldCost = New ValueWrapper(180)
    ManaCost = New ValueWrapper(5)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/dust_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = True
    mIsCourier = False
    'Ability
    Cooldown = New ValueWrapper(60)
    Radius = New ValueWrapper(1050)


    Description = "Use: Reveal - Reveals and slows invisible Heroes in a nearby area. "
    Notes = "Interrupts the user's channeling spells upon using.|Places a debuff on enemies (including not invisible ones) within the radius upon cast. Leaving or entering the area afterwards has no effect.|Can place the debuff on invulnerable units, but not on hidden units or on wards.|Only slows units when they actually are invisible." '
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
      Return "Reveals and slows invisible Heroes in a nearby area."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Reveal"
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


    Dim outmods As New ModifierList()

    Dim pointtargetenemyteaminfo = Helpers.GetPointTargetEnemyTeamInfo(theitem_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim visval As New modValue(1, eModifierType.StealthVisibility, occurencetime)

    Dim vismod As New Modifier(visval, pointtargetenemyteaminfo)

    outmods.Add(vismod)


    Dim slowattackval As New modValue(0.85, eModifierType.AttackSpeedPercentAdded, occurencetime)

    Dim slowattackmod As New Modifier(slowattackval, pointtargetenemyteaminfo)

    outmods.Add(slowattackmod)

    Dim slowmoveval As New modValue(0.85, eModifierType.MoveSpeedPercent, occurencetime)

    Dim slowspeedmod As New Modifier(slowmoveval, pointtargetenemyteaminfo)

    outmods.Add(slowspeedmod)

    Return outmods
  End Function


End Class
