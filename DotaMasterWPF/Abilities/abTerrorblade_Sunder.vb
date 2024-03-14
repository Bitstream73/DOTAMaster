Public Class abSunder
Inherits AbilityBase
  Public minhealth As ValueWrapper
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

    mDisplayName = "Sunder"
    mName = eAbilityName.abSunder
    Me.EntityName = eEntity.abSunder

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTerrorblade

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/terrorblade_sunder_hp2.png"

    Description = "Severs the soul from both Terrorblade and a target Hero, then exchanges them, carrying a percentage of each units' life force. The target Hero is also dealt a ministun. Some hit points must remain."

    ManaCost = New ValueWrapper(200, 100, 0)

    Cooldown = New ValueWrapper(120, 80, 40)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untUnits)


    Range = New ValueWrapper(325, 325, 325)

    minhealth = New ValueWrapper(0.2, 0.2, 0.2, 0.2)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untEnemyHero)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untEnemyIllusion)
    theaffects.Add(eUnit.untAlliedIllusion)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim sunval As New modValue(minhealth, eModifierType.StrSubtracted, occurencetime, aghstime)

    Dim sunmod As New Modifier(sunval, unittargetmulti)
    outmods.Add(sunmod)

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
