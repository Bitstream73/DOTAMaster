Public Class itmAbyssal_Blade_1
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmABYSSAL_BLADE
    Me.EntityName = eEntity.itmABYSSAL_BLADE


    mDisplayName = "Abyssal Blade"
    'mColorText = "The lost blade of the Commander of the Abyss, this edge cuts into an enemy's soul. "
    mGoldCost = New ValueWrapper(6750)
    mMadeFromItems.Add(eItemname.itmSKULL_BASHER)
    mMadeFromItems.Add(eItemname.itmSACRED_RELIC)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)
    'mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/abyssal_blade_lg.png"
    mTier =
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(60)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(1.4)
    ManaCost = New ValueWrapper(150)

    Description = "Active: Stun a target enemy unit for 2.0 seconds. Goes through Spell Immunity. Passive: Bash - Gives a chance to stun for 1.4 seconds."
    Notes = "Multiple Bash sources do not stack, except with the mini-bash from Monkey King Bar|If both proc on the same hit, the one with the longer stun occurs, which always is Skull Basher."
    ColorText = "The lost blade of the Commander of the Abyss, this edge cuts into an enemy's soul." 'FixFixFix

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveselfinfo As New modInfo(eAbilityType.Passive, _
                                        theitem_InfoID, _
                                        theownerid, _
                                        Nothing,
                                        eUnit.untSelf, _
                                        "", eModifierCategory.Passive)

    Dim strval As New modValue(2, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim unittargetenemytargetinfo As New modInfo(eAbilityType.UnitTarget, _
                                                   theitem_InfoID, _
                                                   theownerid, _
                                                   thetarget, _
                                                   eUnit.untEnemyTarget, _
                                                   "", eModifierCategory.Passive)

    Dim stunval As New modValue(0, eModifierType.MeleeStun, occurencetime)
    stunval.mPercentChance = New ValueWrapper(0.25)

    Dim meleestunchance As New Modifier(stunval, unittargetenemytargetinfo)

    outmods.Add(meleestunchance)


    Dim rangeval As New modValue(0, eModifierType.RangeStun, occurencetime)
    rangeval.mPercentChance = New ValueWrapper(0.1)

    Dim rangestunchance As New Modifier(rangeval, unittargetenemytargetinfo)

    outmods.Add(rangestunchance)



    Dim damval As New modValue(30, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Stun a target enemy unit for 2.0 seconds. Goes through Magic Immunity. "
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

    Dim dur As New ValueWrapper(2)
    Dim stunval As New modValue(dur, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = dur 'New ValueWrapper(2)

    Dim stun As New Modifier(stunval, unittargetenemytargetinfo)

    outmods.Add(stun)

    Return outmods
  End Function
End Class
