Public Class abChemical_Rage
Inherits AbilityBase
  Public baseattacktime As ValueWrapper
  Public bonushealthregen As ValueWrapper
  Public bonusmanaregen As ValueWrapper
  Public bonusmovespeed As ValueWrapper
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

    mName = eAbilityName.abChemical_Rage
    Me.EntityName = eEntity.abChemical_Rage

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAlchemist
    mDisplayName = "Chemical Rage"
    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/alchemist_chemical_rage_hp2.png"

    Description = "Alchemist causes his Ogre to enter a chemically induced rage, reducing base attack cooldown and increasing movement speed and regeneration."

    ManaCost = New ValueWrapper(50, 100, 150)


    Cooldown = New ValueWrapper(45, 45, 45)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)




    Duration = New ValueWrapper(25, 25, 25)

    baseattacktime = New ValueWrapper(1.4, 1.2, 1)
    bonushealthregen = New ValueWrapper(50, 75, 100)
    bonusmovespeed = New ValueWrapper(30, 40, 50)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)

    Dim atttimeval As New modValue(baseattacktime, eModifierType.BaseAttackTimeChangedTo, occurencetime, aghstime)
    atttimeval.mValueDuration = Duration

    Dim attmod As New Modifier(atttimeval, notargetself)
    outmods.Add(attmod)


    Dim healthval As New modValue(bonushealthregen, eModifierType.HealthRegenAdded, occurencetime, aghstime)
    healthval.mValueDuration = Duration

    Dim healthmod As New Modifier(healthval, notargetself)
    outmods.Add(healthmod)


    Dim manaval As New modValue(bonusmanaregen, eModifierType.ManaRegenAdded, occurencetime, aghstime)
    manaval.mValueDuration = Duration

    Dim manamod As New Modifier(manaval, notargetself)
    outmods.Add(manamod)


    Dim moveval As New modValue(bonusmovespeed, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)

    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 caster As iDisplayUnit, _
                                                 target As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function

End Class
