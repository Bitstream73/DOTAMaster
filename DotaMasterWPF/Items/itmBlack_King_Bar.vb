Public Class itmBlack_King_Bar
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBLACK_KING_BAR
    Me.EntityName = eEntity.itmBLACK_KING_BAR

    mDisplayName = "Black King Bar"
    'mDescription = "A powerful staff imbued with the strength of giants"
    mGoldCost = New ValueWrapper(3975)
    mMadeFromItems.Add(eItemname.itmRECIPE_BLACK_KING_BAR)
    mMadeFromItems.Add(eItemname.itmOGRE_CLUB)
    mMadeFromItems.Add(eItemname.itmMITHRIL_HAMMER)


    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/black_king_bar_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(80)
    'mRadius = 
    Charges = New ValueWrapper(7)
    'mDuration =
    'mManaCost = 
    Description = "Active: Avatar - Grants Spell Immunity and 100% Magic Damage Resistance. Duration and cooldown decrease with each use. Some Ultimate abilities are able to disable through Black King Bar."
    Notes = "Interupts the owner's channeling spells upon cast.|The spell immunity dispels many buffs and debuffs upon getting applied.|List of removed buffs and debuffs can be found here.|For more details, including a list of spells which are not blocked, see Spell immunity." '
    ColorText = "A powerful staff imbued with the strength of giants."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                                  owner As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinfo As New modInfo(eAbilityType.Passive, _
                                          theitem_InfoID, _
                                          owner, _
                                          Nothing,
                                          eUnit.untSelf, _
                                          "", eModifierCategory.Passive)

    Dim strval As New modValue(10, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)

    Dim unittargetenemytargetinfo As New modInfo(eAbilityType.UnitTarget, _
                                                   theitem_InfoID, _
                                                   owner, _
                                                   thetarget, _
                                                   eUnit.untEnemyTarget, _
                                                   "", eModifierCategory.Passive)


    Dim damval As New modValue(24, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, passiveselfinfo)

    outmods.Add(damage)

    Return outmods

  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Grants magic immunity. Duration and cooldown decrease with each use. Some Ultimate abilities are able to disable through Black King Bar."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Avatar"
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

    Dim dur1 As New ValueWrapper(10)
    Dim timeval1 As New modValue(dur1, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval1.mValueDuration = dur1 'New ValueWrapper(10) 'New TimeSpan(0, 0, 10)

    Dim charge1 As New Modifier(timeval1, notargetselfinfo)
    outmods.Add(charge1)


    Dim dur2 As New ValueWrapper(9)
    Dim timeval2 As New modValue(dur2, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval2.mValueDuration = dur2 'New ValueWrapper(9) 'New TimeSpan(0, 0, 9)
    Dim charge2 As New Modifier(timeval2, notargetselfinfo)
    outmods.Add(charge2)

    Dim dur3 As New ValueWrapper(8)
    Dim timeval3 As New modValue(dur3, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval3.mValueDuration = dur3 'New ValueWrapper(8) 'New TimeSpan(0, 0, 8)
    Dim charge3 As New Modifier(timeval3, notargetselfinfo)
    outmods.Add(charge3)

    Dim dur4 As New ValueWrapper(7)
    Dim timeval4 As New modValue(dur4, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval4.mValueDuration = dur4 'New ValueWrapper(7) 'New TimeSpan(0, 0, 7)
    Dim charge4 As New Modifier(timeval4, notargetselfinfo)
    outmods.Add(charge4)

    Dim dur5 As New ValueWrapper(6)
    Dim timeval5 As New modValue(dur5, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval5.mValueDuration = dur5 'New ValueWrapper(6) 'New TimeSpan(0, 0, 6)
    Dim charge5 As New Modifier(timeval5, notargetselfinfo)
    outmods.Add(charge5)

    Dim dur6 As New ValueWrapper(5)
    Dim timeval6 As New modValue(dur6, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval6.mValueDuration = dur6 'New ValueWrapper(5) 'New TimeSpan(0, 0, 5)
    Dim charge6 As New Modifier(timeval6, notargetselfinfo)
    outmods.Add(charge6)

    Dim dur7 As New ValueWrapper(4)
    Dim timeval7 As New modValue(dur7, eModifierType.MagicImmunity, occurencetime, aghstime)
    timeval7.mValueDuration = dur7 'New ValueWrapper(4) 'New TimeSpan(0, 0, 4)
    Dim charge7 As New Modifier(timeval7, notargetselfinfo)
    outmods.Add(charge7)

    Return outmods

  End Function
End Class
