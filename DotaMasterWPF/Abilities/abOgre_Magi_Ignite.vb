Public Class abIgnite
Inherits AbilityBase
  Public slow As ValueWrapper
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

    mDisplayName = "Ignite"
    mName = eAbilityName.abIgnite
    Me.EntityName = eEntity.abIgnite

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOgre_Magi

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ogre_magi_ignite_hp2.png"

    Description = "Drenches a target in volatile chemicals, causing it to burst into flames. The target is in immense pain, taking damage and moving more slowly."

    ManaCost = New ValueWrapper(95, 105, 115, 125)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(26, 34, 42, 60)

    slow = New ValueWrapper(0.2, 0.22, 0.24, 0.26)

    Duration = New ValueWrapper(5, 6, 7, 8)
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

    Dim burnval As New modValue(Damage, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    burnval.mValueDuration = Duration

    Dim burnmod As New Modifier(burnval, unittargetenemy)
    outmods.Add(burnmod)


    Dim slowval As New modValue(slow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)

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
