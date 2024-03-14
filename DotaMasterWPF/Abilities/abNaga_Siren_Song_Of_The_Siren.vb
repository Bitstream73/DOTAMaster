Public Class abSong_Of_The_Siren
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
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Song of the Siren"
    mName = eAbilityName.abSong_Of_The_Siren
    Me.EntityName = eEntity.abSong_Of_The_Siren

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNaga_Siren

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/naga_siren_song_of_the_siren_hp2.png"

    Description = "All enemies in range of the Naga Siren are put into a magical stasis where they cannot act or be attacked. Using Song of the Siren again will end the duration early."


    ManaCost = New ValueWrapper(100, 100, 100)

    Cooldown = New ValueWrapper(180, 120, 60)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(7, 7, 7)

    Radius = New ValueWrapper(1250, 1250, 1250)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim activeaurenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim sleepval As New modValue(Duration, eModifierType.Sleep, occurencetime, aghstime)
    sleepval.mValueDuration = Duration

    Dim sleepmod As New Modifier(sleepval, activeaurenemies)
    outmods.Add(sleepmod)


    Dim invval As New modValue(Duration, eModifierType.Invulnerability, occurencetime, aghstime)
    invval.mValueDuration = Duration

    Dim invmod As New Modifier(invval, activeaurenemies)
    outmods.Add(invmod)




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
