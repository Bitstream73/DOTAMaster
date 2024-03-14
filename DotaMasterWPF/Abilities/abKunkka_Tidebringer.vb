Public Class abTidebringer
Inherits AbilityBase


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

    Notes = "Cleave damage is reduced by armor type but not by armor value.|The cleave damages a circular area in front of Kunkka.|Applies bonus damage when denying, however, the cleave does not trigger and Tidebringer does not go into cooldown.|Applies bonus damage and goes into cooldown when attacking enemy structures, however, the cleave is not applied.|Plays an audio (only heard by Kunkka) when going off cooldown and has a visual effect on the sword whenever it's ready.|As with all cleave, Tidebringer stacks with Battle Fury and Empower." '"

    mDisplayName = "Tidebringer"
    mName = eAbilityName.abTidebringer
    Me.EntityName = eEntity.abTidebringer

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKunkka

    mAbilityPosition = 2

    mIsUltimate = False 'FixFixFix
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/kunkka_tidebringer_hp2.png"

    Description = "Kunkka's legendary sword grants increased damage and cleaves a large area of effect in front of him for a single strike."

    Cooldown = New ValueWrapper(13, 10, 7, 4)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Radius = New ValueWrapper(600, 500, 500, 500)

    Damage = New ValueWrapper(15, 30, 45, 60)
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

    'Dim unittargetenemy As New modInfo(eAbilityType.UnitTarget, _
    '                                   theability_InfoID, _
    '                                   thecaster.ID, eSourceType.HeroBuild, _
    '                                   thetarget.ID, eUnit.untEnemyTarget, "", eModifierCategory.Passive)


    Dim auraenemy = Helpers.GetAutoCastEnemyUnitsInfo(theability_InfoID, _
                                                      theowner, _
                                                      thetarget, _
                                                      "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.CleavePercentage, Cooldown, occurencetime, aghstime)


    Dim thedamage As New Modifier(damval, auraenemy)
    outmods.Add(thedamage)

    Return outmods
  End Function
End Class
