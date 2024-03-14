Public Class abSpiderling_Spawn_Spiderite
  Inherits AbilityBase
  ' 

  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Spawn Spiderite"
    mName = eAbilityName.abSpiderling_Spawn_Spiderite
    Me.EntityName = eEntity.abSpiderling_Spawn_Spiderite

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpiderling

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/05/Spawn_Spiderite_%28Spiderling%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Broodmother"
    Description = "Applies debuff on attack. If debuffed unit dies, a spiderite will spawn."
    Notes = "Spiderites will only spawn when the attacked unit dies while having the debuff on.|It does not matter who kills the target, if it dies in any way, the spiderites will spawn.|Does not affect wards and buildings, but affects allies.|Spiderites are fully affected by Spin Web.|Spiderites do not possess this ability."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.AutoCast)

    Affects.Add(eUnit.untDyingEnemyTarget)
    '    mAffects.Add(eUnit)

    Duration = New ValueWrapper(2)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim deadtarget = Helpers.GetUnitTargetDyingEnemyTargetInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim lingval As New modValue(1, eModifierType.SpawnSpiderite, occurencetime)

    Dim lingmod As New Modifier(lingval, deadtarget)
    outmods.Add(lingmod)

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
