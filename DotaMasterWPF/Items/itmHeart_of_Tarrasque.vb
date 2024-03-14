Public Class itmHeart_of_Tarrasque
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHEART_OF_TARRASQUE
    Me.EntityName = eEntity.itmHEART_OF_TARRASQUE

    mDisplayName = "Heart of Tarrasque"
    ' mDescription = "Preserved heart of an extinct monster, it bolsters the bearer's fortitude.|Passive: Health Regeneration - Restores a percentage of max health per second.|This ability is disabled if damage is taken from an enemy Hero or Roshan within the last 4 seconds if your hero is melee or 6 seconds if your hero is ranged. This ability is disabled if damage is taken from an enemy Hero or Roshan within the last 4 seconds if your hero is melee or 6 seconds if your hero is ranged.This ability is disabled if damage is taken from an enemy Hero or Roshan within the last 4 seconds if your hero is melee or 6 seconds if your hero is ranged."
    mGoldCost = New ValueWrapper(5500)
    mMadeFromItems.Add(eItemname.itmRECIPE_HEART_OF_TARRASQUE)
    mMadeFromItems.Add(eItemname.itmREAVER)
    mMadeFromItems.Add(eItemname.itmVITALITY_BOOSTER)



    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/heart_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(6)
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManaCost = 

    Description = "Passive: Health Regeneration - Restores a percentage of max health per second. |This ability is disabled if damage is taken from an enemy Hero or Roshan within the last 4 seconds if your hero is melee or 6 seconds if your hero is ranged. "
    Notes = "Health Regeneration from multiple Heart of Tarrasuqes do not stack.|Heals in form of health regeneration, so it heals for 0.02% of maximum health in 0.01 second intervals.|Can fully heal the owner in 50 seconds.|Damage greater than 0 (after reductions) coming from any player (including allies, excluding self) and Roshan puts the regeneration on a 4 second (6 for ranged heroes) cooldown.|Since it is a cooldown and not actually disabled, it can be refreshed with Refresher Orb and Rearm." '
    ColorText = "Preserved heart of an extinct monster, it bolsters the bearer's fortitude."

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

    Dim strval As New modValue(40, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim hpval As New modValue(300, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(hpval, passiveselfinfo)

    outmods.Add(health)


    Dim regval As New modValue(0.02, eModifierType.HPRegenPercent, occurencetime)

    Dim healthregen As New Modifier(regval, passiveselfinfo)

    outmods.Add(healthregen)

    Return outmods
  End Function
End Class
