Public Class abSearing_Arrows
Inherits AbilityBase

  Public bonusdamage As ValueWrapper
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
    mDisplayName = "Searing Arrows"
    mName = eAbilityName.abSearing_Arrows

    Me.EntityName = eEntity.abSearing_Arrows


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClinkz

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/clinkz_searing_arrows_hp2.png"

    Description = "Imbues Clinkz's arrows with fire for extra damage. Searing Arrows is a Unique Attack Modifier, and does not stack with other Unique Attack Modifiers."

    ManaCost = New ValueWrapper(10, 10, 10, 10)

    'mCooldown = New ValueWrapper(0, 0, 0, 0)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)
    Affects.Add(eUnit.untEnemyStructure)

    DamageType = eDamageType.Physical

    bonusdamage = New ValueWrapper(30, 40, 50, 60)

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

    Dim autocastunittarget = Helpers.GetAutoCastEnemyTargetInfo(theability_InfoID, _
                                                            theowner, _
                                                            thetarget, _
                                                            "", eModifierCategory.Passive)

    Dim damval As New modValue(bonusdamage, eModifierType.RightClickDamageAdded, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, autocastunittarget)
    outmods.Add(dammod)

    Return outmods
  End Function
End Class
