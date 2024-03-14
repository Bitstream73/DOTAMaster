Public Class itmArmlet_of_Mordiggian
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmARMLET_OF_MORDIGGIAN
    Me.EntityName = eEntity.itmARMLET_OF_MORDIGGIAN

    mDisplayName = "Armlet of Mordiggian"
    'mDescription = "Weapon of choice among brutes, the bearer sacrifices his life energy to gain immense strength and power. "
    mGoldCost = New ValueWrapper(2600)
    mMadeFromItems.Add(eItemname.itmRECIPE_ARMLET_OF_MORDIGGIAN)
    mMadeFromItems.Add(eItemname.itmHELM_OF_IRON_WILL)
    mMadeFromItems.Add(eItemname.itmGLOVES_OF_HASTE)
    mMadeFromItems.Add(eItemname.itmBLADES_OF_ATTACK)


    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/armlet_lg.png"
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
    Description = "Active: Unholy Strength - Gives +31 damage, +10 attack speed, and +25 strength while active, but drains 40 HP per second. You cannot die from the health loss when the bonus strength is gone, or the health drain per second."
    Notes = "Does not interupt the owner's channeling spells upon toggling.|Upon toggling on, it instantly provides the attack damage and speed and starts draining 4 health in 0.1 second intervals.|Grants 3.5 strength in 0.1 second intervals, so it needs 0.7 seconds to grant the full strength bonus.|Each added strength also increases the owner's current health by 19, granting it a total of 475 current health.|The health lost fully ignores everything. It can not be blocked. However, it does not drain health while invulnerable.|Can not bring the owner's health below 1, so the health loss is never lethal. It does not toggle itself off when reaching 1 health.|Considering the passive health regen and the regen gained from the strength, the health cost is effectively reduced to 32.25 per second.|When toggling off, all bonuses are instantly lost. This also includes he 475 current health which was gained upon toggling it on." '
    ColorText = "Weapon of choice among brutes, the bearer sacrifices his life energy to gain immense strength and power."
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

    Dim damval As New modValue(9, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim attspeedval As New modValue(15, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)


    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)


    Dim hpregenval As New modValue(7, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Gives +31 damage, +10 attack speed, and +25 strength while active, but drains 40 HP per second. You cannot die from the health loss when the bonus strength is gone, or the health drain per second. "
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Unholy Strength"
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

    Dim damval As New modValue(31, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim strval As New modValue(25, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, unittargetenemytargetinfo)

    outmods.Add(strmod)

    Dim onesec As New ValueWrapper(1)
    Dim hpdrainval As New modValue(40, eModifierType.HPSubtracted, onesec, occurencetime)

    Dim hpdrain As New Modifier(hpdrainval, unittargetenemytargetinfo)

    outmods.Add(hpdrain)

    Return outmods
  End Function
End Class
