Public Class itmButterfly
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBUTTERFLY
    Me.EntityName = eEntity.itmBUTTERFLY

    mDisplayName = "Butterfly"
    'mDescription = "Only the mightiest and most experienced of warriors can wield the Butterfly, but it provides incredible dexterity in combat. "
    mGoldCost = New ValueWrapper(6000)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAGON_1)


    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/butterfly_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManaCost = 
    Description = "Active: Flutter - Trade evasion for 20% additional movement speed for 8.0 seconds.|Stacks diminishingly with other sources of Evasion."
    Notes = "Interupts the owner's channeling spells upon cast.|Only evasion granted by all Butterflies in the inventory is lost for the duration. Other sources of evasion still work." '
    ColorText = "Only the mightiest and most experienced of warriors can wield the Butterfly, but it provides incredible dexterity in combat."

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

    Dim agivalue As New modValue(30, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agivalue, passiveselfinfo)

    outmods.Add(agimod)



    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim damval As New modValue(30, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Dim evasionvalue As New modValue(0.35, eModifierType.EvasionPercent, occurencetime)

    Dim evasion As New Modifier(evasionvalue, passiveselfinfo)

    outmods.Add(evasion)


    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)

    Return outmods
  End Function
End Class
