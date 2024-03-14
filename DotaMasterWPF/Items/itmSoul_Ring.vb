Public Class itmSoul_Ring
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSOUL_RING
    Me.EntityName = eEntity.itmSOUL_BOOSTER

    mDisplayName = "Soul Ring"
    'mDescription = "A ring that feeds on the souls of those around it. "
    mGoldCost = New ValueWrapper(800)

    mMadeFromItems.Add(eItemname.itmRECIPE_SOUL_RING)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)
    mMadeFromItems.Add(eItemname.itmSAGES_MASK)

    mCategory = eItemCategory.COMMON

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/soul_ring_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    'mRadius = 
    'mCharges =

    Description = "Active: Sacrifice - Consume 150 HP to temporarily gain 150 Mana. Lasts 10 seconds."
    Notes = "Interupts the user's channeling spells upon cast.|If the added 150 mana would exceed the user's current mana pool, its maximum mana pool is temporarily increased by the exceeding amount.|At the end of the duration, the user loses any of the unused mana of the 150 mana and its maximum mana pool goes back to normal if it was exceeded.|Only counts actually spent mana. Mana lost on other ways (Mana Break, Mana Burn) does not count.|The lost health is not gained back when the gained mana was unused or partly unused.|The 150 health lost upon cast is never lethal. When casting with less than 150 health, the user's health goes down to 1." '
    ColorText = "A ring that feeds on the souls of those around it. "

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


    Dim hpregenval As New modValue(3, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)


    Dim manaregenval As New modValue(0.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Consume 150 HP to temporarily gain 150 Mana. Lasts 10 seconds. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Sacrifice"
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


    Dim hplossval As New modValue(150, eModifierType.DamagePureAdded, occurencetime)

    Dim hploss As New Modifier(hplossval, notargetselfinfo)

    outmods.Add(hploss)


    'Dim notargetselfinfo2 = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
    '                                                   thecaster, _
    '                                                   thetarget, _
    '                                                   "", eModifierCategory.Active)

    Dim manaaddval As New modValue(150, eModifierType.MaxManaAdded, occurencetime)

    Dim managain As New Modifier(manaaddval, notargetselfinfo)

    outmods.Add(managain)

    Return outmods
  End Function
End Class
