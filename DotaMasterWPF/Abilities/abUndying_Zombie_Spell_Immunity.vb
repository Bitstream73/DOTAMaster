Public Class abUndying_Zombie_Spell_Immunity
  Inherits AbilityBase



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

    mDisplayName = "Spell Immunity"
    mName = eAbilityName.abUndying_Zombie_Spell_Immunity
    Me.EntityName = eEntity.abUndying_Zombie_Spell_Immunity

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untUndying_Zombie

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    ' mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/01/Spell_Immunity_icon.png?version=844544b8b984f50ad85674c212798563"
    WebpageLink = "http://dota2.gamepedia.com/Undying#Undying_Zombie"
    Description = "This creature does not feel the effects of most magical spells."
    Notes = ""

    ' mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    'mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)

    Dim immval As New modValue(0, eModifierType.MagicImmunity, occurencetime)

    Dim immod As New Modifier(immval, passiveself)
    outmods.Add(immod)
    Return outmods
  End Function
End Class
