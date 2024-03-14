Public Class itmGhostScepter
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmGHOST_SCEPTER
    Me.EntityName = eEntity.itmGHOST_SCEPTER

    mDisplayName = "Ghost Scepter"
    'mDescription = "Imbues the wielder with a ghostly presence, allowing them to evade physical damage. |Ends if you are magic immune, and will have no effect if you are already magic immune.|Shares cooldown with Ethereal Blade."
    mGoldCost = New ValueWrapper(1600)

    mBuildsToNames.Add(eItemname.itmETHEREAL_BLADE)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ghost_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    'mRadius = 
    'mCharges =

    Description = "Active: Ghost Form - Enter ghost form and become unable to attack or be attacked, but take 40% extra magic damage. Using a Teleport Scroll dispels Ghost Form."
    Notes = "Interupts the user's channeling spells upon cast.|Reduces most heroes' total magic resistance to 6.25% if an ally, or -12.5% if an enemy, (assuming basic 25% magic resistance).|Reduces Meepo's total magic resistance to 9% and Visage's total magic resistance to -26%.|Does stack with magic amplification or movement speed slows of other sources, except with other ethereal effects.|Gets dispelled when the user starts channeling a Town Portal Scroll, but not when starting channeling Boots of Travel.|Dispels Ensnare on the target for its duration.|Shares cooldown with Ethereal Blade." '
    ColorText = "Imbues the wielder with a ghostly presence, allowing them to evade physical damage."

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

    Dim strval As New modValue(7, eModifierType.StrAdded, occurencetime)

    Dim str As New Modifier(strval, passiveselfinfo)

    outmods.Add(str)


    Dim intval As New modValue(7, eModifierType.IntAdded, occurencetime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim agival As New modValue(7, eModifierType.AgiAdded, occurencetime)

    Dim agi As New Modifier(agival, passiveselfinfo)

    outmods.Add(agi)



    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Enter ghost form and become unable to attack or be attacked, but take 40% extra magic damage. Using a Teleport Scroll dispels Ghost Form."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Ghost Form"
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



    Dim outmods As New ModifierList

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim tm As New ValueWrapper(4)
    Dim ghoastval As New modValue(tm, eModifierType.Ghost_Form_Time, occurencetime, aghstime)
    ghoastval.mValueDuration = tm 'New ValueWrapper(4) 'New TimeSpan(0, 0, 4)

    Dim ghostform As New Modifier(ghoastval, notargetselfinfo)

    outmods.Add(ghostform)

    Dim magicdamval As New modValue(1.4, eModifierType.MagicDamageReceivedMultiplier, occurencetime)

    Dim magicresist As New Modifier(magicdamval, notargetselfinfo)

    outmods.Add(magicresist)

    Return outmods
  End Function
End Class
