Public Class itmAssault_Curass
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmASSAULT_CUIRASS
    Me.EntityName = eEntity.itmASSAULT_CUIRASS

    mDisplayName = "Assault Cuirass"
    'mDescription = "Forged in the depths of the nether reaches, this hellish mail provides an army with increased armor and attack speed.|Passive: Assault Aura - Grants attack speed and armor to nearby allied units, and decreases armor for nearby enemies.|Multiple instances of Assault Aura do not stack. "
    mGoldCost = New ValueWrapper(5250)
    mMadeFromItems.Add(eItemname.itmRECIPE_ASSAULT_CUIRASS)
    mMadeFromItems.Add(eItemname.itmPLATEMAIL)
    mMadeFromItems.Add(eItemname.itmHYPERSTONE)
    mMadeFromItems.Add(eItemname.itmCHAINMAIL)


    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/assault_lg.png"
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
    Description = "Passive: Assault Aura - Grants attack speed and armor to nearby allied units, and decreases armor for nearby enemies.|Multiple instances of Assault Aura do not stack."
    Notes = "Fully stacks with other attack speed increasing, armor increasing and armor decreasing effects.|Assault Auras from multiple Assault Cuirasses do not stack.|A unit can be affected the positive aura and by the negative aura at the same time.|The aura's buff and debuff linger for 0.5 seconds.|The status buff icon on enemies only shows up when the affected unit has vision over the source.|Affects invulnerable allies and enemies." '
    ColorText = "Forged in the depths of the nether reaches, this hellish mail provides an army with increased armor and attack speed."
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

    Dim attspeedval1 As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval1, passiveselfinfo)

    outmods.Add(attackspeed)


    Dim arval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(arval, passiveselfinfo)

    outmods.Add(armor)


    Dim aurapassivealliesinfo = Helpers.GetPassiveAuraAlliedHeroesInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim attspeedval As New modValue(20, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeedaura As New Modifier(attspeedval, aurapassivealliesinfo)

    outmods.Add(attackspeedaura)



    Dim armoraura As New Modifier(arval, aurapassivealliesinfo)

    outmods.Add(armoraura)

    Dim auraenemiesinfo = Helpers.GetPassiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim negarmval As New modValue(5, eModifierType.ArmorSubtracted, occurencetime)

    Dim armordebuffaura As New Modifier(negarmval, auraenemiesinfo)

    outmods.Add(armordebuffaura)

    Return outmods
  End Function
End Class
