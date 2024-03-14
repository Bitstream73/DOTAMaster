Public Class abSoul_Rip
Inherits AbilityBase
  Dim damhealperunit As ValueWrapper
  Dim maxunits As ValueWrapper
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

    mDisplayName = "Soul Rip"
    mName = eAbilityName.abSoul_Rip
    Me.EntityName = eEntity.abSoul_Rip

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUndying

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/undying_soul_rip_hp2.png"

    Description = "Redirects the flow of energy through a target friendly or enemy unit, healing or damaging it depending on how many units are near Undying. Each counted unit takes damage."

    ManaCost = New ValueWrapper(50, 75, 100, 125)

    Cooldown = New ValueWrapper(24, 18, 12, 6)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Radius = New ValueWrapper(1300, 1300, 1300, 1300)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetunit = Helpers.GetUnitTargetUnitInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    '!!!!!Fix after new constructor with friend and enemy targets
    'If PageHandler.theGame.IDIsAlly(thecaster, thetarget) Then

    '  Dim healval As New modValue(damhealperunit, eModifierType.HealAddedPerUnit, occurencetime, aghstime)
    '  healval.Charges = maxunits

    '  Dim healmod As New Modifier(healval, unittargetunit)
    '  outmods.Add(healmod)
    'Else

    '  Dim damval As New modValue(damhealperunit, eModifierType.DamageMagicalInflictedPerUnit, occurencetime, aghstime)
    '  damval.Charges = maxunits

    '  Dim dammod As New Modifier(damval, unittargetunit)
    '  outmods.Add(dammod)
    'End If


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
