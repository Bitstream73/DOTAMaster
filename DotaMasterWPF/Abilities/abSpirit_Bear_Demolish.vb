Public Class abSpirit_Bear_Demolish
  Inherits AbilityBase


  Dim attbonusbuildings As ValueWrapper
  Dim magresistbonus As ValueWrapper
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

    mDisplayName = "Demolish"
    mName = eAbilityName.abSpirit_Bear_Demolish
    Me.EntityName = eEntity.abSpirit_Bear_Demolish

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Bear

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/3/3a/Demolish_%28Spirit_Bear%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Spirit_Bear#Spirit_Bear"
    Description = "Increases the power of the Spirit Bear, causing it to deal more damage to buildings and have additional spell resistance."
    Notes = "Demolish requires Summon Spirit Bear level 4 to be unlocked.|Does not deal bonus damage against Tombstone."

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyStructure)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    attbonusbuildings = New ValueWrapper(-1, -1, -1, 0.4)
    magresistbonus = New ValueWrapper(-1, -1, -1, 0.33)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)


    Dim attval As New modValue(attbonusbuildings, eModifierType.BuildingAttackSpeedPercentAdded, occurencetime, aghstime)

    Dim attmod As New Modifier(attval, passiveself)
    outmods.Add(attmod)


    Dim magval As New modValue(magresistbonus, eModifierType.MagicResistancePercentAdded, occurencetime, aghstime)

    Dim magmod As New Modifier(magval, passiveself)
    outmods.Add(magmod)

    Return outmods
  End Function
End Class
