Public Class abWild_Axes
Inherits AbilityBase

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

    mName = eAbilityName.abWild_Axes

    Me.EntityName = eEntity.abWild_Axes

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBeastmaster

    mAbilityPosition = 1
    mDisplayName = "Wild Axes"
    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/beastmaster_wild_axes_hp2.png"

    Description = "Beastmaster sends his axes flying and calls them home again, slicing through enemy units and trees along their path. Each axe can hit an enemy once."

    ManaCost = New ValueWrapper(120, 120, 120, 120)


    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(90, 120, 150, 180)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim lineenemyunits = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)
    Dim linetrees = Helpers.GetPointTargetLineTreesInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, lineenemyunits)
    outmods.Add(dammod)


    'trees
    Dim treeval As New modValue(1, eModifierType.DestroysTree, occurencetime)

    Dim treemod As New Modifier(treeval, linetrees)
    outmods.Add(treemod)

    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
