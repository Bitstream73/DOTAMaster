Public Class abGust
Inherits AbilityBase
  Private mknckbackduration As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Doesn't stop usage of items.|Knockback distance is inversely proportional to travel range, 350 at closest, 0 at 900|Does not interrupt channeling of items.|As with all silences, it will not stop Wraith King's Reincarnation|Disables Riki 's Permanent Invisibility.|As this ability has the power to knockback enemies it will also cancel Templar Assassin's Meld, as the knockback forcibly changes her position if it hits her."

    mDisplayName = "Gust"
    mName = eAbilityName.abGust
    Me.EntityName = eEntity.abGust

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDrow_Ranger

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/drow_ranger_wave_of_silence_hp2.png"
    WebpageLink = ""
    Description = "Releases a wave that silences and knocks back enemy units. Knockback distance is relative to how close they are to you."

    ManaCost = New ValueWrapper(90, 90, 90, 90)

    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)


    Range = New ValueWrapper(900, 900, 900, 900)

    Radius = New ValueWrapper(250, 250, 250, 250)

    Duration = New ValueWrapper(3, 4, 5, 6)

    mknckbackduration = New ValueWrapper(0.6, 0.7, 0.8, 0.9)
  End Sub

  Public Function KnockbackDuration(abilitylevel) As Double
    Return mknckbackduration.Value(abilitylevel)
  End Function
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim coneenemyunitsinfo = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)



    Dim sliencveval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    sliencveval.mValueDuration = Duration

    Dim silence As New Modifier(sliencveval, coneenemyunitsinfo)
    outmods.Add(silence)


    Dim knockval As New modValue(1, eModifierType.Knockback, occurencetime)

    Dim knockback As New Modifier(knockval, coneenemyunitsinfo)
    outmods.Add(knockback)

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
