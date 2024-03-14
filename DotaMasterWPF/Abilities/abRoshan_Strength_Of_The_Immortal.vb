Public Class abRoshan_Strength_Of_The_Immortal
  Inherits AbilityBase
  Public bonusmagicresist As ValueWrapper
  Public armorbonusper4min As ValueWrapper
  Public healthbonusper4min As ValueWrapper
  Public attachdageper4min As ValueWrapper

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

    mDisplayName = "Strength of the Immortal"
    mName = eAbilityName.abRoshan_Strength_Of_The_Immortal
    Me.EntityName = eEntity.abRoshan_Strength_Of_The_Immortal

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRoshan

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/6b/Unknown_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Roshan"
    Description = "Roshan possesses numerous protective abilities, including magic resistance and increasing armor, health, attack damage and Slam damage as time passes. Every illusion attacking Roshan is instantly destroyed. Roshan has phased movement."
    Notes = "The first 0.5 armor are added as the first creep wave spawns, and then every 4 minutes onward.|The 75% magic resistance and the phased status is given to him as he spawns.|All other bonuses are granted every 4 minute after the first creep wave spawns.|The bonuses persist through his death and keep on increasing while he's dead.|Only increases his maximum health by 500. His current health stays unchanged, meaning he has to regenerate up the 500 health.|Illusions are destroyed upon hitting Roshan or launching an attack projectile."

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    bonusmagicresist = New ValueWrapper(0.75)
    armorbonusper4min = New ValueWrapper(0.5)
    healthbonusper4min = New ValueWrapper(500)
    attachdageper4min = New ValueWrapper(10)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim magicval As New modValue(bonusmagicresist, eModifierType.MagicResistanceAdded, occurencetime, aghstime)

    Dim magicmod As New Modifier(magicval, passiveself)
    outmods.Add(magicmod)

    Dim armorval As New modValue(armorbonusper4min, eModifierType.RoshanArmorAddedPer4Min, occurencetime, aghstime)

    Dim armormod As New Modifier(armorval, passiveself)
    outmods.Add(armormod)

    Dim healthval As New modValue(healthbonusper4min, eModifierType.RoshanHealthPer4MinAdded, occurencetime, aghstime)

    Dim healthmod As New Modifier(healthval, passiveself)
    outmods.Add(healthmod)

    Dim damval As New modValue(attachdageper4min, eModifierType.RoshanRClickAttackDamPer4MinAdded, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, passiveself)
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
