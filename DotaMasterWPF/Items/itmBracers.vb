Public Class itmBracers
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBRACER
    Me.EntityName = eEntity.itmBRACER

    mDisplayName = "Bracer"
    ' mDescription = "The bracer is a common choice to toughen up defenses and increase longevity. "
    mGoldCost = New ValueWrapper(525)
    mMadeFromItems.Add(eItemname.itmRECIPE_BRACER)
    mMadeFromItems.Add(eItemname.itmCIRCLET)
    mMadeFromItems.Add(eItemname.itmGAUNTLETS_OF_STRENGTH)

    mCategory = eItemCategory.COMMON

    mBuildsToNames.Add(eItemname.itmDRUM_OF_ENDURANCE)

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/bracer_lg.png"
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
    ColorText = "The bracer is a common choice to toughen up defenses and increase longevity."
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


    Dim strval As New modValue(6, eModifierType.StrAdded, occurencetime)

    Dim str As New Modifier(strval, passiveselfinfo)

    outmods.Add(str)


    Dim agival As New modValue(3, eModifierType.AgiAdded, occurencetime)

    Dim agi As New Modifier(agival, passiveselfinfo)

    outmods.Add(agi)


    Dim intval As New modValue(3, eModifierType.IntAdded, occurencetime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(3, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim dam As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(dam)


    Return outmods
  End Function
End Class
