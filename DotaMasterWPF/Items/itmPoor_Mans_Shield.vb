Public Class itmPoor_Mans_Shield
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPOOR_MANS_SHIELD
    Me.EntityName = eEntity.itmPOOR_MANS_SHIELD

    mDisplayName = "Poor Man's Shield"
    Description = "A busted old shield that seems to block more than it should. Multiple sources of damage block don't stack."
    mGoldCost = New ValueWrapper(550)
    mMadeFromItems.Add(eItemname.itmSLIPPERS_OF_AGILITY)
    mMadeFromItems.Add(eItemname.itmSLIPPERS_OF_AGILITY)
    mMadeFromItems.Add(eItemname.itmSTOUT_SHIELD)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/poor_mans_shield_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =

    Description = "Passive: Damage Block - Blocks physical attack damage based on whether the equipped hero is ranged or melee. Poor Man's Shield will always block attacks from enemy Heroes, but has a chance to block damage from creeps."
    Notes = "For a list of physical damage from spells which isn't blocked, see here.|Does not work against wards (Plague Ward, Mass Serpent Ward, Death Ward).|For more details, see Damage Block." '
    ColorText = "A busted old shield that seems to block more than it should."
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

    Dim meleeval As New modValue(20, eModifierType.DamageMeleeBlockAdded, occurencetime)
    meleeval.mPercentChance = New ValueWrapper(0.6)

    Dim meleeblock As New Modifier(meleeval, passiveselfinfo)

    outmods.Add(meleeblock)


    Dim rangeval As New modValue(10, eModifierType.DamageRangeBlockAdded, occurencetime)
    rangeval.mPercentChance = New ValueWrapper(0.6)

    Dim rangeblock As New Modifier(rangeval, passiveselfinfo)

    outmods.Add(rangeblock)




    Dim agival As New modValue(6, eModifierType.AgiAdded, occurencetime)

    Dim agi As New Modifier(agival, passiveselfinfo)

    outmods.Add(agi)

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
