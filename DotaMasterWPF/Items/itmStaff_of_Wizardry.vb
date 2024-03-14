Public Class itmStaff_of_Wizardry
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSTAFF_OF_WIZARDRY
    Me.EntityName = eEntity.itmSTAFF_OF_WIZARDRY

    mDisplayName = "Staff of Wizardry"
    'mDescription = "A staff of magical powers passed down from the eldest mages."
    mGoldCost = New ValueWrapper(1000)

    mBuildsToNames.Add(eItemname.itmEULS_SCEPTER_OF_DIVINITY)
    mBuildsToNames.Add(eItemname.itmFORCE_STAFF)
    mBuildsToNames.Add(eItemname.itmDAGON_1)
    mBuildsToNames.Add(eItemname.itmNECRONOMICON_1)
    mBuildsToNames.Add(eItemname.itmAGHANIMS_SCEPTER)
    mBuildsToNames.Add(eItemname.itmROD_OF_ATOS)


    mCategory = eItemCategory.ATTRIBUTES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/staff_of_wizardry_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False

    Description = ""
    Notes = "" '
    ColorText = "A staff of magical powers passed down from the eldest mages. "

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

    Dim intval As New modValue(10, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)

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
