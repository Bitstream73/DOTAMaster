Public Class abBlood_Rite
  Inherits AbilityBase
  Public silenceduration As ValueWrapper

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
    mDisplayName = "Blood Rite"
    mName = eAbilityName.abBlood_Rite
    Me.EntityName = eEntity.abBlood_Rite

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBloodseeker

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bloodseeker_blood_bath_hp2.png"

    Description = "Bloodseeker baptizes an area in sacred blood. After 3 seconds the ritual completes, causing any enemies caught in the area to take damage and become silenced."

    Notes = "The affected area is visible to enemies.|The delay consists of 0.4 seconds cast time +2.6 seconds effect delay.|With max level Bloodrage on Bloodseeker, Blood Rite deals 168/224/280/336 damage.|With max level Bloodrage applied on both Bloodseeker and the enemy unit Blood Rite deals 235.2/313.6/392/470.4 damage.|Grants 200 radius flying vision at the center of the affected area for 6 seconds after cast."

    DamageType = eDamageType.Pure

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Radius = New ValueWrapper(600, 600, 600, 600)

    Damage = New ValueWrapper(120, 160, 200, 240)

    silenceduration = New ValueWrapper(3, 4, 5, 6)
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

    Dim damval As New modValue(Damage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemies)
    outmods.Add(dammod)


    Dim silenceval As New modValue(silenceduration, eModifierType.Silence, occurencetime, aghstime)
    silenceval.mValueDuration = silenceduration

    Dim silencemod As New Modifier(silenceval, pointtargetenemies)
    outmods.Add(silencemod)


    Return outmods
  End Function
End Class
