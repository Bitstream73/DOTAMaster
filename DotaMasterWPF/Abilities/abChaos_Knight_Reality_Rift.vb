Public Class abReality_Rift
Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public bonusduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"
    mDisplayName = "Reality Rift"
    mName = eAbilityName.abReality_Rift
    Me.EntityName = eEntity.abReality_Rift

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untChaos_Knight

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/chaos_knight_reality_rift_hp2.png"

    Description = "Teleports you, any images you have and the target unit to a random point along the line between the two of you. Gives you bonus attack damage for one attack."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(24, 18, 12, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Range = New ValueWrapper(550, 600, 650, 700)

    bonusdamage = New ValueWrapper(60, 80, 100, 120)

    bonusduration = New ValueWrapper(1.2, 1.2, 1.2, 1.2)


End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)
    Dim tpval As New modValue(1, eModifierType.TeleportRandom, occurencetime)

    Dim enemytp As New Modifier(tpval, unittargetenemytarget)
    outmods.Add(enemytp)

    Dim selftp As New Modifier(tpval, notargetself)
    outmods.Add(selftp)


    'damage
    Dim damval As New modValue(bonusdamage, eModifierType.RightClickDamageAdded, occurencetime, aghstime)
    damval.mValueDuration = bonusduration

    Dim dammod As New Modifier(damval, unittargetenemytarget)
    outmods.Add(dammod)

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
