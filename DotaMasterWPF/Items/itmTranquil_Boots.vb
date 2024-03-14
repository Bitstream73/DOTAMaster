Public Class itmTranquil_Boots
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmTRANQUIL_BOOTS
    Me.EntityName = eEntity.itmTRANQUIL_BOOTS

    mDisplayName = "Tranquil Boots"
    'mDescription = "While they increase the longevity of the wearer, this boot is not particularly reliable."

    mGoldCost = New ValueWrapper(975)
    mMadeFromItems.Add(eItemname.itmBOOTS_OF_SPEED)
    mMadeFromItems.Add(eItemname.itmRING_OF_PROTECTION)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/tranquil_boots_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(13)
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Passive: Break - Whenever you attack or are attacked, the health regeneration and 30 Movement Speed are lost for 13 seconds."
    Notes = "Reduces Tranquil Boots stats to +60 movement speed, 0 health regeneration and +4 Armor.|Breaks upon successfully landing an attack on an enemy, or when an enemy successfully lands an attack on you.|This means when your or an enemy's attack evasion misses or is disjointed, the boots will not break.|The actual damage from the attack does not matter.|When triggered, the item's icon changes and is set on a 13 second cooldown. However, this has only informative purposes.|This means that refreshing it (Refresher Orb, Rearm) does not skip the broken state." '
    ColorText = "While they increase the longevity of the wearer, this boot is not particularly reliable."

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


    Dim movespeedval As New modValue(90, eModifierType.MoveSpeedAdded, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)



    Dim armorval As New modValue(4, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)



    Dim hpregenval As New modValue(12, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Whenever you attack or get attacked you lose the HP regeneration and 30 Movement Speed for 13 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Break"
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

    Dim autocastselfinfo = Helpers.GetAutoCastSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                     "Occurs when attacking or being attacked", eModifierCategory.Active)

    Dim movespeedval As New modValue(30, eModifierType.MoveSpeedSubtracted, occurencetime)

    Dim movespeed As New Modifier(movespeedval, autocastselfinfo)

    outmods.Add(movespeed)


    Dim hpregenval As New modValue(-12, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, autocastselfinfo)

    outmods.Add(hpregen)

    Return outmods
  End Function
End Class
