Public Class itmUrn_of_Shadows
  Inherits ItemBase


  Public Sub New(theparent As iDisplayUnit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmURN_OF_SHADOWS
    Me.EntityName = eEntity.itmURN_OF_SHADOWS

    mDisplayName = "Urn of Shadows"
    Description = "Contains the ashes of powerful demons.|Gains charges every time an enemy hero dies within 1400 units. Only the closest Urn to the dying hero will gain a charge."
    mGoldCost = New ValueWrapper(875)
    mMadeFromItems.Add(eItemname.itmRECIPE_URN_OF_SHADOWS)
    mMadeFromItems.Add(eItemname.itmSAGES_MASK)
    mMadeFromItems.Add(eItemname.itmGAUNTLETS_OF_STRENGTH)
    mMadeFromItems.Add(eItemname.itmGAUNTLETS_OF_STRENGTH)


    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)


    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/urn_of_shadows_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(7)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(8)
    'mManacost = 

    Description = "Gains charges every time an enemy hero dies within 1400 units. Only the closest Urn to the dying hero will gain a charge.|Active: Soul Release - Heals HP over time to friendly units, but deals pure damage over time to enemy units. The healing effect is lost if the affected unit takes damage from an enemy hero or tower. "
    Notes = "Double clicking the item uses it on self.|Successive casts on the same allied target do not stack, but refresh the duration instead.|However, successive casts on enemy targets fully stack and work independent from each other.|Heals 12.5 health in 0.25 second intervals, resulting in 32 heal instances.|Deals 18.75 damage in 1 second intervals, resulting in 8 damage instances.|The heal is dispelled by any damage coming from players (before reductions), including self afflicted damage, and from towers.|Roshan and the Fountain attacks do not dispel the heal.|Is not dispelled by health cost of spells, health manipulating spells, negative regeneration, Poison Sting and Dispersion.|Can be cast on illusions, Lone Druid's Spirit Bear, Visage's Familiars, Warlock's Golem and the Primal Split spirits." '
    ColorText = "Contains the ashes of powerful demons."

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

    Dim manaval As New modValue(0.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaval, passiveselfinfo)

    outmods.Add(manaregen)

    Dim strval As New modValue(6, eModifierType.StrAdded, occurencetime)

    Dim str As New Modifier(strval, passiveselfinfo)

    outmods.Add(str)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Heals HP over time for friendly units, but deals damage over time for enemy units. The healing effect is lost if the affected unit takes damage from an enemy hero or tower. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Soul Release"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                              thecaster As iDisplayUnit, _
                              thetarget As iDisplayUnit, _
                              ftarget As iDisplayUnit, _
                              isfriendbias As Boolean, _
                              occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim activeauraself = Helpers.GetActiveAuraSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim healval As New modValue(400, eModifierType.HPoT, occurencetime)
    healval.mValueDuration = New ValueWrapper(8)

    Dim healself As New Modifier(healval, activeauraself)
    outmods.Add(healself)



    Dim activeauraallies = Helpers.GetActiveAuraAlliedUnitsInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim healalliedunits As New Modifier(healval, activeauraallies)

    outmods.Add(healalliedunits)



    Dim activeauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim damval As New modValue(400, eModifierType.DamagePhysicaloT, occurencetime)
    damval.mValueDuration = New ValueWrapper(8)

    Dim damage As New Modifier(damval, activeauraenemies)

    Return outmods
  End Function
End Class
