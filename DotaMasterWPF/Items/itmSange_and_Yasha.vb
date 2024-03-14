Public Class itmSange_and_Yasha
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSANGE_AND_YASHA
    Me.EntityName = eEntity.itmSANGE_AND_YASHA

    mDisplayName = "Sange and Yasha"
    'mDescription = "Sange and Yasha, when attuned by the moonlight and used together, become a very powerful combination.|Passive: Greater Maim - Gives a chance on attack to slow movement speed for 5.0 seconds.|Yasha-based movement speed bonuses from multiple items do not stack."
    mGoldCost = New ValueWrapper(4100)
    mMadeFromItems.Add(eItemname.itmSANGE)
    mMadeFromItems.Add(eItemname.itmYASHA)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/sange_and_yasha_lg.png"
    mTier = 3
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(5)
    'mManaCost = 

    Description = "Passive: Greater Maim - Gives a chance on attack to slow movement speed for 5.0 seconds.|Yasha-based movement speed bonuses from multiple items do not stack. "
    Notes = "Successive procs on the same target do not stack, but refresh the duration instead.|The proc chance of Greater Maim from multiple Sange and Yasha work fully independent from each other.|Fully stacks with the Lesser Maim from Heaven's Halberd and from Sange, including the slow.|Does not work against Lone Druid's Spirit Bear, wards and buildings. Works against allied units." '
    ColorText = "Sange and Yasha, when attuned by the moonlight and used together, become a very powerful combination. "

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


    'Dim maimchance As New Modifier(0.16, eModifierType.MaimChance, eAbilityType.Passive, "Greater Maim Chance", mParentorBuildName, eUnit.untSelf, _
    '                                  mName, eSourceType.Item, Me, -1, "")
    'outmods.Add(maimchance)



    Dim moveslowval As New modValue(0.32, eModifierType.MoveSpeedPercentSubtracted, occurencetime)
    moveslowval.mPercentChance = New ValueWrapper(0.16)

    Dim Moveslow As New Modifier(moveslowval, unittargetenemytargetinfo)

    outmods.Add(Moveslow)

    Dim attspeedval As New modValue(0.32, eModifierType.AttackSpeedPercentSubtracted, occurencetime)
    attspeedval.mPercentChance = New ValueWrapper(0.16)

    Dim attackspeed As New Modifier(attspeedval, unittargetenemytargetinfo)

    outmods.Add(attackspeed)

    Dim damval As New modValue(16, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim strval As New modValue(16, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, unittargetenemytargetinfo)

    outmods.Add(strmod)


    Dim agival As New modValue(16, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, unittargetenemytargetinfo)

    outmods.Add(agimod)


    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim attspeedval2 As New modValue(16, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed2 As New Modifier(attspeedval2, passiveselfinfo)

    outmods.Add(attackspeed2)


    Dim movespeedval As New modValue(0.16, eModifierType.MoveSpeedPercent, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)

    Return outmods
  End Function
End Class
