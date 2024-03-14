Public Class itmQuelling_Blade
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmQUELLING_BLADE
    Me.EntityName = eEntity.itmQUELLING_BLADE

    mDisplayName = "Quelling Blade"
    'mDescription = "The axe of a fallen gnome, it allows you to effectively maneuver the forest. Passive: Quell - Gives bonus attack damage against non-hero units, depending on the type of hero you are.  "
    mGoldCost = New ValueWrapper(225)

    mCategory = eItemCategory.ARMAMENTS
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/quelling_blade_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(5)
    'mRadius

    Description = "Active: Destroy Tree/Ward - Destroy a target tree, or deals 100 damage to a ward.|Passive: Quell - Gives bonus attack damage against non-hero units, based on whether the equipped hero is ranged or melee. "
    Notes = "Can only target trees (including Sprout trees) and enemy Observer Wards and Sentry Wards.|Quell is not a Unique Attack Modifier.|When the owner's attack type changes to ranged or melee, the attack damage bonus adapts immediately.|Quell fully stacks with other attack damage increasing effects. It also fully works with crits.|When having cleave, attacking a creep cleaves the increased damage in the area.|The only exception here is Tidebringer, where the increased damage is only applied to the primary attack target.|Elder Dragon Form's splash also splashes the increased damage when attacking a creep.|Moon Glaive bounces deal increased damage when bouncing on creeps. On each bounce, the glaive checks if the target is a hero or not. If it's not, then it deals increased damage.|Psi Blades will spread the increased damage when attacking a creep.|Does not work against wards, buildings, Lone Druid's Spirit Bear and allied units. Works against Roshan." '
    ColorText = "The axe of a fallen gnome, it allows you to effectively maneuver the forest. "
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passivenonherounitinfo = Helpers.GetPassiveEnemyCreepInfo(theitem_InfoID, _
                                                                  theownerid, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Passive)

    Dim meleval As New modValue(0.32, eModifierType.DamageMeleemultiplier, occurencetime)

    Dim meleedam As New Modifier(meleval, passivenonherounitinfo)

    outmods.Add(meleedam)


    Dim range As New modValue(0.12, eModifierType.DamageRangemultiplier, occurencetime)

    Dim rangedam As New Modifier(range, passivenonherounitinfo)

    outmods.Add(rangedam)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Destroy Tree/Ward - Destroy a target tree, or deals 100 damage to a ward."
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

    Dim targettreeinfo = Helpers.GetUnitTargetTreeInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim destryval As New modValue(1, eModifierType.DestroysTree, occurencetime)

    Dim treemod As New Modifier(destryval, targettreeinfo)

    outmods.Add(treemod)



    Dim affected As New List(Of eUnit)
    affected.Add(eUnit.untObserver_Ward)
    affected.Add(eUnit.untSentry_Ward)

    Dim unittargetmultiaffectsinfo = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active, affected)
    Dim melee As New modValue(100, eModifierType.DamageMeleeAdded, occurencetime)

    Dim obsmod As New Modifier(melee, unittargetmultiaffectsinfo)

    outmods.Add(obsmod)

    Return outmods
  End Function
End Class
