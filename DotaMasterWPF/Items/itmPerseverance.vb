Public Class itmPerseverance
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPERSEVERANCE
    Me.EntityName = eEntity.itmPERSEVERANCE

    mDisplayName = "Perseverance"
    'mDescription = "A gem that grants heart to the bearer. "
    mGoldCost = New ValueWrapper(1750)
    mMadeFromItems.Add(eItemname.itmRING_OF_HEALTH)
    mMadeFromItems.Add(eItemname.itmVOID_STONE)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)

    mBuildsToNames.Add(eItemname.itmREFRESHER_ORB)
    mBuildsToNames.Add(eItemname.itmBLOODSTONE)
    mBuildsToNames.Add(eItemname.itmLINKENS_SPHERE)
    mBuildsToNames.Add(eItemname.itmBATTLE_FURY)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/pers_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = ""
    Notes = "" '
    ColorText = "A gem that grants heart to the bearer."
  End Sub

  Public Sub TransmuteEnemy( theenemy As eUnit)
    'may have to do this at somepoint
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

    Dim hpregenval As New modValue(5, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)


    Dim manaregenval As New modValue(1.25, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)


    Dim damval As New modValue(10, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damageadded As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damageadded)

    Return outmods
  End Function
End Class
