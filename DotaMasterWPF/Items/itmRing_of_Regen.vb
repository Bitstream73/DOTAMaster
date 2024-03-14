Public Class itmRing_of_Regen
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRING_OF_REGEN
    Me.EntityName = eEntity.itmRING_OF_REGEN

    mDisplayName = "Ring of Regen"
    'mDescription = "This ring is considered a good luck charm among the Gnomes. "
    mGoldCost = New ValueWrapper(350)

    mBuildsToNames.Add(eItemname.itmVLADMIRS_OFFERING)
    mBuildsToNames.Add(eItemname.itmHEADDRESS)
    mBuildsToNames.Add(eItemname.itmFORCE_STAFF)
    mBuildsToNames.Add(eItemname.itmTRANQUIL_BOOTS)
    mBuildsToNames.Add(eItemname.itmHOOD_OF_DEFIANCE)
    mBuildsToNames.Add(eItemname.itmSOUL_RING)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ring_of_regen_lg.png"
    mTier = 0
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
    ColorText = "This ring is considered a good luck charm among the Gnomes."
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

    Dim hpregenval As New modValue(2, eModifierType.HPRegenAdded, occurencetime)

    Dim regenmod As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(regenmod)

    Return outmods
  End Function
  Public Overrides Property AbilityDescription As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                 thecaster As iDisplayUnit, _
                                thetarget As iDisplayUnit, _
                                 ftarget As iDisplayUnit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function

End Class
