Public Class itmVanguard
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmVANGUARD
    Me.EntityName = eEntity.itmVANGUARD

    mDisplayName = "Vanguard"
    'mDescription = "A powerful shield that defends its wielder from even the most vicious of attacks. "
    mGoldCost = New ValueWrapper(2225)
    mMadeFromItems.Add(eItemname.itmRING_OF_HEALTH)
    mMadeFromItems.Add(eItemname.itmVITALITY_BOOSTER)
    mMadeFromItems.Add(eItemname.itmSTOUT_SHIELD)

    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/vanguard_lg.png"
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

    Description = "Passive: Damage Block - Gives the wielder a chance to block damage from each incoming attack based on whether the equipped hero is melee or ranged."
    Notes = "For a list of physical damage from spells which isn't blocked, see here.|Does not work against wards (Plague Ward, Mass Serpent Ward, Death Ward)." '
    ColorText = "A powerful shield that defends its wielder from even the most vicious of attacks."

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

    Dim hpaddval As New modValue(250, eModifierType.HPAdded, occurencetime)

    Dim hpadded As New Modifier(hpaddval, passiveselfinfo)

    outmods.Add(hpadded)



    Dim rangeval As New modValue(20, eModifierType.DamageRangeBlockAdded, occurencetime)
    rangeval.mPercentChance = New ValueWrapper(0.8)

    Dim rangeblock As New Modifier(rangeval, passiveselfinfo)

    outmods.Add(rangeblock)


    Dim meleeval As New modValue(40, eModifierType.DamageRangeBlockAdded, occurencetime)
    meleeval.mPercentChance = rangeval.mPercentChance

    Dim meleeblock As New Modifier(meleeval, passiveselfinfo)

    outmods.Add(meleeblock)

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
