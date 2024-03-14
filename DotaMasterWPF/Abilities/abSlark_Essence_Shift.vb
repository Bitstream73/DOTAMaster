Public Class abEssence_Shift
  Inherits AbilityBase


  'Public maxhealthlost As ValueWrapper
  'Public healthregenlost As ValueWrapper
  'Public armorlost As ValueWrapper
  'Public attspeedlost As ValueWrapper
  'Public maxmanalost As ValueWrapper
  'Public manaregenlost As ValueWrapper
  'Public attackdamagelost As ValueWrapper

  Public agigained As ValueWrapper
  Public allattributeloss As ValueWrapper


  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Essence Shift"
    mName = eAbilityName.abEssence_Shift
    Me.EntityName = eEntity.abEssence_Shift

    'mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlark

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slark_essence_shift_hp2.png"

    Description = "Slark steals the life essence of enemy heroes with his attacks, draining each of their attributes and converting them to bonus Agility."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    agigained = New ValueWrapper(3, 3, 3, 3)

    allattributeloss = New ValueWrapper(1, 1, 1, 1)

    Duration = New ValueWrapper(120, 60, 30, 15)
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

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim agival As New modValue(agigained, eModifierType.AgiAdded, occurencetime, aghstime)
    agival.mValueDuration = Duration

    Dim agimod As New Modifier(agival, unittargetself)
    outmods.Add(agimod)

    'str
    Dim strloss As New modValue(allattributeloss, eModifierType.StrSubtracted, occurencetime, aghstime)
    strloss.mValueDuration = Duration

    Dim strmod As New Modifier(strloss, unittargetenemy)
    outmods.Add(strmod)

    'agi
    Dim agiloss As New modValue(allattributeloss, eModifierType.AgiSubtracted, occurencetime, aghstime)
    agiloss.mValueDuration = Duration

    Dim agilossmod As New Modifier(agiloss, unittargetenemy)
    outmods.Add(agilossmod)

    'int
    Dim intloss As New modValue(allattributeloss, eModifierType.IntSubtracted, occurencetime, aghstime)
    intloss.mValueDuration = Duration

    Dim intlossmod As New Modifier(intloss, unittargetenemy)
    outmods.Add(intlossmod)

    Return outmods
  End Function
End Class
