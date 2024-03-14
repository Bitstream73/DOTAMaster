Public Class abShackles
Inherits AbilityBase
  Dim damagetick As ValueWrapper
  Dim damagetickinterval As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix'
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Shackles"
    mName = eAbilityName.abShackles
    Me.EntityName = eEntity.abShackles

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Shaman

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_shaman_shackles_hp2.png"

    Description = "CHANNELED - Magically binds an enemy unit so that it cannot move or attack, while dealing damage over time."

    ManaCost = New ValueWrapper(140, 150, 160, 170)

    Cooldown = New ValueWrapper(16, 16, 16, 16)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical


    damagetick = New ValueWrapper(4, 4, 4, 4)
    damagetickinterval = New ValueWrapper(0.1, 0.1, 0.1, 0.1)
    Duration = New ValueWrapper(2.75, 3.5, 4.25, 5)
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

    Dim muteval As New modValue(Duration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    muteval.mValueDuration = Duration

    Dim mutemod As New Modifier(muteval, unittargetenemy)
    outmods.Add(mutemod)


    Dim damval As New modValue(damagetick, eModifierType.DamageMagicalOverTimeInflicted, damagetickinterval, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetenemy)
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
