Public Class abRoshan_Spell_Block
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

    mDisplayName = "Spell Block"
    mName = eAbilityName.abRoshan_Spell_Block
    Me.EntityName = eEntity.abRoshan_Spell_Block

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRoshan

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/8/8c/Spell_Block_%28Roshan%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Roshan"
    Description = "Roshan will block one targeted spell."
    Notes = "This spells blocks spells in the same way as Linken's Sphere does.|A list of blocked spells can be found here.|Besides this, Roshan additionally is untargetable by certain spells. A list of spells can be found below."

    ' mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(15)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    '    mAffects.Add(eUnit)

    '    mDuration = New ValueWrapper()


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

    Dim spellval As New modValue(1, eModifierType.SpellBlock, occurencetime)
    spellval.mCooldown = Cooldown

    Dim spellmod As New Modifier(spellval, passiveself)
    outmods.Add(spellmod)


    Return outmods
  End Function
End Class
