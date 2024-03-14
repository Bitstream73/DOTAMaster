Public Class abNatures_Attendants
Inherits AbilityBase
  Public healpersecond As ValueWrapper
  Public wispcount As ValueWrapper
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

    mDisplayName = "Nature's Addendants"
    mName = eAbilityName.abNatures_Attendants
    Me.EntityName = eEntity.abNatures_Attendants

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnchantress

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enchantress_natures_attendants_hp2.png"

    Description = "A cloud of wisps heals Enchantress and any friendly units nearby. Lasts 10 seconds."

    ManaCost = New ValueWrapper(125, 140, 155, 170)


    Cooldown = New ValueWrapper(45, 45, 45, 45)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untAlliedUnits)

    healpersecond = New ValueWrapper(10, 10, 10, 10)


    Radius = New ValueWrapper(275, 275, 275, 275)

    wispcount = New ValueWrapper(3, 5, 7, 9)

    Duration = New ValueWrapper(10, 10, 10, 10)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList



    Dim activeauraalliesandself = Helpers.GetActiveAuraAlliedUnitsandSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim healval As New modValue(wispcount, eModifierType.RandomTargetHealAdded, occurencetime, aghstime)
    healval.Charges = wispcount
    healval.mValueDuration = Duration
    healval.mRadius = Radius

    Dim healmod As New Modifier(healval, activeauraalliesandself)
    outmods.Add(healmod)


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
