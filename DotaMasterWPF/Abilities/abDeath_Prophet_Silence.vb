Public Class abSilence
Inherits AbilityBase

Public Sub New()

    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Doesn't prevent usage of items.|Cooldown is reduced with Witchcraft to: 14 / 13 / 12 / 11|Mana Cost is reduced with Witchcraft to: 70 / 65 / 60 / 55" '"

    mName = eAbilityName.abSilence
    Me.EntityName = eEntity.abSilence

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDeath_Prophet

    mAbilityPosition = 2

    mDisplayName = "Silence"
    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/death_prophet_silence_hp2.png"

    Description = "Prevents enemy units in a target area from casting spells."

    ManaCost = New ValueWrapper(80, 80, 80, 80)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(425, 425, 425, 425)

    Duration = New ValueWrapper(3, 4, 5, 6)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemyunits = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim slinceval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    slinceval.mValueDuration = Duration

    Dim thesilence As New Modifier(slinceval, pointtargetenemyunits)
    outmods.Add(thesilence)

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
