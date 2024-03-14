Public Class abHawk_Invisibility
  Inherits AbilityBase


  Public fadetime As ValueWrapper
  Public fadedelay As ValueWrapper
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

    mDisplayName = "Invisibility"
    mName = eAbilityName.abHawk_Invisibility
    Me.EntityName = eEntity.abHawk_Invisibility

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untHawk

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/28/Invisibility_%28Hawk%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Beastmaster#Beastmaster.27s_Hawk"
    Description = "If motionless for four seconds, the Greater Hawk becomes invisible."
    Notes = "Requires Call of the Wild to be level 3.|The fade time + the fade delay equal the total time before the hawk goes invisible (4 seconds)."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    fadetime = New ValueWrapper(1)
    fadedelay = New ValueWrapper(3)

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

    Dim invisval As New modValue(occurencetime.Lifespan.count, eModifierType.Invisibility, occurencetime)
    invisval.mValueDuration = New ValueWrapper(occurencetime.Lifespan.count)

    Dim invismod As New Modifier(invisval, passiveself)
    outmods.Add(invismod)

    Return outmods
  End Function


End Class
