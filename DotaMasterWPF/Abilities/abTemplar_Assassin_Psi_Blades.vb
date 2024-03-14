Public Class abPsi_Blades
Inherits AbilityBase

  Public bonusattackrange As ValueWrapper
  Public splitrange As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Psi Blades"
    mName = eAbilityName.abPsi_Blades
    Me.EntityName = eEntity.abPsi_Blades

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTemplar_Assassin

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/templar_assassin_psi_blades_hp2.png"

    Description = "Templar Assassin's psi blades slice through the attacked unit, splitting and damaging enemy units directly behind it, while gaining bonus attack range."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Pure

    bonusattackrange = New ValueWrapper(60, 120, 180, 240)

    splitrange = New ValueWrapper(500, 630, 670, 710)

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

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim damval As New modValue(1, eModifierType.RightClickDamageAsLine, occurencetime)
    damval.mRange = bonusattackrange 'reps range for additional hits in line, so add it to default attack range

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)
    Return outmods
  End Function
End Class
