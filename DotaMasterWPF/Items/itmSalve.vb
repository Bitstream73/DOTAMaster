Public Class itmSalve
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmHEALING_SALVE
    Me.EntityName = eEntity.itmHEALING_SALVE

    mDisplayName = "Salve"
    ' mDescription = "A magical salve that can quickly mend even the deepest of wounds."
    mGoldCost = New ValueWrapper(115)

    mCategory = eItemCategory.CONSUMABLES
    mSoldFrom.Add(eShopTypes.Fountain)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/flask_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    Charges = New ValueWrapper(1)

    Description = "Use: Regenerate - Restores HP on the target unit over time. If the unit is attacked, the effect is lost. "
    Notes = "Double clicking the item uses it on self.|Successive casts on the same target do not stack, but refresh the duration instead.|Restores health in form of health regeneration, so it heals for 0.4 health in 0.01 second intervals, which is 40 health per second.|Is dispelled by any damage greater than 20 (before reductions), including self afflicted damage.|Is not dispelled by health cost of spells, health manipulating spells, negative regeneration, Poison Sting and Dispersion.|Is always dispelled by attacks, even when the attack dealt no damage.|Fully stacks with other health regeneration increasing effects." '
    ColorText = "A magical salve that can quickly mend even the deepest of wounds."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Restores HP on the target unit over time. If the unit is attacked, the effect is lost."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Regenerate"
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
    Dim affected As New List(Of eUnit)

    affected.Add(eUnit.untSelf)
    affected.Add(eUnit.untAlliedHero)

    Dim unittargetmultiaffectinfo = Helpers.GetUnitTargetMultiAffectsInfo(theitem_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "", eModifierCategory.Active, affected)
    Dim healval As New modValue(400, eModifierType.HPoT, occurencetime)

    Dim healmod As New Modifier(healval, unittargetmultiaffectinfo)

    outmods.Add(healmod)

    Return outmods
  End Function
End Class
