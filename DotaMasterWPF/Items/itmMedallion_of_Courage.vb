Public Class itmMedallion_of_Courage
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMEDALLION_OF_COURAGE
    Me.EntityName = eEntity.itmMEDALLION_OF_COURAGE

    mDisplayName = "Medallion of Courage"
    ' mDescription = "The bearer has no fear of combat. "
    mGoldCost = New ValueWrapper(1075)
    mMadeFromItems.Add(eItemname.itmRECIPE_MEDALLION_OF_COURAGE)
    mMadeFromItems.Add(eItemname.itmCHAINMAIL)
    mMadeFromItems.Add(eItemname.itmSAGES_MASK)

    mCategory = eItemCategory.SUPPORT

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/medallion_of_courage_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(7)
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Active: Valor - If cast on an ally, increases their armor while reducing the caster's. If cast on an enemy, reduces the armor of both the enemy and the caster. Lasts 7 seconds."
    Notes = "The debuff on self and the buff on allies/debuff on enemies are independent from each other. Dispeling one does not dispel both.|A unit can be affected by the buff and the debuff at the same cast, but not by multiple buffs or debuffs from it.|This means when an enemy casts it on you and you it on an enemy, the debuffs refresh each other.|But when an enemy and an ally casts it on you, you receive the buff and the debuff, both independent from each other.|Can be cast on any unit, except on wards and buildings. Can target siege creeps." '
    ColorText = "The bearer has no fear of combat."

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


    Dim armorval As New modValue(6, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)


    Dim manaregenval As New modValue(0.5, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenval, passiveselfinfo)

    outmods.Add(manaregen)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return " Reduces the armor of you and your target. Lasts 7 seconds. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Valor"
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


    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim armval As New modValue(6, eModifierType.ArmorAdded, occurencetime)

    Dim armorreductionself As New Modifier(armval, notargetselfinfo)

    outmods.Add(armorreductionself)


    Dim enemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                           thecaster, _
                                                           thetarget, _
                                                           "", eModifierCategory.Active)

    Dim negarmval As New modValue(6, eModifierType.ArmorSubtracted, occurencetime)

    Dim armorreductionenemytarget As New Modifier(negarmval, enemytarget)

    outmods.Add(armorreductionenemytarget)

    Return outmods
  End Function
End Class
