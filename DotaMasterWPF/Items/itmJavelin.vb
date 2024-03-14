Public Class itmJavelin
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmJAVELIN
    Me.EntityName = eEntity.itmJAVELIN

    mDisplayName = "Javelin"
    'mDescription = "A rather typical spear that can sometimes pierce through an enemy's armor when used to attack. "
    mGoldCost = New ValueWrapper(1500)

    mBuildsToNames.Add(eItemname.itmMONKEY_KING_BAR)
    mBuildsToNames.Add(eItemname.itmSKULL_BASHER)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/javelin_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 

    Description = "Passive: Pierce - Grants a chance to deal bonus damage. "
    Notes = "Pierce from multiple Javelin work fully independent from each other.|This means that two of them can proc on the same attack and both deal their damage.|The owner can lifesteal off the damage dealt by Pierce. However, it can not crit or cleave.|The damage can be reduced by e.g. Enfeeble or Static Link.|However it can not be amplified by e.g. Empower or the Double Damage rune.|Adds an average of 8 damage to every attack (29 damage if the item's 21 damage increase is counted as well)." '
    ColorText = "A rather typical spear that can sometimes pierce through an enemy's armor when used to attack."

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

    Dim damval As New modValue(21, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim passiveenemytargetinfo = Helpers.GetPassiveEnemyTargetInfo(theitem_InfoID, _
                                                                   theownerid, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Passive)

    Dim pierceval As New modValue(4, eModifierType.DamagePhysicalAdded, occurencetime)
    pierceval.mPercentChance = New ValueWrapper(0.2)

    Dim piercedamage As New Modifier(pierceval, passiveenemytargetinfo)

    outmods.Add(piercedamage)


    'Dim piercechance As New Modifier(0.2, eModifierType.DamagePierceChancePercent, eAbilityType.Passive, "Pierce Chance", mParentorBuildName, eUnit.untEnemyTarget, _
    '                                 mName, eSourceType.Item, Me, -1, "")
    'outmods.Add(piercechance)

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
