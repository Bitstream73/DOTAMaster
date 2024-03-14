Public Class abDismember
Inherits AbilityBase

  Public dps As ValueWrapper

  Public strengthmulti As ValueWrapper
  Public scepterstrengthmulti As New List(Of Double?)

  Public heroduration As ValueWrapper
  Public creepduration As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Dismember"
    mName = eAbilityName.abDismember
    Me.EntityName = eEntity.abDismember

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPudge

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/pudge_dismember_hp2.png"

    Description = "CHANNELED - Pudge chows down on an enemy unit, disabling it and dealing damage over time. Lasts 3 seconds on Heroes, 6 seconds on creeps. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(100, 130, 170)

    Cooldown = New ValueWrapper(30, 30, 30)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    heroduration = New ValueWrapper(6, 6, 6)
    creepduration = New ValueWrapper(3, 3, 3)

    strengthmulti = New ValueWrapper(-1, -1, -1)
    scepterstrengthmulti.Add(1)
    scepterstrengthmulti.Add(1)
    scepterstrengthmulti.Add(1)
    strengthmulti.LoadScepterValues(scepterstrengthmulti)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyhero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim unittargetenemycreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'damage for heroes and creeps
    Dim damheroval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damheroval.mValueDuration = heroduration

    Dim damheromod As New Modifier(damheroval, unittargetenemyhero)
    outmods.Add(damheromod)


    Dim damcreepval As New modValue(dps, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damcreepval.mValueDuration = creepduration

    Dim damcreepmod As New Modifier(damcreepval, unittargetenemycreep)
    outmods.Add(damcreepmod)

    'disable for heroes and creeps
    Dim disheroval As New modValue(heroduration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    disheroval.mValueDuration = heroduration

    Dim disheromod As New Modifier(disheroval, unittargetenemyhero)
    outmods.Add(disheromod)

    Dim discreepval As New modValue(creepduration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    discreepval.mValueDuration = creepduration

    Dim discreepmod As New Modifier(discreepval, unittargetenemycreep)
    outmods.Add(discreepmod)

    'added scepter damage
    Dim sceptdamheroval As New modValue(strengthmulti, eModifierType.DamageMagicaloTAsMultofStr, occurencetime, aghstime)
    sceptdamheroval.mValueDuration = heroduration

    Dim sceptdamheromod As New Modifier(sceptdamheroval, unittargetenemyhero)
    outmods.Add(sceptdamheromod)

    Dim sceptdamcreepval As New modValue(strengthmulti, eModifierType.DamageMagicaloTAsMultofStr, occurencetime, aghstime)
    sceptdamcreepval.mValueDuration = creepduration

    Dim sceptdamcreepmod As New Modifier(sceptdamcreepval, unittargetenemycreep)
    outmods.Add(sceptdamcreepmod)

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
