Public Class itmMjolnir
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMJOLLNIR
    Me.EntityName = eEntity.itmMJOLLNIR

    mDisplayName = "Mjollnir"
    Description = "Thor's magical hammer, made for him by the dwarves Brok and Eitri.|Passive: Chain Lightning - Grants a chance on attack to release a Chain Lightning that hits 8 targets, dealing damage.|Mjollnir is a Unique Attack Modifier that stacks with other Unique Attack Modifiers, but overrides them when Chain Lightning occurs."
    mGoldCost = New ValueWrapper(5600)
    mMadeFromItems.Add(eItemname.itmRECIPE_MJOLLNIR)
    mMadeFromItems.Add(eItemname.itmHYPERSTONE)
    mMadeFromItems.Add(eItemname.itmMAELSTROM)

    mCategory = eItemCategory.ARTIFACTS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/mjollnir_lg.png"
    mTier = 3
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(35)
    Radius = New ValueWrapper(900)
    'mCharges =
    Duration = New ValueWrapper(15)
    ManaCost = New ValueWrapper(50)

    Description = "Active: Static Charge - Places a charged shield on a target unit which has a 20% chance to release a shocking bolt at a nearby attacker and 4 additional enemies.|Passive: Chain Lightning - Grants a chance on attack to release a Chain Lightning that hits 8 targets, dealing damage.|Mjollnir is a Unique Attack Modifier that stacks with other Unique Attack Modifiers, but overrides them when Chain Lightning occurs."
    Notes = "Double clicking the item casts it on self.|Successive casts on the same allied unit have no effect, wasting the mana and cooldown. The buff is not refreshed.|The search radius is centered around the shielded unit. When it procs, the proccing unit and 4 random enemy units within the radius are hit.|Lightnings cannot trigger more than once per second.|Does not trigger on the damage from Heartstopper Aura, Dispersion, Poison Sting, Corrosive Skin, Fatal Bonds.|Fully ignores HP removal and self afflicted damage.|Each Mjollnir in the inventory has an independent chance to proc. If 2 or more proc on one attack, only one chain lightning is released.|The same applies to Maelstrom and Mjollnir in the same inventory. When both proc on the same hit, Mjollnir has priority.|The lightning bounces in 0.25 second intervals, so hitting 8 targets takes 1.75 seconds.|Does not bounce on invisible units or units in the Fog of War.|Can never hit the same unit twice per proc.|All bounces together can deal up to 1200 damage (before reductions)." '
    ColorText = "Thor's magical hammer, made for him by the dwarves Brok and Eitri."

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

    Dim attspeedval As New modValue(80, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(24, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)


    Dim chaininfo = Helpers.GetPointTargetEnemyUnitsInfo(theitem_InfoID, _
                                                         theownerid, _
                                                         thetarget, _
                                                         "", eModifierCategory.Passive)

    'damage for one of the 8 chainlightnings
    Dim chaindamval As New modValue(150, eModifierType.DamageChainPhysicalInflicted, occurencetime)
    chaindamval.mPercentChance = New ValueWrapper(0.25)
    chaindamval.Charges = New ValueWrapper(8)
    Dim ChainLightningDamage As New Modifier(chaindamval, chaininfo)

    outmods.Add(ChainLightningDamage)



    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Places a charged shield on a target unit which has a 20% chance to release a shocking bolt at a nearby attacker and 4 additional enemies."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Static Charge"
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

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)


    Dim damval As New modValue(200, eModifierType.DamagePhysicalAdded, occurencetime)
    damval.mPercentChance = New ValueWrapper(0.2)

    Dim staticdamage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(staticdamage)



    Return outmods
  End Function
End Class
