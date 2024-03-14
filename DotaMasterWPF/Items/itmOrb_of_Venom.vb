Public Class itmOrb_of_Venom
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmORB_OF_VENOM
    Me.EntityName = eEntity.itmORB_OF_VENOM

    mDisplayName = "Orb of Venom"
    'mDescription = "Envenoms your veapon with the venom of a venomous viper.|Passive: Poison Attack - Poisons the target, dealing damage over time and slowing, depending on whether your hero is melee or ranged.|Orb of Venom is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. Orb of Venom can be combined with Lifesteal Attack Modifiers."
    mGoldCost = New ValueWrapper(275)

    mBuildsToNames.Add(eItemname.itmEYE_OF_SKADI)

    mCategory = eItemCategory.SECRET
    mSoldFrom.Add(eShopTypes.Secret)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/orb_of_venom_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(4)
    'mManaCost = 

    Description = "Passive: Poison Attack - Poisons the target, dealing damage over time and slowing, depending on whether your hero is melee or ranged.|Orb of Venom is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. Orb of Venom can be combined with Lifesteal Attack Modifiers. "
    Notes = "When a melee and a ranged hero with Orb of Venoms attack one target, the slow of the first applied debuff is used and refreshed.|The damage over time is not lethal. It can not drop the affected unit's health below 1.|Deals damage in 1 second intervals, starting 1 second after the debuff is applied, resulting in 4 instances.|Can deal up to 12 damage (before reductions).|Does not work against wards and buildings. Works against siege creeps." '
    ColorText = "Envenoms your veapon with the venom of a venomous viper."

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

    Dim meleeval As New modValue(0.12, eModifierType.MeleeSlow, occurencetime)

    Dim meleeslow As New Modifier(meleeval, unittargetenemytargetinfo)

    outmods.Add(meleeslow)


    Dim rangeval As New modValue(0.04, eModifierType.RangeSlow, occurencetime)

    Dim rangeslow As New Modifier(rangeval, unittargetenemytargetinfo)

    outmods.Add(rangeslow)


    Dim poisonval As New modValue(3, eModifierType.PoisonAttack, occurencetime)

    Dim poisondamage As New Modifier(poisonval, unittargetenemytargetinfo)

    outmods.Add(poisondamage)

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
