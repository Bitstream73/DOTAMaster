Public Class abFrost_Arrows
Inherits AbilityBase


  Public movespeedslow As ValueWrapper
  Public heroduration As ValueWrapper
  Public creepduration As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = True
    PiercesSpellImmunity = False

    Notes = "The slow will not increase by successive casts, it will only be refreshed.|The slow is a unique attack modifier and conflicts with lifesteal, both when used automatically and when used manually.|It works on siege creeps."

    mDisplayName = "Frost Arrows"
    mName = eAbilityName.abFrost_Arrows
    Me.EntityName = eEntity.abFrost_Arrows

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDrow_Ranger

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/drow_ranger_frost_arrows_hp2.png"
    WebpageLink = ""
    Description = "Adds a freezing effect to Drow's attacks, slowing enemy movement. Lasts 1.5 seconds on Heroes, and 7 seconds on creeps. Frost Arrows is a Unique Attack Modifier, and does not stack with other Unique Attack Modifier.|Duration increases to 7 on creeps."

    ManaCost = New ValueWrapper(12, 12, 12, 12)

    ' mCooldown = New ValueWrapper(0, 0, 0, 0)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    ' mDamage = New ValueWrapper(0, 0, 0, 0)


    Range = New ValueWrapper(625, 625, 625, 625)

    movespeedslow = New ValueWrapper(0.11, 0.24, 0.37, 0.6)

    heroduration = New ValueWrapper(1.5, 1.5, 1.5, 1.5)
    creepduration = New ValueWrapper(7, 7, 7, 7)
  End Sub




  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  theowner As idisplayunit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim autounitenemyheroinf = Helpers.GetAutoCastEnemyHeroInfo(theability_InfoID, _
                                                                 theowner, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Passive)

    Dim autounitenemcreepinf = Helpers.GetAutoCastEnemyCreepInfo(theability_InfoID, _
                                                             theowner, _
                                                             thetarget, _
                                                             "", eModifierCategory.Passive)

    Dim heromoveval As New modValue(movespeedslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    heromoveval.mValueDuration = heroduration

    Dim heromoveslow As New Modifier(heromoveval, autounitenemyheroinf)
    outmods.Add(heromoveslow)


    Dim creepmoveval As New modValue(movespeedslow, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    creepmoveval.mValueDuration = creepduration

    Dim Creepmoveslow As New Modifier(creepmoveval, autounitenemcreepinf)
    outmods.Add(Creepmoveslow)


    Return outmods
  End Function

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Return Nothing

    Return outmods
  End Function
End Class
