Public Class abPower_Cogs
Inherits AbilityBase

  Public manahealthdrain As ValueWrapper
  Public attacksrequired As ValueWrapper
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
    mDisplayName = "Power Cogs"
    mName = eAbilityName.abPower_Cogs
    Me.EntityName = eEntity.abPower_Cogs

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClockwerk

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rattletrap_power_cogs_hp2.png"

    Description = "Forms a barrier of energized cogs around Clockwerk, trapping any units that are near. Enemies outside the trap that touch a cog are knocked back, losing health and mana. Once a cog has delivered a shock, it will power down. Cogs can be destroyed by enemy attacks, but Clockwerk can destroy them with just one."

    ManaCost = New ValueWrapper(50, 60, 70, 80)

    Cooldown = New ValueWrapper(15, 15, 15, 15)
    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untUnits)

    DamageType = eDamageType.Magical

    Duration = New ValueWrapper(5, 6, 7, 8)

    manahealthdrain = New ValueWrapper(80, 120, 160, 200)

    attacksrequired = New ValueWrapper(2, 2, 2, 3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim notargetunits = Helpers.GetNoTargetUnitsInfo(theability_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "", eModifierCategory.Active)

    Dim barrierval As New modValue(Duration, eModifierType.Barrier, occurencetime, aghstime)
    barrierval.mValueDuration = Duration
    barrierval.Charges = attacksrequired

    Dim barriermod As New Modifier(barrierval, notargetunits)
    outmods.Add(barriermod)

    Dim healthval As New modValue(manahealthdrain, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim healthmod As New Modifier(healthval, notargetunits)
    outmods.Add(healthmod)


    Dim manaval As New modValue(manahealthdrain, eModifierType.ManaDrained, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, notargetunits)
    outmods.Add(manamod)


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
