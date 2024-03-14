Public Class itmSatanic
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSATANIC
    Me.EntityName = eEntity.itmSATANIC

    mDisplayName = "Satanic"
    ' mDescription = "Immense power at the cost of your soul.|Passive: Lifesteal - Gives Lifesteal on attacks.|Satanic is a Unique Attack Modifier, and does not stack with other Unique Attack Modifier."
    mGoldCost = New ValueWrapper(6150)
    mMadeFromItems.Add(eItemname.itmRECIPE_SATANIC)
    mMadeFromItems.Add(eItemname.itmREAVER)
    mMadeFromItems.Add(eItemname.itmHELM_OF_THE_DOMINATOR)


    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/satanic_lg.png"
    mTier = 3
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(35)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(3.5)
    'mManaCost = 

    Description = "Active: Unholy Rage - Increases Lifesteal by 175% for 3.5 seconds.|Passive: Lifesteal - Gives Lifesteal on attacks.|Satanic is a Unique Attack Modifier, and does not stack with other Unique Attack Modifier. "
    Notes = "Interupts the owner's channeling spells upon cast.|Directly increases the lifesteal granted by its passive part by 175%, resulting in 200% lifesteal.|The lifesteal stacks additively with other sources of lifesteal which are not Unique Attack Modifier.|Cannot lifesteal off of wards, buildings and allied units. Can lifesteal off of siege creeps." '
    ColorText = "Immense power at the cost of your soul."

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

    Dim strval As New modValue(25, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim armorval As New modValue(5, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(20, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim lifeval As New modValue(0.25, eModifierType.LifeStealPercent, occurencetime)
    Dim lifesteal As New Modifier(lifeval, unittargetenemytargetinfo)
    outmods.Add(lifesteal)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Increases Lifesteal by 175% for 3.5 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Unholy Rage"
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

    Dim lifeval As New modValue(1.75, eModifierType.LifeStealPercent, occurencetime)

    Dim lifesteal As New Modifier(lifeval, unittargetenemytargetinfo)

    outmods.Add(lifesteal)

    Return outmods
  End Function
End Class
