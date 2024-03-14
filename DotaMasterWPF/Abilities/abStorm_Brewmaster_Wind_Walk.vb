Public Class abStorm_Brewmaster_Wind_Walk
  Inherits AbilityBase

  Public fadetime As ValueWrapper
  Public movebonus As ValueWrapper
  Public breakdamage As ValueWrapper

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

    mDisplayName = "Wind Walk"
    mName = eAbilityName.abStorm_Brewmaster_Wind_Walk
    Me.EntityName = eEntity.abStorm_Brewmaster_Wind_Walk

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untStorm_Brewmaster

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/2c/Wind_Walk_%28Storm%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Provides temporary invisibility. Bonus movement speed and attack damage when invisible."
    Notes = "Has an instant cast time.|The damage is directly added to Storm's attack damage, so it can be reduced by e.g. Static Link, but not amplified by e.g. Empower.|This also means that Storm can lifesteal off of the damage.|During the fade time, Storm can cast spells and perform attacks without breaking the invisibility.|Attacks performed during the fade time will apply the Wind Walk damage.|The invisibility is broken upon reaching the cast point of spells, or launching an attack.|Unlike other windwalk abilities with Backstab, the attack out of this Wind Walk does not have true strike.|Storm will not auto-attack while invisible."

    ManaCost = New ValueWrapper(75)

    Cooldown = New ValueWrapper(7)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnit)
    '    mAffects.Add(eUnit)

    Duration = New ValueWrapper(20)

    DamageType = eDamageType.Magical
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

    Dim unittarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration

    Dim invismod As New Modifier(invisval, notargetself)
    outmods.Add(invismod)


    Dim speedval As New modValue(movebonus, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)
    speedval.mValueDuration = Duration

    Dim speedmod As New Modifier(speedval, notargetself)
    outmods.Add(speedmod)


    Dim damval As New modValue(breakdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittarget)
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
