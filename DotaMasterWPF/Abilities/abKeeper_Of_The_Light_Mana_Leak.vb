Public Class abMana_Leak
Inherits AbilityBase

  Public manaleakpercent As ValueWrapper
  Public stunduration As ValueWrapper

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

    mDisplayName = "Mana Leak"
    mName = eAbilityName.abMana_Leak
    Me.EntityName = eEntity.abMana_Leak

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKeeper_of_the_Light

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/keeper_of_the_light_mana_leak_hp2.png"

    Description = "Weakens an enemy's magical essence, causing them to lose mana as they move. If the enemy loses all of its mana, it will be stunned."

    ManaCost = New ValueWrapper(75, 75, 75, 75)

    Cooldown = New ValueWrapper(16, 16, 16, 16)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(5, 6, 7, 8)

    manaleakpercent = New ValueWrapper(0.05, 0.05, 0.05, 0.05)

    stunduration = New ValueWrapper(1.5, 2, 2.5, 3)

    Range = New ValueWrapper(550, 700, 850, 1000)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim manaval As New modValue(manaleakpercent, eModifierType.ManaRemovedPercentoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    manaval.mValueDuration = Duration

    Dim manamod As New Modifier(manaval, unittargetenemy)
    outmods.Add(manamod)


    'stun
    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)

    Dim stunmod As New Modifier(stunval, unittargetenemy)
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
