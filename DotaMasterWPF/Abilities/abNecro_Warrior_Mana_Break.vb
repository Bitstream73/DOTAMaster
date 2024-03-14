Public Class abNecro_Warrior_Mana_Break
  Inherits AbilityBase

  Public manaperhit As ValueWrapper
  Public manaasdamage As Double
  Public damperhit As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Mana Break"
    mName = eAbilityName.abNecro_Warrior_Mana_Break
    Me.EntityName = eEntity.abNecro_Warrior_Mana_Break

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecro_Warrior

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/f/f1/Mana_Break_%28Necronomicon_Warrior%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Necronomicon#Necronomicon_Archer"
    Description = "Mana burned per hit, a portion of which is dealt as damage."
    Notes = "The damage is directly added to the warrior's attack damage.|Deals up to 15/30/45 damage per hit (before reductions).|The damage is directly added to the warrior's attack damage, so it can lifesteal off of it. However, it still cannot crit or cleave.|The damage can be reduced with e.g. Enfeeble, but it can not be amplified with e.g. Empower.|Applies the mana loss first, and then the damage."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    manaperhit = New ValueWrapper(25, 50, 75)
    manaasdamage = 0.6
    Dim thevals As New List(Of Double?)
    thevals.Add(manaperhit.Value(0) * manaasdamage)
    thevals.Add(manaperhit.Value(1) * manaasdamage)
    thevals.Add(manaperhit.Value(2) * manaasdamage)
    damperhit = New ValueWrapper(thevals)

    DamageType = eDamageType.Physical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passivetargetenemy = Helpers.GetPassiveEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim manaval As New modValue(manaperhit, eModifierType.RightClickBurnedMana, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, passivetargetenemy)
    outmods.Add(manamod)

    Dim damval As New modValue(damperhit, eModifierType.RightClickBonusDamageInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, passivetargetenemy)
    outmods.Add(dammod)


    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                              theowner As iDisplayUnit, _
                                              thetarget As iDisplayUnit, _
                                              ftarget As iDisplayUnit, _
                                              isfriendbias As Boolean, _
                                              occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
