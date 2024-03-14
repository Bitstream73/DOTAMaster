Public Class abGuardian_Angel
Inherits AbilityBase
  Public scepterradius As New List(Of Double?)
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

    mDisplayName = "Guardian Angel"
    mName = eAbilityName.abGuardian_Angel
    Me.EntityName = eEntity.abGuardian_Angel

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOmniknight

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/omniknight_guardian_angel_hp2.png"

    Description = "Omniknight summons a Guardian Angel that grants immunity from physical damage and greatly increases hit point regeneration of nearby allies. Upgradable by Aghanim's Scepter"

    ManaCost = New ValueWrapper(125, 175, 250)

    Cooldown = New ValueWrapper(150, 150, 150)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(6, 7, 8)

    Radius = New ValueWrapper(600, 600, 600)
    scepterradius.Add(-1) 'global
    scepterradius.Add(-1) 'global
    scepterradius.Add(-1) 'global
    Radius.LoadScepterValues(scepterradius)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetallies = Helpers.GetActiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim physmod As New modValue(Duration, eModifierType.DamagePhysicalImmunity, occurencetime, aghstime)
    physmod.mValueDuration = Duration
    physmod.mRadius = Radius

    Dim physval As New Modifier(physmod, notargetallies)
    outmods.Add(physval)





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
