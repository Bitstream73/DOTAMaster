Public Class abBash
  Inherits AbilityBase


  Public chance As ValueWrapper
  Public bonusdamage As ValueWrapper

  Public creepduration As ValueWrapper
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

    mDisplayName = "Bash"
    mName = eAbilityName.abBash
    Me.EntityName = eEntity.abBash

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlardar

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slardar_bash_hp2.png"

    Description = "Grants a chance that an attack will do bonus damage and stun an enemy. The duration is doubled against creeps."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    chance = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    bonusdamage = New ValueWrapper(60, 80, 100, 120)

    Duration = New ValueWrapper(1, 1, 1, 1)

    creepduration = New ValueWrapper(Duration.Value(0) * 2, _
                                     Duration.Value(1) * 2, _
                                     Duration.Value(2) * 2, _
                                     Duration.Value(3) * 2)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  theowner As idisplayunit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim unittargethero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                            theowner, _
                                                            thetarget, _
                                                            "", eModifierCategory.Passive)

    Dim unittargetcreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                            theowner, _
                                                            thetarget, _
                                                            "", eModifierCategory.Passive)


    Dim damval As New modValue(bonusdamage, eModifierType.RightClickBonusDamageInflicted, occurencetime, aghstime)
    damval.mPercentChance = chance

    Dim dammod As New Modifier(damval, unittargethero)
    outmods.Add(dammod)


    Dim stunval As New modValue(Duration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = Duration

    Dim stunmod As New Modifier(stunval, unittargethero)
    outmods.Add(stunmod)


    'creep values

    Dim cdammod As New Modifier(damval, unittargetcreep)
    outmods.Add(cdammod)


    Dim cstunval As New modValue(creepduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = creepduration

    Dim cstunmod As New Modifier(stunval, unittargetcreep)
    outmods.Add(cstunmod)



    Return outmods
  End Function
End Class
