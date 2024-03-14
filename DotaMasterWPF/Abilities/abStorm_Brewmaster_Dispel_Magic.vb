Public Class abStorm_Brewmaster_Dispel_Magic
  Inherits AbilityBase


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

    mDisplayName = "Dispel Magic"
    mName = eAbilityName.abStorm_Brewmaster_Dispel_Magic
    Me.EntityName = eEntity.abStorm_Brewmaster_Dispel_Magic

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untStorm_Brewmaster

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/0c/Dispel_Magic_%28Storm%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Damages summoned units in a small radius and purges most buffs or debuffs."
    Notes = "List of dispelled buffs and debuffs can be found here.|Affects magic immune allies, but not magic immune enemies and thus can't dispel Repel off of enemies."

    ManaCost = New ValueWrapper(75)

    Cooldown = New ValueWrapper(8)

    AbilityTypes.Add(eAbilityType.PointTargetAura)

    Affects.Add(eUnit.untEnemySummonedUnits)
    'mAffects.Add(eUnit)

    ' mDuration = New ValueWrapper()
    Radius = New ValueWrapper(200)

    Damage = New ValueWrapper(200)
    DamageType = eDamageType.Magical
    Range = New ValueWrapper(500)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim summonedenemies = Helpers.GetPointTargetAuraEnemySummonedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, summonedenemies)
    outmods.Add(dammod)

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untEnemyUnits)
    theaffects.Add(eUnit.untAlliedUnits)
    Dim allunits = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active, _
                                                                             theaffects)

    Dim debuffval As New modValue(1, eModifierType.RemoveDebuffs, occurencetime)

    Dim debuffmod As New Modifier(debuffval, allunits)
    outmods.Add(debuffmod)

    Dim buffval As New modValue(1, eModifierType.RemoveBuffs, occurencetime)

    Dim buffmod As New Modifier(buffval, allunits)
    outmods.Add(buffmod)

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
