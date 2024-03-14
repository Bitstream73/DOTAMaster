Public Class abMarksmanship
Inherits AbilityBase


  Dim magilitybonus As ValueWrapper
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

    Notes = "An icy particle effect is visible on Drow Ranger while Marksmanship is active.|Bonus agility and particle effect is lost if an enemy hero (not illusions) comes within 400 range of Drow Ranger."
    mName = eAbilityName.abMarksmanship
    Me.EntityName = eEntity.abMarksmanship

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDrow_Ranger

    mDisplayName = "Marksmanship"
    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/drow_ranger_marksmanship_hp2.png"
    WebpageLink = ""
    Description = "Drow's experiences in battle improve her accuracy and effectiveness in combat, providing a passive bonus to Agility. Grants no bonus if there are enemy heroes within a 400 AoE."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    magilitybonus = New ValueWrapper(40, 60, 80)
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

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim agival As New modValue(magilitybonus, eModifierType.AgiAdded, occurencetime, aghstime)

    Dim agi As New Modifier(agival, passiveselfinfo)
    outmods.Add(agi)

    Return outmods
  End Function
End Class
