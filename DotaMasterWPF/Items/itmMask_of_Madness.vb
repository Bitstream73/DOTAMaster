Public Class itmMask_of_Madness
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMASK_OF_MADNESS
    Me.EntityName = eEntity.itmMASK_OF_MADNESS

    mDisplayName = "Mask of Madness"
    'mDescription = "Once this mask is worn, its bearer becomes an uncontrollable aggressive force.|Passive: Lifesteal - Grants lifesteal on attacks.|Mask of Madness is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."
    mGoldCost = New ValueWrapper(1900)
    mMadeFromItems.Add(eItemname.itmRECIPE_MASK_OF_MADNESS)
    mMadeFromItems.Add(eItemname.itmMORBID_MASK)



    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/mask_of_madness_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(25)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(12)
    ManaCost = New ValueWrapper(25)

    Description = "Active: Berserk - Gives 100 attack speed and 30% movement speed but causes you to take extra 30% damage. Lasts 12 seconds.|Passive: Lifesteal - Grants lifesteal on attacks.|Mask of Madness is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."
    Notes = "Does not interupt the owner's channeling spells upon cast.|Amplifies all 3 damage types after all reductions.|Amplified damage is the same type of damage dealt.|The lifesteal stacks additively with other sources of lifesteal which are not Unique Attack Modifier.|Cannot lifesteal off of wards, buildings and allied units. Can lifesteal off of siege creeps." '
    ColorText = "Once this mask is worn, its bearer becomes an uncontrollable aggressive force."

  End Sub

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim lifestealval As New modValue(0.2, eModifierType.LifeStealPercent, occurencetime)

    Dim lifesteal As New Modifier(lifestealval, unittargetenemytargetinfo)

    outmods.Add(lifesteal)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Gives 100 attack speed and 30% movement speed but causes you to take extra 30% damage. Lasts 12 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Berserk"
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

    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, notargetselfinfo)

    outmods.Add(attackspeed)



    Dim movespeedval As New modValue(0.3, eModifierType.MoveSpeedPercent, occurencetime)

    Dim movespeed As New Modifier(movespeedval, notargetselfinfo)

    outmods.Add(movespeed)



    Dim damageampval As New modValue(0.3, eModifierType.DamageAmplification, occurencetime)

    Dim incomingdamagebuff As New Modifier(damageampval, notargetselfinfo)

    outmods.Add(incomingdamagebuff)

    Return outmods
  End Function
End Class
