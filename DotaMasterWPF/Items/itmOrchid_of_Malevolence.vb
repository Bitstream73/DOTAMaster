Public Class itmOrchid_of_Malevolence
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmORCHID_MALEVOLENCE
    Me.EntityName = eEntity.itmORCHID_MALEVOLENCE

    mDisplayName = "Orchid of Malevolence"
    'mDescription = "A garnet rod constructed from the essence of a fire demon."
    mGoldCost = New ValueWrapper(5025)
    mMadeFromItems.Add(eItemname.itmRECIPE_ORCHID_MALEVOLENCE)
    mMadeFromItems.Add(eItemname.itmOBLIVION_STAFF)
    mMadeFromItems.Add(eItemname.itmOBLIVION_STAFF)

    mCategory = eItemCategory.CASTER
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/orchid_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(18)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(5)
    ManaCost = New ValueWrapper(100)

    Description = "A garnet rod constructed from the essence of a fire demon."
    Notes = "Does not directly amplify damage as it is dealt, but rather saves all damage values and deals 30% of it 5 seconds after cast.|This means that the damage can be avoided by turning immune to magic damage at the end of the duration.|The damage is applied exactly 5 seconds after cast when the target has the debuff on. The damage is not directly bound to the debuff.|So removing the debuff prematurely will also prevent it from damaging, since the conditions are not met anymore.|Only considers magical, physical and pure damage (after all reductions). Other sources of health loss are ignored.|Successfive casts on the same target do not stack, but only refresh the silence duration.|The damage amplifaction is not refreshed. It will deal damage 5 seconds after the first cast. Following casts will not amplify or deal damage." '
    ColorText = "Active: Soul Burn - Silences target unit for 5.0 seconds and amplifies the damage it takes by 30.0%."

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

    Dim intval As New modValue(2, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)

    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)

    Dim manaval As New modValue(1.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaval, passiveselfinfo)

    outmods.Add(manaregen)

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(30, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Silences target unit for 5.0 seconds and amplifies the damage it takes by 30.0%."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Soul Burn"
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

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim silencenval As New modValue(5, eModifierType.Silence, occurencetime)
    silencenval.mValueDuration = New ValueWrapper(5)

    Dim silence As New Modifier(silencenval, unittargetenemytargetinfo)

    outmods.Add(silence)


    Dim damageampval As New modValue(1.3, eModifierType.DamageAmplification, occurencetime)

    Dim damageamp As New Modifier(damageampval, unittargetenemytargetinfo)

    outmods.Add(damageamp)


    Return outmods
  End Function
End Class
