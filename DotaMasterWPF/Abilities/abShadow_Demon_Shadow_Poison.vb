Public Class abShadow_Poison
Inherits AbilityBase
  Public stackdamage As ValueWrapper
  Public maxstacks As ValueWrapper

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

    mDisplayName = "Shadow Poison"
    mName = eAbilityName.abShadow_Poison
    Me.EntityName = eEntity.abShadow_Poison

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Demon

    mAbilityPosition = 3

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_demon_shadow_poison_hp2.png"

    Description = "Deals damage in a line, and afflicts enemy units with a poison effect. The poison deals 1/2/4/8/16 times the stack damage based on the number of stacks on the target, up to 5 stacks. Additional stacks cause 50 damage each. This deferred damage is dealt when Shadow Poison's duration is expired, or the Release sub-ability is used."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(2.75, 2.75, 2.75, 2.75)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(50, 50, 50, 50)

    stackdamage = New ValueWrapper(20, 35, 50, 65)

    maxstacks = New ValueWrapper(5, 5, 5, 5)

    Duration = New ValueWrapper(10, 10, 10, 10)

    Radius = New ValueWrapper(190, 190, 190, 190)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemies)
    outmods.Add(dammod)


    Dim stackval As New modValue(stackdamage, eModifierType.ShadowPoisonStackDamage, occurencetime, aghstime)

    Dim stackmod As New Modifier(stackval, pointtargetlineenemies)
    outmods.Add(stackmod)




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
