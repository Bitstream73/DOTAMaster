Public Class abKraken_Shell
  Inherits AbilityBase


  Private damageThreshold As ValueWrapper
  Private damageReduction As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The damage reduction is a Damage Block and the debuff removal is a Strong Dispel.|The damage reduction is always on and is not connected to the damage treshold for debuff removal.|Only damage from player owned sources (after reductions) is counted towards debuff removal.|Damage counter for debuff removal resets when Tidehunter doesn't take player based damage for 6 seconds.|A debuff removal proc is indicated by a sound effect and water particles on Tidehunter's skin." '"

    mDisplayName = "Kraken Shell"
    mName = eAbilityName.abKraken_Shell
    Me.EntityName = eEntity.abKraken_Shell

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTidehunter

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tidehunter_kraken_shell_hp2.png"

    Description = "Creates a thick armor shell that reduces physical damage and removes negative buffs when damage received reaches a critical threshold. Kraken Shell does not stack with items that provide Damage Block."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    damageReduction = New ValueWrapper(10, 20, 30, 40)

    damageThreshold = New ValueWrapper(600, 550, 500, 450)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    'If theabilitylevel = 0 Then Return Nothing
    'Dim outmods As New ModifierList

    Return Nothing

    'Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     theowner As iDisplayUnit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                  theowner, _
                                                  thetarget, _
                                                  "", eModifierCategory.Passive)

    Dim damreductionval As New modValue(damageReduction, eModifierType.DamageBlock, occurencetime, aghstime)
    damreductionval.mThreshold = damageThreshold

    Dim thedamagereduction As New Modifier(damreductionval, passiveself)

    Return outmods
  End Function
End Class
