Public Class itmDrum_of_Endurance
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDRUM_OF_ENDURANCE
    Me.EntityName = eEntity.itmDRUM_OF_ENDURANCE

    mDisplayName = "Drum of Endurance"
    ' mDescription = "A relic that enchants the bodies of those around it for swifter movement in times of crisis.|Passive: Swiftness Aura - Gives bonus attack and movement speed to surrounding allies|Multiple instances of Swiftness Aura do not stack. "
    mGoldCost = New ValueWrapper(1875)

    mMadeFromItems.Add(eItemname.itmRECIPE_DRUM_OF_ENDURANCE)
    mMadeFromItems.Add(eItemname.itmBRACER)
    mMadeFromItems.Add(eItemname.itmROBE_OF_THE_MAGI)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ancient_janggo_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Active: Endurance - Gives bonus +10 attack speed and +10% movement speed to surrounding allies.|Passive: Swiftness Aura - Gives bonus attack and movement speed to surrounding allies.|Multiple instances of Swiftness Aura do not stack. "
    Notes = "Interupts the user's channeling spells upon cast.|Multiple casts of Endurance do not stack the buff, but refresh the duration instead.|Only affects player controlled units, including invulnerable units, excluding wards.The aura's buff lingers for 0.5 seconds.|Fully stacks with other sources of movement and attack speed bonuses, except for Swiftness auras of multiple Drums.|Affects invulnerable units." '
    ColorText = "A relic that enchants the bodies of those around it for swifter movement in times of crisis."

  End Sub

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                   theownerid As idisplayunit, _
                                                   thetarget As idisplayunit, _
                                                   ftarget As idisplayunit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinf = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                    theownerid, _
                                                    thetarget, _
                                                    "", eModifierCategory.Passive)

    Dim strval As New modValue(9, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinf)

    outmods.Add(strmod)


    Dim intval As New modValue(9, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinf)

    outmods.Add(intmod)


    Dim agival As New modValue(9, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinf)

    outmods.Add(agimod)


    Dim damval As New modValue(9, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, passiveselfinf)

    outmods.Add(damage)


    Dim auradam As New modValue(5, eModifierType.AttackSpeedAdded, occurencetime)

    Dim auraAttackspeedself As New Modifier(auradam, passiveselfinf)

    outmods.Add(auraAttackspeedself)


    Dim moveval As New modValue(0.05, eModifierType.MoveSpeedPercent, occurencetime)

    Dim auraMovespeedself As New Modifier(moveval, passiveselfinf)

    outmods.Add(auraMovespeedself)


    'Aura component
    Dim aurainf = Helpers.GetPassiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                        theownerid, _
                                                        thetarget, _
                                                        "", eModifierCategory.Passive)


    Dim attspeedval As New modValue(5, eModifierType.AttackSpeedAdded, occurencetime)

    Dim auraAttackspeedalliedunits As New Modifier(attspeedval, aurainf)

    outmods.Add(auraAttackspeedalliedunits)

    Dim movespeedval As New modValue(0.05, eModifierType.MoveSpeedPercent, occurencetime)

    Dim auraMovespeedalliedunits As New Modifier(movespeedval, aurainf)

    outmods.Add(auraMovespeedalliedunits)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Gives bonus +10 attack speed and +10% movement speed to surrounding allies."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Endurance"
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

    'self
    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                      thecaster, _
                                                      thetarget, _
                                                      "", eModifierCategory.Active)

    Dim attspeedval As New modValue(10, eModifierType.AttackSpeedAdded, occurencetime)

    Dim auraAttackspeedself As New Modifier(attspeedval, notargetselfinfo)

    outmods.Add(auraAttackspeedself)


    Dim movespeedval As New modValue(0.1, eModifierType.MoveSpeedPercent, occurencetime)

    Dim auraMovespeedself As New Modifier(movespeedval, notargetselfinfo)

    outmods.Add(auraMovespeedself)


    'allies

    Dim auraalliedunitsinfo = Helpers.GetPassiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)


    Dim auraAttackspeedalliedunits As New Modifier(attspeedval, auraalliedunitsinfo)

    outmods.Add(auraAttackspeedalliedunits)



    Dim auraMovespeedalliedunits As New Modifier(movespeedval, auraalliedunitsinfo)

    outmods.Add(auraMovespeedalliedunits)

    Return outmods
  End Function
End Class
