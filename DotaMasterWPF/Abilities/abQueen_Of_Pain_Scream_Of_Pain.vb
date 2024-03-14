Public Class abScream_Of_Pain
Inherits AbilityBase

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Scream of Pain will hit invisible units.|Has an instant cast time.|Can hit units inside fog of war.|Cannot be disjointed." '"

    mDisplayName = "Scream of Pain"
    mName = eAbilityName.abScream_Of_Pain
    Me.EntityName = eEntity.abScream_Of_Pain

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untQueen_of_Pain

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/queenofpain_scream_of_pain_hp2.png"

    Description = "The Queen of Pain lets loose a piercing scream around her, damaging nearby enemies."

    ManaCost = New ValueWrapper(110, 120, 130, 140)

    Cooldown = New ValueWrapper(7, 7, 7, 7)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(85, 165, 225, 300)

    Radius = New ValueWrapper(475, 475, 475, 475)

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

    Dim screamval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim screamofpain As New Modifier(screamval, activeAuraEnemies)
    outmods.Add(screamofpain)

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
