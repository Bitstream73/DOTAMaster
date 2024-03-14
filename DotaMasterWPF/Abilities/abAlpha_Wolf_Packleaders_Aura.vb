Public Class abAlpha_Wolf_Packleaders_Aura
  Inherits AbilityBase

  Public attackdamagebonus As ValueWrapper
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

    mName = eAbilityName.abAlpha_Wolf_Packleaders_Aura
    Me.EntityName = eEntity.abAlpha_Wolf_Packleaders_Aura

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAlpha_Wolf
    mDisplayName = "Packleaders Aura"
    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/cb/Packleader%27s_Aura_%28Alpha_Wolf%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Alpha_Wolf"
    Description = "The Alpha Wolf's ruthless attacks do extra damage. His commanding presence inspires nearby allies to attack ruthlessly as well."
    Notes = "Only increases base damage and that given by the primary attribute of the affected units. Raw bonus damage is not increased.|The aura's buff lingers for 0.5 seconds.|Fully stacks with other attack damage increasing auras."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untAlliedUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    attackdamagebonus = New ValueWrapper(0.3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim passiveallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim attval As New modValue(attackdamagebonus, eModifierType.PackleaderRClickDamageAsPercofBaseDamandPrimaryStat, occurencetime, aghstime)

    Dim attmod As New Modifier(attval, passiveallies)
    outmods.Add(attmod)

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
