Public Class abBlur
  Inherits AbilityBase


  Public evasion As ValueWrapper
  Public mapvanishradius As ValueWrapper
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

    mDisplayName = "Blur"
    mName = eAbilityName.abBlur
    Me.EntityName = eEntity.abBlur

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhantom_Assassin

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phantom_assassin_blur_hp2.png"

    Description = "The Phantom Assassin becomes hard to see by blurring her body and disappearing from the enemy minimap when near enemy heroes. Some enemy attacks miss."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    evasion = New ValueWrapper(0.2, 0.3, 0.4, 0.5)

    mapvanishradius = New ValueWrapper(1600, 1600, 1600, 1600)
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

    Dim evval As New modValue(evasion, eModifierType.EvasionPercent, occurencetime, aghstime)

    Dim evmod As New Modifier(evval, notargetself)
    outmods.Add(evmod)


    Dim invisval As New modValue(Radius, eModifierType.MiniMapInvisibility, occurencetime, aghstime)

    Dim invismod As New Modifier(invisval, notargetself)
    outmods.Add(invismod)


    Return outmods
  End Function
End Class
