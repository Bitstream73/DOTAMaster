Public Class abTime_Lapse
Inherits AbilityBase

  Public timelapsetime As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Time Lapse Applies a strong dispel on Weaver upon cast.|Time Lapse icon.png Time Lapse only affects Weaver's position, health, mana and status debuffs. Buffs are not removed.|It doesn't matter how long Weaver is already affected by debuffs, they will simply be completely removed, if they can be removed.|Time Lapse icon.png Time Lapse can never kill Weaver. If Weaver was dead less than 5 seconds ago, Timelapse will not cause him to die again.|Time Lapse icon.png Time Lapse does not damage Weaver, it manipulates his health. So it does not interact with any on-damage effect like Cold Snap icon.png Cold Snap, Aphotic Shield icon.png Aphotic Shield or Blink Dagger icon.png Blink Dagger." '"

    mDisplayName = "Time Lapse"
    mName = eAbilityName.abTime_Lapse
    Me.EntityName = eEntity.abTime_Lapse

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWeaver

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/weaver_time_lapse_hp2.png"

    Description = "Weaver warps backward to whatever position it was in five seconds earlier--regaining the HP and mana from that time. No effect on cooldown, gold or experience."


    ManaCost = New ValueWrapper(150, 75, 0)

    Cooldown = New ValueWrapper(60, 50, 40)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)


    timelapsetime = New ValueWrapper(5, 5, 5)

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

    Dim thelapseval As New modValue(timelapsetime, eModifierType.TimeLapse, occurencetime, aghstime)
    thelapseval.mValueDuration = timelapsetime

    Dim thetimelapse As New Modifier(thelapseval, notargetself)
    outmods.Add(thetimelapse)

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
