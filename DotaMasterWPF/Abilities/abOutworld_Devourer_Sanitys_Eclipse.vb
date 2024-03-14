Public Class abSanitys_Eclipse
Inherits AbilityBase
  Public intdiffdammulti As ValueWrapper
  Public indiffmanalossthresh As ValueWrapper

  Public scepterintdiffdammulti As New List(Of Double?)
  Public scepterimdiffmanalossthresh As New List(Of Double?)

  Public manalosspercentage As ValueWrapper

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

    mDisplayName = "Sanity's Eclipse"
    mName = eAbilityName.abSanitys_Eclipse
    Me.EntityName = eEntity.abSanitys_Eclipse

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOutworld_Devourer

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/obsidian_destroyer_sanity_eclipse_hp2.png"

    Description = "Deals damage to enemy Heroes in an area of effect based on the difference between Harbinger and the affected Hero's intelligence. If the Hero takes less than the damage threshold, that Hero loses 75% of its current mana. Sanity's Eclipse can hit units trapped in Astral Imprisonment. If an enemy hero has the same or higher Intelligence than Outworld Devourer, Sanity's Eclipse has no effect. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(175, 250, 325)

    Cooldown = New ValueWrapper(160, 160, 160)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    intdiffdammulti = New ValueWrapper(8, 9, 10)
    scepterintdiffdammulti.Add(9)
    scepterintdiffdammulti.Add(10)
    scepterintdiffdammulti.Add(11)
    intdiffdammulti.LoadScepterValues(scepterintdiffdammulti)

    indiffmanalossthresh = New ValueWrapper(10, 30, 50)
    scepterimdiffmanalossthresh.Add(9)
    scepterimdiffmanalossthresh.Add(10)
    scepterimdiffmanalossthresh.Add(11)
    indiffmanalossthresh.LoadScepterValues(scepterimdiffmanalossthresh)

    Radius = New ValueWrapper(575, 475, 375)

    Range = New ValueWrapper(600, 650, 700)

    manalosspercentage = New ValueWrapper(0.75, 0.75, 0.75)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim damval As New modValue(intdiffdammulti, eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemies)


    Dim manaval As New modValue(manalosspercentage, eModifierType.SanitysManaPercentRemovedwithThreshold, occurencetime, aghstime)
    manaval.mThreshold = indiffmanalossthresh

    Dim manamod As New Modifier(manaval, pointtargetenemies)
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
