Public Class itmMonkey_King_Bar
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMONKEY_KING_BAR
    Me.EntityName = eEntity.itmMONKEY_KING_BAR

    mDisplayName = "Monkey Kind Bar"
    ' mDescription = "A powerful staff used by a master warrior.|Passive: Mini-Bash - Gives a chance to minibash and deal bonus damage.|Passive: True Strike - Prevents your attacks from missing. "
    mGoldCost = New ValueWrapper(5400)
    mMadeFromItems.Add(eItemname.itmDEMON_EDGE)
    mMadeFromItems.Add(eItemname.itmJAVELIN)
    mMadeFromItems.Add(eItemname.itmJAVELIN)



    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/monkey_king_bar_lg.png"
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

    Description = "Passive: Mini-Bash - Gives a chance to minibash and deal bonus damage.|Passive: True Strike - Prevents your attacks from missing. True Strike does not work when attacking enemy structures. "
    Notes = "Mini-Bash from multiple Monkey King Bars work fully independent from each other.|This means that two of them can proc on the same attack and both deal their damage.|The owner can lifesteal off the damage dealt by Mini-Bash. However, it cannot crit or cleave.|The damage can be reduced by e.g. Enfeeble or Static Link.|However it can not be amplified by e.g. Empower or the Double Damage rune.|Does not work against wards and buildings, works against siege creeps and allied units.|Adds an average of 35 damage to every attack (123 damage if the item's 88 damage increase is counted as well).|Projectiles lauched with True Strike cannot be evaded, but still can be disjointed.|Does not work against buildings, works against any other unit, including wards and allied units.|Does not prevent from attacks getting cancel when the target leaves the motion buffer range." '
    ColorText = "A powerful staff used by a master warrior."

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

    Dim damval As New modValue(80, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Dim bashval As New modValue(100, eModifierType.Minibash_Damage, occurencetime)
    bashval.mPercentChance = New ValueWrapper(0.35)
    Dim minibashdamage As New Modifier(bashval, unittargetenemytargetinfo)

    outmods.Add(minibashdamage)


    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)

    'Dim minibashchance As New Modifier(0.35, eModifierType.Minibash_Chance, eAbilityType.Passive, "Chance to Mini-Bash", mParentorBuildName, eUnit.untEnemyTarget, _
    '                                   mName, eSourceType.Item, Me, -1, "")
    'outmods.Add(minibashchance)


    Return outmods
  End Function
End Class
