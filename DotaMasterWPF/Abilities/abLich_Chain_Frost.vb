Public Class abChain_Frost
Inherits AbilityBase
  Public jumpscount As ValueWrapper
  Public slowduration As ValueWrapper
  Public moveslow As ValueWrapper
  Public attackslow As ValueWrapper
  Public jumprange As ValueWrapper

  Public scepterdamage As New List(Of Double?)
  Public scepterrange As New List(Of Double?)
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

    mDisplayName = "Chain Frost"
    mName = eAbilityName.abChain_Frost
    Me.EntityName = eEntity.abChain_Frost

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLich

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lich_chain_frost_hp2.png"

    Description = "Releases an orb of frost that bounces up to 10 times, slowing and damaging enemy units. The first target is mini-stunned. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(200, 325, 500)

    Cooldown = New ValueWrapper(120, 90, 60)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    jumpscount = New ValueWrapper(10, 10, 10)

    slowduration = New ValueWrapper(4, 4, 4)

    moveslow = New ValueWrapper(0.3, 0.3, 0.3)

    attackslow = New ValueWrapper(20, 20, 20)

    jumprange = New ValueWrapper(575, 575, 575)

    Damage = New ValueWrapper(280, 370, 460)
    scepterdamage.Add(370)
    scepterdamage.Add(460)
    scepterdamage.Add(550)
    Damage.LoadScepterValues(scepterdamage)

    Range = New ValueWrapper(750, 750, 750)
    scepterrange.Add(850)
    scepterrange.Add(850)
    scepterrange.Add(850)
    Range.LoadScepterValues(scepterrange)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalBouncesInflicted, occurencetime, aghstime)
    damval.Charges = jumpscount
    damval.mRange = Range

    Dim dammod As New Modifier(damval, unittargetenemies)
    outmods.Add(dammod)



    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = slowduration

    Dim movemod As New Modifier(moveval, unittargetenemies)
    outmods.Add(movemod)



    Dim attval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = slowduration

    Dim attmod As New Modifier(attval, unittargetenemies)
    outmods.Add(attmod)


    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim stunval As New modValue(1, eModifierType.MiniStun, occurencetime)

    Dim stunmod As New Modifier(stunval, unittargetenemytarget)
    outmods.Add(stunmod)

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
