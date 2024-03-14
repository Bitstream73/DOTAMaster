Public Class abNether_Blast
Inherits AbilityBase
  Public blastdelay As ValueWrapper
  Public structuredamage As ValueWrapper
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

    mDisplayName = "Nether Blast"
    mName = eAbilityName.abNether_Blast
    Me.EntityName = eEntity.abNether_Blast

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPugna

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/pugna_nether_blast_hp2.png"

    Description = "An exploding pulse deals damage to enemies and structures in the area. Deals half damage to structures."

    ManaCost = New ValueWrapper(85, 105, 125, 145)

    Cooldown = New ValueWrapper(5.5, 5.5, 5.5, 5.5)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(100, 175, 250, 325)


    structuredamage = New ValueWrapper(0.5 * Damage.Value(0), _
                                       0.5 * Damage.Value(1), _
                                       0.5 * Damage.Value(2), _
                                       0.5 * Damage.Value(3))
    blastdelay = New ValueWrapper(0.9, 0.9, 0.9, 0.9)

    Radius = New ValueWrapper(400, 400, 400, 400)
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

    Dim pointtargetstructures = Helpers.GetPointTargetEnemyStructuresInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetenemies)
    outmods.Add(dammod)



    Dim damstructval As New modValue(structuredamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim damstructmod As New Modifier(damstructval, pointtargetstructures)
    outmods.Add(damstructmod)

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
