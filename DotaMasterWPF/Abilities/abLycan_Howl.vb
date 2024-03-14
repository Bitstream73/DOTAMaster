Public Class abHowl
Inherits AbilityBase
  Public herobonusdamage As ValueWrapper
  Public minionbonusdamage As ValueWrapper
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

    mDisplayName = "Howl"
    mName = eAbilityName.abHowl
    Me.EntityName = eEntity.abHowl

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLycan

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lycan_howl_hp2.png"

    Description = "Grants bonus damage to Lycan, all allied heroes and all units under their control."


    ManaCost = New ValueWrapper(15, 20, 25, 30)

    Cooldown = New ValueWrapper(50, 45, 40, 35)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    herobonusdamage = New ValueWrapper(14, 26, 38, 50)

    minionbonusdamage = New ValueWrapper(5, 10, 15, 20)

    Duration = New ValueWrapper(10, 10, 10, 10)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim mapwideauraalliedheroes = Helpers.GetMapwideAuraAlliedHeroesInfo(theability_InfoID, _
                                                                                         thecaster, _
                                                                                         thetarget, _
                                                                                         "", eModifierCategory.Active)


    Dim mapwideauraalliedcontrolled = Helpers.GetMapwideAuraAllAlliedControlledUnitsInfo(theability_InfoID, _
                                                                                         thecaster, _
                                                                                         thetarget, _
                                                                                         "", eModifierCategory.Active)

    Dim herodamval As New modValue(herobonusdamage, eModifierType.BonusDamage, occurencetime, aghstime)

    Dim heromod As New Modifier(herodamval, mapwideauraalliedheroes)
    outmods.Add(heromod)


    Dim mindamval As New modValue(minionbonusdamage, eModifierType.BonusDamage, occurencetime, aghstime)

    Dim minmod As New Modifier(mindamval, mapwideauraalliedcontrolled)
    outmods.Add(minmod)

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
