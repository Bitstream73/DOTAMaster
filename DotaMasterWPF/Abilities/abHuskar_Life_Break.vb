Public Class abLife_Break
Inherits AbilityBase
  Public damagedealt As ValueWrapper
  Public scepterdamagedealt As New List(Of Double?)

  Public damagetaken As ValueWrapper
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper

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

    mDisplayName = "Life Break"
    mName = eAbilityName.abLife_Break
    Me.EntityName = eEntity.abLife_Break

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHuskar

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/huskar_life_break_hp2.png"

    Description = "Huskar draws upon his health to break an enemy's life, leaping at a target within attack range to inflict a percentage of that hero's current HP, and slow at the cost of his own vitality. While leaping, Huskar is magic immune. Slow lasts 5 seconds. Upgradable by Aghanim's Scepter."


    Cooldown = New ValueWrapper(12, 12, 12)
    sceptercooldown.Add(4)
    sceptercooldown.Add(4)
    sceptercooldown.Add(4)
    Cooldown.LoadScepterValues(sceptercooldown)


    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    damagedealt = New ValueWrapper(0.35, 0.35, 0.35)
    scepterdamagedealt.Add(0.65)
    scepterdamagedealt.Add(0.65)
    scepterdamagedealt.Add(0.65)
    damagedealt.LoadScepterValues(scepterdamagedealt)

    damagetaken = New ValueWrapper(0.35, 0.35, 0.35)

    moveslow = New ValueWrapper(0.4, 0.5, 0.6)

    slowduration = New ValueWrapper(4, 5, 6)

    Range = New ValueWrapper(550, 550, 550)
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

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim leapval As New modValue(1, eModifierType.PullForward, occurencetime)
    leapval.mRange = Range

    Dim leapmod As New Modifier(leapval, notargetself)
    outmods.Add(leapmod)

    Dim damselfval As New modValue(damagetaken, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim damselfmod As New Modifier(damselfval, notargetself)
    outmods.Add(damselfmod)

    Dim damfoeval As New modValue(damagedealt, eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced, occurencetime, aghstime)

    Dim damfoemod As New Modifier(damfoeval, unittargetenemy)
    outmods.Add(damfoemod)


    Dim slowfoeval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowfoeval.mValueDuration = slowduration

    Dim slowfoemod As New Modifier(slowfoeval, unittargetenemy)
    outmods.Add(slowfoemod)


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
