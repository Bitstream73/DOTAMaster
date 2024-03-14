Public Class itmRod_of_Atos
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmROD_OF_ATOS

    Me.EntityName = eEntity.itmROD_OF_ATOS

    mDisplayName = "Rod of Atos"
    Description = "Atos, the Lord of Blight, has his essence stored in this deceptively simple wand. "
    mGoldCost = New ValueWrapper(3100)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmVITALITY_BOOSTER)

    mCategory = eItemCategory.CASTER
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/rod_of_atos_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(10)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(4)
    ManaCost = New ValueWrapper(50)

    Description = "Active: Cripple - Slows the target's movement speed."
    Notes = "Successive casts on the same target do not stack, but refresh the duration instead.|Can not target siege creeps, buildings and wards." '
    ColorText = "Atos, the Lord of Blight, has his essence stored in this deceptively simple wand."

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

    Dim intval As New modValue(2, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)

    Dim hpaddval As New modValue(350, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(hpaddval, passiveselfinfo)

    outmods.Add(health)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Slows the target's movement speed. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Cripple"
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

    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim cripval As New modValue(0.6, eModifierType.MoveSpeedPercentSubtracted, occurencetime)

    Dim crippleslow As New Modifier(cripval, unittargetenemytargetinfo)

    outmods.Add(crippleslow)

    Return outmods
  End Function
End Class
