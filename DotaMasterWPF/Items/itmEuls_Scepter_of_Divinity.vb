Public Class itmEuls_Scepter_of_Divinity
  Inherits ItemBase



  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmEULS_SCEPTER_OF_DIVINITY
    Me.EntityName = eEntity.itmEULS_SCEPTER_OF_DIVINITY

    mDisplayName = "Eul's Scepter of Divinity"
    Description = "A mysterious scepter passed down through the ages, its disruptive winds can be used for good or evil.|Flat movement speed bonuses from multiple Eul's Scepters do not stack."
    mGoldCost = New ValueWrapper(2700)

    mMadeFromItems.Add(eItemname.itmRECIPE_EULS_SCEPTER_OF_DIVINITY)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmSAGES_MASK)
    mMadeFromItems.Add(eItemname.itmVOID_STONE)

    mCategory = eItemCategory.CASTER

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/cyclone_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(23)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(75)

    Description = "Active: Cyclone - A target unit is swept up in a cyclone and made invulnerable for 2.5 seconds. Cyclone can be cast on yourself. Enemy units take 50 magical damage upon landing."
    Notes = "Double clicking the item casts it on self.|Can only target enemies or self. Can not target allies. Can also not target siege creeps, wards and buildings.|Applies a cyclone effect on the target upon cast, so it dispels, turns it invulnerable and fully disables it.|Cycloned units lose their collision size for the duration, so units can path below them.|The damage is applied at the end of the duration. If the cyclone gets purged, it still applies the damage as soon as the target lands.|Does not damage self.|Can be cast on Roshan, but has no effect, since Roshan is immune to forced movement." '
    ColorText = "A mysterious scepter passed down through the ages, its disruptive winds can be used for good or evil."

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


    Dim manaregenval As New modValue(1.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)


    Dim movespeedval As New modValue(40, eModifierType.MoveSpeedAdded, occurencetime)

    Dim movespeed As New Modifier(movespeedval, passiveselfinfo)

    outmods.Add(movespeed)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "A target unit is swept up in a cyclone and made invulnerable for 2.5 seconds. Cyclone can be cast on yourself. Enemy units take 50 magical damage upon landing."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Cyclone"
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
    affects.Add(eUnit.untUnitTarget)


    Dim unittargetmultiaffectsinfo = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active, affects)

    Dim cycval As New modValue(2.5, eModifierType.Cyclone, occurencetime)

    cycval.mValueDuration = New ValueWrapper(2.5)

    Dim cyclone As New Modifier(cycval, unittargetmultiaffectsinfo)

    outmods.Add(cyclone)

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim damval As New modValue(50, eModifierType.DamageMagicalAdded, occurencetime)

    Dim enemytargetdamage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(enemytargetdamage)


    Return outmods
  End Function
End Class
