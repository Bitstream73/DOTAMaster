Public Class itmOblivion_Staff
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmOBLIVION_STAFF
    Me.EntityName = eEntity.itmOBLIVION_STAFF

    mDisplayName = "Oblivion Staff"
    ' mDescription = "Deceptively hidden as an ordinary quarterstaff, it is actually very powerful, much like the Eldritch who originally possessed it. "
    mGoldCost = New ValueWrapper(1675)

    mMadeFromItems.Add(eItemname.itmQUARTERSTAFF)
    mMadeFromItems.Add(eItemname.itmSAGES_MASK)
    mMadeFromItems.Add(eItemname.itmROBE_OF_THE_MAGI)

    mBuildsToNames.Add(eItemname.itmORCHID_MALEVOLENCE)
    mBuildsToNames.Add(eItemname.itmREFRESHER_ORB)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/oblivion_staff_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = ""
    Notes = "" '
    ColorText = "Deceptively hidden as an ordinary quarterstaff, it is actually very powerful, much like the Eldritch who originally possessed it."
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

    Dim intval As New modValue(6, eModifierType.IntAdded, occurencetime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim attspeedval As New modValue(10, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)


    Dim manaregenval As New modValue(0.75, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)


    Dim damval As New modValue(15, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damageadded As New Modifier(damval, passiveselfinfo)

    outmods.Add(damageadded)


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
