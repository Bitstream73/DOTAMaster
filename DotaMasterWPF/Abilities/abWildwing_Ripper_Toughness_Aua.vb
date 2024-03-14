Public Class abWildwing_Ripper_Toughness_Aua
  Inherits AbilityBase


  Public armorbonus As ValueWrapper
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

    mDisplayName = "Toughness Aura"
    mName = eAbilityName.abWildwing_Ripper_Toughness_Aua
    Me.EntityName = eEntity.abWildwing_Ripper_Toughness_Aura

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWildwing_Ripper

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/63/Toughness_Aura_%28Wildwing_Ripper%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Wildwing_Camp"
    Description = "The Wildwing Ripper's fury numbs it to attacks and inspires nearby allies to withstand more blows."
    Notes = "Fully stacks with other armor increasing effects.|The aura's buff lingers for 0.5 seconds.|Fully affects siege creeps."

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untAlliedUnits)

    '    mDuration = New ValueWrapper()
    Radius = New ValueWrapper(900)
    armorbonus = New ValueWrapper(3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                      thecaster As iDisplayUnit, _
                                      thetarget As iDisplayUnit,
                                      ftarget As iDisplayUnit, _
                                      isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim passiveauraallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim armval As New modValue(armorbonus, eModifierType.ArmorAdded, occurencetime, aghstime)

    Dim selfarmmod As New Modifier(armval, passiveself)
    outmods.Add(selfarmmod)

    Dim auraarmmod As New Modifier(armval, passiveauraallies)
    outmods.Add(auraarmmod)

    Return outmods
  End Function
End Class
