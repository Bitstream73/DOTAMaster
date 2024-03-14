Public Class abMacropyre
Inherits AbilityBase
  Public scepterdamage As New List(Of Double?)

  Public scepterduration As New List(Of Double?)

  Public scepterrange As New List(Of Double?)
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

    mDisplayName = "Macropyre"
    mName = eAbilityName.abMacropyre
    Me.EntityName = eEntity.abMacropyre

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untJakiro

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/jakiro_macropyre_hp2.png"

    Description = "Jakiro lays down a line of flame in front of him, each dealing damage per second to enemy units in a wide area of effect. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(220, 330, 440)

    Cooldown = New ValueWrapper(60, 60, 60)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Duration = New ValueWrapper(7, 7, 7)
    scepterduration.Add(14)
    scepterduration.Add(14)
    scepterduration.Add(14)
    Duration.LoadScepterValues(scepterduration)

    Damage = New ValueWrapper(100, 140, 180)
    scepterdamage.Add(125)
    scepterdamage.Add(175)
    scepterdamage.Add(225)
    Damage.LoadScepterValues(scepterdamage)

    Range = New ValueWrapper(900, 900, 900)
    scepterrange.Add(1800)
    scepterrange.Add(1800)
    scepterrange.Add(1800)
    Range.LoadScepterValues(scepterrange)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim coneenemies = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration
    damval.mRange = Radius

    Dim dammod As New Modifier(damval, coneenemies)
    outmods.Add(dammod)

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
