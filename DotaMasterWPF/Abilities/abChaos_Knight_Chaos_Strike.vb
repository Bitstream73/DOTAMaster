Public Class abChaos_Strike
Inherits AbilityBase


  Public critdamage As ValueWrapper
  Public critchance As ValueWrapper
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

    mName = eAbilityName.abChaos_Strike

    Me.EntityName = eEntity.abChaos_Strike


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untChaos_Knight
    mDisplayName = "Chaos Strike"
    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/chaos_knight_chaos_strike_hp2.png"

    Description = "Chaos Knight's mojo gives him a chance to deal bonus damage."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    critdamage = New ValueWrapper(1.25, 1.75, 2.25, 2.75)

    critchance = New ValueWrapper(0.1, 0.1, 0.1, 0.1)
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
                                                theowner As iDisplayUnit, _
                                                thetarget As iDisplayUnit, _
                                                ftarget As iDisplayUnit, _
                                                isfriendbias As Boolean, _
                                                occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList


    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     theowner, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Passive)

    Dim critval As New modValue(critdamage, eModifierType.RightClickDamageMultiplier, occurencetime, aghstime)
    critval.mPercentChance = critchance

    Dim critmod As New Modifier(critval, unittargetenemytarget)
    outmods.Add(critmod)


    Return outmods
  End Function
End Class
