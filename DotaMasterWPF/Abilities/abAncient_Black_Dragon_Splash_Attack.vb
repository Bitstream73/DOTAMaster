Public Class abAncient_Black_Dragon_Splash_Attack
  Inherits AbilityBase


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

    mName = eAbilityName.abAncient_Black_Dragon_Splash_Attack
    Me.EntityName = eEntity.abAncient_Black_Dragon_Splash_Attack

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Black_Dragon
    mDisplayName = "Splash Attack"
    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/e/e8/Splash_Attack_%28Ancient_Black_Dragon%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Black_Dragon"
    Description = "The Black Dragon's explosive attacks are felt by all nearby enemies. Units closer to the blast take more damage."
    Notes = "When the attack misses or is disjointed, no splash damage is dealt."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyUnitsNotTargetted)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim untargettedenemies = Helpers.GetPassiveAuraEnemyUnitesNotTargettedInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim rdam As New modValue(occurencetime.Lifespan.count, eModifierType.RightClickDamageInflicted, occurencetime)

    Dim rmod As New Modifier(rdam, untargettedenemies)
    outmods.Add(rmod)

    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 caster As iDisplayUnit, _
                                                 target As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
