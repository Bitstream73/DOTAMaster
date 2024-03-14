Public Class itmShadow_Blade
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmSHADOW_BLADE
    Me.EntityName = eEntity.itmSHADOW_BLADE

    mDisplayName = "Shadow Blade"
    'mDescription = "The blade of a f)allen king, it allows you to move unseen and strike from the shadows. "
    mGoldCost = New ValueWrapper(3000)
    mMadeFromItems.Add(eItemname.itmSHADOW_AMULET)
    mMadeFromItems.Add(eItemname.itmCLAYMORE)


    mCategory = eItemCategory.WEAPONS
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/invis_sword_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(28)
    'mRadius = 
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(75)

    Description = "Active: Shadow Walk - Makes you invisible until the duration ends, or until you attack or cast a spell. While Shadow Walk is active, you move 20% faster and can move through units. If attacking to break the invisibility, you gain 175 bonus damage on that attack. Lasts 14.0 seconds."
    Notes = "Does not interupt the owner's channeling spells upon cast.|The bonus damage is directly added to the attack damage, so it can be reduced with e.g. Enfeeble or Static Link.|However, it cannot be amplified with e.g. Empower or the Double Damage rune.|The damage is considered by lifesteal, cleaves, Splash (Elder Dragon Form) and Psi Blades, but not by crits.|During the fade time, the user can cast spells, use items and perform attacks without breaking the invisibility.|Those attacks will apply the 175 damage to the target.|The bonus damage does not apply when attacking wards and buildings out of the invisibility.|The invisibility is lost upon reaching the cast point of spells, or upon finishing an attack, for ranged heroes this is upon projectile launch.|This means when the attack misses, the invisibility is still lost.|Allows the user to path through other units, including wards, but not through buildings.|The user can pick up and drop items without breaking the invisibility." '
    ColorText = "The blade of a fallen king, it allows you to move unseen and strike from the shadows."

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         theownerid, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(30, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim attspeedval As New modValue(30, eModifierType.AttackSpeedAdded, occurencetime)

    Dim attackspeed As New Modifier(attspeedval, passiveselfinfo)

    outmods.Add(attackspeed)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Makes you invisible until the duration ends, or until you attack or cast a spell. While Shadow Walk is active, you move 20% faster and can move through units. If attacking to break the invisibility, you gain 150 bonus damage on that attack. Lasts 17 seconds."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Shadow Walk"
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

    Dim phaseval As New modValue(0, eModifierType.Phase_Form, occurencetime)
    phaseval.mValueDuration = New ValueWrapper(17) 'New TimeSpan(0, 0, 17)

    Dim phasewalk As New Modifier(phaseval, notargetselfinfo)

    outmods.Add(phasewalk)

    Dim moveval As New modValue(0.2, eModifierType.MoveSpeedPercent, occurencetime)

    Dim movespeed As New Modifier(moveval, notargetselfinfo)

    outmods.Add(movespeed)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim damval As New modValue(150, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)

    Return outmods
  End Function
End Class
