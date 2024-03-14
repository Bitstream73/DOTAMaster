Public Class itmEthereal_Blade
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmETHEREAL_BLADE
    Me.EntityName = eEntity.itmETHEREAL_BLADE

    mDisplayName = "Ethereal Blade"
    ' mDescription = "A flickering blade of a ghastly nature, it is capable of dealing damage in both magical and physical planes. "
    mGoldCost = New ValueWrapper(4900)
    mMadeFromItems.Add(eItemname.itmEAGLESONG)
    mMadeFromItems.Add(eItemname.itmGHOST_SCEPTER)

    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/ethereal_blade_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(150)

    Description = "Active: Ether Blast - Launches a projectile which converts your target into ethereal form, increasing incoming magic damage. Target unit is slowed and cannot attack or be attacked, and takes 2.0x of your primary attribute + 75 as damage."
    Notes = "Double clicking the item casts it on self.|The projectile travels at a speed of 1200 and can be disjointed.|Damage and slow is only applied when targeting an enemy unit.|Applies the ethereal effect before dealing its own damage, effectively increasing the damage.|Reduces most heroes' total magic resistance to -5%, (assuming basic 25% magic resistance).|Reduces Meepo's total magic resistance to 9% and Visage's total magic resistance to -26%.|Does stack with magic amplification or movement speed slows of other sources, except with other ethereal effects.|Gets dispelled when the target starts channeling a Town Portal Scroll, but not when starting channeling Boots of Travel.|However, on enemies, the slow is not dispelled. Only the ethereal form and magic resistance reduction is dispelled by the scrolls.|Dispels Ensnare on the target for its duration.|Shares cooldown with Ghost Scepter." '
    ColorText = "A flickering blade of a ghastly nature, it is capable of dealing damage in both magical and physical planes."

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

    Dim agival As New modValue(40, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim strval As New modValue(10, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(10, eModifierType.IntAdded, occurencetime)
    Dim intmod As New Modifier(intval, passiveselfinfo)
    outmods.Add(intmod)



    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Converts you and your target into ethereal form, increasing incoming magic damage. Target unit is slowed and cannot attack or be attacked, and takes 2.0x of your primary attribute + 75 as damage. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Ether Blase"
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

    Dim affects As New List(Of eUnit)
    affects.Add(eUnit.untAlliedHero)
    affects.Add(eUnit.untEnemyTarget)

    Dim unittargetmultiaffects = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active, affects)

    Dim moveval As New modValue(0.8, eModifierType.MoveSpeedPercentSubtracted, occurencetime)

    Dim moveslow As New Modifier(moveval, unittargetmultiaffects)

    outmods.Add(moveslow)


    Dim eval As New modValue(3, eModifierType.Ethereal_Time, occurencetime)
    eval.mValueDuration = New ValueWrapper(3)

    Dim enemyetherealform As New Modifier(eval, unittargetmultiaffects)
    outmods.Add(enemyetherealform)

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim evalw As New modValue(4, eModifierType.Ethereal_Time, occurencetime)
    evalw.mValueDuration = New ValueWrapper(4)

    Dim selfetherealform As New Modifier(evalw, notargetselfinfo)

    outmods.Add(selfetherealform)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim magicdamval As New modValue(75, eModifierType.DamageMagicalAdded, occurencetime)

    Dim etherealbasedamage As New Modifier(magicdamval, unittargetenemytargetinfo)

    outmods.Add(etherealbasedamage)



    Dim damval As New modValue(2, eModifierType.PrimaryStatDamageAdded, occurencetime)

    Dim etherealstatdamage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(etherealbasedamage)



    Return outmods
  End Function
End Class
