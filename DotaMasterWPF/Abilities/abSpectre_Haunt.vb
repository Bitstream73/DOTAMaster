Public Class abHaunt
  Inherits AbilityBase
  Public illduration As ValueWrapper
  Public illdamage As ValueWrapper
  Public illdamagetaken As ValueWrapper

  Public hauntcount As ValueWrapper
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

    mDisplayName = "Haunt"
    mName = eAbilityName.abHaunt
    Me.EntityName = eEntity.abHaunt

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpectre

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/spectre_haunt_hp2.png"

    Description = "Creates a spectral nemesis to attack each enemy hero after a short delay. At any moment during the duration, Spectre can use Reality to take the place of a given illusion. Haunt illusions are uncontrollable, take extra damage, and deal less damage than Spectre herself. They move at 400 base movement speed and ignore terrain."

    ManaCost = New ValueWrapper(150, 150, 150)

    Cooldown = New ValueWrapper(120, 120, 120)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    hauntcount = New ValueWrapper(5, 5, 5)

    Duration = New ValueWrapper(7, 6, 5)

    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetenemyheroes = Helpers.GetNoTargetEnemyHeroesInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim unittargetself = Helpers.GetUnitTargetHauntInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)



    Dim hauntval As New modValue(hauntcount, eModifierType.Haunt, occurencetime, aghstime)

    Dim hauntmod As New Modifier(hauntval, notargetenemyheroes)
    outmods.Add(hauntmod)


    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)
    tpval.mRange = Range

    Dim tpmod As New Modifier(tpval, unittargetself)
    outmods.Add(tpmod)


    Return outmods
  End Function


End Class
