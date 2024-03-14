Public Class itmHeavens_Halberd
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHEAVENS_HALBERD
    Me.EntityName = eEntity.itmHEAVENS_HALBERD

    mDisplayName = "Heaven's Halberd"
    Description = "This halberd moves with the speed of a smaller weapon, allowing the bearer to win duels that a heavy edge would not.|Passive: Lesser Maim - Gives a chance on attack to slow movement speed for 4.0 seconds. "
    mGoldCost = New ValueWrapper(3850)
    mMadeFromItems.Add(eItemname.itmSANGE)
    mMadeFromItems.Add(eItemname.itmTALISMAN_OF_EVASION)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/heavens_halberd_lg.png"
    mTier = 3
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(100)


    Description = "Active: Disarms the target for 4.5 seconds. Lasts 3.0 on Melee targets.|Passive: Lesser Maim - Gives a chance on attack to slow movement speed for 4.0 seconds.|Stacks diminishingly with other sources of Evasion. "
    Notes = "The Disarm does not prevent units in a Duel from attacking each other." '
    ColorText = "This halberd moves with the speed of a smaller weapon, allowing the bearer to win duels that a heavy edge would not."

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

    Dim evval As New modValue(0.25, eModifierType.EvasionPercent, occurencetime)
    Dim evasion As New Modifier(evval, passiveselfinfo)
    outmods.Add(evasion)

    Dim strval As New modValue(20, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)



    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(25, eModifierType.DamagePhysicalAdded, occurencetime)
    Dim damage As New Modifier(damval, unittargetenemytargetinfo)
    outmods.Add(damage)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Disarms the target for 4.5 seconds. Lasts 3.0 on Melee targets."
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

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim rangev As New ValueWrapper(4.5)
    Dim rangeval As New modValue(rangev, eModifierType.DisarmRange, occurencetime, aghstime)
    rangeval.mValueDuration = rangev 'New ValueWrapper(4.5) 'New TimeSpan(4500)

    Dim disarmranged As New Modifier(rangeval, unittargetenemytargetinfo)

    outmods.Add(disarmranged)

    Dim dis As New ValueWrapper(3)
    Dim meleeval As New modValue(dis, eModifierType.DisarmMelee, occurencetime, aghstime)
    meleeval.mValueDuration = dis 'New ValueWrapper(3) 'New TimeSpan(0, 0, 3)

    Dim disarmmelee As New Modifier(meleeval, unittargetenemytargetinfo)

    outmods.Add(disarmmelee)



    Dim slowval As New modValue(0.2, eModifierType.MoveSpeedPercentSubtracted, occurencetime)
    slowval.mPercentChance = New ValueWrapper(0.15)

    Dim maimmoveslow As New Modifier(slowval, unittargetenemytargetinfo)

    outmods.Add(maimmoveslow)

    Dim attslowval As New modValue(20, eModifierType.AttackspeedSubtracted, occurencetime)
    attslowval.mPercentChance = slowval.mPercentChance
    Dim maimattackslow As New Modifier(attslowval, unittargetenemytargetinfo)

    outmods.Add(maimattackslow)

    Return outmods
  End Function
End Class
