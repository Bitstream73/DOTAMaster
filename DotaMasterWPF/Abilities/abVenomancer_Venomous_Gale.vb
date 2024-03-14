Public Class abVenomous_Gale
Inherits AbilityBase
  Public strikedamage As ValueWrapper
  Public damageot As ValueWrapper
  Public slow As ValueWrapper
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

    mDisplayName = "Venomous Gale"
    mName = eAbilityName.abVenomous_Gale
    Me.EntityName = eEntity.abVenomous_Gale

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVenomancer

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/venomancer_venomous_gale_hp2.png"

    Description = "Launches a ball of venom in a line, poisoning enemy units so that they take both initial damage and damage over time, as well as suffering slowed movement. Venomous Gale deals damage every 3 seconds over its duration."

    ManaCost = New ValueWrapper(125, 125, 125, 125)


    Cooldown = New ValueWrapper(22, 22, 22, 22)


    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Duration = New ValueWrapper(15, 15, 15, 15)

    strikedamage = New ValueWrapper(25, 50, 75, 100)

    damageot = New ValueWrapper(-1, 30, 60, 90)

    slow = New ValueWrapper(0.5, 0.5, 0.5, 0.5)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim sdamval As New modValue(strikedamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim sdammod As New Modifier(sdamval, pointtargetlineenemies)
    outmods.Add(sdammod)



    Dim dotval As New modValue(damageot, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dotmod As New Modifier(dotval, pointtargetlineenemies)
    outmods.Add(dotmod)


    Dim slowval As New modValue(slow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, pointtargetlineenemies)
    outmods.Add(slowmod)


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
