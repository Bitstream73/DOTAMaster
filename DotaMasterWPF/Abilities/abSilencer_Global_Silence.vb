Public Class abGlobal_Silence
Inherits AbilityBase

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

    mDisplayName = "Global Silence"
    mName = eAbilityName.abGlobal_Silence
    Me.EntityName = eEntity.abGlobal_Silence

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSilencer

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/silencer_global_silence_hp2.png"

    Description = "Silencer stops all sound, preventing enemy heroes and units on the map from casting spells. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(250, 375, 45500)

    Cooldown = New ValueWrapper(130, 130, 130)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    Duration = New ValueWrapper(4, 5, 6)

    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea) 'global
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetenemyheroes = Helpers.GetNoTargetEnemyHeroesInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim silval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    silval.mValueDuration = Duration

    Dim silmod As New Modifier(silval, notargetenemyheroes)
    outmods.Add(silmod)


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
