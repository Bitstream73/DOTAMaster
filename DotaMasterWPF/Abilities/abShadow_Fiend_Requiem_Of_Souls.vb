Public Class abRequiem_Of_Souls
Inherits AbilityBase
  Public castdelay As ValueWrapper

  Public damageperline As ValueWrapper
  Public movereduction As ValueWrapper
  Public damreduction As ValueWrapper
  Public reductduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Requiem of Souls"
    mName = eAbilityName.abRequiem_Of_Souls
    Me.EntityName = eEntity.abRequiem_Of_Souls

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Fiend

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/nevermore_requiem_hp2.png"

    Description = "Captured souls are used to deal massive damage, as well as slowing and reducing the attack damage of nearby enemy units. Requiem of Souls creates one wave of damage for every 2 souls stored by Necromastery. The closest enemy units are hit the hardest. Requiem of Souls has a 1.67 second cast time before it is activated. Requiem of Souls is automatically cast when Shadow Fiend dies, independent of its cooldown."

    ManaCost = New ValueWrapper(150, 175, 200)

    Cooldown = New ValueWrapper(120, 110, 100)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    damageperline = New ValueWrapper(80, 120, 160)

    castdelay = New ValueWrapper(1.67, 1.67, 1.67, 1.67)

    movereduction = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    damreduction = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    reductduration = New ValueWrapper(5, 5, 5, 5)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    'damage per line
    Dim damval As New modValue(damageperline, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetauraenemies)
    outmods.Add(dammod)


    'move slow
    Dim slowval As New modValue(movereduction, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = reductduration

    Dim slowmod As New Modifier(slowval, notargetauraenemies)
    outmods.Add(slowmod)

    'damage reduction
    Dim damredval As New modValue(damreduction, eModifierType.RightClickDamagePercentSubtracted, occurencetime, aghstime)
    damredval.mValueDuration = reductduration

    Dim damredmod As New Modifier(damredval, notargetauraenemies)
    outmods.Add(damredmod)



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
