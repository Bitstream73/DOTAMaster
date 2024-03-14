Public Class abFeast
Inherits AbilityBase


  Public lifeleech As ValueWrapper
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

    mDisplayName = "Feast"
    mName = eAbilityName.abFeast
    Me.EntityName = eEntity.abFeast

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLifestealer

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/life_stealer_feast_hp2.png"

    Description = "Regenerates a portion of the attacked enemy's current HP and deals the same portion of damage per attack."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnit)

    lifeleech = New ValueWrapper(0.04, 0.05, 0.06, 0.07)






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

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Passive)

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Passive)

    Dim damval As New modValue(lifeleech, eModifierType.RightClickDamageAsPercOfTargetCurrHP, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim healval As New modValue(lifeleech, eModifierType.HealAddedAsPercOfTargetCurrHP, occurencetime, aghstime)

    Dim healmod As New Modifier(healval, unittargetself)
    outmods.Add(healmod)


    Return outmods
  End Function
End Class
