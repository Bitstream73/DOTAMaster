Public Class itmMekansm
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMEKANSM
    Me.EntityName = eEntity.itmMEKANSM

    mDisplayName = "Mekansm" ' PageHandler.dbItems.GetFriendlyName(mName)
    'mDescription = "A glowing jewel formed out of assorted parts that somehow fit together perfectly.|Passive: Mekansm Aura - Bonus HP Regen in an area.|Multiple instances of Mekansm Aura do not stack. "
    mGoldCost = New ValueWrapper(2300)
    mMadeFromItems.Add(eItemname.itmRECIPE_MEKANSM)
    mMadeFromItems.Add(eItemname.itmHEADDRESS)
    mMadeFromItems.Add(eItemname.itmBUCKLER)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/mekansm_lg.png"
    mTier =
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(45)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(150)

    Description = "Active: Restore - Heals 250 HP and gives +2 armor in an area.|Passive: Mekansm Aura - Bonus HP Regen in an area.|Multiple instances of Mekansm Aura do not stack. "
    Notes = "Interupts the user's channeling spells upon cast.|Affects every allied unit, including invulnerable units, siege creeps and illusions, exluding wards and buildings.|Does not affect units who have been affected by Restore in the last 25 seconds.|This is not indicated anywhere. The armor bonus lasts 25 seconds, but since it is purgeable, it's not always reliable.|Restore bonus armor does not stack with the armor gained from Buckler and Crimson Guard active abilities.|Stacks with all other sources of flat health regeneration, except with Regeneration Aura from multiple Mekansms.|The flat health regen bonus is not considered by percentage health regeneration increases.|Regenerates up to 240 health in one minute.|Does not affect wards, buildings and invulnerable units.|The aura's buff lingers for 0.5 seconds." '
    ColorText = "A glowing jewel formed out of assorted parts that somehow fit together perfectly."
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

    Dim strval As New modValue(5, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)
    outmods.Add(strmod)


    Dim intval As New modValue(5, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(5, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim hpregenval As New modValue(4, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregenauraself As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregenauraself)




    Dim passivealliesinfo = Helpers.GetPassiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                                  theownerid, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)


    Dim hpregenauraallies As New Modifier(hpregenval, passivealliesinfo)

    outmods.Add(hpregenauraallies)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Heals 250 HP and gives +2 armor in an area.|Passive: Mekansm Aura - Bonus HP Regen in an area."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Restore"
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

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim healthval As New modValue(250, eModifierType.HPAdded, occurencetime)

    Dim healself As New Modifier(healthval, notargetselfinfo)

    outmods.Add(healself)


    Dim armorval As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armorself As New Modifier(armorval, notargetselfinfo)

    outmods.Add(armorself)


    Dim auraalliesinfo = Helpers.GetActiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)


    Dim healallies As New Modifier(healthval, auraalliesinfo)

    outmods.Add(healallies)


    Dim armorallies As New Modifier(armorval, auraalliesinfo)

    outmods.Add(armorallies)

    Return outmods
  End Function
End Class
