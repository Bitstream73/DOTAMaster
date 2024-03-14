Public Class abAncient_Granite_Golem_Granite_Aura
  Inherits AbilityBase

  Public healthbonus As ValueWrapper
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

    mName = eAbilityName.abAncient_Granite_Golem_Granite_Aura
    Me.EntityName = eEntity.abAncient_Granite_Golem_Granite_Aura

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Granite_Golem

    mAbilityPosition = 0
    mDisplayName = "Granite Aura"
    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/00/Granite_Aura_%28Ancient_Granite_Golem%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Granite_Golem"
    Description = "Increases the health capacity of nearby units."
    Notes = "Fully stacks with other health increasing effects.|The aura's buff lingers for 0.5 seconds.|Only increases maximum health by 15%. Does not affect a unit's current health percentage.|Increases a unit's total health. Means it also includes health gained from e.g. strength items, or the 500 heath added to creeps by Helm of the Dominator icon.png Helm of the Dominator.|Does not affect wards and buildings. Does affect siege creeps and Roshan.|When illusions are spawned while affected by the aura, the illusion's health is based on the hero's health before it is increased by the aura.|When a unit receives the Ice Blast icon.png Ice Blast debuff, its current will get reduced to its basic value.|This means when a unit gains for example 300 health from the aura and is at full health, Ice Blast will cause it to lose the 300 health.|Effectively increases the Granite Golem's health to 1955 and the Rock Golems' health to 920."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)


    'mDuration = New ValueWrapper()
    Radius = New ValueWrapper(900)

    healthbonus = New ValueWrapper(0.15)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim auraallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim healthval As New modValue(healthbonus, eModifierType.HealthPercentAdded, occurencetime, aghstime)

    Dim healthmod As New Modifier(healthval, auraallies)
    outmods.Add(healthmod)

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
