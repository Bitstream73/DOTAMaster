Public Class abQuill_Spray
Inherits AbilityBase
  Public quillbasedamage As ValueWrapper
  Public quillstackdamage As ValueWrapper
  Public stackduration As ValueWrapper
  Public maxdamage As ValueWrapper
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
    mDisplayName = "Quill Spray"
    mName = eAbilityName.abQuill_Spray
    Me.EntityName = eEntity.abQuill_Spray

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBristleback

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bristleback_quill_spray_hp2.png"

    Description = "Sprays enemy units with quills dealing damage in an area of effect around Bristleback. Deals bonus damage for every time a unit was hit by Quill Spray in the last 14 seconds."


    ManaCost = New ValueWrapper(35, 35, 35, 35)

    Cooldown = New ValueWrapper(3, 3, 3, 3)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    quillbasedamage = New ValueWrapper(20, 40, 60, 80)

    quillstackdamage = New ValueWrapper(30, 32, 34, 36)

    stackduration = New ValueWrapper(14, 14, 14, 14)

    maxdamage = New ValueWrapper(400 - quillbasedamage.Value(0), _
                                 400 - quillbasedamage.Value(1), _
                                 400 - quillbasedamage.Value(2), _
                                 400 - quillbasedamage.Value(3))
    Radius = New ValueWrapper(625, 625, 625, 625)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetauraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim damval As New modValue(quillbasedamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetauraenemies)
    outmods.Add(dammod)


    Dim stackval As New modValue(quillbasedamage, eModifierType.DamagePhysicalStackingInflicted, occurencetime, aghstime)
    stackval.mValueDuration = stackduration

    Dim stackmod As New Modifier(stackval, notargetauraenemies)
    outmods.Add(stackmod)


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
