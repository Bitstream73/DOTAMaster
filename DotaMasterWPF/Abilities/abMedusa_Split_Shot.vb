Public Class abSplit_Shot
Inherits AbilityBase
  Public totaltargets As ValueWrapper

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

    mDisplayName = "Split Shot"
    mName = eAbilityName.abSplit_Shot
    Me.EntityName = eEntity.abSplit_Shot

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMedusa

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/medusa_split_shot_hp2.png"

    Description = "Medusa magically splits her shot into several arrows. These arrows deal a lower percent of her normal damage. The extra targets will not receive other attack effects (such as critical strike) and Unique Attack Modifiers."



    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Toggle)

    Affects.Add(eUnit.untSelf)

    Damage = New ValueWrapper(0.8, 0.8, 0.8, 0.8)

    totaltargets = New ValueWrapper(2, 3, 4, 5)

    Range = New ValueWrapper(700, 700, 700, 700)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargettoggleuntargettedenemies = Helpers.GetToggleUntargettedEnemyUnitsInfo(theability_InfoID, _
                                                                                      thecaster, _
                                                                                      thetarget, _
                                                                                      "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.RightClickDamagePercentageInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargettoggleuntargettedenemies)
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
