Public Class itmBattle_Fury
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBATTLE_FURY
    Me.EntityName = eEntity.itmBATTLE_FURY

    mDisplayName = "Battle Fury"
    'mDescription = "The bearer of this mighty axe gains the ability to cut down swaths of enemies at once. "
    mGoldCost = New ValueWrapper(4350)
    mMadeFromItems.Add(eItemname.itmBROADSWORD)
    mMadeFromItems.Add(eItemname.itmCLAYMORE)
    mMadeFromItems.Add(eItemname.itmPERSEVERANCE)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/bfury_lg.png"
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
    Description = "Passive: Cleave - Deals a percent of attack damage in a 350 area around the target. Ranged units cannot Cleave."
    Notes = "Cleave damage is reduced by armor type but not by armor value.|The cleave damages a circular area in front of the owner.|As with all cleave, Battle Fury stacks with other Battle Furies, Empower and cleave abilities of other heroes.|When stacking multiple cleaves, each source of cleave deals its own damage instance.|Does not cleave upon attacking wards, buildings or allied units. Wards and buildings are unaffected by cleave.|Despite the visual effect, damage is applied instantly in the whole area.|Ranged units cannot cleave." '
    ColorText = "The bearer of this mighty axe gains the ability to cut down swaths of enemies at once."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passiveenemytarget = Helpers.GetPassiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                                  theownerid, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)


    Dim damval As New modValue(65, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, passiveenemytarget)

    outmods.Add(damage)


    Dim cleaveval As New modValue(0.35, eModifierType.CleavePercentage, occurencetime)

    Dim cleavedamagetarget As New Modifier(cleaveval, passiveenemytarget)

    outmods.Add(cleavedamagetarget)


    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                                  theownerid, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)

    Dim hpregenval As New modValue(6, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)



    Dim manaregenval As New modValue(1.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)


    Dim passiveauraenemytargetinfo = Helpers.GetPassiveAuraEnemyTargetInfo(theitem_InfoID, _
                                                                  theownerid, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)


    Dim cleavedamageaoe As New Modifier(cleaveval, passiveauraenemytargetinfo)

    outmods.Add(cleavedamageaoe)

    Return outmods
  End Function
End Class
