Public Class itmSange
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSANGE
    Me.EntityName = eEntity.itmSANGE

    mDisplayName = "Sange"
    'mDescription = "Sange is an unusually accurate weapon, seeking weak points automatically. "
    mGoldCost = New ValueWrapper(2050)
    mMadeFromItems.Add(eItemname.itmRECIPE_SANGE)
    mMadeFromItems.Add(eItemname.itmOGRE_CLUB)
    mMadeFromItems.Add(eItemname.itmBELT_OF_STRENGTH)

    mBuildsToNames.Add(eItemname.itmHEAVENS_HALBERD)
    mBuildsToNames.Add(eItemname.itmSANGE_AND_YASHA)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/sange_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(4)
    'mManaCost = 

    Description = "Passive: Lesser Maim - Gives a chance on attack to slow movement speed for 4.0 seconds."
    Notes = "Successive procs on the same target do not stack, but refresh the duration instead.|The proc chance of Lesser Maim from multiple Sange work fully independent from each other.|Fully stacks with the Lesser Maim from Heaven's Halberd and the Greater Maim from Sange and Yasha, including the slow.|Does not work against Lone Druid's Spirit Bear, wards and buildings. Works against allied units." '
    ColorText = "Sange is an unusually accurate weapon, seeking weak points automatically."

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


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)


    Dim moveval As New modValue(0.2, eModifierType.MoveSpeedPercentSubtracted, occurencetime)
    moveval.mPercentChance = New ValueWrapper(0.15)
    Dim Moveslow As New Modifier(moveval, unittargetenemytargetinfo)
    outmods.Add(Moveslow)

    Dim attspeedval As New modValue(0.2, eModifierType.AttackSpeedPercentSubtracted, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, unittargetenemytargetinfo)

    outmods.Add(attackspeed)



    Dim damval As New modValue(10, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Return outmods

  End Function
  Public Overrides Property AbilityDescription As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return ""
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
    Return New ModifierList
  End Function

End Class
