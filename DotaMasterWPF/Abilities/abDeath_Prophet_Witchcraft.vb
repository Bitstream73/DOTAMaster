Public Class abWitchcraft
Inherits AbilityBase

  Dim movementspeedpercent As ValueWrapper
  Dim manacostdecrease As ValueWrapper
  Dim cooldowndecrease As ValueWrapper
  Dim addedexorcismspirits As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Witchcraft"
    mName = eAbilityName.abWitchcraft
    Me.EntityName = eEntity.abWitchcraft

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDeath_Prophet

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/death_prophet_witchcraft_hp2.png"

    Description = "Increases the potency of Death Prophet's spells, while providing a passive movement speed boost. Reduces mana costs and cooldowns of Crypt Swarm and Silence, and adds additional spirits to Exorcism."



    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)



    movementspeedpercent = New ValueWrapper(0.05, 0.1, 0.15, 0.2)

    manacostdecrease = New ValueWrapper(10, 15, 20, 25)


    cooldowndecrease = New ValueWrapper(1, 2, 3, 4)

    addedexorcismspirits = New ValueWrapper(3, 4, 5, 6)

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
                                                    theowner As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim moveval As New modValue(movementspeedpercent, eModifierType.MoveSpeedPercent, occurencetime, aghstime)

    Dim themove As New Modifier(moveval, notargetself)
    outmods.Add(themove)


    Dim manaval As New modValue(manacostdecrease, eModifierType.WitchcraftManaCostDecrease, occurencetime, aghstime)

    Dim mana As New Modifier(manaval, notargetself)
    outmods.Add(mana)


    Dim coolval As New modValue(cooldowndecrease, eModifierType.WitchcraftCooldownDecrease, occurencetime, aghstime)

    Dim cool As New Modifier(coolval, notargetself)
    outmods.Add(cool)


    Dim spiritval As New modValue(addedexorcismspirits, eModifierType.WitchcraftSpiritIncrease, occurencetime, aghstime)

    Dim spirval As New Modifier(spiritval, notargetself)
    outmods.Add(spirval)



    Return outmods
  End Function
End Class
