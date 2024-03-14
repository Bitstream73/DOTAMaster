Public Class itmRefresher_Orb
  Inherits ItemBase



  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmREFRESHER_ORB
    Me.EntityName = eEntity.itmREFRESHER_ORB

    mDisplayName = "Refresher Orb"
    'mDescription = "A powerful artifact created for wizards."
    mGoldCost = New ValueWrapper(5225)
    mMadeFromItems.Add(eItemname.itmRECIPE_REFRESHER_ORB)
    mMadeFromItems.Add(eItemname.itmOBLIVION_STAFF)
    mMadeFromItems.Add(eItemname.itmPERSEVERANCE)

    mCategory = eItemCategory.CASTER
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/refresher_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(150)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(375)

    Description = "Active: Reset Cooldowns - Resets the cooldowns of all your items and abilities."
    Notes = "Interupts the user's channeling spells upon cast.|Only refreshes items which are in your inventory. Does not refresh items in stash, in other units' (e.g. couriers) inventory or dropped items.|Refreshes all spells owned by the user. This includes hidden or inactive spells (e.g. invoked spells, or Whirling Axes).|This means that it does not refresh all spells for Rubick. Stolen spells are only refreshed when he owns them upon refreshing.|Since items of same kind always share coodlown, it is not possible to refresh a Refresher Orb's cooldown with another Refresher Orb." '
    ColorText = "A powerful artifact created for wizards."

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

    Dim hpregenval As New modValue(5, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)


    Dim manaregenval As New modValue(20, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)


    Dim intval As New modValue(6, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)
    Dim damval As New modValue(40, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "A powerful artifact created for wizards."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Reset Cooldowns"
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

    Dim refval As New modValue(1, eModifierType.Reset_Cooldowns, occurencetime)

    Dim refresh As New Modifier(refval, notargetselfinfo)

    outmods.Add(refresh)

    Return outmods
  End Function
End Class
