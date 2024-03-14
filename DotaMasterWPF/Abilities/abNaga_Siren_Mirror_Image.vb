Public Class abMirror_Image
Inherits AbilityBase

  Public imagedamage As ValueWrapper
  Public imagedamagetaken As ValueWrapper
  Public imagecount As ValueWrapper

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

    mDisplayName = "Mirror Image"
    mName = eAbilityName.abMirror_Image
    Me.EntityName = eEntity.abMirror_Image

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNaga_Siren

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/naga_siren_mirror_image_hp2.png"

    Description = "Creates three images of Naga Siren under her control."


    ManaCost = New ValueWrapper(70, 80, 90, 100)

    Cooldown = New ValueWrapper(40, 40, 40, 40)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    imagecount = New ValueWrapper(3, 3, 3, 3)

    Duration = New ValueWrapper(30, 30, 30, 30)

    imagedamage = New ValueWrapper(0.2, 0.25, 0.3, 0.35)

    imagedamagetaken = New ValueWrapper(6, 5, 4, 3)
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

    Dim mirval As New modValue(imagecount, eModifierType.MirrorImage, occurencetime, aghstime)
    mirval.mValueDuration = Duration

    Dim mirmod As New Modifier(mirval, notargetself)
    outmods.Add(mirmod)

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
