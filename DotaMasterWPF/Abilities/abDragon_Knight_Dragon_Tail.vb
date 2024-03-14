Public Class abDragon_Tail
Inherits AbilityBase
  Public stunduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Dragon Tail"
    mName = eAbilityName.abDragon_Tail
    Me.EntityName = eEntity.abDragon_Tail

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDragon_Knight

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dragon_knight_dragon_tail_hp2.png"

    Description = "Dragon Knight smites an enemy unit in melee range with his shield, stunning it while dealing minor damage. When in Elder Dragon Form, the cast range increases to 400."

    ManaCost = New ValueWrapper(100, 100, 100, 100)


    Cooldown = New ValueWrapper(12, 11, 10, 9)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(25, 50, 75, 100)

    stunduration = New ValueWrapper(2.5, 2.75, 3, 3.25)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyunits = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, unittargetenemyunits)
    outmods.Add(stunmod)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemyunits)
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
