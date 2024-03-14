Public Class abCentaurReturn
  Inherits AbilityBase
  Public strengthbonusdamage As ValueWrapper
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
    mDisplayName = "Return"
    mName = eAbilityName.abCentaurReturn

    Me.EntityName = eEntity.abCentaurReturn


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCentaur_Warrunner

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/centaur_return_hp2.png"

    Description = "Centaur immediately counters every attack, damaging the attacker based on a percentage of Centaur's strength."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical


    Damage = New ValueWrapper(16, 18, 20, 22)

    strengthbonusdamage = New ValueWrapper(0.26, 0.34, 0.42, 0.5)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetattackingenemy = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                                           thecaster, _
                                                                            thetarget, _
                                                                             "", eModifierCategory.Passive)

    Dim damval As New modValue(Damage, eModifierType.RightClickCounterAttack, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetattackingenemy)
    outmods.Add(dammod)


    Dim strval As New modValue(strengthbonusdamage, eModifierType.StrengthPercentageCounterAttack, occurencetime, aghstime)

    Dim strmod As New Modifier(strval, notargetattackingenemy)
    outmods.Add(strmod)


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
