Public Class itmDesolator
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDESOLATOR
    Me.EntityName = eEntity.itmDESOLATOR

    mDisplayName = "Desolator"
    'mDescription = "A wicked weapon, used in torturing political criminals.|Passive: Corruption - Your attacks reduce target's armor for 15 seconds.|Desolator is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. "
    mGoldCost = New ValueWrapper(4100)
    mMadeFromItems.Add(eItemname.itmRECIPE_DESOLATOR)
    mMadeFromItems.Add(eItemname.itmMITHRIL_HAMMER)
    mMadeFromItems.Add(eItemname.itmMITHRIL_HAMMER)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/desolator_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(15)
    'mManaCost = 

    Description = "Passive: Corruption - Your attacks reduce target's armor for 15 seconds.|Desolator is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. "
    Notes = "Successive attacks with Desolator do not stack the debuff, but refresh the duration instead.|The target's armor is reduced before the attack damage is dealt, but still relies on the attack not to miss.|Works against every unit, including wards, buildings and allied units." '
    ColorText = "A wicked weapon, used in torturing political criminals. "

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(60, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim armorval As New modValue(7, eModifierType.ArmorSubtracted, occurencetime)

    Dim armordrain As New Modifier(armorval, unittargetenemytargetinfo)

    outmods.Add(armordrain)

    Return outmods
  End Function
End Class
