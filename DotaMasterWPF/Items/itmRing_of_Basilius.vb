Public Class itmRing_of_Basilius
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRING_OF_BASILIUS
    Me.EntityName = eEntity.itmRING_OF_BASILIUS

    mDisplayName = "Ring of Basilius"
    'mDescription = "Ring given as a reward to the greatest mages.|Multiple instances of Basilius Aura do not stack.|Does not stack with armor auras from Ring of Basilius, Rind of Aquila, or Vladmir's Offering."
    mGoldCost = New ValueWrapper(500)

    mMadeFromItems.Add(eItemname.itmSAGES_MASK)
    mMadeFromItems.Add(eItemname.itmRING_OF_PROTECTION)

    mBuildsToNames.Add(eItemname.itmVLADMIRS_OFFERING)
    mBuildsToNames.Add(eItemname.itmRING_OF_AQUILA)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ring_of_basilius_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    Radius = New ValueWrapper(900)
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Passive: Basilius Aura - Grants mana regeneration and armor in a 900 area of effect.|Active: Toggle whether the aura affects other non-hero units.|Multiple instances of Basilius Aura do not stack. "
    Notes = "Does not interupt the user's channeling spells upon toggling.|The flat mana regen bonus is not considered by percentage mana regeneration increases.|Regenerates up to 39 mana in one minute.|The aura bonuses do not stack with the auras from Ring of Basilius, Ring of Aquila icon.png Ring of Aquila and Vladmir's Offering icon.png Vladmir's Offering.|The aura's buff lingers for 0.5 seconds.|Lone Druid's Spirit Bear, Visage's Familiars, Warlock's Golem and the Primal Split spirits as heroes." '
    ColorText = "Ring given as a reward to the greatest mages."
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

    Dim armval As New modValue(1, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armval, passiveselfinfo)

    outmods.Add(armor)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(6, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim dammod As New Modifier(damval, passiveselfinfo)

    outmods.Add(dammod)


    Dim auraselfinfo = Helpers.GetPassiveAuraSelfInfo(theitem_InfoID, _
                                                      theownerid, _
                                                      thetarget, _
                                                      "", eModifierCategory.Passive)

    Dim manaval As New modValue(0.5, eModifierType.ManaRegenAdded, occurencetime)

    Dim manaregenauraself As New Modifier(manaval, auraselfinfo)

    outmods.Add(manaregenauraself)


    Dim armval2 As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armorauraself As New Modifier(armval2, auraselfinfo)

    outmods.Add(armorauraself)


    Dim auraalliesinfo = Helpers.GetPassiveAuraAlliedHeroesInfo(theitem_InfoID, _
                                                                theownerid, _
                                                                thetarget, _
                                                                "", eModifierCategory.Passive)


    Dim manaregenauraalliedheroes As New Modifier(manaval, auraalliesinfo)

    outmods.Add(manaregenauraalliedheroes)



    Dim armorauraalliedheroes As New Modifier(armval2, auraalliesinfo)

    outmods.Add(armorauraalliedheroes)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Toggle whether the aura affects other non-hero units."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Active"
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

    Dim auranonhero = Helpers.GetActiveAuraAlliedNonHeroUnitsInfo(theitem_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim manaval As New modValue(0.5, eModifierType.ManaRegenAdded, occurencetime)

    Dim manaregenaura As New Modifier(manaval, auranonhero)

    outmods.Add(manaregenaura)



    Dim armval As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armoraura As New Modifier(armval, auranonhero)

    outmods.Add(armoraura)

    Return outmods
  End Function
End Class
