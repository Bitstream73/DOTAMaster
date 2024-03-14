Public Class abFinger_Of_Death
Inherits AbilityBase
  Dim scepterdamage As New List(Of Double?)
  Dim sceptermanacost As New List(Of Double?)
  Dim sceptercooldown As New List(Of Double?)
  Dim aoe As ValueWrapper
  Dim scepteraoe As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Finger of Death has a 0.25 delay before the damage is applied after the spell is cast, allowing certain abilities to avoid the damage." '"

    mDisplayName = "Finger of Death"
    mName = eAbilityName.abFinger_Of_Death

    Me.EntityName = eEntity.abFinger_Of_Death

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLion

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lion_finger_of_death_hp2.png"

    Description = "Rips at an enemy unit, trying to turn it inside-out. Deals massive damage. Upgradable with Aghanim's Scepter."


    ManaCost = New ValueWrapper(200, 420, 650)
    sceptermanacost.Add(200)
    sceptermanacost.Add(420)
    sceptermanacost.Add(625)
    ManaCost.LoadScepterValues(sceptermanacost)

    Cooldown = New ValueWrapper(160, 100, 40)
    sceptercooldown.Add(100)
    sceptercooldown.Add(60)
    sceptercooldown.Add(20)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(600, 725, 850)
    scepterdamage.Add(725)
    scepterdamage.Add(875)
    scepterdamage.Add(1025)
    Damage.LoadScepterValues(scepterdamage)


    aoe = New ValueWrapper(-1, -1, -1)
    scepteraoe.Add(200)
    scepteraoe.Add(200)
    scepteraoe.Add(200)
    aoe.LoadScepterValues(scepteraoe)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim theoutdamage As New Modifier(damval, unittargetenemy)
    outmods.Add(theoutdamage)


    'scepter aoe

    Dim unittargetUntargettedEnemi = Helpers.GetUnitTargetUntargettedEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim aoedamval As New modValue(aoe, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim aoedam As New Modifier(aoedamval, unittargetUntargettedEnemi)
    outmods.Add(aoedam)

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
