Public Class itmBlades_of_Attack
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBLADES_OF_ATTACK
    Me.EntityName = eEntity.itmBLADES_OF_ATTACK

    mDisplayName = "Blades of Attack"
    ' mDescription = "The damage of these small, concealable blades should not be underestimated. "
    mGoldCost = New ValueWrapper(450)

    mBuildsToNames.Add(eItemname.itmPHASE_BOOTS)
    mBuildsToNames.Add(eItemname.itmCRYSTALYS)
    mBuildsToNames.Add(eItemname.itmARMLET_OF_MORDIGGIAN)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/blades_of_attack_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 

    Description = ""
    Notes = "" '
    ColorText = "The damage of these small, concealable blades should not be underestimated. "
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


    Dim damval As New modValue(9, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim dammod As New Modifier(damval, passiveselfinfo)

    outmods.Add(dammod)

    Return outmods

  End Function
End Class
