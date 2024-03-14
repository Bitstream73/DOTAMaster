Public Class itmStout_Shield
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSTOUT_SHIELD
    Me.EntityName = eEntity.itmSTOUT_SHIELD

    mDisplayName = "Stout Shield"
    'mDescription = "One man's wine barrel bottom is another man's shield. Passive: Damage Block - Gives a chance to block damage, depending on the type of hero you are."
    mGoldCost = New ValueWrapper(250)

    mBuildsToNames.Add(eItemname.itmPOOR_MANS_SHIELD)
    mBuildsToNames.Add(eItemname.itmMANTA_STYLE)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/stout_shield_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    '   mCooldown = 
    'mRadius = 

    Description = "Passive: Damage Block - Gives a chance to block damage based on whether the equipped hero is melee or ranged. "
    Notes = "For a list of physical damage from spells which isn't blocked, see here.|Does not work against wards (Plague Ward, Mass Serpent Ward, Death Ward)." '
    ColorText = "One man's wine barrel bottom is another man's shield. "

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

    Dim blockval As New modValue(20, eModifierType.DamageMeleeBlockAdded, occurencetime)
    blockval.mPercentChance = New ValueWrapper(0.6)
    Dim mblock As New Modifier(blockval, passiveselfinfo)

    outmods.Add(mblock)


    Dim blockval2 As New modValue(10, eModifierType.DamageRangeBlockAdded, occurencetime)
    blockval2.mPercentChance = blockval.mPercentChance
    Dim rblock As New Modifier(blockval2, passiveselfinfo)

    outmods.Add(rblock)



    'Dim bchance As New Modifier(0.6, eModifierType.DamageBlockChance, eAbilityType.Passive, "Block Chance", mParentorBuildName, eUnit.untSelf, _
    '                            mName, eSourceType.Item, Me, -1, "")
    'outmods.Add(bchance)

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
