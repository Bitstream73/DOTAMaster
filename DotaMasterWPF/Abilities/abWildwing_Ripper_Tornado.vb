Public Class abWildwing_Ripper_Tornado
  Inherits AbilityBase

  Public maxchanneltime As ValueWrapper
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

    mDisplayName = "Tornado"
    mName = eAbilityName.abWildwing_Ripper_Tornado
    Me.EntityName = eEntity.abWildwing_Ripper_Tornado

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWildwing_Ripper

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/f/f9/Tornado_%28Wildwing_Ripper%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Wildwing_Camp"
    Description = "The Wildwing Ripper calls on the spirit of the wind, creating a sentient Tornado that he can control. The Tornado slows nearby enemies and does damage. It is invulnerable and can move anywhere"
    Notes = "As a neutral unit: The wildwing never casts this spell.|As a player controlled unit: No restrictions."

    ManaCost = New ValueWrapper(200)

    Cooldown = New ValueWrapper(70)

    AbilityTypes.Add(eAbilityType.Channeled)

    Affects.Add(eUnit.untEnemyUnits)
    'mAffects.Add(eUnit)

    '    mDuration = New ValueWrapper()

    Range = New ValueWrapper(500)

    maxchanneltime = New ValueWrapper(40)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim channeledself = Helpers.GetChanneledSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim torval As New modValue(1, eModifierType.petTornado, occurencetime)
    torval.mValueDuration = maxchanneltime

    Dim tormod As New Modifier(torval, channeledself)

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
