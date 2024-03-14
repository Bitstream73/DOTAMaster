Public Class itmHood_of_Defiance
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHOOD_OF_DEFIANCE
    Me.EntityName = eEntity.itmHOOD_OF_DEFIANCE

    mDisplayName = "Hood of Defiance"
    ' mDescription = "A furred, magic resistant headpiece that is feared by wizards. "
    mGoldCost = New ValueWrapper(2125)
    mMadeFromItems.Add(eItemname.itmRING_OF_HEALTH)
    mMadeFromItems.Add(eItemname.itmCLOAK)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)

    mBuildsToNames.Add(eItemname.itmPIPE_OF_INSIGHT)

    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/hood_of_defiance_lg.png"
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

    Description = ""
    Notes = "" '
    ColorText = "A furred, magic resistant headpiece that is feared by wizards. "

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

    Dim regenval As New modValue(5, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(regenval, passiveselfinfo)

    outmods.Add(hpregen)


    Dim magicresistval As New modValue(0.3, eModifierType.MagicResistancePercentAdded, occurencetime)

    Dim spellresist As New Modifier(magicresistval, passiveselfinfo)

    outmods.Add(spellresist)

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
