Public Class itmForce_Staff
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmFORCE_STAFF
    Me.EntityName = eEntity.itmFORCE_STAFF

    mDisplayName = "Force Staff"
    Description = ""
    mGoldCost = New ValueWrapper(2250)

    mMadeFromItems.Add(eItemname.itmRECIPE_FORCE_STAFF)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmRING_OF_REGEN)

    mCategory = eItemCategory.CASTER

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/force_staff_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(20)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(25)

    Description = "Active: Force - Pushes any target unit 600 units in the direction it is facing. Double click to self-cast."
    Notes = "Double clicking the item casts it on self.|Pushes the target at a speed of 1500.|The target is not disabled during the push, so it still can cast spells or items, attack and turn during the push.|It also means that it won't cancel channeling spells on the target.|However, it does cancel the user's channeling spells upon cast, since it's a single target spell. It's not the push itself canceling them.|Does not push units affected by a Chronosphere, Black Hole, Duel icon.png Duel, or an enemy Kinetic Field.|Can target any unit, except for wards and buildings. The only exception is Homing Missile.|Can force units over impassable terrain. Trees within 100 radius around the pushed target get destroyed during the push.|Can be cast on Roshan but with no effect, since Roshan is immune to forced movement." '
    ColorText = "Allows you to manipulate others, for good or evil."

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

    Dim intval As New modValue(10, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim hpregenval As New modValue(3, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)

    outmods.Add(hpregen)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Pushes any target unit 600 units in the direction it is facing. Double click to self-cast."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Force"
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
    affects.Add(eUnit.untSelf)
    affects.Add(eUnit.untAlliedHero)

    Dim unittargetmultiaffectsinfo = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active, affects)
    Dim forceval As New modValue(1, eModifierType.PushForward, occurencetime)

    Dim forcepush As New Modifier(forceval, unittargetmultiaffectsinfo)

    outmods.Add(forcepush)
    Return outmods
  End Function
End Class
