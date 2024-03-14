Public Class itmRadiance
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmRADIANCE
    Me.EntityName = eEntity.itmRADIANCE

    mDisplayName = "Radiance"
    'mDescription = "A divine weapon that causes damage and a bright burning effect that lays waste to nearby enemies. "
    mGoldCost = New ValueWrapper(5150)
    mMadeFromItems.Add(eItemname.itmRECIPE_RADIANCE)
    mMadeFromItems.Add(eItemname.itmSACRED_RELIC)


    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/radiance_lg.png"
    mTier =
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    'mCooldown = 
    Radius = New ValueWrapper(700)
    'mCharges =
    'mDuration =
    'mManaCost = 


    Description = "Active: Toggles Burn Damage on or off.|Passive: Burn Damage - Deals damage per second in a 700 radius."
    Notes = "Does not interupt the owner's channeling spells upon toggling.|Burn Damage is provided by an aura, its debuff lingers for 0.5 seconds.|This means after leaving the radius, enemies can still be damaged by up to one tick.|Deals damage in 1 second intervals, starting 1 second after the debuff is placed.|Burn Damage of multiple Radiance do not stack. Only the first applied debuff deals damage.|Does not affect ancient creeps, Roshan, Warlock icon.png Warlock's Golem and Storm and Fire from Primal Split." '
    ColorText = "A divine weapon that causes damage and a bright burning effect that lays waste to nearby enemies."
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

    Dim damval As New modValue(65, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Toggles Burn Damage on or off. Deals damage per second in a 700 radius. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Burn Damage"
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

    Dim auraenemyunitsinfo = Helpers.GetPassiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim dps As New modValue(50, eModifierType.damagePerSecond, occurencetime)
    dps.mValueInterval = New ValueWrapper(1) 'New TimeSpan(0, 0, 1)

    Dim burndamage As New Modifier(dps, auraenemyunitsinfo)
    outmods.Add(burndamage)
    Return outmods
  End Function
End Class
