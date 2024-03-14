Public Class abJinada
Inherits AbilityBase


  Public critdamage As ValueWrapper
  Public moveslow As ValueWrapper
  Public attackslow As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "When off cooldown , Bounty Hunter's weapons will emit an orange glow." '"

    mName = eAbilityName.abJinada
    Me.EntityName = eEntity.abJinada

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBounty_Hunter

    mAbilityPosition = 2
    mDisplayName = "Jinada"
    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bounty_hunter_jinada_hp2.png"

    Description = "Bounty Hunter plans his next hit, passively adding a critical strike and maim to his next attack."


    Cooldown = New ValueWrapper(12, 10, 8, 6)


    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    critdamage = New ValueWrapper(1.5, 1.75, 2, 2.25)

    moveslow = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    attackslow = New ValueWrapper(25, 25, 25, 25)

    Duration = New ValueWrapper(3, 3, 3, 3)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     theowner As idisplayunit, _
                                                    thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist


    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    'Dim theduration = New TimeSpan(mDuration.Item(theabilitylevel - 1) * TimeSpan.TicksPerSecond)



    'crit
    Dim critval As New modValue(critdamage, eModifierType.CritDamage, Cooldown, occurencetime, aghstime)
    critval.mValueDuration = Duration

    Dim thecritdamage As New Modifier(critval, unittargetenemy)
    outmods.Add(thecritdamage)


    'move slow
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim themove As New Modifier(moveval, unittargetenemy)
    outmods.Add(themove)


    'attack slow
    Dim attackval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attackval.mValueDuration = Duration

    Dim theattack As New Modifier(attackval, unittargetenemy)
    outmods.Add(theattack)


    Return outmods
  End Function
End Class
