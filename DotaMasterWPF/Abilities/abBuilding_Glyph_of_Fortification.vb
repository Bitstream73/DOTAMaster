Public Class abBuilding_Glyph_of_Fortification
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

    mName = eAbilityName.abBuilding_Glyph_of_Fortification
    Me.EntityName = eEntity.abBuilding_Glyph_Of_Fortification

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBuilding

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False
    mDisplayName = "Glyph of Fortification"
    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/6b/Unknown_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Glyph_of_Fortification"
    Description = " When activated, it grants a massive impenetrable armor bonus to all buildings belonging to that team, including towers, barracks, and the Ancient, making them immune any source of incoming damage. A team's Glyph cooldown is instantly refreshed when they lose a Tier 1 tower."
    Notes = ""

    'mManaCost = New ValueWrapper()

    Cooldown = New ValueWrapper(0)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untBuildings)

    Duration = New ValueWrapper(5)

    mStates = New List(Of String)
    mStates.Add("Off")
    mStates.Add("On")

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


    If thestateindex = 1 Then
      Dim outmods As New ModifierList

      Dim notargetself = Helpers.GetNoTargetBuildingsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

      Dim invul As New modValue(Duration, eModifierType.Invulnerability, occurencetime, aghstime)
      invul.mValueDuration = Duration

      Dim invmod As New Modifier(invul, notargetself)
      outmods.Add(invmod)

      Return outmods
    End If
    Return Nothing
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
