Public Class abVoodoo_Restoration
Inherits AbilityBase
  Public manapersec As ValueWrapper
  Public healpersec As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Heal is applied in 0.33 second intervals.|Cannot be toggled while silenced.|Does not grant charges to enemy Magic Sticks or Magic Wands.|Can be toggled while channeling without interrupting it." '"

    mDisplayName = "Voodoo Restoration"
    mName = eAbilityName.abVoodoo_Restoration
    Me.EntityName = eEntity.abVoodoo_Restoration

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWitch_Doctor

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/witch_doctor_voodoo_restoration_hp2.png"

    Description = "Witch Doctor focuses his magic to heal nearby allied units."

    ManaCost = New ValueWrapper(20, 30, 40, 50)

    Cooldown = New ValueWrapper(0, 0, 0, 0)

    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Toggle)

    Affects.Add(eUnit.untSelf)


    manapersec = New ValueWrapper(8, 12, 1, 20)

    Radius = New ValueWrapper(500, 500, 500, 500)
    
    healpersec = New ValueWrapper(16, 24, 32, 40)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraallies = Helpers.GetChanneledAuraAlliedUnitsInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                              "", eModifierCategory.Active)

    Dim manaperval As New modValue(manapersec, eModifierType.ManaRegenAdded, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)

    Dim themanapersec As New Modifier(manaperval, auraallies)
    outmods.Add(themanapersec)


    Dim healperval As New modValue(healpersec, eModifierType.HealAdded, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)

    Dim thehealpersec As New Modifier(healperval, auraallies)
    outmods.Add(thehealpersec)


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
