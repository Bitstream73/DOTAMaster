Public Class abBuilding_Backdoor_Protection
  Inherits AbilityBase
  Public illusiondamagereduction As ValueWrapper
  Public herodamagereduction As ValueWrapper
  Public healot As ValueWrapper

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

    mName = eAbilityName.abBuilding_Backdoor_Protection
    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBuilding
    Me.EntityName = eEntity.abBuilding_Back_Door_Protection

    mDisplayName = "Backdoor Protection"
    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/6b/Unknown_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Buildings"
    Description = "Activates when there are no nearby enemy creeps, and causes the building to take 25% damage from illusions and 75% damage from other units. If a backdoor-protected building is damaged by an enemy, it will regenerate the lost health at a rate of 90 HP per second. It is still possible to destroy protected buildings with sufficiently high damage. Backdoor protection will not regenerate damage dealt by friendly units."
    Notes = ""

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()

    illusiondamagereduction = New ValueWrapper(0.25)
    herodamagereduction = New ValueWrapper(0.75)

    healot = New ValueWrapper(90)

    mStates = New List(Of String)
    mStates.Add("off")
    mStates.Add("on")

    mStateImageURLs = New List(Of String)
    mStateImageURLs.Add("")
    mStateImageURLs.Add("")
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    If thestateindex = 1 Then

      Dim notargetself = Helpers.GetNoTargetBuildingInfo(theability_InfoID, _
                                                                               thecaster, _
                                                                               thetarget, _
                                                                               "", eModifierCategory.Active)

      Dim illdamval As New modValue(illusiondamagereduction, eModifierType.IllusionDamageReducedTo, occurencetime, aghstime)

      Dim illmod As New Modifier(illdamval, notargetself)
      outmods.Add(illmod)

      Dim herodamval As New modValue(herodamagereduction, eModifierType.HeroDamageReducedTo, occurencetime, aghstime)

      Dim heromod As New Modifier(herodamval, notargetself)
      outmods.Add(heromod)


      Dim regenval As New modValue(healot, eModifierType.HealoTSetTo, occurencetime, aghstime)

      Dim regenmod As New Modifier(regenval, notargetself)
      outmods.Add(regenmod)

      Return outmods
    End If
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
