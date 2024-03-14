Public Class abSlithereen_Crush
Inherits AbilityBase
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Slithereen Crush"
    mName = eAbilityName.abSlithereen_Crush
    Me.EntityName = eEntity.abSlithereen_Crush

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlardar

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slardar_slithereen_crush_hp2.png"

    Description = "Slams the ground, stunning and damaging nearby enemy land units. After the stun, the affected units are slowed."

    ManaCost = New ValueWrapper(80, 95, 105, 115)

    Cooldown = New ValueWrapper(8, 8, 8, 8)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(50, 100, 150, 200)

    Radius = New ValueWrapper(350, 350, 350, 350)

    moveslow = New ValueWrapper(0.2, 0.2, 0.2, 0.2)

    attslow = New ValueWrapper(20, 20, 20, 20)

    slowduration = New ValueWrapper(2, 2, 2, 2)

    stunduration = New ValueWrapper(1.6, 1.9, 2.2, 2.5)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetenemies)
    outmods.Add(dammod)


    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunmod As New Modifier(stunval, notargetenemies)
    outmods.Add(stunmod)


    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmod As New Modifier(slowval, notargetenemies)
    outmods.Add(slowmod)


    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, notargetenemies)
    outmods.Add(attmod)

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
