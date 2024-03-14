Public Class abHill_Troll_Priest_Mana_Aura
  Inherits AbilityBase

  Public manaregenbonus As ValueWrapper
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

    mDisplayName = "Mana Aura"
    mName = eAbilityName.abHill_Troll_Priest_Mana_Aura
    Me.EntityName = eEntity.abHill_Troll_Priest_Mana_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHill_Troll_Priest

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/2a/Heal_%28Hill_Troll_Priest%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Hill_Troll_Priest"
    Description = "Provides bonus mana regeneration to all nearby allies."
    Notes = "Is an aura, so its buff lingers for 0.5 seconds.|Restores mana in form of mana regeneration, so it regenerates 0.2 mana in 0.1 second intervals, which makes 2 mana per second.|Stacks with all other sources of flat mana regeneration.|The flat mana regen bonus is not considered by percentage mana regeneration increases.|Regenerates up to 120 mana in one minute."

    '    mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    Radius = New ValueWrapper(900)

    manaregenbonus = New ValueWrapper(2)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passiveauraallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim manaval As New modValue(manaregenbonus, eModifierType.ManaRegenAdded, New ValueWrapper(1), occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, passiveauraallies)
    outmods.Add(manamod)

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
