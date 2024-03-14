Public Class itmHeaddress
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHEADDRESS
    Me.EntityName = eEntity.itmHEADDRESS

    mDisplayName = "Headdress"
    'mDescription = "Creates a soothing aura that restores allies in battle. Multiple instances of Regeneration Aura do not stack. "
    mGoldCost = New ValueWrapper(600)

    mMadeFromItems.Add(eItemname.itmRECIPE_HEADDRESS)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)
    mMadeFromItems.Add(eItemname.itmIRON_BRANCH)

    mBuildsToNames.Add(eItemname.itmMEKANSM)
    mBuildsToNames.Add(eItemname.itmPIPE_OF_INSIGHT)

    mCategory = eItemCategory.SUPPORT
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/headdress_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    Radius = New ValueWrapper(750)
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Passive: Regeneration Aura - Restores HP to allies in a 750 unit radius.|Multiple instances of Regeneration Aura do not stack. "
    Notes = "Stacks with all other sources of flat health regeneration, except with Regeneration Aura from multiple Headdress.|The flat health regen bonus is not considered by percentage health regeneration increases.|Regenerates up to 180 health in one minute.|Places the buff on illusions, but they do not benefit from it.|Does not affect wards, buildings and invulnerable units.|The aura 's buff lingers for 0.5 seconds." '
    ColorText = "Creates a soothing aura that restores allies in battle."

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


    Dim hpregenval As New modValue(2, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregenauraself As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregenauraself)



    Dim strval As New modValue(2, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(2, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(2, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim passivealliedheroes = Helpers.GetPassiveAuraAlliedHeroesInfo(theitem_InfoID, _
                                                                     theownerid, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Passive)


    Dim hpregenauraalliedheroes As New Modifier(hpregenval, passivealliedheroes)

    outmods.Add(hpregenauraalliedheroes)

    Return outmods
  End Function
End Class
