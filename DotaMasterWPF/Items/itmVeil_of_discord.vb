Public Class itmVeil_of_discord
  Inherits ItemBase

  Public Sub New(theparent As iDisplayUnit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)

    mName = eItemname.itmVEIL_OF_DISCORD
    Me.EntityName = eEntity.itmVEIL_OF_DISCORD

    mDisplayName = "Veil of Discord"
    'mDescription = "The headwear of corrupt magi."
    mGoldCost = New ValueWrapper(2675)
    mMadeFromItems.Add(eItemname.itmRECIPE_VEIL_OF_DISCORD)
    mMadeFromItems.Add(eItemname.itmHELM_OF_IRON_WILL)
    mMadeFromItems.Add(eItemname.itmNULL_TALISMAN)

    mCategory = eItemCategory.CASTER
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/veil_of_discord_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    Radius = New ValueWrapper(600)
    'mCharges =
    Duration = New ValueWrapper(25)
    ManaCost = New ValueWrapper(75)

    Description = "Active: Magic Weakness - Emits a weakening blast that increases the magic damage enemies take. Lasts 25.0 seconds."
    Notes = "Places a debuff on enemy units in the area upon cast. Leaving or entering the area afterwards has no effect.|Multiple casts on the same targets do not stack, but refresh the duration instead.|Reduces most heroes' magic resistance down to 6.25%, if they don't have any other source of magic resistance.|Reduces Meepo's magic resistance down to 18.75% and Visage's magic resistance down to -12.5%, if they don't have any other source of magic resistance." '
    ColorText = "The headwear of corrupt magi."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                                    theownerid As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim hpregenval As New modValue(6, eModifierType.HPRegenAdded, occurencetime)
    Dim hpregen As New Modifier(hpregenval, passiveselfinfo)
    outmods.Add(hpregen)

    Dim strval As New modValue(6, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(6, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)



    Dim agival As New modValue(6, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)



    Dim damval As New modValue(6, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, passiveselfinfo)

    outmods.Add(damage)



    Dim armorval As New modValue(6, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Emits a weakening blast that increases the magic damage enemies take. Lasts 25.0 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Magic Weakness"
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

    Dim auraenemiesinfo = Helpers.GetActiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                              thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim magval As New modValue(0.25, eModifierType.MagicResistancePercentSubtracted, occurencetime)

    Dim magicweakness As New Modifier(magval, auraenemiesinfo)

    outmods.Add(magicweakness)


    Return outmods
  End Function
End Class
