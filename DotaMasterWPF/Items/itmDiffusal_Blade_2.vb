Public Class itmDiffusal_Blade_2
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDIFFUSAL_BLADE_2
    Me.EntityName = eEntity.itmDIFFUSAL_BLADE

    mDisplayName = "Diffusal Blade (1)"
    'mDescription = "An enchanted blade that allows the user to cut straight into the enemy's soul.|Passive: Feedback - Your attacks burn 20/36 mana and deal the same amount in physical damage. Upgradable.|Diffusal Blade is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers. "
    mGoldCost = New ValueWrapper(4150)
   
    mMadeFromItems.Add(eItemname.itmBLADE_OF_ALACRITY)
    mMadeFromItems.Add(eItemname.itmBLADE_OF_ALACRITY)
    mMadeFromItems.Add(eItemname.itmROBE_OF_THE_MAGI)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/diffusal_blade_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(8)
    'mRadius = 
    Charges = New ValueWrapper(8)
    'mDuration =
    'mManaCost = 

    Description = "Active: Purge - Purges a target unit, removing its buffs, and slowing it. Instantly kills summoned units.|Passive: Manabreak - Your attacks burn 25 mana and deal the same amount in physical damage. Does not stack with other manabreak abilities."
    Notes = "Double clicking the item casts it on self.|Applies a normal dispel on the target upon cast.|Does not slow or damage allied targets.|Can be cast on invulnerable units.|The slow deceases in 0.8 second intervals, so it slows for 100%/80%/60%/40%/20%, going one step down every 0.8 seconds.|When cast on non-hero units, it ensnares the target for the initial 3 seconds, fully preventing it from moving.|The slow still applies to them. So after the ensnare, they are slowed for the remaining second like heroes.|Treats Roshan, ancient creeps, Lone Druid's Spirit Bear, Visage's Familiars and the Primal Split spirits as heroes.|Instantly kills summoned target (except for Spirit Bears, Familiars and Primal Split spirits) by dealing their current health as damage to them.|The damage is directly added to the owner's attack damage.|The owner can lifesteal off the damage dealt by the manabreak. However, it cannot crit or cleave.|The damage can be reduced by e.g. Enfeeble or Static Link.|However it cannot be amplified by e.g. Empower or the Double Damage rune.|Applies the mana loss first, and then the damage." '
    ColorText = "An enchanted blade that allows the user to cut straight into the enemy's soul."

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

    Dim agival As New modValue(30, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim intval As New modValue(10, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Purges a target unit, removing buffs, slowing, and dealing damage if it is a summoned unit."

    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Purge"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                 thecaster As idisplayunit, _
                                 thetarget As idisplayunit, _
                                 ftarget As idisplayunit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList




    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim removeval As New modValue(1, eModifierType.RemoveBuffs, occurencetime)

    Dim buffremove As New Modifier(removeval, unittargetenemytargetinfo)

    outmods.Add(buffremove)

    'this is a guess. haven't found actual number
    Dim purgeval As New modValue(0.1, eModifierType.MoveSpeedPercentSubtracted, occurencetime)

    Dim purgeslow As New Modifier(purgeval, unittargetenemytargetinfo)

    outmods.Add(purgeslow)


    Dim manaval As New modValue(36, eModifierType.ManaRemoved, occurencetime)
    Dim manadrain As New Modifier(manaval, unittargetenemytargetinfo)
    outmods.Add(manadrain)

    Dim damval As New modValue(36, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim manadraindamage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(manadraindamage)


    Dim unittargetenemytargetinfo2 = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "Illusion Damage", eModifierCategory.Active)

    Dim purgedamval As New modValue(9999, eModifierType.DamagePhysicalAdded, occurencetime)
    Dim purgedamage As New Modifier(purgedamval, unittargetenemytargetinfo2)
    outmods.Add(purgedamage)




    Return outmods
  End Function
End Class
