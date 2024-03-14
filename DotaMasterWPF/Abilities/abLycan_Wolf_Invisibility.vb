Public Class abLycan_Wolf_Invisibility
  Inherits AbilityBase


  Public procchance As ValueWrapper
  Public critdamage As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Available for level 3-4 wolves"

    mDisplayName = "Invisibility"
    mName = eAbilityName.abLycan_Wolf_Invisibility
    Me.EntityName = eEntity.abLycan_Wolf_Invisibility

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLycan_Wolf

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/c3/Invisibility_%28Lycan_Wolf%29_icon.png"

    Description = "Permanently invisible when not attacking."

    'mManaCost = New ValueWrapper(145, 145, 145, 145)

    'mCooldown = New ValueWrapper(30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyTarget)

    'mDuration = New ValueWrapper(55, 55, 55, 55)


    'baseattacktime = New ValueWrapper(1.25, 1.2, 1.15, 1.1)

    'mDamage = New ValueWrapper(18, 29, 37, 46)

    'hp = New ValueWrapper(200, 240, 280, 320)

    procchance = New ValueWrapper(-1, 0.3, 0.3, 0.3)
    critdamage = New ValueWrapper(-1, 1.7, 1.7, 1.7)
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


    Dim Autocastself = Helpers.GetAutoCastSelfInfo(theability_InfoID, _
                                                   caster, _
                                                   target, _
                                                   "", eModifierCategory.Active)

    Dim invisval As New modValue(occurencetime.Lifespan.count, eModifierType.InvisibilityWhenNotAttacking, occurencetime)

    Dim invismod As New Modifier(invisval, Autocastself)
    outmods.Add(invismod)

    Return outmods
  End Function

End Class
