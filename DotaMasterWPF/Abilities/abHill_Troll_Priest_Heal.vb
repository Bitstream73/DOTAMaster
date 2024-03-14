Public Class abHill_Troll_Priest_Heal
  Inherits AbilityBase

  Public heal As ValueWrapper
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

    mDisplayName = "Heal"
    mName = eAbilityName.abHill_Troll_Priest_Heal
    Me.EntityName = eEntity.abHill_Troll_Priest_Heal

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHill_Troll_Priest

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/2a/Heal_%28Hill_Troll_Priest%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Hill_Troll_Priest"
    Description = "The Hill Troll Priest lays his holy blessing upon the target ally, replenishing some health."
    Notes = "The cast of Heal is never registered as a spell, meaning it won't trigger Curse of the Silent, Last Word, Essence Aura, Magic Stick and Magic Wand.|As a neutral unit: The troll automatically heals a hurt allied unit once. After that, it stops doing anything. It neither continues healing, nor attacks or moves.|The troll only continuously heals its allies, when an enemy unit is within the 350 cast range, and is attackable (must not be invulnerable or in ethereal state.)|As a play controlled unit: When put on auto-cast, the troll automatically heals a random nearby hurt allied unit. On each cast, a random unit is select. It does not lock on one unit until it is fully healed.|Does not follow hurt units to heal.|There are no priorities. Each hurt unit has the same chance to get healed by auto-cast.|Can not heal siege creeps, wards and buildings."

    ManaCost = New ValueWrapper(5)

    Cooldown = New ValueWrapper(0.5)

    AbilityTypes.Add(eAbilityType.AutoCast)

    Affects.Add(eUnit.untTargettedAlly)
    'mAffects.Add(eUnit)

    ' mDuration = New ValueWrapper()


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim unittargetedally = Helpers.GetAutoCastAllyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim healval As New modValue(heal, eModifierType.HealAdded, Cooldown, occurencetime, aghstime)

    Dim healmod As New Modifier(healval, unittargetedally)
    outmods.Add(healmod)


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
