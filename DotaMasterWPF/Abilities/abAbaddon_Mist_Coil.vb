Public Class abMist_Coil
  Inherits AbilityBase

  Private HealDamagetoTarget As ValueWrapper
  Private DamageToAbaddon As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = True
    BlockedByLinkens = True
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = True

    mName = eAbilityName.abMist_Coil
    Me.EntityName = eEntity.abMist_Coil

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAbaddon
    mDisplayName = "Mist Coil"
    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/abaddon_death_coil_hp2.png"
    WebpageLink = ""
    Description = "Abaddon releases a coil of deathly mist that can damage an enemy unit or heal a friendly unit at the cost of some of Abaddon's health."
    Notes = "The damage to Abaddon is pure damage.|Self-damage from Mist Coil can burst Aphotic Shield.|Abaddon can deny himself with this ability"

    ManaCost = New ValueWrapper(50, 60, 70, 80)

    Cooldown = New ValueWrapper(5, 5, 5, 5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    DamageType = eDamageType.Magical

    Range = New ValueWrapper(800, 800, 800, 800)

    HealDamagetoTarget = New ValueWrapper(100, 150, 200, 250)

    DamageToAbaddon = New ValueWrapper(75, 100, 125, 150)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



    Dim outmods As New ModifierList




    Dim unittargetallyinfo = Helpers.GetUnitTargetAlliedUnitsInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim magval As New modValue(HealDamagetoTarget, eModifierType.HealFriendlyorDamageEnemy, occurencetime, aghstime)

    Dim magicheal As New Modifier(magval, unittargetallyinfo)

    outmods.Add(magicheal)




    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim damval As New modValue(DamageToAbaddon, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim casterselfdamage As New Modifier(damval, notargetselfinfo)

    outmods.Add(casterselfdamage)

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
