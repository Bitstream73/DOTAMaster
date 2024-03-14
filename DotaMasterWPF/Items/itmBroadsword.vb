Public Class itmBroadsword
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBROADSWORD
    Me.EntityName = eEntity.itmBROADSWORD

    mDisplayName = "Broadsword"
    ' mDescription = "The classic weapon of choice for knights, this blade is sturdy and reliable for slaying enemies. "
    mGoldCost = New ValueWrapper(1200)

    mBuildsToNames.Add(eItemname.itmBLADE_MAIL)
    mBuildsToNames.Add(eItemname.itmBATTLE_FURY)
    mBuildsToNames.Add(eItemname.itmCRYSTALYS)


    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/broadsword_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    Description = ""
    Notes = "" '
    ColorText = "The classic weapon of choice for knights, this blade is sturdy and reliable for slaying enemies."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                                   owner As iDisplayUnit, _
                                                   target As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         owner, _
                                                                         target, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(18, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim dammod As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(dammod)

    Return outmods
  End Function
End Class
