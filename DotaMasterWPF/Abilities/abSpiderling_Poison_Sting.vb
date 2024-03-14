Public Class abSpiderling_Poison_Sting
  Inherits AbilityBase
  Public dps As ValueWrapper
  Public moveslow As ValueWrapper
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

    mDisplayName = "Poison Sting"
    mName = eAbilityName.abSpiderling_Poison_Sting
    Me.EntityName = eEntity.abSpiderling_Poison_Sting

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpiderling

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/b/bd/Poison_Sting_%28Spiderling%29_icon.png/120px-Poison_Sting_%28Spiderling%29_icon.png?version=b333463c609b003f9a819fd04f45d681"
    WebpageLink = "http://dota2.gamepedia.com/Broodmother"
    Description = "Poisons enemies on attack."
    Notes = "Successive hits with Poison Sting on the same target do not stack, only the debuff gets refreshed.|The damage source of Poison Sting is set to be the spiderlings, not Broodmother.|This means that e.g. Blade Mail or Spiked Carapace will reflect it back to the spiderlings instead of Broodmother.|Deals damage in 1 second intervals, starting 1 second after the debuff is applied, resulting in 2 (6) damage ticks.|Can deal up to 16 (48) damage (before reductions).|Affects allies and wards, but not buildings.|Spiderites do not possess this ability."

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    dps = New ValueWrapper(8)
    moveslow = New ValueWrapper(0.15)
    heroduration = New ValueWrapper(2)
    creepduration = New ValueWrapper(6)

    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim targethero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim targetcreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim heromoveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    heromoveval.mValueDuration = heroduration

    Dim heromod As New Modifier(heromoveval, targethero)
    outmods.Add(heromod)

    Dim creepmoveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    creepmoveval.mValueDuration = creepduration

    Dim creepmod As New Modifier(creepmoveval, targetcreep)
    outmods.Add(creepmod)



    Dim herodamval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, occurencetime, aghstime)
    herodamval.mValueDuration = heroduration

    Dim herodammod As New Modifier(herodamval, targethero)
    outmods.Add(herodammod)



    Dim creepdamval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, occurencetime, aghstime)
    creepdamval.mValueDuration = creepduration

    Dim creepdammod As New Modifier(creepdamval, targetcreep)
    outmods.Add(creepdammod)



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
