Public Class itmManta_Style
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMANTA_STYLE
    Me.EntityName = eEntity.itmMANTA_STYLE

    mDisplayName = "Manta Style"
    ' mDescription = "An axe made of reflective materials that causes confusion amongst enemy ranks. "
    mGoldCost = New ValueWrapper(5050)
    mMadeFromItems.Add(eItemname.itmRECIPE_MANTA_STYLE)
    mMadeFromItems.Add(eItemname.itmYASHA)
    mMadeFromItems.Add(eItemname.itmULTIMATE_ORB)

    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/manta_lg.png"
    mTier = 3
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(50)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(165)

    Description = "Active: Mirror Image - Creates 2 images of your hero that last 20 seconds.|Melee images deal 33% damage and take 350% damage, while Ranged images deal 28% and take 400% damage.|Yasha-based movement speed bonuses from multiple items do not stack. "
    Notes = "Has 50 seconds cooldown for ranged heroes and 35 seconds cooldown for melee heroes.|The user is invulnerable and hidden for 0.1 seconds upon cast.|Disjoints projectiles upon cast.|Applies a normal dispel on the owner upon cast.|Resets all current attack and spell targeting orders from other units on the owner.|The formation of the owner and the illusions is always the same. One spawns on the owner's cast location and the others randomly on north, east, south or west side each.|Though the formation is always the same, the owner and the illusions take a random position in the formation and have all the same facing angle." '
    ColorText = "An axe made of reflective materials that causes confusion amongst enemy ranks."

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


    Dim strval As New modValue(10, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)



    Dim intval As New modValue(26, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)



    Dim agival As New modValue(10, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)



    Dim attspeedval As New modValue(15, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)



    Dim movespeedval As New modValue(0.1, eModifierType.MoveSpeedPercent, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)


    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Creates 2 illusions of your hero that last 20 seconds.|Melee illusions deal 33% damage and take 250% bonus damage. Ranged illusions deal 28% damage and take 300% bonus damage."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Mirror Image"
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
                                                                         "", eModifierCategory.Passive)

    Dim illusiondamage As New modValue(0.33, eModifierType.MantaMeleeIllusionDamagePercentage, occurencetime)

    Dim meleeillusiondamage1 As New Modifier(illusiondamage, unittargetenemytargetinfo)

    outmods.Add(meleeillusiondamage1)



    Dim meleeillusiondamage2 As New Modifier(illusiondamage, unittargetenemytargetinfo)

    outmods.Add(meleeillusiondamage2)

    Dim illusionrangedamage As New modValue(0.28, eModifierType.MantaRangeIllusionDamagePercentage, occurencetime)

    Dim rangeillusiondamage1 As New Modifier(illusionrangedamage, unittargetenemytargetinfo)

    outmods.Add(rangeillusiondamage1)



    Dim rangeillusiondamage2 As New Modifier(illusionrangedamage, unittargetenemytargetinfo)

    outmods.Add(rangeillusiondamage2)

    Return outmods
  End Function
End Class
