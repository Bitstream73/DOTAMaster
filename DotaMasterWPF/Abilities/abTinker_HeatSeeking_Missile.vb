Public Class abHeatSeeking_Missile
  Inherits AbilityBase
  Public numberoftargets As ValueWrapper
  Public scepternumberoftargets As New List(Of Double?)
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

    Notes = "Unlike Tinker's other spells, Heat-Seeking Missile has an instant cast time.|This ability can be upgraded by Aghanim's Scepter.|Can deal up to a maximum of 200/350/500/650 (400/700/1000/1300*) damage split across multiple heroes." '"

    mDisplayName = "Heatseeking Missile"
    mName = eAbilityName.abHeatSeeking_Missile
    Me.EntityName = eEntity.abHeatSeeking_Missile

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTinker

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tinker_heat_seeking_missile_hp2.png"

    Description = "Launches a pair of rockets at the nearest visible enemy heroes within 2500 range. The number of missile targets is doubled with Aghanim's Scepter."

    ManaCost = New ValueWrapper(120, 140, 160, 180)

    Cooldown = New ValueWrapper(25, 25, 25, 25)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(100, 175, 250, 325)

    numberoftargets = New ValueWrapper(2, 2, 2, 2)
    scepternumberoftargets.Add(2 * numberoftargets.Value(0))
    scepternumberoftargets.Add(2 * numberoftargets.Value(1))
    scepternumberoftargets.Add(2 * numberoftargets.Value(2))
    scepternumberoftargets.Add(2 * numberoftargets.Value(3))
    numberoftargets.LoadScepterValues(scepternumberoftargets)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraenemy = Helpers.GetActiveAuraNearestEnemyHeroInfo(theability_InfoID, _
                                                              thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim rocketval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    rocketval.Charges = numberoftargets

    Dim therockets As New Modifier(rocketval, auraenemy)
    outmods.Add(therockets)


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
