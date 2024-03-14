Public Class abMana_Drain
Inherits AbilityBase
  Public manadrainpersec As ValueWrapper
  Public managainpersec As ValueWrapper
  Public breakdistance As ValueWrapper

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

    Notes = "Destroys Illusions after 0.25 seconds.|Can continue to drain as long as the target is within 1200 range from Lion and they remain visible.|Total mana drained (100/200/300/600)|Will stop draining if the target runs out of mana.|Cannot be dispelled by anything." '"

    mDisplayName = "Mana Drain"
    mName = eAbilityName.abMana_Drain
    Me.EntityName = eEntity.abMana_Drain

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLion

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lion_mana_drain_hp2.png"

    Description = "CHANNELED - Absorbs the magical energies of a target enemy unit by taking mana from it every second."

    ManaCost = New ValueWrapper(10, 10, 10, 10)

    Cooldown = New ValueWrapper(20, 15, 10, 5)

    Duration = New ValueWrapper(5, 5, 5, 5)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    manadrainpersec = New ValueWrapper(20, 40, 60, 120)

    managainpersec = New ValueWrapper(20, 40, 60, 120)
    breakdistance = New ValueWrapper(1200, 1200, 1200, 1200)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim channeledenemy = Helpers.GetChanneledEnemyUnitsInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)

    Dim channeledself = Helpers.GetChanneledSelfInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)

    Dim drainval As New modValue(manadrainpersec, eModifierType.ManaoT, occurencetime, aghstime)
    drainval.mValueDuration = Duration

    Dim thedrain As New Modifier(drainval, channeledenemy)
    outmods.Add(thedrain)


    Dim gainval As New modValue(managainpersec, eModifierType.ManaoTSubtracted, occurencetime, aghstime)
    gainval.mValueDuration = Duration

    Dim thegain As New Modifier(gainval, channeledself)
    outmods.Add(thegain)

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
