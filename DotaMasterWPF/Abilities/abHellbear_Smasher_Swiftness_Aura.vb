Public Class abHellbear_Smasher_Swiftness_Aura
  Inherits AbilityBase



  Dim attspeedbonus As ValueWrapper
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

    mDisplayName = "Swiftness Aura"
    mName = eAbilityName.abHellbear_Smasher_Swiftness_Aura
    Me.EntityName = eEntity.abHellbear_Smasher_Swiftness_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHellbear_Smasher

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/2f/Swiftness_Aura_%28Hellbear_Smasher%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Hellbear_Camp"
    Description = "The seasoned Hellbear Smasher attacks more quickly and inspires nearby allies to follow suit."
    Notes = "Fully stacks with other attack speed increasing effects.|The aura 's buff lingers for 0.5 seconds."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    Radius = New ValueWrapper(900)
    attspeedbonus = New ValueWrapper(15)

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
                                      thecaster As iDisplayUnit, _
                                      thetarget As iDisplayUnit, _
                                      ftarget As iDisplayUnit, _
                                      isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim passiveauraallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)


    Dim attval As New modValue(attspeedbonus, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.mRadius = Radius

    Dim attmodallies As New Modifier(attval, passiveauraallies)
    outmods.Add(attmodallies)

    Dim attmodself As New Modifier(attval, passiveself)
    outmods.Add(attmodself)
    Return outmods

  End Function

 
End Class
