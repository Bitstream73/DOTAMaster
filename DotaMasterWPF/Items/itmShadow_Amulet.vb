Public Class itmShadow_Amulet
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSHADOW_AMULET
    Me.EntityName = eEntity.itmSHADOW_AMULET

    mDisplayName = "Shadow Amulet"
    'mDescription = ""
    mGoldCost = New ValueWrapper(1600)

    mBuildsToNames.Add(eItemname.itmSHADOW_BLADE)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/shadow_amulet_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(10)
    'mRadius = 
    'mCharges =

    Description = "Active: Fade - Grants invisibility to you or target allied hero over 1.5 seconds. Moving breaks the invisibility. There is no cooldown when using this item on yourself."
    Notes = "Does not interupt the user's channeling spells upon cast, neither when casting on self, nor when casting on allies.|When casting on allies, the user does not have to face the targeted ally to cast it. Does not interrupt the target's channeling spells.|During the fade time, the unit can still cast spells, use items and perform attacks.|After the fade time, the unit automatically stops moving or attacking, but it does not stop spell casts.|While invisible, the unit can turn and pick up or drop items without breaking the invisibility.|While invisible, the unit is phased, means other units can walk through it without getting blocked.|The invisibility is broken upon reaching the cast point of spells or items or upon performing an attack.|The repositioning effects of the following spells also break the invisibility:|Black Hole, Vacuum, Gust, Deafening Blast, Tornado, Power Cogs, Meat Hook, Adaptive Strike, Telekinesis, Primal Roar, Skewer, Flamebreak, Boulder Boulder Smash, Geomagnetic Grip, Greater Bash, Blinding Light, Electric Vortex, Toss, Cyclone, Snowball, Eul's Scepter of Divinity and Force Staff." '
    ColorText = ""

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

    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Grants invisibility to you or target allied hero over 1.5 seconds. Moving breaks the invisibility. There is no cooldown when using this item on yourself. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Fade"
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

    Dim pointtargetmultiaffects = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                        thecaster, _
                                                                        thetarget, _
                                                                        "", eModifierCategory.Active, affects)

    Dim invisval As New modValue(0, eModifierType.Invisibility, occurencetime)

    Dim invis As New Modifier(invisval, pointtargetmultiaffects)

    outmods.Add(invis)


    Dim moveval As New modValue(0, eModifierType.MuteMove, occurencetime)

    Dim nomove As New Modifier(moveval, pointtargetmultiaffects)

    outmods.Add(nomove)


    Dim abival As New modValue(0, eModifierType.MuteAbilities, occurencetime)

    Dim nocast As New Modifier(abival, pointtargetmultiaffects)

    outmods.Add(nocast)

    Return outmods
  End Function
End Class
