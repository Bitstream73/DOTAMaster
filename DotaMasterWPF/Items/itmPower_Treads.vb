Public Class itmPower_Treads
  Inherits ItemBase


  'Public stateimageurls As List(Of String)

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPOWER_TREADS
    Me.EntityName = eEntity.itmPOWER_TREADS

    mDisplayName = "Power Treads"
    'mDescription = "A pair of tough-skinned boots that change to meet the demands of the wearer.|Flat movement speed bonuses from multiple pairs of boots do not stack."
    mGoldCost = New ValueWrapper(1400)
    mMadeFromItems.Add(eItemname.itmGLOVES_OF_HASTE)
    mMadeFromItems.Add(eItemname.itmBOOTS_OF_SPEED)
    mMadeFromItems.Add(eItemname.itmBELT_OF_STRENGTH)

    mCategory = eItemCategory.COMMON
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/power_treads_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    mStateImageURLs = New List(Of String)
    mStateImageURLs.Add("http://hydra-media.cursecdn.com/dota2.gamepedia.com/8/8a/Power_Treads_%28Strength%29_icon.png?version=ea27621cba3a96d160a849aa61ef865d")
    mStateImageURLs.Add("http://hydra-media.cursecdn.com/dota2.gamepedia.com/d/d5/Power_Treads_%28Intelligence%29_icon.png?version=58381c468e90125b501e5837292449b9")
    mStateImageURLs.Add("http://hydra-media.cursecdn.com/dota2.gamepedia.com/9/95/Power_Treads_%28Agility%29_icon.png?version=40084c548db02c93b9a9a287f25b31a2")
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = "Active: Switch Attribute - Changes selected attribute between Strength, Agility and Intelligence.|Power Treads can be built using a Belt of Strength, Band of Elvenskin, or a Robe of the Magi. Flat movement speed bonuses from multiple pairs of boots do not stack, nor does the attack speed bonus from multiple Power Treads. "
    Notes = "Interupts the user's channeling spells upon cast.|Switches from Strength to Intelligence, Intelligence to Agility, and Agility to Strength." '
    ColorText = "A pair of tough-skinned boots that change to meet the demands of the wearer."

    mStates = New List(Of String)
    mStates.Add("Str")
    mStates.Add("Int")
    mStates.Add("Agi")
  End Sub


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    owner As idisplayunit, _
                                                    target As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList
    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     owner, _
                                                     target, _
                                                     "", eModifierCategory.Passive)

    Dim movespeedval As New modValue(50, eModifierType.MoveSpeedAdded, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)


    Dim attspeedval As New modValue(50, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)


    Select Case thestateindex
      Case 0
        'strength State
        Dim strval As New modValue(8, eModifierType.StrAdded, occurencetime, 0)
        strval.mStateIndex = 0

        Dim str As New Modifier(strval, passiveselfinfo)

        outmods.Add(str)

      Case 1
        ' Intelligence State
        Dim intval As New modValue(8, eModifierType.IntAdded, occurencetime, 1)
        intval.mStateIndex = 1

        Dim int As New Modifier(intval, passiveselfinfo)

        outmods.Add(int)

      Case 2
        'Agility state
        Dim agival As New modValue(8, eModifierType.AgiAdded, occurencetime, 2)
        agival.mStateIndex = 2

        Dim agi As New Modifier(agival, passiveselfinfo)

        outmods.Add(agi)

      Case Else
        PageHandler.theLog.writelog("itmPower_Treads.getpassivemods passed index: " & thestateindex.ToString)
    End Select





    Return outmods
  End Function




  Public Overrides Property AbilityDescription As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return ""
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
    Return New ModifierList
  End Function


End Class
