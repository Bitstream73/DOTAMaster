Public Class abKobold_Foreman_Speed_Aura
  Inherits AbilityBase

  Public movebonus As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Speed Aura"
    mName = eAbilityName.abKobold_Foreman_Speed_Aura
    Me.EntityName = eEntity.abKobold_Foreman_Speed_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKobold_Foreman

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/7/78/Speed_Aura_%28Kobold_Foreman%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Kobold_Camp"
    Description = "The Kobold Foreman's cruel efficiency increases his movement speed and the movement speed of all nearby allies."
    Notes = "Fully stacks with other movement speed increasing effects.|The aura's buff lingers for 0.5 seconds."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    movebonus = New ValueWrapper(0.12)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim auraallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim speedval As New modValue(movebonus, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)

    Dim speedmod As New Modifier(speedval, auraallies)
    outmods.Add(speedmod)

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
