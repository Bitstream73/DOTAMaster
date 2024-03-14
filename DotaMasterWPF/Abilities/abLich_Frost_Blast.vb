Public Class abFrost_Blast
Inherits AbilityBase
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public areadamage As ValueWrapper

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

    mDisplayName = "Frost Blast"
    mName = eAbilityName.abFrost_Blast
    Me.EntityName = eEntity.abFrost_Blast

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLich

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lich_frost_nova_hp2.png"

    Description = "Blasts the target enemy unit with damaging frost, dealing area damage and slowing movement and attack rates for 4 seconds. The primary target takes the most damage."

    ManaCost = New ValueWrapper(125, 150, 170, 190)


    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(50, 100, 150, 200)

    Radius = New ValueWrapper(200, 200, 200, 200)

    moveslow = New ValueWrapper(0.3, 0.3, 0.3, 0.3)

    attslow = New ValueWrapper(20, 20, 20, 20)

    areadamage = New ValueWrapper(75, 100, 125, 150)

    Duration = New ValueWrapper(4, 4, 4, 4)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetauraenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    'aura damage
    Dim auradamval As New modValue(areadamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim auradammod As New Modifier(auradamval, pointtargetauraenemies)
    outmods.Add(auradammod)

    'aura slow
    Dim auraslowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    auraslowval.mValueDuration = Duration

    Dim auraslowmod As New Modifier(auraslowval, pointtargetauraenemies)
    outmods.Add(auraslowmod)


    'target additional damage
    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
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
