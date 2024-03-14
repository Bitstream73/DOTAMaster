Public Class itmVladmirs_Offering
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmVLADMIRS_OFFERING
    Me.EntityName = eEntity.itmVLADMIRS_OFFERING

    mDisplayName = "Vladmir's Offering"
    Description = "An eerie mask that is haunted with the malice of a fallen vampire.| Vladmir's Aura - Grants a variety of bonuses to nearby allies. Lifesteal bonuses from Vladmir's Aura only affect melee units.|Multiple instances of Vladmir's Aura do not stack.  "
    mGoldCost = New ValueWrapper(2050)

    mMadeFromItems.Add(eItemname.itmRECIPE_VLADMIRS_OFFERING)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)
    mMadeFromItems.Add(eItemname.itmRING_OF_BASILIUS)
    mMadeFromItems.Add(eItemname.itmMORBID_MASK)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/vladmir_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManacost = 
    Radius = New ValueWrapper(900)
    Description = "Passive: Vladmir's Aura - Grants a variety of bonuses to nearby allies. Lifesteal bonuses from Vladmir's Aura only affect melee units. |Multiple instances of Vladmir's Aura do not stack. "
    Notes = "The aura bonuses do not stack with the auras from Vladmir's Offering, Ring of Basilius and Ring of Aquila.|The lifesteal is not a Unique Attack Modifier, so it stacks additively with all other sources of lifesteal.|Cannot lifesteal off of siege creeps, wards, buildings and allied units.||Only increases base damage and that given by the primary attribute of the affected units. Raw bonus damage is not increased.|The flat mana regen bonus is not considered by percentage mana regeneration increases.|Regenerates up to 48 mana in one minute.|The aura's buff lingers for 0.5 seconds.|Affects invulnerable units." '
    ColorText = "An eerie mask that is haunted with the malice of a fallen vampire."

  End Sub

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList()

    Dim aurapassiveenemiesinfo = Helpers.GetPassiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                                      theownerid, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Passive)

    Dim arualifeval As New modValue(0.16, eModifierType.LifeStealPercent, occurencetime)
    arualifeval.mRadius = New ValueWrapper(900)
    Dim auralifestealself As New Modifier(arualifeval, aurapassiveenemiesinfo)

    outmods.Add(auralifestealself)

    Dim aurapassiveselfe = Helpers.GetPassiveAuraSelfInfo(theitem_InfoID, _
                                                          theownerid, _
                                                          thetarget, _
                                                          "", eModifierCategory.Passive)

    Dim damval As New modValue(0.15, eModifierType.DamagePhysicalPercent, occurencetime)
    damval.mRadius = New ValueWrapper(900)

    Dim aurabonusdamageself As New Modifier(damval, aurapassiveselfe)

    outmods.Add(aurabonusdamageself)



    Dim manaval As New modValue(0.8, eModifierType.ManaRegenAdded, occurencetime)
    manaval.mRadius = New ValueWrapper(900)

    Dim auramanaregenself As New Modifier(manaval, aurapassiveselfe)

    outmods.Add(auramanaregenself)


    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim aurabonusarmorself As New Modifier(armorval, passiveselfinfo)

    outmods.Add(aurabonusarmorself)


    Dim hpregenval As New modValue(2, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregenself As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregenself)




    'Dim auralifestealallies As New Modifier(0.16, eModifierType.LifeStealPercent, "Lifesteal Aura", eAbilityType.Passive, mParentorBuildName, eUnit.untAlliedMeleeUnits, _
    '                               mName, eOwnerType.Item, Me, -1, "")
    'outmods.Add(auralifestealallies)

    'Dim aurabonusdamageallies As New Modifier(0.15, eModifierType.DamagePhysicalPercent, "Bonus Damage Aura", eAbilityType.Passive, mParentorBuildName, eUnit.untAlliedMeleeUnits, _
    '                                 mName, eOwnerType.Item, Me, -1, "")
    'outmods.Add(aurabonusdamageself)


    Dim passiveaurameleeunitsinfo = Helpers.GetPassiveAuraAlliedMeleeUnitsInfo(theitem_InfoID, _
                                                                               theownerid, _
                                                                               thetarget, _
                                                                               "", eModifierCategory.Passive)


    Dim aurabonusarmorallies As New Modifier(armorval, passiveaurameleeunitsinfo)
    outmods.Add(aurabonusarmorself)


    Dim auramanaregenallies As New Modifier(manaval, passiveaurameleeunitsinfo)
    outmods.Add(auramanaregenallies)





    Return outmods
  End Function

 
End Class
