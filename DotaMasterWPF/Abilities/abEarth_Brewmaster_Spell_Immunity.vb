Public Class abEarth_Brewmaster_Spell_Immunity
  Inherits AbilityBase



  Public stunduration As ValueWrapper

  Public procchance As ValueWrapper
  Public closedamageRadius As ValueWrapper
  Public fardamageradius As ValueWrapper
  Public closedamage As ValueWrapper
  Public fardamage As ValueWrapper
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

    '    mNotes =

    mDisplayName = "Spell Immunity"
    mName = eAbilityName.abEarth_Brewmaster_Spell_Immunity
    Me.EntityName = eEntity.abEarth_Brewmaster_Spell_Immunity

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Brewmaster

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/e/e5/Spell_Immunity_%28Earth%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Immune to spells."


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                                     caster, _
                                                                     target, _
                                                                     "", eModifierCategory.Active)

    Dim immval As New modValue(occurencetime.Lifespan.count, eModifierType.MagicImmunity, occurencetime, 0)
    immval.mValueDuration = New ValueWrapper(occurencetime.Lifespan.count)

    Dim immmod As New Modifier(immval, notargetself)
    outmods.Add(immmod)

    Return outmods
  End Function



End Class
