Public Class abWraithfire_Blast
Inherits AbilityBase
  Public stunduration As ValueWrapper
  Public slow As ValueWrapper
  Public dot As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Wraithfire Blast"
    mName = eAbilityName.abWraithfire_Blast
    Me.EntityName = eEntity.abWraithfire_Blast

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWraith_King

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skeleton_king_hellfire_blast_hp2.png"

    Description = "Wraith King sears an enemy unit with spectral fire, dealing damage and stunning, then dealing damage over time and slowing the target."

    ManaCost = New ValueWrapper(140, 140, 140, 140)

    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(50, 100, 150, 200)


    stunduration = New ValueWrapper(2, 2, 2, 2)

    slow = New ValueWrapper(0.2, 0.2, 0.2, 0.2)

    dot = New ValueWrapper(15, 30, 40, 50)

    slowduration = New ValueWrapper(2, 2, 2, 2)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'damage
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    'stun
    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, unittargetenemy)
    outmods.Add(stunmod)

    'dot
    Dim dotval As New modValue(dot, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = stunduration

    Dim dotmod As New Modifier(dotval, unittargetenemy)
    outmods.Add(dotmod)

    'slow
    Dim slowval As New modValue(slow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(slowmod)

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
