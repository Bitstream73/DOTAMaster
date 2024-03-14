Public Class itmCrystalys
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmCRYSTALYS
    Me.EntityName = eEntity.itmCRYSTALYS

    mDisplayName = "Crystalys"
    'mDescription = "A blade forged from rare crystals, it seeks weak points in enemy armor."
    mGoldCost = New ValueWrapper(2150)
    mMadeFromItems.Add(eItemname.itmRECIPE_CRYSTALYS)
    mMadeFromItems.Add(eItemname.itmBROADSWORD)
    mMadeFromItems.Add(eItemname.itmBLADES_OF_ATTACK)

    mBuildsToNames.Add(eItemname.itmDAEDALUS)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/lesser_crit_lg.png"
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
    Description = "Passive: Critical Strike - Grants a chance to deal critical damage on an attack."
    Notes = "Makes use of pseudo-random distribution.|Increases attack damage by an average of +15%.|The proc chance of multiple crit sources stack, the damage multiplicator do not." '
    ColorText = "A blade forged from rare crystals, it seeks weak points in enemy armor."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                                    owner As iDisplayUnit, _
                                                    target As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     owner, _
                                                     target, _
                                                     "", eModifierCategory.Passive)




    Dim critdamval As New modValue(1.75, eModifierType.CritMultiplier, occurencetime)
    critdamval.mPercentChance = New ValueWrapper(0.2)
    Dim CritDamage As New Modifier(critdamval, passiveselfinfo)

    outmods.Add(CritDamage)


    Dim damval As New modValue(30, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, passiveselfinfo)

    outmods.Add(damage)

    Return outmods
  End Function
End Class
