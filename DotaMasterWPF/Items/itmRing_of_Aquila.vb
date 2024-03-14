Public Class itmRing_of_Aquila
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRING_OF_AQUILA
    Me.EntityName = eEntity.itmRING_OF_AQUILA

    mDisplayName = "Ring of Aquila"
    Description = "The ring of the fallen Warlord Aquila continues to support armies in battle.|Multiple instances of Aquila Aura do not stack. "
    mGoldCost = New ValueWrapper(985)
    mMadeFromItems.Add(eItemname.itmRECIPE_WRAITH_BAND)
    mMadeFromItems.Add(eItemname.itmRING_OF_BASILIUS)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ring_of_aquila_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Passive: Aquila Aura - Grants mana regeneration and armor in a 900 area of effect.|Active: Toggle whether the aura affects other non-hero units.|Multiple instances of Aquila Aura do not stack. "
    Notes = "Does not interupt the user's channeling spells upon toggling.|The flat mana regen bonus is not considered by percentage mana regeneration increases.|Regenerates up to 39 mana in one minute.|The aura bonuses do not stack with the auras from Ring of Aquila, Ring of Basilius and Vladmir's Offering.|The aura's buff lingers for 0.5 seconds.|Treats Lone Druid's Spirit Bear, Visage's Familiars, Warlock's Golem and the Primal Split spirits as heroes." '
    ColorText = "The ring of the fallen Warlord Aquila continues to support armies in battle."

    mStates = New List(Of String)
    mStates.Add("Off")
    mStates.Add("On")

    mStateImageURLs = New List(Of String)
    mStateImageURLs.Add("http://cdn.dota2.com/apps/dota2/images/items/ring_of_aquila_lg.png")
    mStateImageURLs.Add("http://cdn.dota2.com/apps/dota2/images/items/ring_of_aquila_lg.png")

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

    Dim strval As New modValue(3, eModifierType.StrAdded, occurencetime)

    Dim strength As New Modifier(strval, passiveselfinfo)

    outmods.Add(strength)


    Dim agival As New modValue(9, eModifierType.AgiAdded, occurencetime)

    Dim agility As New Modifier(agival, passiveselfinfo)

    outmods.Add(agility)


    Dim intval As New modValue(3, eModifierType.IntAdded, occurencetime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim armorval As New modValue(1, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)


    Dim damval As New modValue(9, eModifierType.RightClickDamageAdded, occurencetime)

    Dim damage As New Modifier(damval, passiveselfinfo)
    outmods.Add(damage)

    'aura

    Dim auraselfinfo = Helpers.GetPassiveAuraSelfInfo(theitem_InfoID, _
                                                      theownerid, _
                                                      thetarget, _
                                                      "", eModifierCategory.Passive)

    Dim manaregenval As New modValue(0.65, eModifierType.ManaRegenAdded, occurencetime)

    Dim manaregenauraself As New Modifier(manaregenval, auraselfinfo)

    outmods.Add(manaregenauraself)



    Dim armorval2 As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armorauraself As New Modifier(armorval2, auraselfinfo)

    outmods.Add(armorauraself)




    Dim auraalliesinfo = Helpers.GetPassiveAuraAlliedHeroesInfo(theitem_InfoID, _
                                                                theownerid, _
                                                                thetarget, _
                                                                "", eModifierCategory.Passive)


    Dim manaregenauraalliedheroes As New Modifier(manaregenval, auraalliesinfo)

    outmods.Add(manaregenauraalliedheroes)


    Dim armorauraalliedheroes As New Modifier(armorval2, auraalliesinfo)

    outmods.Add(armorauraalliedheroes)


    Select Case thestateindex
      Case 0

      Case 1
        Dim auranonhero = Helpers.GetPassiveAuraAlliedNonHeroesInfo(theitem_InfoID, _
                                                                theownerid, _
                                                                thetarget, _
                                                                "", eModifierCategory.Passive)

        Dim creeparmormod As New Modifier(armorval2, auranonhero)
        outmods.Add(creeparmormod)

        Dim creepmanamod As New Modifier(manaregenval, auranonhero)
        outmods.Add(creepmanamod)

      Case Else

        PageHandler.theLog.writelog("itmRing_of_Aqhila passed out of range stateindex: " & thestateindex.ToString)
    End Select

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Toggle whether the aura affects other non-hero units."
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

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                 thecaster As iDisplayUnit, _
                                 thetarget As iDisplayUnit, _
                                 ftarget As iDisplayUnit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim auranonheroinfo = Helpers.GetActiveAuraAlliedNonHeroUnitsInfo(theitem_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim manaregenval As New modValue(0.65, eModifierType.ManaRegenAdded, occurencetime)

    Dim manaregenaura As New Modifier(manaregenval, auranonheroinfo)

    outmods.Add(manaregenaura)


    Dim armorval2 As New modValue(2, eModifierType.ArmorAdded, occurencetime)

    Dim armoraura As New Modifier(armorval2, auranonheroinfo)

    outmods.Add(armoraura)


    Return outmods
  End Function
End Class
