Public Class abIce_Vortex
Inherits AbilityBase
  Public slowmove As ValueWrapper
  Public increasedmagicdamage As ValueWrapper

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

mName = eAbilityName.abIce_Vortex
    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Apparition
    Me.EntityName = eEntity.abIce_Vortex

    mDisplayName = "Ice Vortex"
    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ancient_apparition_ice_vortex_hp2.png"

    Description = "Creates a vortex of icy energy that slows movement speed and increases magic damage done in its range. Lasts 16 seconds."

    ManaCost = New ValueWrapper(80, 90, 100, 110)


    Cooldown = New ValueWrapper(4, 4, 4, 4)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(275, 275, 275, 275)

    Duration = New ValueWrapper(16, 16, 16, 16)

    slowmove = New ValueWrapper(0.15, 0.2, 0.25, 0.3)

    increasedmagicdamage = slowmove
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointtargetenemyunits = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim moveval As New modValue(slowmove, eModifierType.MoveSpeedPercentStackSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, pointtargetenemyunits)
    outmods.Add(movemod)


    Dim damval As New modValue(increasedmagicdamage, eModifierType.MagicResistanceSubtracted, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, pointtargetenemyunits)
    outmods.Add(dammod)

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
