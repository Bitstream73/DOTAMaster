Public Class itmScythe_of_Vyse
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSCYTHE_OF_VYSE
    Me.EntityName = eEntity.itmSCYTHE_OF_VYSE

    mDisplayName = "Scythe of Vyse"
    'mDescription = "The most guarded relic among the cult of Vyse, it is the most coveted weapon among magi. "
    mGoldCost = New ValueWrapper(5675)
    mMadeFromItems.Add(eItemname.itmMYSTIC_STAFF)
    mMadeFromItems.Add(eItemname.itmULTIMATE_ORB)
    mMadeFromItems.Add(eItemname.itmVOID_STONE)

    mCategory = eItemCategory.CASTER
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/sheepstick_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(35)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(100)

    Description = "Active: Hex - Turns a target unit into a harmless critter for 3.5 seconds. Destroys illusions."
    Notes = "Applies a Hex on the target, so it is muted and has certain passive skills (e.g. Evasion, Damage Block) disabled.|Unlike other hexes, Scythe of Vyse's hex sets the target's base movement speed to 140.|Since it only changes the base movement speed and doesn't slow in that sense, all speed increasing effects apply.|A unit hexed with a Scythe of Vyse with Boots of Speed has 190 move speed.|Hex instantly destroys illusions, but not summoned units.|Scythe of Vyse hex transforms the target into a Play pig." '
    ColorText = "The most guarded relic among the cult of Vyse, it is the most coveted weapon among magi."

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

    Dim strval As New modValue(10, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim agival As New modValue(10, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim intval As New modValue(35, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim manaval As New modValue(1.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaval, passiveselfinfo)

    outmods.Add(manaregen)


    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "The most guarded relic among the cult of Vyse, it is the most coveted weapon among magi. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Hex"
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

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)
    Dim hexval As New modValue(3.5, eModifierType.Hex, occurencetime)
    hexval.mValueDuration = New ValueWrapper(3.5) 'New TimeSpan(3500)
    Dim hex As New Modifier(hexval, unittargetenemytargetinfo)
    outmods.Add(hex)

    Return outmods
  End Function
End Class
