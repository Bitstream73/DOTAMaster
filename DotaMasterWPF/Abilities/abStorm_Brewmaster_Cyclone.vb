Public Class abStorm_Brewmaster_Cyclone
  Inherits AbilityBase

  Public heroduration As ValueWrapper
  Public creepduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Cyclone"
    mName = eAbilityName.abStorm_Brewmaster_Cyclone
    Me.EntityName = eEntity.abStorm_Brewmaster_Cyclone

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untStorm_Brewmaster

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/e/e2/Cyclone_%28Storm%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Encloses a unit in a tornado, removing it from the battlefield."
    Notes = "Applies a Cyclone effect on the affected units, so it turns them invulnerable and fully disables them for its duration.|However, unlike other cyclones, this one does not dispel the target.|Cycloned units lose their collision size for the duration, so units can path below them."

    ManaCost = New ValueWrapper(150)

    Cooldown = New ValueWrapper(8)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untUnit)


    '    mDuration = New ValueWrapper()
    heroduration = New ValueWrapper(6)
    creepduration = New ValueWrapper(20)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim herotarget = Helpers.GetUnitTargetHeroInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim creeptarget = Helpers.GetUnitTargetCreepInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim hinvulval As New modValue(heroduration, eModifierType.Invulnerability, occurencetime, aghstime)
    hinvulval.mValueDuration = heroduration

    Dim hinvulmod As New Modifier(hinvulval, herotarget)
    outmods.Add(hinvulmod)



    Dim cinvulval As New modValue(creepduration, eModifierType.Invulnerability, occurencetime, aghstime)
    cinvulval.mValueDuration = creepduration

    Dim cinvulmod As New Modifier(cinvulval, creeptarget)
    outmods.Add(cinvulmod)


    Dim hmuteval As New modValue(heroduration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    hmuteval.mValueDuration = heroduration

    Dim hmutemod As New Modifier(hmuteval, herotarget)
    outmods.Add(hmutemod)



    Dim cmuteval As New modValue(creepduration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    cmuteval.mValueDuration = creepduration

    Dim cmutemod As New Modifier(cmuteval, creeptarget)
    outmods.Add(cmutemod)

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
