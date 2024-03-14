Public Class itmMorbid_Mask
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMORBID_MASK
    Me.EntityName = eEntity.itmMORBID_MASK

    mDisplayName = "Morbid mask"
    'mDescription = "A mask that drains the energy of those caught in its gaze. |Passive: Lifesteal - Gives lifesteal on attacks. |Morbid Mask is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."
    mGoldCost = New ValueWrapper(900)
    'mMadeFrom.Add()

    mBuildsToNames.Add(eItemname.itmVLADMIRS_OFFERING)
    mBuildsToNames.Add(eItemname.itmHELM_OF_THE_DOMINATOR)
    mBuildsToNames.Add(eItemname.itmMASK_OF_MADNESS)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/lifesteal_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = "Passive: Lifesteal - Gives lifesteal on attacks.|Morbid Mask is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. "
    Notes = "The lifesteal stacks additively with other sources of lifesteal which are not Unique Attack Modifier.|Cannot lifesteal off of wards, buildings and allied units. Can lifesteal off of siege creeps." '
    ColorText = "A mask that drains the energy of those caught in its gaze. "

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetselfinfo = Helpers.GetPassiveEnemyTargetInfo(theitem_InfoID, _
                                                               theownerid, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim lifeval As New modValue(0.015, eModifierType.LifeStealPercent, occurencetime)

    Dim lifesteal As New Modifier(lifeval, unittargetselfinfo)

    outmods.Add(lifesteal)

    Return outmods
  End Function
End Class
