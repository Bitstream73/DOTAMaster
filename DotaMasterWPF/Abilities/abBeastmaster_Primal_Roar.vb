Public Class abPrimal_Roar
Inherits AbilityBase
  Public stunduration As ValueWrapper
  Public shoutwidth As ValueWrapper
  Public moveslow As ValueWrapper
  Public attackslow As ValueWrapper
  Public slowduration As ValueWrapper

  Public scepterrange As New List(Of Double?)
  Public sceptercooldown As New List(Of Double?)
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
    mDisplayName = "Primal Roar"
    mName = eAbilityName.abPrimal_Roar
    Me.EntityName = eEntity.abPrimal_Roar

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBeastmaster

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/beastmaster_primal_roar_hp2.png"

    Description = "A deafening roar that deals damage and stuns the target enemy unit, while opening a path between Beastmaster and his prey. Nearby enemies also take damage and have their movement speed and attack rate reduced. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(150, 175, 200)


    Cooldown = New ValueWrapper(80, 75, 70)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    stunduration = New ValueWrapper(3, 3.5, 4)

    Damage = New ValueWrapper(200, 250, 300)

    shoutwidth = New ValueWrapper(300, 300, 300)

    moveslow = New ValueWrapper(0.5, 0.5, 0.5)

    attackslow = New ValueWrapper(50, 50, 50)

    slowduration = New ValueWrapper(2, 3, 4)

    Radius = New ValueWrapper(300, 300, 300)

    Range = New ValueWrapper(600, 600, 600)
    scepterrange.Add(950)
    scepterrange.Add(950)
    scepterrange.Add(950)
    Range.LoadScepterValues(scepterrange)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetconeenemyunits = Helpers.GetUnitTargetConeUntargettedEnemyUnitsInfo(theability_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim stunconemod As New Modifier(stunval, unittargetconeenemyunits)
    outmods.Add(stunconemod)

    Dim stuntarget As New Modifier(stunval, unittargetenemytarget)
    outmods.Add(stuntarget)


    Dim shoveval As New modValue(1, eModifierType.PushSideways, occurencetime)

    Dim shovecone As New Modifier(shoveval, unittargetconeenemyunits)
    outmods.Add(shovecone)


    'movespeed
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, unittargetconeenemyunits)
    outmods.Add(movemod)


    'attspeed
    Dim attval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, unittargetconeenemyunits)
    outmods.Add(attmod)


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
