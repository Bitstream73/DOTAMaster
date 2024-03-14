Public Class itmShivas_Guard
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSHIVAS_GUARD
    Me.EntityName = eEntity.itmSHIVAS_GUARD

    mDisplayName = "Shiva's Guard"
    Description = "Said to have belonged to a goddess, today it retains much of its former power.|Passive: Freezing Aura - Reduces attack speed on enemies.|Multiple instances of Freezing Aura do not stack. "
    mGoldCost = New ValueWrapper(4700)
    mMadeFromItems.Add(eItemname.itmRECIPE_SHIVAS_GUARD)
    mMadeFromItems.Add(eItemname.itmMYSTIC_STAFF)
    mMadeFromItems.Add(eItemname.itmPLATEMAIL)


    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/shivas_guard_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = True
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(30)
    Radius = New ValueWrapper(900)
    'mCharges =
    Duration = New ValueWrapper(4)
    ManaCost = New ValueWrapper(100)

    Description = "Active: Arctic Blast - Emits a freezing wave that does 200 damage to enemies and slows their movement by -40% for 4.0 seconds.|Passive: Freezing Aura - Reduces attack speed on enemies.|Multiple instances of Freezing Aura do not stack. "
    Notes = "Does not interupt the owner's channeling spells upon cast.|The blast spreads at a speed of 350.||The area of effect is centered around the owner, so when moving, the radius moves along.|The blast is not a ring. It affects every unit between the blast's edge and the caster.|This means it is not possible to avoid the blast by blinking towards the caster.|Provides 800 radius flying vision, following the caster and leaving a trail of vision which lasts for 2 seconds.|Freezing Auras from multiple Shiva's Gaurds don't stack.|The aura's debuff lingers for 0.5 seconds.|The status buff icon only shows up when the affected unit has vision over the source." '
    ColorText = "Said to have belonged to a goddess, today it retains much of its former power."

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

    Dim intval As New modValue(30, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim armorval As New modValue(15, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)

    Return outmods

  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Emits a freezing wave that does 200 damage to enemies and slows their movement by -40% for 4.0 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Arctic Blast"
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

    Dim activeauraenemyinfo = Helpers.GetActiveAuraEnemyUnitsInfo(theitem_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim attspeedval As New modValue(40, eModifierType.AttackspeedSubtracted, occurencetime)

    Dim auraattackslow As New Modifier(attspeedval, activeauraenemyinfo)

    outmods.Add(auraattackslow)



    Dim damval As New modValue(200, eModifierType.DamageMagicalAdded, occurencetime)

    Dim BlastDamage As New Modifier(damval, activeauraenemyinfo)

    outmods.Add(BlastDamage)



    Dim movespeedval As New modValue(0.4, eModifierType.MoveSpeedPercentSubtracted, occurencetime)

    Dim BlastMoveSlow As New Modifier(movespeedval, activeauraenemyinfo)

    outmods.Add(BlastMoveSlow)


    Return outmods
  End Function
End Class
