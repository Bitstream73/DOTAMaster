Public Class abVendetta
Inherits AbilityBase
  Public movespeed As ValueWrapper
  Public bonusdamage As ValueWrapper

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

    mDisplayName = "Vendetta"
    mName = eAbilityName.abVendetta
    Me.EntityName = eEntity.abVendetta

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNyx_Assassin

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/nyx_assassin_vendetta_hp2.png"

    Description = "Allows Nyx Assassin to become invisible and gain a speed bonus. If Nyx Assassin attacks to break the invisibility, massive bonus damage is dealt with the attack."


    ManaCost = New ValueWrapper(160, 210, 260)

    Cooldown = New ValueWrapper(70, 60, 50)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Physical

    Duration = New ValueWrapper(50, 35, 20)

    movespeed = New ValueWrapper(0.16, 0.18, 0.2)

    bonusdamage = New ValueWrapper(250, 400, 550)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim invval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invval.mValueDuration = Duration

    Dim invmod As New Modifier(invval, notargetself)
    outmods.Add(invmod)


    Dim damval As New modValue(bonusdamage, eModifierType.RightClickBonusDamageInflicted, occurencetime, aghstime)


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
