Public Class itmHelm_of_Iron_Will
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHELM_OF_IRON_WILL
    Me.EntityName = eEntity.itmEULS_SCEPTER_OF_DIVINITY

    mDisplayName = "Helm of Iron Will"
    ' mDescription = "The helmet of a legendary warrior who fell in battle. "
    mGoldCost = New ValueWrapper(950)

    mBuildsToNames.Add(eItemname.itmARMLET_OF_MORDIGGIAN)
    mBuildsToNames.Add(eItemname.itmHELM_OF_THE_DOMINATOR)
    mBuildsToNames.Add(eItemname.itmVEIL_OF_DISCORD)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/helm_of_iron_will_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    '    mCooldown = 
    'mRadius = 


    Description = ""
    Notes = "" '
    ColorText = "The helmet of a legendary warrior who fell in battle. "

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

    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armod As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armod)


    Dim hpregenval As New modValue(3, eModifierType.HPRegenAdded, occurencetime)

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
