Public Class itmPipe_of_Insight
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPIPE_OF_INSIGHT
    Me.EntityName = eEntity.itmPIPE_OF_INSIGHT

    mDisplayName = "Pipe of Insight"
    'mDescription = "A powerful artifact of mysterious origin, it creates barriers against magical forces.|Passive: Insight Aura - Gives nearby friendly units 4 health regeneration.|Multiple instances of spell resistance from items do not stack. "
    mGoldCost = New ValueWrapper(3625)

    mMadeFromItems.Add(eItemname.itmRECIPE_PIPE_OF_INSIGHT)
    mMadeFromItems.Add(eItemname.itmHOOD_OF_DEFIANCE)
    mMadeFromItems.Add(eItemname.itmHEADDRESS)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/pipe_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(60)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(100)

    Description = "Active: Barrier - Gives nearby friendly units a shield that blocks 400 spell damage.|Passive: Insight Aura - Gives nearby friendly units 4 health regeneration."
    Notes = "Interupts the user's channeling spells upon cast.|Does not affect invulnerable units, siege creeps, wards and buildings.|Does not affect units who have been affected by Guard in the last 50 seconds. This is not indicated anywhere.|Barrier blocks damage before any reductions. The only exception here is spell immunity, during which it does not block any magic damage.|Stacks with all other sources of flat health regeneration, except with Regeneration Aura from multiple Pipes of Insight.|The flat health regen bonus is not considered by percentage health regeneration increases.|Regenerates up to 240 health in one minute.|Does not affect wards, buildings and invulnerable units.|The aura's buff lingers for 0.5 seconds." '
    ColorText = "A powerful artifact of mysterious origin, it creates barriers against magical forces."

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

    Dim HPVAL As New modValue(8, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(HPVAL, passiveselfinfo)

    outmods.Add(hpregen)


    Dim magval As New modValue(0.3, eModifierType.MagicResistancePercentAdded, occurencetime)

    Dim magicresist As New Modifier(magval, passiveselfinfo)

    outmods.Add(magicresist)

    'from aura
    Dim passiveselfinfo2 = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "From aura", eModifierCategory.Passive)

    Dim hpvalregen As New modValue(4, eModifierType.HPAdded, occurencetime)

    Dim hpregenself As New Modifier(hpvalregen, passiveselfinfo2)

    outmods.Add(hpregenself)



    Dim auraalliesinfo = Helpers.GetActiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                              theownerid, _
                                                              thetarget, _
                                                              "", eModifierCategory.Passive)

    Dim hpregenallies As New Modifier(hpvalregen, auraalliesinfo)

    outmods.Add(hpregenallies)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Gives nearby friendly units a shield that blocks 400 spell damage."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Barrier"
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

    Dim activeauraselfinfo = Helpers.GetActiveAuraSelfInfo(theitem_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim magval As New modValue(-400, eModifierType.DamageMagicalAdded, occurencetime)

    Dim magicdamageself As New Modifier(magval, activeauraselfinfo)

    outmods.Add(magicdamageself)

    Dim activeauraallies = Helpers.GetActiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim magicdamageallies As New Modifier(magval, activeauraallies)

    outmods.Add(magicdamageallies)

    Return outmods
  End Function
End Class
