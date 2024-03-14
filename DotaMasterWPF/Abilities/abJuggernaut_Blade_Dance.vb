Public Class abBlade_Dance
  Inherits AbilityBase

  Public critchance As ValueWrapper
  Public critdamagemultiplier As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The sound and particles play upon start of the attack, not when the attack lands." '"

    mDisplayName = "Blade Dance"
    mName = eAbilityName.abBlade_Dance

    Me.EntityName = eEntity.abBlade_Dance

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJuggernaut

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/juggernaut_blade_dance_hp2.png"

    Description = "Gives Juggernaut a chance to deal double damage on each attack."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    critdamagemultiplier = New ValueWrapper(2, 2, 2, 2)

    critchance = New ValueWrapper(0.2, 0.25, 0.3, 0.35)


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
                                                     theowner As idisplayunit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim damval As New modValue(critdamagemultiplier, eModifierType.RightClickDamageMultiplier, occurencetime, aghstime)
    damval.mPercentChance = critchance

    Dim thedamage As New Modifier(damval, unittargetenemy)
    outmods.Add(thedamage)


    Return outmods
  End Function
End Class
