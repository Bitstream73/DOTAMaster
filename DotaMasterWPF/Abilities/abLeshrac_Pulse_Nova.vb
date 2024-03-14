Public Class abPulse_Nova
  Inherits AbilityBase

  Public manapersec As ValueWrapper
  Public scepterdamage As New List(Of Double?)
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

    Notes = "Instant toggle.|Will deal damage to invisible units." '"

    mDisplayName = "Pulse Nova"
    mName = eAbilityName.abPulse_Nova
    Me.EntityName = eEntity.abPulse_Nova

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLeshrac

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/leshrac_pulse_nova_hp2.png"

    Description = "Creates waves of damaging energy around Leshrac, one per second, to damage nearby enemy units. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(70, 90, 110)

    Cooldown = New ValueWrapper(1, 1, 1)

    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    manapersec = New ValueWrapper(20, 40, 60)

    Radius = New ValueWrapper(450, 450, 450)

    Damage = New ValueWrapper(100, 130, 160)
    scepterdamage.Add(160)
    scepterdamage.Add(190)
    scepterdamage.Add(220)
    Damage.LoadScepterValues(scepterdamage)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim toggleenemies = Helpers.GetToggleEnemyUnitsInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    'Dim tdamage As Double
    'If thecaster.HasAghs(occurencetime, aghstime) Then
    '  tdamage = scepterdamage.Item(theabilitylevel - 1)
    'Else
    '  tdamage = mDamage(theabilitylevel - 1)
    'End If

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalPerSec, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, toggleenemies)
    outmods.Add(thedamage)

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
