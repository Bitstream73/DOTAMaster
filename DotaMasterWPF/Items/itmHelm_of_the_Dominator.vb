Public Class itmHelm_of_the_Dominator
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHELM_OF_THE_DOMINATOR
    Me.EntityName = eEntity.itmHELM_OF_THE_DOMINATOR

    mDisplayName = "Helm of the Dominator"
    ' mDescription = "The powerful headpiece of a dead necromancer.|Passive: Lifesteal - Gives lifesteal on attacks.|Helm of the Dominator is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."
    mGoldCost = New ValueWrapper(1850)
    mMadeFromItems.Add(eItemname.itmMORBID_MASK)
    mMadeFromItems.Add(eItemname.itmHELM_OF_IRON_WILL)


    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/helm_of_the_dominator_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(60)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(75)

    Description = "Active: Dominate - Take control of a non-hero, non-ancient target unit. Dominated units gain 500 bonus health.|Passive: Lifesteal - Gives lifesteal on attacks.|Helm of the Dominator is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."
    Notes = "Dominating a creep while already having one dominated causes the previous dominated creep to die.|The dominated creep is directly bound to the item it was dominated with.|This means it is possible to get multiple helms and have a creep dominated with each.|This also means when the dominated creep changes ownership again (e.g.Enchant), dominating a new creep still causes it to die.|When the item gets sold, destroyed, or built into a Satanic, the dominated creep dies.|Cannot dominate Roshan, ancient creeps, Necronomicon summons, Lone Druid's Spirit Bear, Visage's Familiars, Warlock's Golems and the Primal Split spirits.|The lifesteal stacks additively with other sources of lifesteal which are not Unique Attack Modifier.|Cannot lifesteal off of wards, buildings and allied units. Can lifesteal off of siege creeps." '
    ColorText = "The powerful headpiece of a dead necromancer."

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


    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)


    Dim lifeval As New modValue(0.15, eModifierType.LifeStealPercent, occurencetime)

    Dim lifesteal As New Modifier(lifeval, passiveselfinfo)

    outmods.Add(lifesteal)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)


    Dim damval As New modValue(20, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Take control of a non-hero, non-ancient target unit."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Dominate"
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

    Dim pointtargetenemyinfo = Helpers.GetUnitTargetEnemyCreepInfo(theitem_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim domval As New modValue(0, eModifierType.Dominate, occurencetime)

    Dim dominate As New Modifier(domval, pointtargetenemyinfo)

    outmods.Add(dominate)

    Return outmods
  End Function
End Class
