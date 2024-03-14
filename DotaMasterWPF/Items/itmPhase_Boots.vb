Public Class itmPhase_Boots
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmPHASE_BOOTS
    Me.EntityName = eEntity.itmPHASE_BOOTS

    mDisplayName = "Phase Boots"
    'mDescription = "Boots that allow the wearer to travel between the ether. "
    mGoldCost = New ValueWrapper(1350)

    mMadeFromItems.Add(eItemname.itmBOOTS_OF_SPEED)
    mMadeFromItems.Add(eItemname.itmBLADES_OF_ATTACK)
    mMadeFromItems.Add(eItemname.itmBLADES_OF_ATTACK)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/phase_boots_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(8)
    Duration = New ValueWrapper(4)
    'mRadius = 
    'mCharges =

    Description = "Active: Phase - Gives increased movement speed and lets you move through units. Phase is cancelled upon using another item or ability.|Flat movement speed bonuses from multiple pairs of boots do not stack. "
    Notes = "Does not interupt the user's channeling spells upon cast.|Phase is canceled upon reaching the cast point of spells or items. Attacking does not cancel it.|Allows the user to path through other units, including wards, but not through buildings." '
    ColorText = "Boots that allow the wearer to travel between the ether."
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

    Dim moveval As New modValue(50, eModifierType.MoveSpeedAdded, occurencetime)

    Dim movespeed As New Modifier(moveval, passiveselfinfo)

    outmods.Add(movespeed)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Gives increased movement speed and lets you move through units. Phase is cancelled upon using another item or ability.|Flat movement speed bonuses from multiple pairs of boots do not stack. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Phase"
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

    Dim dur As New ValueWrapper(4)
    Dim phaseval As New modValue(dur, eModifierType.Phase_Form, occurencetime, aghstime)
    phaseval.mValueDuration = dur ' New TimeSpan(0, 0, 4)

    Dim phase As New Modifier(phaseval, notargetselfinfo)

    outmods.Add(phase)


    Dim moveval As New modValue(0.16, eModifierType.MoveSpeedPercent, occurencetime)

    Dim movespeedpercent As New Modifier(moveval, notargetselfinfo)

    outmods.Add(movespeedpercent)

    Return outmods

  End Function
End Class
