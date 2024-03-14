Public Class itmLinkins_Sphere
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmLINKENS_SPHERE
    Me.EntityName = eEntity.itmLINKENS_SPHERE

    mDisplayName = "Linken's Sphere"
    ' mDescription = "This magical sphere once protected one of the most famous heroes in history. "
    mGoldCost = New ValueWrapper(5175)
    mMadeFromItems.Add(eItemname.itmRECIPE_LINKENS_SPHERE)
    mMadeFromItems.Add(eItemname.itmULTIMATE_ORB)
    mMadeFromItems.Add(eItemname.itmPERSEVERANCE)


    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/sphere_lg.png"
    mTier = 3
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(17)
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManaCost = 

    Description = "Spellblock - Passively blocks most targeted spells once every 17 seconds. Can be cast on an allied unit to temporarily transfer the buff."
    Notes = "Still works while the owner's inventory is muted." '
    ColorText = "This magical sphere once protected one of the most famous heroes in history."

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


    Dim strval As New modValue(15, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(15, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(15, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim manaregenval As New modValue(1.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)

    Dim spellval As New modValue(1, eModifierType.SpellBlock, occurencetime)

    Dim spellblock As New Modifier(spellval, passiveselfinfo)

    outmods.Add(spellblock)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(10, eModifierType.DamagePhysicalAdded, occurencetime)
    Dim damage As New Modifier(damval, unittargetenemytargetinfo)
    outmods.Add(damage)



    Return outmods
  End Function
  Public Overrides Property AbilityDescription As String
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return ""
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
    Return New ModifierList

  End Function

End Class
