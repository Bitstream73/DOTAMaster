Public Class abPoison_Attack
Inherits AbilityBase


  Dim dot As ValueWrapper
  Dim moveslow As ValueWrapper
  Dim attslow As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True '
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Poison Attack"
    mName = eAbilityName.abPoison_Attack

    Me.EntityName = eEntity.abPoison_Attack

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untViper

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/viper_poison_attack_hp2.png"

    Description = "Intensifies Viper's venom, adding an effect to his normal attack that slows attack and movement speed while dealing damage over time. Poison Attack is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."

    ManaCost = New ValueWrapper(20, 20, 20, 20)


    Cooldown = New ValueWrapper(0, 0, 0, 0)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    'mDamage = New ValueWrapper(0, 0, 0, 0)

    Duration = New ValueWrapper(2, 2, 2, 2)

    dot = New ValueWrapper(10, 16, 22, 28)

    moveslow = New ValueWrapper(0.1, 0.2, 0.3, 0.4)

    attslow = New ValueWrapper(10, 20, 30, 40)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 theowner As idisplayunit, _
                                                thetarget As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim autocasttargetenemy = Helpers.GetAutoCastEnemyTargetInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim damval As New modValue(dot, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, autocasttargetenemy)
    outmods.Add(dammod)


    'move slow
    Dim movvval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    movvval.mValueDuration = Duration

    Dim movemod As New Modifier(movvval, autocasttargetenemy)
    outmods.Add(movemod)

    'att slow
    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, autocasttargetenemy)
    outmods.Add(attmod)
    Return outmods
  End Function
End Class
