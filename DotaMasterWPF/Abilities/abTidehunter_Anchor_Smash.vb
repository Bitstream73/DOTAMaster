Public Class abAnchor_Smash
  Inherits AbilityBase

  Private damageReduction As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Has a cast time of 0.5 seconds.|Affects ancient creeps, but not Roshan." '"

    mDisplayName = "Anchor Smash"
    mName = eAbilityName.abAnchor_Smash
    Me.EntityName = eEntity.abAnchor_Smash

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTidehunter

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tidehunter_anchor_smash_hp2.png"

    Description = "Tidehunter swings his mighty anchor to damage nearby enemies and reduce their attack damage."

    ManaCost = New ValueWrapper(30, 40, 50, 60)
    
    Cooldown = New ValueWrapper(7, 6, 5, 4)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical


    Damage = New ValueWrapper(75, 125, 175, 225)

    damageReduction = New ValueWrapper(0.45, 0.5, 0.55, 0.6)

    Duration = New ValueWrapper(6, 6, 6, 6)

    Radius = New ValueWrapper(375, 375, 375, 375)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeAuraEnemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim damval As New modValue(Me.Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim damage As New Modifier(damval, activeAuraEnemies)
    outmods.Add(damage)


    Dim damreductionval As New modValue(damageReduction, eModifierType.DamageReduction, occurencetime, aghstime)
    damreductionval.mValueDuration = Duration

    Dim damreduction As New Modifier(damreductionval, activeAuraEnemies)
    outmods.Add(damreduction)






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
