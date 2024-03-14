Public Class itmDaedalus
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDAEDALUS
    Me.EntityName = eEntity.itmDAEDALUS

    mDisplayName = "Daedalus"
    'mDescription = "A weapon of incredible power that is difficult for even the strongest of warriors to control. "
    mGoldCost = New ValueWrapper(5550)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAEDALUS)
    mMadeFromItems.Add(eItemname.itmCRYSTALYS)
    mMadeFromItems.Add(eItemname.itmDEMON_EDGE)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/greater_crit_lg.png"
    mTier = 3
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
    Description = "Passive: Critical Strike - Grants a chance to deal critical damage on an attack."
    Notes = "Makes use of pseudo-random distribution.|Increases attack damage by an average of +35%.|The proc chance of multiple crit sources stack, the damage multiplicator do not." '
    ColorText = "A weapon of incredible power that is difficult for even the strongest of warriors to control."
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

    Dim damval As New modValue(30, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Dim critmultval As New modValue(2.4, eModifierType.CritMultiplier, occurencetime)
    Dim critmulti As New Modifier(critmultval, unittargetenemytargetinfo)
    outmods.Add(critmulti)

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim critchanceval As New modValue(0.25, eModifierType.CritChance, occurencetime)

    Dim critchance As New Modifier(critchanceval, passiveselfinfo)

    outmods.Add(critchance)

    Return outmods
  End Function
End Class
