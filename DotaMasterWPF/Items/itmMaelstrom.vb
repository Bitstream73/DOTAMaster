Public Class itmMaelstrom
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMAELSTROM
    Me.EntityName = eEntity.itmMAELSTROM

    mDisplayName = "Maelstrom"
    'mDescription = "A hammer forged for the gods themselves, Maelstrom allows its user to harness the power of lightning.|Passive: Chain Lightning - Grants a chance on attack to release a Chain Lightning that hits 4 targets, dealing damage.|Maelstrom is a Unique Attack Modifier that stacks with other Unique Attack Modifiers, but overrides them when Chain Lightning occurs."
    mGoldCost = New ValueWrapper(2700)
    mMadeFromItems.Add(eItemname.itmRECIPE_MAELSTROM)
    mMadeFromItems.Add(eItemname.itmGLOVES_OF_HASTE)
    mMadeFromItems.Add(eItemname.itmMJOLLNIR)

    mBuildsToNames.Add(eItemname.itmMJOLLNIR)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/maelstrom_lg.png"
    mTier = 0
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

    Description = "Passive: Chain Lightning - Grants a chance on attack to release a Chain Lightning that hits 4 targets, dealing damage.|Maelstrom is a Unique Attack Modifier that stacks with other Unique Attack Modifiers, but overrides them when Chain Lightning occurs. "
    Notes = "Each Maelstrom in the inventory has an independent chance to proc. If more than 2 proc on one attack, only one chain lightning is released.|The same applies to Maelstrom and Mjollnir in the same inventory. When both proc on the same hit, Mjollnir has priority.|The lightning bounces in 0.25 second intervals, so hitting 4 targets takes 0.75 seconds.|Does not bounce on invisible units or units in the Fog of War.|Can never hit the same unit twice per proc.|All bounces together can deal up to 480 damage (before reductions)." '
    ColorText = "A hammer forged for the gods themselves, Maelstrom allows its user to harness the power of lightning."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(24, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim attspeeval As New modValue(25, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeeval, unittargetenemytargetinfo)

    outmods.Add(attackspeed)


    Dim passiveauraenemyunitsinfo = Helpers.GetPassiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    'Dim chainchance As New Modifier(0.25, eModifierType.ChainLightningChance, eAbilityType.Passive, "Chain Lightning Chance", mParentorBuildName, eUnit.untSelf, _
    '                               mName, eSourceType.Item, Me, -1, "")
    'outmods.Add(chainchance)

    Dim chaindamval As New modValue(120, eModifierType.ChainLightning, occurencetime)
    chaindamval.mPercentChance = New ValueWrapper(0.25)
    Dim chaindamage As New Modifier(chaindamval, passiveauraenemyunitsinfo)
    outmods.Add(chaindamage)

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
