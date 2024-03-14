Public Class abPermanent_Invisibility
Inherits AbilityBase


  Public fadedelay As ValueWrapper
  Public invishealthregen As ValueWrapper
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

    mDisplayName = "Permanent Invisibility"
    mName = eAbilityName.abPermanent_Invisibility
    Me.EntityName = eEntity.abPermanent_Invisibility

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRiki

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/riki_permanent_invisibility_hp2.png"

    Description = "Riki fades into the shadows, staying permanently invisible except while attacking. While silenced, Riki will be visible."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    fadedelay = New ValueWrapper(8, 6, 4, 2)

    invishealthregen = New ValueWrapper(4, 5, 6, 7)

    '  mDuration = New ValueWrapper(, -1, -1, -1)
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
                                                   theowner As idisplayunit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)


    Dim invisval As New modValue(occurencetime.Lifespan.count, eModifierType.Invisibility, occurencetime)
    invisval.mValueDuration = New ValueWrapper(occurencetime.Lifespan.count)

    Dim invismod As New Modifier(invisval, notargetself)
    outmods.Add(invismod)



    Dim regenval As New modValue(invishealthregen, eModifierType.HealthRegenAdded, occurencetime, aghstime)
    regenval.mValueDuration = Duration

    Dim regenmod As New Modifier(regenval, notargetself)
    outmods.Add(regenmod)

    Return outmods

  End Function
End Class
