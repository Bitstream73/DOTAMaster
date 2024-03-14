Public Class abCurse_Of_The_Silent
Inherits AbilityBase
  Public manaloss As ValueWrapper
  Public dampersec As ValueWrapper
  Public interval As ValueWrapper
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

    mDisplayName = "Curse of the Silent"
    mName = eAbilityName.abCurse_Of_The_Silent
    Me.EntityName = eEntity.abCurse_Of_The_Silent

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSilencer

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/silencer_curse_of_the_silent_hp2.png"

    Description = "Curses the target area, causing enemy Heroes to take damage and lose mana until they cast a spell."

    ManaCost = New ValueWrapper(75, 95, 115, 135)

    Cooldown = New ValueWrapper(20, 16, 12, 8)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    manaloss = New ValueWrapper(8, 16, 24, 32)

    dampersec = New ValueWrapper(20, 35, 50, 65)


    interval = New ValueWrapper(1, 1, 1, 1)

    Duration = New ValueWrapper(6, 6, 6, 6)

    Radius = New ValueWrapper(350, 350, 350, 350)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)


    Dim manacastval As New modValue(manaloss, eModifierType.ManaDrainedUntilSpellcast, interval, occurencetime, aghstime)
    manacastval.mValueDuration = Duration

    Dim manacastmod As New Modifier(manacastval, pointtargetenemies)
    outmods.Add(manacastmod)


    Dim damcastval As New modValue(dampersec, eModifierType.DamageMagicalInflictedUntilSpellcast, interval, occurencetime, aghstime)
    damcastval.mValueDuration = Duration

    Dim dammod As New Modifier(damcastval, pointtargetenemies)
    outmods.Add(dammod)



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
